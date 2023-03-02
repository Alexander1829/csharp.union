using System.Security.Cryptography;
using System.Text;

namespace AppSample.CoreTools.Helpers;

public static class CryptoHelper
{
    /// <summary>
    /// Returns the hash as an array of 32 bytes
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>

    public static byte[] Sha256Hash(string s)
    {
        return Sha256Hash(Encoding.UTF8.GetBytes(s));
    }

    public static byte[] Sha256Hash(byte[] bytes)
    {
        using var crypt = SHA256.Create();
        byte[] hashBytes = crypt.ComputeHash(bytes);
        return hashBytes;
    }
}