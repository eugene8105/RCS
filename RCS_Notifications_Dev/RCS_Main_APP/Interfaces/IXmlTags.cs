using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCS_Main_APP.Interfaces
{
    /// <summary>
    /// IXmlTags 
    /// </summary>
    interface IXmlTags
    {
        string TagTitle { get; set; }
        string TagDescription { get; set; }
        string TagConsequences { get; set; }
        string TagCauses { get; set; }
        string[] TagActions { get; set; }
    }
}
