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

namespace XizheC
{
    public class CDECUMENTARY
    {
        basec bc = new basec();
        private string _USID;
        public string USID
        {
            set { _USID = value; }
            get { return _USID; }

        }
        private string _UNAME;
        public string UNAME
        {
            set { _UNAME = value; }
            get { return _UNAME; }

        }
        private string _EMID;
        public string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }
        private string _ENAME;
        public string ENAME
        {
            set { _ENAME = value; }
            get { return _ENAME; }

        }
        private string _DECUMENTARY;
        public string DECUMENTARY
        {
            set { _DECUMENTARY = value; }
            get { return _DECUMENTARY; }

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
        #region sql
        string setsql = @"
SELECT 
A.DUID AS 跟单号,
A.DECUMENTARY AS 跟单名称,
(SELECT ENAME FROM EMPLOYEEINFO 
WHERE EMID=A.MAKERID ) AS 制单人,
A.DATE AS 制单日期
FROM
DECUMENTARY A

";

        string setsqlo = @"
INSERT INTO SUPPLIERINFO_DET
(
SUKEY,
SUID,
SN,
CONTACT,
THE_DEFAULT,
PHONE,
QQ,
ALWW,
FAX,
POSTCODE,
EMAIL,
ADDRESS,
DEPART,
MAKERID,
DATE,
YEAR,
MONTH,
DAY
)
VALUES
(
@SUKEY,
@SUID,
@SN,
@CONTACT,
@THE_DEFAULT,
@PHONE,
@QQ,
@ALWW,
@FAX,
@POSTCODE,
@EMAIL,
@ADDRESS,
@DEPART,
@MAKERID,
@DATE,
@YEAR,
@MONTH,
@DAY

)


";

        string setsqlt = @"

INSERT INTO SUPPLIERINFO_MST
(
SUID,
SNAME,
SUKEY,
DATE,
MAKERID,
YEAR,
MONTH,
DAY,
PAYMENT,
PAYMENT_CLAUSE,
SUPPLIER_ID,
USER_DEFINED_ONE,
USER_DEFINED_TWO,
USER_DEFINED_THREE,
USER_DEFINED_FOUR,
USER_DEFINED_FIVE,
USER_DEFINED_SIX,
USER_DEFINED_SEVEN,
USER_DEFINED_EIGHT,
USER_DEFINED_NINE,
USER_DEFINED_TEN,
REMARK,
SALE_AUDIT,
FINANCIAL_AUDIT,
OFFICE_AUDIT

)
VALUES
(
@SUID,
@SNAME,
@SUKEY,
@DATE,
@MAKERID,
@YEAR,
@MONTH,
@DAY,
@PAYMENT,
@PAYMENT_CLAUSE,
@SUPPLIER_ID,
@USER_DEFINED_ONE,
@USER_DEFINED_TWO,
@USER_DEFINED_THREE,
@USER_DEFINED_FOUR,
@USER_DEFINED_FIVE,
@USER_DEFINED_SIX,
@USER_DEFINED_SEVEN,
@USER_DEFINED_EIGHT,
@USER_DEFINED_NINE,
@USER_DEFINED_TEN,
@REMARK,
@SALE_AUDIT,
@FINANCIAL_AUDIT,
@OFFICE_AUDIT
)
";
        string setsqlth = @"
UPDATE SUPPLIERINFO_MST SET 
SNAME=@SNAME,
SUKEY=@SUKEY,
DATE=@DATE,
MAKERID=@MAKERID,
YEAR=@YEAR,
MONTH=@MONTH,
DAY=@DAY,
PAYMENT=@PAYMENT,
PAYMENT_CLAUSE=@PAYMENT_CLAUSE,
SUPPLIER_ID=@SUPPLIER_ID,
USER_DEFINED_ONE=@USER_DEFINED_ONE,
USER_DEFINED_TWO=@USER_DEFINED_TWO,
USER_DEFINED_THREE=@USER_DEFINED_THREE,
USER_DEFINED_FOUR=@USER_DEFINED_FOUR,
USER_DEFINED_FIVE=@USER_DEFINED_FIVE,
USER_DEFINED_SIX=@USER_DEFINED_SIX,
USER_DEFINED_SEVEN=@USER_DEFINED_SEVEN,
USER_DEFINED_EIGHT=@USER_DEFINED_EIGHT,
USER_DEFINED_NINE=@USER_DEFINED_NINE,
USER_DEFINED_TEN=@USER_DEFINED_TEN,
REMARK=@REMARK,
SALE_AUDIT=@SALE_AUDIT,
FINANCIAL_AUDIT=@FINANCIAL_AUDIT,
OFFICE_AUDIT=@OFFICE_AUDIT
";


        #endregion
        DataTable dt = new DataTable();
      
        public CDECUMENTARY()
        {
            sql = setsql;
            sqlo = setsqlo;
            sqlt = setsqlt;
            sqlth = setsqlth;
        }
        public string GETID()
        {
            string v1 = bc.numYM(10, 4, "0001", "SELECT * FROM DECUMENTARY", "DUID", "DU");
            string GETID = "";
            if (v1 != "Exceed Limited")
            {
                GETID = v1;
            }
            return GETID;
        }
    
    }
}
