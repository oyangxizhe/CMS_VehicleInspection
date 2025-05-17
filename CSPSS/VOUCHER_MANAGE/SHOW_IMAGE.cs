using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using XizheC;

namespace CSPSS.VOUCHER_MANAGE
{
    public partial class SHOW_IMAGE : Form
    {
        DataTable dt = new DataTable();
        private string _IDO;
        public string IDO
        {
            set { _IDO = value; }
            get { return _IDO; }

        }
        private string _ADD_OR_UPDATE;
        public string ADD_OR_UPDATE
        {
            set { _ADD_OR_UPDATE = value; }
            get { return _ADD_OR_UPDATE; }
        }
        private string _IMAGE_PATH;
        public string IMAGE_PATH
        {
            set { _IMAGE_PATH = value; }
            get { return _IMAGE_PATH; }
        }
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        basec bc = new basec();
        CDECUMENTARY cDECUMENTARY = new CDECUMENTARY();

   
        protected int M_int_judge, i;
        protected int select;
        public SHOW_IMAGE()
        {
            InitializeComponent();
        }

        private void SHOW_IMAGE_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pictureBox1.Image = Image.FromStream(System.Net.WebRequest.Create(IMAGE_PATH).GetResponse().GetResponseStream());
        }

      

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    

    }
}
