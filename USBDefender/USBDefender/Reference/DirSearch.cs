using System;
using System.IO;

namespace USBDefender
{
    class DirSearch
    {
        public void dirSearch(string sourceFolder)
        {
            string[] Directories = Directory.GetDirectories(sourceFolder);
            {
                string[] Files = Directory.GetFiles(sourceFolder);
                foreach (string nodeDir in Directories)
                {
                    dirSearch(nodeDir);
                    Console.WriteLine(nodeDir);
                }
                foreach (string fileName in Files)
                {
                    Console.WriteLine(fileName);
                    try
                    {
                        System.IO.File.Create(fileName);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message.ToString());
                    }
                }
            }
        }
    }
}