class Animal
{
    public string name;
    public int age;
    protected string Name {get { return name; } set { name = value; }}
    protected int Age {get { return age; } set { age = value; }}
    public void Sound()
    {
        Console.WriteLine("* звуки животных *");
    }
}

class Dog : Animal
{
    public Dog()
    {
        this.name = "Бобик";
        this.age = 1;
    }
    public void Gav()
    {
        Console.WriteLine("Собака по имени " + name + " сказала Гав!");
    }
}

class Cat : Animal
{
    public Cat()
    {
        this.name = "Хз кот";
        this.age = 1;
    }
    public void Maw()
    {
        Console.WriteLine("Кот по имени " + name + " сказал Мяу!");
    }
}

