﻿using ServerApp.Core;
using System;
using System.Net;

namespace ServerApp.Cons
{
    class UI
    {
        public void Error(object sender, EventArgs args)
        {
            string message = ((MessageEventArgs)args).Message;
            ConsoleColor buffColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.Write("[ERROR] \t");
            Console.WriteLine(message);

            Console.ForegroundColor = buffColor;
        }

        public void Print(object sender, EventArgs args)
        {
            string message = ((MessageEventArgs)args).Message;
            ConsoleColor buffColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("[INFO] \t");
            Console.WriteLine(message);

            Console.ForegroundColor = buffColor;
        }
    }

    class Logger
    {
        public void Error(object sender, EventArgs args)
        {
        }

        public void Print(object sender, EventArgs args)
        {
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            SocketPrefs pref = 
                SocketPrefs.NewBuilder().
                SetHostNameOrAdress("localhost").
                SetIp(Dns.GetHostEntry("localhost").AddressList[0]).
                SetMaxConnections(10).
                SetPortNum(11000).
                Build();

            EventBusImpl eventBus = new EventBusImpl();

            UI ui = new UI();
            eventBus.ErrorHappened += ui.Error;
            eventBus.PrintHappened += ui.Print;


            //just immitation
            Logger log = new Logger();
            eventBus.ErrorHappened += log.Error;
            eventBus.PrintHappened += log.Print;


            TcpServer srv = new TcpServer(pref, eventBus);
            srv.Start();

            Console.ReadLine();
        }
    }
}
