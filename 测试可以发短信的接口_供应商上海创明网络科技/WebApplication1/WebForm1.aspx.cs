using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;

namespace SendSmsDemo_web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //http://smsapi.c123.cn/OpenPlatform/OpenApi?action=sendOnce&ac=1001@501198720001&authkey=6F8D8B0B3E10714C7C60C9E773312FC6&cgid=52&csid=1001@50119872&c=%e5%b8%8c%e5%93%b2%e8%bd%af%e4%bb%b6&m=13511634094,15962654095
            //http://smsapi.c123.cn/OpenPlatform/OpenApi?action=sendOnce&ac=1001@501198720001&authkey=6F8D8B0B3E10714C7C60C9E773312FC6&csid=52&cgid=1001@50119872&c=abc&m=13511634094,15962654095
        }
        private void a()
        {
            TextBox4.Text = DateTime.Now.ToString("yyyyMMddHHmmss");//大写HH表示24小时制时间
            string m = TextBox1.Text;
            string a = TextBox2.Text;
            string c = Server.UrlEncode(a);
            //string c =TransferEncoding(Encoding.Default, Encoding.UTF8, a);
            string address = "http://smsapi.c123.cn/OpenPlatform/OpenApi?";
            string action = "sendOnce";
            /*string ac= "1001@501198720001";
            string authkey = "6F8D8B0B3E10714C7C60C9E773312FC6";
            string cgid = "52";
            string csid = "1001@50119872";*/
            string ac = "1001@501154290001";
            string authkey = "D065F69BBBC103D7C44860EBCB7F8EA1";
            string cgid = "52";
            string csid = "1001@50119872";
            string v1=address +"action={0}&"+"ac={1}&"+"authkey={2}&"+"cgid={3}&"+"csid={4}&"+"c={5}&"+"m={6}";
            string v2 = string.Format(v1, action ,ac, authkey, cgid,csid, c, m);
            Response.Write(v2);
            Response.Redirect(v2);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            a();
        }

        public static string TransferEncoding(Encoding srcEncoding, Encoding dstEncoding, string srcStr)
        {
            byte[] srcBytes = srcEncoding.GetBytes(srcStr);
            byte[] bytes = Encoding.Convert(srcEncoding, dstEncoding, srcBytes);
            return dstEncoding.GetString(bytes);
        }
     


 
    }
}