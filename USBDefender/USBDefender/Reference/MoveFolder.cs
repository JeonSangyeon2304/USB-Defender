using System.IO;
using System.Windows.Forms;

namespace USBDefender
{
    class MoveFolder
    {
        public bool moveFolder(string sourceFolder, string destFolder)
        {
            bool isFolder = true;
            string[] files = null;


            //만약 선택된 것이 폴더가 아니라면 문제가 발생
            try
            {
                files = Directory.GetFiles(sourceFolder);
            }
            catch
            {
                isFolder = false;
            }

            if (isFolder)
            {
                if (!Directory.Exists(destFolder))
                    Directory.CreateDirectory(destFolder);

                string[] folders = Directory.GetDirectories(sourceFolder);
                foreach (string file in files)
                {
                    string name = Path.GetFileName(file);
                    string dest = Path.Combine(destFolder, name);
                    // 이미 존재하면 오류 발생
                    try
                    {
                        File.Move(file, dest);
                    }
                    catch
                    {
                        MessageBox.Show("이미 파일이 존재합니다.");
                        break;
                    }
                }
                foreach (string folder in folders)
                {
                    string name = Path.GetFileName(folder);
                    string dest = Path.Combine(destFolder, name);

                    moveFolder(folder, dest);
                    Directory.Delete(folder);
                }

                return isFolder;
            }
            else
                return isFolder;
        }
    }
}
