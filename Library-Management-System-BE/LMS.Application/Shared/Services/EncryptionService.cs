using System.Security.Cryptography;
using System.Text;

namespace LMS.Application;
public class EncryptionService : IEncryptionService
{
    #region Fields & Properties

    private const string ENCRYPT_KEY = "Ya)RH*qy6~7d-v&}mwr24G";
    private const string DECRYPT_KEY = "Ya)RH*qy6~7d-v&}mwr24G";
    private static readonly byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

    #endregion

    #region Functions

    public string EncryptText(string strText)
    {
        return Encrypt(strText, ENCRYPT_KEY);
    }

    public string EncryptText(string strText, string key)
    {
        return Encrypt(strText, key);
    }

    public string DecryptText(string strText)
    {
        return Decrypt(strText, DECRYPT_KEY);
    }

    public string DecryptText(string strText, string key)
    {
        return Decrypt(strText, key);
    }

    private string Encrypt(string strText, string strEncrKey)
    {
        try
        {
            byte[] key = Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 16));
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = IV;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] inputByteArray = Encoding.UTF8.GetBytes(strText);
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    private string Decrypt(string strText, string sDecrKey)
    {
        try
        {
            strText = strText.Replace('-', '+').Replace('_', '/');
            switch (strText.Length % 4)
            {
                case 2: strText += "=="; break;
                case 3: strText += "="; break;
            }

            byte[] key = Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 16));
            byte[] inputByteArray = Convert.FromBase64String(strText);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = IV;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aesAlg.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                        return Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    #endregion
}
