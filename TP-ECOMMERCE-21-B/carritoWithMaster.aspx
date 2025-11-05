  <%@ Import Namespace="dominio" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="carritoWithMaster.aspx.cs" Inherits="TP_ECOMMERCE_21_B.carritoWithMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" ID="textcart"/>
   <% for (int i = 0; i < 5; i++) { %>
    <div class="card">
        <p>Div número <%= i + 1 %></p>
    </div>
<% } %>
</asp:Content>
