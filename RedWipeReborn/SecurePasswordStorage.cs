using RedWipeReborn.Properties;
using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace RedWipeReborn
{
	internal static class SecurePasswordStorage
	{
		private const string SPS_Identifier = "RedWipeReborn";
        
        public static void SaveCredentials(string username, string password)
        {
            Settings.Default.RedditUsername = SecurePasswordStorage.EncryptForUser(username);
            Settings.Default.RedditPassword = SecurePasswordStorage.EncryptForUser(password);
            Settings.Default.Save();
        }
        public static string GetPassword()
        {
            return SecurePasswordStorage.DecryptForUser(Settings.Default.RedditPassword, "");
        }

        public static string GetUsername()
        {
            return SecurePasswordStorage.DecryptForUser(Settings.Default.RedditUsername, "");
        }

        private static string DecryptForUser(string data, string defaultOnFailure = "")
		{
            if (string.IsNullOrEmpty(data))
                return defaultOnFailure;

			try
			{
				byte[] encryptedBytes = Convert.FromBase64String(data);
				byte[] decryptedBytes = ProtectedData.Unprotect(encryptedBytes, Encoding.ASCII.GetBytes("RedWipeReborn"), DataProtectionScope.CurrentUser);
				return Encoding.Unicode.GetString(decryptedBytes);
			}
			catch
			{
				return defaultOnFailure;
			}
		}

		private static string EncryptForUser(string data)
		{
			return Convert.ToBase64String(
                ProtectedData.Protect(
                    Encoding.Unicode.GetBytes(data),
                    Encoding.ASCII.GetBytes("RedWipeReborn"),
                    DataProtectionScope.CurrentUser));
		}
	}
}