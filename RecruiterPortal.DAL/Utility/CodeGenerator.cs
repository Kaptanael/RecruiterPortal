using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace RecruiterPortal.DAL.Utility
{
    public class CodeGenerator
    {
        public static string AutoGenerate(int natID)
        {
            UnicodeEncoding utf16 = new UnicodeEncoding();
            Guid guid = Guid.NewGuid();
            Random random = new Random(unchecked((int)DateTime.Now.Ticks + 15));

            byte[] saltValue = new byte[4];

            random.NextBytes(saltValue);

            string unHashedCode = guid.ToString() + utf16.GetString(saltValue);

            MD5 hash = MD5.Create();
            byte[] hashValue = hash.ComputeHash(Encoding.UTF8.GetBytes(unHashedCode));

            StringBuilder sBuilder = new StringBuilder();


            foreach (byte hexdigit in saltValue)
            {
                sBuilder.Append(hexdigit.ToString("x2", CultureInfo.InvariantCulture.NumberFormat));
            }

            return sBuilder.ToString();
        }

        public static string GenerateTemporaryPassword()
        {
            UnicodeEncoding utf16 = new UnicodeEncoding();
            Guid guid = Guid.NewGuid();
            Random random = new Random(unchecked((int)DateTime.Now.Ticks));

            byte[] saltValue = new byte[4];

            random.NextBytes(saltValue);

            string unHashedCode = guid.ToString() + utf16.GetString(saltValue);

            MD5 hash = MD5.Create();
            byte[] hashValue = hash.ComputeHash(Encoding.UTF8.GetBytes(unHashedCode));

            StringBuilder sBuilder = new StringBuilder();


            foreach (byte hexdigit in saltValue)
            {
                sBuilder.Append(hexdigit.ToString("x2", CultureInfo.InvariantCulture.NumberFormat));
            }

            return sBuilder.ToString().ToUpper();
        }
    }
}
