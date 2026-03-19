namespace LMS.Application;

public interface IEncryptionService
{
    string EncryptText(string strText);
    string EncryptText(string strText, string key);
    string DecryptText(string strText);
    string DecryptText(string strText, string key);
}