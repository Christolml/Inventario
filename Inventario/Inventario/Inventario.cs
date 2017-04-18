using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Inventario
{
    class Inventario
    {
        Producto[] vectorPro = new Producto[15];
        int contador = 0;
        bool aviso;


        public void agregar(Producto producto)
        {
            if (contador <= 15)
            {
                if (buscarInicio(producto.codigo) == false)
                {
                    vectorPro[contador] = producto;
                    contador++;
                }
            }
            else
                MessageBox.Show("Cantidad excedida");
        }

        public bool buscarInicio(int codigo)
        {
            bool mostrar = false;

            for (int i = 0; i < contador; i++)
            {
                if (codigo == vectorPro[i].codigo)
                    mostrar = true;
            }
            return mostrar;
        }

        public void eliminar(int codigo)
        {
            for (int i = 0; i < contador; i++)
            {
                if (codigo == vectorPro[i].codigo)
                {
                    for(int a=i;a<(contador-1);a++)
                    {
                        vectorPro[a] = vectorPro[a + 1];
                    }
                    MessageBox.Show("Se elimino");
                }
            }
            vectorPro[contador - 1] = null;
            contador--;

        }



        public Producto  buscar(int codigo)
        {
            Producto  mostrar = null;

            for(int i=0;i<contador;i++)
            {
                if (codigo == vectorPro[i].codigo)
                    mostrar = vectorPro[i];
            }
            return mostrar;
        }

        public bool insertar(Producto producto, int posicion)
        {
            if (buscarInicio(producto.codigo) == false)
            {
                int posNuevo = contador;
                if (posicion <= (contador - 1) && posicion >= 0)
                {
                    for (int i = 0; i < contador; i++)
                    {
                        if (posicion == i)    //la i estaria representando a la posición de mi prodcuto que ya tengo en el vector
                        {
                            for (int a = i; a <= (contador - 1); a++)
                            {
                                vectorPro[posNuevo] = vectorPro[posNuevo - 1];
                                posNuevo--;
                            }
                            vectorPro[posicion] = producto;
                        }
                    }
                    contador++;
                    aviso = true;
                }
                else
                    aviso = false;

            }
            return aviso;
        }

        public string reporte()
        {
            string mostrar = "";

            for(int i=0;i<contador;i++)
            {
                mostrar += vectorPro[i].ToString() + "\r\n";
            }
            return mostrar;
        }
    }
}
