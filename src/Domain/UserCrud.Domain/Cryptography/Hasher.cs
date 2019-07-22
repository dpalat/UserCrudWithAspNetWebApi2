using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UserCrud.Domain.Cryptography
{
    public class Hasher : IHasher
    {
        public string CalculateHash(string input)
        {
            var InputBuffer = Encoding.Unicode.GetBytes(input);
            byte[] HashedBytes;
            using (var Hasher = new SHA256Managed())
            {
                HashedBytes = Hasher.ComputeHash(InputBuffer);
            }

            return BitConverter.ToString(HashedBytes).Replace("-", string.Empty);
        }
    }
}
