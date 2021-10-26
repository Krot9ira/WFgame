using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace WAcademy
{
    class Block : Field
    {
        public int numberOfBlockType; // Число обозначающее тип блока используется для установки соответствующего внешнего вида
        public bool isCanBeSwaped; //Может ли он меняться с другими блоками местами
        public bool isStatic; //Можно ли его перемещать
        public bool isTaken = false;
        public List<Bitmap> Looks = new List<Bitmap>() { Resource1.block, Resource1.green, Resource1.RED, Resource1.blue, Resource1.white}; //Список с возможными внешними видами

        
        public Block(int x, int y, int z, int r, int numberOfBlockType, bool isStatic,bool isCanBeSwaped)
        {
            this.numberOfBlockX = x;
            this.numberOfBlockY = y;
            this.lenghtToCenterX = z;
            this.lenghtToCenterY = r;
            this.numberOfBlockType = numberOfBlockType;
            this.isStatic = isStatic;
            this.isCanBeSwaped = isCanBeSwaped;
        }
       
       
       
        

    }
    
}
