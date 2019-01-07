using System;

namespace Server
{
    public class Program
    {
        private const int PORT = 7070;

        public static void Main(string[] args)
        {
            Server server = new Server(PORT);
            server.Start();

            Console.ReadLine();
        }
    }
}
