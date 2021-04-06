using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRCommTest
{
    public class ClassPlcVars
    {
        public T_Hmi HMI;

        public ClassPlcVars()
        {
            HMI.Axis = new T_HmiAxis[3];
        }

        public struct T_Hmi
        {
            public bool StartMachine;
            public T_HmiAxis[] Axis;
        }
        

        public struct T_HmiAxis
        {
            //from PLC
            public float ActPos;
            public bool Enabled;

            //to PLC
            public bool Reset;

            public bool JogPlus;
            public bool JogMinus;
            public double JogVelo;

            public double SetPos;
            public double SetVelo;
            public bool MoveSetPos;

        }


    }



}
