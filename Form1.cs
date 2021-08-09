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

        

        private void btnMovePosAxisX1_Click(object sender, EventArgs e)
        {
            PlcComm.Vars.HMI.Axis[0].SetPos = Convert.ToDouble(txtGoToPosAxisX1.Text);
            PlcComm.Vars.HMI.Axis[0].SetVelo = Convert.ToDouble(txtMoveVeloAxisX1.Text);
            PlcComm.Vars.HMI.Axis[0].MoveSetPos = PlcComm.Vars.HMI.Axis[0].Enabled && !PlcComm.Vars.HMI.Axis[0].MoveSetPos;
        }

        private void btnStopAxisX1_Click(object sender, EventArgs e)
        {
            PlcComm.Vars.HMI.Axis[0].MoveSetPos = false;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlcComm.Read(textBox1.Text);

            MessageBox.Show(PlcComm.PlcValue);
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
