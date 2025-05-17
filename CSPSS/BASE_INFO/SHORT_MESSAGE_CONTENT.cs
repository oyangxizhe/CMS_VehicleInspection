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
    public partial class SHORT_MESSAGE_CONTENT : Form
    {
      
        protected string M_str_sql = @"select A.USID AS USID,A.UNAME AS UNAME,A.EMID AS EMID,B.ENAME AS ENAME,A.PWD AS PWD,
(SELECT ENAME FROM EMPLOYEEINFO  WHERE EMID=A.MAKERID) AS MAKER,A.DATE AS DATE from   USERINFO  A LEFT JOIN EMPLOYEEINFO B ON A.EMID=B.EMID";
        basec bc = new basec();
        CUSER cuser = new CUSER();
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        public SHORT_MESSAGE_CONTENT()
        {
            InitializeComponent();
        }

  
        #region bind()
        private void Bind()
        {

            textBox1.Text = bc.getOnlyString("SELECT CGID FROM SHORT_MESSAGE_CONTENT");
            textBox2.Text = bc.getOnlyString("SELECT SHORT_MESSAGE_CONTENT FROM SHORT_MESSAGE_CONTENT");
            hint.ForeColor = Color.Red;
            if (bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS) != "")
            {
                hint.Text = bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS);
            }
            else
            {
                hint.Text = "";
            }
            btnSave.Focus();
        }
        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
           
          
            try
            {
                save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        #region save
        protected void save()
        {
            if (juage())
            {

            }

            else
            {

             DataTable dt = bc.getdt("SELECT * FROM SHORT_MESSAGE_CONTENT");
             if (dt.Rows.Count > 0)
             {

                 string sql = @"
UPDATE SHORT_MESSAGE_CONTENT SET 
CGID=@CGID,
SHORT_MESSAGE_CONTENT=@SHORT_MESSAGE_CONTENT,
MAKERID=@MAKERID,
DATE=@DATE ";
                 SQlcommandE_MST(sql);
             }
             else
             {

                 string sql = @"
INSERT INTO 
SHORT_MESSAGE_CONTENT 
(
CGID,
SHORT_MESSAGE_CONTENT,
MAKERID,
DATE
)
VALUES
(
@CGID,
@SHORT_MESSAGE_CONTENT,
@MAKERID,
@DATE
)
";
                 SQlcommandE_MST(sql);

             }

   

            }

            
        }

        #endregion
        #region SQlcommandE_MST
        protected void SQlcommandE_MST(string sql)
        {
            hint.Text = "";
            string varMakerID = LOGIN.EMID;
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace("-", "/");
            SqlConnection sqlcon = bc.getcon();
            SqlConnection con = bc.getcon();
            SqlCommand sqlcom = new SqlCommand(sql, con);
            sqlcom.Parameters.Add("@CGID", SqlDbType.VarChar, 20).Value = textBox1.Text;
            sqlcom.Parameters.Add("@SHORT_MESSAGE_CONTENT", SqlDbType.VarChar,300).Value = textBox2.Text;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = varMakerID;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            con.Open();
            sqlcom.ExecuteNonQuery();
            con.Close();
            IFExecution_SUCCESS = true;
            Bind();
        }
        #endregion
        #region juage()
        private bool juage()
        {

            bool b = false;
            //int charSize = Encoding.Default.GetBytes(textBox1.Text).Length;
            int charSize = textBox2.Text.Length;
            if (charSize > 270)
            {
                hint.Text = "只能最多输入270个字符";
                b= true;
            }
            return b;
        }
        #endregion
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region
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

        private void SHORT_MESSAGE_CONTENT_Load(object sender, EventArgs e)
        {
            Bind();
           
        }

    }
}
