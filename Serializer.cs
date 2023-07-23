using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WinFormsApp1
{
    internal static class Serializer
    {
        public static int SaveToFile(Form1 form)
        {
            string saveLocation = "../../../Shadow.png";

            List<password> passwords = new();
            passwords.Add(new password("google", "thetruecool", "password123"));
            passwords.Add(new password("yandex", "thetruecool", "password123"));
            passwords.Add(new password("outlook", "thetruecool", "password123"));
            passwords.Add(new password("github", "thetruecool", "password123"));
            passwords.Add(new password("typingclub", "thetruecool", "password123"));

            FileStream Save = File.OpenWrite(saveLocation);
            string bytes = "";

            foreach (password password in passwords)
            {
                bytes += Serialize(password);
            }

            Save.Write(Encoding.ASCII.GetBytes(bytes));
            Save.Close();

            return 1;
        }

        public static int LoadFromFile()
        {
            throw new NotImplementedException();
        }

        private static string Serialize(password password)
        {
            string text = string.Format("{0}\n{1}\n{2}\n\n",password.WebSite,password.Username,password.Password);
            return text;
        }

        private static byte[] DeSerialise(password password)
        {
            throw new NotImplementedException();
        }
    }
}
