using System.Security.Cryptography;
using System.Text;

namespace Wpf.Services;

public static class Encrypt
{
    public static string GetSHA256(string data)
    {
        var enconding = new ASCIIEncoding();
        var builder = new StringBuilder();
        byte[]? stream = null;

        var sHA = SHA256.Create();

        stream = sHA.ComputeHash(enconding.GetBytes(data));

        for (var i = 0; i < stream.Length; i++)
            builder.AppendFormat("{0:x2}", stream[i]);

        return builder.ToString();
    }
}