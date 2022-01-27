using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    public class PasswordGenerator
    {
        public PasswordGenerator(string name, int countOfSymbols)
        {
            this.Name = name;
            this.CountOfSymbols = countOfSymbols;

        }
        public string Name { get; private set; }
        public int CountOfSymbols { get; set; }


        public void Generator(string fileName, List<string> sites)
        {


            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            StreamWriter password = new StreamWriter(Path.Combine(path, $"{fileName}.txt"));
            int counter = 0;

            password.WriteLine($"{this.Name}`s passwords");
            foreach (var s in sites)
            {
                counter++;
                password.WriteLine($"{counter}.{s} -> {CreatePassword(CountOfSymbols)}");

            }
            password.WriteLine($"{DateTime.Now}");

            password.Close();



        }



        private string CreatePassword(int length)
        {
            List<char> chars = new List<char>();

            for (int i = 33; i <= 125; i++)
            {

                chars.Add((char)i);
            }

            Random random = new Random();
            StringBuilder password = new StringBuilder();

            while (true)
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < length; i++)
                {
                    sb.Append(chars[random.Next(chars.Count)]);
                    if (ValidPassword(sb.ToString(), length))
                    {
                        break;
                    }
                }

                if (ValidPassword(sb.ToString(), length) == true)
                {

                    password.Append(sb.ToString());
                    break;
                }

            }


            return password.ToString();

        }
        static bool ValidPassword(string password, int lenght)
        {
            var cointainsNum = new Regex(@"[0-9]+");
            var containUpperChar = new Regex(@"[A-Z]+");
            var containsLowerChar = new Regex(@"[a-z]+");
            var containsSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            var validLenght = password.Length == lenght;



            bool valid = cointainsNum.IsMatch(password) && containUpperChar.IsMatch(password)
            && containsLowerChar.IsMatch(password) && containsSymbols.IsMatch(password) && validLenght;

            return valid;
        }
    }
}
