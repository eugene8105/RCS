using RCS_Main_APP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCS_Main_APP
{
    class XmlTags : IXmlTags
    {
        public string TagTitle { get; set; }
        public string TagDescription { get; set; }
        public string TagConsequences { get; set; }
        public string TagCauses { get; set; }
        public string[] TagActions { get; set; }

    } // end of XmlTags class
}
