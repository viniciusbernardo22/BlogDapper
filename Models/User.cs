

using System.Text;
using Dapper.Contrib.Extensions;

namespace BlogDapper.Models
{
    [Table("[User]")]
    public class User
    {
        public User() => Roles = new List<Role>();
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }

        [Write(false)] 
        public List<Role> Roles { get; set; } 
        public User GenerateRandomUser()
        {
            Random r = new Random();
            string RandomFirstName = GenerateName(r.Next(6, 12));
            string RandomSurName = GenerateName(r.Next(4, 16));

            var user = new User();
            user.Name = $"{RandomFirstName} {RandomSurName}";
            user.Email = $"{RandomFirstName}@gmail.com";
            user.PasswordHash = Convert.ToBase64String(Encoding.UTF8.GetBytes(RandomFirstName));
            user.Bio = $"{RandomFirstName.ToUpper()}";
            user.Image = $"https://plus.unsplash.com/{RandomFirstName}_${RandomSurName}";
            user.Slug = $"{RandomFirstName}-{RandomSurName}";

            return user;
        }

        private static string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = string.Empty;
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2;
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;
            
        }

    }
}