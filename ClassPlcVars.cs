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
            public float ActPos;
            public bool Enabled;
            public bool JogPlus;
        }


    }



}
