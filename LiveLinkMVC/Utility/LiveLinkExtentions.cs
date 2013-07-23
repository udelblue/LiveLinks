using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LiveLinkMVC.Models;

namespace LiveLinkMVC.Utility
{
    public static class LiveLinkExtentions
    {
        public static string URLEncrypt(this LiveLink livelink)
        {

           string EncryptURL = Crypto.Encrypt(livelink.ID.ToString());
           return EncryptURL;
        }

        public static string URLDecrypt (this LiveLink livelink,string EncryptedURL)
        {

            string EncryptURL = Crypto.Decrypt(EncryptedURL);
            return EncryptURL;
        }

    }
}