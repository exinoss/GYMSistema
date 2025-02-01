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

namespace GYMSistema.Vista.vwClases
{
    public partial class CUClases : UserControl
    {
        clsClases controllerClases = new clsClases();
        clsSocios controllerSocios = new clsSocios();
        public CUClases()
        {
            InitializeComponent();
        }
        void CargarClasesEnDgv()
        {
            dgvContenedor.DataSource = null;
            dgvContenedor.DataSource = controllerClases.ListarAll();
        }
        void LimpiarControles()
        {
            txtNombre.Text = "";
            txtHora.Text = "";
            cmbSocio.SelectedIndex = -1;
            cmbDiaSemana.SelectedIndex = -1;
            txtCupoMax.Text = "";
        }
        void CargarSociosEnCombo()
        {
            var listaSocios = controllerSocios.ListarAll();
            cmbSocio.DataSource = listaSocios;
            cmbSocio.DisplayMember = "Nombre";
            cmbSocio.ValueMember = "IdSocio";
            cmbSocio.SelectedIndex = -1;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            dtoClases c = new dtoClases();
            c.Nombre = txtNombre.Text;
            c.Hora = int.TryParse(txtHora.Text, out int horaInt) ? horaInt : 0;
            c.IdSocio = cmbSocio.SelectedIndex >= 0 ? Convert.ToInt32(cmbSocio.SelectedValue) : 0;
            c.DiaSemana = cmbDiaSemana.SelectedIndex >= 0 ? cmbDiaSemana.SelectedItem.ToString() : "";
            c.CupoMaximo = int.TryParse(txtCupoMax.Text, out int cupo) ? cupo : 0;
            if (controllerClases.RegistrarClase(c))
            {
                CargarClasesEnDgv();
                LimpiarControles();
                MessageBox.Show("Se registró correctamente");
            }
            else
            {
                MessageBox.Show("No se pudo registrar");
            }
        }

        private void CUClases_Load(object sender, EventArgs e)
        {
            CargarClasesEnDgv();
            CargarSociosEnCombo();
          
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvContenedor.SelectedRows.Count > 0)
            {
                int idClase = Convert.ToInt32(dgvContenedor.SelectedRows[0].Cells["IdClase"].Value);
                dtoClases c = new dtoClases();
                c.IdClase = idClase;
                c.Nombre = txtNombre.Text;
                c.Hora = int.TryParse(txtHora.Text, out int horaInt) ? horaInt : 0;
                c.IdSocio = cmbSocio.SelectedIndex >= 0 ? Convert.ToInt32(cmbSocio.SelectedValue) : 0;
                c.DiaSemana = cmbDiaSemana.SelectedIndex >= 0 ? cmbDiaSemana.SelectedItem.ToString() : "";
                c.CupoMaximo = int.TryParse(txtCupoMax.Text, out int cupo) ? cupo : 0;
                if (controllerClases.EditarClase(c))
                {
                    CargarClasesEnDgv();
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
                int idClase = Convert.ToInt32(dgvContenedor.SelectedRows[0].Cells["IdClase"].Value);
                if (controllerClases.EliminarClase(idClase))
                {
                    CargarClasesEnDgv();
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
                txtHora.Text = dgvContenedor.Rows[e.RowIndex].Cells["Hora"].Value.ToString();
                cmbSocio.SelectedValue = Convert.ToInt32(dgvContenedor.Rows[e.RowIndex].Cells["IdSocio"].Value);
                cmbDiaSemana.SelectedItem = dgvContenedor.Rows[e.RowIndex].Cells["DiaSemana"].Value.ToString();
                txtCupoMax.Text = dgvContenedor.Rows[e.RowIndex].Cells["CupoMaximo"].Value.ToString();
            }
        }
    }
}
