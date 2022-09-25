using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace removipe
{
    public class CommonSetting
    {
        public CommonSetting()
        {

        }
        public CommonSetting(
            bool valvePressOpen,
            float valvePressOpenValue, 
            int valvePressRepeatValue,
            int valvePressInterval,
            bool valveTimeOpen,
            int valveTimeOpenValue,
            int valveTimeRepeatValue,
            int valveTimeInterval,
            int valveInterval,
            int valvePressCount,
            bool simulatorMode)
        {
            this.valvePressOpen = valvePressOpen;
            this.valvePressOpenValue = valvePressOpenValue;
            this.valvePressRepeatValue = valvePressRepeatValue;
            this.valvePressInterval = valvePressInterval;
            this.valvePressCount = valvePressCount;

            this.valveTimeOpen = valveTimeOpen;
            this.valveTimeOpenValue = valveTimeOpenValue;
            this.valveTimeRepeatValue = valveTimeRepeatValue;
            this.valveTimeInterval = valveTimeInterval;

            this.valveInterval = valveInterval;
            this.simulatorMode = simulatorMode;
        }

        bool valveTimeOpen = false;
        /// <summary>
        /// valveTimeOpen
        /// </summary>
        public bool ValveTimeOpen
        {
            get { return valveTimeOpen; }
            set { valveTimeOpen = value; }
        }

        bool valvePressOpen = false;
        /// <summary>
        /// valvePressOpen
        /// </summary>
        public bool ValvePressOpen
        {
            get { return valvePressOpen; }
            set { valvePressOpen = value; }
        }

        float valvePressOpenValue = 5.0f;
        /// <summary>
        /// valvePressValue
        /// </summary>
        public float ValvePressOpenValue
        {
            get { return valvePressOpenValue; }
            set { valvePressOpenValue = value; }
        }

        int valvePressRepeatValue = 1;
        /// <summary>
        /// valveTimeValue
        /// </summary>
        public int ValvePressRepeatValue
        {
            get { return valvePressRepeatValue; }
            set { valvePressRepeatValue = value; }
        }

        int valvePressInterval = 500;
        /// <summary>
        /// valveRepeatValue
        /// </summary>
        public int ValvePressInterval
        {
            get { return valvePressInterval; }
            set { valvePressInterval = value; }
        }

        int valvePressCount = 5;
        /// <summary>
        /// ValvePressCount
        /// </summary>
        public int ValvePressCount
        {
            get { return valvePressCount; }
            set { valvePressCount = value; }
        }

        int valveTimeOpenValue = 0;
        /// <summary>
        /// valveMinInterval
        /// </summary>
        public int ValveTimeOpenValue
        {
            get { return valveTimeOpenValue; }
            set { valveTimeOpenValue = value; }
        }


        int valveTimeRepeatValue = 1;
        /// <summary>
        /// valveMinInterval
        /// </summary>
        public int ValveTimeRepeatValue
        {
            get { return valveTimeRepeatValue; }
            set { valveTimeRepeatValue = value; }
        }

        int valveTimeInterval = 500;
        /// <summary>
        /// valveMinInterval
        /// </summary>
        public int ValveTimeInterval
        {
            get { return valveTimeInterval; }
            set { valveTimeInterval = value; }
        }

        int valveInterval = 1000;
        /// <summary>
        /// valveMinInterval
        /// </summary>
        public int ValveInterval
        {
            get { return valveInterval; }
            set { valveInterval = value; }
        }


        bool simulatorMode = false;
        /// <summary>
        /// SimulatorMode
        /// </summary>
        public bool SimulatorMode
        {
            get { return simulatorMode; }
            set { simulatorMode = value; }
        }

    }
}
