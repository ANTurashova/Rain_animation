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
        private static Random rand = null;
        private Thread t;
        public bool IsAlive { get { return t != null && t.IsAlive; } } //IsAlive = true, если поток запущен, else false 
        private int width, height;
        public static Color color = Color.Blue;
        private bool stop = false;
        public int DropD { get; set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        static public int dx { get; set; }
        

        public Drop(Rectangle r) //при включении анимации начинает рандомить координаты 
        {
            Update(r);  //Update(DataSet)
            if (rand == null) rand = new Random();
            X = rand.Next(0, width);
            Y = 0;
            DropD = 10; //размер шариков 
        }

        public void Update(Rectangle r)
        {
            width = r.Width;
            height = r.Height;
        }
        
        private void Move()
        {
            while (!stop && Y < height)
            {
                Thread.Sleep(10);  //Остановка потока в миллисек
                Y += 1;
                if (dx != 0) 
                {
                    X += dx;
                    if (X < 0)
                    {
                        X = width - 1;
                    }
                    if (X > width)
                    {
                        X = 1;
                    } 
                }
            }
        }



        public void Start() //из Animator.cs
        {
            if (t == null || !t.IsAlive)
            {
                stop = false;
                ThreadStart th = new ThreadStart(Move);
                t = new Thread(th);
                t.Start();
            }
        }
        
        public void Stop() //из Animator.cs
        {
            stop = true;
        }
    }
}
