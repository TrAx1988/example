using System.Net;
using System.Net.Sockets;

namespace FullProject.Infrastructure
{

    /// <summary>
    /// Schnittstelle für einen Dienst, der die aktuelle Zeit bereitstellt.
    /// </summary>
    public interface ITimeService
    {
        /// <summary>
        /// Gibt die aktuelle Zeit zurück.
        /// </summary>
        /// <returns>Die aktuelle Zeit als <see cref="DateTime"/>.</returns>
        Task<DateTime> GetCurrentDateTimeAsync();
    }


    /// <summary>
    /// Liefert die aktuelle Systemzeit.
    /// </summary>
    public class SystemTimeService : ITimeService
    {
        public Task<DateTime> GetCurrentDateTimeAsync()
        {
            return Task.FromResult(DateTime.UtcNow);
        }
    }

    /// <summary>
    /// Liefert die aktuelle Zeit von einem NTP-Server.
    /// </summary>
    public class NtpTimeService : ITimeService
    {
        private readonly string _ntpServer;

        public NtpTimeService(string ntpServer = "pool.ntp.org")
        {
            _ntpServer = ntpServer;
        }

        public async Task<DateTime> GetCurrentDateTimeAsync()
        {
            // NTP-Paket vorbereiten
            var ntpData = new byte[48];
            ntpData[0] = 0x1B;

            var addresses = await Dns.GetHostAddressesAsync(_ntpServer);
            var ipEndPoint = new IPEndPoint(addresses[0], 123);

            using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Connect(ipEndPoint);
            socket.Send(ntpData);
            socket.ReceiveTimeout = 3000;
            socket.Receive(ntpData);

            const byte serverReplyTime = 40;
            ulong intPart = (ulong)ntpData[serverReplyTime] << 24 |
                            (ulong)ntpData[serverReplyTime + 1] << 16 |
                            (ulong)ntpData[serverReplyTime + 2] << 8 |
                            (ulong)ntpData[serverReplyTime + 3];

            ulong fractPart = (ulong)ntpData[serverReplyTime + 4] << 24 |
                              (ulong)ntpData[serverReplyTime + 5] << 16 |
                              (ulong)ntpData[serverReplyTime + 6] << 8 |
                              (ulong)ntpData[serverReplyTime + 7];

            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
            var networkDateTime = new DateTime(1900, 1, 1).AddMilliseconds((long)milliseconds);

            return networkDateTime.ToUniversalTime();
        }
    }
}
