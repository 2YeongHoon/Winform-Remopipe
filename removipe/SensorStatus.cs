using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace removipe
{
    public class SensorStatus
    {
        public SensorStatus()
        {
        }

        public SensorStatus(int no, bool solvalve, float presure)
        {
            this.no = no;
            this.solValve = solvalve;
            this.presureSensor = presure;

            this.name = string.Format("STAGE#{0}", no);   
        }
        int no;
        /// <summary>
        /// StageNo
        /// </summary>
        public int No
        {
            get { return no; }
            set { no = value; }
        }

        //2017/05/15
        string name = "";

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        bool solValve = false;
        /// <summary>
        /// SolValve
        /// </summary>
        public bool SolValve
        {
            get { return solValve; }
            set { solValve = value; }
        }

        float presureSensor;
        /// <summary>
        /// 차압센서 값
        /// </summary>
        public float PresureSensor
        {
            get { return presureSensor; }
            set { presureSensor = value; }
        }

        double flowSensor;
        /// <summary>
        /// 유량센서 값
        /// </summary>
        public double FlowSensor
        {
            get { return flowSensor; }
            set { flowSensor = value; }
        }

        double presureMax = 2;
        public double PresureMax
        {
            get { return presureMax; }
            set { presureMax = value; }
        }
        double presureMin = 0;
        /// <summary>
        /// 차압센서 (min) 내부계산용
        /// </summary>
        public double PresureMin
        {
            get { return presureMin; }
            set { presureMin = value; }
        }
        double presureSensorOffset;
        /// <summary>
        /// 
        /// </summary>
        public double PresureSensorOffset
        {
            get { return presureSensorOffset; }
            set { presureSensorOffset = value; }
        }

        int rawOffsetPresureMin = 0;
        public int RawOffsetPresureMin
        {
            get { return rawOffsetPresureMin; }
            set { rawOffsetPresureMin = value; }
        }

        int rawOffsetPresureMax = 4095;
        public int RawOffsetPresureMax
        {
            get { return rawOffsetPresureMax; }
            set { rawOffsetPresureMax = value; }
        }

        double presureSensorRate = 0;
        /// <summary>
        /// 계산된 Rate화면 출력용
        /// </summary>
        public double PresureSensorRate
        {
            get { return presureSensorRate; }
            set { presureSensorRate = value; }
        }

        int presureSensorRaw;

        public int PresureSensorRaw
        {
            get { return presureSensorRaw; }
            set { presureSensorRaw = value; }
        }

    }
}
