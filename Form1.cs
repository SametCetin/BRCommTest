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
using Task = System.Threading.Tasks.Task;

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
            BnrComm br = new BnrComm();
            var val = await br.ReadLreal(PlcComm.BRCpu, "HMI.Axis[0].ActPos");
            txtActPosAxisX1.Text = val.Item2.ToString();
            tmrVisuUpdate.Start();
        }

        private async void btnJogPlusX1_MouseDown(object sender, MouseEventArgs e)
        {

            BnrComm br1 = new BnrComm();
            var val = await br1.WriteUint(PlcComm.BRCpu, "HMI.Axis[0].JogVelo", Convert.ToUInt16(txtMoveVeloAxisX1.Text));

            BnrComm br2 = new BnrComm();
            await br2.WriteBool(PlcComm.BRCpu, "HMI.Axis[0].JogPlus", true);
        }

        private async void btnJogPlusX1_MouseUp(object sender, MouseEventArgs e)
        {
            BnrComm br2 = new BnrComm();
            await br2.WriteBool(PlcComm.BRCpu, "HMI.Axis[0].JogPlus", false);
        }

        private async void btnJogMinAxisX1_MouseDown(object sender, MouseEventArgs e)
        {
            BnrComm br1 = new BnrComm();
            var val = await br1.WriteUint(PlcComm.BRCpu, "HMI.Axis[0].JogVelo", Convert.ToUInt16(txtMoveVeloAxisX1.Text));

            BnrComm br2 = new BnrComm();
            await br2.WriteBool(PlcComm.BRCpu, "HMI.Axis[0].JogMinus", true);
        }

        private async void btnJogMinAxisX1_MouseUp(object sender, MouseEventArgs e)
        {
            BnrComm br2 = new BnrComm();
            await br2.WriteBool(PlcComm.BRCpu, "HMI.Axis[0].JogMinus", false);
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

        private async void button1_Click(object sender, EventArgs e)
        {
            BnrComm br = new BnrComm();
            var val = await br.ReadString(PlcComm.BRCpu, "strvar1");
            //var val = await br.ReadBoolArray(PlcComm.BRCpu, "Alarm", 201);

            MessageBox.Show(val.Item2);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            BnrComm br = new BnrComm();
            var val = await br.WriteString(PlcComm.BRCpu, "strvar1", textBox1.Text);
            //MessageBox.Show(delFirstDot(textBox1.Text));   
        }

        private string delFirstDot(string varName)
        {
            if (varName.Substring(0, 1) == ".")
                varName = varName.Substring(1, varName.Length - 1);
            return varName;
        }

        private async Task<bool> TestTask()
        {

            return true;
        }
        private void btnStructReader_Click(object sender, EventArgs e)
        {
            tmrWaitFormLoad.Interval = 100;
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
                tmrVisuUpdate2.Start();
            }
            else
                lblStatus.Text = "Plc not connected";
        }

        private void ConnectToPlc()
        {
            PlcComm.ConnectToPvi("127.0.0.1");
        }

        private async void tmrVisuUpdate2_Tick(object sender, EventArgs e)
        {
            tmrVisuUpdate2.Stop();

            BnrComm br = new BnrComm();
            var val = await br.ReadLreal(PlcComm.BRCpu, "HMI.Axis[1].ActPos");
            //var val = await PlcComm.ReadLreal("HMI.Axis[1].ActPos");
            txtActPosAxisZ1.Text = val.Item2.ToString();
            tmrVisuUpdate2.Start();
        }

        private async void btnJogMinusZ1_MouseDown(object sender, MouseEventArgs e)
        {
            BnrComm br1 = new BnrComm();
            var val = await br1.WriteUint(PlcComm.BRCpu, "HMI.Axis[1].JogVelo", Convert.ToUInt16(txtMoveVeloAxisZ1.Text));

            BnrComm br2 = new BnrComm();
            await br2.WriteBool(PlcComm.BRCpu, "HMI.Axis[1].JogMinus", true);

        }

        private async void btnJogMinusZ1_MouseUp(object sender, MouseEventArgs e)
        {
            BnrComm br2 = new BnrComm();
            await br2.WriteBool(PlcComm.BRCpu, "HMI.Axis[1].JogMinus", false);
        }

        private async void btnJogPlusZ1_MouseDown(object sender, MouseEventArgs e)
        {
            BnrComm br1 = new BnrComm();
            var val = await br1.WriteUint(PlcComm.BRCpu, "HMI.Axis[1].JogVelo", Convert.ToUInt16(txtMoveVeloAxisZ1.Text));

            BnrComm br2 = new BnrComm();
            await br2.WriteBool(PlcComm.BRCpu, "HMI.Axis[1].JogPlus", true);
        }

        private async void btnJogPlusZ1_MouseUp(object sender, MouseEventArgs e)
        {
            BnrComm br2 = new BnrComm();
            await br2.WriteBool(PlcComm.BRCpu, "HMI.Axis[1].JogPlus", false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool[] arr1 = new bool[200];
            bool[] arr2 = new bool[200];

            for(int i=0;i<10;i++)
            {
                arr1[i] = true;
            }

            for (int i=0;i<arr2.Length-1;i++)
            {
                    arr2[i+1] = arr1[i];
            }
           
            MessageBox.Show("done");
        }
    }
}
