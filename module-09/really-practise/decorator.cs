using System;

namespace ReportingSystem
{
    public interface IReport
    {
        string Generate();
    }

    public class SalesReport : IReport
    {
        public string Generate() => "Sales Report Data";
    }

    public class UserReport : IReport
    {
        public string Generate() => "User Report Data";
    }

    public abstract class ReportDecorator : IReport
    {
        protected IReport _report;
        public ReportDecorator(IReport report) => _report = report;
        public abstract string Generate();
    }

    public class DateFilterDecorator : ReportDecorator
    {
        public DateFilterDecorator(IReport report) : base(report) { }
        public override string Generate() => _report.Generate() + " | Filtered by Date";
    }

    public class SortingDecorator : ReportDecorator
    {
        public SortingDecorator(IReport report) : base(report) { }
        public override string Generate() => _report.Generate() + " | Sorted";
    }

    public class CsvExportDecorator : ReportDecorator
    {
        public CsvExportDecorator(IReport report) : base(report) { }
        public override string Generate() => _report.Generate() + " | Exported to CSV";
    }

    public class PdfExportDecorator : ReportDecorator
    {
        public PdfExportDecorator(IReport report) : base(report) { }
        public override string Generate() => _report.Generate() + " | Exported to PDF";
    }

    class Program
    {
        static void Main()
        {
            IReport report = new SalesReport();
            report = new DateFilterDecorator(report);
            report = new SortingDecorator(report);
            report = new CsvExportDecorator(report);

            Console.WriteLine(report.Generate());
        }
    }
}
