using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BR.AN.PviServices;


namespace BRCommTest
{
    class ClassBuRPlcComm
    {
        System.Windows.Forms.Timer tmrWaitFornConn;
        System.Windows.Forms.Timer tmrPlcSync;

        BR.AN.PviServices.Service BRService;
        BR.AN.PviServices.Cpu BRCpu;

        private void InitializeComponent()
        {
            tmrWaitFornConn = new System.Windows.Forms.Timer();
            tmrWaitFornConn.Interval = 3000;
            tmrWaitFornConn.Tick += TmrWaitFornConn_Tick;

            tmrPlcSync = new System.Windows.Forms.Timer();
            tmrPlcSync.Interval = 100;
            tmrPlcSync.Tick += TmrPlcSync_Tick;
        }

        

        public ClassBuRPlcComm()
        {
            InitializeComponent();
            tmrWaitFornConn.Start();

        }

        ~ClassBuRPlcComm()
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
            { }
        }

        private void TmrWaitFornConn_Tick(object sender, EventArgs e)
        {
            tmrWaitFornConn.Stop();
            ConnectToPvi();
        }

        void ConnectToPvi()
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
                BRCpu.Connection.ANSLTcp.DestinationIpAddress = "127.0.0.1";
                BRCpu.Connected += new PviEventHandler(BRCpu_Connected);
            }
            BRCpu.Connect();
        }

        void BRCpu_Connected(object sender, PviEventArgs e)
        {
            tmrPlcSync.Start();
        }

        private void TmrPlcSync_Tick(object sender, EventArgs e)
        {
            tmrPlcSync.Stop();
            System.Windows.Forms.MessageBox.Show("timerSync");
        }

    }
}
