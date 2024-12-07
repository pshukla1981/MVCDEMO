using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace MVCDEMO.Repository
{
    public class Cryptograpy
    {
        public static string EncryptString(string inputString, byte[] key, byte[] iv)
        {
            byte[] encryptedData;

            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = key;
                des.IV = iv;

                ICryptoTransform encryptor = des.CreateEncryptor();

                byte[] inputBytes = Encoding.UTF8.GetBytes(inputString);
                encryptedData = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
            }

            return Convert.ToBase64String(encryptedData);
        }
        public static string DecryptString(string inputString, byte[] key, byte[] iv)
        {
            byte[] decryptedData;

            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = key;
                des.IV = iv;

                ICryptoTransform decryptor = des.CreateDecryptor();

                byte[] inputBytes = Convert.FromBase64String(inputString);
                decryptedData = decryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
            }

            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}