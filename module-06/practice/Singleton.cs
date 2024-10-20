using System;
using System.IO;
using System.Threading;

public enum LogLevel
{
    INFO,
    WARNING,
    ERROR
}

public class Logger
{
    private static Logger _instance;
    private static readonly object _lock = new object();
    private LogLevel _currentLogLevel;
    private string _logFilePath;

    private Logger()
    {
        _currentLogLevel = LogLevel.INFO;
        _logFilePath = "app.log";
    }

    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
            }
        }
        return _instance;
    }

    public void SetLogLevel(LogLevel level)
    {
        _currentLogLevel = level;
    }

    public void Log(string message, LogLevel level)
    {
        if (level >= _currentLogLevel)
        {
            lock (_lock)
            {
                using (StreamWriter writer = new StreamWriter(_logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now} [{level}]: {message}");
                }
            }
        }
    }

    public void LoadConfiguration(string configFilePath)
    {
        _logFilePath = "newLogFile.log";
        _currentLogLevel = LogLevel.WARNING;
    }
}

public class LogReader
{
    private string _logFilePath;

    public LogReader(string logFilePath)
    {
        _logFilePath = logFilePath;
    }

    public void ReadLogs(LogLevel filterLevel)
    {
        if (File.Exists(_logFilePath))
        {
            using (StreamReader reader = new StreamReader(_logFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains($"[{filterLevel}]"))
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Logger logger = Logger.GetInstance();
        logger.SetLogLevel(LogLevel.INFO);

        Thread thread1 = new Thread(() => LogMessages("Thread 1", logger));
        Thread thread2 = new Thread(() => LogMessages("Thread 2", logger));

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        LogReader logReader = new LogReader("app.log");
        Console.WriteLine("\nReading ERROR logs:");
        logReader.ReadLogs(LogLevel.ERROR);
    }

    static void LogMessages(string threadName, Logger logger)
    {
        for (int i = 0; i < 5; i++)
        {
            logger.Log($"{threadName} - message {i}", LogLevel.INFO);
            logger.Log($"{threadName} - warning {i}", LogLevel.WARNING);
            logger.Log($"{threadName} - error {i}", LogLevel.ERROR);
            Thread.Sleep(100);
        }
    }
}
