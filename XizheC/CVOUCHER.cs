using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using XizheC;

namespace XizheC
{
    public class CVOUCHER
    {
        #region nature
        private string _ErrowInfo;
        public string ErrowInfo
        {

            set { _ErrowInfo = value; }
            get { return _ErrowInfo; }

        }
        private string _AUDIT_STYLE;
        public string AUDIT_STYLE
        {
            set { _AUDIT_STYLE = value; }
            get { return _AUDIT_STYLE; }

        }
        private string _sql;
        public string sql
        {
            set { _sql = value; }
            get { return _sql; }

        }
        private string _sqlo;
        public string sqlo
        {
            set { _sqlo = value; }
            get { return _sqlo; }

        }
        private string _sqlt;
        public string sqlt
        {
            set { _sqlt = value; }
            get { return _sqlt; }

        }
        private string _sqlth;
        public string sqlth
        {
            set { _sqlth = value; }
            get { return _sqlth; }

        }
        private string _sqlf;
        public string sqlf
        {
            set { _sqlf = value; }
            get { return _sqlf; }

        }
        private string _sqlfi;
        public string sqlfi
        {
            set { _sqlfi = value; }
            get { return _sqlfi; }

        }
        private string _TABLE_TOP;
        public string TABLE_TOP
        {
            set { _TABLE_TOP = value; }
            get { return _TABLE_TOP; }

        }
        private string _SUID;
        public string SUID
        {
            set { _SUID = value; }
            get { return _SUID; }

        }
        private string _LAST_MAKERID;
        public string LAST_MAKERID
        {
            set { _LAST_MAKERID = value; }
            get { return _LAST_MAKERID; }

        }
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
     
        private string _VOUCHER_DATE;
        public string VOUCHER_DATE
        {

            set { _VOUCHER_DATE = value; }
            get { return _VOUCHER_DATE; }

        }

        private string _EMID;
        public string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }
        private string _MAKERID;
        public string MAKERID
        {
            set { _MAKERID = value; }
            get { return _MAKERID; }

        }
        private string _STATUS;
        public string STATUS
        {
            set { _STATUS = value; }
            get { return _STATUS; }

        }
        private  string _VOID;
        public string VOID
        {
            set { _VOID = value; }
            get { return _VOID; }

        }
        private string _MANAGE_AUDIT_STATUS;
        public string MANAGE_AUDIT_STATUS
        {
            set { _MANAGE_AUDIT_STATUS = value; }
            get { return _MANAGE_AUDIT_STATUS; }

        }
        private string _FINANCIAL_AUDIT_STATUS;
        public string FINANCIAL_AUDIT_STATUS
        {
            set { _FINANCIAL_AUDIT_STATUS = value; }
            get { return _FINANCIAL_AUDIT_STATUS; }

        }
        private string _GENERAL_MANAGE_AUDIT_STATUS;
        public string GENERAL_MANAGE_AUDIT_STATUS
        {
            set { _GENERAL_MANAGE_AUDIT_STATUS = value; }
            get { return _GENERAL_MANAGE_AUDIT_STATUS; }

        }
        private  string _BILL_ID;
        public  string BILL_ID
        {
            set { _BILL_ID = value; }
            get { return _BILL_ID; }

        }
        private  string _HANDLER_MAKERID;
        public string HANDLER_MAKERID
        {
            set { _HANDLER_MAKERID = value; }
            get { return _HANDLER_MAKERID; }

        }
        private string _MANAGE_AUDIT_MAKERID;
        public string MANAGE_AUDIT_MAKERID
        {
            set { _MANAGE_AUDIT_MAKERID = value; }
            get { return _MANAGE_AUDIT_MAKERID; }

        }
        private string _MANAGE_AUDIT_DATE;
        public string MANAGE_AUDIT_DATE
        {
            set { _MANAGE_AUDIT_DATE = value; }
            get { return _MANAGE_AUDIT_DATE; }

        }
   
        private string _FINANCIAL_AUDIT_MAKERID;
        public string FINANCIAL_AUDIT_MAKERID
        {
            set { _FINANCIAL_AUDIT_MAKERID = value; }
            get { return _FINANCIAL_AUDIT_MAKERID; }

        }
        private string _FINANCIAL_AUDIT_DATE;
        public string FINANCIAL_AUDIT_DATE
        {
            set { _FINANCIAL_AUDIT_DATE = value; }
            get { return _FINANCIAL_AUDIT_DATE; }

        }
        private string _GENERAL_MANAGE_AUDIT_MAKERID;
        public string GENERAL_MANAGE_AUDIT_MAKERID
        {
            set { _GENERAL_MANAGE_AUDIT_MAKERID = value; }
            get { return _GENERAL_MANAGE_AUDIT_MAKERID; }

        }
        private string _GENERAL_MANAGE_AUDIT_DATE;
        public string GENERAL_MANAGE_AUDIT_DATE
        {
            set { _GENERAL_MANAGE_AUDIT_DATE = value; }
            get { return _GENERAL_MANAGE_AUDIT_DATE; }

        }
        private string _LAST_DATE;
        public string LAST_DATE
        {
            set { _LAST_DATE = value; }
            get { return _LAST_DATE; }

        }
        #endregion
        #region setsql
        string setsql = @"
SELECT 
A.VOID AS 传单编号,
A.BILL_ID AS 单号,
A.VOUCHER_DATE AS 出货日期,
A.HANDLER_MAKERID AS 下单人工号,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.HANDLER_MAKERID) AS 下单人,
A.TABLE_TOP AS 表头,
A.SUID AS 供应商编号,
B.SNAME AS 供应商名称,
CASE WHEN A.MANAGE_AUDIT_STATUS='N'  THEN '业务未审核'
WHEN A.MANAGE_AUDIT_STATUS='Y' AND  A.FINANCIAL_AUDIT_STATUS='N' AND A.GENERAL_MANAGE_AUDIT_STATUS='N' THEN '业务已审核'
WHEN A.FINANCIAL_AUDIT_STATUS='N'  THEN '财务未审核'
WHEN A.FINANCIAL_AUDIT_STATUS='Y'AND A.GENERAL_MANAGE_AUDIT_STATUS='N' THEN '财务已审核'
WHEN A.GENERAL_MANAGE_AUDIT_STATUS='N' THEN '文员未审核'
WHEN A.GENERAL_MANAGE_AUDIT_STATUS='Y' THEN '文员已审核'
END AS 状态,
A.MANAGE_AUDIT_MAKERID AS 业务工号,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MANAGE_AUDIT_MAKERID) AS 业务,
A.FINANCIAL_AUDIT_MAKERID AS 财务工号,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.FINANCIAL_AUDIT_MAKERID ) AS 财务,
A.GENERAL_MANAGE_AUDIT_MAKERID AS 文员工号,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.GENERAL_MANAGE_AUDIT_MAKERID) AS 文员,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID) AS 制单人,
A.DATE AS 制单日期
FROM VOUCHER_MST A 
LEFT JOIN SupplierInfo_MST   B ON A.SUID=B.SUID
LEFT JOIN EMPLOYEEINFO C ON A.MAKERID=C.EMID

";
        string setsqlo = @"


";


        string setsqlt = @"INSERT INTO VOUCHER_MST(

VOID,
VOUCHER_DATE,
BILL_ID,
HANDLER_MAKERID,
TABLE_TOP,
STATUS,
SUID,
AUDIT_STYLE,
MANAGE_AUDIT_STATUS,
MANAGE_AUDIT_MAKERID,
MANAGE_AUDIT_DATE,
FINANCIAL_AUDIT_STATUS,
FINANCIAL_AUDIT_MAKERID,
FINANCIAL_AUDIT_DATE,
GENERAL_MANAGE_AUDIT_STATUS,
GENERAL_MANAGE_AUDIT_MAKERID,
GENERAL_MANAGE_AUDIT_DATE,
LAST_MAKERID,
LAST_DATE,
MAKERID,
DATE,
YEAR,
MONTH,
DAY
) VALUES 

(
@VOID,
@VOUCHER_DATE,
@BILL_ID,
@HANDLER_MAKERID,
@TABLE_TOP,
@STATUS,
@SUID,
@AUDIT_STYLE,
@MANAGE_AUDIT_STATUS,
@MANAGE_AUDIT_MAKERID,
@MANAGE_AUDIT_DATE,
@FINANCIAL_AUDIT_STATUS,
@FINANCIAL_AUDIT_MAKERID,
@FINANCIAL_AUDIT_DATE,
@GENERAL_MANAGE_AUDIT_STATUS,
@GENERAL_MANAGE_AUDIT_MAKERID,
@GENERAL_MANAGE_AUDIT_DATE,
@LAST_MAKERID,
@LAST_DATE,
@MAKERID,
@DATE,
@YEAR,
@MONTH,
@DAY
)

";
        string setsqlth = @"UPDATE VOUCHER_MST SET 
VOID=@VOID,
VOUCHER_DATE=@VOUCHER_DATE,
BILL_ID=@BILL_ID,
HANDLER_MAKERID=@HANDLER_MAKERID,
TABLE_TOP=@TABLE_TOP,
STATUS=@STATUS,
SUID=@SUID,
AUDIT_STYLE=@AUDIT_STYLE,
MANAGE_AUDIT_MAKERID=@MANAGE_AUDIT_MAKERID,
FINANCIAL_AUDIT_MAKERID=@FINANCIAL_AUDIT_MAKERID,
GENERAL_MANAGE_AUDIT_MAKERID=@GENERAL_MANAGE_AUDIT_MAKERID,
LAST_MAKERID=@LAST_MAKERID,
LAST_DATE=@LAST_DATE,
DATE=@DATE,
YEAR=@YEAR,
MONTH=@MONTH,
DAY=@DAY
";
        string setsqlf= @"

";
        string setsqlfi = @" 
 SELECT 
 A.INITIAL_RATE,
 A.PERIOD,
 B.CYCODE,
 B.FINANCIAL_YEAR
 FROM CURRENCY_DET A 
 LEFT JOIN CURRENCY_MST B ON A.CYID=B.CYID 
";

        #endregion
        basec bc = new basec();
        DataTable dt = new DataTable();
        DataTable dto = new DataTable();
        ExcelToCSHARP etc = new ExcelToCSHARP();
        public CVOUCHER()
        {
            IFExecution_SUCCESS = true;
            sql = setsql;
            sqlo = setsqlo;
            sqlt = setsqlt;
            sqlth = setsqlth;
            sqlf = setsqlf;
            sqlfi = setsqlfi;
     

        
        }
        public string GETID()
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            string v1 = bc.numYMD(12, 4, "0001", "select * from VOUCHER_GETID", "VOID", "VO");
            string GETID = "";
            if (v1 != "Exceed Limited")
            {
                GETID = v1;
                bc.getcom("INSERT INTO VOUCHER_GETID(VOID,DATE,YEAR,MONTH,DAY) VALUES ('" + v1 + "','"+varDate +"','"+year +"','"+month +"','"+day +"')");
            }
            return GETID;
        }
        #region SQlcommandE
        public  void SQlcommandE(string sql)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            //string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            SqlConnection sqlcon = bc.getcon();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@VOID", SqlDbType.VarChar, 20).Value = VOID;
            sqlcom.Parameters.Add("@VOUCHER_DATE", SqlDbType.VarChar, 20).Value = VOUCHER_DATE;
            sqlcom.Parameters.Add("@BILL_ID", SqlDbType.VarChar, 20).Value = BILL_ID;
            sqlcom.Parameters.Add("@HANDLER_MAKERID", SqlDbType.VarChar, 20).Value = HANDLER_MAKERID;
            sqlcom.Parameters.Add("@TABLE_TOP", SqlDbType.VarChar, 20).Value = TABLE_TOP;
            sqlcom.Parameters.Add("@STATUS", SqlDbType.VarChar, 20).Value = STATUS;
            sqlcom.Parameters.Add("@SUID", SqlDbType.VarChar, 20).Value = SUID;
            sqlcom.Parameters.Add("@AUDIT_STYLE", SqlDbType.VarChar, 20).Value = AUDIT_STYLE;
            sqlcom.Parameters.Add("@MANAGE_AUDIT_STATUS", SqlDbType.VarChar, 20).Value = MANAGE_AUDIT_STATUS;
            sqlcom.Parameters.Add("@MANAGE_AUDIT_MAKERID", SqlDbType.VarChar, 20).Value = MANAGE_AUDIT_MAKERID;
            sqlcom.Parameters.Add("@MANAGE_AUDIT_DATE", SqlDbType.VarChar, 20).Value = MANAGE_AUDIT_DATE;
            sqlcom.Parameters.Add("@FINANCIAL_AUDIT_STATUS", SqlDbType.VarChar, 20).Value = FINANCIAL_AUDIT_STATUS;
            sqlcom.Parameters.Add("@FINANCIAL_AUDIT_MAKERID", SqlDbType.VarChar, 20).Value = FINANCIAL_AUDIT_MAKERID;
            sqlcom.Parameters.Add("@FINANCIAL_AUDIT_DATE", SqlDbType.VarChar, 20).Value = FINANCIAL_AUDIT_DATE;
            sqlcom.Parameters.Add("@GENERAL_MANAGE_AUDIT_STATUS", SqlDbType.VarChar, 20).Value = GENERAL_MANAGE_AUDIT_STATUS;
            sqlcom.Parameters.Add("@GENERAL_MANAGE_AUDIT_MAKERID", SqlDbType.VarChar, 20).Value = GENERAL_MANAGE_AUDIT_MAKERID;
            sqlcom.Parameters.Add("@GENERAL_MANAGE_AUDIT_DATE", SqlDbType.VarChar, 20).Value = GENERAL_MANAGE_AUDIT_DATE;
            sqlcom.Parameters.Add("@LAST_MAKERID", SqlDbType.VarChar, 20).Value = EMID;
            sqlcom.Parameters.Add("@LAST_DATE", SqlDbType.VarChar, 20).Value = LAST_DATE;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = EMID;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcom.Parameters.Add("@DAY", SqlDbType.VarChar, 20).Value = day;
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
        #region Search()
        public DataTable Search(string ACCODE, string ACNAME)
        {

            string sql1 = @" where A.ACCODE like '%" + ACCODE + "%' AND A.ACNAME LIKE '%" + ACNAME + "%' ORDER BY ACCODE ASC";
            dt = basec.getdts(sql + sql1);
            return dt;
        }
        #endregion

    
        public bool CheckIfALLOW_SAVEOR_DELETE(string VOID,string USID)
        {
            bool b = false;
            EMID= bc.getOnlyString ("SELECT EMID FROM USERINFO WHERE USID='"+USID +"'");
            string MAKERID = bc.getOnlyString("SELECT MAKERID FROM VOUCHER_MST WHERE VOID='"+VOID +"'");
            if (bc.exists("SELECT STATUS FROM VOUCHER_MST WHERE VOID='" + VOID + "'"))
            {
                string s2 = bc.getOnlyString("SELECT STATUS FROM VOUCHER_MST WHERE VOID='" + VOID + "'");
                string v1 = bc.getOnlyString("SELECT GENERAL_MANAGE FROM RIGHTLIST WHERE USID='"+USID +"' AND NODE_NAME='传单作业'");
                if (this.RETURN_MANAGE_AUDIT_STATUS (VOID ) == "Y" || this.RETURN_FINANCIAL_AUDIT_STATUS (VOID ) == "Y"|| 
                    this.RETURN_GENERAL_AUDIT_STATUS (VOID )=="Y")
                {
                  
                    b = true;
                    ErrowInfo = "业务已审核或财务已审核或文员已审核凭证需逐个撤审后才能删除与修改";

                }
                else if(bc.exists ("SELECT * FROM REMIND WHERE RIID='"+VOID +"'"))
                {
                    b = true;
                    ErrowInfo = "此单据已经传送到供应商客户端不能再删除与修改";
                }
                else if (EMID !=MAKERID && v1!="Y")
                {
                   
                    b = true;
                    ErrowInfo = "非凭证的制单人只允许文员删除与修改";

                }

             
            }

            return b;
        }
     

   
        public string RETURN_GENERAL_AUDIT_STATUS(string VOID)
        {
         
            STATUS  = bc.getOnlyString("SELECT GENERAL_MANAGE_AUDIT_STATUS FROM VOUCHER_MST WHERE VOID='" + VOID + "'");
            return STATUS;
        }
        public string RETURN_FINANCIAL_AUDIT_STATUS(string VOID)
        {

            STATUS = bc.getOnlyString("SELECT FINANCIAL_AUDIT_STATUS FROM VOUCHER_MST WHERE VOID='" + VOID + "'");
            return STATUS;
        }
        public string RETURN_MANAGE_AUDIT_STATUS(string VOID)
        {

            STATUS = bc.getOnlyString("SELECT MANAGE_AUDIT_STATUS FROM VOUCHER_MST WHERE VOID='" + VOID + "'");
            return STATUS;
        }
        public void   RETURN_IF_AUDIT_COMPLETE(string VOID)
        {
            bool b = false;
             string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            DataTable dt = bc.getdt("SELECT * FROM VOUCHER_MST WHERE VOID='" + VOID + "'");
            string v1=dt.Rows[0]["AUDIT_STYLE"].ToString();
            string v2 = "", v3 = "", v4 = "";
            if (!string.IsNullOrEmpty(dt.Rows[0]["MANAGE_AUDIT_STATUS"].ToString()))
            {
                v2 = dt.Rows[0]["MANAGE_AUDIT_STATUS"].ToString();
            }
            if (!string.IsNullOrEmpty(dt.Rows[0]["FINANCIAL_AUDIT_STATUS"].ToString()))
            {
                v3 = dt.Rows[0]["FINANCIAL_AUDIT_STATUS"].ToString();
            }
            if (!string.IsNullOrEmpty(dt.Rows[0]["GENERAL_MANAGE_AUDIT_STATUS"].ToString()))
            {
                v4 = dt.Rows[0]["GENERAL_MANAGE_AUDIT_STATUS"].ToString();
            }
           // MessageBox.Show(v1+","+v2+","+v3+","+v4);
            if (v1 == "NNN" && v2 == "N" && v3 == "N" && v4 == "N")
            {
               
                b = true;
            }
            else if (v1 == "YNN" && v2 == "Y" && v3 == "N" && v4 == "N")
            {
                b = true;
            }
            else if (v1 == "NYN" && v2 == "N" && v3 == "Y" && v4 == "N")
            {
                b = true;

            }
            else if (v1 == "NNY" && v2 == "N" && v3 == "N" && v4 == "Y")
            {
                b = true;
            }
            else if (v1 == "YYN" && v2 == "Y" && v3 == "Y" && v4 == "N")
            {
                b = true;
            }
            else if (v1 == "YNY" && v2 == "Y" && v3 == "N" && v4 == "Y")
            {
                b = true;

            }
            else if (v1 == "NYY" && v2 == "N" && v3 == "Y" && v4 == "Y")
            {
                b = true;
            }
            else if (v1 == "YYY" && v2 == "Y" && v3 == "Y" && v4 == "Y")
            {
                b = true;
            }
         
            if (b)
            {
                basec.getcoms(@"
INSERT 
REMIND
(
RIID,
IF_RECEIVE_COMPANYINFO,
IF_SALE_RECEIVE_SUPPLIERINFO,
IF_FINANCIAL_RECEIVE_SUPPLIERINFO,
IF_OFFICE_RECEIVE_SUPPLIERINFO,
DATE
) 
VALUES 
(
'" + VOID + "','N','N','N','N','"+varDate +"')");

            }
          
        }
    }
}
