using System.Text;
using System;

public interface IReportBuilder
{
    void SetHeader(string header);
    void SetContent(string content);
    void SetFooter(string footer);
    string GetReport();
}

public class TextReportBuilder : IReportBuilder
{
    private StringBuilder _report = new StringBuilder();

    public void SetHeader(string header)
    {
        _report.AppendLine(header);
    }

    public void SetContent(string content)
    {
        _report.AppendLine(content);
    }

    public void SetFooter(string footer)
    {
        _report.AppendLine(footer);
    }

    public string GetReport()
    {
        return _report.ToString();
    }
}

public class HtmlReportBuilder : IReportBuilder
{
    private StringBuilder _report = new StringBuilder();

    public void SetHeader(string header)
    {
        _report.AppendLine($"<h1>{header}</h1>");
    }

    public void SetContent(string content)
    {
        _report.AppendLine($"<p>{content}</p>");
    }

    public void SetFooter(string footer)
    {
        _report.AppendLine($"<footer>{footer}</footer>");
    }

    public string GetReport()
    {
        return _report.ToString();
    }
}

public class ReportDirector
{
    public void ConstructReport(IReportBuilder builder)
    {
        builder.SetHeader("Report Header");
        builder.SetContent("Report Content");
        builder.SetFooter("Report Footer");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var director = new ReportDirector();

        var textBuilder = new TextReportBuilder();
        director.ConstructReport(textBuilder);
        Console.WriteLine(textBuilder.GetReport());

        var htmlBuilder = new HtmlReportBuilder();
        director.ConstructReport(htmlBuilder);
        Console.WriteLine(htmlBuilder.GetReport());
    }
}
