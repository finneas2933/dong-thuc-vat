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
    public partial class ucListItem : UserControl
    {
        public ucListItem()
        {
            InitializeComponent();
        }

        #region Properties
        private string _tenloai, _ho, _bo, _lop, _nganh, _anh;
        private int _stt;
        [Category("Custom Props")]
        public string Tenloai
        {
            get { return _tenloai; }
            set { _tenloai = value; lbTenLoai.Text = value; }
        }
        [Category("Custom Props")]
        public string Ho
        {
            get { return _ho; }
            set { _ho = value; lbHo.Text = value; }
        }
        [Category("Custom Props")]
        public string Bo
        {
            get { return _bo; }
            set { _bo = value; lbBo.Text = value; }
        }
        [Category("Custom Props")]
        public string Lop
        {
            get { return _lop; }
            set { _lop = value; lbLop.Text = value; }
        }
        [Category("Custom Props")]
        public string Nganh
        {
            get { return _nganh; }
            set { _nganh = value; lbNganh.Text = value; }
        }
        [Category("Custom Props")]
        public string Anh
        {
            get { return _anh; }
            set { _anh = value; pbLoai.Image = Image.FromFile(value); }
        }
        [Category("Custom Props")]
        public int Stt
        {
            get { return _stt; }
            set { _stt = value; lbSTT.Text = value.ToString() + "."; }
        }
        #endregion
    }
}
