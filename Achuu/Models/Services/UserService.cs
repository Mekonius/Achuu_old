using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Achuu.Models.Services
{
    public class UserService
    {
        private readonly IDbContextFactory<AchuuContext> _contextFactory;

        public UserService(IDbContextFactory<AchuuContext> context)
        {
            _contextFactory = context;
        }

        public async Task<User?> LoginAsync(string email, string password)
        {

            using var context = _contextFactory.CreateDbContext();
            var user = context.Users != null ? await context.Users.FirstOrDefaultAsync(u => u.Email == email) : null;

            if (user is null)
            {
                throw new Exception("User not found");
            }

            // hash the provided password and compare it to the stored hash
            string hashedPassword = string.Empty;
            if (user.Salt != null)
            {
                hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password,
                    salt: Convert.FromBase64String(user.Salt),
                    prf: KeyDerivationPrf.HMACSHA512,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8));
            }

            if (user.Hash != hashedPassword)
            {
                throw new Exception("Incorrect password");
            }

            return user;
        }

        public async Task CreateUserAsync(User user, string password)
        {
            using var context = _contextFactory.CreateDbContext();
            using var transaction = context.Database.BeginTransaction();

            var existingUser = context.Users != null
                ? await context.Users.FirstOrDefaultAsync(u => (u.Email != null && u.Email.ToLower() == (user.Email ?? "").ToLower()) || (u.Name != null && u.Name.ToLower() == (user.Name ?? "").ToLower()))
                : null;
            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }

            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            // Set the hashed password and salt to the user object
            user.Hash = hashed;
            user.Salt = Convert.ToBase64String(salt);

            if (context.Users != null)
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }

            await transaction.CommitAsync();
        }


        //Edit User
        public async Task EditUserAsync(User user)
        {
            using var context = _contextFactory.CreateDbContext();
            if (context.Users != null)
            {
                context.Users.Update(user);
                await context.SaveChangesAsync();
            }
        }





    }
}
