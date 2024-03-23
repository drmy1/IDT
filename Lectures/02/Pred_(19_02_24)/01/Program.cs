class Person
{
    public int month, day, year;

    public Person youngerOfTwo(Person p1, Person p2)
    {
        int p1d = p1.year * 10000 + p1.month * 100 + p1.day;
        int p2d = p2.year * 10000 + p2.month * 100 + p2.day;

        if (p1d > p2d) { return p1; }
        else return p2;
    }


    public static Person youngerOfThree(Person p1, Person p2, Person p3)
    {
        Person q = youngerOfTwo(p1, p2);
        Person r = youngerOfTwo(q, p3);
        return r;
    }
    public static void Main(string[] args)
    {
        Person person1 = new Person();
        person1.year = 2003;
        person1.month = 1;
        person1.day = 1;
        Person person2 = new Person();
        person2.year = 2004;
        person2.month = 1;
        person2.day = 1;
        Person person3 = new Person();
        person3.year = 2005;
        person3.month = 1;
        person3.day = 1;

        Person y = youngerOfThree(person1, person2 , person3);
    }
}