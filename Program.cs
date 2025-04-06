namespace Sparrow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sparrow v0.0.1");

            Simulation sim = new Simulation();
            sim.Run();
        }
    }
}
