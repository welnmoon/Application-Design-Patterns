using System;

public interface IDocument
{
    public void Open();
}

public class Report : IDocument
{
    public void Open()
    {
        Console.WriteLine("Открытие отчета.");
    }
}

public class Resume : IDocument
{
    public void Open() {
        Console.WriteLine("Открытие отчета.");
    }

}

public class Letter : IDocument
{
    public void Open() {
        Console.WriteLine("Открытие отчета.");
    }
}

public class Invoice : IDocument
{
    public void Open()
    {
        Console.WriteLine("Открытие счета.");
    }
}

//--------------------------------------------------------------------------//

abstract public class DocumentCreator
{
    public abstract IDocument CreateDocument();
}

public class ReportCreator : DocumentCreator
{
    public override IDocument CreateDocument()
    {
        Console.WriteLine("Создание документа типа Report.");
        return new Report();
    }
}

public class ResumeCreator : DocumentCreator
{
    public override IDocument CreateDocument()
    {
        Console.WriteLine("Создание документа типа Resume");
        return new Resume();
    }
}

public class LetterCreator : DocumentCreator
{
    public override IDocument CreateDocument()
    {
        Console.WriteLine("Создание документа типа Letter");
        return new Letter();
    }
}

public class InvoiceCreator : DocumentCreator
{
    public override IDocument CreateDocument()
    {
        Console.WriteLine("Создание документа типа Invoice.");
        return new Invoice();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
     DocumentCreator resumeCreator = new ResumeCreator();
     DocumentCreator reportCreator = new ReportCreator();
     DocumentCreator letterCreator = new LetterCreator();
     DocumentCreator invoiceCreator = new InvoiceCreator();


        Console.WriteLine("Выберите тип документа (1: Report, 2: Resume, 3: Letter, 4: Invoice): ");
        int choice = int.Parse(Console.ReadLine());

        IDocument document = null;

        switch (choice)
        {
            case 1:
                document = reportCreator.CreateDocument();
                break;
            case 2:
                document = resumeCreator.CreateDocument();
                break;
            case 3:
                document = letterCreator.CreateDocument();
                break;
            case 4: 
                document = invoiceCreator.CreateDocument();
                break;
            default:
                Console.WriteLine("Wrong!!");
                return;
        }

       document.Open();
    }
}
