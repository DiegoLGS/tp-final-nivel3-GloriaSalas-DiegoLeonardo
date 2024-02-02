<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="tienda_web.DetalleProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-3 mb-3">Detalle del producto</h1>
    <asp:Label runat="server" ID="lblAviso" CssClass="fs-3 mt-2" />      
<%if(Request.QueryString["id"] != null)
  {
%>
    <hr />
    <div class="card m-auto border-info">
        <div class="row g-0">
            <div class="col-md-4 text-center align-self-center">
                <asp:Image runat="server" ID="imgArticulo" class="img-fluid rounded-start" onerror="this.src='https://www.mobismea.com/upload/iblock/2a0/2f5hleoupzrnz9o3b8elnbv82hxfh4ld/No%20Product%20Image%20Available.png'" />
            </div>
            <div class="col-md-8">
                <div class="card-body">
                    <asp:Label runat="server" class="card-title fs-1 d-block text-center text-md-start" ID="tituloCard" />
                    <asp:Label runat="server" class="card-text fs-3 d-block text-center text-md-start" ID="descripcionCard" />
                    <asp:Label runat="server" class="card-text fs-3 fw-semibold d-block text-center text-md-start" ID="precioCard" />
                </div>
                <ul class="list-group list-group-flush">
                    <asp:Label runat="server" class="list-group-item" ID="marcaCard" />
                    <asp:Label runat="server" class="list-group-item" ID="categoriaCard" />
                    <asp:Label runat="server" class="list-group-item" ID="codigoCard" />
                    <asp:Label runat="server" class="list-group-item" ID="idCard" />
                </ul>
                <div class="card-body">
                    <asp:HyperLink runat="server" class="card-link" ID="linkPagina" Target="_blank" />
                </div>
            </div>
        </div>
    </div>
    <hr />
    <div class="d-flex">
        <a href="/" class="btn btn-primary btn-lg ms-auto">Regresar</a>
    </div>
<%}%>
</asp:Content>
