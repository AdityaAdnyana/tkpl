using System;
using System.Collections.Generic;
using System.Text;

namespace tkpl.View.User_Page.Factory.ReportModule
{
    public abstract class FactoryReportModule
    {
        protected string _lessonTitle;
        protected decimal _maxWeight;
        protected decimal _score;
       


        protected FactoryReportModule( string lessonTitle, decimal maxWeight, decimal score)
        {
            _lessonTitle = lessonTitle;
            _maxWeight = maxWeight;
            _score = score;

        }

        public abstract IReportModule CreateReportModule();

        public Panel CreateModule()
        {
            IReportModule module = CreateReportModule();
            return module.GetPanel();
        }


    }
}
