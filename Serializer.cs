using System.Text;
namespace WinFormsApp1
{
    internal static class Serializer
    {
        private static string SaveLocation = "../../../Shadow.png";
        ///<summary>
        ///Call Serializer.SaveToFile() To save all current passwords to file. Also runs whenever the form is closed
        ///</summary>
        public static int SaveToFile(Form1 form)
        {
            List<passwordInfo> passwords = form.Passwords;

            FileStream Save = File.OpenWrite(SaveLocation);
            string bytes = "";

            foreach (passwordInfo password in passwords)
            {
                bytes += Serialize(password);
            }

            Save.Write(Encoding.ASCII.GetBytes(bytes));
            Save.Close();

            return 0;
        }

        /// <summary>
        /// Call Serializer.LoadFromFile() to load passwords from preset file
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>

        public static int LoadFromFile(Form1 form)
        {
            List<passwordInfo> passwords = new();

            string encryptedtext = File.ReadAllText(SaveLocation);

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
        }

        private static string Serialize(passwordInfo password)
        {
            string text = string.Format("{0}\n{1}\n{2}\n\n",password.WebSite,password.Username,password.Password);
            return text;
        }
    }
}
