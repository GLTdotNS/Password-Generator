using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    internal class Engine
    {

        public Engine()
        {

        }
        internal void StartProgram()
        {
            MainMenu();
            Console.ReadKey();
            while (true)
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Въведете своето име");
                Console.ResetColor();
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.Beep();
                    Console.Clear();
                    MainMenu();
                    continue;
                }
                ConsoleLines();
                var pg = new PasswordGenerator(input);


                Console.WriteLine("(За изход от режим въвеждане: end)");
                Console.WriteLine("Въведете сайтове , които желаете:");
                Console.ResetColor();
                string site = Console.ReadLine();
                List<string> listOfSites = new List<string>();

                while (site != "--end")
                {
                    if (string.IsNullOrEmpty(site))
                    {
                        Console.Beep();
                        continue;
                    }
                    listOfSites.Add(site);

                    site = Console.ReadLine();
                }



                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Сайтовете , които въведохте са:");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                int counter = 1;
                foreach (var s in listOfSites)
                {
                    Console.WriteLine($"{counter++}. {s}");
                }

                ConsoleLines();




                Console.WriteLine("Как искате да наименувате файла ?");
                Console.WriteLine("Пример: myPasswords");
                Console.ResetColor();
                input = Console.ReadLine();
                ConsoleLines();
                pg.Generator(input, listOfSites);


                Console.Clear();
                Progressbar();
                Console.Clear();
                Console.WriteLine("Файлът е записан на вашия работен плот");
                Console.ResetColor();
                ConsoleLines();
                Console.WriteLine("За да продължите натиснете [ENTER]");
                Console.ReadKey();
                Console.Clear();


                MainMenu();
                Console.WriteLine();
                Console.WriteLine(); 
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("За да генерирате нов файл въведете: --new");
                Console.WriteLine("За да приключите програмата въведете: --exit");
                input = Console.ReadLine();


                if (input == "--exit")
                {
                    Environment.Exit(0);

                }
                else if (input == "--new")
                {
                    Console.Clear();
                    Progressbar();
                    Console.Clear();
                    MainMenu();
                    continue;
                }
              



            }
        }

        private void ConsoleLines()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
        }
        private void MainMenu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Title = "PASSWORD GENERATOR v1";


            string patternBold = @"
 ██▓███   ▄▄▄        ██████   ██████  █     █░ ▒█████   ██▀███  ▓█████▄        
▓██░  ██▒▒████▄    ▒██    ▒ ▒██    ▒ ▓█░ █ ░█░▒██▒  ██▒▓██ ▒ ██▒▒██▀ ██▌       
▓██░ ██▓▒▒██  ▀█▄  ░ ▓██▄   ░ ▓██▄   ▒█░ █ ░█ ▒██░  ██▒▓██ ░▄█ ▒░██   █▌       
▒██▄█▓▒ ▒░██▄▄▄▄██   ▒   ██▒  ▒   ██▒░█░ █ ░█ ▒██   ██░▒██▀▀█▄  ░▓█▄   ▌       
▒██▒ ░  ░ ▓█   ▓██▒▒██████▒▒▒██████▒▒░░██▒██▓ ░ ████▓▒░░██▓ ▒██▒░▒████▓        
▒▓▒░ ░  ░ ▒▒   ▓▒█░▒ ▒▓▒ ▒ ░▒ ▒▓▒ ▒ ░░ ▓░▒ ▒  ░ ▒░▒░▒░ ░ ▒▓ ░▒▓░ ▒▒▓  ▒        
░▒ ░       ▒   ▒▒ ░░ ░▒  ░ ░░ ░▒  ░ ░  ▒ ░ ░    ░ ▒ ▒░   ░▒ ░ ▒░ ░ ▒  ▒        
░░         ░   ▒   ░  ░  ░  ░  ░  ░    ░   ░  ░ ░ ░ ▒    ░░   ░  ░ ░  ░        
               ░  ░      ░        ░      ░        ░ ░     ░        ░           
                                                                 ░             
  ▄████ ▓█████  ███▄    █ ▓█████  ██▀███   ▄▄▄      ▄▄▄█████▓ ▒█████   ██▀███  
 ██▒ ▀█▒▓█   ▀  ██ ▀█   █ ▓█   ▀ ▓██ ▒ ██▒▒████▄    ▓  ██▒ ▓▒▒██▒  ██▒▓██ ▒ ██▒
▒██░▄▄▄░▒███   ▓██  ▀█ ██▒▒███   ▓██ ░▄█ ▒▒██  ▀█▄  ▒ ▓██░ ▒░▒██░  ██▒▓██ ░▄█ ▒
░▓█  ██▓▒▓█  ▄ ▓██▒  ▐▌██▒▒▓█  ▄ ▒██▀▀█▄  ░██▄▄▄▄██ ░ ▓██▓ ░ ▒██   ██░▒██▀▀█▄  
░▒▓███▀▒░▒████▒▒██░   ▓██░░▒████▒░██▓ ▒██▒ ▓█   ▓██▒  ▒██▒ ░ ░ ████▓▒░░██▓ ▒██▒
 ░▒   ▒ ░░ ▒░ ░░ ▒░   ▒ ▒ ░░ ▒░ ░░ ▒▓ ░▒▓░ ▒▒   ▓▒█░  ▒ ░░   ░ ▒░▒░▒░ ░ ▒▓ ░▒▓░
  ░   ░  ░ ░  ░░ ░░   ░ ▒░ ░ ░  ░  ░▒ ░ ▒░  ▒   ▒▒ ░    ░      ░ ▒ ▒░   ░▒ ░ ▒░
░ ░   ░    ░      ░   ░ ░    ░     ░░   ░   ░   ▒     ░      ░ ░ ░ ▒    ░░   ░ 
      ░    ░  ░         ░    ░  ░   ░           ░  ░             ░ ░     ░     
                                                                               
                                                                                     
";
            Console.WriteLine(patternBold);
            Console.ForegroundColor = ConsoleColor.Blue;
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("● Програмата има за цел да генерира осем-цифрена парола , като символите съдържащи се в нея, са избрани на случаен принцип.");
            sb.AppendLine("Паролите ще бъдат записани на работния плот в текстов документ.");
            sb.AppendLine("Просто следвайте инструкциите. ●");
            sb.AppendLine("Тук можете да проверите сигурността на генерираните пароли: https://www.passwordmonster.com");
            Console.WriteLine(sb.ToString()) ;
            Console.ResetColor();


        }

        private void Progressbar()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(1, 1);
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i <= 100; i++)
            {
                Console.Write($"[{i}%]");
                for (int j = 0; j < i; j++)
                {
                    Console.Write("█");
                }

                Console.SetCursorPosition(1, 1);
                System.Threading.Thread.Sleep(50);

            }
            Console.WriteLine();
        }
      
    }
}
