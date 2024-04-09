using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Panadería
{
    public enum TPanes { Concha, Bolillo, Croissant, Quequito, Dona, Empanada }
    public class Pan
    {
        public TPanes Nombre { get; set; }
        public decimal Precio {  get; set; }
        public byte Cantidad { get; set; }
    }
}
