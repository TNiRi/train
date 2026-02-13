using System.Security.Cryptography.X509Certificates;

interface IDamage
{
    public void TakeDamage(int damage);
}

abstract class Character: IDamage
{
    private string Name;
    private int Health;
    private double[] coordinates;
    public Character(string Name, int Health)
    {
        this.Name = Name;
        this.coordinates = coordinates[0, 0, 0];
        this.Health = Health;
    }
    public void TakeDamage(int damage);
    public void Attack();
    public void Move(double x, double y, double z)
    {
        this.coordinates = [x, y, z];
    }
}

class Warrior: Character
{
    public override void Attack()
    {
        Console.WriteLine("Воин наносит удар");
    }
    public void TakeDamage(int damage)
    {
        this.Health -= damage;
    }
}

class Mage: Character
{
    public override void Attack()
    {
        Console.WriteLine("Маг кастует заклинание");
    }
        public void TakeDamage(int damage)
    {
        this.Health -= damage;
    }
}

class Program
{
    static void Main()
    {
        Character[] mas = [new Warrior(), new Mage()];
        foreach (Character i in mas)
        {
            i.Attack();
        }
    }
}

class Tiefling: haracter
{
    public override void Attack()
    {
        Console.WriteLine("Тифлинг атакует");
    }
}