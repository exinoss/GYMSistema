using GYMSistema.Controlador;
using GYMSistema.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYMSistema.Vista.vwCliente
{
    public partial class CUSocios : UserControl
    {
        clsSocios controller = new clsSocios();
        public CUSocios()
        {
            InitializeComponent();
        }
        void CargarSociosEnDgv()
        {
            dgvContenedor.DataSource = null;
            dgvContenedor.DataSource = controller.ListarAll();
        }

        void LimpiarControles()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            dtpFechaNacimiento.Value = DateTime.Today;
        }
        private void CUSocios_Load(object sender, EventArgs e)
        {
            CargarSociosEnDgv();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            dtoSocios s = new dtoSocios();
            s.Nombre = txtNombre.Text;
            s.Apellido = txtApellido.Text;
            s.Direccion = txtDireccion.Text;
            s.Telefono = txtTelefono.Text;
            s.FechaNacimiento = dtpFechaNacimiento.Value;
            if (controller.RegistrarSocio(s))
            {
                CargarSociosEnDgv();
                LimpiarControles();
                MessageBox.Show("Se registró correctamente");
            }
            else
            {
                MessageBox.Show("No se pudo registrar");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvContenedor.SelectedRows.Count > 0)
            {
                int idSocio = Convert.ToInt32(dgvContenedor.SelectedRows[0].Cells["IdSocio"].Value);
                dtoSocios s = new dtoSocios();
                s.IdSocio = idSocio;
                s.Nombre = txtNombre.Text;
                s.Apellido = txtApellido.Text;
                s.Direccion = txtDireccion.Text;
                s.Telefono = txtTelefono.Text;
                s.FechaNacimiento = dtpFechaNacimiento.Value;
                if (controller.EditarSocio(s))
                {
                    CargarSociosEnDgv();
                    LimpiarControles();
                    MessageBox.Show("Se actualizó correctamente");
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvContenedor.SelectedRows.Count > 0)
            {
                int idSocio = Convert.ToInt32(dgvContenedor.SelectedRows[0].Cells["IdSocio"].Value);
                if (controller.EliminarSocio(idSocio))
                {
                    CargarSociosEnDgv();
                    LimpiarControles();
                    MessageBox.Show("Se eliminó correctamente");
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar");
                }
            }
        }

        private void dgvContenedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtNombre.Text = dgvContenedor.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtApellido.Text = dgvContenedor.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
                txtDireccion.Text = dgvContenedor.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();
                txtTelefono.Text = dgvContenedor.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                dtpFechaNacimiento.Value = Convert.ToDateTime(dgvContenedor.Rows[e.RowIndex].Cells["FechaNacimiento"].Value);
            }
        }
    }
}
