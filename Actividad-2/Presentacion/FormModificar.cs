using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace Presentacion
{
    public partial class FormModificar : Form
    {
        public FormModificar()
        {
            InitializeComponent();
        }

        private void FormModificar_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();

            Size = new Size(450,110);

            try
            {
                cmbCategoria.DataSource = categoriaNegocio.listar();
                cmbMarca.DataSource = marcaNegocio.listar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Articulo articulo = new Articulo();

            Size = new Size(450, 490);

            try
            {
                string codigo = txtBCodigo.Text;
                articulo = articuloNegocio.buscarArticulo("", codigo);

                txtBCodigo.Text = articulo.Codigo;
                txtNombre.Text = articulo.Nombre;
                txtDescripcion.Text = articulo.Descripcion;
                cmbCategoria.Text = articulo.TipoCategoria.Nombre;
                cmbMarca.Text = articulo.TipoMarca.Nombre;

                txtPrecio.Text = articulo.Precio.ToString();
                txtImagenUrl.Text = articulo.UrlImagen;
                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 59) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
