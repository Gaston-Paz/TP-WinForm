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
            MarcaNegocio categoriaNegocio = new MarcaNegocio();

            try
            {
                cmbCategoria.DataSource = categoriaNegocio.listar();
                cmbMarca.DataSource = MarcaNegocio.listar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

    }
}
