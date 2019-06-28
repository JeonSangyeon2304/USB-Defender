using System.Text;
using System.Security.Cryptography;
using System.Diagnostics;

namespace USBDefender
{
    class Encryption_Module
    {
        public string encryption_module(string account, string passwd)
        {
            //Debug 출력
            Debug.WriteLine("\t\t\t-------------Encryption Module-------------");

            string envryption_value = AES128_Encrypt(MD5_Module(account), passwd);

            return envryption_value;
        }

        private string MD5_Module(string account)               // MD5로 계정을 128비트로 증가
        {
            StringBuilder MD5str = new StringBuilder();
            byte[] byteArr = Encoding.ASCII.GetBytes(account);
            byte[] resultArr = (new MD5CryptoServiceProvider()).ComputeHash(byteArr);

            for (int cnt = 0; cnt < resultArr.Length; cnt++)
                MD5str.Append(resultArr[cnt].ToString("X2"));

            //Debug 출력
            Debug.WriteLine("\t\t\tEncryption Module > MD5_Module /// MD5_account: " + MD5str.ToString());

            return MD5str.ToString();
        }

        private string AES128_Encrypt(string key, string s)     // AES-128로 비밀번호를 암호화
        {
            StringBuilder result = new StringBuilder();

            byte[] KeyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] EncryptArray = UTF8Encoding.UTF8.GetBytes(s);

            RijndaelManaged Rdel = new RijndaelManaged();
            Rdel.Mode = CipherMode.ECB;
            Rdel.Padding = PaddingMode.Zeros;
            Rdel.Key = KeyArray;

            ICryptoTransform CtransForm = Rdel.CreateEncryptor();
            byte[] ResultArray = CtransForm.TransformFinalBlock(EncryptArray, 0, EncryptArray.Length);

            foreach (byte b in ResultArray)
                result.AppendFormat("{0:x2}", b);

            //Debug 출력
            Debug.WriteLine("\t\t\tEncryption Module > AES128_Encrypt /// AES-128 Encrypt: " + result.ToString());
            return result.ToString();
        }
    }
}
