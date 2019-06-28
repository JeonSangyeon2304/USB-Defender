using System;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace USBDefender
{
    class getRegistry
    {
        [DllImport("kernel32", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        public extern static IntPtr LoadLibrary(string libraryName);
        [DllImport("kernel32", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        public extern static IntPtr GetProcAddress(IntPtr hwnd, string procedureName);
        private delegate bool IsWow64ProcessDelegate([In] IntPtr handle, [Out] out bool isWow64Process);

        public static bool IsOS64Bit()
        {
            if (IntPtr.Size == 8 || (IntPtr.Size == 4 && Is32BitProcessOn64BitProcessor()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static IsWow64ProcessDelegate GetIsWow64ProcessDelegate()
        {
            IntPtr handle = LoadLibrary("kernel32");

            if (handle != IntPtr.Zero)
            {
                IntPtr fnPtr = GetProcAddress(handle, "IsWow64Process");

                if (fnPtr != IntPtr.Zero)
                {
                    return (IsWow64ProcessDelegate)Marshal.GetDelegateForFunctionPointer((IntPtr)fnPtr, typeof(IsWow64ProcessDelegate));
                }
            }
            return null;
        }

        private static bool Is32BitProcessOn64BitProcessor()
        {
            IsWow64ProcessDelegate fnDelegate = GetIsWow64ProcessDelegate();
            if (fnDelegate == null)
            {
                return false;
            }

            bool isWow64;
            bool retVal = fnDelegate.Invoke(System.Diagnostics.Process.GetCurrentProcess().Handle, out isWow64);
            if (retVal == false)
            {
                return false;
            }
            return isWow64;
        }

        private static string Registry_GetValue(RegistryHive mainkey, string regkeypath, string regkeyvalue)
        {
            RegistryKey subkey;
            RegistryKey regkey;
            string reg_value = null;
            if (IsOS64Bit())
            {
                subkey = RegistryKey.OpenBaseKey(mainkey, RegistryView.Registry64);
                regkey = subkey.OpenSubKey(regkeypath, false);
            }
            else
            {
                subkey = RegistryKey.OpenBaseKey(mainkey, RegistryView.Registry32);
                regkey = subkey.OpenSubKey(regkeypath, false);
            }
            if (regkey != null)
                reg_value = regkey.GetValue(regkeyvalue, "").ToString();
            return reg_value;
        }

        private static string[] Registry_GetSubKeyNames(RegistryHive mainkey, string regkeypath)
        {
            RegistryKey subkey;
            RegistryKey regkey;
            string[] subkey_list = null;
            if (IsOS64Bit())
            {
                subkey = RegistryKey.OpenBaseKey(mainkey, RegistryView.Registry64);
                regkey = subkey.OpenSubKey(regkeypath, false);
            }
            else
            {
                subkey = RegistryKey.OpenBaseKey(mainkey, RegistryView.Registry32);
                regkey = subkey.OpenSubKey(regkeypath, false);
            }
            if (regkey != null)
                subkey_list = regkey.GetSubKeyNames();


            return subkey_list;
        }

        public string main(string serial_num)
        {
            string path = @"SOFTWARE\Microsoft\Windows Portable Devices\Devices";
            string instert_usb_reg = null;
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(path);

            string[] regstrykey_name = Registry_GetSubKeyNames(RegistryHive.LocalMachine, path);

            foreach (string list in regstrykey_name)
                if (list.Contains(serial_num))
                    instert_usb_reg = list;

            path += "\\" + instert_usb_reg;
            string friendly_name = Registry_GetValue(RegistryHive.LocalMachine, path, "FriendlyName");
            string name = friendly_name;
            if(friendly_name.Length > 2)
                name = friendly_name.Substring(1);
            string return_value = null;

            if (name.Equals(":\\"))
                return_value = friendly_name.Substring(0,2);
            else
            {
                path = @"SOFTWARE\Microsoft\Windows Search\VolumeInfoCache";
                RegistryKey reg = Registry.LocalMachine.OpenSubKey(path);
                string[] drive_names = Registry_GetSubKeyNames(RegistryHive.LocalMachine, path);
                

                foreach (string list in drive_names)
                {
                    string repath = path + "\\" + list;
                    reg.OpenSubKey(list);
                    string result = Registry_GetValue(RegistryHive.LocalMachine, repath, "VolumeLabel");

                    if (result == friendly_name)
                        return_value = list;
                }
            }
            return return_value;
        }
    }
}
