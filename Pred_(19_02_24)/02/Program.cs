class Fraction
{
    public int number, denom;

    public static void Simplify(Fraction f)
    {
        int a = f.number;
        int b = f.denom;
        while (b != 0)
        {
            int nb = a % b;
            a = b;
            b = nb;
        }
        Fraction result = new Fraction();
        result.number = f.number / a;
        result.denom = f.denom / a;
        f = result;
    }

    public static void Main(string[] args)
    {
        Fraction f = new Fraction();
        f.number = 15;
        f.denom = 5;
        Fraction.Simplify(f);
        Console.WriteLine("{0}/{1}", f.number, f.denom);
    }
}