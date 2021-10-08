using System;
using System.IO;

namespace CSharpRestApi.Classes
{
    public static class Utils
    {
        public static string FileToBase64String(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);
            string base64 = Convert.ToBase64String(bytes);
            string base64data = "data:video/mp4;base64," + base64;

            return base64data;
        }

        public static void Base64StringToFile(string path, string base64)
        {
            string base64data = base64.Replace("data:video/mp4;base64,", "");
            byte[] videoBytes = Convert.FromBase64String(base64data);

            File.WriteAllBytes(path, videoBytes);
        }
    }
}
