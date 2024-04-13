using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CarteiraDoInvestidor.CrossCuting.Utils
{
    public static class SecurityUtils
    {
            public static String HashSHA256(this string plainText)
            {
                SHA256 criptoProvider = SHA256.Create();

                byte[] btexto = Encoding.UTF8.GetBytes(plainText);

                var criptoResult = criptoProvider.ComputeHash(btexto);

                return Convert.ToHexString(criptoResult);
            }

    }
}
