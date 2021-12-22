
namespace DesignPatterns.GammaCategorization.CreationalDesignPatterns.Builder
{
    public class FluentBuilder
    {
        public static void Main()
        {
            ExcelReport excelReport = new ExcelReport();
            excelReport.CreateReport();
            excelReport.AddReportType().AddHeader().AddBodyContent().AddFooter();
            Report report = excelReport.GetReport();
            report.DisplayReport();

            WordReport wordReport = new WordReport();
            wordReport.CreateReport();
            wordReport.AddReportType().AddHeader().AddBodyContent().AddFooter();
            report = excelReport.GetReport();
            report.DisplayReport();
        }
    }

    public class Report
    {
        public string Header { get; set; }

        public string Footer { get; set; }

        public string BodyContent { get; set; }

        public string ReportType { get; set; }

        public void DisplayReport()
        {
            Console.WriteLine("Report Type: " + ReportType);
            Console.WriteLine("Report Header: " + Header);
            Console.WriteLine("Body Content: " + BodyContent);
            Console.WriteLine("Report Footer: " + Footer);
        }
    }

    public abstract class ReportBuilder
    {
        protected Report report;

        public abstract ReportBuilder AddHeader();

        public abstract ReportBuilder AddFooter();

        public abstract ReportBuilder AddBodyContent();

        public abstract ReportBuilder AddReportType();

        public void CreateReport()
        {
            report = new Report();
        }

        public Report GetReport()
        {
            return report;
        }
    }

    public class ExcelReport : ReportBuilder
    {
        public override ReportBuilder AddBodyContent()
        {
            report.BodyContent = "This is an Excel report";
            return this;
        }

        public override ReportBuilder AddFooter()
        {
            report.Footer = "Excel report is finished";
            return this;
        }

        public override ReportBuilder AddHeader()
        {
            report.Header = "Excel report is started";
            return this;
        }

        public override ReportBuilder AddReportType()
        {
            report.ReportType = "Excel report";
            return this;
        }
    }

    public class WordReport : ReportBuilder
    {
        public override ReportBuilder AddBodyContent()
        {
            report.BodyContent = "This is an Word report";
            return this;
        }

        public override ReportBuilder AddFooter()
        {
            report.Footer = "Word report is finished";
            return this;
        }

        public override ReportBuilder AddHeader()
        {
            report.Header = "Word report is started";
            return this;
        }

        public override ReportBuilder AddReportType()
        {
            report.ReportType = "Word report";
            return this;
        }
    }
}
