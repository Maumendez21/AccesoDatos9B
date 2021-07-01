<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebPruebaAccesoSQL.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" href="css/sweetalert2.min.css" />
<script src="js/sweetalert2.all.min.js" ></script>
<script src="js/index.js"></script>

<title></title>
</head>
<body>
    <button onclick="msgbox('jjj', 'sss', 'success')" >aaa</button>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Probar Conexión" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Consulta DataReader" />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Width="496px"></asp:TextBox>
            <br />
            <br />
            <asp:ListBox ID="ListBox1" runat="server" Height="112px" Width="496px"></asp:ListBox>
            <br />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="ConsultaDataSet" />
&nbsp;
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="ObtenDataSet" />
            <br />
            <asp:GridView ID="GridView1" runat="server" Height="159px" Width="499px">
            </asp:GridView>
            <br />
            <br />
            <br />
            ID:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;&nbsp; Nombre:
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Button" />
            <br />
            <br />
            idProd:
            <asp:TextBox ID="txtIdProd" runat="server"></asp:TextBox>
&nbsp;Descripcion:
            <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
&nbsp;Categoria
            <asp:TextBox ID="txtCategoria" runat="server"></asp:TextBox>
&nbsp;precio
            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Button" />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
