using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Reflection;
using XizheC;
using System.Net;
using System.Web;
using System.Xml;
using System.Collections;
using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.Adapters;
using System.Web.UI.HtmlControls;
using System.Web.Util;



namespace CSPSS.VOUCHER_MANAGE
{
    public partial class VOUCHERT : Form
    {
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        CREMIND cremind = new CREMIND();
        private string _ACID;
        public string ACID
        {
            set { _ACID = value; }
            get { return _ACID; }

        }
        private string _ACCOUNTING_PERIOD_START_DATE;
        public string ACCOUNTING_PERIOD_START_DATE
        {
            set { _ACCOUNTING_PERIOD_START_DATE = value; }
            get { return _ACCOUNTING_PERIOD_START_DATE; }

        }
        private string _ACCOUNTING_PERIOD_EXPIRATION_DATE;
        public string ACCOUNTING_PERIOD_EXPIRATION_DATE
        {
            set { _ACCOUNTING_PERIOD_EXPIRATION_DATE = value; }
            get { return _ACCOUNTING_PERIOD_EXPIRATION_DATE; }

        }
        private string _IDO;
        public string IDO
        {
            set { _IDO = value; }
            get { return _IDO; }

        }
        private string _WATER_MARK_CONTENT;
        public string WATER_MARK_CONTENT
        {
            set { _WATER_MARK_CONTENT = value; }
            get { return _WATER_MARK_CONTENT; }

        }
        private string _ADD_OR_UPDATE;
        public string ADD_OR_UPDATE
        {
            set { _ADD_OR_UPDATE = value; }
            get { return _ADD_OR_UPDATE; }
        }
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        private static bool _IF_DOUBLE_CLICK;
        public static bool IF_DOUBLE_CLICK
        {
            set { _IF_DOUBLE_CLICK = value; }
            get { return _IF_DOUBLE_CLICK; }

        }
        private static string _EMID;
        public static string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }
        private static string _ENAME;
        public static string ENAME
        {
            set { _ENAME = value; }
            get { return _ENAME; }

        }
        private static string _SUID;
        public static string SUID
        {
            set { _SUID = value; }
            get { return _SUID; }

        }
        private static string _SNAME;
        public static string SNAME
        {
            set { _SNAME = value; }
            get { return _SNAME; }

        }
        protected int i, j;
        protected int M_int_judge, t;
        basec bc = new basec();
        CVOUCHER vou = new CVOUCHER();
        ExcelToCSHARP etc = new ExcelToCSHARP();
        CFileInfo cfileinfo = new CFileInfo();
        VOUCHER F1 = new VOUCHER();
        Color c2 = System.Drawing.ColorTranslator.FromHtml("#990033");
        USER_MANAGE.REMIND F2 = new CSPSS.USER_MANAGE.REMIND();
 
        public VOUCHERT()
        {
            InitializeComponent();
        }
        public VOUCHERT(VOUCHER Frm)
        {
            InitializeComponent();
            F1 = Frm;
        }
        public VOUCHERT(USER_MANAGE .REMIND FRM)
        {
            InitializeComponent();
            F2 = FRM;
        }

        private void VOUCHERT_Load(object sender, EventArgs e)
        {

            textBox1.Text = IDO;
            textBox2.Focus();
        
            bind();
            try
            {
               
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        #region bind
        private void bind()
        {

        
            comboBox2.BackColor = Color.Yellow;
            pictureBox1.Visible = false;
            LENAME.Text = "";
            label20.Text = "";
            label21.Text = "";
            label22.Text = "";
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;

            string v1 = bc.getOnlyString("SELECT ADD_NEW FROM RIGHTLIST WHERE  USID='" + LOGIN.USID + "' AND NODE_NAME='传单作业'");
            string v2 = bc.getOnlyString("SELECT EDIT FROM RIGHTLIST WHERE  USID='" + LOGIN.USID + "' AND NODE_NAME='传单作业'");
            string v3 = bc.getOnlyString("SELECT DEL FROM RIGHTLIST WHERE  USID='" + LOGIN.USID + "' AND NODE_NAME='传单作业'");

            string v4 = bc.getOnlyString("SELECT MANAGE FROM RIGHTLIST WHERE  USID='" + LOGIN.USID + "' AND NODE_NAME='传单作业'");
            string v5 = bc.getOnlyString("SELECT FINANCIAL FROM RIGHTLIST WHERE  USID='" + LOGIN.USID + "' AND NODE_NAME='传单作业'");
            string v6 = bc.getOnlyString("SELECT GENERAL_MANAGE FROM RIGHTLIST WHERE  USID='" + LOGIN.USID + "' AND NODE_NAME='传单作业'");

            if (v1 == "Y")
            {
                btnAdd.Visible = true;
                label9.Visible = true;
                btnSave.Visible = true;
                label17.Visible = true;
                btnupload.Visible = true;
                label3.Visible = true;
                btndelfile.Visible = true;
                label6.Visible = true;
                
            }
            else
            {
                btnAdd.Visible = false;
                label9.Visible = false;
                btnSave.Visible = false;
                label17.Visible = false;
                btnupload.Visible = false;
                label3.Visible = false;
                btndelfile.Visible = false;
                label6.Visible = false;
            }
            if (v2== "Y" || v1=="Y")
            {
               
                btnSave.Visible = true;
                label17.Visible = true;
                btnupload.Visible = true;
                label3.Visible = true;
                btndelfile.Visible = true;
                label6.Visible = true;


            }
            else
            {
               
                btnSave.Visible = false;
                btnupload.Visible = false;
                label3.Visible = false;
                btndelfile.Visible = false;
                label6.Visible = false;
            }
            if (v3 =="Y")
            {
                btnDel.Visible = true;
                label5.Visible = true;
            }
            else
            {
                btnDel.Visible = false;
                label5.Visible = false;

            }
         
            if (v4 == "Y")
            {
                lkmange_audit.Visible = true;
            }
            else
            {
                lkmange_audit.Visible = false;

            }
            if (v5 == "Y")
            {
                lkfinancial_audit.Visible = true;
            }
            else
            {
                lkfinancial_audit.Visible = false;

            }
            if (v6 == "Y")
            {
                lkgeneral_manage.Visible = true;
            }
            else
            {
                lkgeneral_manage.Visible = false;

            }

         
        
            hint.Location = new Point(400, 100);
            hint.ForeColor = Color.Red;
            if (bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS) != "")
            {

                hint.Text = bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS);
            }
            else
            {
                hint.Text = "";
            }

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            DataTable dtx = basec.getdts(vou.sql +" where A.VOID='" + textBox1.Text + "' ORDER BY  A.VOID ASC ");
            if (dtx.Rows.Count > 0)
            {
                dateTimePicker1.Text  = dtx.Rows[0]["出货日期"].ToString();
                textBox2.Text = dtx.Rows[0]["单号"].ToString();
                comboBox1.Text = dtx.Rows[0]["下单人工号"].ToString();
                LENAME.Text=dtx.Rows[0]["下单人"].ToString();
                textBox3.Text = dtx.Rows[0]["表头"].ToString();
                comboBox2.Text = dtx.Rows[0]["供应商编号"].ToString();
                textBox4.Text = dtx.Rows[0]["供应商名称"].ToString();
                comboBox3.Text = dtx.Rows[0]["业务工号"].ToString();
                label20.Text=dtx.Rows[0]["业务"].ToString();
                comboBox4.Text = dtx.Rows[0]["财务工号"].ToString();
                label21.Text=dtx.Rows[0]["财务"].ToString();
                comboBox5.Text = dtx.Rows[0]["文员工号"].ToString();
                label22.Text=dtx.Rows[0]["文员"].ToString();
               
                if (!string.IsNullOrEmpty(dtx.Rows[0]["业务"].ToString()))
                {
                    checkBox1.Checked = true;
                }
                if (!string.IsNullOrEmpty(dtx.Rows[0]["财务"].ToString()))
                {
                    checkBox2.Checked = true;
                }
                if (!string.IsNullOrEmpty(dtx.Rows[0]["文员"].ToString()))
                {
                    checkBox3.Checked = true;
                }
            }
            else
            {
                
                DataTable dty = new DataTable();
                 dty = bc.getdt("SELECT A.EMID AS EMID,B.ENAME  AS ENAME FROM USERINFO A LEFT JOIN EMPLOYEEINFO B ON A.EMID=B.EMID WHERE B.DEPART='财务'");
                if (dty.Rows.Count > 0)
                {
                    comboBox4.Text = dty.Rows[0]["EMID"].ToString();
                    label21.Text = dty.Rows[0]["ENAME"].ToString();
                }
                dty = bc.getdt("SELECT A.EMID AS EMID,B.ENAME  AS ENAME FROM USERINFO A LEFT JOIN EMPLOYEEINFO B ON A.EMID=B.EMID WHERE B.DEPART='办公室'");
                if (dty.Rows.Count > 0)
                {
                    comboBox5.Text = dty.Rows[0]["EMID"].ToString();
                    label22.Text = dty.Rows[0]["ENAME"].ToString();
                }
                pictureBox1.Visible = false;
                textBox2.Text = DateTime.Now.ToString("yyyy-MM-dd").Replace("/", "-");
            }
         bind2();
         dtx = bc.getdt(cremind.sql + " WHERE A.RIID='"+textBox1 .Text +"'");
         if (dtx.Rows.Count > 0)
         {
             textBox5.Text = dtx.Rows[0]["供应商留言"].ToString();
             if (dtx.Rows[0]["是否作废"].ToString() == "已作废")
             {
                 linkLabel1.Text = "已作废";
             }
             else
             {
                 linkLabel1.Text = "正常";
             }
       
             F2.bind();
         }
         else
         {
             textBox5.Text = "";
             linkLabel1.Text = "正常";
          
        
         }
           
        }
        #endregion
        #region bind2
        private void bind2()
        {
           
            dt3 = bc.getdt(@"
SELECT cast(0   as   bit)   as   复选框,
OLDFILENAME AS 文件名,FLKEY AS 索引 FROM WAREFILE WHERE WAREID='"+textBox1 .Text +"'  AND INITIAL_OR_OTHER='INITIAL'");
            if (dt3.Rows.Count > 0)
            {

                dataGridView2.DataSource = dt3;
                dgvStateControl();
            }
            else
            {

                dataGridView2.DataSource = null;
            }
          
            //dateTimePicker1.Text = DateTime.Now.ToString("yyyy/MM/dd").Replace("-", "/");


            this.WindowState = FormWindowState.Maximized;
            Color c = System.Drawing.ColorTranslator.FromHtml("#efdaec");
     

       
            if (vou.RETURN_MANAGE_AUDIT_STATUS (textBox1 .Text ) == "Y")
            {

                lkmange_audit.Text = "业务已审核";

            }
            else
            {

                lkmange_audit.Text = "业务未审核";
            }
            if (vou.RETURN_FINANCIAL_AUDIT_STATUS (textBox1 .Text )=="Y")
            {

                lkfinancial_audit.Text = "财务已审核";
            }
            else 
            {
                lkfinancial_audit.Text = "财务未审核";
              
            }
            if (vou.RETURN_GENERAL_AUDIT_STATUS (textBox1 .Text )=="Y")
            {
                lkgeneral_manage.Text = "文员已审核";

            }
            else
            {

                lkgeneral_manage.Text = "文员未审核";
            }
            IF_DOUBLE_CLICK = false;
           


        }
        #endregion
        #region dgvStateControl
        private void dgvStateControl()
        {
            int i;
          
            dataGridView2.RowHeadersDefaultCellStyle.BackColor = Color.Lavender;
       
            int numCols2 = dataGridView2.Columns.Count;
           

            dataGridView2.Columns["复选框"].Width = 50;
            dataGridView2.Columns["文件名"].Width = 130;
            dataGridView2.Columns["索引"].Width = 130;
        
            for (i = 0; i < numCols2; i++)
            {

                dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                //this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.EnableHeadersVisualStyles = false;
                dataGridView2.Columns[i].HeaderCell.Style.BackColor = Color.Lavender;

            }
       
            for (i = 0; i < dataGridView2.Columns.Count; i++)
            {
                dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView2.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                i = i + 1;
            }

         

            dataGridView2.Columns["文件名"].ReadOnly = true;
            dataGridView2.Columns["索引"].ReadOnly = true;


        }
        #endregion
     
  
        #region override enter
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter &&(( !(ActiveControl is System.Windows.Forms.TextBox) ||
                !((System.Windows.Forms.TextBox)ActiveControl).AcceptsReturn) ))
            {
               
               

                    SendKeys.SendWait("{Tab}");
                
                return true;
            }
            if (keyData == (Keys.Enter | Keys.Shift))
            {
                SendKeys.SendWait("+{Tab}");
             
                return true;
            }
    
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private bool juage()
        {
            string v1 = bc.getOnlyString("SELECT SALE_AUDIT FROM SUPPLIERINFO_MST WHERE SUID='" + comboBox2.Text + "'");
            string v2 = bc.getOnlyString("SELECT FINANCIAL_AUDIT FROM SUPPLIERINFO_MST WHERE SUID='" + comboBox2.Text + "'");
            string v3 = bc.getOnlyString("SELECT OFFICE_AUDIT FROM SUPPLIERINFO_MST WHERE SUID='" + comboBox2.Text + "'");

            string v4 = bc.getOnlyString("SELECT MANAGE_AUDIT_STATUS FROM VOUCHER_MST WHERE VOID='"+textBox1 .Text +"'");
            string v5 = bc.getOnlyString("SELECT FINANCIAL_AUDIT_STATUS FROM VOUCHER_MST WHERE VOID='" + textBox1.Text + "'");
            string v6 = bc.getOnlyString("SELECT GENERAL_MANAGE_AUDIT_STATUS FROM VOUCHER_MST WHERE VOID='" + textBox1.Text + "'");

  
          
            bool b = false;
            if (comboBox2 .Text  == "")
            {
                hint.Text = "供应商编号不能为空！";
                b = true;
            }
            else if (!bc.exists ("SELECT * FROM SUPPLIERINFO_MST WHERE SUID='"+comboBox2 .Text +"'"))
            {
                hint.Text = "此供应商编号不存在";
                b = true;
            }
            else if (comboBox3.Text == "" && v1 == "Y" )
            {
                hint.Text = "此供应商需要业务审核，需指定业务审核员工工号";
                b = true;
            }
         
            else if (comboBox3.Text!="" && !bc.exists ("SELECT * FROM EMPLOYEEINFO WHERE EMID='"+comboBox3.Text +"'"))
            {
                hint.Text = "此工号不存于系统";
                b = true;
            }
            else if (comboBox4.Text == "" && v2 == "Y")
            {
                hint.Text = "此供应商需要财务审核，需指定财务审核员工工号";
                b = true;
            }
            else if (comboBox4.Text != "" && !bc.exists("SELECT * FROM EMPLOYEEINFO WHERE EMID='" + comboBox4.Text + "'"))
            {
                hint.Text = "此工号不存于系统";
                b = true;
            }
            else if (comboBox5.Text == "" && v3 == "Y")
            {
                hint.Text = "此供应商需要文员审核，需指定文员审核员工工号";
                b = true;
            }
            else if (comboBox5.Text != "" && !bc.exists("SELECT * FROM EMPLOYEEINFO WHERE EMID='" + comboBox5.Text + "'"))
            {
                hint.Text = "此工号不存于系统";
                b = true;
            }
            else if (v4 == "Y")
            {
                hint.Text = "此单据已经业务审核了，需撤销审核才能修改";
                b = true;
            }
            else if (v5 == "Y")
            {
                hint.Text = "此单据已经财务审核了，需撤销审核才能修改";
                b = true;
            }
            else if (v6== "Y")
            {
                hint.Text = "此单据已经文员审核了，需撤销审核才能修改";
                b = true;
            }
            else if (bc.exists("SELECT * FROM REMIND WHERE RIID='" + textBox1.Text + "'"))
            {
                b = true;
                hint.Text = "此单据已经传送到供应商客户端不能再删除与修改或撤审核";
            }
            return b;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
        }
        #region btnExcelPrint
        private void btnExcelPrint_Click(object sender, EventArgs e)
        {
  
        }
        #endregion
        private void ClearText()
        {

            dateTimePicker1.Value = DateTime.Now.Date;
            textBox2.Text = "";
            comboBox1.Text = "";
            textBox3.Text = "";
            comboBox2.Text = "";
            textBox4.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
        }
        #region save
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (juage())
            {
            }
           
            else
            {
                save();
             
                if (IFExecution_SUCCESS)
                {

                    add();
                }
            }
        }
        #endregion
        private void save()
        {
            string v1 = bc.getOnlyString("SELECT ADD_NEW FROM RIGHTLIST WHERE  USID='" + LOGIN.USID + "' AND NODE_NAME='传单作业'");
            string v2 = bc.getOnlyString("SELECT EDIT FROM RIGHTLIST WHERE  USID='" + LOGIN.USID + "' AND NODE_NAME='传单作业'");
            string v3 = bc.getOnlyString("SELECT DEL FROM RIGHTLIST WHERE  USID='" + LOGIN.USID + "' AND NODE_NAME='传单作业'");

            string v4 = bc.getOnlyString("SELECT MANAGE FROM RIGHTLIST WHERE  USID='" + LOGIN.USID + "' AND NODE_NAME='传单作业'");
            string v5 = bc.getOnlyString("SELECT FINANCIAL FROM RIGHTLIST WHERE  USID='" + LOGIN.USID + "' AND NODE_NAME='传单作业'");
            string v6 = bc.getOnlyString("SELECT GENERAL_MANAGE FROM RIGHTLIST WHERE  USID='" + LOGIN.USID + "' AND NODE_NAME='传单作业'");


            if (v1 == "Y")
            {

                btnSave.Visible = true;
                label17.Visible = true;
                btnupload.Visible = true;
                label3.Visible = true;
                btndelfile.Visible = true;
                label6.Visible = true;

            }
            else
            {

                btnSave.Visible = false;
                label17.Visible = false;
                btnupload.Visible = false;
                label3.Visible = false;
                btndelfile.Visible = false;
                label6.Visible = false;
            }
            if (v2 == "Y" || v1 == "Y")
            {

                btnSave.Visible = true;
                label17.Visible = true;
                btnupload.Visible = true;
                label3.Visible = true;
                btndelfile.Visible = true;
                label6.Visible = true;


            }
            else
            {
               
                btnSave.Visible = false;
                btnupload.Visible = false;
                label3.Visible = false;
                btndelfile.Visible = false;
                label6.Visible = false;
            }
            btnSave.Focus();
            vou.EMID = LOGIN.EMID;
            string date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace("-", "/");
            vou.VOID = textBox1.Text;
            DateTime date1 = Convert.ToDateTime(dateTimePicker1.Value);
            vou.VOUCHER_DATE = date1.ToString("yyyy/MM/dd").Replace("-", "/");
            vou.BILL_ID = textBox2.Text;
            vou.HANDLER_MAKERID = comboBox1.Text;
            vou.TABLE_TOP = textBox3.Text;
            vou.STATUS = "N";
            vou.SUID = comboBox2.Text;
            vou.MANAGE_AUDIT_STATUS = "N";
            vou.MANAGE_AUDIT_MAKERID = comboBox3.Text;
            vou.MANAGE_AUDIT_DATE = date;
            vou.FINANCIAL_AUDIT_STATUS = "N";
            vou.FINANCIAL_AUDIT_MAKERID = comboBox4.Text;
            vou.FINANCIAL_AUDIT_DATE = date;
            vou.GENERAL_MANAGE_AUDIT_STATUS = "N";
            vou.GENERAL_MANAGE_AUDIT_MAKERID = comboBox5.Text;
            vou.GENERAL_MANAGE_AUDIT_DATE = date;
            vou.MAKERID = LOGIN.EMID;
            vou.LAST_MAKERID = LOGIN.EMID;
            vou.LAST_DATE = date;
            vou.AUDIT_STYLE = bc.getOnlyString("SELECT AUDIT_STYLE FROM SUPPLIERINFO_MST WHERE SUID='"+comboBox2.Text +"'");
            if (bc.exists("SELECT * FROM VOUCHER_MST WHERE VOID='"+textBox1 .Text +"'"))
            {
                if (v2 != "Y")
                {
                    hint.Text = "您没有修改权限";
                    IFExecution_SUCCESS = false;
                }
                else
                {
                    vou.SQlcommandE(vou.sqlth + " WHERE VOID='" + textBox1.Text + "'");
                    IFExecution_SUCCESS = true;
                    bind();
                    F1.Bind();
                    F1.search();
                    string v21 = bc.getOnlyString("SELECT AUDIT_STYLE FROM VOUCHER_MST WHERE VOID='" + textBox1.Text + "'");
                    if (v21 == "NNN")
                    {
                        vou.RETURN_IF_AUDIT_COMPLETE(textBox1.Text);
                    }
                }
            }
            else if (v1 != "Y")
            {
                hint.Text = "您没有新增权限";
                IFExecution_SUCCESS = false;
            }
            else
            {
                vou.SQlcommandE(vou.sqlt);
                IFExecution_SUCCESS = true;
                bind();
                F1.Bind();
                F1.search();
                string v21 = bc.getOnlyString("SELECT AUDIT_STYLE FROM VOUCHER_MST WHERE VOID='" + textBox1.Text + "'");
                if (v21 == "NNN")
                {
                    vou.RETURN_IF_AUDIT_COMPLETE(textBox1.Text);
                }
            }
        
          
            /*if (juage2())
            {


            }
            else
            {
         
            }

            try
            {
        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
            */

        }
        private void add()
        {
            ClearText();
    
            bind();
        
            
            textBox2.Focus();

        }
        #region juage2()
        private bool juage2()
        {
            bool b = false;
            string v9 = bc.getOnlyString("SELECT GENERAL_MANAGE FROM RIGHTLIST WHERE  USID='" + LOGIN.USID + "' AND NODE_NAME='传单作业'");
           if (ADD_OR_UPDATE =="UPDATE" &&  vou.CheckIfALLOW_SAVEOR_DELETE (textBox1 .Text,LOGIN .USID  ))
            {
               
                b = true;
                hint.Text = vou.ErrowInfo;
           
            }
            else if (ADD_OR_UPDATE == "UPDATE" && bc.getOnlyString ("SELECT EDIT FROM RIGHTLIST WHERE USID='"+LOGIN .USID +"' AND NODE_NAME='传单作业'")!="Y")
            {

                b = true;
                hint.Text = "您没有修改作业的权限";

            }
            return b;
        }
        #endregion


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
        private void btnDel_Click(object sender, EventArgs e)
        {

            
            try
            {
                if (vou.CheckIfALLOW_SAVEOR_DELETE(textBox1.Text,LOGIN .USID ))
                {
                    hint.Text = vou.ErrowInfo;
                }
                else if (MessageBox.Show("确定要删除该条凭证吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    basec.getcoms("DELETE VOUCHER_MST WHERE VOID='" + textBox1.Text + "'");
                  

                   
                    bind();
                    ClearText();
                    textBox1.Text = "";
                    F1.Bind();
                    F1.search();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
        }

        #region lkmange_audit
        private void lkmange_audit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace("-", "/");
            string v1 = bc.getOnlyString("SELECT MANAGE_AUDIT_MAKERID FROM VOUCHER_MST WHERE VOID='" + textBox1.Text + "'");
           
            if (!bc.exists("SELECT * FROM VOUCHER_MST WHERE VOID='" + textBox1.Text + "'"))
            {
                hint.Text = "先保存此单据后才可审核";
            }
            /*else if (bc.getOnlyString ("SELECT SALE_AUDIT FROM SUPPLIERINFO_MST WHERE SUID='"+comboBox2 .Text +"'")!="Y")
            {
                hint.Text = "该项无审核需求，无需审核";
            }*/
            else if (string.IsNullOrEmpty(v1))
            {
                hint.Text = "该项无审核需求，无需审核";

            }
            else if (!string .IsNullOrEmpty (v1) && v1!= LOGIN.EMID)
            {

                hint.Text = "您不是指定的审核员工号 " + v1;
            }
            else if (bc.exists("SELECT * FROM REMIND WHERE RIID='" +textBox1 .Text + "'"))
            {
            
             hint .Text = "此单据已经传送到供应商客户端不能再删除与修改或撤审核";
            }
            else if (vou.RETURN_MANAGE_AUDIT_STATUS(textBox1.Text) == "N")
            {
                basec.getcoms("UPDATE VOUCHER_MST SET MANAGE_AUDIT_STATUS='Y',MANAGE_AUDIT_DATE='" + date + "' WHERE VOID='" + textBox1.Text + "'");
                bind();
                F1.Bind();
                F1.search();
                vou.RETURN_IF_AUDIT_COMPLETE(textBox1.Text);
            }
         
            else
            {

                basec.getcoms("UPDATE VOUCHER_MST SET MANAGE_AUDIT_STATUS='N',MANAGE_AUDIT_DATE='" + date + "' WHERE VOID='" + textBox1.Text + "'");
                bind();
                F1.Bind();
                F1.search();
                vou.RETURN_IF_AUDIT_COMPLETE(textBox1.Text);

            }
            try
            {

         

            }
            catch (Exception)
            {

            }
        }
        #endregion
        #region lkfinancial_audit
        private void lkfinancial_audit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace("-", "/");
            string v1 = bc.getOnlyString("SELECT FINANCIAL_AUDIT_MAKERID FROM VOUCHER_MST WHERE VOID='" + textBox1.Text + "'");
  
            try
            {
               if (!bc.exists("SELECT * FROM VOUCHER_MST WHERE VOID='" + textBox1.Text + "'"))
                {
                    hint.Text = "先保存此单据后才可审核";
                }
               else if (string.IsNullOrEmpty(v1))
               {
                   hint.Text = "该项无审核需求，无需审核";

               }
               else if (!string.IsNullOrEmpty(v1) && v1 != LOGIN.EMID)
               {

                   hint.Text = "您不是指定的审核员工号 " + v1;
               }
               else if (bc.exists("SELECT * FROM REMIND WHERE RIID='" + textBox1.Text + "'"))
               {

                   hint.Text = "此单据已经传送到供应商客户端不能再删除与修改或撤审核";
               }
                else if (vou.RETURN_FINANCIAL_AUDIT_STATUS(textBox1.Text) == "N")
                {

                    basec.getcoms("UPDATE VOUCHER_MST SET FINANCIAL_AUDIT_STATUS='Y',FINANCIAL_AUDIT_DATE='" +date  + "' WHERE VOID='" + textBox1.Text + "'");
                    bind();
                    F1.Bind();
                    F1.search();
                    vou.RETURN_IF_AUDIT_COMPLETE(textBox1.Text);
                }
         
                else
                {
                    basec.getcoms("UPDATE VOUCHER_MST SET FINANCIAL_AUDIT_STATUS='N',FINANCIAL_AUDIT_DATE='" + date  + "' WHERE VOID='" + textBox1.Text + "'");
                    bind();
                    F1.Bind();
                    F1.search();
                    vou.RETURN_IF_AUDIT_COMPLETE(textBox1.Text);

                }
            
            }
            catch (Exception)
            {


            }
        }
        #endregion
        #region lkgeneral_manage
        private void lkgeneral_manage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace("-", "/");
            string v1 = bc.getOnlyString("SELECT GENERAL_MANAGE_AUDIT_MAKERID FROM VOUCHER_MST WHERE VOID='" + textBox1.Text + "'");
      
            try
            {
                if (!bc.exists("SELECT * FROM VOUCHER_MST WHERE VOID='" + textBox1.Text + "'"))
                {
                    hint.Text = "先保存此单据后才可审核";
                }
                else if (string.IsNullOrEmpty(v1))
                {
                    hint.Text = "该项无审核需求，无需审核";

                }
                else if (!string.IsNullOrEmpty(v1) && v1 != LOGIN.EMID)
                {

                    hint.Text = "您不是指定的审核员工号 " + v1;
                }
                else if (bc.exists("SELECT * FROM REMIND WHERE RIID='" + textBox1.Text + "'"))
                {

                    hint.Text = "此单据已经传送到供应商客户端不能再删除与修改或撤审核";
                }
                else if (vou.RETURN_GENERAL_AUDIT_STATUS(textBox1.Text) == "N")
                {
                    basec.getcoms("UPDATE VOUCHER_MST SET GENERAL_MANAGE_AUDIT_STATUS='Y',GENERAL_MANAGE_AUDIT_DATE='" + date + "' WHERE VOID='" + textBox1.Text + "'");
                    bind();
                    F1.Bind();
                    F1.search();

                    vou.RETURN_IF_AUDIT_COMPLETE(textBox1.Text);
                }
          
                else
                {

                    basec.getcoms("UPDATE VOUCHER_MST SET GENERAL_MANAGE_AUDIT_STATUS='N',GENERAL_MANAGE_AUDIT_DATE='" + date + "' WHERE VOID='" + textBox1.Text + "'");
                    bind();
                    F1.Bind();
                    F1.search();
                    vou.RETURN_IF_AUDIT_COMPLETE(textBox1.Text);
                  

                }
              
            }
            catch (Exception)
            {


            }
          
        }
        #endregion 
        #region btnupload
        private void btnupload_Click(object sender, EventArgs e)
        {
            if (juage())
            {

            }
            else
            {
                WATER_MARK_CONTENT = bc.getOnlyString("SELECT WATER_MARK_CONTENT FROM SUPPLIERINFO_MST WHERE SUID='"+comboBox2 .Text +"'");
                uploadfile();
            }
            try
            {
      
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }



        }
        #endregion
        private void uploadfile()
        {

            string v2 = bc.getOnlyString("SELECT EDIT FROM RIGHTLIST WHERE USID='" + LOGIN.USID + "' AND NODE_NAME='传单作业'");
            if (v2 != "Y" && ADD_OR_UPDATE == "UPDATE")
            {
                hint.Text = "您没有修改权限不能修改上传";
            }
            else if (!bc.exists("SELECT * FROM UPLOADFILE_DOMAIN"))
            {
                hint.Text = "未设置服务器IP或域名";
            }
            else
            {
                OpenFileDialog openf = new OpenFileDialog();
                if (openf.ShowDialog() == DialogResult.OK)
                {
                    Random ro = new Random();
                    string stro = ro.Next(100, 100000000).ToString() + "-";
                    string NewName = DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + stro;
                    cfileinfo.SERVER_IP_OR_DOMAIN = bc.getOnlyString("SELECT UPLOADFILE_DOMAIN FROM UPLOADFILE_DOMAIN");
                    //cfileinfo.UploadImage(openf.FileName, Path.GetFileName(openf.FileName), textBox1 .Text );
                    //this.UploadFile(openf.FileName, System.IO.Path.GetFileName(openf.FileName), "File/", textBox1.Text);

                    string v21 = bc.FROM_RIGHT_UNTIL_CHAR(Path.GetFileName(openf.FileName), 46);

                    if (v21 == "jpeg" || v21 == "jpg" || v21 == "png" || v21 == "bmp" || v21 == "gif")
                    {
                        cfileinfo.MakeThumbnail(openf.FileName, "c:\\" + Path.GetFileName(openf.FileName), 300, 300, "Cut");
                        cfileinfo.ADD_WATER_MARK("c:\\" + Path.GetFileName(openf.FileName), "c:\\300X300" + NewName + Path.GetFileName(openf.FileName), WATER_MARK_CONTENT );

                        cfileinfo.ADD_WATER_MARK(openf.FileName, "c:\\INITIAL" + NewName + Path.GetFileName(openf.FileName), WATER_MARK_CONTENT );

                        cfileinfo.INITIAL_OR_OTHER = "INITIAL";
                        cfileinfo.UploadFile("c:\\INITIAL" + NewName + Path.GetFileName(openf.FileName), System.IO.Path.GetFileName(openf.FileName), "File/", textBox1.Text);
                        cfileinfo.INITIAL_OR_OTHER = "300X300";
                        cfileinfo.UploadFile("c:\\300X300" + NewName + Path.GetFileName(openf.FileName), System.IO.Path.GetFileName(openf.FileName), "File/", textBox1.Text);


                        if (File.Exists("c:\\300X300" + NewName + Path.GetFileName(openf.FileName)))
                        {

                            File.Delete("c:\\300X300" + NewName + Path.GetFileName(openf.FileName));
                            File.Delete("c:\\" + Path.GetFileName(openf.FileName));
                            File.Delete("c:\\INITIAL" + NewName + Path.GetFileName(openf.FileName));
                        }

                        v21 = bc.FROM_RIGHT_UNTIL_CHAR(Path.GetFileName(openf.FileName), 46);
                        string path = bc.getOnlyString("SELECT PATH FROM WAREFILE WHERE FLKEY='" + cfileinfo.FLKEY + "'");
                        path = bc.getOnlyString("SELECT PATH FROM WAREFILE WHERE FLKEY='" + cfileinfo.FLKEY + "'");
                        pictureBox1.Visible = true;
                        pictureBox1.Image = Image.FromStream(System.Net.WebRequest.Create(path).GetResponse().GetResponseStream());
                    }
                    else
                    {
                        cfileinfo.INITIAL_OR_OTHER = "INITIAL";
                        cfileinfo.UploadFile(openf.FileName, System.IO.Path.GetFileName(openf.FileName), "File/", textBox1.Text);

                    }
                    bind2();

                }
            }

        }
        #region dataGridView2_Click
        private void dataGridView2_Click(object sender, EventArgs e)
        {
            int i = dataGridView2.CurrentCell.ColumnIndex;
         
            if (dataGridView2.CurrentCell.ColumnIndex == 1)
            {
                SaveFileDialog sfl = new SaveFileDialog();
                sfl.FileName = dt3.Rows[dataGridView2.CurrentCell.RowIndex]["文件名"].ToString();
                //sfl.Filter = "*.xls|*.doc|*.xlsx|*.docx";
                if (sfl.ShowDialog() == DialogResult.OK)
                {

                    WebClient wclient = new WebClient();
                    string v1 = bc.getOnlyString("SELECT PATH FROM WAREFILE WHERE FLKEY='" + dt3.Rows[dataGridView2.CurrentCell.RowIndex]["索引"].ToString() + "'");
                    wclient.DownloadFile(v1, sfl.FileName);

                    /*DataTable dt3x = bc.getdt("SELECT * FROM WAREFILE WHERE FLKEY='" + dt3.Rows[dataGridView2.CurrentCell.RowIndex]["索引"].ToString() + "'");
                    Byte[] byte2 = (byte[])dt3x.Rows[0]["IMAGE_DATA"];
                    System.IO.File.WriteAllBytes(sfl.FileName, byte2);*/
                    hint.Text = "已下载";
                }
            }
            else if (i == 2)
            {
                string path = bc.getOnlyString("SELECT PATH FROM WAREFILE WHERE FLKEY='" + dt3.Rows[dataGridView2 .CurrentCell .RowIndex ]["索引"].ToString() + "'");

                string v21 = bc.FROM_RIGHT_UNTIL_CHAR(Path.GetFileName(path), 46);
                if (v21 == "jpeg" || v21 == "jpg" || v21 == "png" || v21 == "bmp" || v21 == "gif")
                {
                    pictureBox1.Image = Image.FromStream(System.Net.WebRequest.Create(path).GetResponse().GetResponseStream());
                    pictureBox1.Visible = true;
                    SHOW_IMAGE show_image = new SHOW_IMAGE();
                    show_image.IMAGE_PATH = path;
                    show_image.Show();

                }
                else
                {
                    pictureBox1.Visible = false;

                }

            }
            try
            {
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
        }
        #endregion
        #region btndelfile
        private void btndelfile_Click(object sender, EventArgs e)
        {
            delfile();
        }
        #endregion
        #region delfile
        public void delfile()
        {

            try
            {
                string v21 = bc.getOnlyString("SELECT EDIT FROM RIGHTLIST WHERE USID='" + LOGIN.USID + "' AND NODE_NAME='传单作业'");
                if (v21 != "Y" && ADD_OR_UPDATE == "UPDATE")
                {
                    hint.Text = "您没有修改权限不能删除文件";
                }
                else if (vou.CheckIfALLOW_SAVEOR_DELETE(textBox1.Text, LOGIN.USID))
                {
                    hint.Text = vou.ErrowInfo;
                }
                else
                {
                    if (MessageBox.Show("确定要删除该文件吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (dt3.Rows.Count > 0)
                        {

                            for (int i = 0; i < dt3.Rows.Count; i++)
                            {
                                if (dataGridView2.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True")
                                {

                                    string v2 = dt3.Rows[i]["索引"].ToString();
                                    string v3 = bc.getOnlyString("SELECT PATH FROM WAREFILE WHERE FLKEY='" + v2 + "'");
                                    string v4 = bc.FROM_RIGHT_UNTIL_CHAR(v3, 47);
                                    bc.getcom(@"INSERT INTO SERVER_DELETE_FILE(FLKEY,NEW_FILE_NAME) VALUES ('" + v2 + "','" + v4 + "')");

                                    bc.getcom("DELETE WAREFILE WHERE FLKEY='" + v2 + "'");
                                }


                            }
                            bind2();

                        }

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }


        }
        #endregion
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearText();
            IFExecution_SUCCESS = false;
            textBox1 .Text  = vou.GETID();
            bind();
        }

   

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            IF_DOUBLE_CLICK = false;
            BASE_INFO.EMPLOYEE_INFO FRM = new CSPSS.BASE_INFO.EMPLOYEE_INFO();;
            FRM.VOUCHER_USE();
            FRM.ShowDialog();
            this.comboBox1.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.comboBox1.DroppedDown = false;//使组合框不显示其下拉部分
            this.comboBox1.IntegralHeight = true;//恢复默认值
            if (IF_DOUBLE_CLICK)
            {
                comboBox1.Text = EMID;
                LENAME.Text = ENAME;
            }
            textBox3.Focus();
        }
        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            IF_DOUBLE_CLICK = false;
            BASE_INFO.SUPPLIER_INFO FRM = new CSPSS.BASE_INFO.SUPPLIER_INFO();
            FRM.GET_DATA_INT = 1;
            FRM.VOUCHER_USE();
            FRM.ShowDialog();
            this.comboBox2.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.comboBox2.DroppedDown = false;//使组合框不显示其下拉部分
            this.comboBox2.IntegralHeight = true;//恢复默认值
            if (IF_DOUBLE_CLICK)
            {
                comboBox2.Text = SUID;
                textBox4.Text = SNAME;
            }
            checkbox_info();
            //comboBox3.Focus();
        }
      
        private void checkbox_info()
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
     
            if (bc.exists("SELECT * FROM SUPPLIERINFO_MST WHERE SUID='" + comboBox2.Text + "'"))
            {
                DataTable dtx = bc.getdt("SELECT * FROM SUPPLIERINFO_MST WHERE SUID='" + comboBox2.Text + "'");
                if (dtx.Rows.Count > 0)
                {

                    if (dtx.Rows[0]["SALE_AUDIT"].ToString() == "Y")
                    {
                        checkBox1.Checked = true;
                    }
                  
                    if (dtx.Rows[0]["FINANCIAL_AUDIT"].ToString() == "Y")
                    {
                        checkBox2.Checked = true;
                    }
                
                    if (dtx.Rows[0]["OFFICE_AUDIT"].ToString() == "Y")
                    {
                        checkBox3.Checked = true;
                    }
                
                }

            }

        }

        private void comboBox3_DropDown(object sender, EventArgs e)
        {
            IF_DOUBLE_CLICK = false;
            BASE_INFO.EMPLOYEE_INFO FRM = new CSPSS.BASE_INFO.EMPLOYEE_INFO(); 
            FRM.VOUCHER_USE();
            FRM.ShowDialog();
            this.comboBox3.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.comboBox3.DroppedDown = false;//使组合框不显示其下拉部分
            this.comboBox3.IntegralHeight = true;//恢复默认值
            if (IF_DOUBLE_CLICK)
            {
                comboBox3.Text = EMID;
                label20.Text = ENAME;
            }
            comboBox4.Focus();
        }
        private void comboBox4_DropDown(object sender, EventArgs e)
        {
            IF_DOUBLE_CLICK = false;
            BASE_INFO.EMPLOYEE_INFO FRM = new CSPSS.BASE_INFO.EMPLOYEE_INFO(); 
            FRM.VOUCHER_USE();
            FRM.ShowDialog();
            this.comboBox4.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.comboBox4.DroppedDown = false;//使组合框不显示其下拉部分
            this.comboBox4.IntegralHeight = true;//恢复默认值
            if (IF_DOUBLE_CLICK)
            {
                comboBox4.Text = EMID;
                label21.Text = ENAME;
            }
            comboBox5.Focus();
        }
        private void comboBox5_DropDown(object sender, EventArgs e)
        {
            IF_DOUBLE_CLICK = false;
            BASE_INFO.EMPLOYEE_INFO FRM = new CSPSS.BASE_INFO.EMPLOYEE_INFO(); 
            FRM.VOUCHER_USE();
            FRM.ShowDialog();
            this.comboBox5.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.comboBox5.DroppedDown = false;//使组合框不显示其下拉部分
            this.comboBox5.IntegralHeight = true;//恢复默认值
            if (IF_DOUBLE_CLICK)
            {
                comboBox5.Text = EMID;
                label22.Text = ENAME;
            }
          
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataTable dtx = bc.getdt(cremind.sql + " WHERE A.RIID='" + textBox1.Text + "'");
            if (dtx.Rows.Count > 0)
            {

                string LOGIN_GROUP_NAME = bc.getOnlyString("SELECT USER_GROUP FROM USERINFO WHERE USID='" + LOGIN.USID + "'");
                if (LOGIN_GROUP_NAME == dtx.Rows[0]["供应商名称"].ToString())
                {

                    basec.getcoms("UPDATE REMIND SET IF_CANCEL='Y' WHERE RIID='" + textBox1.Text + "'");
                    IFExecution_SUCCESS = true;
                    bind();
                }
                else if(LOGIN .UNAME !="admin")
                {
                    hint.Text = "此作废为供应商或管理员操作";
                    IFExecution_SUCCESS = false;


                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
           DataTable  dtx= bc.getdt(cremind.sql+" WHERE A.RIID='"+textBox1 .Text +"'");
            if (dtx.Rows.Count > 0)
            {
               
                    string LOGIN_GROUP_NAME = bc.getOnlyString("SELECT USER_GROUP FROM USERINFO WHERE USID='" + LOGIN.USID + "'");
                    if (LOGIN_GROUP_NAME == dtx.Rows[0]["供应商名称"].ToString())
                    {

                        basec.getcoms("UPDATE REMIND SET SUPPLIER_LEAVE_MESSAGE='"+textBox5 .Text +"' WHERE RIID='"+textBox1.Text +"'");
                        IFExecution_SUCCESS = true;
                        bind();
                    }
                    else
                    {
                        hint.Text = "此留言为供应商操作";
                        IFExecution_SUCCESS = false;
                       

                    }
            }
        }

        private void VOUCHERT_SizeChanged(object sender, EventArgs e)
        {
            /*if (this.WindowState == FormWindowState.Minimized)
            {        // 在此处理最小化按钮被点击后的过程  
                MessageBox.Show("窗口被最小化啦");
                this.WindowState = FormWindowState.Normal;
                F3.form_change();
            }*/
        }

 

      
    }
}
