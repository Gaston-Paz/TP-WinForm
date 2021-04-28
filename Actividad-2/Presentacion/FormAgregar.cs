using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace Presentacion
{
    public partial class FormAgregar : Form
    {
        public FormAgregar()
        {
            InitializeComponent();
        }

        private void lblPrecio_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Articulo nuevo = new Articulo();
            ArticuloNegocio articuloNegrocio = new ArticuloNegocio();

            try
            {
                nuevo.Nombre = txtNombre.Text;
                nuevo.Id = txtCodigo.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.UrlImagen = txtUrlImagen.Text;
                nuevo.TipoCategoria = (Categoria)cmbCategoria.SelectedItem;
                nuevo.TipoMarca = (Marca)cmbMarca.SelectedItem;

                articuloNegrocio.agregar(nuevo);
                MessageBox.Show("El artículo se agregó con éxito");
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
          
        }

        private void FormAgregar_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();

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
    }
}
