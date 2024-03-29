﻿<%@ Page Title="Panel de administración" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="AdministrarArticulos.aspx.cs" Inherits="tienda_web.AdministrarArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .modal {
            display: none;
            position: fixed;
            z-index: 1;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            overflow: auto;
            background-color: rgba(0,0,0,0.4);
        }

        .modal-contenido {
            background-color: #fefefe;
            position: relative;
            z-index: 2;
            margin: 15% auto;
            padding: 20px;
            border: 2px solid #888;
            border-radius: 12px;
            width: 80%;
            max-width: 500px;
        }

        .cerrar {
            color: #aaa;
            position: absolute;
            z-index: 2;
            right: 10px;
            top: 10px;
            font-size: 28px;
            font-weight: bold;
        }
    </style>
    <script>
        function ocultar(event) {
            const modal = document.getElementById("<%= modal.ClientID %>");
            if (event.target === modal) {
                modal.style.display = "none";
            }
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h1 class="mt-3 mb-3">Panel de administración</h1>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <div class="col-sm-12 col-md-6">
                <div class="mb-3">
                    <asp:Label Text="Buscar por nombre:" runat="server" />
                    <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
                </div>
            </div>
                <div class="col-6">
                    <div class="mb-3">
                        <asp:CheckBox Text="*Filtro avanzado"
                            CssClass="" ID="chkAvanzado" runat="server"
                            AutoPostBack="true"
                            OnCheckedChanged="chkAvanzado_CheckedChanged" />
                    </div>
                </div>

    <%if (this.chkAvanzado.Checked)
        {
    %>

            <div class="row">
                <div class ="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                        <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" >
                            <asp:ListItem Text="Nombre" />
                            <asp:ListItem Text="Marca" />
                            <asp:ListItem Text="Categoria" />
                            <asp:ListItem Text="Precio" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class ="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Criterio" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control" />
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Filtro" ID="lblFiltroAvanzado" runat="server" />
                        <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                    </div>
                </div>
            
                <div class="col-3 d-flex align-items-end">
                    <div class="mb-3">
                        <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" id="btnBuscar" OnClick="btnBuscar_Click" />
                    </div>
                </div>
            </div>

    <%}%>
            <asp:GridView runat="server" ID="dgvArticulos" CssClass="table table-dark table-striped table-responsive-md" AutoGenerateColumns="false" 
                DataKeyNames="Id" 
                OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
                OnRowDeleting="dgvArticulos_RowDeleting"
                OnPageIndexChanging="dgvArticulos_PageIndexChanging"
                AllowPaging="true" PageSize="10">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:TemplateField HeaderText="Precio">
                        <ItemTemplate>
                            <%# utilidades.UtilidadPrecio.limitarDecimales(Eval("Precio")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Editar" HeaderText="Modificación" ControlStyle-CssClass="btn btn-sm btn-info" ItemStyle-CssClass="ps-3" />
                    <asp:CommandField ShowDeleteButton="true" DeleteText="Borrar" HeaderText="Eliminación" ControlStyle-CssClass="btn btn-sm btn-danger" ItemStyle-CssClass="ps-3" />
                </Columns>
            </asp:GridView>
            <div class="d-flex">
                <a href="FormularioArticulo.aspx" class="btn btn-primary btn-lg ms-auto">Agregar nuevo artículo</a>
            </div>

            <div runat="server" id="modal" class="modal" onclick="ocultar(event)" >
                <div class="modal-contenido" >
                    <asp:Button runat="server" Text="X" class="cerrar btn btn-default rounded-circle" onclick="btnCancelarEliminar_Click" />
                    <h2>Confirmar eliminación</h2>
                    <p>¿Estás seguro de que deseas eliminar este artículo?</p>
                    <asp:Label runat="server" ID="articuloAEliminar" CssClass="fw-semibold d-block mb-3" />
                    <asp:Button ID="btnConfirmarEliminar" runat="server" Text="Confirmar" CssClass="btn btn-danger" OnClick="btnConfirmarEliminar_Click" />
                    <asp:Button ID="btnCancelarEliminar" runat="server" Text="Cancelar" CssClass="btn btn-secondary ms-2" OnClick="btnCancelarEliminar_Click" />
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
