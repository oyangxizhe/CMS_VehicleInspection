using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSPSS
{
    static class Program
    {/// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new  LOGIN ());
            //Application.Run(new CSPSS.VOUCHER_MANAGE.DECUMENTARY ());
           //Application.Run(new BASE_INFO.UPLOADFILE_DOMAIN());
            //Application.Run(new BASE_INFO.SUPPLIER_INFO ());
            //Application.Run(new BASE_INFO.SUPPLIER_INFOT());
            //Application.Run(new BASE_INFO.CUSTOMER_INFO());
          //Application.Run(new BASE_INFO.CUSTOMER_INFOT());
            //Application.Run(new BASE_INFO.SHORT_MESSAGE_CONTENT ());

            //Application.Run(new  BASE_INFO .ACCOUNTANT_COURSE ());
            //Application.Run(new CSPSS .USER_MANAGE .USER_INFO ());
            //Application.Run(new CSPSS .USER_MANAGE.REMIND ());
            //Application.Run(new CSPSS.USER_MANAGE.EDIT_RIGHT ());
           
            //Application.Run(new CSPSS.VOUCHER_MANAGE .VOUCHER());

            //Application.Run(new CSPSS .BASE_INFO .EMPLOYEE_INFO ());
            //Application.Run(new CSPSS.MAIN());
            //Application.Run(new C23.StorageManage.frmGodET());
            //Application .Run (new C23.StorageManage .FrmPWGodET());
            //Application.Run(new C23.UserManage.FrmUSER_INFO());
            //Application.Run(new C23.UserManage.FrmEditRight());
            //Application.Run(new C23.EmployeeManage.FrmEmployeeInfo());
        }
    }
}
