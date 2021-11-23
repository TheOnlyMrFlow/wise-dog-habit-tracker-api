using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace TWD.HabitTracker.Domain.ValueObjects.Password
{
    public class Password : IEquatable<Password>
    {
        public Password(string? clear)
        {
            if (string.IsNullOrWhiteSpace(clear))
                throw new PasswordException();
            
            Clear = clear;
            Hashed = HashPassword(clear);

            if (!PasswordIsCompliant(clear))
                throw new PasswordException();
        }

        public string Clear { get; }
        public string Hashed { get; }

        public bool Equals(Password? other) => Clear == other?.Clear;

        public override bool Equals(object? obj) => obj is Password o && Equals(o);

        public override int GetHashCode() => HashCode.Combine(Clear);

        public static bool operator ==(Password? left, Password? right) => left is not null && left.Equals(right);

        public static bool operator !=(Password left, Password right) => !(left == right);

        public override string ToString() => Clear;


        /// <summary>
        ///     Check if password contains at least 1 Uppercase, 1 Lowercase, 1 Digit, 1 SpecialChar and length >= 10
        /// </summary>
        /// <param name="password"></param>
        /// <returns>true if password is compliant</returns>
        private static bool PasswordIsCompliant(string password)
        {
            return password.Length >= 10 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) &&
                   password.Any(c => ! char.IsLetterOrDigit(c));
        }

        private static string GenerateHash(string password, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                salt,
                KeyDerivationPrf.HMACSHA1,
                100000,
                256 / 8)
            );
        }

        private static bool ValidateHash(string password, string hash)
        {
            if (!hash.Contains("|"))
                throw new ArgumentException("Bad hash, not containing |");
            var b64Salt = hash.Split('|')[0];

            var salt = Convert.FromBase64String(b64Salt);

            var hashed = GenerateHash(password, salt);
            return $"{b64Salt}|{hashed}" == hash;
        }

        public static string HashPassword(string password)
        {
            var salt = new byte[128 / 8];

            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);

            var hashed = GenerateHash(password, salt);
            var b64Salt = Convert.ToBase64String(salt);

            return $"{b64Salt}|{hashed}";
        }

        public static void EnsureHashMatch(string password, string hash)
        {
            if (!ValidateHash(password, hash))
                throw new PasswordException("Password is not recognized");
        }
    }
}