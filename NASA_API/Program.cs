namespace NASA_API;

class Program
{
    static void Main(string[] args)
    {
        // double test1 = 0.0291443905;
        // Console.WriteLine(test1);
        // Dictionary<string,double> test2 = new();
        // test2.Add("emi",0.3214);
        // Dictionary<string,Dictionary<string,double>> test3 = new();
        // test3.Add("luna", new Dictionary<string,double>("emi2", 14.124));
        // Console.WriteLine(test3["luna"]["emi2"]);
        
        
        //NEO_Feed t = new();
        //t.getData().Wait();

        NEO_Lookup t2 = new();
        t2.getData().Wait();
    }
}
