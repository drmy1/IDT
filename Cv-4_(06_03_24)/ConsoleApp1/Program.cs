/**
 * Hlavni trida programu pro numericky vypocet urciteho integralu
 */
public class Exercise04
{
    public static void Main(String[] args)
    {
        LinearFunction lf = new LinearFunction(0, 1);
        Integrator integrator = new Integrator();
        integrator.SetDelta(0.01);
        double integral = integrator.Integrate(lf, 0, 10);
        Console.WriteLine(integral);

        IFunction myPolynomial = new GeneralPolynomial(new double[] { 7, -5, 3, -15 });
        IFunction firstDerivative = new Derivative(myPolynomial);
        IFunction secondDerivative = new Derivative(firstDerivative);
        IFunction thirdDerivative = new Derivative(secondDerivative);

        for (double x = 0; x < 10.1; x += 0.2)
        {
            Console.WriteLine(thirdDerivative.ValueAt(x));
        }

        // jeste overeni treba pro funkci sinus
        IFunction sin = new Sine();
        IFunction cos = new Derivative(sin);
        Console.WriteLine("Cosinus");
        for (double x = 0; x < Math.PI * 2; x += 0.3)
        {
            Console.WriteLine(cos.ValueAt(x));
        }
    }
}

/**
 * Obecna matematicka funkce
 */
interface IFunction
{
    /**
	 * Vypocte a vrati hodnotu funkce v zadanem bode
	 */
    double ValueAt(double p);

    double Differentiate(double x);
}

/**
 * Trida pro numericky vypocet urciteho integralu funkce
 */
class Integrator
{
    /** Krok pro vypocet integralu */
    double delta;

    /**
	 * Numbericky vypocte a vrati urcity integral zadane fukce f od a do b
	 */
    public double Integrate(IFunction f, double a, double b)
    {
        double result = 0;
        double p = a;
        double v = f.ValueAt(p);
        while (p + delta < b)
        {
            //obdelniky sirky delta
            result += delta * v;
            p += delta;
            v = f.ValueAt(p);
        }
        // jeste posledni obdelnik, ktery bude uzsi nez delta
        result += Math.Abs(p - b) * v;
        return result;
    }

    /**
	 * Nastavi krok pro vypocet integralu
	 * @param d krok pro vypocet integralu
	 */
    public void SetDelta(double d)
    {
        this.delta = d;
    }

}

/**
 * Linerani funkce
 * @author Libor Vasa
 */
class LinearFunction : AbstractFunction
{

    /** Smernice funkce */
    double k;
    /** Posun funkce */
    double q;

    /**
	 * Vytvori novou linearni funkci se zadanymi koeficienty
	 */
    public LinearFunction(double k, double q)
    {
        this.k = k;
        this.q = q;
    }

    public override double ValueAt(double p)
    {
        return (k * p + q);
    }

}

class QuadraticPolynomial : AbstractFunction
{
    double x1, x2, x3;
    public QuadraticPolynomial(double x1, double x2, double x3)
    {
        this.x1 = x1;
        this.x2 = x2;
        this.x3 = x3;
    }

    public override double ValueAt(double p)
    {
        return (x1 * Math.Pow(p, 2) + x2 * p + x3);
    }
}

abstract class AbstractFunction : IFunction
{
    double epsilon = 0.01;

    public void Setepsilon(double epsilon)
    {
        this.epsilon = epsilon;
    }

    public abstract double ValueAt(double p);


    public double Differentiate(double x)
    {
        double h = 0.01;


        //f'(x) ~= [f(x+h) - f(x)]/h
        double f1 = (ValueAt(x + h) - ValueAt(x)) / h;
        h /= 2;
        double f2 = (ValueAt(x + h) - ValueAt(x)) / h;

        while (Math.Abs(f1 - f2) > epsilon)
        {
            f1 = f2;
            h /= 2;
            f2 = (ValueAt(x + h) - ValueAt(x)) / h;
        }

        return f1;

    }
}

class GeneralPolynomial : AbstractFunction
{
    double[] coefs;

    public GeneralPolynomial(double[] coefs)
    {
        this.coefs = coefs;
    }

    public override double ValueAt(double x)
    {
        double result = 0;
        for (int i = 0; i < coefs.Length; i++)
        {
            result += coefs[i] * Math.Pow(x, i);
        }
        return result;
    }
}

class Sine : AbstractFunction
{
    public override double ValueAt(double x)
    {
        return Math.Sin(x);
    }
}

class Derivative : AbstractFunction
{
    IFunction f;

    public Derivative(IFunction f)
    {
        this.f = f;
    }

    public override double ValueAt(double x)
    {
        return f.Differentiate(x);
    }
}