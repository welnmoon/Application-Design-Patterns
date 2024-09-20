using System;

public interface IPrinter
{
    void Print(string content);
}

public interface IScanner
{
    void Scan(string content);
}

public interface IFax
{
    void Fax(string content);
}

public class AllInOnePrinter : IPrinter, IScanner, IFax
{
    public void Print(string content)
    {
        Console.WriteLine("Printing: " + content);
    }

    public void Scan(string content)
    {
        Console.WriteLine("Scanning: " + content);
    }

    public void Fax(string content)
    {
        Console.WriteLine("Faxing: " + content);
    }
}

public class BasicPrinter : IPrinter
{
    public void Print(string content)
    {
        Console.WriteLine("Printing: " + content);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IPrinter allInOnePrinter = new AllInOnePrinter();
        allInOnePrinter.Print("Document 1");

        IScanner scanner = new AllInOnePrinter();
        scanner.Scan("Document 2");

        IFax fax = new AllInOnePrinter();
        fax.Fax("Document 3");

        IPrinter basicPrinter = new BasicPrinter();
        basicPrinter.Print("Document 4");
    }
}
