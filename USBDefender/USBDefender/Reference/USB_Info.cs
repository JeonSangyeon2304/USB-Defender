using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Diagnostics;

namespace USBDefender
{
    class USB_Info
    {
        class USBDeviceInfo
        {
            public USBDeviceInfo(string pnpDeviceID, string description)
            {
                this.PnpDeviceID = pnpDeviceID;
                this.Description = description;
            }
            public string PnpDeviceID { get; private set; }
            public string Description { get; private set; }
        }

        static List<USBDeviceInfo> GetUSBDevices()
        {
            List<USBDeviceInfo> devices = new List<USBDeviceInfo>();

            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
                collection = searcher.Get();

            foreach (var device in collection)
            {
                devices.Add(new USBDeviceInfo(
                (string)device.GetPropertyValue("PNPDeviceID"),
                (string)device.GetPropertyValue("Description")
                ));
            }

            collection.Dispose();
            return devices;
        }

        public string[] main()
        {
            //Debug 출력
            Debug.WriteLine("\t\t\t-------------USB Info-------------");

            getRegistry getRegistry = new getRegistry();

            // usb_info_list[0] = 드라이브 문자
            // usb_info_list[1] = VID & PID
            // usb_info_list[2] = Serial Num
            var usbDevices = GetUSBDevices();
            string[] pnpinfo_row = new string[usbDevices.Count()];
            char sp = '\\';
            int pnpinfo_cont = 0;

            // 인식된 장치중 Description이 USB 대용량 저장 장치인 것만 저장
            for (int i = 0; i < usbDevices.Count(); i++)
            {
                if (usbDevices[i].Description.Equals("USB 대용량 저장 장치"))
                    if (!string.IsNullOrEmpty(usbDevices[i].PnpDeviceID))
                    {
                        pnpinfo_row[i] = usbDevices[i].PnpDeviceID;
                        pnpinfo_cont++;
                    }
            }
            string[] pnpinfo = new string[pnpinfo_cont];
            for (int i = 0; i < pnpinfo.Count(); i++)
            {
                for (int j = 0; j < pnpinfo_row.Count(); j++)
                {
                    if (!string.IsNullOrEmpty(pnpinfo_row[j]))
                    {
                        pnpinfo[i] = pnpinfo_row[j];
                        i++;
                    }
                }

            }
            string[,] usb_info_list_row = new string[pnpinfo_cont, 3];
            string[] usb_info_list = new string[pnpinfo_cont];
            for (int i = 0; i < pnpinfo_cont; i++)
            {
                string[] temp = pnpinfo[i].Split(sp);
                for (int j = 0; j < 3; j++)
                    usb_info_list_row[i, j] = temp[j];
            }

            // 해당 장치의 Driver letter 찾아서 저장
            for (int i = 0; i < pnpinfo_cont; i++)
            {
                usb_info_list_row[i, 0] = getRegistry.main(usb_info_list_row[i, 2]);
            }

            // 리스트 정형화
            for (int i = 0; i < pnpinfo_cont; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    usb_info_list[i] += usb_info_list_row[i, j] + "/";
                }
                usb_info_list[i] = usb_info_list[i].Substring(0, (usb_info_list[i].Length - 2));
            }

            if (usb_info_list.Length == 0)
            {
                string[] empty = new string[1];
                empty[0] = "empty";
                return empty;
            }


            //Debug 출력
            Debug.Write("\t\t\tUSB Info /// Info: ");
            foreach (string list in usb_info_list)
                Debug.Write(list);

            return usb_info_list;
        }
    }
}
