using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace removipe
{
    public class ValveManual
    {
        public ValveManual()
        {
        }
        public ValveManual(bool status, bool use)
        {
            this.status = status;
            this.use = use;
        }

        bool status = false;
        /// <summary>
        /// valveManualStatus
        /// </summary>
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        bool use = false;
        /// <summary>
        /// valveManualStatus
        /// </summary>
        public bool Use
        {
            get { return use; }
            set { use = value; }
        }
    }
}
