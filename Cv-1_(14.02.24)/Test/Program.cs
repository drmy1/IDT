//Drmota + Konečný


Console.WriteLine("x1");
int x1 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("y1");
int y1 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("z1");
int z1 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("x2");
int x2 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("y2");
int y2 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("z2");
int z2 = Convert.ToInt32(Console.ReadLine());



int det = (x1 * y2) - (x2 * y1);
if (det == 0)
{ 
Console.WriteLine("Determinant je 0");
}
else
{
int det1 = (z1 * y2) - (z2 * y1);
int det2 = (x1 * z2) - (x2 * z1);

int x = det1 / det;
int y = det2 / det;
    Console.WriteLine("x:" + x);
    Console.WriteLine("y:" + y);

}





