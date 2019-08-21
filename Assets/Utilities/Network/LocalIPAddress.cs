using System.Net;
using System.Net.Sockets;

namespace UnityUtilities.Network
{
    public abstract class LocalIPAddress
    {
        public static string GetLocalIP()
        {
            var localIP = "0.0.0.0";
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily != AddressFamily.InterNetwork) continue;

                localIP = ip.ToString();
                break;
            }

            return localIP;
        }
    }
}
