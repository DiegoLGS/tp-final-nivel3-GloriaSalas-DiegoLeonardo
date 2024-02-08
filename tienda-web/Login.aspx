<%@ Page Title="Login" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="tienda_web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex" style="min-height:82vh">
        <div class="col-6 m-auto bg-info bg-opacity-25 p-3 rounded">
            <h3 class="mt-3 mb-3">Login</h3>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" cssclass="form-control" Required="True" ID="txtEmail" />
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" cssclass="form-control" Required="True" ID="txtPassword" TextMode="Password"/>
            </div>
            <asp:Label runat="server" Text="" ID="lblAviso" CssClass="text-danger" />
            <div class="text-center">
                <asp:Button Text="Ingresar" cssclass="btn btn-primary m-1" ID="btnLogin" OnClick="btnLogin_Click" runat="server" />
                <a href="Default.aspx" class="btn btn-outline-danger m-2">Cancelar</a>
            </div>            
        </div>
    </div>
</asp:Content>
