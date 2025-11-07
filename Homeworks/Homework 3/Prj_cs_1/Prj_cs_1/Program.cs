using System;

class Polynomial
{
    private int degree; //поля
    private double[] coeffs;

    public Polynomial() //конструкторы
    {
        degree = 0;
        coeffs = new double[1] { 0.0 };
    }

    public Polynomial(double[] new_coeffs)
    {
        degree = new_coeffs.Length - 1;
        coeffs = (double[])new_coeffs.Clone();
    }

    public int Degree //свойства
    {
        get { return degree; }
    }

    public double[] Coeffs
    {
        get { return (double[])coeffs.Clone(); }
    }

    public override string ToString()
    {
        string equation = "";
        if (coeffs[0] != 0.0) { equation += coeffs[0].ToString(); }
        if (coeffs[1] != 0.0)
        {
            if (coeffs[1] >= 0) { equation += " + " + coeffs[1].ToString() + "x"; }
            else { equation += " - " + (-1 * coeffs[1]).ToString(); }
        }
        for (int i = 2; i < coeffs.Length; i += 1)
        {
            if (coeffs[i] != 0.0)
            {
                if (coeffs[i] >= 0) { equation += " + " + coeffs[i].ToString() + "x^" + i.ToString(); }
                else { equation += " - " + coeffs[i].ToString() + "x^" + i.ToString(); }
            }
        }
        return equation;
    }

        public static Polynomial operator + (Polynomial obj1, Polynomial obj2)
    {
        double[] coeffs3;
        if (obj1.degree > obj2.degree)
        {
            coeffs3 = (double[])obj1.coeffs.Clone();
            for (int i = 0; i < obj2.coeffs.Length; i += 1)
            {
                coeffs3[i] += obj2.coeffs[i];
            }
        }
        else
        {
            coeffs3 = (double[])obj2.coeffs.Clone();
            for (int i = 0; i < obj1.coeffs.Length; i += 1)
            {
                coeffs3[i] += obj1.coeffs[i];
            }
        }
        Polynomial obj3 = new Polynomial(coeffs3);
        return obj3;
        }
}

    class Programm
    {
        static void Main(string[] args)
        {
        double[] coeffs = { 1.0, 0.0, 2.0 };
        Polynomial p1 = new Polynomial(coeffs); // 1 + 2x^2
        Console.WriteLine(p1);
        Polynomial p2 = new Polynomial([2.0, 3.0, 1.0]);
        Console.WriteLine(p1 + p2);
        }
    }