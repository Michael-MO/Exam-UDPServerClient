using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class Server
    {
        private static List<string> namesList = new List<string>();
        private int PORT;

        public Server(int PORT)
        {
            this.PORT = PORT;
        }

        public void Start()
        {
            IPEndPoint removeEP = new IPEndPoint(IPAddress.Any, PORT);

            using (UdpClient receiverSocket = new UdpClient(PORT))
            {
                while (true)
                {
                    HandleOneRequest(receiverSocket, removeEP);
                }
            }
        }

        private void HandleOneRequest(UdpClient receiverSocket, IPEndPoint removeEP)
        {
            byte[] data = receiverSocket.Receive(ref removeEP);
            string inString = Encoding.ASCII.GetString(data);

            if (!namesList.Contains(inString))
            {
                namesList.Add(inString);

                Console.WriteLine("Modtaget : " + inString);
                Console.WriteLine("Sender IP : " + removeEP.Address + ", PORT : " + removeEP.Port);
            }
            else
            {
            }


            byte[] outData = Encoding.ASCII.GetBytes(inString.ToUpper());
            receiverSocket.Send(outData, outData.Length, removeEP);
        }
    }
}
