using CanvasCliente.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace CanvasCliente.Services
{
    public  class CanvasClient
    {
        TcpClient cliente = new TcpClient();
        public CanvasClient(string ip,Rectangulo rectangulo)
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(ip), 4999);
            cliente.Connect(ipe);
            Thread.Sleep(1000);
            Enviar(rectangulo);
          
        }
        public void Enviar(Rectangulo r)
        {
            try
            {
                var json = JsonConvert.SerializeObject(r);
                Byte[] buffer = Encoding.UTF8.GetBytes(json);
                var stream = cliente.GetStream();
                stream.Write(buffer,0, buffer.Length);
                stream.Flush();
            }
            catch (Exception)
            {

                Cerrar();
            }
        }

        public void Cerrar()
        {
            cliente.Close();
        }
    }
}
