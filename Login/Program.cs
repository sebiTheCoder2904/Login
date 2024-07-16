using static System.Net.Mime.MediaTypeNames;

namespace Login
{
    internal class Program
    {
        static void typeString(string text, int delay)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            // Console.WriteLine("");
        }

        static void typeString_middle(int yPoss, string text, int delay)
        {
            Console.SetCursorPosition((Console.WindowWidth / 2) - (text.Length / 2), yPoss);
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine("");
        }

        static void loadingDot(int yPoss, int Length, int delay, int loop)
        {
            Console.CursorVisible = false;
            for (int j = loop; j > 0; j--)
            {
                for (int i = 0; i != Length; i++)
                {
                    string spaces = new string(' ', i);
                    Console.SetCursorPosition((Console.WindowWidth / 2) - (Length / 2), yPoss);
                    Console.Write(spaces + "x");
                    Thread.Sleep(delay);
                }

                for (int i = Length; i != 0; i--)
                {
                    string spaces = new string(' ', i);
                    Console.SetCursorPosition((Console.WindowWidth / 2) - (Length / 2), yPoss);
                    Console.Write(spaces + "x                        ");
                    Thread.Sleep(delay);
                }
            }
            Console.CursorVisible = true;
            // for (int i = Length; i  Length; i++)
            // {
            //     string spaces = new string(' ', i);
            //     typeString_middle(yPoss, spaces + "x", 30);
            // }

        }

        static bool Login(string username, string password, int trys)
        {
            string userText = "Username: ";
            string passText = "Password: ";
            int x = 0;

            while (true)
            {

                Console.Clear();

                Console.SetCursorPosition((Console.WindowWidth / 2) - ((userText.Length + username.Length) / 2), ((Console.WindowHeight / 2) - 1));
                typeString(userText, 30);
                string userInput = Console.ReadLine().ToString();

                Console.SetCursorPosition((Console.WindowWidth / 2) - ((passText.Length + password.Length) / 2), (Console.WindowHeight / 2));
                typeString(passText, 30);
                string passInput = Console.ReadLine().ToString();

                loadingDot((Console.WindowHeight / 2) + 3, 30, 30, 2);

                if (userInput == username && passInput == password)
                {
                    Console.Clear();
                    typeString_middle(Console.WindowHeight / 2, "You're now logged in have fun...", 30);
                    return true;

                }
                else
                {
                    if (x == (trys - 1))
                    {
                        Console.Clear();
                        typeString_middle(Console.WindowHeight / 2, "Now you will have to do a quiz with us...", 30);
                        return false;
                    }
                    else
                    {
                        Console.Clear();
                        typeString_middle(Console.WindowHeight / 2, "Login failed. Please check your username and password and try again.", 30);
                        x++;
                    }
                }

            }
        }

        static bool quiz()
        {
            string question1 = "How old are you?";
            string answer1 = "I am __ Years old";
            int year = 2024;
            string question2 = "when were you born?";
            string answer2 = "I was born in the Year ____";

            Console.Clear();
            // question 1
            Console.SetCursorPosition((Console.WindowWidth / 2) - ((question1.Length) / 2), ((Console.WindowHeight / 2) - 2));
            typeString(question1, 30);

            Console.SetCursorPosition((Console.WindowWidth / 2) - ((answer1.Length) / 2), ((Console.WindowHeight / 2)));
            typeString(answer1, 30);
            Console.SetCursorPosition(Console.CursorLeft - 12, Console.CursorTop);

            string ageInput = Console.ReadLine().ToString();

            // question 2
            Console.Clear() ;
            Console.SetCursorPosition((Console.WindowWidth / 2) - ((question2.Length) / 2), ((Console.WindowHeight / 2) - 2));
            typeString(question2, 30);

            Console.SetCursorPosition((Console.WindowWidth / 2) - ((answer2.Length) / 2), ((Console.WindowHeight / 2)));
            typeString(answer2, 30);
            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop);


            string yearInput = Console.ReadLine().ToString();

            if (year - int.Parse(ageInput) == int.Parse(yearInput))
            {
                Console.Clear();
                typeString_middle(Console.WindowHeight / 2, "you completed our quiz", 30);
                return true;

            }
            else
            {
                Console.Clear();
                typeString_middle(Console.WindowHeight / 2, "you are now blogged... bye", 30);
                return false;
            }
        }


        static void Main()
            {
                while (true)
                {
                    if (Login("Sebi", "2009", 3) == false)
                    {
                        if (quiz() == false)
                        {
                            break;
                        }
                    }
                    else break;
                    
                }
                Console.ReadKey();

        }
    }
}


// no loggin:
//  1# how old are you?
//  2# calculating the age 
//  3# asking for birth
//  4# showing result

