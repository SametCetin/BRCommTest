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

        BR.AN.PviServices.Service BRService;
        BR.AN.PviServices.Cpu BRCpu;
        BR.AN.PviServices.Variable BRVariable;
        BR.AN.PviServices.Variable AxisX1ActVal;
        BR.AN.PviServices.Variable varHMI;


        bool PviConnectionIsOk;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tmrWaitFormLoad.Start();
        }

        private void tmrWaitFormLoad_Tick(object sender, EventArgs e)
        {
            tmrWaitFormLoad.Stop();
            ConnectToPvi();
        }

        void ConnectToPvi()
        {
            if (BRService == null)
            {
                lblStatus.Text = "Connecting to PLC";

                BRService = new Service("service");
                BRService.Connected += new PviEventHandler(BRService_Connected);
            }
            BRService.Connect();
        }

        private void BRService_Connected(object sender, PviEventArgs e)
        {
            if (BRCpu == null)
            {
                BRCpu = new Cpu(BRService, "cpu");
                BRCpu.Connection.DeviceType = DeviceType.ANSLTcp;
                BRCpu.Connection.ANSLTcp.DestinationIpAddress = "127.0.0.1";
                BRCpu.Connected += new PviEventHandler(BRCpu_Connected);
            }
            BRCpu.Connect();
        }

        void BRCpu_Connected(object sender, PviEventArgs e)
        {
            PviConnectionIsOk = true;
            lblStatus.Text = ((Cpu)sender).Name + " connected";
        }

        private void tmrAxisX1_Tick(object sender, EventArgs e)
        {

        }

        private void btnJogPlus_Click(object sender, EventArgs e)
        {
            tmrReadPlc.Start();
        }

        private void tmrReadPlc_Tick(object sender, EventArgs e)
        {
            tmrReadPlc.Stop();
            if (BRVariable == null)
            {
                BRVariable = new Variable(BRCpu, "count");
                BRVariable.Active = true;
                BRVariable.Connect();
                BRVariable.ValueChanged += new VariableEventHandler(BRVariable_ValueChanged);
            }
            
            if (varHMI == null)
            {
                varHMI = new Variable(BRCpu, "HMI");
                varHMI.Active = true;
                varHMI.Connect();
                varHMI.ValueChanged += new VariableEventHandler(VarHMI_ValueChanged);
            }
            //HMI = new Variable(BRCpu, "count");
            //HMI.Connect();
            //HMI.ValueChanged += new VariableEventHandler(HMI_ValueChanged);
            //tmrReadPlc.Start();
        }

        private void BRVariable_ValueChanged(object sender, VariableEventArgs e)
        {
            Variable tmpVar = (Variable)sender;
            lblStatus.Text = tmpVar.Value.ToString();
        }

        private void VarHMI_ValueChanged(object sender, VariableEventArgs e)
        {
            Variable tmpVar = (Variable)sender;
            HMI.StartMachine = (bool)tmpVar.Value["StartMachine"];
            HMI.AxisX1Enabled = (bool)tmpVar.Value["AxisX1.Enabled"];
            MessageBox.Show(HMI.StartMachine.ToString() + HMI.AxisX1Enabled.ToString());
        }

        private void HMI_ValueChanged(object sender, VariableEventArgs e)
        {
            Variable tmpVar = (Variable)sender;
            MessageBox.Show(tmpVar.Value.ToString());
        }

        public struct T_Hmi
        {
            public bool StartMachine;
            public bool AxisX1Enabled;
        }
        T_Hmi HMI;
        
    }
}
