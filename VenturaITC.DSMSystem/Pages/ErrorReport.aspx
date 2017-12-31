<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ErrorReport.aspx.cs" Inherits="VenturaITC.DSMSystem.Pages.ErrorReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Reporte de Erro</h2>
    <hr />
    <br />
    <div class="form-horizontal">
        <div class="form-group required">
            <asp:Label runat="server" AssociatedControlID="txtDescription" CssClass="col-md-2 control-label">Descrição</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control" TextMode="MultiLine" Width="100%" Height="100px" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDescription"
                    CssClass="text-danger" ErrorMessage="O campo descrição é de preenchimento obrigatório." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtErrorMsg" CssClass="col-md-2 control-label">Erro</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtErrorMsg" CssClass="form-control" TextMode="MultiLine" Width="100%" Height="160px" ReadOnly="true" />
            </div>
        </div>
    </div>
    <br />
    <div class="modal-footer">
        <asp:Button runat="server" ID="btnClose" Text="Fechar" CssClass="btn btn-default" CausesValidation="False" OnClick="btnClose_Click" />
        <asp:Button runat="server" ID="btnReport" Text="Reportar" OnClick="btnReport_Click" CssClass="btn btn-primary" />
    </div>
</asp:Content>
