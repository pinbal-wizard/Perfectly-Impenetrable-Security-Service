using System.Text;
namespace WinFormsApp1
{
    /// <summary>
    /// Class responsible for Saving and Loading passwords 
    /// </summary>
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
                if (text == "")
                {
                    continue;
                }
                string URL = text.Split("\n")[0], UserName = text.Split("\n")[1], Password = text.Split("\n")[2];
                form.AddEntry(URL, UserName, Password);
            }
            return 0;
        }

        /// <summary>
        /// This Function will serialise a passwordStruct into a string to be saved to disk
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private static string Serialize(PasswordStruct password)
        {
            string text = string.Format("{0}\n{1}\n{2}\n\n\n",password.WebSite,password.Username,password.Password);
            return text;
        }


        /// <summary>
        /// This Function Will deserialse a string into its passwordstruct item
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private static byte[] DeSerialise(PasswordStruct password)
        {
            throw new NotImplementedException();
        }
    }
}
