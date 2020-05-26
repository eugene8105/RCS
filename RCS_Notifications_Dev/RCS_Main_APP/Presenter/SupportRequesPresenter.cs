using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCS_Main_APP.Interfaces;
using RCS_Main_APP.Models;
using RCS_Main_APP.View;

namespace RCS_Main_APP.Presenter
{
    class SupportRequesPresenter
    {
        SupportRequestModel srm = new SupportRequestModel();

        ISupportRequestView supportView;
        public SupportRequesPresenter(ISupportRequestView supView)
        {
            supportView = supView;
        }
        public void RoboticSupportReq()
        {
            srm.RoboticSupportRequest(supportView.RobSupportText, supportView.WebHookRobotSupport);
        }

        public void R4supportReq()
        {
            srm.R4Request(supportView.R4SupportText, supportView.WebHookR4Support);
        }

    } // end of SupportRequesPresenter class
}
