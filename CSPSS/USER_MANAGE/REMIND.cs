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
namespace CSPSS.USER_MANAGE
{
    public partial class REMIND : Form
    {
      

        basec bc = new basec();
        CUSER cuser = new CUSER();
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        private string _VOID;
        public string VOID
        {
            set { _VOID = value; }
            get { return _VOID; }

        }
        public REMIND()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void REMIND_Load(object sender, EventArgs e)
        {
            bind();
        }

    
        public  void bind()
        {
            string v1 = @"
SELECT 
A.RIID AS 传单编号,
B.BILL_ID AS 单号,
B.VOUCHER_DATE AS 出货日期,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=B.HANDLER_MAKERID) AS 下单人,
B.TABLE_TOP AS 表头,
A.SUPPLIER_LEAVE_MESSAGE AS 供应商留言,
CASE WHEN A.IF_CANCEL='Y' THEN '已作废'
ELSE '正常'
END AS 是否作废
FROM REMIND A 
LEFT JOIN VOUCHER_MST B ON A.RIID=B.VOID 
WHERE A.RIID='" + VOID +"'";
            dt = bc.getdt(v1);
           if (dt.Rows.Count > 0)
           {

           dataGridView1.DataSource = dt;
           dgvStateControl();
           }
            try
            {
               
            }
            catch (Exception)
            {

            }
            //dataGridView1.DataSource = bc.getdt(sqlo);
        }

        #region dgvStateControl
        private void dgvStateControl()
        {
            int i;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Lavender;
            int numCols1 = dataGridView1.Columns.Count;
            dataGridView1.Columns["传单编号"].Width = 80;
            dataGridView1.Columns["单号"].Width = 200;
            dataGridView1.Columns["出货日期"].Width = 80;
            dataGridView1.Columns["下单人"].Width = 80;
            dataGridView1.Columns["表头"].Width = 200;
            for (i = 0; i < numCols1; i++)
            {

                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.Columns[i].HeaderCell.Style.BackColor = Color.Lavender;

            }
            for (i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                i = i + 1;
            }
            for (i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[i].ReadOnly = true;

            }
        }
        #endregion

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            VOUCHER_MANAGE.VOUCHERT FRM = new CSPSS.VOUCHER_MANAGE.VOUCHERT(this);
            FRM.IDO = dt.Rows[dataGridView1.CurrentCell.RowIndex]["传单编号"].ToString();
            FRM.ADD_OR_UPDATE = "UPDATE";
            FRM.ShowDialog();
        }
  
    
    

     
    }
}
