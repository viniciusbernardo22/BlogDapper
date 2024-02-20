using Dapper.Contrib.Extensions;

namespace BlogDapper.Models
{
    [Table("[Role]")]
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public Role GenerateRandomRole()
        {
            Random r = new Random();
            string RandomFirstName = GenerateRole(r.Next(6, 12));
            string RandomSurName = GenerateRole(r.Next(4, 16));

            var role = new Role();
            role.Name = $"{RandomFirstName}@{RandomSurName}";
            role.Slug = $"{RandomFirstName}!{RandomSurName}";
            
            return role;
        }

        private static string GenerateRole(int len)
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