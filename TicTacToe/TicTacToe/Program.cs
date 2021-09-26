using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Выберите режим:\n1-игра с другим игроком\n2-игра с ботом");
                var choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    PlayWithAnotherPlayer();
                }
                else if (choice == 2)
                {
                    PlayWithBot();
                }

                Console.ReadLine();
            }
            catch (FormatException arg)
            {
                Console.WriteLine(arg.Message);
            }
        }
        public static void PlayWithAnotherPlayer()
        {
            try
            {
                Console.Clear();
                string name = string.Empty;
                Random rnd = new Random();
                int[] repit = new int[] { };
                Console.WriteLine("Введите имя 1 игрока:");
                string player1 = Console.ReadLine();
                Console.WriteLine("Введите имя 2 игрока:");
                string player2 = Console.ReadLine();
                Console.WriteLine($"Кто будет ходить первым? {player1}, {player2} или рандомный выбор?(1-3)");
                int firstTurn = Convert.ToInt32(Console.ReadLine());

                if (firstTurn == 1)
                {
                    name = player1;
                }
                else if (firstTurn == 2)
                {
                    name = player2;
                }
                else if (firstTurn == 3)
                {
                    firstTurn = rnd.Next(1, 3);
                    name = firstTurn == 1 ? (player1) : (player2);
                }

                Console.WriteLine($"{name}, чем будете ходить?(X:0)");
                string choice = Console.ReadLine();
                Console.WriteLine("Введите размер поля:");
                int n = Convert.ToInt32(Console.ReadLine());
                int[,] buffer = new int[n, n];
                int lenght = n * n;

                if (n < 3)
                {
                    throw new ArgumentException("Размер поля не может быть < 3");
                }

                Console.Clear();
                DrawField(n);

                for (int count = 0; count < lenght; count++)
                {
                    if (firstTurn == 1)
                    {
                        if (choice.Equals("0"))
                        {
                            Console.SetCursorPosition(4 * n + 1, 0);
                            Console.Write($"{player1}, введите номер ячейки: ");
                            int number = Convert.ToInt32(Console.ReadLine());
                            Console.SetCursorPosition(4 * n + 1, 0);
                            string str = new string(' ', 40);
                            Console.Write(str);
                            int result = repit.FirstOrDefault(c => c == number);

                            if (result == 0)
                            {
                                Draw0(number, n);
                                int i0 = ((number - 1) / n);
                                int j0 = ((number - 1) % n);
                                buffer[i0, j0] = 2;
                                choice = "X";
                                Array.Resize(ref repit, repit.Length + 1);
                                repit[repit.Length - 1] = number;
                            }
                            else
                            {
                                Console.SetCursorPosition(4 * n + 1, 1);
                                Console.Write("Эта ячейка занята, введите другое число");
                                string wait = Console.ReadLine();
                                Console.SetCursorPosition(4 * n + 1, 1);
                                str = new string(' ', 40);
                                Console.Write(str);
                                lenght++;
                                choice = "0";
                                firstTurn = 1;
                                continue;
                            }
                        }
                        else
                        {
                            Console.SetCursorPosition(4 * n + 1, 0);
                            Console.Write($"{player1}, введите номер ячейки: ");
                            int number = Convert.ToInt32(Console.ReadLine());
                            Console.SetCursorPosition(4 * n + 1, 0);
                            string str = new string(' ', 40);
                            Console.Write(str);
                            int result = repit.FirstOrDefault(c => c == number);

                            if (result == 0)
                            {
                                DrawX(number, n);
                                int i0 = ((number - 1) / n);
                                int j0 = ((number - 1) % n);
                                buffer[i0, j0] = 1;
                                choice = "0";
                                Array.Resize(ref repit, repit.Length + 1);
                                repit[repit.Length - 1] = number;
                            }
                            else
                            {
                                Console.SetCursorPosition(4 * n + 1, 1);
                                Console.Write("Эта ячейка занята, введите другое число");
                                string wait = Console.ReadLine();
                                Console.SetCursorPosition(4 * n + 1, 1);
                                str = new string(' ', 40);
                                Console.Write(str);
                                lenght++;
                                choice = "X";
                                firstTurn = 1;
                                continue;
                            }

                        }

                        firstTurn *= 2;
                    }
                    else if (firstTurn == 2)
                    {
                        if (choice.Equals("X"))
                        {
                            Console.SetCursorPosition(4 * n + 1, 0);
                            Console.Write($"{player2}, введите номер ячейки: ");
                            int number = Convert.ToInt32(Console.ReadLine());
                            Console.SetCursorPosition(4 * n + 1, 0);
                            string str = new string(' ', 40);
                            Console.Write(str);
                            int result = repit.FirstOrDefault(c => c == number);

                            if (result == 0)
                            {
                                DrawX(number, n);
                                int i0 = ((number - 1) / n);
                                int j0 = ((number - 1) % n);
                                buffer[i0, j0] = 1;
                                choice = "0";
                                Array.Resize(ref repit, repit.Length + 1);
                                repit[repit.Length - 1] = number;
                            }
                            else
                            {
                                Console.SetCursorPosition(4 * n + 1, 1);
                                Console.Write("Эта ячейка занята, введите другое число");
                                string wait = Console.ReadLine();
                                Console.SetCursorPosition(4 * n + 1, 1);
                                str = new string(' ', 40);
                                Console.Write(str);
                                lenght++;
                                choice = "X";
                                firstTurn = 2;
                                continue;
                            }
                        }
                        else
                        {
                            Console.SetCursorPosition(4 * n + 1, 0);
                            Console.Write($"{player2}, введите номер ячейки: ");
                            int number = Convert.ToInt32(Console.ReadLine());
                            Console.SetCursorPosition(4 * n + 1, 0);
                            string str = new string(' ', 40);
                            Console.Write(str);
                            int result = repit.FirstOrDefault(c => c == number);

                            if (result == 0)
                            {
                                Draw0(number, n);
                                int i0 = ((number - 1) / n);
                                int j0 = ((number - 1) % n);
                                buffer[i0, j0] = 2;
                                choice = "X";
                                Array.Resize(ref repit, repit.Length + 1);
                                repit[repit.Length - 1] = number;
                            }
                            else
                            {
                                Console.SetCursorPosition(4 * n + 1, 1);
                                Console.Write("Эта ячейка занята, введите другое число");
                                string wait = Console.ReadLine();
                                Console.SetCursorPosition(4 * n + 1, 1);
                                str = new string(' ', 40);
                                Console.Write(str);
                                lenght++;
                                choice = "0";
                                firstTurn = 2;
                                continue;
                            }
                        }

                        firstTurn /= 2;
                    }

                    CheckWinner(ref n, player1, player2, buffer, firstTurn);

                    if (repit.Length == lenght)
                    {
                        Console.SetCursorPosition(4 * n + 1, 0);
                        string str = new string(' ', 40);
                        Console.Write(str);
                        Console.SetCursorPosition(4 * n + 1, 0);
                        Console.Write($"Ничья");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                }
            }
            catch (ArgumentException arg)
            {
                Console.WriteLine(arg.Message);
            }

            catch (FormatException arg)
            {
                Console.WriteLine(arg.Message);
            }
        }
        public static void PlayWithBot()
        {
            try
            {
                Console.Clear();
                string name = string.Empty;
                Random rnd = new Random(Guid.NewGuid().ToByteArray().Sum(x => x));
                int[] repit = new int[] { };
                Console.WriteLine("Введите ваше имя:");
                string player1 = Console.ReadLine();
                string bot = "Bot";
                string choice = string.Empty;
                Console.WriteLine($"Кто будет ходить первым? {player1}, {bot} или рандомный выбор?(1-3)");
                int firstTurn = Convert.ToInt32(Console.ReadLine());

                if (firstTurn == 1)
                {
                    name = player1;
                    Console.WriteLine($"{name}, чем будете ходить?(X:0)");
                    choice = Console.ReadLine();
                }
                else if (firstTurn == 2)
                {
                    name = bot;
                    int rand = rnd.Next(1, 3);
                    choice = rand == 1 ? ("X") : ("0");
                }
                else if (firstTurn == 3)
                {
                    firstTurn = rnd.Next(1, 3);
                    name = firstTurn == 1 ? (player1) : (bot);

                    if (firstTurn == 1)
                    {
                        name = player1;
                        Console.WriteLine($"{name}, чем будете ходить?(X:0)");
                        choice = Console.ReadLine();
                    }
                    else if (firstTurn == 2)
                    {
                        name = bot;
                        int rand = rnd.Next(1, 3);
                        choice = rand == 1 ? ("X") : ("0");
                    }
                }

                Console.WriteLine("Введите размер поля:");
                int n = Convert.ToInt32(Console.ReadLine());
                int[,] buffer = new int[n, n];
                int lenght = n * n;

                if (n < 3)
                {
                    throw new ArgumentException("Размер поля не может быть < 3");
                }

                Console.Clear();
                DrawField(n);

                for (int count = 0; count < lenght; count++)
                {
                    if (firstTurn == 1)
                    {
                        if (choice.Equals("0"))
                        {
                            Console.SetCursorPosition(4 * n + 1, 0);
                            Console.Write($"{player1}, введите номер ячейки: ");
                            int number = Convert.ToInt32(Console.ReadLine());
                            Console.SetCursorPosition(4 * n + 1, 0);
                            string str = new string(' ', 40);
                            Console.Write(str);
                            int result = repit.FirstOrDefault(c => c == number);

                            if (result == 0)
                            {
                                Draw0(number, n);
                                int i0 = ((number - 1) / n);
                                int j0 = ((number - 1) % n);
                                buffer[i0, j0] = 2;
                                choice = "X";
                                Array.Resize(ref repit, repit.Length + 1);
                                repit[repit.Length - 1] = number;
                            }
                            else
                            {
                                Console.SetCursorPosition(4 * n + 1, 1);
                                Console.Write("Эта ячейка занята, введите другое число");
                                string wait = Console.ReadLine();
                                Console.SetCursorPosition(4 * n + 1, 1);
                                str = new string(' ', 40);
                                Console.Write(str);
                                lenght++;
                                choice = "0";
                                firstTurn = 1;
                                continue;
                            }
                        }
                        else
                        {
                            Console.SetCursorPosition(4 * n + 1, 0);
                            Console.Write($"{player1}, введите номер ячейки: ");
                            int number = Convert.ToInt32(Console.ReadLine());
                            Console.SetCursorPosition(4 * n + 1, 0);
                            string str = new string(' ', 40);
                            Console.Write(str);
                            int result = repit.FirstOrDefault(c => c == number);

                            if (result == 0)
                            {
                                DrawX(number, n);
                                int i0 = ((number - 1) / n);
                                int j0 = ((number - 1) % n);
                                buffer[i0, j0] = 1;
                                choice = "0";
                                Array.Resize(ref repit, repit.Length + 1);
                                repit[repit.Length - 1] = number;
                            }
                            else
                            {
                                Console.SetCursorPosition(4 * n + 1, 1);
                                Console.Write("Эта ячейка занята, введите другое число");
                                string wait = Console.ReadLine();
                                Console.SetCursorPosition(4 * n + 1, 1);
                                str = new string(' ', 40);
                                Console.Write(str);
                                lenght++;
                                choice = "X";
                                firstTurn = 1;
                                continue;
                            }

                        }

                        firstTurn *= 2;
                    }
                    else if (firstTurn == 2)
                    {
                        if (choice.Equals("X"))
                        {
                            Console.SetCursorPosition(4 * n + 1, 0);
                            Console.Write($"{bot}, введите номер ячейки: ");
                            int number = GiveMeANumber(repit, lenght);
                            Console.SetCursorPosition(4 * n + 1, 0);
                            string str = new string(' ', 40);
                            Console.Write(str);
                            int result = repit.FirstOrDefault(c => c == number);

                            if (result == 0)
                            {
                                DrawX(number, n);
                                int i0 = ((number - 1) / n);
                                int j0 = ((number - 1) % n);
                                buffer[i0, j0] = 1;
                                choice = "0";
                                Array.Resize(ref repit, repit.Length + 1);
                                repit[repit.Length - 1] = number;
                            }
                            else
                            {
                                Console.SetCursorPosition(4 * n + 1, 1);
                                Console.Write("Эта ячейка занята, введите другое число");
                                string wait = Console.ReadLine();
                                Console.SetCursorPosition(4 * n + 1, 1);
                                str = new string(' ', 40);
                                Console.Write(str);
                                lenght++;
                                choice = "X";
                                firstTurn = 2;
                                continue;
                            }
                        }
                        else
                        {
                            Console.SetCursorPosition(4 * n + 1, 0);
                            Console.Write($"{bot}, введите номер ячейки: ");
                            int number = GiveMeANumber(repit, lenght);
                            Console.SetCursorPosition(4 * n + 1, 0);
                            string str = new string(' ', 40);
                            Console.Write(str);
                            int result = repit.FirstOrDefault(c => c == number);

                            if (result == 0)
                            {
                                Draw0(number, n);
                                int i0 = ((number - 1) / n);
                                int j0 = ((number - 1) % n);
                                buffer[i0, j0] = 2;
                                choice = "X";
                                Array.Resize(ref repit, repit.Length + 1);
                                repit[repit.Length - 1] = number;
                            }
                            else
                            {
                                Console.SetCursorPosition(4 * n + 1, 1);
                                Console.Write("Эта ячейка занята, введите другое число");
                                string wait = Console.ReadLine();
                                Console.SetCursorPosition(4 * n + 1, 1);
                                str = new string(' ', 40);
                                Console.Write(str);
                                lenght++;
                                choice = "0";
                                firstTurn = 2;
                                continue;
                            }
                        }

                        firstTurn /= 2;
                    }

                    CheckWinner(ref n, player1, bot, buffer, firstTurn);

                    if (repit.Length == lenght)
                    {
                        Console.SetCursorPosition(4 * n + 1, 0);
                        string str = new string(' ', 40);
                        Console.Write(str);
                        Console.SetCursorPosition(4 * n + 1, 0);
                        Console.Write($"Ничья");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                }
            }
            catch (ArgumentException arg)
            {
                Console.WriteLine(arg.Message);
            }

            catch (FormatException arg)
            {
                Console.WriteLine(arg.Message);
            }
        }
        public static void CheckWinner(ref int n, string player1, string player2, int[,] buffer, int firstTurn)
        {
            int sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0, sum5 = 0, sum6 =0;
            for (int i = 0; i < buffer.GetLength(0); i++)
            {
                for (int j = 0; j < buffer.GetLength(1); j++)
                {
                    if (buffer[i, j] == 2 || buffer[j, i] == 2)
                    {
                        sum2++;
                    }
                    else if (buffer[i, j] == 1 || buffer[j, i] == 1)
                    {
                        sum1++;
                    }
                }

                if (sum1 == 3 || sum2 == 3)
                {
                    break;
                }
                else
                {
                    sum1 = 0; sum2 = 0;
                }
            }

            for (int i = 0; i < buffer.GetLength(0); i++)
            {
                for (int j = 0; j < buffer.GetLength(1); j++)
                {
                    if (buffer[i, j] == 2 && i == j)
                    {
                        sum4++;
                    }
                    else if (buffer[i, j] == 1 && i == j)
                    {
                        sum3++;
                    }
                }
            }

            for (int i = 0; i < buffer.GetLength(0); i++)
            {
                for (int j = 0; j < buffer.GetLength(1); j++)
                {
                    if (buffer[i, j] == 2 && i + j == n - 1)
                    {
                        sum6++;
                    }
                    else if (buffer[i, j] == 1 && i + j == n - 1)
                    {
                        sum5++;
                    }
                }
            }

            if (sum1 == 3 || sum2 == 3 || sum3 == 3 || sum4 == 3 || sum5 == 3 || sum6 == 3  && firstTurn == 2)
            {
                Console.SetCursorPosition(4 * n + 1, 0);
                string str = new string(' ', 40);
                Console.Write(str);
                Console.SetCursorPosition(4 * n + 1, 0);
                Console.Write($"Победил {player1}");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else if (sum1 == 3 || sum2 == 3 || sum3 == 3 || sum4 == 3 || sum5 == 3 || sum6 == 3 && firstTurn == 1)
            {
                Console.SetCursorPosition(4 * n + 1, 0);
                string str = new string(' ', 40);
                Console.Write(str);
                Console.SetCursorPosition(4 * n + 1, 0);
                Console.Write($"Победил {player2}");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
        public static int GiveMeANumber(int[] exclude, int lenght)
        {
            Random rand = new Random();
            var validValues = Enumerable.Range(1, lenght + 1).Except(exclude).ToArray();
            var result = validValues[rand.Next(0, validValues.Length)];
            return result;
        }
        public static void DrawField(int n)
        {
            for (int i = 0; i <= 4 * n; i += 4)
            {
                for (int j = 0; j <= 4 * n; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write('=');
                }
            }

            for (int j = 0; j <= 4 * n; j += 4)
            {
                for (int i = 0; i <= 4 * n; i++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write('=');
                }
            }

            for (int count = 1; count <= n * n; count++)
            {
                int i0 = ((count - 1) % n) * 4 + 1;
                int j0 = ((count - 1) / n) * 4 + 1;
                Console.SetCursorPosition(i0 + 1, j0 + 1);
                Console.Write($"{count}");
            }
        }
        public static void Draw0(int number, int n)
        {
            int i0 = ((number - 1) % n) * 4 + 1;
            int j0 = ((number - 1) / n) * 4 + 1;
            Console.SetCursorPosition(i0 + 1, j0 + 1);
            Console.Write('0');
        }
        public static void DrawX(int number, int n)
        {
            int i0 = ((number - 1) % n) * 4 + 1;
            int j0 = ((number - 1) / n) * 4 + 1;
            Console.SetCursorPosition(i0 + 1, j0 + 1);
            Console.Write('X');
        }
    }
}
