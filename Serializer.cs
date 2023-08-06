using System.Text;
using System.Security.Cryptography;
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
                bytes += Encrypt(Serialize(password), form.hash);
                bytes += "\n";
            }

            Save.Write(Encoding.UTF8.GetBytes(bytes));
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

            string[] splitEncryptedText = encryptedtext.Split("\n");
            for(int i  = 1; i < splitEncryptedText.Length; i++)
            {
                if (splitEncryptedText[i] == "")
                {
                    continue;
                }
                string decryptedText;
                decryptedText = Decrypt(splitEncryptedText[i], form.hash);
                string[] splitText = decryptedText.Split(",");
                string website = Base64Decode(splitText[0]);
                string username = Base64Decode(splitText[1]);
                string password = Base64Decode(splitText[2]);
                form.AddEntry(website, username, password);
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
            string text = string.Format("{0},{1},{2}",Base64Encode(password.WebSite), Base64Encode(password.Username), Base64Encode(password.Password), "\n");
            return text;
        }

        private static string Base64Encode(string input)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(input));
        }

        private static string Base64Decode(string input)
        {
            return Encoding.ASCII.GetString(Convert.FromBase64String(input));
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

        /// <summary>
        /// Encrypts a peice of plaintext, should be called after properly formating with Serializer
        /// </summary>
        /// <param name="content"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private static string Encrypt(string content,byte[] password)
        {
            //password is already hashed
            byte[] bytes = Encoding.UTF8.GetBytes(content);

            using (SymmetricAlgorithm crypt = Aes.Create())
            using (HashAlgorithm hash = MD5.Create())
            using (MemoryStream memoryStream = new MemoryStream())
            {
                crypt.Key = password;
                crypt.GenerateIV();

                using (CryptoStream cryptoStream = new CryptoStream(
                    memoryStream, crypt.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(bytes, 0, bytes.Length);
                }

                string base64IV = Convert.ToBase64String(crypt.IV);
                string base64Ciphertext = Convert.ToBase64String(memoryStream.ToArray());

                return base64IV + "!" + base64Ciphertext;
            }
        }

        /// <summary>
        /// Dencrypts a peice of encrypted text
        /// </summary>
        /// <param name="content"></param>
        /// <param name=" cryptText"></param>
        /// <returns></returns>
        public static string Decrypt(string cryptText,byte[] password)
        {
            //password is already hashed
            string content = String.Empty;

            string[] splitCryptText = cryptText.Split("!");
            string base64CipherText = splitCryptText[1];
            string base64InitializationVector = splitCryptText[0];

            byte[] CipherText = Convert.FromBase64String(base64CipherText);
            byte[] InitializationVector = Convert.FromBase64String(base64InitializationVector);

            using (SymmetricAlgorithm crypt = Aes.Create())
            using (HashAlgorithm hash = MD5.Create())
            using (MemoryStream memoryStream = new MemoryStream(CipherText)) {

                crypt.Key = password;
                crypt.IV = InitializationVector;
                // Seed and construct the transformation used for decrypting

                try
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, crypt.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            content = streamReader.ReadToEnd();
                        }
                    }
                }

                catch (CryptographicException ex)
                {
                    MessageBox.Show("An error occurred during decryption:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }




            }
            return content;
        }
    }
}
