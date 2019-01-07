using System;

namespace Client
{
    public class Program
    {
        private const int PORT = 7070;
        public static void Main(string[] args)
        {
            Client client = new Client(PORT);
            client.Start();

            Console.ReadLine();
        }
    }
}
