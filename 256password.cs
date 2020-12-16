private string Gen256password()
        {
            
            RijndaelManaged aesEncryption = new RijndaelManaged();
            aesEncryption.KeySize = 256;
            aesEncryption.BlockSize = 128;
            aesEncryption.Mode = CipherMode.CBC;
            aesEncryption.Padding = PaddingMode.PKCS7;
            aesEncryption.GenerateIV();
            string ivStr = Convert.ToBase64String(aesEncryption.IV);
            aesEncryption.GenerateKey();
            string keyStr = Convert.ToBase64String(aesEncryption.Key);
            //string completeKey = ivStr + "," + keyStr;
            string key = ivStr + keyStr;
            //String key = Convert.ToBase64String(ASCIIEncoding.UTF8.GetBytes(completeKey));
            return key;
        }