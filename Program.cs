namespace fishCs
{
    public class Program
    {
        static ServerConnection server;
        static async Task Main()
        {
            server = new ServerConnection("http://127.1.1.1:3000");


            Console.ForegroundColor = ConsoleColor.DarkCyan; Console.WriteLine("\n\n\tAll fishes: "); Console.ForegroundColor = ConsoleColor.Gray; (await server.Get()).ForEach(x => Console.WriteLine(x));

            Console.ForegroundColor = ConsoleColor.DarkCyan; Console.Write("\n\tNumber of fishes: "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine((await server.Get()).Count());
            Console.ForegroundColor = ConsoleColor.DarkCyan; Console.Write("\n\tSum of the fishes' weights: "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine(Math.Round((await server.Get()).Select(x => x.weight).Sum(), 6) + " kg");


            Console.ReadKey(false);
        }
    }
}
