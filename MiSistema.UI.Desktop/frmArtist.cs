using MiSistema.Data;
using MiSistema.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiSistema.UI.Desktop
{
    public partial class frmArtist : Form
    {

        public frmArtist()
        {
            InitializeComponent();
        }

        private void btnCantidad_Click(object sender, EventArgs e)
        {
            var artistaDA = new ArtistDA();
            lblCantidad.Text = artistaDA.Count().ToString();

            var filtroByName = $"%{txtFiltroByName.Text}%";

            dgvListado.DataSource = artistaDA.Gets(filtroByName);
            dgvListado.Refresh();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var frm = new frmInsertArtist();
            frm.ShowDialog();
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var artist = (Artist)dgvListado.Rows[e.RowIndex].DataBoundItem;
            var frm = new frmInsertArtist();
            frm.Artist = artist;
            frm.ShowDialog();
        }
        
    }
}
