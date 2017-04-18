using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        Inventario inventario = new Inventario();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //agregado sirve para decirme si ya existe el codigo ingresado cuando es true el codigo ya existe
            //cuando es false el codigo no existe y lo guarda
            bool agregado = inventario.buscarInicio(Convert.ToInt16(txtCodigo.Text));
            Producto producto = new Producto(Convert.ToInt16(txtCodigo.Text), txtNombre.Text, Convert.ToInt16(txtCantidad.Text), Convert.ToInt16(txtPrecio.Text));
            inventario.agregar(producto);
            if(agregado==false)
            {
                MessageBox.Show("Producto guardado");
                txtReporte.Text = producto.ToString();
            }
            else
            {
                MessageBox.Show("Ese código ya existe");
                txtReporte.Text = "";
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            bool agregado = inventario.buscarInicio(Convert.ToInt16(txtCodigo.Text));
            Producto producto = new Producto(Convert.ToInt16(txtCodigo.Text), txtNombre.Text, Convert.ToInt16(txtCantidad.Text), Convert.ToInt16(txtPrecio.Text));

            if (txtPos.Text=="")
            {
                inventario.agregar(producto);
                if (agregado == false)
                {
                    MessageBox.Show("Producto guardado");
                    txtReporte.Text = producto.ToString();
                }
                else
                {
                    MessageBox.Show("Ese código ya existe");
                    txtReporte.Text = "";
                }
            }
            else 
            {
                inventario.insertar(producto, Convert.ToInt16(txtPos.Text));

                if (agregado==false && inventario.insertar(producto, Convert.ToInt16(txtPos.Text)) == true)
                {
                    MessageBox.Show("Producto guardado");
                    txtReporte.Text = producto.ToString();
                }
                else if(agregado == true && inventario.insertar(producto, Convert.ToInt16(txtPos.Text)) == false)
                {
                    MessageBox.Show("Error, ese codigo ya existe");
                }
                else if(agregado == false && inventario.insertar(producto, Convert.ToInt16(txtPos.Text)) == false)
                {
                    MessageBox.Show("Error, posición fuera de rango");
                }
                else if(agregado==true && inventario.insertar(producto, Convert.ToInt16(txtPos.Text)) == true)
                {
                    MessageBox.Show("Error codigo existente y posición fuera de rango");
                    txtReporte.Text = "";
                }


            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Producto buscado = inventario.buscar(Convert.ToInt16(txtCodigoConsulta.Text));
            if (buscado != null)
            {
                txtReporte.Text = buscado.ToString();  
            }
            else
                MessageBox.Show("Error, producto no encontrado");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inventario.eliminar(Convert.ToInt16(txtCodigoConsulta.Text));
            txtReporte.Text = "";
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            txtReporte.Text = inventario.reporte();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
