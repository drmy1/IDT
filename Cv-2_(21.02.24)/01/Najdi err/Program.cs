﻿public enum Subject { math, computers }

public class PlanEvent
{
    /* Jmeno tutora */
    public String tutor;
    /* Hodina pocatku doucovani (10 = 10:00 atd.) */
    public int start;
    /* Hodina konce doucovani (10 = 10:00 atd.) */
    public int end;
    /* Den tydne doucovani (0 = Pondeli, 1 = Utery atd.) */
    public int dayOfWeek;
    /* Doucovany predmet */
    public Subject subject;

    /*
	 * Vytvori novou nabidku tutora na doucovani
	 */
    public PlanEvent(string tutor, int start, int end, int dayOfWeek, Subject subject)
    {
        this.tutor = tutor;
        this.start = start;
        this.end = end;
        this.dayOfWeek = dayOfWeek;
        this.subject = subject;
    }

    /*
	 * Vrati true, pokud se tato udalost prekryva se zadanou udalosti, jinak vrati false
	 */
    public bool IsInConflict(PlanEvent other)
    {
        if (this.dayOfWeek != other.dayOfWeek)
        {
            return false;
        }
        if (this.end <= other.start)
        {
            return false;
        }
        if (other.end <= this.start)
        {
            return false;
        }
        return true;
    }

    public static void Main(String[] args)
    {
        PlanEvent event1 = new PlanEvent("František Vonásek", 10, 13, 1, Subject.math);
        PlanEvent event2 = new PlanEvent("Čeněk Landsmann", 9, 12, 1, Subject.computers);
        PlanEvent event3 = new PlanEvent("Hubert Zámožný", 11, 14, 1, Subject.math);
        PlanEvent event4 = new PlanEvent("Dobromila Musilová-Wébrová", 9, 14, 1, Subject.computers);
        PlanEvent event5 = new PlanEvent("Sisoj Psoič Rispoloženskyj", 11, 12, 1, Subject.math);
        PlanEvent event6 = new PlanEvent("Billy Blaze", 8, 10, 1, Subject.computers);
        PlanEvent event7 = new PlanEvent("Flynn Taggart", 13, 15, 1, Subject.math);
        Console.WriteLine(event1.IsInConflict(event2));
        Console.WriteLine(event1.IsInConflict(event3));
        Console.WriteLine(event1.IsInConflict(event4));
        Console.WriteLine(event1.IsInConflict(event5));
        Console.WriteLine(event1.IsInConflict(event6));
        Console.WriteLine(event1.IsInConflict(event7));
    }
}

public class Plan
{
    public PlanEvent[] timetable;

    public Plan(PlanEvent[] timetable)
    {
        this.timetable = timetable; 
    }

    public bool IsConflict(Plan timetable)
    {
        
    }
}
