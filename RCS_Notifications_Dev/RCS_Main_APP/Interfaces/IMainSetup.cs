using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCS_Main_APP.Interfaces
{
    interface IMainSetup
    {
        /// <summary>
        /// set up text label on the button of the main screen if controller available on the network or not - without connections
        /// </summary>
        string MainLblControllerInfo { get; set; }
    }
}
