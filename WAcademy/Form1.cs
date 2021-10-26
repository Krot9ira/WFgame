using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WAcademy
{
    public partial class Form1 : Form
    {
        public Bitmap ChipRed = Resource1.RED;
        bool isTakenObject = false;
        List<Block> blocks = new List<Block>();
        bool isOne = false;
        int localPositionX;
        int localPositionY;
        
        internal void ListTaken(List<Block> blockуs)
        {
            blocks = blockуs;
        }
        public Form1()
        {
            
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | 
                ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.UserPaint, true);
            UpdateStyles();
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (Block item in blocks)
                {
                if (item.isTaken == true)
                {
                    var localposition = this.PointToClient(MousePosition);
                    int x = localposition.X;
                    int y = localposition.Y;
                    g.DrawImage(item.Looks[item.numberOfBlockType], new Rectangle(x - 25, y - 25, item.lenghtToCenterX, item.lenghtToCenterY));
                }
                else
                {
                    g.DrawImage(item.Looks[item.numberOfBlockType], new Rectangle(item.numberOfBlockX, item.numberOfBlockY, item.lenghtToCenterX, item.lenghtToCenterY));
                }

            }
            
            
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = Control.MousePosition.X;
            int xForRed = 0;
            int xForGreen = 0;
            int xForBlue = 0;
            foreach (Block item3 in blocks) // проверка на окончание игры
            {
                if (item3.numberOfBlockType == 1 & xForGreen == 0)
                {
                    xForGreen = item3.numberOfBlockX;

                }
                else if (item3.numberOfBlockType == 1 & xForGreen != 0)
                {
                    if (item3.numberOfBlockX == xForGreen)
                    {
                        isOne = true;
                    }
                    else
                    {
                        isOne = false;
                        break;
                    }

                }
                if (item3.numberOfBlockType == 2 & xForRed == 0)
                {
                    xForRed = item3.numberOfBlockX;

                }
                else if (item3.numberOfBlockType == 2 & xForRed != 0)
                {
                    if (item3.numberOfBlockX == xForRed)
                    {
                        isOne = true;
                    }
                    else
                    {
                        isOne = false;
                        break;
                    }

                }
                if (item3.numberOfBlockType == 3 & xForBlue == 0)
                {
                    xForBlue = item3.numberOfBlockX;

                }
                else if (item3.numberOfBlockType == 3 & xForBlue != 0)
                {
                    if (item3.numberOfBlockX == xForBlue)
                    {
                        isOne = true;
                    }
                    else
                    {
                        isOne = false;
                        break;
                    }

                }
                


            }
            if (isOne == true)
            {
                Application.Exit(); 
            }
            Refresh();
        }
        // ниже код который проверяет есть ли под мышкой блок, а так же когда уже блок в "руке" на какой блок перенес его игрок
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (Block item in blocks)
            {
                Point between = new Point((item.numberOfBlockX + 25) - e.X, (item.numberOfBlockY + 25) - e.Y);
                double distance = Math.Sqrt((between.X * between.X) + (between.Y * between.Y)); 
                if (distance < 28 & item.isStatic == false)
                {
                    isTakenObject = true;
                    item.isTaken = true;
                    break;
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (Block item in blocks)
            {
                if (item.isTaken == true)
                {
                    foreach (Block item2 in blocks)
                    {
                        if (item2.isCanBeSwaped == false)
                        { }
                        else
                        {
                            Point between = new Point((item2.numberOfBlockX + 25) - e.X, (item2.numberOfBlockY + 25) - e.Y);
                            double distance = Math.Sqrt((between.X * between.X) + (between.Y * between.Y));
                            Point betweenBlock = new Point((item.numberOfBlockX) - item2.numberOfBlockX, (item.numberOfBlockY) - item2.numberOfBlockY);
                            double distanceOfBlock = Math.Sqrt((betweenBlock.X * betweenBlock.X) + (betweenBlock.Y * betweenBlock.Y));
                            if (distance < 28 & distanceOfBlock < 110)
                            {
                                localPositionX = item.numberOfBlockX;
                                localPositionY = item.numberOfBlockY;
                                item.numberOfBlockX = item2.numberOfBlockX;
                                item.numberOfBlockY = item2.numberOfBlockY;
                                item2.numberOfBlockX = localPositionX;
                                item2.numberOfBlockY = localPositionY;
                            }
                        }
                    }
                    
                    isTakenObject = false;
                    item.isTaken = false;
                    
                    break;
                }
               
            }
        }
    }
}
