
namespace DesignPrinciples.GammaCategorization.CreationalDesignPatterns.Builder
{
    public class Builder
    {
        public static void Main()
        {
            Report report;
            ReportManager reportManager = new ReportManager();
            ExcelReport excelReport = new ExcelReport();
            report = reportManager.CreateReport(excelReport);
            report.DisplayReport();

            WordReport wordReport = new WordReport();
            report = reportManager.CreateReport(wordReport);
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

        public abstract void AddHeader();

        public abstract void AddFooter();

        public abstract void AddBodyContent();

        public abstract void AddReportType();

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
        public override void AddBodyContent()
        {
            report.BodyContent = "This is an Excel report";
        }

        public override void AddFooter()
        {
            report.Footer = "Excel report is finished";
        }

        public override void AddHeader()
        {
            report.Header = "Excel report is started";
        }

        public override void AddReportType()
        {
            report.ReportType = "Excel report";
        }
    }

    public class WordReport : ReportBuilder
    {
        public override void AddBodyContent()
        {
            report.BodyContent = "This is an Word report";
        }

        public override void AddFooter()
        {
            report.Footer = "Word report is finished";
        }

        public override void AddHeader()
        {
            report.Header = "Word report is started";
        }

        public override void AddReportType()
        {
            report.ReportType = "Word report";
        }
    }

    public class ReportManager
    {
        public Report CreateReport(ReportBuilder reportBuilder)
        {
            reportBuilder.CreateReport();
            reportBuilder.AddReportType();
            reportBuilder.AddHeader();
            reportBuilder.AddBodyContent();
            reportBuilder.AddFooter();

            return reportBuilder.GetReport();
        }
    }
}
