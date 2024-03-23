/**
 * Zasobnik pro uchovani retezcu
 */
interface IStringStack
{
    /**
     * Prida retezec do zasobniku
     * @param s retezec, ktery ma byt pridan do zasobniku
     */
    void Add(String s);

    /**
     * Vrati retezec z vrcholu zasobniku
     */
    String Get();

    /**
     * Odstrani prvek z vrcholu zasobniku
     */
    void RemoveLast();
}

/**
 * Asistent omezujici prokrastinaci
 */
class ProcrastinationAssistant
{
    public static void Main(String[] args)
    {
        IStringStack stack = new StackArray();
        
        stack.Add("Naucit se hrat na ukulele");
        stack.Add(RandomString());
        stack.Add(RandomString());
        stack.Add(RandomString());
        stack.Add(RandomString());
        TestStack(stack);
      
    }

    /**
     * Vygeneruje a vrati nahodny retezec 
     */
    public static string RandomString()
    {
        Random r = new Random();
        String result = "";
        for (int i = 0; i < (5 + r.Next(20)); i++)
        {
            result += (char)(r.Next(24) + 65);
        }
        return result;
    }
    static void TestStack(IStringStack stack)
    {
        string[] teststack = new string[100000];

        for (int i = 0; i < 100000; i++)
        {
            teststack[i] = RandomString();
        }
        for (int i = 0; i < 100000; i++)
        {
            stack.Add(teststack[i]);
        }
        for (int i = 99999; i >= 0; i--)
        {
            if (stack.Get() == teststack[i])
            {
                stack.RemoveLast();
            }
            else throw new Exception("");
        }
    }
}
    /**
     * Implementace zasobniku retezcu pomoci pole
     */
class StackArray : IStringStack
    {
        /** Data v zasobniku */
        private String[] data;
        /** Index pozice, na kterou se vlozi novy prvek */
        private int freeIndex;

        /**
         * Vytvori novy prazdny zasobnik
         */
        public StackArray()
        {
            data = new string[5];
            freeIndex = 0;
        }

        public void Add(String s)
        {
        if (freeIndex == data.Length)
            {
                ExpandArray();
            }
        data[freeIndex] = s;
            freeIndex++;
        }

        public String Get()
        {
            return data[freeIndex-1];
        }

        public void RemoveLast()
        {
            freeIndex--;
        }

        public void ExpandArray()
        { 
            string [] datanew = new string[data.Length*2];
            for (int i = 0; i < data.Length; i++)
            {
            datanew[i] = data[i];
            }
            data = datanew;

        }
    }
