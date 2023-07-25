﻿using System.Text;
namespace WinFormsApp1
{
    internal static class Serializer
    {
        private static string SaveLocation = "../../../Shadow.png";
        ///<summary>
        ///Call Serializer.SaveToFile() To save all current PasswordsList to file. Also runs whenever the form is closed
        ///</summary>
        public static int SaveToFile(MainWindow form)
        {
            List<PasswordStruct> PasswordsList = form.PasswordsList;

            FileStream Save = File.OpenWrite(SaveLocation);
            string bytes = "";

            foreach (PasswordStruct password in PasswordsList)
            {
                bytes += Serialize(password);
            }

            Save.Write(Encoding.ASCII.GetBytes(bytes));
            Save.Close();

            return 0;
        }

        /// <summary>
        /// Call Serializer.LoadFromFile() to load PasswordsList from preset file
        /// </summary>
        /// <returns></returns>
        public static int LoadFromFile(MainWindow form)
        {
            List<PasswordStruct> PasswordsList = new();

            string encryptedtext = File.ReadAllText(SaveLocation);

            string[] splitEncryptedText = encryptedtext.Split("\n\n\n");
            foreach (string text in splitEncryptedText)
            {
                MessageBox.Show(text);
                if (text == "")
                {
                    continue;
                }
                string URL = text.Split("\n")[0], UserName = text.Split("\n")[1], Password = text.Split("\n")[2];
                form.AddEntry(URL, UserName, Password);
            }
            return 0;
        }

        private static string Serialize(PasswordStruct password)
        {
            string text = string.Format("{0}\n{1}\n{2}\n\n\n",password.WebSite,password.Username,password.Password);
            MessageBox.Show(text);
            return text;
        }

        private static byte[] DeSerialise(PasswordStruct password)
        {
            throw new NotImplementedException();
        }
    }
}
