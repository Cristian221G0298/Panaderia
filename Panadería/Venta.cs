using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Panadería
{
    public class Venta:INotifyPropertyChanged
    {
        public List<Pan> Panes { get; set; } = new();
        public ObservableCollection<Pan> ListaPanes { get; set; } = new();
        public decimal Total { get; set; }
        public ICommand? AgregarCommand { get; set; }
        public ICommand? EliminarCommand { get; set; }
        public ICommand? ComprarCommand { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        public Venta()
        {
            AgregarCommand = new RelayCommand<Pan>(Agregar);
            EliminarCommand = new RelayCommand(Eliminar);
            ComprarCommand = new RelayCommand(Comprar);
            Panes =
            [
                new()
                {
                    Nombre = TPanes.Concha,
                    Precio = 7.5m,
                    Cantidad = 20
                },
                new()
                {
                    Nombre = TPanes.Quequito,
                    Precio = 9m,
                    Cantidad = 20
                },
                new()
                {
                    Nombre = TPanes.Croissant,
                    Precio = 12.5m,
                    Cantidad = 20
                },
                new()
                {
                    Nombre = TPanes.Empanada,
                    Precio = 8.5m,
                    Cantidad = 20
                },
                new()
                {
                    Nombre = TPanes.Dona,
                    Precio = 15m,
                    Cantidad = 25
                },
                new()
                {
                    Nombre = TPanes.Bolillo,
                    Precio = 2.5m,
                    Cantidad = 20
                }
            ];
        }
        public void Agregar(Pan p)
        {
            if(p.Cantidad == 0)
            {
                throw new ArgumentException($"Ya no hay {p.Nombre}s disponibles");
            }
            p.Cantidad--;
            Total += p.Precio;
            ListaPanes.Add(p);
            PropertyChanged?.Invoke(this, new(nameof(Total)));
        }
        public void Eliminar()
        {
            if(ListaPanes!=null)
            {
                ListaPanes.Last().Cantidad++;
                Total -= ListaPanes.Last().Precio;
                ListaPanes.Remove(ListaPanes.Last());
                PropertyChanged?.Invoke(this, new(nameof(Total)));
            }
        }
        public void Comprar()
        {
            ListaPanes.Clear();
            Total = 0;
            PropertyChanged?.Invoke(this, new(nameof(Total)));
        }
    }
}
