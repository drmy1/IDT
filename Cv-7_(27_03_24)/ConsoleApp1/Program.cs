/**
 * Prichozi hovor do call centra
 */
public class IncomingCall
{
	/** Volajici cislo */
	public int callingNumber;
	/** Cas kdy hovor prisel (v sekundach od zacatku smeny) */
	public int time;
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
			last.next = nl;
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

/**
 * Odbavovani prichozich hovoru pomoci operatoru
 */
class Dispatcher {
	/** Fronta prichozich hovoru */
	private CallerQueue callerQueue;
	/** Fronta operatoru */
	private OperatorQueue operatorQueue;
	
	/**
	 * Vytvori novou instanci s prazdnymi frontami
	 */
	public Dispatcher() {
		this.callerQueue = new CallerQueue();
		this.operatorQueue = new OperatorQueue();
	}
	
	/**
	 * Zaradi prichozi hovor do fronty
	 * @param number telefonni cislo prichoziho hvoru
	 * @param time cas zacatku hovoru (v sekundach od zacatku smeny)
	 */
	public void Call(int number, int time) {
		IncomingCall call = new IncomingCall();
		call.callingNumber = number;
		call.time = time;
		callerQueue.Add(call);
	}
	
	/**
	 * Zaradi volneho operatora do fronty
	 * @param name jmeno volneho operatora
	 * @param time cas zarazeni volneho operatora do fronty (v sekundach od zacatku smeny)
	 */
	public void FreeOperator(String name, int time) {
		operatorQueue.Add(new FreeOperator(name, time)); // operator name se time sekund od zacatku smeny prihlasil jako dostupny
	}

	/**
	 * Priradi nejdele cekajici hovor z fronty nejdele cekajicimu operatorovi z fronty
	 */
	public void DispatchCall() {
	}
	
	/**
	 * Priradi zadany prichozi hovor zadanemu volnemu operatorovi 
	 * @param call prichozi hovor
	 * @param operator volny operator
	 */
	private void AssignCall(IncomingCall call, FreeOperator operator) {
		Console.WriteLine(operator.name + " is answering call from +420 " + call.callingNumber);
		Console.WriteLine("The caller has waited for " + Math.max(0, operator.time - call.time) + " seconds.");
	}
}

public class CallDispatching {
	public static void Main(String[] args) {
		Dispatcher d = new Dispatcher();
		d.FreeOperator("Tonda", 0);
		d.DispatchCall();
		d.FreeOperator("Jarmila", 10);
		d.DispatchCall();
		d.Call(608123456, 15);
		d.DispatchCall();
		d.Call(723987654, 35);
		d.DispatchCall();
		d.Call(602112233, 45);
		d.DispatchCall();
		d.FreeOperator("Pepa", 62);
		d.DispatchCall();
		d.Call(608987654, 124);
		d.DispatchCall();
		d.FreeOperator("Tonda", 240);
		d.DispatchCall();
	}
}