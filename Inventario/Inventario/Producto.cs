using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario
{
    class Producto
    {

        private int _codigo;
        public int codigo { get { return _codigo; } }

        public int cantidad { get; }
        public int precio { get; }
        public string nombre;

      

        public Producto(int codigo,string nombre,int cantidad, int precio)
        {
            this._codigo = codigo;
            this.nombre = nombre;
            this.cantidad = cantidad;
            this.precio = precio;

        }


        public override string ToString()
        {

            string mostrar = "";
            mostrar = " Código del producto: " + _codigo + "\r\n Nombre del producto: " + nombre + "\r\n Cantidad del producto: "
                + cantidad + "\r\n Precio del producto: " + precio +"\r\n";
           
            return mostrar;
        }



    }
}
