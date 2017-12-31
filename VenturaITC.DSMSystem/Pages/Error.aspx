<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="VenturaITC.DSMSystem.Pages.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title></title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="Styles/MyStyles.css" rel="stylesheet" />
    <link href="Styles/Template.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container body-content">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:Image runat="server" ImageUrl="~/Images/error.png" Width="25px" Height="25px"></asp:Image>&nbsp;
                    <asp:Label runat="server" Text="Erro" Font-Size="Medium"></asp:Label>
                </div>
                <div class="panel-body">
                    <asp:TextBox runat="server" ID="txtErrorMsg" Font-Size="Small" CssClass="form-control" TextMode="MultiLine" Width="100%" Height="250px" ReadOnly="true" />
                </div>

            </div>
            <br />
            <div class="modal-footer">
                <asp:Button runat="server" ID="btnBack" Text="<<Voltar" CssClass="btn btn-default" OnClientClick="javascript:history.back(); return false" ToolTip="Voltar" />
                <asp:Button runat="server" ID="btnReport" Text="Reportar" OnClick="btnReport_Click" CssClass="btn btn-primary" />
            </div>
        </div>
        <br />
        <hr />
        <footer>
            <div style="text-align: center;">
                <asp:Label runat="server" ID="lblCopyright" Font-Size="11px"></asp:Label>
                <br />
                <asp:Label runat="server" ID="lblDeveloper" Font-Size="11px" Text="Desenvolvido Por: Ventura IT & Consulting -"></asp:Label>&nbsp;                  
                    <asp:HyperLink ID="hyperlink1" Font-Size="12px" Text="www.venturaitc.co.mz" NavigateUrl="http://www.venturaitc.co.mz" Target="_new" runat="server" />
            </div>
        </footer>
    </form>
</body>
</html>
