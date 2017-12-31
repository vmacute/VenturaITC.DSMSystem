<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="VenturaITC.DSMSystem.Pages.Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div class="panel panel-default">
        <div class="panel-heading">
            <asp:Image runat="server" ImageUrl="~/Images/info.png" Width="25px" Height="25px"></asp:Image>&nbsp;
             <asp:Label runat="server" Text="Informação" Font-Size="Medium"></asp:Label>
        </div>
        <div class="panel-body">
            <h3>Navegador não suportado!</h3>
            <div style="padding-top: 5px;">
                <p>Deverá utilizar um dos seguintes navegadores:</p>
                <p>1 - Google Chrome (versão 60.0 ou superior) - <strong>Recomendado</strong></p>
                <p>2 - Mozila Firefox (versão 46.0 ou superior)</p>
            </div>
        </div>
    </div>
</asp:Content>
