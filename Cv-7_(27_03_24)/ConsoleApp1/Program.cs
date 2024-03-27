/**
 * Prichozi hovor do call centra
 */
public class IncomingCall
{
	/** Volajici cislo */
	int callingNumber;
	/** Cas kdy hovor prisel (v sekundach od zacatku smeny) */
	int time;
}

/**
 * Prvek spojoveho seznamu
 */
public class Link
{
	/** Data prvku - prichozi hovor do call centra */
	public IncomingCall data;
	/** Dalsi prvek spojoveho seznamu */
	public Link next;
}

/**
 * Fronta prichozich hovoru
 */
public class CallerQueue
{
	/** Prvni prvek fronty */
	private Link first;
	/** Posledni prvek fronty */
	private Link last;

	/**
	 * Prida prichozi hovor na konec fronty
	 * @param call prichozi hovor
	 */
	public void Add(IncomingCall call)
	{
		Link nl = new Link();
		nl.data = call;
		if (first == null)
		{
			first = nl;
			last = nl;
		}
		else
		{
			last = nl;
		}
	}

	/**
	 * Vrati prvni prichozi hovor nebo null, pokud je fronta prazdna
	 * @return prvni prichozi hovor nebo null, pokud je fronta prazdna
	 */
	public IncomingCall Get()
	{
		if (first != null)
		{
			return first.data;
		}
		else
		{
			return null;
		}
	}

	/**
	 * Odstrani prvni prichozi hovor z fronty, pokud fronta neni prazdna
	 */
	public void RemoveFirst()
	{
		if (first != null)
		{
			first = first.next;
		}
		else
		{
			Console.WriteLine("Remove call on empty queue. Probably error, continuing...");
		}
	}
}