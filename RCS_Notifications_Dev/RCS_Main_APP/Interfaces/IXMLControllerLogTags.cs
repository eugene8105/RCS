using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCS_Main_APP.Interfaces
{
    interface IXMLControllerLogTags
    {
        string Description { get; set; }
        string ErrorCode { get; set; }
        string Title { get; set; }
        string ErrorType { get; set; }
        string ErrorTime { get; set; }
        string BodyText { get; set; }

    } // end of IControllerLogMessageOutput interface
} 
