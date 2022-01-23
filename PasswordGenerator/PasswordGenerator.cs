using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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



        private string CreatePassword(int lenght)
        {
            const string validChars = "zxcvbnmasdfghjklqwertyuiopZXCVBNMASDFGHJKLQWERTYUIOP!@#$%^&";
            const string validNums = "0123456789";

            Random random = new Random();
            StringBuilder sb = new StringBuilder();

            lenght /= 2;
            for (int i = 0; i < lenght; i++)
            {
                sb.Append(validChars[random.Next(validChars.Length)]);
                sb.Append(validNums[random.Next(validNums.Length)]);
            }


            return sb.ToString();
        }
    }
}
