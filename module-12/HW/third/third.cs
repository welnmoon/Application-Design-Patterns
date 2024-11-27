using System;
using System.Collections.Generic;

class Program
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public List<string> Materials { get; set; } = new List<string>();
        public List<string> Reviews { get; set; } = new List<string>();
    }

    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; } // "Student", "Teacher", "Admin"
    }

    public class OnlineCourseSystem
    {
        private List<Course> courses = new List<Course>();
        private List<User> users = new List<User>();

        public void RegisterUser(string name, string role)
        {
            users.Add(new User { ID = users.Count + 1, Name = name, Role = role });
            Console.WriteLine($"Пользователь '{name}' зарегистрирован как {role}.");
        }

        public void AddCourse(string name, string category)
        {
            courses.Add(new Course { ID = courses.Count + 1, Name = name, Category = category });
            Console.WriteLine($"Курс '{name}' добавлен в категорию '{category}'.");
        }

        public void EnrollInCourse(int courseId, string userName)
        {
            var course = courses.Find(c => c.ID == courseId);
            if (course != null)
            {
                Console.WriteLine($"Пользователь '{userName}' записан на курс '{course.Name}'.");
            }
            else
            {
                Console.WriteLine("Курс не найден.");
            }
        }

        public void AddMaterial(int courseId, string material)
        {
            var course = courses.Find(c => c.ID == courseId);
            if (course != null)
            {
                course.Materials.Add(material);
                Console.WriteLine($"Материал добавлен к курсу '{course.Name}': {material}");
            }
            else
            {
                Console.WriteLine("Курс не найден.");
            }
        }

        public void LeaveReview(int courseId, string review)
        {
            var course = courses.Find(c => c.ID == courseId);
            if (course != null)
            {
                course.Reviews.Add(review);
                Console.WriteLine($"Отзыв добавлен к курсу '{course.Name}': {review}");
            }
            else
            {
                Console.WriteLine("Курс не найден.");
            }
        }

        public void ViewCourses()
        {
            foreach (var course in courses)
            {
                Console.WriteLine($"ID: {course.ID}, Название: {course.Name}, Категория: {course.Category}");
            }
        }

        public void ViewStatistics(string teacherName)
        {
            Console.WriteLine($"Статистика для преподавателя '{teacherName}':");
            Console.WriteLine($"Курсов создано: {courses.Count}");
        }
    }

    static void Main(string[] args)
    {
        var system = new OnlineCourseSystem();

        system.RegisterUser("Иван", "Student");
        system.RegisterUser("Мария", "Teacher");

        system.AddCourse("C# для начинающих", "Программирование");
        system.AddCourse("Основы SQL", "Базы данных");

        system.ViewCourses();

        system.EnrollInCourse(1, "Иван");
        system.AddMaterial(1, "Введение в C#");
        system.LeaveReview(1, "Очень полезный курс!");

        system.ViewStatistics("Мария");
    }
}
