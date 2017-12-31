<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccessDenied.aspx.cs" Inherits="VenturaITC.DSMSystem.Pages.AccessDenied" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div class="panel panel-default">
        <div class="panel-heading">
            <asp:Image runat="server" ImageUrl="~/Images/deny.png" Width="25px" Height="25px"></asp:Image>&nbsp;
            <asp:Label runat="server" Text="Acesso Negado" Font-Size="Medium"></asp:Label>
        </div>
        <div class="panel-body">
            <h3>Utilizador sem permissão para aceder a página!</h3>
        </div>
    </div>
    <br />
    <div class="modal-footer">
        <asp:Button runat="server" ID="btnBack" Text="<<Voltar" CssClass="btn btn-default" OnClientClick="javascript:history.back(); return false" ToolTip="Voltar" />
    </div>
</asp:Content>
