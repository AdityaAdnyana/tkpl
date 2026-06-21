using System;
using System.Collections.Generic;
using System.Text;
using tkpl.View.User_Page.Factory.ReportModule;

namespace tkpl.View.Factory.ModuleReport
{
    public static class ModuleReportCreatorFactory
    {
        public static FactoryReportModule CreateModuleReportCreator(bool isPassed, string lessonTitle, decimal maxWeight, decimal score)
        {
            if (isPassed)
            {
                return new FactoryPassReportModule(lessonTitle, maxWeight, score);
            }
            else
            {
                return new FactoryFailedReportModule(lessonTitle, maxWeight, score);
            }
        }
    }
}
