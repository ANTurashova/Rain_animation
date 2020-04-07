using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Rain_animation
{
    class Animator
    {
        private Graphics mainG;
        private BufferedGraphics bg;
        private Thread t;
        private List<Drop> drops = new List<Drop>();
        private Brush b;
        private int width, height;    
        private bool stop = false;
        public int Lvl { get; set; }

        public Animator(Graphics g, Rectangle r)
        {
            Update(g, r);
            b = new SolidBrush(Drop.color); //кисть с заливкой
        }

        public void Update(Graphics g, Rectangle r)
        {
            mainG = g;  //private Graphics
            width = r.Width;
            height = r.Height;
            bg = BufferedGraphicsManager.Current.Allocate(mainG, new Rectangle(0, 0, width, height)); //BGM позволяет реализовать двойную буферизацию
            foreach (var d in drops) //тут будет отрисовочка 
            {
                d.Update(r);
            } 
        }
        
        private void Animate()
        {
            while (!stop)
            {
                Graphics g = bg.Graphics;
                g.Clear(Color.White);
                int cnt = drops.Count;

                for (int i = 0; i < cnt; i++)
                {
                    if (!drops[i].IsAlive) drops.Remove(drops[i]);
                    i--;
                    cnt--;
                }

                foreach (var d in drops)
                {
                    g.FillEllipse(b, d.X, d.Y, d.DropD, d.DropD); //отрисовка кружочков 
                } 
                try
                {
                    bg.Render();
                }
                catch (Exception e) { } 
                Thread.Sleep(Lvl);  //завершение
            }
        }
       
        public void Start() //для запуска дождя
        {
            if (t == null || !t.IsAlive) //IsAlive = true, если поток запущен, else false 
            {
                stop = false;
                ThreadStart th = new ThreadStart(Animate); //ThreadStart = состояние выполнения объекта Thread (старт) 
                t = new Thread(th); //Thread = создаёт и контролирует поток, задаёт приоритет и возвращает статус 
                t.Start();
            }
            var rect = new Rectangle(0, 0, width, height);
            Drop d = new Drop(rect);
            d.Start();
            drops.Add(d);
        }
        
        public void Stop()
        {
            stop = true;
            foreach (var b in drops)
            {
                b.Stop();
            }
            drops.Clear();
        }
    }
}
