using System.Security.Cryptography;

class Student
{
    public string name;
    public int age;
    public string grade;

    public Student(string name, int age, string grade)
    {
        this.name = name;
        this.age = age;
        this.grade = grade;
    }
    
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public int Age
    {
        get { return age; }
        set { age = value; }
    }
    public string Grade
    {
        get { return grade; }
        set { grade = value; }
    }

    public void Learning()
    {
        Console.WriteLine($"Студент по имени {name}, которому {age} лет, учится в группе {grade}");
    }
}