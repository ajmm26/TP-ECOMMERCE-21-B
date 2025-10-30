<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TP_ECOMMERCE_21_B.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<!-- Bootstrap CSS -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"/>

<!-- Bootstrap Icons -->
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css"/>

    <link href="Content/estilos.css" rel="stylesheet" />
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
       <asp:Label runat="server" ID="tituloProducto"/>
         <div id="div-details">
             <div id="div-img">
               <asp:Image runat="server" ID="imgProducto" CssClass="imagen-producto" ImageUrl="https://pngimg.com/uploads/shampoo/shampoo_PNG17.png"/>
             </div>
             <div id="div-text">
                <strong><asp:Label runat="server" ID="ttlp"/></strong>
             </div>
         </div>
     </form>
</body>
</html>
