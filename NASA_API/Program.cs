namespace NASA_API;

class Program
{
    static void Main(string[] args)
    {
        NEO_Feed t = new();
        t.getData().Wait();
    }
}
