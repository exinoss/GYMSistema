using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYMSistema.Vista.vwReportes
{
    public partial class CUReporte : UserControl
    {
        public CUReporte()
        {
            InitializeComponent();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void CUReporte_Load(object sender, EventArgs e)
        {
            DataSetMembresia ds = new DataSetMembresia();
            var adapter = new DataSetMembresiaTableAdapters.sp_ReporteMembresiasActivasTableAdapter();
            adapter.Fill(ds.sp_ReporteMembresiasActivas);

            reportViewer1.LocalReport.DataSources.Clear();


            var dt = ds.sp_ReporteMembresiasActivas as System.Data.DataTable;

            if (dt != null)
            {
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetMemebresias", dt));
            }

            reportViewer1.RefreshReport();

        }
    }
}
