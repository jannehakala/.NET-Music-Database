using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace MusicDatabase {

    public partial class BLLogin {
        private string username;
        private string password;

        private const int IterationIndex = 0;
        private const int SaltIndex = 1;
        private const int Pbkdf2Index = 2;

        public BLLogin(string username, string password) {
            this.username = username;
            this.password = password;
        }

        public static bool ValidatePassword(string password, string correctHash) {
            char[] delimiter = { ':' };
            var split = correctHash.Split(delimiter);
            var iterations = Int32.Parse(split[IterationIndex]);
            var salt = Convert.FromBase64String(split[SaltIndex]);
            var hash = Convert.FromBase64String(split[Pbkdf2Index]);

            var testHash = GetPbkdf2Bytes(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        private static bool SlowEquals(byte[] a, byte[] b) {
            var diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++) {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }

        private static byte[] GetPbkdf2Bytes(string password, byte[] salt, int iterations, int outputBytes) {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }

        public bool LoginUser(out string messageToUser) {
            try {
                string message = "";

                if (DBMusicDatabase.LoginUser(username, password, out message)) {
                    messageToUser = message;
                    return true;
                }
                messageToUser = message;
                return false;

            } catch (Exception ex) {
                throw ex;
            }
        }

        public bool CheckIfAdmin() {
            try {
                if (DBMusicDatabase.CheckIfAdmin(username)) {
                    return true;
                }
                return false;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
