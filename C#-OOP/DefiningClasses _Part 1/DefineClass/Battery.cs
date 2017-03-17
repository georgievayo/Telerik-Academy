using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClass
{
    public class Battery
    {
        private string model;
        private int? hoursIdle;
        private int? hoursTalk;
        private BatteryType type;

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Model's name is invallid");
                }
                else
                {
                    this.model = value;
                }
            }
        }

        public int? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set

            {
                if (value<= 0)
                {
                    throw new ArgumentException("Hours Idle should be more than 0");
                }
                this.hoursIdle = value;

            }
        }

        public int? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Hours talk should be more than 0");
                }
                this.hoursTalk = value;
            }
        }

        public Battery(string model)
        {
            Model = model;
            HoursIdle = null;
            HoursTalk = null;
        }
        public Battery(string model, int? hIdle, int? hTalk, BatteryType t) : this(model)
        {
            HoursIdle = hIdle;
            HoursTalk = hTalk;
            type = t;
        }

        public override string ToString()
        {
            return $"[Battery model: {this.model}, Hours Idle: {this.hoursIdle}, Hours Talk: {this.hoursTalk}]";
        }
    }

    public enum BatteryType
    {
        LiIon,
        NiMH,
        NiCd
    }
}
