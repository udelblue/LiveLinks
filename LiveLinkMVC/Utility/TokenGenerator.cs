using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

using System.Web;

namespace LiveLinkMVC.Utility
{
    public class TokenGenerator
    {

        public string EncryptTime(DateTime time)
        {
          string timeString = time.ToLongTimeString();
         string encryptString =  Crypto.Encrypt(timeString);

         return encryptString;
        }

        public string EncryptTime(TimeSpan timespan)
        {
         DateTime currentTime = DateTime.Now;
         DateTime futureTime = currentTime.Add(timespan);
            string timeString = futureTime.ToLongTimeString();
            string encryptString = Crypto.Encrypt(timeString);

            return encryptString;
        }

        public DateTime DecryptTime(string token) 
        {
            try
            {
                string decryptString = Crypto.Decrypt(token);
                DateTime decryptTime = DateTime.Parse(decryptString);
                return decryptTime;
            }
            catch (Exception)
            {
                throw new Exception("Error Decrypting token");
              
            }
          
        }

        public bool ValidateTime(string token)
        {

            bool value;
            try
            {
                string decryptString = Crypto.Decrypt(token);
                DateTime decryptTime = DateTime.Parse(decryptString);
                if ( decryptTime < DateTime.Now)
                {
                    value = false;
                }
                else
                {
                    value = true;     
                } 
            }
            catch (Exception)
            {

                value = false;
            } 

            return value;
        }


    }
}
