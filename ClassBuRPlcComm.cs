using BR.AN.PviServices;
using System;
using System.Threading;


namespace BRCommTest
{
    public class ClassBuRPlcComm
    {
        public ClassPlcVars Vars; //Plc variables

        System.Windows.Forms.Timer tmrPlcSync;

        BR.AN.PviServices.Service BRService;
        BR.AN.PviServices.Cpu BRCpu;
        BR.AN.PviServices.Variable BRPlcVar;

        string DestAddress = "127.0.0.1";

        private void InitializeComponent()
        {
            tmrPlcSync = new System.Windows.Forms.Timer();
            tmrPlcSync.Interval = 100;
            tmrPlcSync.Tick += TmrPlcSync_Tick;

            Vars = new ClassPlcVars();
        }

        public ClassBuRPlcComm()
        {
            InitializeComponent();
        }

        ~ClassBuRPlcComm()
        {
            try
            {
                if (BRPlcVar != null && BRPlcVar.IsConnected)
                    BRPlcVar.Disconnect();
                if (BRCpu != null && BRCpu.IsConnected)
                    BRCpu.Disconnect();
                if (BRService != null && BRService.IsConnected)
                    BRService.Disconnect();
            }
            catch
            { }
        }
        
        public void ConnectToPvi(string destAddress)
        {
            DestAddress = destAddress;
            ConnectToService();
        }

        private void ConnectToService()
        {
            if (BRService == null)
            {
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
                BRCpu.Connection.ANSLTcp.DestinationIpAddress = DestAddress;
                BRCpu.Connected += new PviEventHandler(BRCpu_Connected);
            }
            BRCpu.Connect();
        }

        void BRCpu_Connected(object sender, PviEventArgs e)
        {
            tmrPlcSync.Start();
        }

        public bool CheckConnection()
        {
            if (BRPlcVar == null)
                return false;

            return BRPlcVar.IsConnected;
        }

        private void TmrPlcSync_Tick(object sender, EventArgs e)
        {
            tmrPlcSync.Stop();

            if (BRPlcVar == null)
            {
                BRPlcVar = new Variable(BRCpu, "HMI");
                BRPlcVar.ValueRead += new PviEventHandler(BRPlcVar_ValueRead);
                BRPlcVar.WriteValueAutomatic = false;
            }
            BRPlcVar.ReadValue();
            BRPlcVar.Connect();
        }

        private void BRPlcVar_ValueRead(object sender, PviEventArgs e)
        {
            Variable tmpVar = (Variable)sender;
            try
            {
                Vars.HMI.Axis[0].ActPos = (float)tmpVar.Value["Axis[0].ActPos"];
                Vars.HMI.Axis[0].Enabled = (bool)tmpVar.Value["Axis[0].Enabled"];
            }
            catch
            { }

            try
            {
                tmpVar.Value["Axis[0].Reset"] = Vars.HMI.Axis[0].Reset;
                tmpVar.Value["Axis[0].JogPlus"] = Vars.HMI.Axis[0].JogPlus;
                tmpVar.Value["Axis[0].JogMinus"] = Vars.HMI.Axis[0].JogMinus;
                tmpVar.Value["Axis[0].JogVelo"] = Vars.HMI.Axis[0].JogVelo;
                tmpVar.Value["Axis[0].SetPos"] = Vars.HMI.Axis[0].SetPos;
                tmpVar.Value["Axis[0].SetVelo"] = Vars.HMI.Axis[0].SetVelo;
                tmpVar.Value["Axis[0].MoveSetPos"] = Vars.HMI.Axis[0].MoveSetPos;

                BRPlcVar.WriteValue();
            }
            catch
            { }

            tmrPlcSync.Start();
        }

        private void Wait(int ms)
        {
            for (int i=0; i<ms; i++)
            {
                Thread.Sleep(1);
                System.Windows.Forms.Application.DoEvents();
            }
        }

    }
}
