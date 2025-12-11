class Master : Student
{
    public Master(string name, int age, string grade) : base(name, age, grade) {}
    public void Graduation()
    {
        Console.WriteLine($"{name} защищает диплом");
    }
}

class Bachelor : Student
{
    public Bachelor(string name, int age, string grade) : base(name, age, grade) {}

    public void ExamsPassing()
    {
        Console.WriteLine($"{name} сдает экзамены");
    }
}