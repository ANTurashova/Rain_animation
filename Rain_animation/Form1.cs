using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rain_animation
{
    public partial class Form1 : Form
    {
        private Animator a;
        private Thread t;
        private bool stop = true;

        public Form1()
        {
            InitializeComponent();
            a = new Animator(panelMain.CreateGraphics(), panelMain.ClientRectangle); //возвращает прямоугольник, представляющий клиентскую область элемента управления (гарант что останется)
            a.Lvl = 30;
        }

        private void Move() //двигает капли (вниз)
        {
            while (!stop)
            {
                Thread.Sleep(400); //Thread.Sleep() = приостановка потока в миллисек 
                a.Start();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //запуск при клике
        {
            Start();
        }
        private void button2_Click(object sender, EventArgs e) //удалить всё и запустить последнюю капельку :D (Это не баг, а фича!) 
        {
            stop = true;    
            Stop();
        }

        private void panelMain_Resize(object sender, EventArgs e) //При изменении размера формы перерисовывает область отрисовки
        {
            if (this.WindowState != System.Windows.Forms.FormWindowState.Minimized && a != null)
            {
                a.Update(panelMain.CreateGraphics(), panelMain.ClientRectangle);
            } 
        } 

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Drop.dx = trackBar1.Value - 10; //позволяет получить отрицательное значение перемещения
        }

        private void Start()  //Продублированно из Animator.cs, но для Move
        {
            if (t == null || !t.IsAlive) 
            {
                stop = false;
                ThreadStart th = new ThreadStart(Move); 
                t = new Thread(th); 
                t.Start();
            } 
        }
        
        private void Stop() //Продублированно из Animator.cs для a
        {
            stop = true;
            a.Stop();
        }
    }
}
