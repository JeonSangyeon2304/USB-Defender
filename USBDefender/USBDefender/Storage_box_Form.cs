using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Diagnostics;

namespace USBDefender
{
    public partial class Storage_box_Form : Form
    {
        string path = @"C:\Control Panel.{21EC2020-3AEA-1069-A2DD-08002B30309D}";
        string befor_path;
        public Storage_box_Form()
        {
            //Debug 출력
            Debug.WriteLine("------------------------Storage Form------------------------");

            InitializeComponent();

            restorage_btn.BackColor = Color.FromArgb(50, 0, 0, 0);

            restorage_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 0, 0, 0);
            listView1.BringToFront();
        }

        private void Storage_box_Form_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("이름", listView1.Width / 4, HorizontalAlignment.Left);
            listView1.Columns.Add("수정한 날짜", listView1.Width / 4, HorizontalAlignment.Left);
            listView1.Columns.Add("유형", listView1.Width / 4, HorizontalAlignment.Left);
            listView1.Columns.Add("크기", listView1.Width / 4, HorizontalAlignment.Left);

            //행 단위 선택 가능
            listView1.FullRowSelect = true;

            SettingListView(path, 0);
        }

        private void SettingListView(string sFullPath, int i)
        {
            try
            {
                listView1.Items.Clear();
                DirectoryInfo dir = new DirectoryInfo(sFullPath);

                if (i == 1)
                {
                    ListViewItem lsvitem = new ListViewItem();
                    lsvitem.ImageIndex = 2;
                    lsvitem.Text = "...";
                    listView1.Items.Add(lsvitem);
                }

                int DirectCount = 0;

                foreach (DirectoryInfo dirItem in dir.GetDirectories())
                {
                    ListViewItem isvitem = new ListViewItem();

                    isvitem.ImageIndex = 2;
                    isvitem.Text = dirItem.Name;

                    listView1.Items.Add(isvitem);

                    listView1.Items[DirectCount].SubItems.Add(dirItem.CreationTime.ToString());
                    listView1.Items[DirectCount].SubItems.Add("폴더");
                    listView1.Items[DirectCount].SubItems.Add(dirItem.GetFiles().Length.ToString() + "files");

                    DirectCount++;
                }

                FileInfo[] files = dir.GetFiles();
                int Count = 0;
                foreach (FileInfo fileinfo in files)
                {
                    ListViewItem lsvitem = new ListViewItem();
                    lsvitem.ImageIndex = 4;
                    lsvitem.Text = fileinfo.Name;
                    listView1.Items.Add(lsvitem);
                    if (fileinfo.LastWriteTime != null)
                        listView1.Items[Count].SubItems.Add(fileinfo.LastWriteTime.ToString());
                    else
                        listView1.Items[Count].SubItems.Add(fileinfo.CreationTime.ToString());
                    listView1.Items[Count].SubItems.Add(fileinfo.Attributes.ToString());
                    listView1.Items[Count].SubItems.Add(fileinfo.Length.ToString());
                    Count++;
                }
            }

            catch (Exception e)
            {
                MessageBox.Show("에러 발생: " + e.Message);
            }
        }

        private void restorage_btn_Click(object sender, EventArgs e)
        {
            MoveFolder moveFolder = new MoveFolder();
            DirSearch dirSearch = new DirSearch();

            ListView.SelectedListViewItemCollection collection = this.listView1.SelectedItems;

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            string Save_Path = dialog.SelectedPath;

            foreach (ListViewItem item in collection)
            {
                if (!item.Text.Equals("..."))
                {
                    string Origin_path = path + "\\" + item.SubItems[0].Text;

                    if (moveFolder.moveFolder(Origin_path, Save_Path + "\\" + item.SubItems[0].Text))
                    {
                        dirSearch.dirSearch(Origin_path);
                        Directory.Delete(Origin_path);
                    }
                    else
                    {
                        FileInfo file = new FileInfo(Origin_path);
                        if (file.Exists)
                            file.MoveTo(Save_Path + "\\" + item.SubItems[0].Text);
                        else
                            MessageBox.Show("선택된 파일이 없습니다.");
                    }
                    // Debug 출력
                    Debug.WriteLine("Storage Form > restorage_btn_Click /// Origin_path: " + Origin_path);
                }
            }
            this.Close();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index_num = listView1.FocusedItem.Index;
            string selected_list = listView1.Items[index_num].SubItems[0].Text;

            if (listView1.FocusedItem.ImageIndex != 4)
            {
                if (selected_list == "...")
                {
                    // 뒷경로 삭제
                    string[] path_point = path.Split('\\');
                    befor_path = null;
                    // Debug 출력
                    foreach (string list in path_point)
                        Debug.WriteLine("Storage Form > listView_MouseDoubleClick /// path point: " + list);
                    Counting counting = new Counting();
                    int length = counting.count(path_point);
                    for (int i = 0; i < length - 1; i++)
                    {
                        befor_path += path_point[i];
                        befor_path += "\\";
                    }
                    befor_path = befor_path.Substring(0, befor_path.Length - 1);
                    // 만약, 삭제된 결과가 C:일때 C:\t,1로 settinglistview 실행
                    if (befor_path.Equals("C:\\t"))
                    {
                        path = @"C:\t";
                        SettingListView(@"C:\t", 0);
                    }
                    // 아니면 0으로 실행
                    else
                    {
                        path = befor_path;
                        SettingListView(befor_path, 1);
                    }
                    // Debug 출력
                    Debug.WriteLine("Storage Form > listView_MouseDoubleClick /// befor_path: " + befor_path);
                }
                else
                {
                    // Debug 출력
                    Debug.WriteLine("Storage Form > listView_MouseDoubleClick /// 폴더 선택");
                    path += "\\" + selected_list;
                    SettingListView(path, 1);

                    // Debug 출력
                    Debug.WriteLine("Storage Form > listView_MouseDoubleClick /// path: " + path);
                }
            }
        }
    }
}
