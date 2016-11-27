using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace MusicDatabase {

    public partial class BLRegister {
        private string username;
        private string password;

        private const int SaltByteSize = 24;
        private const int HashByteSize = 20;
        private const int Pbkdf2Iterations = 1000;

        public BLRegister(string username, string password) {
            this.username = username;
            this.password = HashPassword(password);
        }

        public bool RegisterUser(out string messageToUser) {
            try {
                string message = "";

                if (DBMusicDatabase.RegisterUser(username, password, out message)) {
                    messageToUser = message;
                    return true;
                }
                messageToUser = message;
                return false;

            } catch (Exception ex) {
                throw ex;
            }
        }        

        public static string HashPassword(string password) {
            var cryptoProvider = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SaltByteSize];
            cryptoProvider.GetBytes(salt);

            var hash = GetPbkdf2Bytes(password, salt, Pbkdf2Iterations, HashByteSize);
            return Pbkdf2Iterations + ":" +
                   Convert.ToBase64String(salt) + ":" +
                   Convert.ToBase64String(hash);
        }

        private static byte[] GetPbkdf2Bytes(string password, byte[] salt, int iterations, int outputBytes) {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }
    }
}
