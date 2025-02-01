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

namespace GYMSistema.Vista.vwMembresia
{
    public partial class CUMembresia : UserControl
    {
        clsMembresia controller = new clsMembresia();
        public CUMembresia()
        {
            InitializeComponent();
        }

        void CargarMembresiasEnDgv()
        {
            dgvContenedor.DataSource = null;
            dgvContenedor.DataSource = controller.ListarAll();
        }

        void LimpiarControles()
        {
            txtTipo.Text = "";
            txtDuracion.Text = "";
            txtPrecio.Text = "";
            chkActiva.Checked = false;
        }
        private void CUMembresia_Load(object sender, EventArgs e)
        {
            CargarMembresiasEnDgv();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            dtoMembresia m = new dtoMembresia();
            m.Tipo = txtTipo.Text;
            m.DuracionMeses = int.TryParse(txtDuracion.Text, out int dur) ? dur : 0;
            m.Precio = decimal.TryParse(txtPrecio.Text, out decimal prc) ? prc : 0;
            m.Activa = chkActiva.Checked;
            if (controller.RegistrarMembresia(m))
            {
                CargarMembresiasEnDgv();
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
                int id = Convert.ToInt32(dgvContenedor.SelectedRows[0].Cells["IdMembresia"].Value);
                dtoMembresia m = new dtoMembresia();
                m.IdMembresia = id;
                m.Tipo = txtTipo.Text;
                m.DuracionMeses = int.TryParse(txtDuracion.Text, out int dur) ? dur : 0;
                m.Precio = decimal.TryParse(txtPrecio.Text, out decimal prc) ? prc : 0;
                m.Activa = chkActiva.Checked;
                if (controller.EditarMembresia(m))
                {
                    CargarMembresiasEnDgv();
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
                int id = Convert.ToInt32(dgvContenedor.SelectedRows[0].Cells["IdMembresia"].Value);
                if (controller.EliminarMembresia(id))
                {
                    CargarMembresiasEnDgv();
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
                txtTipo.Text = dgvContenedor.Rows[e.RowIndex].Cells["Tipo"].Value.ToString();
                txtDuracion.Text = dgvContenedor.Rows[e.RowIndex].Cells["DuracionMeses"].Value.ToString();
                txtPrecio.Text = dgvContenedor.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
                chkActiva.Checked = Convert.ToBoolean(dgvContenedor.Rows[e.RowIndex].Cells["Activa"].Value);
            }
        }
    }
}
