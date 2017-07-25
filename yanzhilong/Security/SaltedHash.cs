using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace yanzhilong.Security
{
    /// <summary>
    /// Thank you Martijn
    /// http://www.dijksterhuis.org/creating-salted-hash-values-in-c/
    /// 
    /// Stronger/Slower Alternative: 
    /// https://github.com/defuse/password-hashing/blob/master/PasswordStorage.cs
    /// </summary>
    public class SaltedHash
    {
        readonly HashAlgorithm HashProvider;
        readonly int SalthLength;

        public SaltedHash(HashAlgorithm HashAlgorithm, int theSaltLength)
        {
            HashProvider = HashAlgorithm;
            SalthLength = theSaltLength;
        }

        public SaltedHash() : this(SHA256.Create(), 4) { }

        private byte[] ComputeHash(byte[] Data, byte[] Salt)
        {
            var DataAndSalt = new byte[Data.Length + SalthLength];
            Array.Copy(Data, DataAndSalt, Data.Length);
            Array.Copy(Salt, 0, DataAndSalt, Data.Length, SalthLength);

            return HashProvider.ComputeHash(DataAndSalt);
        }

        public void GetHashAndSalt(byte[] Data, out byte[] Hash, out byte[] Salt)
        {
            Salt = new byte[SalthLength];

            var random = RandomNumberGenerator.Create();

            random.GetNonZeroBytes(Salt);

            Hash = ComputeHash(Data, Salt);
        }

        public void GetHashAndSaltString(string Data, out string Hash, out string Salt)
        {
            byte[] HashOut;
            byte[] SaltOut;

            GetHashAndSalt(Encoding.UTF8.GetBytes(Data), out HashOut, out SaltOut);

            Hash = Convert.ToBase64String(HashOut);
            Salt = Convert.ToBase64String(SaltOut);
        }

        public bool VerifyHash(byte[] Data, byte[] Hash, byte[] Salt)
        {
            var NewHash = ComputeHash(Data, Salt);

            if (NewHash.Length != Hash.Length) return false;

            for (int Lp = 0; Lp < Hash.Length; Lp++)
                if (!Hash[Lp].Equals(NewHash[Lp]))
                    return false;

            return true;
        }

        public bool VerifyHashString(string Data, string Hash, string Salt)
        {
            if (Hash == null || Salt == null)
                return false;

            byte[] HashToVerify = Convert.FromBase64String(Hash);
            byte[] SaltToVerify = Convert.FromBase64String(Salt);
            byte[] DataToVerify = Encoding.UTF8.GetBytes(Data);
            return VerifyHash(DataToVerify, HashToVerify, SaltToVerify);
        }
    }
}