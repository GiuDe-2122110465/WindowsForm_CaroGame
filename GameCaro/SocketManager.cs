using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace GameCaro
{
    public class SocketManager
    {
        #region Client
        Socket client; 
        public bool ConnectServer()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), PORT);
            client = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            try
            {
                client.Connect(iep);
                return true;
            }
            catch
            {
                    return false;
            }
            return true;
        }
        #endregion

        #region Server
        Socket server;
        public void CreateServer() 
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), PORT);
            server = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
            server.Bind(iep);
            server.Listen(10);

            Thread acceptClient = new Thread(() =>
            {
                client = server.Accept();
            });
            acceptClient.IsBackground=true;
            acceptClient.Start();
        }
        #endregion

        #region Both
        public string IP = "127.0.0.1";
        public int PORT = 9999;
        public const int BUFFER = 1024;
        public bool IsServer = true;

        public bool Send(object data)
        {
              byte[] sendData=SerializeData(data);
            
                return SendData(client,sendData);
        }
        public object Receive()
        {
            byte[] receiveData=new byte[BUFFER];
            bool isOk = ReceiveData(client,receiveData);
            return DeserializeData(receiveData);
        }
        public bool SendData(Socket target, byte[] data)
        {
            return target.Send(data) == 1 ? true : false;
        }
        public bool ReceiveData(Socket target, byte[] data)
        {
           return target.Receive(data) == 1 ? true : false;
        }
        public byte[] SerializeData(object o)
        {
            MemoryStream ms = new MemoryStream();
#pragma warning disable SYSLIB0011 // Type or member is obsolete
            BinaryFormatter bf1 = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            bf1.Serialize(ms, o);
            return ms.ToArray();
        }

        public object DeserializeData(byte[] theBytesArray)
        {
            MemoryStream ms = new MemoryStream(theBytesArray);
#pragma warning disable SYSLIB0011 // Type or member is obsolete
            BinaryFormatter bf1 = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }

        public string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }
        #endregion
    }
}
