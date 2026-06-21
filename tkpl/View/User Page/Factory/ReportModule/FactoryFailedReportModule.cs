using System;
using System.Collections.Generic;
using System.Text;

namespace tkpl.View.User_Page.Factory.ReportModule
{
    public class FactoryFailedReportModule : FactoryReportModule
    {
        public FactoryFailedReportModule(string lessonTitle, decimal maxWeight, decimal score) 
            : base(lessonTitle, maxWeight, score)
        {
        }

        public override IReportModule CreateReportModule()
        {
            return new FailedReportModule(_lessonTitle, _maxWeight, _score);
        }
    }
}
