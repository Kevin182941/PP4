<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PP4.Login"%>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-9" />
    <title>Login</title>   
     <link href="CSS/Login.css" rel="stylesheet" />
</head>
<body>
    <div class = "login">
        <div class="form-login">
        <h1>Login</h1>
        <img src="Images/Avatar.jpg" class ="avatar"/>
        </div>
        <div class="form-log">       
        <input type="text" placeholder="&#128100;Usuario" />
        <input type="password" placeholder="&#128275;Contraseña" />
        <input class="btn-save" type="submit" value="Login"/>
        <a href ="#">Olvido su Contrasena?</a><br>
        <a href ="Usuarios.aspx">No tiene Cuenta?</a>
            
       </div>    
    </div>

    <%--<form id="form1" runat="server">   
    </form>--%>
</body>
</html>
