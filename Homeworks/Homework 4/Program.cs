class Program
{
public static void Main()
    {
        Master mast = new Master("Виктор", 100, "ъ");
        mast.Graduation();
        Bachelor b = new Bachelor("Викто", 10, "ь");
        b.ExamsPassing();
    }
}