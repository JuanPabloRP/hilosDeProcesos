using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hilosDeProcesos
{
    public partial class frmMain : Form
    {
        int counterLbl1 = 1, lbl1Velocity = 2, counterLbl2 = 1, lbl2Velocity = 2, counterLbl3 = 1, lbl2Velocity3 = 2, lbl3Velocity = 2;
        bool lbl1WentTo100 = false, lbl1WentTo1 = true, lbl2WentTo20 = false, lbl2WentTo1 = true, lbl3WentToTheFinal = false, lbl3WentToTheBegin = true;
        
        /// <summary>
        ///  Juan Pablo Roldan Patiño
        ///  2023
        ///  Aplicacion para ver como en c# hacemos uso de hilos de proceso
        /// </summary>
        
        public frmMain()
        {
            InitializeComponent();
            //lbl2Velocity = lbl1Velocity * 5;
        }

        private  void btnStart_Click(object sender, EventArgs e)
        {
            tmr1.Enabled = true;
            tmr2.Enabled = true;
            //Task.Delay(10);
            tmr3.Enabled = true;

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            tmr1.Enabled = false;
            tmr2.Enabled = false;
            tmr3.Enabled = false;
        }

        private void tmr1_Tick(object sender, EventArgs e)
        {
            if (counterLbl1 == 100)
            {
                lbl1WentTo100 = true;
                lbl1WentTo1 = false;
            }

            if (counterLbl1 == 1)
            {
                lbl1WentTo100 = false;
                lbl1WentTo1 = true;
            }

            if (lbl1WentTo100 == false && lbl1WentTo1 == true)
            {
                lbl1.Text = counterLbl1++.ToString();
                lbl1.Location = new Point(lbl1.Location.X + lbl1Velocity, lbl1.Location.Y);
            }
            else if (lbl1WentTo100 == true && lbl1WentTo1 == false)
            {
                lbl1.Location = new Point(lbl1.Location.X - lbl1Velocity, lbl1.Location.Y);
                lbl1.Text = counterLbl1--.ToString();
            }
            
        }

        private void tmr2_Tick(object sender, EventArgs e)
        {
            if (counterLbl2 == 20)
            {
                lbl2WentTo20 = true;
                lbl2WentTo1 = false;
                lbl2.Text = 20.ToString();
            }

            if (counterLbl2 == 1)
            {
                lbl2WentTo20 = false;
                lbl2WentTo1 = true;
            }

            if (lbl2WentTo20 == false && lbl2WentTo1 == true)
            {
                lbl2.Text = counterLbl2++.ToString();
                lbl2.Location = new Point(lbl2.Location.X + lbl2Velocity, lbl2.Location.Y);
            }

            if ((lbl2WentTo20 == true && lbl2WentTo1 == false) && (lbl1WentTo100 == true && counterLbl1 <= 20))
            {
                lbl2.Text = counterLbl2--.ToString();
                lbl2.Location = new Point(lbl2.Location.X - lbl2Velocity, lbl2.Location.Y);
            }

        }


        private void tmr3_Tick(object sender, EventArgs e)
        {
            
            if (counterLbl3 == 50 ) 
            {
                lbl3WentToTheFinal = true;
                lbl3WentToTheBegin = false;
            }

            if (counterLbl3 == 1 )
            {
                lbl3WentToTheFinal = false;
                lbl3WentToTheBegin = true;
            }

            

            if ( (lbl3WentToTheFinal == false && lbl3WentToTheBegin == true) || (counterLbl1 > counterLbl3 && counterLbl1 <= 50))
            {
                lbl3.Text = counterLbl3++.ToString();
                lbl3.Location = new Point(lbl3.Location.X + lbl3Velocity, lbl3.Location.Y);
            }
            else if ( (lbl3WentToTheFinal == true && lbl3WentToTheBegin == false) || (counterLbl1 < counterLbl3 && counterLbl1 >= 1))
            {
                lbl3.Location = new Point(lbl3.Location.X - lbl3Velocity, lbl3.Location.Y);
                lbl3.Text = counterLbl3--.ToString();
            }
            else
            {
                lbl3.Location = new Point(lbl3.Location.X, lbl3.Location.Y);
                lbl3.Text = "Error";
            }

            
        }

    }
}
