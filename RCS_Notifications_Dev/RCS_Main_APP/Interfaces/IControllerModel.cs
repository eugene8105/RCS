using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.Discovery;
using ABB.Robotics.Controllers.IOSystemDomain;

namespace RCS_Main_APP.Interfaces
{
    interface IControllerModel
    {
        /// <summary>
        /// using for set collection of available controllers on the network
        /// </summary>
        ControllerInfoCollection CntCollection { get; set; }
        NetworkScanner Scanner { get; set; }
        /// <summary>
        /// Instance of Controller
        /// </summary>
        Controller Cntr { get; set; }
        /// <summary>
        /// creates collection of controllers on the network after scan was done.
        /// </summary>
        ControllerInfo ContrInfo { get; set; }
        /// <summary>
        /// Instance of 
        /// </summary>
        ABB.Robotics.Controllers.RapidDomain.Task[] Tasks { get; set; }
        NetworkWatcher NetWatch { get; set; }
        /// <summary>
        /// Method to set up dispose of the Controller returns boolean
        /// </summary>
        /// <returns></returns>
        void DisableController();
        /// <summary>
        /// Method for set up an controller connection
        /// </summary>
        /// <returns></returns>
        void EnableController(); 

    } // end of IControllerModel

} // end of RCS_Main_APP.Models
