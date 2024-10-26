using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro
{
    [Serializable]
    public class SocketData
    {
        private int command;
        public int Command
        {
            get { return command; }
            set { command = value; }
        }


        private Point point;
        public Point Point {
            get => point;
            set => point = value;
        }

        private string message;
        public string Message { get => message; set => message = value; }

        public SocketData(int command,string message, Point point)
        {
            this.Command = command;
            this.Point = point;
            this.Message=message;
        }
    }

    public enum SocketCommand
    {
        SEND_POINT,
        NOTIFY,
        NEW_GAME,
        END_GAME,
        TIME_OUT,
        QUIT
    }

    }
