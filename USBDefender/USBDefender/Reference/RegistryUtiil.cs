using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace USBDefender
{
    class RegistryUtiil
    {
        private const string REGISTRY_RUN_LOCATION = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        public static String getAssemblyPath()
        {
            return Application.StartupPath;
        }

        public static void SetAutoStart(string keyName, string assemblyLocation)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(REGISTRY_RUN_LOCATION);
            key.SetValue(keyName, assemblyLocation);
        }
        public static bool IsAutoStartEnabled(string keyName, string assemblyLocation)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(REGISTRY_RUN_LOCATION);
            if (key == null)
                return false;
            string value = (string)key.GetValue(keyName);
            if (value == null)
                return false;
            return (value == assemblyLocation);
        }
        public static void UnSetAutoStart(string keyName)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(REGISTRY_RUN_LOCATION);
            key.DeleteValue(keyName);
        }

    }
}
