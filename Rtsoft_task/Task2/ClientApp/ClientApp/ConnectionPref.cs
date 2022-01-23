﻿using System.Net;

namespace ClientApp
{
    public class ConnectionPref
    {
        public class Builder
        {
            public Builder SetHostNameOrAdress(string hostNameOrAdress)
            {
                activePref.IpHostInfo = Dns.GetHostEntry(hostNameOrAdress);
                return this;
            }

            public Builder SetPortNum(int portNumber)
            {
                activePref.PortNumber = portNumber;
                return this;
            }

            public Builder SetIp(IPAddress ipAddress)
            {
                activePref.IpAddress = ipAddress;
                return this;
            }

            public ConnectionPref Build() => activePref;

            private ConnectionPref activePref = new ConnectionPref();
        }

        public static Builder NewBuilder() => new Builder();

        public IPHostEntry IpHostInfo { get; private set; }

        public int PortNumber { get; private set; }

        public IPAddress IpAddress { get; private set; }
    }
}
