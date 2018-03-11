using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 50;//cercivenin eni
            Console.WindowWidth = 50;//cercivenin hundurluyu
            int screenwidth = Console.WindowWidth;
            int screenheight = Console.WindowHeight;
            Random randomnummer = new Random();//teasadufi eded
            int score = 5;// ilanin bawlanginc uzunlugu
            int gameover = 0;
            pixel Snake = new pixel();
            Snake.xpos = screenwidth / 2; 
            Snake.ypos = screenheight / 2;//ilanin bawlanginc pozisiyasi
            Snake.head = ConsoleColor.Red;
            string movement = "RIGHT";
            List<int> listPosX = new List<int>();
            List<int> listPosY = new List<int>();
            int nextPosX = randomnummer.Next(0, screenwidth);//tesadufi pikselin setr uzre pozisiyasi
            int nextPosY = randomnummer.Next(0, screenheight);//sutun uzre pozisiyasi
            DateTime tijd = DateTime.Now;
            DateTime tijd2 = DateTime.Now;
            bool keypress = false;
            while (true)
            {
                Console.Clear();
                if (Snake.xpos == screenwidth - 1 || Snake.xpos == 0 || Snake.ypos == screenheight - 1 || Snake.ypos == 0)
                {
                    gameover = 1;
                }
                //ekranimizin kenar boyunca xetler.
                for (int i = 0; i < screenwidth; i++)
                {
                    Console.SetCursorPosition(i, 0); 
                    Console.Write("■");
                }
                for (int i = 0; i < screenwidth; i++)
                {
                    Console.SetCursorPosition(i, screenheight - 1);
                    Console.Write("■");
                }
                for (int i = 0; i < screenheight; i++)
                {
                    Console.SetCursorPosition(0, i); 
                    Console.Write("■");
                }
                for (int i = 0; i < screenheight; i++)
                {
                    Console.SetCursorPosition(screenwidth - 1, i);
                    Console.Write("■");
                }
                Console.ForegroundColor = ConsoleColor.Green;
                if (nextPosX == Snake.xpos && nextPosY == Snake.ypos)//ilanin bawinin ve tesadufi ekrana verilen pikselin pozisilari eynidise 
                {
                    score++;// ilanin uzunlugu bir vahid artirilir
                    nextPosX = randomnummer.Next(1, screenwidth - 2);
                    nextPosY = randomnummer.Next(1, screenheight - 2);//ekrana tesadufi  piksel verilir
                }
                for (int i = 0; i < listPosX.Count(); i++)
                {
                    Console.SetCursorPosition(listPosX[i], listPosY[i]);
                    Console.Write("■");
                    if (listPosX[i] == Snake.xpos && listPosY[i] == Snake.ypos)//uzunlugunun her hansi bir yerine deyende oyun bitir.
                    {
                        gameover = 1;
                    }
                }
                if (gameover == 1)
                {
                    break;
                }
                Console.SetCursorPosition(Snake.xpos, Snake.ypos);//Bize setrin ve sutunun pozisiyasini qaytarir.
                Console.ForegroundColor = Snake.head;
                Console.Write("■");
                Console.SetCursorPosition(nextPosX, nextPosY);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("■");
                tijd = DateTime.Now;
                keypress = false;
                while (true)
                {
                    tijd2 = DateTime.Now;
                    if (tijd2.Subtract(tijd).TotalMilliseconds > 500) { break; }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo Button = Console.ReadKey(true);
                        Console.WriteLine(Button.Key.ToString());
                        if (Button.Key.Equals(ConsoleKey.UpArrow) && movement != "DOWN" && keypress == false) 
                        {
                            movement = "UP";
                            keypress = true;
                        }
                        if (Button.Key.Equals(ConsoleKey.DownArrow) && movement != "UP" && keypress == false)
                        {
                            movement = "DOWN";
                            keypress = true;
                        }
                        if (Button.Key.Equals(ConsoleKey.LeftArrow) && movement != "RIGHT" && keypress == false)
                        {
                            movement = "LEFT";
                            keypress = true;
                        }
                        if (Button.Key.Equals(ConsoleKey.RightArrow) && movement != "LEFT" && keypress == false)
                        {
                            movement = "RIGHT";
                            keypress = false;
                        }
                    }
                }
                listPosX.Add(Snake.xpos);
                listPosY.Add(Snake.ypos);
                switch (movement)// istiqametler.
                {
                    case "UP":
                        Snake.ypos--;
                        break;
                    case "DOWN":
                        Snake.ypos++;
                        break;
                    case "LEFT":
                        Snake.xpos--;
                        break;
                    case "RIGHT":
                        Snake.xpos++;
                        break;
                }
                if (listPosX.Count() > score)
                {
                    listPosX.RemoveAt(0);
                    listPosY.RemoveAt(0);
                }
            }
            Console.SetCursorPosition(screenwidth / 5, screenheight / 2);
            Console.WriteLine("Game over, Score: " + score);
            Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 1);
        }
       
    }
    class pixel
    {
        public int xpos;
        public int ypos;
        public ConsoleColor head;
    }
}
