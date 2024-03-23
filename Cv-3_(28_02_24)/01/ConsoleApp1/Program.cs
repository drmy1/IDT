using System.Security.Cryptography;

class MyAPP
{ 
public static void Main(String[] args)
{
    int[] data = { 1, 3, 5, 41, 48, 52, 63, 71 };
    DateTime start = DateTime.Now;
    bool found = IntervalSubdivision(data, 53);
    DateTime stop = DateTime.Now;
    Console.WriteLine("Interval subdivision finished in " + (stop - start).TotalMilliseconds * 1000 + " ns");
    Console.WriteLine("Number found: " + found);
}
}

interface IFinder

{
    public bool Find(int x, int[] data);
}

class IntervalSubdivisionFinder : IFinder
{
 /*
 * Metoda rozhoduje, zda se predana hodnota x nachazi v predanem serazenem poli
 */
    static bool IntervalSubdivision(int[] data, int x)
    {
        int left = 0; //leva hranice intervalu
        int right = data.Length - 1; //prava hranice intervalu
        int mid = (left + right) / 2; //index uprostred intervalu
        while (data[mid] != x)
        {
            if (left >= right)
            {
                return false;
            }
            //nyni zmensime interval	
            if (data[mid] > x)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
            mid = (left + right) / 2;
        }
        return true;
    }
}

class SequentialFinder : IFinder
{
    void Find(in int[] data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            if (data[i] == x)
            {
                return true;
            }
        }
        return false;
    }
}