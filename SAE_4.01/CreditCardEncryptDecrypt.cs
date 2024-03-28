using System.Text;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace SAE_4._01
{
    //classe pour crypter/décrypter les cartes bancaires car la clé ne doit pas passer côté client pour que les cartes cryptées dans la base soient protégées.
    public class CreditCardEncryptDecrypt
    {
        private byte[] key = Convert.FromBase64String("72hqKV6F/3bBlAJzPVDWJ0CxzIqlVD6066/rk9V84jU="); //La même que celle de "SAE4_01_Laravel_Base".
        private const int bcryptWorkFactor = 15;

        public string Encrypt(string card)
        {
            // Encrypte sample text via the Aes256CbcEncrypter class.
            string encrypted = Aes256CbcEncrypter.Encrypt(card, key);

            return encrypted;
        }

        public string Decrypt(string encryptedCard)
        {
            // Decrypt the sample text via the Aes256CbcEncrypter class.
            string decrypted = Aes256CbcEncrypter.Decrypt(encryptedCard, key);

            return decrypted;
        }
    }

    class Aes256CbcEncrypter
    {
        private static readonly Encoding encoding = Encoding.UTF8;

        public static string Encrypt(string plainText, byte[] key)
        {
            try
            {
                RijndaelManaged aes = new RijndaelManaged();
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;

                aes.Key = key;
                aes.GenerateIV();

                ICryptoTransform AESEncrypt = aes.CreateEncryptor(aes.Key, aes.IV);
                byte[] buffer = encoding.GetBytes(plainText);

                string encryptedText = Convert.ToBase64String(AESEncrypt.TransformFinalBlock(buffer, 0, buffer.Length));

                string mac = "";

                mac = BitConverter.ToString(HmacSHA256(Convert.ToBase64String(aes.IV) + encryptedText, key)).Replace("-", "").ToLower();

                var keyValues = new Dictionary<string, object>
                {
                    { "iv", Convert.ToBase64String(aes.IV) },
                    { "value", encryptedText },
                    { "mac", mac },
                };

                return Convert.ToBase64String(encoding.GetBytes(JsonConvert.SerializeObject(keyValues)));
            }
            catch (Exception e)
            {
                throw new Exception("Error encrypting: " + e.Message);
            }
        }

        public static string Decrypt(string plainText, byte[] key)
        {
            try
            {
                RijndaelManaged aes = new RijndaelManaged();
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;
                aes.Key = key;

                // Base 64 decode
                byte[] base64Decoded = Convert.FromBase64String(plainText);
                string base64DecodedStr = encoding.GetString(base64Decoded);

                // JSON Decode base64Str
                var payload = JsonConvert.DeserializeObject<Dictionary<string, string>>(base64DecodedStr);

                aes.IV = Convert.FromBase64String(payload["iv"]);

                ICryptoTransform AESDecrypt = aes.CreateDecryptor(aes.Key, aes.IV);
                byte[] buffer = Convert.FromBase64String(payload["value"]);

                return encoding.GetString(AESDecrypt.TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch (Exception e)
            {
                throw new Exception("Error decrypting: " + e.Message);
            }
        }

        static byte[] HmacSHA256(string data, byte[] key)
        {
            using (HMACSHA256 hmac = new HMACSHA256(key))
            {
                return hmac.ComputeHash(encoding.GetBytes(data));
            }
        }
    }
}
