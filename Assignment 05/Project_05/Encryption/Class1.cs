using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Encryption
{
    public class Encrypt_Decrypt 
    {
        //Use a 32 byte string to act as the encoder for the encrypting and decrypting
        private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("z9olw723j4gitl4r");
        // This is used to set the size of the encrypt/decrypt key of 256 bits
        private const int theKey = 256;

        //This block is used to convert the passed plaintext string to to the new encrpyted string
        public static string Encrypt(string plainText)
        {
            //Use UTF8 to incode the passed strinf to max 4 byte charcters
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            using (PasswordDeriveBytes password = new PasswordDeriveBytes("1234", null))
            {
                //Use GetBytes to calculate the 32 bytes needed
                byte[] keyBytes = password.GetBytes(theKey / 8);

                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {   
                    //Use CipherMode as the block cipher
                    symmetricKey.Mode = CipherMode.CBC;

                    //Make an ecrypter from keyBytes and the initVectorBytes
                    using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                byte[] cipherTextBytes = memoryStream.ToArray();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        //This block is used to convert the passed encrpyted string to to the original plaintext string
        public static string Decrypt(string cipherText)
        {
            //Create a byte array from the passed ciphertext
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            using(PasswordDeriveBytes password = new PasswordDeriveBytes("1234", null))
            {
                //Use GetBytes to calculate the 32 bytes needed
                byte[] keyBytes = password.GetBytes(theKey / 8);

                using(RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    //Use CipherMode as the block cipher
                    symmetricKey.Mode = CipherMode.CBC;

                    //Make an ecrypter from keyBytes and the initVectorBytes
                    using(ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
                    {
                        using(MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using(CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {   
                                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                //Use UTF8 to incode the passed strinf to max 4 byte charcters
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }
    }


    }




