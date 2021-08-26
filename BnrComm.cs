using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BR.AN.PviServices;

namespace BRCommTest
{
    public class BnrComm
    {
        //Lreal
        bool ReadValDoneLreal;
        double ReadValLreal;
        BR.AN.PviServices.Variable BRPlcVarLreal;
        TaskCompletionSource<bool> tcsReadLreal = null;
        System.Windows.Forms.Timer tmrReadValToutLreal;

        bool WriteValDoneLreal;
        BR.AN.PviServices.Variable BRPlcVarWriteLreal;
        TaskCompletionSource<bool> tcsWriteLreal = null;
        System.Windows.Forms.Timer tmrWriteValToutLreal;
        
        //Bool
        bool ReadValDoneBool;
        bool ReadValBool;
        BR.AN.PviServices.Variable BRPlcVarBool;
        TaskCompletionSource<bool> tcsReadBool = null;
        System.Windows.Forms.Timer tmrReadValToutBool;

        bool WriteValDoneBool;
        BR.AN.PviServices.Variable BRPlcVarWriteBool;
        TaskCompletionSource<bool> tcsWriteBool = null;
        System.Windows.Forms.Timer tmrWriteValToutBool;

        //Uint;
        bool ReadValDoneUint;
        UInt16 ReadValUint;
        BR.AN.PviServices.Variable BRPlcVarUint;
        TaskCompletionSource<bool> tcsReadUint = null;
        System.Windows.Forms.Timer tmrReadValToutUint;

        bool WriteValDoneUint;
        BR.AN.PviServices.Variable BRPlcVarWriteUint;
        TaskCompletionSource<bool> tcsWriteUint = null;
        System.Windows.Forms.Timer tmrWriteValToutUint;

        ~BnrComm()
        {
            try
            {

                if (BRPlcVarLreal != null)
                    BRPlcVarLreal.Disconnect();
                if (tmrReadValToutLreal != null)
                    tmrReadValToutLreal.Stop();

            }
            catch
            { }
        }

        //----------------------------------------
        // varName
        //----------------------------------------
        private string delFirstDot(string varName)
        {
            if (varName.Substring(0, 1) == ".")
                varName = varName.Substring(1, varName.Length - 1);
            return varName;
        } 

        //----------------------------------------
        // LREAL okuma
        //----------------------------------------
        public async Task<(bool, double)> ReadLreal(BR.AN.PviServices.Cpu brCpu, string varName)
        {
            ReadValLreal = 0;
            ReadValDoneLreal = false;

            if (brCpu == null)
                return (ReadValDoneLreal, ReadValLreal);

            try
            {
                BRPlcVarLreal = new BR.AN.PviServices.Variable(brCpu, varName);
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
                BRPlcVarLreal = null;
            }

            return (ReadValDoneLreal, ReadValLreal);
        }

        private void BRPlcVarLreal_ValueRead(object sender, PviEventArgs e)
        {
            tmrReadValToutLreal.Stop();
            BR.AN.PviServices.Variable tmpVar = (BR.AN.PviServices.Variable)sender;
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
        // LREAL yazma
        //----------------------------------------
        public async Task<bool>WriteLreal(BR.AN.PviServices.Cpu brCpu, string varName, double val)
        {
            WriteValDoneLreal = false;

            if (brCpu == null)
                return WriteValDoneLreal;

            try
            {
                BRPlcVarWriteLreal = new BR.AN.PviServices.Variable(brCpu, varName);
                BRPlcVarWriteLreal.ValueWritten += new PviEventHandler(BRPlcVarWriteLreal_ValueWritten);
                BRPlcVarWriteLreal.Error += new PviEventHandler(BRPlcVarWriteLreal_Error);
                BRPlcVarWriteLreal.Value = val;
                BRPlcVarWriteLreal.WriteValue();
                BRPlcVarWriteLreal.Connect();
            }
            catch
            {
                return WriteValDoneLreal;
            }

            tmrWriteValToutLreal = new System.Windows.Forms.Timer();
            tmrWriteValToutLreal.Tick += tmrWriteValToutLreal_tick;
            tmrWriteValToutLreal.Interval = 2000;
            tmrWriteValToutLreal.Start();

            tcsWriteLreal = new TaskCompletionSource<bool>();
            await tcsWriteLreal.Task;
            

            if (BRPlcVarWriteLreal != null)
            {
                BRPlcVarWriteLreal.Disconnect();
                BRPlcVarWriteLreal.Dispose();
                BRPlcVarWriteLreal = null;
            }

            return WriteValDoneLreal;
        }

        private void BRPlcVarWriteLreal_ValueWritten(object sender, PviEventArgs e)
        {
            tmrWriteValToutLreal.Stop();
            WriteValDoneLreal = true;
            tcsWriteLreal?.TrySetResult(true);
        }

        private void BRPlcVarWriteLreal_Error(object sender, PviEventArgs e)
        {
            tmrWriteValToutLreal.Stop();
            tcsWriteLreal?.TrySetResult(true);
        }

        private void tmrWriteValToutLreal_tick(object sender, EventArgs e)
        {
            tmrWriteValToutLreal.Stop();
            tcsWriteLreal?.TrySetResult(true);
        }


        //----------------------------------------
        // BOOL okuma
        //----------------------------------------
        public async Task<(bool, bool)> ReadBool(BR.AN.PviServices.Cpu brCpu, string varName)
        {
            ReadValBool = false;
            ReadValDoneBool = false;

            if (brCpu == null)
                return (ReadValDoneBool, ReadValBool);

            try
            {
                BRPlcVarBool = new BR.AN.PviServices.Variable(brCpu, varName);
                BRPlcVarBool.ValueRead += new PviEventHandler(BRPlcVarBool_ValueRead);
                BRPlcVarBool.Error += new PviEventHandler(BRPlcVarBool_Error);
                BRPlcVarBool.ReadValue();
                BRPlcVarBool.Connect();
            }
            catch
            {
                return (ReadValDoneBool, ReadValBool);
            }

            tmrReadValToutBool = new System.Windows.Forms.Timer();
            tmrReadValToutBool.Tick += tmrReadValToutBool_tick;
            tmrReadValToutBool.Interval = 2000;
            tmrReadValToutBool.Start();

            tcsReadBool = new TaskCompletionSource<bool>();
            await tcsReadBool.Task;

            if (BRPlcVarBool != null)
            {
                BRPlcVarBool.Disconnect();
                BRPlcVarBool.Dispose();
                BRPlcVarBool = null;
            }

            return (ReadValDoneBool, ReadValBool);
        }

        private void BRPlcVarBool_ValueRead(object sender, PviEventArgs e)
        {
            tmrReadValToutBool.Stop();
            BR.AN.PviServices.Variable tmpVar = (BR.AN.PviServices.Variable)sender;
            ReadValBool = tmpVar.Value;
            ReadValDoneBool = true;
            tcsReadBool?.TrySetResult(true);
        }

        private void BRPlcVarBool_Error(object sender, PviEventArgs e)
        {
            tmrReadValToutBool.Stop();
            tcsReadBool?.TrySetResult(true);
        }

        private void tmrReadValToutBool_tick(object sender, EventArgs e)
        {
            tmrReadValToutBool.Stop();
            tcsReadBool?.TrySetResult(true);
        }

        //----------------------------------------
        // BOOL yazma
        //----------------------------------------
        public async Task<bool> WriteBool(BR.AN.PviServices.Cpu brCpu, string varName, bool val)
        {
            WriteValDoneBool = false;

            if (brCpu == null)
                return WriteValDoneBool;

            try
            {
                BRPlcVarWriteBool = new BR.AN.PviServices.Variable(brCpu, varName);
                BRPlcVarWriteBool.ValueWritten += new PviEventHandler(BRPlcVarWriteBool_ValueWritten);
                BRPlcVarWriteBool.Error += new PviEventHandler(BRPlcVarWriteBool_Error);
                BRPlcVarWriteBool.Value = val;
                BRPlcVarWriteBool.WriteValue();
                BRPlcVarWriteBool.Connect();
            }
            catch
            {
                return WriteValDoneBool;
            }

            tmrWriteValToutBool = new System.Windows.Forms.Timer();
            tmrWriteValToutBool.Tick += tmrWriteValToutBool_tick;
            tmrWriteValToutBool.Interval = 2000;
            tmrWriteValToutBool.Start();

            tcsWriteBool = new TaskCompletionSource<bool>();
            await tcsWriteBool.Task;

            if (BRPlcVarWriteBool != null)
            {
                BRPlcVarWriteBool.Disconnect();
                BRPlcVarWriteBool.Dispose();
                BRPlcVarWriteBool = null;
            }

            return WriteValDoneBool;
        }

        private void BRPlcVarWriteBool_ValueWritten(object sender, PviEventArgs e)
        {
            tmrWriteValToutBool.Stop();
            WriteValDoneBool = true;
            tcsWriteBool?.TrySetResult(true);
        }

        private void BRPlcVarWriteBool_Error(object sender, PviEventArgs e)
        {
            tmrWriteValToutBool.Stop();
            tcsWriteBool?.TrySetResult(true);
        }

        private void tmrWriteValToutBool_tick(object sender, EventArgs e)
        {
            tmrWriteValToutBool.Stop();
            tcsWriteBool?.TrySetResult(true);
        }


        //----------------------------------------
        // UINT okuma
        //----------------------------------------
        public async Task<(bool, UInt16)> ReadUint(BR.AN.PviServices.Cpu brCpu, string varName)
        {
            ReadValUint = 0;
            ReadValDoneUint = false;

            if (brCpu == null)
                return (ReadValDoneUint, ReadValUint);

            try
            {
                BRPlcVarUint = new BR.AN.PviServices.Variable(brCpu, varName);
                BRPlcVarUint.ValueRead += new PviEventHandler(BRPlcVarUint_ValueRead);
                BRPlcVarUint.Error += new PviEventHandler(BRPlcVarUint_Error);
                BRPlcVarUint.ReadValue();
                BRPlcVarUint.Connect();
            }
            catch
            {
                return (ReadValDoneUint, ReadValUint);
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
                BRPlcVarUint = null;
            }

            return (ReadValDoneUint, ReadValUint);
        }

        private void BRPlcVarUint_ValueRead(object sender, PviEventArgs e)
        {
            tmrReadValToutUint.Stop();
            BR.AN.PviServices.Variable tmpVar = (BR.AN.PviServices.Variable)sender;
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
        // UINT yazma
        //----------------------------------------
        public async Task<bool> WriteUint(BR.AN.PviServices.Cpu brCpu, string varName, UInt16 val)
        {
            WriteValDoneUint = false;

            if (brCpu == null)
                return WriteValDoneUint;

            try
            {
                BRPlcVarWriteUint = new BR.AN.PviServices.Variable(brCpu, varName);
                BRPlcVarWriteUint.ValueWritten += new PviEventHandler(BRPlcVarWriteUint_ValueWritten);
                BRPlcVarWriteUint.Error += new PviEventHandler(BRPlcVarWriteUint_Error);
                BRPlcVarWriteUint.Value = val;
                BRPlcVarWriteUint.WriteValue();
                BRPlcVarWriteUint.Connect();
            }
            catch
            {
                return WriteValDoneUint;
            }

            tmrWriteValToutUint = new System.Windows.Forms.Timer();
            tmrWriteValToutUint.Tick += tmrWriteValToutUint_tick;
            tmrWriteValToutUint.Interval = 2000;
            tmrWriteValToutUint.Start();

            tcsWriteUint = new TaskCompletionSource<bool>();
            await tcsWriteUint.Task;

            if (BRPlcVarWriteUint != null)
            {
                BRPlcVarWriteUint.Disconnect();
                BRPlcVarWriteUint.Dispose();
                BRPlcVarWriteUint = null;
            }

            return WriteValDoneUint;
        }

        private void BRPlcVarWriteUint_ValueWritten(object sender, PviEventArgs e)
        {
            tmrWriteValToutUint.Stop();
            WriteValDoneUint = true;
            tcsWriteUint?.TrySetResult(true);
        }

        private void BRPlcVarWriteUint_Error(object sender, PviEventArgs e)
        {
            tmrWriteValToutUint.Stop();
            tcsWriteUint?.TrySetResult(true);
        }

        private void tmrWriteValToutUint_tick(object sender, EventArgs e)
        {
            tmrWriteValToutUint.Stop();
            tcsWriteUint?.TrySetResult(true);
        }


        //Array Bool
        bool ReadValDoneArrayBool;
        bool[] ReadValArrayBool;
        BR.AN.PviServices.Variable BRPlcVarArrayBool;
        TaskCompletionSource<bool> tcsReadArrayBool = null;
        System.Windows.Forms.Timer tmrReadValToutArrayBool;
        //----------------------------------------
        // BOOL ARRAY okuma
        //----------------------------------------
        public async Task<(bool, bool[])> ReadBoolArray(BR.AN.PviServices.Cpu brCpu, string varName, uint cnt)
        {
            ReadValArrayBool = new bool[cnt];
            ReadValDoneArrayBool = false;

            if (brCpu == null)
                return (ReadValDoneArrayBool, ReadValArrayBool);

            try
            {
                BRPlcVarArrayBool = new BR.AN.PviServices.Variable(brCpu, varName);
                BRPlcVarArrayBool.ValueRead += new PviEventHandler(BRPlcVarArrayBool_ValueRead);
                BRPlcVarArrayBool.Error += new PviEventHandler(BRPlcVarArrayBool_Error);
                BRPlcVarArrayBool.ReadValue();
                BRPlcVarArrayBool.Connect();
            }
            catch
            {
                return (ReadValDoneArrayBool, ReadValArrayBool);
            }

            tmrReadValToutArrayBool = new System.Windows.Forms.Timer();
            tmrReadValToutArrayBool.Tick += tmrReadValToutArrayBool_tick;
            tmrReadValToutArrayBool.Interval = 2000;
            tmrReadValToutArrayBool.Start();

            tcsReadArrayBool = new TaskCompletionSource<bool>();
            await tcsReadArrayBool.Task;

            if (BRPlcVarArrayBool != null)
            {
                BRPlcVarArrayBool.Disconnect();
                BRPlcVarArrayBool.Dispose();
                BRPlcVarArrayBool = null;
            }

            return (ReadValDoneArrayBool, ReadValArrayBool);
        }

        private void BRPlcVarArrayBool_ValueRead(object sender, PviEventArgs e)
        {
            tmrReadValToutArrayBool.Stop();
            BR.AN.PviServices.Variable tmpVar = (BR.AN.PviServices.Variable)sender;
            ReadValArrayBool = tmpVar.Value;
            ReadValDoneArrayBool = true;
            tcsReadArrayBool?.TrySetResult(true);
        }

        private void BRPlcVarArrayBool_Error(object sender, PviEventArgs e)
        {
            tmrReadValToutArrayBool.Stop();
            tcsReadArrayBool?.TrySetResult(true);
        }

        private void tmrReadValToutArrayBool_tick(object sender, EventArgs e)
        {
            tmrReadValToutArrayBool.Stop();
            tcsReadArrayBool?.TrySetResult(true);
        }


        //String
        bool ReadValDoneString;
        string ReadValString;
        BR.AN.PviServices.Variable BRPlcVarString;
        TaskCompletionSource<bool> tcsReadString = null;
        System.Windows.Forms.Timer tmrReadValToutString;
        //----------------------------------------
        // STRING okuma
        //----------------------------------------
        public async Task<(bool, string)> ReadString(BR.AN.PviServices.Cpu brCpu, string varName)
        {
            ReadValString = "";
            ReadValDoneString = false;

            if (brCpu == null)
                return (ReadValDoneString, ReadValString);

            try
            {
                BRPlcVarString = new BR.AN.PviServices.Variable(brCpu, varName);
                BRPlcVarString.ValueRead += new PviEventHandler(BRPlcVarString_ValueRead);
                BRPlcVarString.Error += new PviEventHandler(BRPlcVarString_Error);
                BRPlcVarString.ReadValue();
                BRPlcVarString.Connect();
            }
            catch
            {
                return (ReadValDoneString, ReadValString);
            }

            tmrReadValToutString = new System.Windows.Forms.Timer();
            tmrReadValToutString.Tick += tmrReadValToutString_tick;
            tmrReadValToutString.Interval = 2000;
            tmrReadValToutString.Start();

            tcsReadString = new TaskCompletionSource<bool>();
            await tcsReadString.Task;

            if (BRPlcVarString != null)
            {
                BRPlcVarString.Disconnect();
                BRPlcVarString.Dispose();
                BRPlcVarString = null;
            }

            return (ReadValDoneString, ReadValString);
        }

        private void BRPlcVarString_ValueRead(object sender, PviEventArgs e)
        {
            tmrReadValToutString.Stop();
            BR.AN.PviServices.Variable tmpVar = (BR.AN.PviServices.Variable)sender;
            ReadValString = tmpVar.Value;
            ReadValDoneString = true;
            tcsReadString?.TrySetResult(true);
        }

        private void BRPlcVarString_Error(object sender, PviEventArgs e)
        {
            tmrReadValToutString.Stop();
            tcsReadString?.TrySetResult(true);
        }

        private void tmrReadValToutString_tick(object sender, EventArgs e)
        {
            tmrReadValToutString.Stop();
            tcsReadString?.TrySetResult(true);
        }




        //----------------------------------------
        // STRING yazma
        //----------------------------------------
        //String
        bool WriteValDoneString;
        BR.AN.PviServices.Variable BRPlcVarWriteString;
        TaskCompletionSource<bool> tcsWriteString = null;
        System.Windows.Forms.Timer tmrWriteValToutString;

        public async Task<bool> WriteString(BR.AN.PviServices.Cpu brCpu, string varName, string val)
        {
            WriteValDoneString = false;

            if (brCpu == null)
                return WriteValDoneString;

            try
            {
                BRPlcVarWriteString = new BR.AN.PviServices.Variable(brCpu, varName);
                BRPlcVarWriteString.ValueWritten += new PviEventHandler(BRPlcVarWriteString_ValueWritten);
                BRPlcVarWriteString.Error += new PviEventHandler(BRPlcVarWriteString_Error);
                BRPlcVarWriteString.Value = val;
                BRPlcVarWriteString.WriteValue();
                BRPlcVarWriteString.Connect();
            }
            catch
            {
                return WriteValDoneString;
            }

            tmrWriteValToutString = new System.Windows.Forms.Timer();
            tmrWriteValToutString.Tick += tmrWriteValToutString_tick;
            tmrWriteValToutString.Interval = 2000;
            tmrWriteValToutString.Start();

            tcsWriteString = new TaskCompletionSource<bool>();
            await tcsWriteString.Task;

            if (BRPlcVarWriteString != null)
            {
                BRPlcVarWriteString.Disconnect();
                BRPlcVarWriteString.Dispose();
                BRPlcVarWriteString = null;
            }

            return WriteValDoneString;
        }

        private void BRPlcVarWriteString_ValueWritten(object sender, PviEventArgs e)
        {
            tmrWriteValToutString.Stop();
            WriteValDoneString = true;
            tcsWriteString?.TrySetResult(true);
        }

        private void BRPlcVarWriteString_Error(object sender, PviEventArgs e)
        {
            tmrWriteValToutString.Stop();
            tcsWriteString?.TrySetResult(true);
        }

        private void tmrWriteValToutString_tick(object sender, EventArgs e)
        {
            tmrWriteValToutString.Stop();
            tcsWriteString?.TrySetResult(true);
        }

    }
}
