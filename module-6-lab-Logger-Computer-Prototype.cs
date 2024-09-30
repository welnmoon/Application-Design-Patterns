using System;
using System.Collections.Generic;
public enum LogLevel
{
    INFO, WARNING, ERROR
}

public class Logger
{
    private static Logger _instance;
    private static readonly object _lock = new object();
    private LogLevel _currentLogLevel = LogLevel.INFO;

    private Logger() { }

    public static Logger GetInstance()
    {
        lock (_lock)
        {
            if (_instance == null)
            {
                _instance = new Logger();
            }
        }

        return _instance;
    }

    public void SetLogLevel(LogLevel level)
    {
        _currentLogLevel = level;
    }

    public void Log(LogLevel loglevel, string message)
    {
        if (loglevel >= _currentLogLevel)
        {
            string logMessage = $"{DateTime.Now} [{loglevel}] {message}";
            Console.WriteLine(logMessage);
        }
    }
}

//-------------------------------------------------------------------------------------//

public class Computer
{
    public string CPU { get; set; }
    public string RAM { get; set; }
    public string Storage { get; set; }
    public string GPU { get; set; }
    public string OS { get; set; }

    public override string ToString()
    {
        return $"Компьютер: CPU - {CPU}, RAM - {RAM}, Накопитель - {Storage}, GPU - {GPU}, ОС - {OS}";
    }
}

public interface IComputerBuilder
{
    void SetCPU();
    void SetRAM();
    void SetStorage();
    void SetGPU();
    void SetOS();
    Computer GetComputer();
}

public class OfficeComputerBuilder : IComputerBuilder
{
    private Computer _computer = new Computer();

    public void SetCPU() => _computer.CPU = "Intel i3";
    public void SetRAM() => _computer.RAM = "8GB";
    public void SetStorage() => _computer.Storage = "1TB HDD";
    public void SetGPU() => _computer.GPU = "Integrated";
    public void SetOS() => _computer.OS = "Windows 10";

    public Computer GetComputer() => _computer;
}

public class GamingComputerBuilder : IComputerBuilder
{
    private Computer _computer = new Computer();

    public void SetCPU() => _computer.CPU = "Intel i9";
    public void SetRAM() => _computer.RAM = "32GB";
    public void SetStorage() => _computer.Storage = "1TB SSD";
    public void SetGPU() => _computer.GPU = "NVIDIA RTX 3080";
    public void SetOS() => _computer.OS = "Windows 11";

    public Computer GetComputer() => _computer;
}

public class ComputerDirector
{
    private IComputerBuilder _builder;

    public ComputerDirector(IComputerBuilder builder)
    {
        _builder = builder;
    }

    public void ConstructComputer()
    {
        _builder.SetCPU();
        _builder.SetRAM();
        _builder.SetStorage();
        _builder.SetGPU();
        _builder.SetOS();
    }

    public Computer GetComputer()
    {
        return _builder.GetComputer();
    }
}

//------------------------------------------------------------------------------------//

public interface IPrototype
{
    IPrototype Clone();
}

public class Section : IPrototype
{
    public string Title { get; set; }
    public string Text { get; set; }

    public IPrototype Clone()
    {
        return new Section { Title = this.Title, Text = this.Text };
    }
}

public class Image : IPrototype
{
    public string Url { get; set; }

    public IPrototype Clone()
    {
        return new Image { Url = this.Url };
    }
}

public class Document : IPrototype
{
    public string Title { get; set; }
    public string Content { get; set; }
    public List<Section> Sections { get; set; } = new List<Section>();
    public List<Image> Images { get; set; } = new List<Image>();

    public IPrototype Clone()
    {
        Document clone = new Document
        {
            Title = this.Title,
            Content = this.Content,
            Sections = new List<Section>(),
            Images = new List<Image>()
        };

        foreach (var section in this.Sections)
        {
            clone.Sections.Add((Section)section.Clone());
        }

        foreach (var image in this.Images)
        {
            clone.Images.Add((Image)image.Clone());
        }

        return clone;
    }
}

public class DocumentManager
{
    public IPrototype CreateDocument(IPrototype prototype)
    {
        return prototype.Clone();
    }
}

public class Singleton
{
    public static void Main(string[] args)
    {
        Logger logger = Logger.GetInstance();
        logger.SetLogLevel(LogLevel.WARNING);

        logger.Log(LogLevel.INFO, "Система запущена");
        logger.Log(LogLevel.WARNING, "Проблема");
        logger.Log(LogLevel.ERROR, "ошибка");

        //----------------------------------------//

        // Создаем офисный компьютер
        IComputerBuilder officeBuilder = new OfficeComputerBuilder();
        ComputerDirector director = new ComputerDirector(officeBuilder);
        director.ConstructComputer();
        Computer officeComputer = director.GetComputer();
        Console.WriteLine(officeComputer);

        // Создаем игровой компьютер
        IComputerBuilder gamingBuilder = new GamingComputerBuilder();
        director = new ComputerDirector(gamingBuilder);
        director.ConstructComputer();
        Computer gamingComputer = director.GetComputer();
        Console.WriteLine(gamingComputer);

        //-------------------------------------//

        Document originalDoc = new Document
        {
            Title = "Оригинальный документ",
            Content = "Это содержимое оригинального документа.",
            Sections = new List<Section>
            {
                new Section { Title = "Раздел 1", Text = "Текст раздела 1." },
                new Section { Title = "Раздел 2", Text = "Текст раздела 2." }
            },
            Images = new List<Image>
            {
                new Image { Url = "http://example.com/image1.png" },
                new Image { Url = "http://example.com/image2.png" }
            }
        };

        DocumentManager manager = new DocumentManager();
        Document clonedDoc = (Document)manager.CreateDocument(originalDoc);

        clonedDoc.Title = "Клонированный документ";
        clonedDoc.Sections[0].Text = "Измененный текст для раздела 1.";

        Console.WriteLine($"Оригинальный документ: {originalDoc.Title}");
        foreach (var section in originalDoc.Sections)
        {
            Console.WriteLine($"  {section.Title}: {section.Text}");
        }

        Console.WriteLine($"Клонированный документ: {clonedDoc.Title}");
        foreach (var section in clonedDoc.Sections)
        {
            Console.WriteLine($"  {section.Title}: {section.Text}");
        }

    }
}
