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
            tmrWaitFormLoad.Start();
        }

        private void tmrWaitFormLoad_Tick(object sender, EventArgs e)
        {
            tmrWaitFormLoad.Stop();
            PlcComm.ConnectToPvi("127.0.0.1");
            Wait(2000);
            bool connOK = PlcComm.CheckConnection();

            if (connOK)
            {
                lblStatus.Text = "Plc OK";
                tmrVisuUpdate.Start();
            }
            else
                lblStatus.Text = "Plc not connected";
         }

        private void Wait(int ms)
        {
            for (int i = 0; i < ms; i++)
            {
                Thread.Sleep(1);
                System.Windows.Forms.Application.DoEvents();
            }
        }

        private void tmrVisuUpdate_Tick(object sender, EventArgs e)
        {
            chkEnabledAxisX1.Checked = PlcComm.Vars.HMI.Axis[0].Enabled;
            txtActPosAxisX1.Text = PlcComm.Vars.HMI.Axis[0].ActPos.ToString();
            

        }

        private void btnJogPlusX1_MouseDown(object sender, MouseEventArgs e)
        {
            PlcComm.Vars.HMI.Axis[0].JogVelo = Convert.ToDouble(txtMoveVeloAxisX1.Text);
            PlcComm.Vars.HMI.Axis[0].JogPlus = PlcComm.Vars.HMI.Axis[0].Enabled;
        }

        private void btnJogPlusX1_MouseUp(object sender, MouseEventArgs e)
        {
            PlcComm.Vars.HMI.Axis[0].JogPlus = false;
        }

        private void btnJogMinAxisX1_MouseDown(object sender, MouseEventArgs e)
        {
            PlcComm.Vars.HMI.Axis[0].JogVelo = Convert.ToDouble(txtMoveVeloAxisX1.Text);
            PlcComm.Vars.HMI.Axis[0].JogMinus = PlcComm.Vars.HMI.Axis[0].Enabled;
        }

        private void btnJogMinAxisX1_MouseUp(object sender, MouseEventArgs e)
        {
            PlcComm.Vars.HMI.Axis[0].JogMinus = false;
        }

        private void btnResetAxisX1_MouseDown(object sender, MouseEventArgs e)
        {
            PlcComm.Vars.HMI.Axis[0].Reset = true;
        }

        private void btnResetAxisX1_MouseUp(object sender, MouseEventArgs e)
        {
            PlcComm.Vars.HMI.Axis[0].Reset = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(this);
            frm.Show();
        }

        private void btnMovePosAxisX1_Click(object sender, EventArgs e)
        {

        }
    }
}
