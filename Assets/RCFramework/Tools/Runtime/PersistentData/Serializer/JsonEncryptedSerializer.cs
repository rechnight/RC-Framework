// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace RCFramework.Tools
{
    public class JsonEncryptedSerializer : ISerializer
    {
        private readonly string _key;
        private const string _saltText = "customSaltText";
        private const string _keyPrefName = "encryptionKey";

        public JsonEncryptedSerializer(string keyString = null)
        {
            _key = !string.IsNullOrEmpty(keyString) ? keyString : LoadOrGeneratePersistentKey();
        }

        public string Serialize<T>(T obj)
        {
            using var ms = new MemoryStream();
            using (var writer = new StreamWriter(ms))
            {
                writer.Write(JsonUtility.ToJson(obj));
                writer.Flush();
                ms.Position = 0;

                using var encryptedStream = new MemoryStream();
                Encrypt(ms, encryptedStream, _key);
                return Convert.ToBase64String(encryptedStream.ToArray());
            }
        }

        public T Deserialize<T>(string data)
        {
            byte[] bytes = Convert.FromBase64String(data);
            using var input = new MemoryStream(bytes);
            using var decrypted = new MemoryStream();
            Decrypt(input, decrypted, _key);
            decrypted.Position = 0;

            using var reader = new StreamReader(decrypted);
            return JsonUtility.FromJson<T>(reader.ReadToEnd());
        }

        private void Encrypt(Stream inputStream, Stream outputStream, string sKey)
        {
            using var algorithm = new RijndaelManaged { KeySize = 256, Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 };
            var key = new Rfc2898DeriveBytes(sKey, Encoding.ASCII.GetBytes(_saltText), 10000);
            algorithm.Key = key.GetBytes(algorithm.KeySize / 8);
            algorithm.GenerateIV();

            outputStream.Write(algorithm.IV, 0, algorithm.IV.Length);

            using var cryptoStream = new CryptoStream(outputStream, algorithm.CreateEncryptor(), CryptoStreamMode.Write);
            inputStream.CopyTo(cryptoStream);
        }

        private void Decrypt(Stream inputStream, Stream outputStream, string sKey)
        {
            using var algorithm = new RijndaelManaged { KeySize = 256, Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 };
            var key = new Rfc2898DeriveBytes(sKey, Encoding.ASCII.GetBytes(_saltText), 10000);
            algorithm.Key = key.GetBytes(algorithm.KeySize / 8);

            byte[] iv = new byte[algorithm.BlockSize / 8];
            inputStream.Read(iv, 0, iv.Length);
            algorithm.IV = iv;

            using var cryptoStream = new CryptoStream(inputStream, algorithm.CreateDecryptor(), CryptoStreamMode.Read);
            cryptoStream.CopyTo(outputStream);
        }

        private string LoadOrGeneratePersistentKey()
        {
            if (PlayerPrefs.HasKey(_keyPrefName))
                return PlayerPrefs.GetString(_keyPrefName);

            string newKey = Guid.NewGuid().ToString();
            PlayerPrefs.SetString(_keyPrefName, newKey);
            PlayerPrefs.Save();
            return newKey;
        }
    }
}