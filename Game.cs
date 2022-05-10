using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    public class Game
    {
        private static Game game;
        public Player player;
        public Maze maze;
        public static Game getGame()
        {
            if (game == null)
                game = new Game()
                {
                    maze = new Maze.Builder(11, 7)
                    .FillRoom()
                    .FillHorizontal()
                    .FillVertical()
                    .Build(),
                    player = new Player()
                };
            return game;
        }
        public void Move(int a, int b)
        {
            Console.SetCursorPosition(a, b);
            //Console.Write("☻");
            Console.Write("☺");
        }
        public void Start()
        {
            var a = 1;
            var b = 1;
            var n = 23;
            var m = 16;
            var point = 2;
            var initialPoints = Maze.Builder.point;
            var s = new StringBuilder($"{maze}");

            while (true)
            {
                Console.WriteLine(s);
                Console.WriteLine("Очков: "+point);
                player.Move(a, b);

                if (initialPoints == 0)
                {
                    Console.SetCursorPosition(0, n+2);
                    Console.WriteLine("Поздравляю, вы прошли игру!");
                    break;
                }                    

                if (s[b * m + a] == '@'){
                    s[b * m + a] = ' ';
                    point++;
                    initialPoints--;
                    Console.Clear();
                    continue;
                }

                var pressbtn = Console.ReadKey(true);
                if (pressbtn.Key == ConsoleKey.W)
                {
                    if (b > 1)
                    if (s[(b-1) * m + a] != '─')
                        b -= 2;
                    Console.Clear();
                    continue;
                }

                if (pressbtn.Key == ConsoleKey.A)
                {
                    if (a > 1)
                        if (s[b * m + (a-1)] != '│')
                            a -= 2;
                    Console.Clear();
                    continue;
                }

                if (pressbtn.Key == ConsoleKey.S)
                {
                    if (b < n)
                        if (s[(b+1) * m + a] != '─' && s[(b+1) * m + a] != '═')
                            b += 2;
                    Console.Clear();
                    continue;
                }

                if (pressbtn.Key == ConsoleKey.D)
                {
                    if (a < m)
                        if (s[b * m + (a+1)] != '│' && s[b * m + (a+1)] != '║')
                            a += 2;
                    Console.Clear();
                    continue;
                }

                if (pressbtn.Key == ConsoleKey.I)
                {
                    if (b > 1)
                        if (s[(b-1) * m + a] == '─')
                        {
                            if (point > 1)
                            {
                                
                                point--;
                                s[(b-1) * m + a] = ' ';
                                b -= 2;
                            } else
                            {
                                continue;
                            }
                        }
                    Console.Clear();
                    continue;
                }

                if (pressbtn.Key == ConsoleKey.J)
                {
                    if (a > 1)
                        if (s[b * m + (a-1)] == '│')
                        {
                            if (point > 1)
                            {
                                point--;
                                s[b * m + (a - 1)] = ' ';
                                a -= 2;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    Console.Clear();
                    continue;
                }

                if (pressbtn.Key == ConsoleKey.K)
                {
                    if (b < n)
                        if (s[(b+1) * m + a] == '─' && s[(b+1) * m + a] != '═')
                        {
                            if (point > 1)
                            {
                                point--;
                                s[(b+1) * m + a] = ' ';
                                b += 2;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    Console.Clear();
                    continue;
                }

                if (pressbtn.Key == ConsoleKey.L)
                {
                    if (a < m)
                        if (s[b * m + (a+1)] == '│' && s[b * m + (a+1)] != '║')
                        {
                            if (point > 1)
                            {
                                point--;
                                s[b * m + (a + 1)] = ' ';
                                a += 2;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    Console.Clear();
                    continue;
                }

                if (pressbtn.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.WriteLine("Игра окончена");
                    return;
                }
                if (pressbtn.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    a = 1;
                    b = 1;
                    point = 2;
                    s = new StringBuilder($"{maze}");
                    initialPoints = Maze.Builder.point;
                    continue;
                }
            }
        }
    }
}
