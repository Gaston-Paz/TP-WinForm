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
    public partial class Form1 : Form
    {
        private List<Articulo> listaArticulos;

        public Form1()
        {
            InitializeComponent();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAgregar formAgregar = new FormAgregar();
            formAgregar.ShowDialog();
            cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FormModificar modificar = new FormModificar();
            modificar.ShowDialog();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
           
            try
            {
                listaArticulos = articuloNegocio.listar();
                dgvArticulos.DataSource = listaArticulos;
                
                dgvArticulos.Columns["Descripcion"].Visible = false;
                dgvArticulos.Columns["UrlImagen"].Visible = false;

                RecargarImg(listaArticulos[0].UrlImagen);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void RecargarImg(string img)
        {
            pbxArticulo.Load(img);
        }

        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            RecargarImg(seleccionado.UrlImagen);
        }
    }
}
