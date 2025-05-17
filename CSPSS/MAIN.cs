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

namespace CSPSS
{
    public partial class MAIN : Form
    {
         DataTable dt = new DataTable();
         DataTable dt2 = new DataTable();
         basec bc = new basec();
         CUSER cuser = new CUSER();
         CEMPLOYEE_INFO cemplyee_info = new CEMPLOYEE_INFO();
         Color c2 = System.Drawing.ColorTranslator.FromHtml("#4a7bb8");
         Color c3 = System.Drawing.ColorTranslator.FromHtml("#24ade5");
         CVOUCHER cvoucher = new CVOUCHER();
         CDEPART cdepart = new CDEPART();
         CPOSITION cposition = new CPOSITION();
         CUSER_GROUP cuser_group = new CUSER_GROUP();
         CSUPPLIER_INFO csupplier_info = new CSUPPLIER_INFO();
         CDECUMENTARY cdecumentary = new CDECUMENTARY();
         CREMIND cremind = new CREMIND();
         CCUSTOMER_INFO ccustomer_info = new CCUSTOMER_INFO();
         private string _VOID;
         public string VOID
         {
             set { _VOID = value; }
             get { return _VOID; }

         }
        public MAIN()
        {
            InitializeComponent();
        }
        private void MAIN_Load(object sender, EventArgs e)
        {
           
            try
            {
                /*ccustomer_info.SHORT_MESSAGE_CONTENT = string.Format(@"为免去您排队麻烦，只要你把爱车开过来，我们有专人全程引导，检测快捷方便，让您省时更省心。每周一到周六实行朝九晚五工作时间。预约检车专享VlP贵宾服务， 电话：0830-2517097；地址：泸州市江阳区蓝安路二段(市交警支队内)");
                ccustomer_info.PHONE = "13511634094";
                ccustomer_info.SEND_MESSAGE();*/
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            timer1.Enabled = true;
            this.Text = "车检机构客户管理系统 Version 1.0.0.0";
            dt = bc.getdt("SELECT * from RightList where USID = '"+LOGIN .USID+"'");
            SHOW_TREEVIEW(dt);
            menuStrip1.Font = new Font("宋体", 9);
            this.WindowState = FormWindowState.Maximized;
            toolStripStatusLabel1.Text = "||当前用户：" + LOGIN.UNAME;
            toolStripStatusLabel2.Text = "||所属部门：" + LOGIN.DEPART;
            toolStripStatusLabel3.Text = "||登录时间：" + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + " || 技术支持：苏州好用软件有限公司";
            pictureBox1.Image = Resource1.company;
            listView1.BackColor = c2;
          
            groupBox1.BackColor = c2;
       
            listView1.ForeColor = Color.White;
            listView1.Font = new Font("新宋体", 11);
            imageList1.Images.Add(CSPSS.Resource1._1);
            imageList1.Images.Add(CSPSS.Resource1._2);
            imageList1.Images.Add(CSPSS.Resource1._3);
            imageList1.Images.Add(CSPSS.Resource1._4);
            imageList1.Images.Add(CSPSS.Resource1._5);
            imageList1.Images.Add(CSPSS.Resource1._6);
            imageList1.Images.Add(CSPSS.Resource1._7);
            imageList1.Images.Add(CSPSS.Resource1._8);
            imageList1.Images.Add(CSPSS.Resource1._9);
            imageList1.Images.Add(CSPSS.Resource1._10);
            imageList1.Images.Add(CSPSS.Resource1._11);
            imageList1.Images.Add(CSPSS.Resource1._12);
            imageList1.Images.Add(CSPSS.Resource1._13);
            imageList1.Images.Add(CSPSS.Resource1._14);
            imageList1.Images.Add(CSPSS.Resource1._15);
            imageList1.Images.Add(CSPSS.Resource1._16);
            imageList1.Images.Add(CSPSS.Resource1._17);
            imageList1.Images.Add(CSPSS.Resource1._18);
            imageList1.Images.Add(CSPSS.Resource1._19);
            imageList1.Images.Add(CSPSS.Resource1._20);
            imageList1.Images.Add(CSPSS.Resource1._21);
            imageList1.Images.Add(CSPSS.Resource1._22);
            imageList1.Images.Add(CSPSS.Resource1._23);
            imageList1.Images.Add(CSPSS.Resource1._24);
            imageList1.Images.Add(CSPSS.Resource1._25);
            imageList1.Images.Add(CSPSS.Resource1._26);
            imageList1.Images.Add(CSPSS.Resource1._27);
            imageList1.Images.Add(CSPSS.Resource1._28);
            imageList1.Images.Add(CSPSS.Resource1._29);
            imageList1.Images.Add(CSPSS.Resource1._30);
            imageList1.Images.Add(CSPSS.Resource1._31);
            imageList1.Images.Add(CSPSS.Resource1._32);
            imageList1.Images.Add(CSPSS.Resource1._33);
            imageList1.Images.Add(CSPSS.Resource1._34);
            imageList1.Images.Add(CSPSS.Resource1._35);
            imageList1.Images.Add(CSPSS.Resource1._36);
            imageList1.Images.Add(CSPSS.Resource1._37);
            imageList1.Images.Add(CSPSS.Resource1._38);
            imageList1.Images.Add(CSPSS.Resource1._39);
            imageList1.Images.Add(CSPSS.Resource1._40);
            imageList1.Images.Add(CSPSS.Resource1._41);
            imageList1.Images.Add(CSPSS.Resource1._42);


            imageList1.ColorDepth = ColorDepth.Depth32Bit;/*防止图片失真*/
            listView1.View = View.SmallIcon;
            listView2.View = View.LargeIcon;
            imageList1.ImageSize = new Size(48, 48);/*set imglist size*/
            listView1.SmallImageList = imageList1;
            listView2.LargeImageList = imageList1;
            bind();
        }
        #region dgvStateControl
        private void dgvStateControl()
        {
            int i;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Lavender;
            dataGridView1.ClearSelection();//取消默认选中列
            int numCols1 = dataGridView1.Columns.Count;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;/*自动调整DATAGRIDVIEW的列宽*/
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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        #endregion
        #region show_treeview
        private void SHOW_TREEVIEW(DataTable dt)
        {
           
            dt = bc.GET_DT_TO_DV_TO_DT(dt, "", "PARENT_NODEID=0");

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem lvi = listView1.Items.Add(dt.Rows[i]["NODE_NAME"].ToString());
                    lvi.ImageIndex = Convert.ToInt32(dt.Rows[i]["NODEID"].ToString()) - 1;/*NEED THIS SO CAN SHOW*/
                }

                DataTable dtx = bc.GET_DT_TO_DV_TO_DT(dt, "", "NODE_NAME='账务管理'");
                if (dtx.Rows.Count > 0)
                {
                    click(dtx.Rows[0]["NODE_NAME"].ToString());
                    if (listView1 .Items.Count >1)
                    {
                        listView1.Items[1].BackColor = c3;
                    }
                    else
                    {
                        listView1.Items[0].BackColor = c3;
                      
                    }
                }
                else
                {

                    click(dt.Rows[0]["NODE_NAME"].ToString());
                    listView1.Items[0].BackColor = c3;
                }


            }
        
       
        }
        #endregion

        #region show_treeview_O
        private void SHOW_TREEVIEW_O(string NODEID)
        {

            dt2 = bc.getdt("SELECT * FROM RIGHTLIST WHERE PARENT_NODEID='" + NODEID  + "'AND  USID = '" + LOGIN.USID + "'");
            if (dt2.Rows.Count > 0)
            {
                for(int i=0;i<dt2.Rows.Count ;i++)
                {
                    ListViewItem lvi = listView2.Items.Add(dt2.Rows [i]["NODE_NAME"].ToString());
                    lvi.ImageIndex = Convert.ToInt32(dt2.Rows[i]["NODEID"].ToString()) - 1;/*NEED THIS SO CAN SHOW*/
                }
            }
        }
        #endregion

         private void 退出系统ToolStripMenuItem1_Click(object sender, EventArgs e)
         {
             if (MessageBox.Show("确定要退出本系统吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
             {
                 Application.Exit();
             }
             else
             {
                 MAIN fmain = new MAIN();
                 fmain.Show();
             }
         }
         private void listView1_Click(object sender, EventArgs e)
         {
            
             string v1 = listView1.SelectedItems[0].SubItems[0].Text.ToString();/*get selectitem value*/
             click(v1);
            
         }
         private void click(string NODE_NAME)
         {
             listView2.Items.Clear();
             string id = bc.getOnlyString("SELECT NODEID FROM RIGHTLIST WHERE NODE_NAME='" + NODE_NAME + "'");
             SHOW_TREEVIEW_O(id);

             foreach (ListViewItem lvi in listView1.Items)
             {
                 if (lvi.Selected)
                 {
                     lvi.BackColor = c3;
                     //pictureBox1.Focus();/*SELECTED AFTER MOVE FOCUS*/
                 }
                 else
                 {
                     lvi.BackColor = c2;
                 }

             }

         }
         private void listView2_Click(object sender, EventArgs e)
         {
             string v1 = listView2.SelectedItems[0].SubItems[0].Text.ToString();/*get selectitem value*/
             string v11 = bc.getOnlyString("SELECT ADD_NEW FROM RIGHTLIST WHERE  USID='" + LOGIN.USID + "' AND NODE_NAME='传单作业'");
             #region v1
             if (v1 == "客户信息维护")
             {
                 BASE_INFO.CUSTOMER_INFOT FRM = new CSPSS.BASE_INFO.CUSTOMER_INFOT();
                 FRM.IDO = ccustomer_info.GETID();
                 FRM.Show();


             }
             else if (v1 == "短信内容")
             {
                 CSPSS.BASE_INFO.SHORT_MESSAGE_CONTENT FRM = new CSPSS.BASE_INFO.SHORT_MESSAGE_CONTENT() ;
                 FRM.Show();

             }
             else if (v1 == "供应商信息维护")
             {
                 CSPSS.BASE_INFO.SUPPLIER_INFO FRM = new CSPSS.BASE_INFO.SUPPLIER_INFO();
                 FRM.IDO = csupplier_info.GETID();
                 FRM.Show();

             }

             else if (v1 == "员工信息维护")
             {
                 CSPSS.BASE_INFO.EMPLOYEE_INFO FRM = new CSPSS.BASE_INFO.EMPLOYEE_INFO();
                 FRM.IDO = cemplyee_info.GETID();
                 FRM.Show();

             }
             else if (v1 == "部门信息维护")
             {
                 CSPSS.BASE_INFO.DEPART FRM = new CSPSS.BASE_INFO.DEPART();
                 FRM.IDO = cdepart.GETID();
                 FRM.Show();

             }
             else if (v1 == "职务信息维护")
             {
                 CSPSS.BASE_INFO.POSITION FRM = new CSPSS.BASE_INFO.POSITION();
                 FRM.IDO = cposition.GETID();
                 FRM.Show();

             }
             else if (v1 == "服务器IP")
             {
                 CSPSS.BASE_INFO.UPLOADFILE_DOMAIN FRM = new CSPSS.BASE_INFO.UPLOADFILE_DOMAIN();

                 FRM.Show();

             }
             else if (v1 == "传单作业")
             {
                 if (v11 != "Y")
                 {
                     MessageBox.Show("您没有新增权限");
                 }
                 else
                 {
                     CSPSS.VOUCHER_MANAGE.VOUCHERT FRM = new CSPSS.VOUCHER_MANAGE.VOUCHERT();
                     FRM.IDO = cvoucher.GETID();
                     FRM.Show();
                 }

             }
             else if (v1 == "传单查询作业")
             {
                 CSPSS.VOUCHER_MANAGE.VOUCHER FRM = new CSPSS.VOUCHER_MANAGE.VOUCHER();
                 FRM.Show();

             }
             else if (v1 == "用户帐户")
             {
                 CSPSS.USER_MANAGE.USER_INFO FRM = new CSPSS.USER_MANAGE.USER_INFO();
                 FRM.IDO = cuser.GETID();
                 FRM.ADD_OR_UPDATE = "ADD";
                 FRM.Show();

             }

             else if (v1 == "更改密码")
             {
                 CSPSS.USER_MANAGE.EDIT_PWD FRM = new CSPSS.USER_MANAGE.EDIT_PWD();
                 FRM.Show();

             }
             else if (v1 == "权限管理")
             {
                 CSPSS.USER_MANAGE.EDIT_RIGHT FRM = new CSPSS.USER_MANAGE.EDIT_RIGHT();
                 FRM.Show();

             }
             else if (v1 == "用户组信息")
             {
                 CSPSS.USER_MANAGE.USER_GROUP FRM = new CSPSS.USER_MANAGE.USER_GROUP();
                 FRM.IDO = cuser_group.GETID();
                 FRM.Show();

             }
             #endregion
         }

         private void timer1_Tick(object sender, EventArgs e)
         {
             timer1.Interval = 60000;
             bind();
         }
         private void bind()
         {
             DataTable dtt = ccustomer_info.RETURN_SHOW_DATA();
             if (dtt.Rows.Count > 0)
             {
                 dataGridView1.DataSource = dtt;
                 dgvStateControl();
               
             }
             else
             {
                 dataGridView1.DataSource = null;
             }
         }

         private void button1_Click(object sender, EventArgs e)
         {
             bind();
         }

         private void button1_Click_1(object sender, EventArgs e)
         {
           
         }

         private void listView1_SelectedIndexChanged(object sender, EventArgs e)
         {

         }

         private void groupBox1_Paint(object sender, PaintEventArgs e)
         {
             e.Graphics.Clear(this.c2);
         }
    }
}
