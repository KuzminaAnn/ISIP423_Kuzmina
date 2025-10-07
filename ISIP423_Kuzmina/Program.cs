using System;
using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;

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

// Класс системы университета
//public class UniversitySystem
//{
//    private List<Student> students = new List<Student>();
//    private List<Teacher> teachers = new List<Teacher>();
//    private List<Course> courses = new List<Course>();

//    public void AddStudent(Student student) => students.Add(student);
//    public void AddTeacher(Teacher teacher) => teachers.Add(teacher);
//    public void AddCourse(Course course) => courses.Add(course);

//    public void DisplayAllStudents()
//    {
//        foreach (var student in students)
//        {
//            student.DisplayInfo();
//            Console.WriteLine(new string('-', 30));
//        }
//    }

//    public void DisplayAllTeachers()
//    {
//        foreach (var teacher in teachers)
//        {
//            teacher.DisplayInfo();
//            Console.WriteLine(new string('-', 30));
//        }
//    }

//    public void DisplayAllCourses()
//    {
//        foreach (var course in courses)
//        {
//            course.DisplayInfo();
//            Console.WriteLine(new string('-', 30));
//        }
//    }
//}


// Обновленное консольное меню с возможностью добавления курса
class Program
{
    static void Main()
    {
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
                    { 
                        Console.WriteLine("1. Добавить студента");
                        Console.WriteLine("2. Запиать студента на курс");
                        Console.WriteLine("3. Посмотреть информацию");
                        Console.WriteLine("4. Вывод всех студентов");
                        Console.Write("Выберите действие: ");
                        string choice1 = Console.ReadLine();
                        switch (choice1)
                        {
                            case "1":
                                private static void AddBook()
                            {
                                Console.WriteLine("Добавление новой книги");

                                var book = new Book
                                {
                                    Id = currentId++,
                                    Title = GetInput("Название"),
                                    Author = GetInput("Автор"),
                                    Genre = GetGenre(),
                                    Year = GetIntInput("Год издания"),
                                    Price = GetDecimalInput("Цена")
                                };

                                books.Add(book);
                                Console.WriteLine("Книга добавлена!");
                            }
                                break;
                        }
                    }
                  break;
                    

                case "2":
                    Console.WriteLine("1. Добавить преподавателя");
                    Console.WriteLine("2. Запиать преподавателя вести курс");
                    Console.WriteLine("3. Посмотреть информацию");
                    Console.WriteLine("4. Вывод всех преподавателей");
                    Console.Write("Выберите действие: ");
                    string choice2 = Console.ReadLine();

                    switch (choice2)
                    {
                        case "1":

                            break;
                    }
                    break;

                case "3":
                    Console.WriteLine("1. Добавить курс");
                    Console.WriteLine("2. Посмотреть инфо о курсе");
                    Console.WriteLine("3. Посмотреть участников курса");
                    Console.WriteLine("4. Вывод всех курсов");
                    Console.Write("Выберите действие: ");
                    string choice3 = Console.ReadLine();

                    switch (choice3)
                    {
                        case "1":

                            break;
                    }
                    break;
            }
        }
    }
}