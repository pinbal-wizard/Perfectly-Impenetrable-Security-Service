using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

            List<passwordInfo> passwords = form.Passwords;

            FileStream Save = File.OpenWrite(saveLocation);
            string bytes = "";

            foreach (passwordInfo password in passwords)
            {
                bytes += Serialize(password);
            }

            Save.Write(Encoding.ASCII.GetBytes(bytes));
            Save.Close();

            return 0;
        }

        public static int LoadFromFile(Form1 form)
        {
            string saveLocation = "../../../Shadow.png";

            List<passwordInfo> passwords = new();

            string encryptedtext = File.ReadAllText(saveLocation);

            string[] splitEncryptedText = encryptedtext.Split("\n\n");
            foreach (string text in splitEncryptedText)
            {
                if (text == "")
                {
                    continue;
                }
                MessageBox.Show(text);
                string URL = text.Split("\n")[0], UserName = text.Split("\n")[1], Password = text.Split("\n")[2];
                form.addEntry(URL, UserName, Password);
            }
            return 0;
            //throw new NotImplementedException();
        }

        private static string Serialize(passwordInfo password)
        {
            string text = string.Format("{0}\n{1}\n{2}\n\n",password.WebSite,password.Username,password.Password);
            return text;
        }

        private static passwordInfo DeSerialise()
        {
            throw new NotImplementedException();
        }
    }
}
