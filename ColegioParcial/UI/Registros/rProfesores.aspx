<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="rProfesores.aspx.cs" Inherits="ColegioParcial.UI.Registros.rProfesores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div class="page-header text-center col-8">
        <h1><strong>Registro Profesores</strong></h1>
        <br />

    </div>
    <br />

    <div class="form-group row col-9">
        <label for="Idinput" class="col-sm-4 col-form-label text-right">Id</label>
        <div class="col-sm-4">
            <asp:TextBox ID="IDTextBox" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="form-group row col-9">
        <label for="Nombresinput" class="col-sm-4 col-form-label text-right">Nombres</label>
        <div class="col-sm-4">
            <asp:TextBox ID="NombreTextBox" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="form-group row col-9">
        <label for="Apelidosinput" class="col-sm-4 col-form-label text-right">Apellidos</label>
        <div class="col-sm-4">
            <asp:TextBox ID="apellidoTextBox" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="form-group row col-9">
        <label for="Tandainput" class="col-sm-4 col-form-label text-right">Apellidos</label>
        <div class="col-sm-4">
            <asp:TextBox ID="TandaTextBox" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>



    <!--div class="col-sm-10">
        <input type="email" class="form-control form-control-success" id="inputHorizontalSuccess" placeholder="name@example.com">
        <div class="form-control-feedback">Success! You've done it.</div>
        <small class="form-text text-muted">Example help text that remains unchanged.</small>
    </--div--->
    <br />

    <div class="col-9 ml-md-auto">
        <asp:Button ID="BtnNuevo" runat="server" class="btn btn-primary" Text="Nuevo" />
        <asp:Button ID="BtnEliminar" runat="server" class="btn btn-primary " Text="Eliminar" />
        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" class="btn btn-primary" OnClick="BtnGuardar_Click" />
    </div>
</asp:Content>
