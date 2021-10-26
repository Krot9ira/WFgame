using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WAcademy
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int randomblock;
            int blocksN1 = 0;
            int blocksN2 = 0;
            int blocksN3 = 0;
            Random rnd = new Random();
            List<int> Randomser = new List<int>() { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3 };
           
            Field Battle = new Field();
            Battle.numberOfBlockX = 5;
            Battle.numberOfBlockY = 5;
            Battle.lenghtToCenterX = 100;
            Battle.lenghtToCenterY = 100;
            List<Block> blocks = new List<Block>();
            for (int a = 1; a <= 5; a++)
            {
                if (a == 2 || a == 4)
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        if (i == 1 || i == 3 || i == 5)
                        {
                            blocks.Add(new Block(a * Battle.lenghtToCenterX, i * Battle.lenghtToCenterY, 50, 50, 0, true, false));
                        }
                        else
                        {
                            blocks.Add(new Block(a * Battle.lenghtToCenterX, i * Battle.lenghtToCenterY, 50, 50, 4, true, true));
                        }
                    }
                }
                else
                {
                    for (int i = 1; i <= 5; i++)
                    {
                     
                        randomblock = rnd.Next(0, Randomser.Count - 1);
                        
                     
                        blocks.Add(new Block(a * Battle.lenghtToCenterX, i * Battle.lenghtToCenterY, 50, 50, Randomser[randomblock], false, false));
                        Randomser.RemoveAt(randomblock);
                    }
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 Game = new Form1();
            Game.ListTaken(blocks);
            Application.Run(Game);
            

            Console.WriteLine(blocks.Count);


        }
    }
}
