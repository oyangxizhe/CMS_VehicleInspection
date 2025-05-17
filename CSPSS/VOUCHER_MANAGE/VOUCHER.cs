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
    public partial class VOUCHER : Form
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dtx = new DataTable();
        basec bc = new basec();
        CREMIND cremind = new CREMIND();
        

        protected int M_int_judge, i, look;
        protected int getdata;

        Color c2 = System.Drawing.ColorTranslator.FromHtml("#990033");
        CVOUCHER vou = new CVOUCHER();
        private static DataTable _GETDT_INFO;
        public  static DataTable GETDT_INFO
        {
            set { _GETDT_INFO = value; }
            get { return _GETDT_INFO; }

        }
        private static bool _IF_DOUBLE_CLICK;
        public static bool IF_DOUBLE_CLICK
        {
            set { _IF_DOUBLE_CLICK = value; }
            get { return _IF_DOUBLE_CLICK; }

        }
        public VOUCHER()
        {
            InitializeComponent();
        }
        #region init
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VOUCHER));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnToExcel = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.hint = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.btnSearch = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(0, 242);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(943, 336);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.DataSourceChanged += new System.EventHandler(this.dataGridView1_DataSourceChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.chk2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnToExcel);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Location = new System.Drawing.Point(3, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(936, 109);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(614, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 57;
            this.label9.Text = "制单人";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(662, 51);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(121, 21);
            this.textBox2.TabIndex = 56;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(78, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 55;
            this.label8.Text = "上传编号";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(137, 79);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(173, 21);
            this.textBox1.TabIndex = 54;
            // 
            // chk2
            // 
            this.chk2.AutoSize = true;
            this.chk2.Location = new System.Drawing.Point(343, 31);
            this.chk2.Name = "chk2";
            this.chk2.Size = new System.Drawing.Size(15, 14);
            this.chk2.TabIndex = 51;
            this.chk2.UseVisualStyleBackColor = true;
            this.chk2.CheckedChanged += new System.EventHandler(this.chk2_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBox1.Items.AddRange(new object[] {
            "",
            "业务未审核",
            "业务已审核",
            "财务未审核",
            "财务已审核",
            "文员未审核",
            "文员已审核"});
            this.comboBox1.Location = new System.Drawing.Point(423, 51);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(388, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 50;
            this.label3.Text = "状态";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(598, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 49;
            this.label2.Text = "~";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "yyyy/MM/dd";
            this.dtpEndDate.Enabled = false;
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(662, 22);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(121, 21);
            this.dtpEndDate.TabIndex = 48;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "yyyy/MM/dd";
            this.dtpStartDate.Enabled = false;
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(423, 22);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(121, 21);
            this.dtpStartDate.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(364, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 46;
            this.label1.Text = "出货期间";
            // 
            // comboBox2
            // 
            this.comboBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBox2.Location = new System.Drawing.Point(137, 20);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(173, 20);
            this.comboBox2.TabIndex = 5;
       
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(66, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 44;
            this.label6.Text = "供应商代码";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(66, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 45;
            this.label7.Text = "供应商名称";
            // 
            // btnToExcel
            // 
            this.btnToExcel.FlatAppearance.BorderSize = 0;
            this.btnToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToExcel.Font = new System.Drawing.Font("宋体", 9F);
            this.btnToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnToExcel.Image")));
            this.btnToExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnToExcel.Location = new System.Drawing.Point(841, 13);
            this.btnToExcel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(50, 64);
            this.btnToExcel.TabIndex = 11;
            this.btnToExcel.Text = "导出";
            this.btnToExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnToExcel.UseVisualStyleBackColor = false;
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(137, 49);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(173, 21);
            this.textBox5.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(857, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 29;
            this.label11.Text = "退出";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(771, 95);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 28;
            this.label12.Text = "搜索";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.hint);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(936, 121);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "菜单栏";
           
            // 
            // hint
            // 
            this.hint.AutoSize = true;
            this.hint.Location = new System.Drawing.Point(421, 68);
            this.hint.Name = "hint";
            this.hint.Size = new System.Drawing.Size(29, 12);
            this.hint.TabIndex = 402;
            this.hint.Text = "hint";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(28, 95);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 24;
            this.label17.Text = "新增";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.InitialImage = null;
            this.btnAdd.Location = new System.Drawing.Point(12, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 60);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.TabStop = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.InitialImage = null;
            this.btnExit.Location = new System.Drawing.Point(843, 20);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(60, 60);
            this.btnExit.TabIndex = 19;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.InitialImage = null;
            this.btnSearch.Location = new System.Drawing.Point(757, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 60);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.TabStop = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // VOUCHER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(942, 616);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VOUCHER";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "传单查询作业";
            this.Load += new System.EventHandler(this.VOUCHER_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
  
    
        private void VOUCHER_Load(object sender, EventArgs e)
        {
           
            Bind();
        }
        #region Bind
        public void Bind()
        {
            if (bc.getOnlyString("SELECT UNAME FROM USERINFO WHERE USID='"+LOGIN .USID +"'") == "admin")
            {
                btnToExcel.Visible = true;
            }
            else
            {
                btnToExcel.Visible = false;
            }
            string v1 = bc.getOnlyString("SELECT ADD_NEW FROM RIGHTLIST WHERE USID='" + LOGIN.USID + "' AND NODE_NAME='传单作业'");

            if (v1 == "Y")
            {
                btnAdd.Visible = true;
                label17.Visible = true;
            }
            else
            {
                btnAdd.Visible = false;
                label17.Visible = false;
            }
            this.WindowState = FormWindowState.Maximized;
          
            think();
            hint.Text = "";
            hint.ForeColor = Color.Red;
        
            try
            {
            
              
            }
            catch (Exception)
            {


            }
           
        }
        #endregion
        #region think
        private void think()
        {

            dt2 = bc.getdt("SELECT * FROM SUPPLIERINFO_MST");
            AutoCompleteStringCollection inputInfoSource = new AutoCompleteStringCollection();
       
            comboBox2.Items.Clear();
            foreach (DataRow dr in dt2.Rows)
            {

                comboBox2.Items.Add(dr["SUID"].ToString() + " " + dr["SNAME"].ToString());
                inputInfoSource.Add(dr["SUID"].ToString() + " " + dr["SNAME"].ToString());
            }
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBox2.AutoCompleteCustomSource = inputInfoSource;
          
        }
        #endregion
        #region dgvStateControl
        private void dgvStateControl()
        {
            dataGridView1.Columns["传单编号"].Width = 80;
            dataGridView1.Columns["单号"].Width = 80;
            dataGridView1.Columns["出货日期"].Width =80;
            dataGridView1.Columns["下单人工号"].Width = 80;
            dataGridView1.Columns["下单人"].Width = 80;
            dataGridView1.Columns["表头"].Width = 80;
            dataGridView1.Columns["供应商编号"].Width = 80;
            dataGridView1.Columns["供应商名称"].Width = 80;
            dataGridView1.Columns["状态"].Width = 80;
            dataGridView1.Columns["业务工号"].Width = 80;
            dataGridView1.Columns["业务"].Width = 80;
            dataGridView1.Columns["财务工号"].Width = 80;
            dataGridView1.Columns["财务"].Width = 80;
            dataGridView1.Columns["文员工号"].Width = 80;
            dataGridView1.Columns["文员"].Width = 80;
            dataGridView1.Columns["制单人"].Width = 80;
            dataGridView1.Columns["制单日期"].Width = 120;


            int i;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Lavender;
            int numCols1 = dataGridView1.Columns.Count;
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
                if (i == 6)
                {
                    dataGridView1.Columns[i].ReadOnly = true;
                }
                else
                {
                    dataGridView1.Columns[i].ReadOnly = true;
                }
                if (i == 0)
                {
                    dataGridView1.Columns[i].Visible = true;

                }
            }

            
        }
        #endregion

        #region add

        #endregion
  


        #region override enter
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter &&
             (
             (
              !(ActiveControl is System.Windows.Forms.TextBox) ||
              !((System.Windows.Forms.TextBox)ActiveControl).AcceptsReturn)
             )
             )
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


        #region doubleclick
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

                VOUCHERT frm = new VOUCHERT(this);
                frm.IDO  = dt.Rows[dataGridView1.CurrentCell.RowIndex]["传单编号"].ToString();
                frm.ADD_OR_UPDATE = "UPDATE";
                frm.Show();
        }
        #endregion
        public void a2()
        {

            getdata = 1;

        }
        public void a3()
        {

            getdata = 2;

        }
   
        private void btnToExcel_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
               
                bc.dgvtoExcel(dataGridView1, "传单明细");
                
            }
            else
            {
                MessageBox.Show("没有数据可导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < dataGridView1.Columns.Count; i++)
            {
                if (dataGridView1.Columns[i].ValueType.ToString() == "System.Decimal")
                {
                    dataGridView1.Columns[i].DefaultCellStyle.Format = "#0.0000";
                    dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                }

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
          VOUCHERT frm = new VOUCHERT(this);
          frm.IDO = vou.GETID();
          frm.ADD_OR_UPDATE = "ADD";
          frm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
            try
            {
               
            }
            catch (Exception)
            {
                //MessageBox.Show("不能出现(单引号+变量+单引号)+变量的格式");

            }

        }
        #region search()
        public void search()
        {
            string v1 = dtpStartDate.Value.ToString("yyyy/MM/dd 00:00:00").Replace("-", "/");
            string v2 = dtpEndDate.Value.ToString("yyyy/MM/dd 23:59:59").Replace("-", "/");

            string v3 = dtpStartDate.Value.ToString("yyyy/MM/dd").Replace("-", "/");
            string v4 = dtpEndDate.Value.ToString("yyyy/MM/dd").Replace("-", "/");
            dt = basec.getdts(vou.sql + " ORDER BY B.SNAME ASC");
            string v5=comboBox1 .Text ;
            string v7="";
            v7 = " A.SUID LIKE '%"+bc.REMOVE_NAME (comboBox2 .Text) +"%'";
            
       
         
       
            if (chk2.Checked)
            {
             
                if (comboBox1.Text == "业务未审核")
                {


                    search_o(vou.sql + " WHERE  "+v7+" AND B.SNAME LIKE '%" + textBox5.Text +
                        "%' AND A.MANAGE_AUDIT_STATUS='N'  AND A.VOUCHER_DATE BETWEEN '" + v3 + "' AND '" + v4 +
                        "'  AND A.VOID LIKE '%" + textBox1.Text +
                        "%'  AND C.ENAME LIKE '%"+textBox2 .Text +"%'");

                }
                else    if (comboBox1.Text == "业务已审核")
                {
                  

                    search_o(vou.sql + " WHERE  "+v7+" AND B.SNAME LIKE '%" + textBox5.Text +
                        "%' AND A.MANAGE_AUDIT_STATUS='Y' AND A.FINANCIAL_AUDIT_STATUS='N' AND A.GENERAL_MANAGE_AUDIT_STATUS='N' AND A.VOUCHER_DATE BETWEEN '" + v3 + "' AND '" + v4 +
                        "'  AND A.VOID LIKE '%" + textBox1.Text +
                        "%'  AND C.ENAME LIKE '%" + textBox2.Text + "%'");
                     
                }
                else if (comboBox1.Text == "财务未审核")
                {

                    search_o(vou.sql + " WHERE  "+v7+" AND B.SNAME LIKE '%" + textBox5.Text +
                        "%' AND A.FINANCIAL_AUDIT_STATUS='N' AND A.VOUCHER_DATE BETWEEN '" + v3 + "' AND '" + v4 +
                        "' AND A.VOID LIKE '%" + textBox1.Text +
                        "%'  AND C.ENAME LIKE '%" + textBox2.Text + "%'");

                }
                else if (comboBox1.Text == "财务已审核")
                {
                  
                    search_o(vou.sql + " WHERE  "+v7+" AND B.SNAME LIKE '%" + textBox5.Text +
                        "%' AND A.FINANCIAL_AUDIT_STATUS='Y' AND A.GENERAL_MANAGE_AUDIT_STATUS='N' AND A.VOUCHER_DATE BETWEEN '" + v3 + "' AND '" + v4 +
                        "'  AND A.VOID LIKE '%" + textBox1.Text +
                        "%'  AND C.ENAME LIKE '%" + textBox2.Text + "%'");

                }
                else if (comboBox1.Text == "文员未审核")
                {
                    search_o(vou.sql + " WHERE  "+v7+" AND B.SNAME LIKE '%" + textBox5.Text +
                      "%' AND A.GENERAL_MANAGE_AUDIT_STATUS='N' AND A.VOUCHER_DATE BETWEEN '" + v3 + "' AND '" + v4 +
                      "'  AND A.VOID LIKE '%" + textBox1.Text +
                      "%'  AND C.ENAME LIKE '%" + textBox2.Text + "%'");
                }
                else if (comboBox1.Text == "文员已审核")
                {
                    search_o(vou.sql + " WHERE  "+v7+" AND B.SNAME LIKE '%" + textBox5.Text +
                      "%' AND A.GENERAL_MANAGE_AUDIT_STATUS ='Y' AND A.VOUCHER_DATE BETWEEN '" + v3 + "' AND '" + v4 +
                      "' AND A.VOID LIKE '%" + textBox1.Text +
                      "%'  AND C.ENAME LIKE '%" + textBox2.Text + "%'");
                }
             
                else
                {
                   
                    search_o(vou.sql + " WHERE "+v7+" AND B.SNAME LIKE '%" + textBox5.Text +
                      "%' AND A.VOUCHER_DATE BETWEEN '" + v3 + "' AND '" + v4 +
                      "'AND A.VOID LIKE '%" + textBox1.Text +
                      "%'  AND C.ENAME LIKE '%" + textBox2.Text + "%'");
                }
            }
            else
            {
                 if (comboBox1.Text == "业务未审核")
                {


                    search_o(vou.sql + " WHERE "+v7+" AND B.SNAME LIKE '%" + textBox5.Text +
                        "%' AND A.MANAGE_AUDIT_STATUS='N'  AND A.VOID LIKE '%" + textBox1.Text +
                        "%'  AND C.ENAME LIKE '%" + textBox2.Text + "%'");

                }
                else if (comboBox1.Text == "业务已审核")
                {


                    search_o(vou.sql + @" WHERE "+v7+" AND B.SNAME LIKE '%" + textBox5.Text +
                        "%' AND A.MANAGE_AUDIT_STATUS='Y' AND A.FINANCIAL_AUDIT_STATUS='N' AND A.GENERAL_MANAGE_AUDIT_STATUS='N'  AND A.VOID LIKE '%" + textBox1.Text + "%'  AND C.ENAME LIKE '%" + textBox2.Text + "%'");

                }
                else if (comboBox1.Text == "财务未审核")
                {

                    search_o(vou.sql + " WHERE "+v7+" AND B.SNAME LIKE '%" + textBox5.Text +
                        "%' AND A.FINANCIAL_AUDIT_STATUS='N'  AND A.VOID LIKE '%" + textBox1.Text + "%'  AND C.ENAME LIKE '%" + textBox2.Text + "%'");

                }
                else if (comboBox1.Text == "财务已审核")
                {

                    search_o(vou.sql + " WHERE "+v7+" AND B.SNAME LIKE '%" + textBox5.Text +
                        "%' AND A.FINANCIAL_AUDIT_STATUS='Y' AND A.GENERAL_MANAGE_AUDIT_STATUS='N' AND A.VOID LIKE '%" + textBox1.Text + "%'  AND C.ENAME LIKE '%" + textBox2.Text + "%'");

                }
                else if (comboBox1.Text == "文员未审核")
                {
                    search_o(vou.sql + " WHERE "+v7+" AND B.SNAME LIKE '%" + textBox5.Text +
                      "%' AND A.GENERAL_MANAGE_AUDIT_STATUS='N' AND A.VOID LIKE '%" + textBox1.Text + "%'  AND C.ENAME LIKE '%" + textBox2.Text + "%'");
                }
                else if (comboBox1.Text == "文员已审核")
                {
                    search_o(vou.sql + " WHERE "+ v7+" AND B.SNAME LIKE '%" + textBox5.Text +
                      "%' AND A.GENERAL_MANAGE_AUDIT_STATUS ='Y' AND A.VOID LIKE '%" + textBox1.Text + "%'  AND C.ENAME LIKE '%" + textBox2.Text + "%'");
                }
           
                else
                {

                    search_o(vou.sql + " WHERE "+v7+" AND B.SNAME LIKE '%" + textBox5.Text +
                      "%'   AND A.VOID LIKE '%" + textBox1.Text +
                      "%'  AND C.ENAME LIKE '%" + textBox2.Text + "%'");
                }


            }

    
        }
        #endregion

        #region search_o()
        public void search_o(string sql)
        {
            string sqlo =" ORDER BY A.VOID ASC";
            string v7 = bc.getOnlyString("SELECT SCOPE FROM SCOPE_OF_AUTHORIZATION WHERE USID='"+LOGIN .USID +"'");
           // string v7 = "Y";
            string LOGIN_GROUP_NAME = bc.getOnlyString("SELECT USER_GROUP FROM USERINFO WHERE USID='" + LOGIN.USID + "'");
            string USER_TYPE = bc.getOnlyString("SELECT USER_TYPE FROM USERINFO WHERE USID='" + LOGIN.USID + "'");
            if (USER_TYPE == "公司用户")
            {
                label6.Visible = true;
                comboBox2.Visible = true;
                label7.Visible = true;
                textBox5.Visible = true;
                label8.Visible = true;
                textBox1.Visible = true;
                label3.Visible = true;
                comboBox1.Visible = true;
                label9.Visible = true;
                textBox2.Visible = true;

            }
            else
            {
                label6.Visible = false;
                comboBox2.Visible = false;
                label7.Visible = false;
                textBox5.Visible = false;
                label8.Visible = false;
                textBox1.Visible = false;
                label3.Visible = false;
                comboBox1.Visible = false;
                label9.Visible = false;
                textBox2.Visible = false;

            }
            if (USER_TYPE == "公司用户")
            {
                if (v7 == "Y")
                {

                    dt = bc.getdt(sql + sqlo);

                }
                else if (v7 == "GROUP")
                {

                    dt = bc.getdt(sql + @" AND A.MAKERID IN (SELECT EMID FROM USERINFO A WHERE USER_GROUP IN 
 (SELECT USER_GROUP FROM USERINFO WHERE USID='" + LOGIN.USID + "'))" + sqlo);
                }

                else
                {
                    dt = bc.getdt(sql + " AND A.MAKERID='" + LOGIN.EMID + "'" + sqlo);

                }
            }
            else
            {
                dt = bc.getdt(sql + " AND B.SNAME='" + LOGIN_GROUP_NAME + "'");

            }
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                dgvStateControl();
            }
            else
            {
                hint.Text = "找不到所要搜索项！";
                dataGridView1.DataSource = dt;

            }
        }
        #endregion
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            PERIOD period = new PERIOD();
            MessageBox.Show(period.NEXT_FINANCIAL_YEAR + "," + period.NEXT_PERIOD+","+period .NEXT_PERIOD_t );
        }

        private void chk2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk2.Checked)
            {
                dtpStartDate.Enabled = true;
                dtpEndDate.Enabled = true;
            }
            else
            {
                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;

            }
        }


     
    }
}
