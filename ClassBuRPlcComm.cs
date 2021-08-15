using BR.AN.PviServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace BRCommTest
{
    public class ClassBuRPlcComm
    {
        bool ReadValDoneUint;
        UInt16 ReadValUint;
        BR.AN.PviServices.Variable BRPlcVarUint;
        TaskCompletionSource<bool> tcsReadUint = null;
        System.Windows.Forms.Timer tmrReadValToutUint;

        bool ReadValDoneLreal;
        double ReadValLreal;
        BR.AN.PviServices.Variable BRPlcVarLreal;
        TaskCompletionSource<bool> tcsReadLreal = null;
        System.Windows.Forms.Timer tmrReadValToutLreal;


        System.Windows.Forms.Timer tmrConnectPviTimeOut;
        System.Windows.Forms.Timer tmrWriteToPlcTimeOut;

        bool WaitConnectToPvi;
        bool ConnectToPviDone;

        bool WaitWriteToPlc;
        bool WriteToPlcDone;
        
        string DestAddress = "127.0.0.1";
        string PlcVarVal = "";

        BR.AN.PviServices.Service BRService;
        BR.AN.PviServices.Cpu BRCpu;
        
        BR.AN.PviServices.Variable BRPlcVarWr;

        public ClassBuRPlcComm()
        {
        }

        ~ClassBuRPlcComm()
        {
            try
            {
                if (BRPlcVarUint != null)
                    BRPlcVarUint.Disconnect();
                if (tmrReadValToutUint != null)
                    tmrReadValToutUint.Stop();

                if (BRPlcVarLreal != null)
                    BRPlcVarLreal.Disconnect();
                if (tmrReadValToutLreal != null)
                    tmrReadValToutUint.Stop();

                if (BRPlcVarWr != null)
                    BRPlcVarWr.Disconnect();
                if (BRCpu != null)
                    BRCpu.Disconnect();
                if (BRService != null)
                    BRService.Disconnect();


            }
            catch
            { }
        }

        public bool ConnectToPvi(string destAddress)
        {
            tmrConnectPviTimeOut = new System.Windows.Forms.Timer();
            tmrConnectPviTimeOut.Tick += tmrConnectPviTimeOut_Tick;
            tmrConnectPviTimeOut.Interval = 8000;
            tmrConnectPviTimeOut.Start();

            DestAddress = destAddress;
            ConnectToService();

            WaitConnectToPvi = true;
            while (WaitConnectToPvi)
            {
                Thread.Sleep(10);
                System.Windows.Forms.Application.DoEvents();
            }

            tmrConnectPviTimeOut.Stop();

            return ConnectToPviDone;

        }

        private void tmrConnectPviTimeOut_Tick(object sender, EventArgs e)
        {
            WaitConnectToPvi = false;
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
            ConnectToPviDone = true;
            WaitConnectToPvi = false;
        }

        public bool CheckConnection()
        {
            if (BRCpu == null)
                return false;

            return BRCpu.IsConnected;
        }

        //----------------------------------------
        // UINT okuma
        //----------------------------------------
        public async System.Threading.Tasks.Task<(bool, UInt16)> ReadUint(string VarName)
        {
            ReadValUint = 0;
            ReadValDoneUint = false;

            if (BRCpu == null)
                return (false, ReadValUint);

            try
            {
                BRPlcVarUint = new Variable(BRCpu, VarName);
                BRPlcVarUint.ValueRead += new PviEventHandler(BRPlcVarUint_ValueRead);
                BRPlcVarUint.Error += new PviEventHandler(BRPlcVarUint_Error);
                BRPlcVarUint.ReadValue();
                BRPlcVarUint.Connect();
            }
            catch
            {
                return (false, ReadValUint);
            }

            tmrReadValToutUint = new System.Windows.Forms.Timer();
            tmrReadValToutUint.Tick += tmrReadValToutUint_tick;
            tmrReadValToutUint.Interval = 2000;
            tmrReadValToutUint.Start();

            tcsReadUint = new TaskCompletionSource<bool>();
            await tcsReadUint.Task;

            if (BRPlcVarUint != null)
            {
                BRPlcVarUint.Disconnect();
                BRPlcVarUint.Dispose();
            }
            BRPlcVarUint = null;

            return (ReadValDoneUint, ReadValUint);
        }

        private void BRPlcVarUint_ValueRead(object sender, PviEventArgs e)
        {
            tmrReadValToutUint.Stop();
            Variable tmpVar = (Variable)sender;
            ReadValUint = tmpVar.Value;
            ReadValDoneUint = true;
            tcsReadUint?.TrySetResult(true);
        }

        private void BRPlcVarUint_Error(object sender, PviEventArgs e)
        {
            tmrReadValToutUint.Stop();
            tcsReadUint?.TrySetResult(true);
        }

        private void tmrReadValToutUint_tick(object sender, EventArgs e)
        {
            tmrReadValToutUint.Stop();
            tcsReadUint?.TrySetResult(true);
        }

        //----------------------------------------
        // LREAL okuma
        //----------------------------------------
        public async System.Threading.Tasks.Task<(bool, Double)> ReadLreal(string VarName)
        {
            ReadValLreal = 0;
            ReadValDoneLreal = false;

            if (BRCpu == null)
                return (ReadValDoneLreal, ReadValLreal);

            try
            {
                BRPlcVarLreal = new Variable(BRCpu, VarName);
                BRPlcVarLreal.ValueRead += new PviEventHandler(BRPlcVarLreal_ValueRead);
                BRPlcVarLreal.Error += new PviEventHandler(BRPlcVarLreal_Error);
                BRPlcVarLreal.ReadValue();
                BRPlcVarLreal.Connect();
            }
            catch
            {
                return (ReadValDoneLreal, ReadValLreal);
            }

            tmrReadValToutLreal = new System.Windows.Forms.Timer();
            tmrReadValToutLreal.Tick += tmrReadValToutLreal_tick;
            tmrReadValToutLreal.Interval = 2000;
            tmrReadValToutLreal.Start();

            tcsReadLreal = new TaskCompletionSource<bool>();
            await tcsReadLreal.Task;

            if (BRPlcVarLreal != null)
            {
                BRPlcVarLreal.Disconnect();
                BRPlcVarLreal.Dispose();
            }
            BRPlcVarLreal = null;

            return (ReadValDoneLreal, ReadValLreal);
        }

        private void BRPlcVarLreal_ValueRead(object sender, PviEventArgs e)
        {
            tmrReadValToutLreal.Stop();
            Variable tmpVar = (Variable)sender;
            ReadValLreal = tmpVar.Value;
            ReadValDoneLreal = true;
            tcsReadLreal?.TrySetResult(true);
        }

        private void BRPlcVarLreal_Error(object sender, PviEventArgs e)
        {
            tmrReadValToutLreal.Stop();
            tcsReadLreal?.TrySetResult(true);
        }

        private void tmrReadValToutLreal_tick(object sender, EventArgs e)
        {
            tmrReadValToutLreal.Stop();
            tcsReadLreal?.TrySetResult(true);
        }
        //----------------------------------------
        // LREAL okuma
        //----------------------------------------
        //public async System.Threading.Tasks.Task<(bool, double)> ReadLreal(string VarName)
        //{
        //    PlcVarVal = "0";
        //    double readVal = 0;
        //    if (BRCpu == null)
        //    {
        //        return readVal;
        //    }
        //    setupVariable(VarName);
        //    tcs = new TaskCompletionSource<bool>();
        //    await tcs.Task;
        //    readVal = Convert.ToDouble(PlcVarVal);
        //    disconnectVariable();
        //    return readVal;
        //}
        //-------------------------------------------

        private void setupVariableWr(string VarName)
        {
            try
            {
                tmrWriteToPlcTimeOut = new System.Windows.Forms.Timer();
                tmrWriteToPlcTimeOut.Tick += tmrWriteToPlcTimeOut_tick;
                tmrWriteToPlcTimeOut.Interval = 2000;
                tmrWriteToPlcTimeOut.Start();

                BRPlcVarWr = new Variable(BRCpu, VarName);
                BRPlcVarWr.ValueWritten += new PviEventHandler(BRPlcVarWr_ValueWritten);
                BRPlcVarWr.Error += new PviEventHandler(BRPlcVarWr_Error);
                BRPlcVarWr.ReadValue();
                BRPlcVarWr.Connect();

                WriteToPlcDone = false;
                WaitWriteToPlc = true;
            }
            catch
            {

            }
        }

        private void disconnectVariableWr()
        {
            tmrWriteToPlcTimeOut.Stop();

            BRPlcVarWr.Disconnect();
            BRPlcVarWr.Dispose();
            BRPlcVarWr = null;
        }

        public bool Write(string varName)
        {
            if (BRCpu == null || BRPlcVarWr != null)
            {
                return false;
            }

            setupVariableWr(varName);

            BRPlcVarWr.WriteValue();

            while (WaitWriteToPlc)
            {
                Thread.Sleep(10);
                //System.Windows.Forms.Application.DoEvents();
            }

            disconnectVariableWr();

            return WriteToPlcDone;
        }

        private void BRPlcVarWr_ValueWritten(object sender, PviEventArgs e)
        {
            WriteToPlcDone = true;
            WaitWriteToPlc = false;
        }

        private void BRPlcVarWr_Error(object sender, PviEventArgs e)
        {
            WaitWriteToPlc = false;
        }

        private void tmrWriteToPlcTimeOut_tick(object sender, EventArgs e)
        {
            WaitWriteToPlc = false;
        }

    }
}
