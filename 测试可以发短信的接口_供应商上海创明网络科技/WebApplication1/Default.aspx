<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="mt��ͨȺ������" OnClick="Button1_Click" />&nbsp;<asp:Button ID="Button2" runat="server" Text="�����" OnClick="Button2_Click" />
        &nbsp;<asp:Button ID="Button3" runat="server" Text="���ն���" OnClick="Button3_Click" />&nbsp;<asp:Button ID="Button4" runat="server" Text="����Ⱥ������" OnClick="Button4_Click" />
        &nbsp;<asp:Button ID="Button5" runat="server" Text="mdSmsSend_u������" OnClick="Button5_Click" />
    </div>
        <asp:Label ID="Label1" runat="server" Text="������ʾ���"></asp:Label>
    </form>
</body>
</html>

