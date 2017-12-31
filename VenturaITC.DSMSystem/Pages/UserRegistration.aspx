<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="VenturaITC.DSMSystem.Pages.UserRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Cadastro de Utilizador</h2>
    <hr />
    <div class="form-horizontal">
        <div class="form-group required">
            <asp:Label runat="server" AssociatedControlID="txtFullName" CssClass="col-md-2 control-label">Nome Completo</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtFullName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFullName"
                    CssClass="text-danger" ErrorMessage="O campo nome completo é de preenchimento obrigatório." />
            </div>
        </div>
        <div class="form-group required">
            <asp:Label runat="server" AssociatedControlID="txtCellPhone" CssClass="col-md-2 control-label">Nº Celular</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCellPhone" CssClass="form-control" TextMode="Number" MaxLength="7" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCellPhone"
                    CssClass="text-danger" ErrorMessage="O campo nº celular é de preenchimento obrigatório." Display="Dynamic" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCellPhone"
                    CssClass="text-danger" ErrorMessage="Nº de celular inválido! Ex. de formato válido: 8212345670"
                    ValidationExpression="^82(\d{7})|83(\d{7})|84(\d{7})|85(\d{7})|86(\d{7})|87(\d{7})$" Display="Dynamic" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" />
            </div>
        </div>
        <div class="form-group required">
            <asp:Label runat="server" AssociatedControlID="ddlRole" CssClass="col-md-2 control-label">Tipo</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlRole" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlRole"
                    CssClass="text-danger" ErrorMessage="O campo tipo é de preenchimento obrigatório." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtUsername" CssClass="col-md-2 control-label">Username</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUsername"
                    CssClass="text-danger" ErrorMessage="O campo usernam é de preenchimento obrigatório." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="col-md-2 control-label">Password Inicial</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword"
                    CssClass="text-danger" ErrorMessage="O campo password inicial de preenchimento obrigatório." />
            </div>
        </div>
    </div>
    <div class="modal-footer">
        <asp:Button runat="server" ID="btnBack" Text="<<Voltar" CssClass="btn btn-default" CausesValidation="False" OnClick="btnBack_Click" />
        <asp:Button runat="server" ID="btnClear" Text="Limpar" OnClick="btnClear_Click" CssClass="btn btn-default" CausesValidation="False" />
        <asp:Button runat="server" ID="btnSave" Text="Gravar" OnClick="SaveUser_Click" CssClass="btn btn-primary" />
    </div>
</asp:Content>
