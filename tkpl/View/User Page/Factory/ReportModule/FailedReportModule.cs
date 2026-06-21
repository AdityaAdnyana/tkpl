using System;
using System.Collections.Generic;
using System.Text;
using tkpl.Controller;  

namespace tkpl.View.User_Page.Factory.ReportModule
{
    public class FailedReportModule : IReportModule
    {
        protected string _lessonTitle;
        protected decimal _maxWeight;
        protected decimal _score;
        protected List<Panel> _reportCards;
        public FailedReportModule(string lessonTitle, decimal maxWeight, decimal score)
        {
            _lessonTitle = lessonTitle;
            _maxWeight = maxWeight;
            _score = score;
        }

        public void AddReportCard(Panel reportCard)
        {
            _reportCards.Add(reportCard);
        }

        public Panel GetPanel()
        {
            Panel panel = new Panel();
            var ui = AppConfig.UI;
            panel.Size = new Size(ui.ReportModuleWidth, ui.ReportModuleHeight);
            panel.BackColor =Color.RosyBrown;

            Label LbTitle = new Label();
            LbTitle.Text = _lessonTitle;
            LbTitle.Location = new Point(24, 19);
            LbTitle.Size = new Size(ui.ReportModuleContentWidth, ui.ReportModuleContentHeight);
            LbTitle.Font = new Font(ui.ReportModuleContentFontFamily, ui.ReportModuleContentFontSize, FontStyle.Bold);
            panel.Controls.Add(LbTitle);

            Label LbTotalScore = new Label();
            LbTotalScore.Text = $"Total Score: {_score}";
            LbTotalScore.Location = new Point(244, 19);
            LbTotalScore.Size = new Size(ui.ReportModuleContentWidth, ui.ReportModuleContentHeight);
            LbTotalScore.Font = new Font(ui.ReportModuleContentFontFamily, ui.ReportModuleContentFontSize, FontStyle.Bold);
            panel.Controls.Add(LbTotalScore);

            Label LbStatus = new Label();
            LbStatus.Text = "Failed";
            LbStatus.Location = new Point(476, 19);
            LbStatus.Size = new Size(ui.ReportModuleContentWidth, ui.ReportModuleContentHeight);
            LbStatus.Font = new Font(ui.ReportModuleContentFontFamily, ui.ReportModuleContentFontSize, FontStyle.Bold);
            panel.Controls.Add(LbStatus);

            FlowLayoutPanel flowPanel = new FlowLayoutPanel();
            flowPanel.Visible = false;
            flowPanel.Location = new Point(24, 60); // Posisikan di bawah teks utama
            flowPanel.AutoSize = true; // Biarkan tinggi menyesuaikan isinya
            flowPanel.MaximumSize = new Size(ui.ReportModuleWidth - 40, 0);
            flowPanel.FlowDirection = FlowDirection.TopDown; // Kartu tersusun ke bawah
            flowPanel.WrapContents = false; ;

            foreach (var card in _reportCards)
            {
                flowPanel.Controls.Add(card);
            }
            panel.Controls.Add(flowPanel);

            Button BtnReport = new Button();
            BtnReport.Text = "View Report";
            BtnReport.Location = new Point(751, 19);
            BtnReport.Size = new Size(ui.ReportModuleButtonWidth, ui.ReportModuleButtonHeight);
            BtnReport.Font = new Font(ui.ReportModuleButtonFontFamily, ui.ReportModuleButtonFontSize, FontStyle.Bold);
            BtnReport.Click += (s, e) =>
            {
                flowPanel.Visible = !flowPanel.Visible;
                if (flowPanel.Visible)
                {
                    // Jika dibuka, tinggi panel = tinggi awal + tinggi flowpanel + margin bawah
                    panel.Height = ui.ReportModuleHeight + flowPanel.Height + 20;
                }
                else
                {
                    // Jika ditutup, kembalikan ke tinggi semula
                    panel.Height = ui.ReportModuleHeight;
                }
            };
            panel.Controls.Add(BtnReport);

            
            return panel;
        }


    }
}