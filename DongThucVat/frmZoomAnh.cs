using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DongThucVat
{
    public partial class frmZoomAnh : Form
    {
        public frmZoomAnh(Image image)
        {
            InitializeComponent();
            pbZoom.Image = image;
            pbZoom.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
