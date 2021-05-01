﻿using System;
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
        private Articulo nuevo = null;
        public FormAgregar()
        {
            InitializeComponent();
        }

        public FormAgregar(Articulo nuevo)
        {
            InitializeComponent();
            this.nuevo = nuevo;
            Text = "Modificar Articulo";
        }

       private void btnAgregar_Click(object sender, EventArgs e)
        {
            Articulo nuevo = new Articulo();
            ArticuloNegocio articuloNegrocio = new ArticuloNegocio();

            try
            {
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;              
                nuevo.TipoMarca = (Marca)cmbMarca.SelectedItem;
                nuevo.TipoCategoria = (Categoria)cmbCategoria.SelectedItem;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.UrlImagen = txtUrlImagen.Text;
                
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
                cmbCategoria.ValueMember = "Id";
                cmbCategoria.DisplayMember = "Nombre";
                cmbMarca.ValueMember = "Id";
                cmbMarca.DisplayMember = "Nombre";

                if (nuevo != null)
                {
                    txtCodigo.Text = nuevo.Codigo;
                    txtDescripcion.Text = nuevo.Descripcion;
                    txtNombre.Text = nuevo.Nombre;
                    txtPrecio.Text = nuevo.Precio.ToString();
                    RecargarImg(nuevo.UrlImagen);
                    cmbCategoria.Text = nuevo.TipoCategoria.Nombre;
                    cmbMarca.Text = nuevo.TipoMarca.Nombre;
                    txtUrlImagen.Text = nuevo.UrlImagen;
                    cmbMarca.SelectedValue = nuevo.TipoMarca.Id;
                    cmbCategoria.SelectedValue = nuevo.TipoCategoria.Id;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Estás seguro que deseas salir? Perderás la información", "Agregar Artículo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
                Close();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 59) && e.KeyChar != 8)
                e.Handled = true;

        }

        private void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            try
            {
                RecargarImg(txtUrlImagen.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        
        private void RecargarImg(string img)
        {
            try
            {
                pbAgregar.Load(img);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            Marca nuevo = new Marca();
            Marca_Categoria marcaCategoria = new Marca_Categoria(nuevo);
            marcaCategoria.ShowDialog();
            
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Categoria nuevo = new Categoria();
            Marca_Categoria marcaCategoria = new Marca_Categoria(nuevo);
            marcaCategoria.ShowDialog();
            
        }
    }
}
