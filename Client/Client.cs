using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public class Client
    {
        private int PORT;

        public Client(int PORT)
        {
            this.PORT = PORT;
        }

        public void Start()
        {
            // Car obj = new Car("Tesla", "Red", "EL23400");
            string message = "Michael";

            byte[] data = Encoding.ASCII.GetBytes(message);
            IPEndPoint receiverEP = new IPEndPoint(IPAddress.Broadcast, PORT);

            using (UdpClient senderSocket = new UdpClient()) // Ingen Port
            {
                senderSocket.EnableBroadcast = true;
                senderSocket.Send(data, data.Length, receiverEP);

                IPEndPoint receiveEP = new IPEndPoint(IPAddress.Any, 0);
                byte[] inData = senderSocket.Receive(ref receiverEP);

                string inString = Encoding.ASCII.GetString(inData);

                //Console.WriteLine("Modtaget : " + inString);
            }
        }
    }
}
