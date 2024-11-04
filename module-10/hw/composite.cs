using System;
using System.Collections.Generic;

public abstract class FileSystemComponent
{
    public string Name { get; set; }

    public FileSystemComponent(string name)
    {
        Name = name;
    }

    public abstract void Display(string indent = "");
    public abstract int GetSize();
}

public class File : FileSystemComponent
{
    public int Size { get; set; }

    public File(string name, int size) : base(name)
    {
        Size = size;
    }

    public override void Display(string indent = "")
    {
        Console.WriteLine($"{indent}- File: {Name}, Size: {Size}KB");
    }

    public override int GetSize()
    {
        return Size;
    }
}

public class Directory : FileSystemComponent
{
    private List<FileSystemComponent> _components = new List<FileSystemComponent>();

    public Directory(string name) : base(name) { }

    public void Add(FileSystemComponent component)
    {
        if (!_components.Contains(component))
        {
            _components.Add(component);
        }
    }

    public void Remove(FileSystemComponent component)
    {
        if (_components.Contains(component))
        {
            _components.Remove(component);
        }
    }

    public override void Display(string indent = "")
    {
        Console.WriteLine($"{indent}+ Directory: {Name}");
        foreach (var component in _components)
        {
            component.Display(indent + "  ");
        }
    }

    public override int GetSize()
    {
        int totalSize = 0;
        foreach (var component in _components)
        {
            totalSize += component.GetSize();
        }
        return totalSize;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Directory root = new Directory("Root");
        File file1 = new File("File1.txt", 500);
        File file2 = new File("File2.txt", 300);
        Directory subDirectory1 = new Directory("SubDir1");
        File file3 = new File("File3.txt", 200);
        Directory subDirectory2 = new Directory("SubDir2");

        root.Add(file1);
        root.Add(subDirectory1);
        subDirectory1.Add(file2);
        subDirectory1.Add(subDirectory2);
        subDirectory2.Add(file3);

        root.Display();
        Console.WriteLine($"Total size: {root.GetSize()}KB");
    }
}
