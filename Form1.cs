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

        ClassPlcVars PLC;
        ClassBuRPlcComm BuRPlcComm;

        public Form1()
        {
            InitializeComponent();
            PLC = new ClassPlcVars();
            BuRPlcComm = new ClassBuRPlcComm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //tmrWaitFormLoad.Start();
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
            tmrReadPlcVal.Start();
            //if (varHMI == null)
            //{
            //    varHMI = new Variable(BRCpu, "HMI");
            //    varHMI.Active = true;
            //    varHMI.Connect();
            //    varHMI.ValueChanged += new VariableEventHandler(HMI_ValueChanged);
            //}
            //tmrAssignToPlc.Start();
        }

       
        private void HMI_ValueChanged(object sender, VariableEventArgs e)
        {
            //varHMI.Active = false;
            Variable tmpVar = (Variable)sender;
            txtActPosAxisX1.Text = (string)tmpVar.Value["Axis[1].ActPos"];
            //HMI.StartMachine = (bool)tmpVar.Value["StartMachine"]; //HMI.StartMachine
            //HMI.AxisX1Enabled = (bool)tmpVar.Value["AxisX1.Enabled"]; //HMI.AxisX1.Enabled
            //MessageBox.Show(HMI.StartMachine.ToString() + HMI.AxisX1Enabled.ToString());

        }

        

        private void tmrAssignToPlc_Tick(object sender, EventArgs e)
        {
            tmrAssignToPlc.Stop();

            varHMI.Value["Axis[0].JogPlus"] = PLC.HMI.Axis[1].JogPlus;

            tmrAssignToPlc.Start();
        }

        private void tmrReadPlcVal_Tick(object sender, EventArgs e)
        {
            tmrReadPlcVal.Stop();

            if (varHMI == null)
            {
                varHMI = new Variable(BRCpu, "HMI");
                varHMI.ValueRead += new PviEventHandler(VarHMI_ValueRead);
                varHMI.WriteValueAutomatic = false;
            }
            varHMI.ReadValue();
            varHMI.Connect();
        }

        private void VarHMI_ValueRead(object sender, PviEventArgs e)
        {
            Variable tmpVar = (Variable)sender;
            try
            {
                PLC.HMI.Axis[0].ActPos = (float)tmpVar.Value["Axis[0].ActPos"];
                PLC.HMI.Axis[0].Enabled = (bool)tmpVar.Value["Axis[0].Enabled"];
            }
            catch
            { }

            txtActPosAxisX1.Text = PLC.HMI.Axis[0].ActPos.ToString();
            chkEnabledAxisX1.Checked = PLC.HMI.Axis[0].Enabled;

            try
            {
                tmpVar.Value["Axis[0].Reset"] = PLC.HMI.Axis[0].Reset;
                tmpVar.Value["Axis[0].JogPlus"] = PLC.HMI.Axis[0].JogPlus;
                tmpVar.Value["Axis[0].JogMinus"] = PLC.HMI.Axis[0].JogMinus;
                tmpVar.Value["Axis[0].JogVelo"] = PLC.HMI.Axis[0].JogVelo;
                tmpVar.Value["Axis[0].SetPos"] = PLC.HMI.Axis[0].SetPos;
                tmpVar.Value["Axis[0].SetVelo"] = PLC.HMI.Axis[0].SetVelo;
                tmpVar.Value["Axis[0].MoveSetPos"] = PLC.HMI.Axis[0].MoveSetPos;

                varHMI.WriteValue();
            }
            catch
            { }

            tmrReadPlcVal.Start();
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varHMI != null && varHMI.IsConnected)
                    varHMI.Disconnect();
                if (BRCpu != null && BRCpu.IsConnected)
                    BRCpu.Disconnect();
                if (BRService != null && BRService.IsConnected)
                    BRService.Disconnect();
            }
            catch
            {}

        }

        private void btnMovePosAxisX1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnJogPlusX1_MouseDown(object sender, MouseEventArgs e)
        {
            PLC.HMI.Axis[0].JogVelo = Convert.ToDouble(txtMoveVeloAxisX1.Text);
            PLC.HMI.Axis[0].JogPlus = PLC.HMI.Axis[0].Enabled;
        }

        private void btnJogPlusX1_MouseUp(object sender, MouseEventArgs e)
        {
            PLC.HMI.Axis[0].JogVelo = Convert.ToDouble(txtMoveVeloAxisX1.Text);
            PLC.HMI.Axis[0].JogPlus = false;
        }

        private void btnJogMinAxisX1_MouseDown(object sender, MouseEventArgs e)
        {
            PLC.HMI.Axis[0].JogVelo = Convert.ToDouble(txtMoveVeloAxisX1.Text);
            PLC.HMI.Axis[0].JogMinus = PLC.HMI.Axis[0].Enabled;
        }

        private void btnJogMinAxisX1_MouseUp(object sender, MouseEventArgs e)
        {
            PLC.HMI.Axis[0].JogVelo = Convert.ToDouble(txtMoveVeloAxisX1.Text);
            PLC.HMI.Axis[0].JogMinus = false;
        }

        private void btnResetAxisX1_MouseDown(object sender, MouseEventArgs e)
        {
            PLC.HMI.Axis[0].Reset = true;
        }

        private void btnResetAxisX1_MouseUp(object sender, MouseEventArgs e)
        {
            PLC.HMI.Axis[0].Reset = false;
        }

        private void btnMovePosAxisX1_MouseDown(object sender, MouseEventArgs e)
        {
            PLC.HMI.Axis[0].SetVelo = Convert.ToDouble(txtMoveVeloAxisX1.Text);
            PLC.HMI.Axis[0].SetPos = Convert.ToDouble(txtGoToPosAxisX1.Text);
            PLC.HMI.Axis[0].MoveSetPos = PLC.HMI.Axis[0].Enabled;
        }

        private void btnStopAxisX1_Click(object sender, EventArgs e)
        {
            PLC.HMI.Axis[0].MoveSetPos = false;
        }


    }
}
