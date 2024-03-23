/**
 * Tri varianty odstraneni duplicitnich hodnot z pole
 */
public class RemoveDuplicates
{

    /**
	 * Odstrani z pole prvek na indexu index
	 */
    public static int[] RemoveItem(int[] data, int index)
    {
        //vysledne pole bude o 1 kratsi
        int[] result = new int[data.Length - 1];
        //zkopirujeme prvky az do indexu i
        for (int i = 0; i < index; i++)
        {
            result[i] = data[i];
        }
        //i-ty prvek preskocime a zkopirujeme vsechny zbyvajici prvky
        for (int i = index + 1; i < data.Length; i++)
        {
            result[i - 1] = data[i];
        }
        return result;
    }

    /**
	 * Prochazi vsechny polozky a odstranuje duplikaty metodou removeItem()
	 */
    public static int[] RemoveDuplicates1(int[] data)
    {
        int[] result = data;
        for (int i = 0; i < result.Length; i++)
        {
            for (int j = i + 1; j < result.Length; j++)
            {
                if (result[j] == result[i])
                {
                    result = RemoveItem(result, j);
                    j--;
                }
            }
        }
        return result;
    }

    /**
	 * Prochazi vsechny polozky a provadi ostraneni vsech duplikatu jedne polozky najednou
	 */
    public static int[] RemoveDuplicates2(int[] data)
    {
        int[] result = data;
        for (int i = 0; i < result.Length; i++)
        {
            //spocteme, kolik ma polozka result[i] duplikatu
            int count = 0; //pocet duplikatu
            for (int j = i + 1; j < result.Length; j++)
            {
                if (result[j] == result[i])
                {
                    count++;
                }
            }
            //pokud je alespon jeden duplikat, pak ho odstranime
            if (count > 0)
            {
                //vysledek bude o count kratsi
                int[] newResult = new int[result.Length - count];
                //prvky az do indexu i muzeme jednoduse zkopirovat
                for (int k = 0; k <= i; k++)
                {
                    newResult[k] = result[k];
                }
                int index = i + 1 ; //index v cilovem poli
                for (int k = i + 1; k < result.Length; k++)
                {
                    if (result[k] != result[i])
                    { //neni duplikat
                        newResult[index] = result[k];
                        index++;
                    }
                }
                result = newResult;
            }
        }
        return result;
    }

    /**
	 * Pouziva redukci pomoci pole zaznamu, zda dane cislo bylo nalezeno v datech ci nikoli
	 */
    public static int[] RemoveDuplicates3(int[] data)
    {
        //nejdrive jen zjistime, kolik mame unikatnich cisel
        bool[] encountered = new bool[1000000];
        int count = 0; //pocet unikatnich cisel
        for (int i = 0; i < data.Length; i++)
        {
            if (!encountered[data[i]])
            { //nove objevene cislo
                encountered[data[i]] = true;
                count++;
            }
        }
        //v promenne count je ted pocet unikatnich cisel
        //pole encountered ted pouzijeme jeste jednou stejnym zpusobem
        encountered = new bool[1000000];
        int[] result = new int[count];
        int index = 0;
        for (int i = 0; i < data.Length; i++)
        {
            if (!encountered[data[i]])
            {
                result[index] = data[i];
                encountered[data[i]] = true;
                index++;
            }
        }
        return result;
    }

    /**
	 * Generuje nahodna data v rozsahu do 100 000,
	 * cimz se simuluje, ze cca 90% cisel je "neaktivnich"
	 */
    public static int[] GenerateData(int count)
    {
        int[] result = new int[count];
        Random r = new Random();
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = r.Next(100000);
        }
        return result;
    }

    public static void Main(String[] args)
    {
        int count = 30000;
        int[] data = GenerateData(count);

        int[] reducedData1 = RemoveDuplicates1(data);
        int[] reducedData2 = RemoveDuplicates2(data);
        int[] reducedData3 = RemoveDuplicates3(data);
        Console.WriteLine("All done.");
    }
}