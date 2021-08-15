using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using BR.AN.PviServices;

namespace BRCommTest
{
    public partial class Form1 : Form
    {
        public ClassBuRPlcComm PlcComm;

        public Form1()
        {
            InitializeComponent();
            PlcComm = new ClassBuRPlcComm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void Wait(int ms)
        {
            if (ms < 10)
                ms = 10;

            for (int i = 0; i < ms/10; i++)
            {
                Thread.Sleep(10);
                System.Windows.Forms.Application.DoEvents();
            }
        }

        private async void tmrVisuUpdate_Tick(object sender, EventArgs e)
        {
            tmrVisuUpdate.Stop();

            var res = await PlcComm.ReadLreal("HMI.Axis[0].ActPos");
            txtActPosAxisX1.Text = res.Item2.ToString();

            res = await PlcComm.ReadLreal("HMI.Axis[1].ActPos");
            txtActPosAxisX2.Text = res.Item2.ToString();

            tmrVisuUpdate.Start();
        }

        private void btnJogPlusX1_MouseDown(object sender, MouseEventArgs e)
        {
            PlcComm.Write("HMI.Axis[0].JogPlus");
        }

        private void btnJogPlusX1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void btnJogMinAxisX1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void btnJogMinAxisX1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void btnResetAxisX1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void btnResetAxisX1_MouseUp(object sender, MouseEventArgs e)
        {
           
        }



        TaskCompletionSource<bool> tcs2 = null;
        private async void btnMovePosAxisX1_Click(object sender, EventArgs e)
        {
            tcs2 = new TaskCompletionSource<bool>();
            await tcs2.Task;
            MessageBox.Show("aaaaa");
        }

        private void btnStopAxisX1_Click(object sender, EventArgs e)
        {
            tcs2?.TrySetResult(true);
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            
            var res = await PlcComm.ReadUint(textBox1.Text);
            
            MessageBox.Show(res.Item1.ToString() + "|" + res.Item2.ToString());
        }

   
        private void btnStructReader_Click(object sender, EventArgs e)
        {
            tmrWaitFormLoad.Interval = 10;
            tmrWaitFormLoad.Start();
        }

        private void tmrWaitFormLoad_Tick(object sender, EventArgs e)
        {
            tmrWaitFormLoad.Stop();
            PlcComm.ConnectToPvi("127.0.0.1");
            bool connOK = PlcComm.CheckConnection();

            if (connOK)
            {
                lblStatus.Text = "Plc OK";
                tmrVisuUpdate.Start();
            }
            else
                lblStatus.Text = "Plc not connected";
        }

        private void ConnectToPlc()
        {
            PlcComm.ConnectToPvi("127.0.0.1");
        }
    }
}
