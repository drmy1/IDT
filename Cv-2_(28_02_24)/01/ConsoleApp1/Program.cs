/*
 * Metoda rozhoduje, zda se predana hodnota x nachazi v predanem serazenem poli
 */
static bool IntervalSubdivision(int[] data, int x)
{
    int left = 0; //leva hranice intervalu
    int right = data.Length; //prava hranice intervalu
    int mid = (left + right) / 2; //index uprostred intervalu
    while (data[mid] != x)
    {
        if (left == right)
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
static void Main(String[] args)
{
    int[] data = {1, 2, 3};
    DateTime start = DateTime.Now;
    bool found = IntervalSubdivision(data, 2);
    DateTime stop = DateTime.Now;
    Console.WriteLine("Interval subdivision finished in " + (stop - start).TotalMilliseconds * 1000 + " ns");
    Console.WriteLine("Number found: " + found);
}
