using System;
using System.Windows.Forms;

namespace Break
{
    public partial class Form1 : Form
    {
        DateTime Ticked;
        int interval;
        System.Timers.Timer timer = new System.Timers.Timer();
        public Form1()
        {
            InitializeComponent();
            timer.Stop();
            Ticked = DateTime.Now;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);
        }

        private void finished_Click(object sender, EventArgs e)
        {
            Ticked = DateTime.Now;
            interval = 60000 * Convert.ToInt32(textBox1.Text);
            timer.Interval = interval;
            timer.Start();
            this.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            this.Invoke(new Action(() => this.Show()));
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
            notifyIcon1.Text = "Time to next break: " + (Convert.ToInt32(textBox1.Text) - DateTime.Now.Subtract(Ticked).Minutes).ToString() + " Minutes";
        }
    }
}
