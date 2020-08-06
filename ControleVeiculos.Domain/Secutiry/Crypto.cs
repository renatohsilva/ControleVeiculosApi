using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ControleVeiculos.Domain.Secutiry
{
    public static class Crypto
    {
        public static string Encrypt(this string input)
        {
            try
            {
                byte[] dataArray = Encoding.ASCII.GetBytes(input);
                HashAlgorithm sha = new SHA1CryptoServiceProvider();
                return Encoding.ASCII.GetString(sha.ComputeHash(dataArray));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
