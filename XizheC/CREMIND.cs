using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using XizheC;
using System.Windows.Forms;

namespace XizheC
{
    public class CREMIND
    {
        basec bc = new basec();

        #region nature
        private string _EMID;
        public string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }
   
     
        private string _SUID;
        public string SUID
        {
            set { _SUID = value; }
            get { return _SUID; }

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
      
        private string _sqlsi;
        public string sqlsi
        {
            set { _sqlsi = value; }
            get { return _sqlsi; }

        }
        private string _MAKERID;
        public string MAKERID
        {
            set { _MAKERID = value; }
            get { return _MAKERID; }

        }
       
        private  bool _IFExecutionSUCCESS;
        public  bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
  
        private string _ErrowInfo;
        public string ErrowInfo
        {

            set { _ErrowInfo = value; }
            get { return _ErrowInfo; }

        }
  
  
        #endregion
        DataTable dt = new DataTable();
        #region sql
        string setsql = @"
SELECT 
A.RIID AS 传单编号,
B.BILL_ID AS 单号,
B.TABLE_TOP AS 表头,
B.VOUCHER_DATE AS 出货日期,
A.IF_RECEIVE_COMPANYINFO AS 是否收到公司信息,
A.SUPPLIER_LEAVE_MESSAGE AS 供应商留言,
CASE WHEN A.IF_CANCEL='Y' THEN '已作废'
ELSE '正常'
END AS 是否作废,
C.SNAME AS 供应商名称,
B.MANAGE_AUDIT_MAKERID AS 业务工号,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=B.MANAGE_AUDIT_MAKERID) AS 业务,
A.IF_SALE_RECEIVE_SUPPLIERINFO AS 是否业务收到供应商信息, 
B.FINANCIAL_AUDIT_MAKERID AS 财务工号,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=B.FINANCIAL_AUDIT_MAKERID ) AS 财务,
A.IF_FINANCIAL_RECEIVE_SUPPLIERINFO AS 是否财务收到供应商信息,
B.GENERAL_MANAGE_AUDIT_MAKERID AS 文员工号,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=B.GENERAL_MANAGE_AUDIT_MAKERID) AS 文员,
A.IF_OFFICE_RECEIVE_SUPPLIERINFO AS 是否文员收到供应商信息
FROM REMIND A 
LEFT JOIN VOUCHER_MST B ON A.RIID=B.VOID 
LEFT JOIN SUPPLIERINFO_MST C ON B.SUID=C.SUID

";

        string setsqlo = @"


";

        string setsqlt = @"


";
        string setsqlth = @"


";

        string setsqlf = @"


)
";
        string setsqlfi = @"

";
        string setsqlsi = @"

)
";
        #endregion
        public CREMIND()
        {
            string year, month, day;
            year = DateTime.Now.ToString("yy");
            month = DateTime.Now.ToString("MM");
            day = DateTime.Now.ToString("dd");
            //GETID =bc.numYM(10, 4, "0001", "SELECT * FROM WORKORDER_PICKING_MST", "WPID", "WP");

            sql = setsql;
            sqlo = setsqlo;
            sqlt = setsqlt;
            sqlth = setsqlth;
            sqlf = setsqlf;
            sqlfi = setsqlfi;
            sqlsi = setsqlsi;
        }
      
  

    }
}
