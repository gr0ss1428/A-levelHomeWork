using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork6
{
    enum Movement
    {
        RESET,
        DOWN,
        UP
    }
    class Program
    {
        
        static Timer timer;
        static Stalactite stalactite;
        static int moveCount;
        static int moveNexGen;
        static Helicopter helicopterUser;
        private static int countFrame;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetWindowSize(121, 36);
            Console.SetBufferSize(121, 36);
            Console.CursorVisible = false;
            Cave wall = new Cave(120, 30, '#');
            stalactite = new Stalactite(119, 30, 'X');
            helicopterUser = new Helicopter(120, 30);
            moveCount = 0;
            moveNexGen = stalactite.random.Next(10, 50);
            countFrame = 0;
            stalactite.NewGeneration();
            
            timer = new Timer(NextFrame, null, 0, 100);

            while (true)
            {
                
                    
                    if(Console.ReadKey(true).Key == ConsoleKey.Spacebar) helicopterUser.ChangeMovement();
                //helicopterUser.Move();

            }

            Console.ReadKey();

        }
        static void NextFrame(object ob)
        {

            countFrame++;
            if(countFrame%2==0)stalactite.Move();
            helicopterUser.Move();
            
            if (++moveCount >= moveNexGen)
            {
                moveCount = 0;
                moveNexGen = stalactite.random.Next(10, 50);
                stalactite.NewGeneration();
            }

            if (countFrame == 10) countFrame = 0;
            helicopterUser.movement = Movement.DOWN;
        }

       
    }
}
