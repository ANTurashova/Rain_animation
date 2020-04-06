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
        private bool stop = true;
        private Thread t;

        public Form1()
        {
            InitializeComponent();
         
        }

        private void Move() //двигает капли (вниз)
        {
            while (!stop)
            {
                Thread.Sleep(150); //Thread.Sleep() = приостановка потока в миллисек 
               
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panelMain_Resize(object sender, EventArgs e) //При изменении размера формы перерисовывает область отрисовки
        {
            if (this.WindowState != System.Windows.Forms.FormWindowState.Minimized && a != null)
            {
                
            } 
        } 

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           
        }

        

        private void panelMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                stop = true;    //правая кропка - стоп
                Stop();
            }
            else if (e.Button == MouseButtons.Left) //левая кнопка - старт 
            {
                Start();
            } 
        }

        private void Start() //для запуска дождя
        {
            if (t == null || !t.IsAlive) //IsAlive = true, если поток запущен, else false 
            {
                stop = false;
                ThreadStart th = new ThreadStart(Move); //ThreadStart = состояние выполнения объекта Thread (старт) 
                t = new Thread(th); //Thread = создаёт и контролирует поток, задаёт приоритет и возвращает статус 
                t.Start();
            } 
        }
        private void Stop()
        {
           
        }
    }
}
