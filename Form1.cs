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
            //tmrWaitFormLoad.Start();
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

        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BRPlcVar1 != null)
                BRPlcVar1.Disconnect();

            if (BRCpu1 != null)
                BRCpu1.Disconnect();

            if (BRService1 != null)
                BRService1.Disconnect();
        }

        private BR.AN.PviServices.Service BRService1;
        private BR.AN.PviServices.Cpu BRCpu1;
        private BR.AN.PviServices.Variable BRPlcVar1;

        private string DestAddress1 = "127.0.0.1";

        private void button1_Click(object sender, EventArgs e)
        {
            //Form2 frm = new Form2(this);
            //frm.Show();
            ConnectToPlc();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (BRCpu1 != null && BRCpu1.IsConnected)
            {
                if (this.BRPlcVar1 == null)
                {
                    BRPlcVar1 = new BR.AN.PviServices.Variable(BRCpu1, textBox1.Text);
                    BRPlcVar1.ValueRead += new PviEventHandler(BRPlcVar1_ValueRead);
                }
                BRPlcVar1.Connect();
                BRPlcVar1.ReadValue();                
            }
            else
                MessageBox.Show("Connection fault");
        }


        private void ConnectToPlc()
        {
            BRService1 = new Service("BRService1");
            BRService1.Connect();
            BRService1.Connected += new PviEventHandler(BRService1_Connected);
        }

        private void BRService1_Connected(object sender, PviEventArgs e)
        {
            BRCpu1 = new BR.AN.PviServices.Cpu(BRService1, "BRCpu1");
            BRCpu1.Connection.DeviceType = DeviceType.TcpIp;
            BRCpu1.Connection.TcpIp.DestinationIpAddress = "127.0.0.1";

            BRCpu1.Connect();
            BRCpu1.Connected += new PviEventHandler(BRCpu1_Connected);
        }

        private void BRCpu1_Connected(object sender, PviEventArgs e)
        {
            lblStatus.Text = "connectedCpu";
        }

        private void BRPlcVar1_ValueRead(object sender, PviEventArgs e)
        {
            MessageBox.Show(((Variable)sender).Value.ToString());
        }
    }
}
