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

namespace GYMSistema.Vista.vwPagos
{
    public partial class CUPagos : UserControl
    {
        clsPagos controllerPagos = new clsPagos();
        clsSocios controllerSocios = new clsSocios();
        clsMembresia controllerMembresia = new clsMembresia();
        public CUPagos()
        {
            InitializeComponent();
        }
        void CargarPagosEnDgv()
        {
            dgvContenedor.DataSource = null;
            dgvContenedor.DataSource = controllerPagos.ListarAll();
        }

        void CargarSociosEnCombo()
        {
            var listaSocios = controllerSocios.ListarAll();
            cmbSocio.DataSource = listaSocios;
            cmbSocio.DisplayMember = "Nombre";

            cmbSocio.ValueMember = "IdSocio";
            cmbSocio.SelectedIndex = -1;
        }

        void CargarMembresiasEnCombo()
        {
            var listaMembresias = controllerMembresia.ListarAll();
            cmbMembresia.DataSource = listaMembresias;
            cmbMembresia.DisplayMember = "Tipo";
            cmbMembresia.ValueMember = "IdMembresia";
            cmbMembresia.SelectedIndex = -1;
        }

        void LimpiarControles()
        {
            cmbSocio.SelectedIndex = -1;
            cmbMembresia.SelectedIndex = -1;
            txtMonto.Text = "";
            dtpFecha.Value = DateTime.Today;
        }
        private void CUPagos_Load(object sender, EventArgs e)
        {
            CargarPagosEnDgv();
            CargarSociosEnCombo();
            CargarMembresiasEnCombo();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            dtoPagos p = new dtoPagos();
            p.IdSocio = cmbSocio.SelectedIndex >= 0 ? Convert.ToInt32(cmbSocio.SelectedValue) : 0;
            p.IdMembresia = cmbMembresia.SelectedIndex >= 0 ? Convert.ToInt32(cmbMembresia.SelectedValue) : 0;
            p.FechaPago = dtpFecha.Value;
            p.Monto = decimal.TryParse(txtMonto.Text, out decimal monto) ? monto : 0;
            if (controllerPagos.RegistrarPago(p))
            {
                CargarPagosEnDgv();
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
                int idPago = Convert.ToInt32(dgvContenedor.SelectedRows[0].Cells["IdPago"].Value);
                dtoPagos p = new dtoPagos();
                p.IdPago = idPago;
                p.IdSocio = cmbSocio.SelectedIndex >= 0 ? Convert.ToInt32(cmbSocio.SelectedValue) : 0;
                p.IdMembresia = cmbMembresia.SelectedIndex >= 0 ? Convert.ToInt32(cmbMembresia.SelectedValue) : 0;
                p.FechaPago = dtpFecha.Value;
                p.Monto = decimal.TryParse(txtMonto.Text, out decimal monto) ? monto : 0;
                if (controllerPagos.EditarPago(p))
                {
                    CargarPagosEnDgv();
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
                int idPago = Convert.ToInt32(dgvContenedor.SelectedRows[0].Cells["IdPago"].Value);
                if (controllerPagos.EliminarPago(idPago))
                {
                    CargarPagosEnDgv();
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
                int idSocio = Convert.ToInt32(dgvContenedor.Rows[e.RowIndex].Cells["IdSocio"].Value);
                int idMembresia = Convert.ToInt32(dgvContenedor.Rows[e.RowIndex].Cells["IdMembresia"].Value);
                cmbSocio.SelectedValue = idSocio;
                cmbMembresia.SelectedValue = idMembresia;
                dtpFecha.Value = Convert.ToDateTime(dgvContenedor.Rows[e.RowIndex].Cells["FechaPago"].Value);
                txtMonto.Text = dgvContenedor.Rows[e.RowIndex].Cells["Monto"].Value.ToString();
            }
        }
    }
}
