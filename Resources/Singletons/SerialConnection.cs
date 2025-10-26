using System.IO.Ports;

namespace Resources.Singletons
{
    internal sealed class SerialConnection
    {
        private static SerialPort serialPort;

        internal static SerialPort GetInstance(string port)
        {
            if (serialPort == null || serialPort.PortName != port)
            {
                if (serialPort != null)
                {
                    if (serialPort.IsOpen) serialPort.Close();

                    serialPort.Dispose();
                }

                serialPort = new SerialPort(port, 9600, Parity.None, 8, StopBits.One);
                serialPort.Handshake = Handshake.None;
                serialPort.ReadTimeout = 5000;
                serialPort.WriteTimeout = 5000;
            }
            return serialPort;
        }
    }
}
