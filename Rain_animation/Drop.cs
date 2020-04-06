using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Rain_animation
{
    class Drop
    {
        public int DropD { get; set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        private static Random rand = null;


        public Drop(Rectangle r) //при включении анимации начинает рандомить координаты 
        {
           
        }
    }
}
