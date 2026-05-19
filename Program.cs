namespace fishCs
{
    public class Program
    {
        static ServerConnection server;
        static List<Fish> list = [];
        static async Task Main()
        {
            server = new ServerConnection("http://127.1.1.1:3000");
            bool run = true;

            list = (await server.Get());

            do
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.DarkCyan; Console.WriteLine("\n\n\tAll fishes: "); Console.ForegroundColor = ConsoleColor.Gray; list.ForEach(x => Console.WriteLine(x));

                // 1.
                Console.ForegroundColor = ConsoleColor.DarkCyan; Console.Write("\n\tNumber of fishes: "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine(list.Count());
                // 3.
                Console.ForegroundColor = ConsoleColor.DarkCyan; Console.Write("\n\tSum of the fishes' weights: "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine(Math.Round(list.Select(x => x.weight).Sum(), 6) + " kg");


                Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\n\t(R) Refresh");
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\t(Esc) Exit"); Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("\n\t> ");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.R:
                        list = (await server.Get());
                        break;
                    case ConsoleKey.Escape:
                        run = false;
                        break;
                    default:
                        break;
                }
            }
            while (run);
        }
    }
}
