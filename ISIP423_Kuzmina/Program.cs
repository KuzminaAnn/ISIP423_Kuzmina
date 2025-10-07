using System;
using System.Collections.Generic;

// Абстрактный базовый класс
public abstract class Person
{
    public string Name { get; set; }
    protected int Age { get; set; }
    protected string Contact { get; set; }

    public Person(string name, int age, string contact)
    {
        Name = name;
        Age = age;
        Contact = contact;
    }

    public abstract void DisplayInfo();
}

// Класс Студент
public class Student : Person
{
    private List<Course> courses = new List<Course>();

    public Student(string name, int age, string contact) : base(name, age, contact) { }

    public void EnrollCourse(Course course)
    {
        courses.Add(course);
    }

    public List<Course> GetCourses() => courses;

    public override void DisplayInfo()
    {
        Console.WriteLine($"Студент: {Name}");
        Console.WriteLine($"Возраст: {Age}");
        Console.WriteLine($"Контакты: {Contact}");
        Console.WriteLine("Курсы:");
        foreach (var course in courses)
        {
            Console.WriteLine($"- {course.Name}");
        }
    }
}

// Класс Преподаватель
public class Teacher : Person
{
    private List<Course> courses = new List<Course>();

    public Teacher(string name, int age, string contact) : base(name, age, contact) { }

    public void AssignCourse(Course course)
    {
        courses.Add(course);
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Преподаватель: {Name}");
        Console.WriteLine($"Возраст: {Age}");
        Console.WriteLine($"Контакты: {Contact}");
        Console.WriteLine("Курсы:");
        foreach (var course in courses)
        {
            Console.WriteLine($"- {course.Name}");
        }
    }
}

// Класс Курс
public class Course
{
    public string Name { get; set; }
    public Teacher Teacher { get; set; }
    public string Opis { get; set; }
    private List<Student> students = new List<Student>();

    public Course(string name, Teacher teacher)
    {
        Name = name;
        Teacher = teacher;
    }

    public void AddStudent(Student student)
    {
        students.Add(student);
        student.EnrollCourse(this);
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Курс: {Name}");
        Console.WriteLine($"Преподаватель: {Teacher.Name}");
        Console.WriteLine("Студенты:");
        Console.WriteLine($"Описание: {Opis}"); 

        foreach (var student in students)
        {
            Console.WriteLine($"- {student.Name}");
        }
    }
}


// Обновленное консольное меню с возможностью добавления курса
class Program
{
    static void Main()
    {
        UniversitySystem system = new UniversitySystem();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Система управления университетом");
            Console.WriteLine("1. Студент");
            Console.WriteLine("2. Преподаватель");
            Console.WriteLine("3. Курс");
            Console.WriteLine("4. Выйти");

            Console.Write("Выберите действие: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Система управления университетом");
                    Console.WriteLine("1. Добавить студента");
                    Console.WriteLine("2. Запиать студента на курс");
                    Console.WriteLine("3. Посмотреть информацию");
                    Console.WriteLine("4. Вывод всех студентов");
                    break;
                case "2":
                    break;
                case "3":
                    Console.Write("Введите название курса: ");
                    string courseName = Console.ReadLine();

                    Console.Write("Введите описание курса: ");
                    string courseDescription = Console.ReadLine();

                    Console.Write("Введите количество часов: ");
                    int courseHours = int.Parse(Console.ReadLine());

                    Console.Write("Введите уровень курса: ");
                    string courseLevel = Console.ReadLine();

                    // Выбор преподавателя для курса
                    Console.WriteLine("Выберите преподавателя:");
                    for (int i = 0; i < system.teachers.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {system.teachers[i].Name}");
                    }
                    Console.Write("Введите номер преподавателя: ");
                    int teacherIndex = int.Parse(Console.ReadLine()) - 1;

                    Teacher selectedTeacher = system.teachers[teacherIndex];

                    Course newCourse = new Course(
                        courseName,
                        courseDescription,
                        courseHours,
                        courseLevel,
                        selectedTeacher
                    );

                    system.AddCourse(newCourse);
                    break;
            }
        }
    }
}