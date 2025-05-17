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

namespace CSPSS.BASE_INFO
{
    public partial class CUSTOMER_INFOT : Form
    {
        DataTable dt = new DataTable();
        basec bc=new basec ();
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
   
        protected int M_int_judge, i;
        protected int select;
        CCUSTOMER_INFO ccustomer_info = new CCUSTOMER_INFO();
        
        public CUSTOMER_INFOT()
        {
            InitializeComponent();
        }

        private void CUSTOMER_INFOT_Load(object sender, EventArgs e)
        {
            textBox1.Text = IDO;
            label10.Text = "状态中已过年审期表示在建客户信息时该车已经过了年审期";
            label14.Text = "状态中显示的年份表示该年份已经发送过短信提醒及在当天系统有提示清单";
            label10.ForeColor = CCOLOR.rose;
            label14.ForeColor = CCOLOR.rose;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            textBox2.BackColor = Color.Yellow;
            textBox3.BackColor = Color.Yellow;
            textBox4.BackColor = Color.Yellow;
            comboBox2.Text = "四川";
            textBox2.Text = "川E";
            bind();
        }
     
      
        public void a1()
        {
            dataGridView1.ReadOnly = true;
            select = 0;
        }
        public void a2()
        {
            dataGridView1.ReadOnly = true;
            select = 1;
        }

        public void ClearText()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            dateTimePicker1.Text = DateTime.Now.ToString("yyyy/MM/dd").Replace("-", "/");
            comboBox2.Text = "四川";
            textBox2.Text = "川E";
        }
   
        #region bind
        private void bind()
        {
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            textBox2.Focus();
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

            
            dt = basec.getdts(ccustomer_info.sql +" WHERE DATEDIFF(DAY,GETDATE(),DATE)>-7 AND DATEDIFF(DAY,GETDATE(),DATE)<1 ORDER BY  B.DATE DESC ");
            dt = ccustomer_info.GENERAL_ID(dt);
            if (dt.Rows.Count > 0)
            {
            
                dataGridView1.DataSource = dt;
                dgvStateControl();
            }
            else
            {
                
                dataGridView1.DataSource = null;

            }
        
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        #endregion
        private void btnAdd_Click(object sender, EventArgs e)
        {
            add();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            M_int_judge = 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            try
            {
                btnSave.Focus();
                if (juage())
                {
                    IFExecution_SUCCESS = false;
                }
                else
                {

                    save();
                    if (IFExecution_SUCCESS == true)
                    {
                        add();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);


            }
        }
        private void add()
        {
            ClearText();
            textBox1.Text = ccustomer_info.GETID();
            bind();
            ADD_OR_UPDATE = "ADD";
        }
        private void save()
        {
            ccustomer_info.EMID = LOGIN.EMID;
            ccustomer_info.CUID = textBox1.Text;
            ccustomer_info.CUSTOMER_ID = textBox2.Text;
            ccustomer_info.CNAME = textBox3.Text;
            ccustomer_info.PROVINCE = comboBox2.Text;
            ccustomer_info.CARTYPE = comboBox1.Text;
            ccustomer_info.LIMITED_DATE = dateTimePicker1.Text;
            ccustomer_info.PHONE = textBox4.Text;
            ccustomer_info.save();
            IFExecution_SUCCESS = ccustomer_info.IFExecution_SUCCESS;
            hint.Text = ccustomer_info.ErrowInfo;
            if (IFExecution_SUCCESS)
            {

                bind();
            }
              
            try
            {
       
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }


        }
        private bool juage()
        {
            bool b = false;
            if (textBox1 .Text  == "")
            {
                hint.Text = "单号不能为空！";
                b = true;
            }
           else   if (textBox2.Text == "")
           {
               hint.Text = "车牌号码不能为空！";
               b = true;
           }
           else if (textBox3.Text == "")
           {
               hint.Text = "车主姓名不能为空！";
               b = true;
           }
            else if (textBox4.Text == "")
            {
                hint.Text = "手机号不能为空！";
                b = true;
            }
            else if (bc.yesno1(textBox4 .Text )==0)
            {
                hint.Text = "手机号只能输入数字！";
                b = true;
            }
          /* else if (juage3()==0)
           {
               hint.Text = "需点选一个默认联系人！";
               b = true;
           }
           else if (juage3()>1)
           {
               hint.Text = "默认联系人只能选择一个！";
               b = true;
           }*/
            return b;
        }
        #region juage2()
        private bool juage2()
        {
            bool b = false;
            DataTable dtx = bc.GET_NOEXISTS_EMPTY_ROW_DT(dt, "", "联系人 IS NOT NULL");
            foreach (DataRow dr in dtx.Rows)
            {
                
                string v1 = dr["联系电话"].ToString();
                string v2 = dr["传真号码"].ToString();
                string v3 = dr["邮政编码"].ToString();
                string v4 = dr["公司地址"].ToString();
                string v5 = dr["QQ号"].ToString();
       
                if (bc.checkphone(v1) == false)
                {
                    b = true;
                    hint.Text = "项次" + dr["项次"].ToString() + " 电话号码只能输入数字！";

                }
                /*else if (v1 != "" && bc.exists("SELECT * FROM CUSTOMERINFO_DET WHERE PHONE='" + v1 + "' AND CUID!='" + textBox1.Text + "'"))
                {
                    b = true;
                    hint.Text = "项次" + dr["项次"].ToString() + " 电话号码已经存在！";

                }*/
                else if (bc.checkphone(v5) == false)
                {
                    b = true;
                    hint.Text = "项次" + dr["项次"].ToString() + " QQ号只能输入数字！";

                }
               /* else if (v5!="" && bc.exists("SELECT * FROM CUSTOMERINFO_DET WHERE QQ='" + v5 + "' AND CUID!='"+ textBox1 .Text +"'"))
                {
                    b = true;
                    hint.Text = "项次" + dr["项次"].ToString() + " QQ号码已经存在！";

                }*/
         
                else if (bc.checkphone(v2) == false)
                {
                    b = true;
                    hint.Text = "项次" + dr["项次"].ToString() + " 传真号码只能输入数字！";

                }
                else if (bc.checkphone(v3) == false)
                {
                    b = true;
                    hint.Text ="项次" + dr["项次"].ToString() + " 邮编只能输入数字！";

                }
                /*if (v4 == "")
                {
                 
                    hint.Text = "项次" + dr["项次"].ToString() + " 公司地址不能为空";
                    b = true;
                }*/
             
           
            }
        
            return b;
        }
        #endregion
        #region juage3()
        private int juage3()
        {
            DataTable dtx = bc.GET_NOEXISTS_EMPTY_ROW_DT(dt, "", "联系人 IS NOT NULL");
            int n = 0;
            foreach (DataRow dr in dtx.Rows)
            {
                string v1 = dr["默认联系人"].ToString();
                if (v1=="True")
                {
                    n = n + 1;

                }
            }
            return n;
        }
        #endregion
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                 if (MessageBox.Show("确定要删除该条凭证吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    basec.getcoms("DELETE CUSTOMERINFO_MST WHERE CUID='" + textBox1.Text + "'");
           
                    bind();
                    ClearText();
                    textBox1.Text = "";
                
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region override enter
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && ((!(ActiveControl is System.Windows.Forms.TextBox) ||
                !((System.Windows.Forms.TextBox)ActiveControl).AcceptsReturn)))
            {


                    SendKeys.SendWait("{Tab}");
                
                return true;
            }
            if (keyData == (Keys.Enter | Keys.Shift))
            {
                SendKeys.SendWait("+{Tab}");

                return true;
            }
            if (keyData == (Keys.F7))
            {

                //double_info();

                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
        #region dgvStateControl
        private void dgvStateControl()
        {
            int i;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Lavender;
            dataGridView1.ClearSelection();//取消默认选中列
            int numCols1 = dataGridView1.Columns.Count;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;/*自动调整DATAGRIDVIEW的列宽*/
            dataGridView1.AllowUserToAddRows = false;
            for (i = 0; i < numCols1; i++)
            {

                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                //this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.Columns[i].HeaderCell.Style.BackColor = Color.Lavender;
                dataGridView1.Columns[i].ReadOnly = true;
                dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
   
            for (i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                i = i + 1;
            }
            dataGridView1.Columns["客户编号"].Width = 80;
            dataGridView1.Columns["车牌号码"].Width = 80;
            dataGridView1.Columns["车主姓名"].Width = 80;
            dataGridView1.Columns["车辆类型"].Width = 80;
            dataGridView1.Columns["年审日期"].Width = 80;
            dataGridView1.Columns["省份"].Width = 80;
            dataGridView1.Columns["制单人"].Width = 80;
            dataGridView1.Columns["制单日期"].Width = 120;
        }
        #endregion

        private void 删除此项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string v1 = dt.Rows[dataGridView1.CurrentCell.RowIndex][0].ToString();
            string sql2 = "DELETE FROM CUSTOMERINFO_DET WHERE CUID='" + textBox1.Text + "' AND SN='" + v1 + "'";
            if (dt.Rows.Count > 0)
            {

                if (MessageBox.Show("确定要删除该条信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (!bc.exists("SELECT * FROM CUSTOMERINFO_DET WHERE CUID='" + textBox1.Text + "' AND SN='"+v1+"'"))
                    {
                        hint.Text = "此条记录还未写入数据库";
                    }
                    else  if (bc.juageOne("SELECT * FROM CUSTOMERINFO_DET WHERE CUID='" + textBox1.Text + "'"))
                    {

                        basec.getcoms(sql2);
                        string sql3 = "DELETE CUSTOMERINFO_MST WHERE CUID='" + textBox1.Text + "'";
                        basec.getcoms(sql3);
                        basec.getcoms("DELETE REMARK WHERE CUID='" + textBox1.Text + "'");
                        IFExecution_SUCCESS = false;
                        bind();
                    }
                    else
                    {

                        basec.getcoms(sql2);
                      
                        IFExecution_SUCCESS = false;
                        bind();
                    }
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

        private void btnSearch_Click(object sender, EventArgs e)
        {

            search_o();
           
          
        }

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {

                bc.dgvtoExcel(dataGridView1, "客户信息");

            }
            else
            {
                MessageBox.Show("没有数据可导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #region search_o()
        public void search_o()
        {
            StringBuilder sqb = new StringBuilder(ccustomer_info.sql);
            sqb.AppendFormat(" WHERE B.CUSTOMER_ID LIKE '%{0}%' ", textBox5.Text);
            sqb.AppendFormat(" AND B.CNAME LIKE '%{0}%' ", textBox6.Text);
       
            string sqlo = " ORDER BY B.CUID ASC";
            string v7 = bc.getOnlyString("SELECT SCOPE FROM SCOPE_OF_AUTHORIZATION WHERE USID='" + LOGIN.USID + "'");
            //string v7 = "Y";
            if (v7 == "Y")
            {
                dt = bc.getdt(sqb.ToString ()+ sqlo);
            }
            else if (v7 == "GROUP")
            {

                dt = bc.getdt(sqb.ToString() + @" AND B.MAKERID IN (SELECT EMID FROM USERINFO A WHERE USER_GROUP IN 
 (SELECT USER_GROUP FROM USERINFO WHERE USID='" + LOGIN.USID + "'))" + sqlo);
            }
            else
            {
                dt = bc.getdt(sqb.ToString() + " AND B.MAKERID='" + LOGIN.EMID + "'" + sqlo);

            }
            if (v7 == "Y")
            {
                // btnToExcel.Visible = true;

            }
            else
            {
                //btnToExcel.Visible = false;

            }
            dt = ccustomer_info.GENERAL_ID(dt);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                dgvStateControl();
              
             
            }
            else
            {
                hint.Text = "找不到所要搜索项！";
                dataGridView1.DataSource = null;

            }
        }
        #endregion
     

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                i = dataGridView1.CurrentCell.RowIndex;
                textBox1.Text = dt.Rows[i]["客户编号"].ToString();
                textBox2.Text = dt.Rows[i]["车牌号码"].ToString();
                textBox3.Text = dt.Rows[i]["车主姓名"].ToString();
                comboBox1.Text = dt.Rows[i]["车辆类型"].ToString();
                dateTimePicker1.Text = dt.Rows[i]["年审日期"].ToString();
                textBox4.Text = dt.Rows[i]["电话"].ToString();
                comboBox2.Text = dt.Rows[i]["省份"].ToString();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime d1 = dateTimePicker1.Value;

            string v1 = d1.AddMonths(-1).ToString("MM/dd");
            MessageBox.Show(v1);

        }
   
    }
}
