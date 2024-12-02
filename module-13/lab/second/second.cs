public class Course
{
    public int CourseId { get; set; }
    public string Name { get; set; }
    public bool IsAvailable { get; set; }
}

public class CourseSystem
{
    private List<Course> courses = new List<Course>
    {
        new Course { CourseId = 1, Name = "Основы программирования", IsAvailable = true },
        new Course { CourseId = 2, Name = "Основы математики", IsAvailable = false }
    };

    public bool RegisterForCourse(int courseId, string userName)
    {
        var course = courses.Find(c => c.CourseId == courseId);
        if (course == null)
        {
            Console.WriteLine("Курс не найден.");
            return false;
        }

        if (!course.IsAvailable)
        {
            Console.WriteLine($"Курс '{course.Name}' недоступен. Регистрация не выполнена.");
            return false;
        }

        Console.WriteLine($"Пользователь {userName} зарегистрирован на курс '{course.Name}'.");
        return true;
    }
}
