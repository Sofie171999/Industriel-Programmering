// See https://aka.ms/new-console-template for more information


using System.Net.Sockets;
using System.Text;

const string program = @"
def f():
  p1 = p[.3, -.3, .1, 0, -3.1415, 0]
  p2 = p[.2, -.3, .1, 0, -3.1415, 0]
  times = 0
  while (times < 4):
    movej(get_inverse_kin(p1))
    movej(get_inverse_kin(p2))
    times = times + 1
  end
end
";

const int urscriptPort = 30002, dashboardPort = 29999;
const string IpAddress = "localhost";

void SendString(string host, int port, string message)
{
    using var client = new TcpClient(host, port);
    using var stream = client.GetStream();
    stream.Write(Encoding.ASCII.GetBytes(message));
}

SendString(IpAddress, dashboardPort, "brake release\n");
SendString(IpAddress, urscriptPort, program);
// To stop:
// SendString(IpAddress, dashboardPort, "stop\n");