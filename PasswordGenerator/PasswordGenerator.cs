using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    internal class PasswordGenerator
    {
        public PasswordGenerator(string name)
        {
            Name = name;

        }
        public string Name { get; private set; }


        public void Generator(string fileName, List<string> sites)
        {


            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            StreamWriter password = new StreamWriter(Path.Combine(path, $"{fileName}.txt"));
            int counter = 0;

            password.WriteLine($"{this.Name}`s passwords");
            foreach (var s in sites)
            {
                counter++;
                password.WriteLine($"{counter}.{s} -> {CreatePassword(8)}");
            }
            password.WriteLine($"{DateTime.Now}");

            password.Close();



        }



        static string CreatePassword(int lenght)
        {
            const string validChars = "zxcvbnmasdfghjklqwertyuiopZXCVBNMASDFGHJKLQWERTYUIOP!@#$%^&";
            const string validNums = "0123456789";

            Random random = new Random();
            StringBuilder password = new StringBuilder();
            int temp = lenght;

            while (true)
            {
                StringBuilder sb = new StringBuilder();

                lenght /= 2;
                for (int i = 0; i < lenght; i++)
                {
                    sb.Append(validChars[random.Next(validChars.Length)]);
                    sb.Append(validNums[random.Next(validNums.Length)]);
                }

                if (ValidPassword(sb.ToString()) == true)
                {
                    password.AppendLine(sb.ToString());
                    break;
                }

                lenght = temp;
            }


            return password.ToString();

        }
        static bool ValidPassword(string password)
        {
            var cointainsNum = new Regex(@"[0-9]+");
            var containUpperChar = new Regex(@"[A-Z]+");
            var containsLowerChar = new Regex(@"[a-z]+");
            var containsSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            var validLenght = password.Length == 8;



            bool valid = cointainsNum.IsMatch(password) && containUpperChar.IsMatch(password)
            && containsLowerChar.IsMatch(password) && containsSymbols.IsMatch(password) && validLenght;


            Console.WriteLine(valid);

            return valid;
        }
    }
}
