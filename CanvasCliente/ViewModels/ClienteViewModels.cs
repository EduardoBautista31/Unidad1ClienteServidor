using CanvasCliente.Models;
using CanvasCliente.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CanvasCliente.ViewModels
{
    public class ClienteViewModels:INotifyPropertyChanged
    {
        Rectangulo r = new Rectangulo();
        CanvasClient Client;
        public string IP { get; set; }
        public int Alto { get; set; }
        public int Ancho { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        private string colorselect;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string ColorSeleccionado
        {
            get { return colorselect; }
            set
            {
                colorselect = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ColorSeleccionado"));
            }
        }

        public ICommand EnviarCommand { get; set; }
        public ClienteViewModels()
        {
            EnviarCommand = new RelayCommand(Enviar);
        }

        private void Enviar()
        {

            if (IPAddress.TryParse(IP, out IPAddress? direccionip))
            {
                Client = new CanvasClient(direccionip.ToString(),
                    new Rectangulo
                    {
                        Alto = Alto,
                        Ancho = Ancho,
                        Fill = ColorSeleccionado,
                        CordenadaX = X,
                        CordenadaY = Y,
                    });
                //Client = new CanvasClient(direccionip.ToString(), Usuario);
            }
        }
    }
}
