using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Text.Json.Nodes;
using System.Xml;

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
            List<String> bytes = new();

            foreach (PasswordStruct password in PasswordsList)
            {
                bytes.Add(Serialize(password));
            }
            Save.Write(Encoding.ASCII.GetBytes(String.Join(",", bytes)));
            Save.Close();

            return 0;
        }

        /// <summary>
        /// Call Serializer.LoadFromFile() to load PasswordsList from preset file
        /// </summary>
        /// <returns></returns>
        public static int LoadFromFile(MainWindow form)
        {
            return -1;

            List<PasswordStruct> PasswordsList = new();

            string encryptedtext = File.ReadAllText(SaveLocation);

            string[] splitEncryptedText = encryptedtext.Split("\n\n\n");
            foreach (string text in splitEncryptedText)
            {
                //MessageBox.Show(text);  //debug line
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
        /// <br></br>***Need to add Encrypt/Decrpt functions
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private static string Serialize(PasswordStruct password)
        {
            if (password.Password == ""|| password.WebSite == "" || password.Username == "")
            {
                return "";
            }

            List<String> array = new();
            array.Add("{" + password.WebSite + "}");
            array.Add("{" + password.Username + "}");
            array.Add("{" + password.Password + "}");
            string text = String.Concat(String.Concat( "{" ,String.Join(",",array)),"}"); //God awful line plz fix
            return text;
        }


        /// <summary>
        /// This Function Will deserialse a string into its passwordstruct item
        /// <br></br>***Need to add Encrypt/Decrpt functions
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private static byte[] DeSerialise(PasswordStruct password)
        {
            throw new NotImplementedException();
        }


        public static string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
