using GYMSistema.Vista.vwClases;
using GYMSistema.Vista.vwCliente;
using GYMSistema.Vista.vwMembresia;
using GYMSistema.Vista.vwPagos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYMSistema.Vista
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnSocios_Click(object sender, EventArgs e)
        {
            CUSocios ControlUser = new CUSocios();
            pnlCuenco.Controls.Clear();
            ControlUser.Dock = DockStyle.Fill;
            pnlCuenco.Controls.Add(ControlUser);
        }

        private void btnMembresia_Click(object sender, EventArgs e)
        {
            CUMembresia ControlUser = new CUMembresia();
            pnlCuenco.Controls.Clear();
            ControlUser.Dock = DockStyle.Fill;
            pnlCuenco.Controls.Add(ControlUser);
        }

        private void btnClases_Click(object sender, EventArgs e)
        {
            CUClases ControlUser = new CUClases();
            pnlCuenco.Controls.Clear();
            ControlUser.Dock = DockStyle.Fill;
            pnlCuenco.Controls.Add(ControlUser);
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            CUPagos ControlUser = new CUPagos();
            pnlCuenco.Controls.Clear();
            ControlUser.Dock = DockStyle.Fill;
            pnlCuenco.Controls.Add(ControlUser);
        }
    }
}
