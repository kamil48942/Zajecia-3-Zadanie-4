using System;
using System.IO;
using System.Security.Cryptography;

class RSACryptoExample
{
    static void Main()
    {
        try
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                string publicKey = rsa.ToXmlString(false);
                string privateKey = rsa.ToXmlString(true);

                File.WriteAllText("publicKey.xml", publicKey);
                File.WriteAllText("privateKey.xml", privateKey);

                byte[] fileBytes = File.ReadAllBytes("plikdozadania.txt");

                byte[] encryptedBytes = rsa.Encrypt(fileBytes, false);

                File.WriteAllBytes("zaszyfrowany_plik.dat", encryptedBytes);

                byte[] decryptedBytes = rsa.Decrypt(encryptedBytes, false);

                File.WriteAllBytes("deszyfrowany_plik.txt", decryptedBytes);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Wystąpił wyjątek: " + e.Message);
        }
    }
}
