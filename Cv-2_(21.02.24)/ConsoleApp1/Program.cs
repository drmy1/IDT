class Point
{
    private double x, y;

    public Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public double getX() { return x; }

    public double getY() { return y; }


    public void setX(double x) 
    {  
        this.x = x; 
    }

    public void setY(double y) 
    {
        this.y = y;
    }

    public double DistanceTo(Point b)
    {
        double deltaX = b.getX() - this.x;
        double deltaY = b.getY() - this.y;
        return Math.Sqrt(deltaX*deltaX + deltaY*deltaY);
    }

    static void Main() 
    { 
        Point a = new Point(5, 5);
        Point b = new Point(7, 7);

        Console.WriteLine("Vzdalenost: "+ a.DistanceTo(b));

        Point[] pole = new Point[] { a, b };
        Map m = new Map(pole);
    }
}

class Map
{
    Point[] body;

    public
}
