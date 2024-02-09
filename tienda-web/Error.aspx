<%@ Page Title="Error" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="tienda_web.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-3 mb-3">Error</h1>
    <asp:Label text="Aún no se provocó ningún error, y esperamos que continúe así 😅" id="lblError" runat="server" CssClass="fs-3 mt-2" />    
</asp:Content>
