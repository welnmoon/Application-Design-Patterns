using System;

public abstract class ReportGenerator
{
    public void GenerateReport()
    {
        PrepareData();
        FormatReport();
        if (CustomerWantsSave())
        {
            SaveReport();
        }
        if (CustomerWantsSendEmail())
        {
            SendReportByEmail();
        }
    }

    protected void PrepareData()
    {
        Console.WriteLine("Preparing data for the report...");
    }

    protected abstract void FormatReport();
    protected abstract void SaveReport();

    protected virtual bool CustomerWantsSave()
    {
        return true;
    }

    protected virtual bool CustomerWantsSendEmail()
    {
        return false;
    }

    protected void SendReportByEmail()
    {
        Console.WriteLine("Sending report by email...");
    }
}

public class PdfReport : ReportGenerator
{
    protected override void FormatReport()
    {
        Console.WriteLine("Formatting PDF report...");
    }

    protected override void SaveReport()
    {
        Console.WriteLine("Saving PDF report...");
    }
}

public class ExcelReport : ReportGenerator
{
    protected override void FormatReport()
    {
        Console.WriteLine("Formatting Excel report...");
    }

    protected override void SaveReport()
    {
        Console.WriteLine("Saving Excel report...");
    }

    protected override bool CustomerWantsSendEmail()
    {
        Console.WriteLine("Do you want to send the Excel report by email? (yes/no)");
        string input = Console.ReadLine().ToLower();
        return input == "yes";
    }
}

public class HtmlReport : ReportGenerator
{
    protected override void FormatReport()
    {
        Console.WriteLine("Formatting HTML report...");
    }

    protected override void SaveReport()
    {
        Console.WriteLine("Saving HTML report...");
    }
}

public class CsvReport : ReportGenerator
{
    protected override void FormatReport()
    {
        Console.WriteLine("Formatting CSV report...");
    }

    protected override void SaveReport()
    {
        Console.WriteLine("Saving CSV report...");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ReportGenerator pdfReport = new PdfReport();
        Console.WriteLine("\nGenerating PDF Report:");
        pdfReport.GenerateReport();

        ReportGenerator excelReport = new ExcelReport();
        Console.WriteLine("\nGenerating Excel Report:");
        excelReport.GenerateReport();

        ReportGenerator htmlReport = new HtmlReport();
        Console.WriteLine("\nGenerating HTML Report:");
        htmlReport.GenerateReport();

        ReportGenerator csvReport = new CsvReport();
        Console.WriteLine("\nGenerating CSV Report:");
        csvReport.GenerateReport();
    }
}
