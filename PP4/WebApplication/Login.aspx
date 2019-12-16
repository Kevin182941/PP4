<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PP4.Frm_Login" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Estilos/EstiloLogin.css" type="text/css" rel="stylesheet" />
    <title></title>    
</head>
<body>
          <form class="login" runat="server">
          <h1 class="login-title">Cine </h1>
               
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               
                <asp:Image class="FormatoCentralizado" ID="Image2" runat="server" Height="137px" ImageUrl="~/Imagenes/login.png" Width="160px" />

                

        <div>
            <asp:TextBox CssClass="login-input" ID="txtUsuario" runat="server" Placeholder="Usuario"></asp:TextBox>
            <asp:TextBox CssClass="login-input" ID="txtClave" runat="server" Placeholder="Password" TextMode="Password"></asp:TextBox>
            <asp:Button CssClass="login-button" ID="BtnIngresar" runat="server" Text="Ingresar" OnClick="BtnIngresar_Click" />
            <div>
                <br />
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Recuperar Datos de Ingreso</asp:LinkButton>
            </div>
        </div>
    </form>>
</body>
</html>
