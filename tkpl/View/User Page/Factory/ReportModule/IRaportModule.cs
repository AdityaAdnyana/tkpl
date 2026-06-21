using System;
using System.Collections.Generic;
using System.Text;

namespace tkpl.View.User_Page.Factory.ReportModule
{
    public interface IReportModule
    {
        Panel GetPanel();
        void AddReportCard(Panel reportCard);
    }

    
}
