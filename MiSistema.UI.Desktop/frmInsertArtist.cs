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
    public partial class frmInsertArtist : Form
    {
        public Artist Artist { get; set; }
        public frmInsertArtist()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            var artistDA = new ArtistDA();
            var artist = new Artist();

            artist.Name = txtName.Text.Trim();

            if (this.Artist != null)
            {
                
                artist.ArtistID = this.Artist.ArtistID;
                artistDA.Update(artist);
            }
            else
            {
                artistDA.Insert(artist);
            }

            this.Close();
        }

        private void frmInsertArtist_Load(object sender, EventArgs e)
        {
            if (this.Artist!=null)// editando el artista
            {
                txtName.Text = this.Artist.Name;
            }
        }
    }
}
