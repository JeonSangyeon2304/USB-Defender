using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Diagnostics;


namespace USBDefender
{
    public partial class State_Form : Form
    {
        string local_IP = "Not availble, Please check your network setting!";    // Local IP 저장
        private ListBox listBox = new ListBox();
        string[] device_info = new string[100];
        string index_context;
        bool selected_list = false;
        bool isItemSelected;

        private String PROGRAM_KEY_NAME = "USB Defender";
        private String ASSEMBLY_PATH = Assembly.GetExecutingAssembly().Location;

        Connected_DB connected_DB = new Connected_DB();

        public State_Form()
        {
            InitializeComponent();

            //버튼 투명
            Register_btn.BackColor = Color.FromArgb(50, 0, 0, 0);
            Unregister_btn.BackColor = Color.FromArgb(50, 0, 0, 0);
            storage_box_btn.BackColor = Color.FromArgb(50, 0, 0, 0);
            

            Register_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 0, 0, 0);
            Unregister_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 0, 0, 0);
            storage_box_btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 0, 0, 0);

            Device_List.BringToFront();

            // 자동 실행
            RegistryUtiil.SetAutoStart(PROGRAM_KEY_NAME, ASSEMBLY_PATH);

            device_info[0] = "empty";

            //시작할때 폴더가 없으면 폴더 생성
            string storage_path = @"C:\Control Panel.{21EC2020-3AEA-1069-A2DD-08002B30309D}";
            if (!Directory.Exists(storage_path))
            {
                Directory.CreateDirectory(storage_path);
                Process.Start("attrib.exe", "+h " + "+s \"" + storage_path + "\"");
            }
        }

        private void State_Form_Load(object sender, EventArgs e)
        {
            // Debug 출력
            Debug.WriteLine("------------------------ State Form ------------------------");

            // IP를 획득
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    local_IP = ip.ToString();
                    break;
                }
            }

            // Debug 출력
            Debug.WriteLine("State Form // State_Form_Load // Get Local IPv4: " + local_IP);

            // Debug 출력
            Debug.WriteLine("State Form // State_Form_Load // State Form >>> ConnectedDB");

            // DB에 검색한 결과가 없으면 계정 등록
            if (!connected_DB.Search(local_IP))
            {
                MessageBox.Show("등록된 계정이 없습니다.\n계정을 등록하세요");
                this.Visible = false;

                // Debug 출력
                Debug.WriteLine("State Form // State_Form_Load // State Form >>> Register Form");

                Register_Form show_register_form = new Register_Form();
                Register_Form.local_IP = local_IP;
                show_register_form.ShowDialog();
            }



            ///
            ThreadParam tp = new ThreadParam();
            Thread t = new Thread(delegate () { tp = tp.ThreadFuction(tp); });
            t.Start();
            while (tp.thread_statue == 0)
            { Thread.Sleep(1); }
            device_info = tp.insert_device_info;
            t.Abort();

            //Debug 출력
            Debug.WriteLine("------------------------State Form------------------------");
            foreach (string line in device_info)
                Debug.WriteLine("State Form > WndProc /// device info: " + line);
            ///



            Refreash();
        }

        protected override void WndProc(ref Message m)
        {
            UInt32 WM_DEVICECHANGE = 0x0219;
            UInt32 DBT_DEVTUP_VOLUME = 0x02;
            UInt32 DBT_DEVICEARRIVAL = 0x8000;
            UInt32 DBT_DEVICEREMOVECOMPLETE = 0x8004;

            // 장치가 연결되었을 때
            if ((m.Msg == WM_DEVICECHANGE) && (m.WParam.ToInt32() == DBT_DEVICEARRIVAL))
            {
                int devType = Marshal.ReadInt32(m.LParam, 4);
                if (devType == DBT_DEVTUP_VOLUME)
                {
                    // Debug 출력
                    Debug.WriteLine("State Form > WndProc /// 장치 연결인식");

                    ThreadParam tp = new ThreadParam();
                    Thread t = new Thread(delegate () { tp = tp.ThreadFuction(tp); });
                    t.Start();
                    while (tp.thread_statue == 0)
                    { Thread.Sleep(1); }
                    device_info = tp.insert_device_info;
                    t.Abort();

                    //Debug 출력
                    Debug.WriteLine("------------------------State Form------------------------");
                    foreach (string line in device_info)
                        Debug.WriteLine("State Form > WndProc /// device info: " + line);

                    Refreash();
                }
            }

            // 장치가 연결 해제 되었을 때
            if ((m.Msg == WM_DEVICECHANGE) && (m.WParam.ToInt32() == DBT_DEVICEREMOVECOMPLETE))
            {
                int devType = Marshal.ReadInt32(m.LParam, 4);
                if (devType == DBT_DEVTUP_VOLUME)
                {
                    // Debug 출력
                    Debug.WriteLine("State Form > WndProc /// 장치 연결해제 인식");

                    ThreadParam tp = new ThreadParam();
                    Thread t = new Thread(delegate () { tp = tp.ThreadFuction(tp); });
                    t.Start();
                    while (tp.thread_statue == 0)
                    { Thread.Sleep(1); }
                    device_info = tp.insert_device_info;
                    t.Abort();

                    Refreash();
                }
            }
            base.WndProc(ref m);
        }

        public void Refreash()
        {
            Device_List.Items.Clear();

            // DB에 비교
            if (device_info[0].Equals("empty"))
                Device_List.Items.Add(new MyListBoxItem(Color.Black, "인식된 장치가 없습니다."));
            else
            {
                
                foreach (string list in device_info) {
                    //정보 분리
                    string[] device = list.Split('/');
                    string drive_letter = device[0] + '/';
                    string PID_VID = device[1];
                    string S_N = device[2];

                    //암호화
                    Encryption_Module encryption_Module = new Encryption_Module();
                    string enc_device_info = encryption_Module.encryption_module(PID_VID, S_N);

                    //DB에 전달
                    Connected_DB connected_DB = new Connected_DB();
                    bool reg = connected_DB.Search(enc_device_info, local_IP);

                    if (reg)
                    {
                        Device_List.Items.Add(new MyListBoxItem(Color.Blue, drive_letter));

                        foreach (string device_info_list in device_info)
                            Debug.WriteLine("State Form > Refreash /// device info: " + device_info_list);
                    }

                    else
                    {
                        // 파일 삭제 및 복사하는 스레드
                        Thread remove = new Thread(new ParameterizedThreadStart(file_remove));
                        remove.Start(drive_letter);
                        try
                        {
                            remove.Join();
                            Device_List.Items.Add(new MyListBoxItem(Color.Red, drive_letter));
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());
                        }
                    }

                }
            }
        }

        static void file_remove(object Drive_letter)
        {
            string letter = (string)Drive_letter;
            CopyFolder copyFolder = new CopyFolder();
            DirSearch dirSearch = new DirSearch();
            string Save_Path = @"C:\Control Panel.{21EC2020-3AEA-1069-A2DD-08002B30309D}";
            if (copyFolder.copyFolder((string)Drive_letter, Save_Path + "\\" + letter[0] + "-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")))
                dirSearch.dirSearch((string)Drive_letter);
        }


        private void Register_btn_Click(object sender, EventArgs e)
        {
            if (selected_list)
            {
                //Debug 출력
                Debug.WriteLine("State Form > Install_btn_Click /// list_index: " + index_context);

                if (index_context.Equals("인식된 장치가 없습니다."))
                {
                    MessageBox.Show("인식된장치가 없습니다.");
                    Refreash();
                }
                else
                {
                    // 해당 아이템의 device info 정보 획득
                    string selected_info = null;

                    foreach (string list in device_info)
                    {
                        string Drive_letter = list.Substring(0, 3);
                        if (index_context.Equals(Drive_letter))
                            selected_info = list;
                    }
                    string[] device = selected_info.Split('/');
                    string drive_letter = device[0] + '/';
                    string PID_VID = device[1];
                    string S_N = device[2];

                    //Debug 출력
                    Debug.WriteLine("State Form > Install_btn_Click /// selected device info: " + selected_info);

                    //암호화
                    Encryption_Module encryption_Module = new Encryption_Module();
                    string enc_device_info = encryption_Module.encryption_module(PID_VID, S_N);

                    //DB에 전달
                    Connected_DB connected_DB = new Connected_DB();
                    bool reg = connected_DB.Search(enc_device_info, local_IP);

                    if(reg)
                        MessageBox.Show("이미 등록된 장치입니다.");
                    else
                        connected_DB.recode(enc_device_info, local_IP, drive_letter);
                }
                selected_list = false;
            }
            else
                MessageBox.Show("선택된 장치가 없습니다.");
        }

        private void Unregister_btn_Click(object sender, EventArgs e)
        {
            if (selected_list)
            {
                //Debug 출력
                Debug.WriteLine("State Form > Install_btn_Click /// list_index: " + index_context);

                if (index_context.Equals("인식된 장치가 없습니다."))
                {
                    MessageBox.Show("인식된장치가 없습니다.");
                    Refreash();
                }
                else
                {
                    // 해당 아이템의 device info 정보 획득
                    string selected_info = null;

                    foreach (string list in device_info)
                    {
                        string Drive_letter = list.Substring(0, 3);
                        if (index_context.Equals(Drive_letter))
                            selected_info = list;
                    }
                    string[] device = selected_info.Split('/');
                    string drive_letter = device[0] + '/';
                    string PID_VID = device[1];
                    string S_N = device[2];

                    //Debug 출력
                    Debug.WriteLine("State Form > Install_btn_Click /// selected device info: " + selected_info);

                    //암호화
                    Encryption_Module encryption_Module = new Encryption_Module();
                    string enc_device_info = encryption_Module.encryption_module(PID_VID, S_N);

                    //DB에 전달
                    Connected_DB connected_DB = new Connected_DB();
                    bool reg = connected_DB.Search(enc_device_info, local_IP);

                    if(reg)
                        connected_DB.recode(enc_device_info, local_IP);
                    else
                        MessageBox.Show("등록된 적이 없는 장치입니다.");
                }
                selected_list = false;
            }
            else
                MessageBox.Show("선택된 장치가 없습니다.");
        }

        private void storage_box_btn_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("State Form --->>> Storage box");

            bool isOpen = true;

            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "Storage_box_Form")
                    isOpen = false;
            }
            if (isOpen)
            {
                Storage_box_Form storage_box = new Storage_box_Form();
                storage_box.Owner = this;
                storage_box.Show();
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
            this.Activate();
        }

        private void onContextClick(object sender, EventArgs e)
        {
            switch (((ToolStripMenuItem)sender).Name)
            {
                case "열기":
                    this.Visible = true;
                    this.Activate();
                    break;
                case "종료":
                    this.notifyIcon1.Dispose();
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                    break;
            }
        }

        private void State_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }


        public struct ThreadParam
        {
            public string[] insert_device_info;
            public int thread_statue;

            public ThreadParam ThreadFuction(ThreadParam paramVal)
            {
                // Debug 출력
                Debug.WriteLine("State Form --->>> USB Info");

                USB_Info USB_Information = new USB_Info();
                paramVal.insert_device_info = USB_Information.main();
                paramVal.thread_statue = 1;

                return paramVal;
            }
        }

        private void List_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;
            isItemSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
            int itemIndex = e.Index;

            MyListBoxItem item = Device_List.Items[e.Index] as MyListBoxItem;
            if (itemIndex >= 0 && itemIndex < Device_List.Items.Count)
            {
                Graphics g = e.Graphics;

                // Background Color
                SolidBrush backgroundColorBrush = new SolidBrush((isItemSelected) ? Color.Red : Color.Silver);
                g.FillRectangle(backgroundColorBrush, e.Bounds);

                // Set text color
                if (item != null)
                {
                    e.Graphics.DrawString(
                        item.Message,
                        Device_List.Font,
                        new SolidBrush(item.ItemColor),
                        0,
                        e.Index * Device_List.ItemHeight
                    );
                }
                if (isItemSelected)
                {
                    SolidBrush itemTextColorBrush = new SolidBrush(Color.White);
                    g.DrawString(item.Message, e.Font, itemTextColorBrush, Device_List.GetItemRectangle(itemIndex).Location);
                    backgroundColorBrush.Dispose();
                    itemTextColorBrush.Dispose();
                    selected_list = true;
                    index_context = item.Message;
                }
            }
            e.DrawFocusRectangle();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Refreash();
        }
    }

    public class MyListBoxItem
    {
        public MyListBoxItem(Color c, string m)
        {
            ItemColor = c;
            Message = m;
        }
        public Color ItemColor { get; set; }
        public string Message { get; set; }
    }
}
