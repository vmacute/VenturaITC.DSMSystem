<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordChange.aspx.cs" Inherits="VenturaITC.DSMSystem.Pages.PasswordChange" %>

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
    <link href="~/Styles/MyStyles.css" rel="stylesheet" />
    <link href="~/Styles/Template.css" rel="stylesheet" />
</head>
<body class="login-background">
    <form id="form1" runat="server">
        <div class="password-change-panel">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:Image runat="server" ImageUrl="~/Images/password.png" Width="25px" Height="25px" CssClass="img-circle"></asp:Image>&nbsp;
                    <asp:Label runat="server" Text="Mudança de Password" Font-Size="Medium"></asp:Label>
                </div>
                <div class="panel-body">
                    <div class="form-horizontal">
                        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                            <div class="alert alert-danger" role="alert">
                                <p class="text-danger">
                                    <asp:Literal runat="server" ID="erroMsg" />
                                </p>
                            </div>
                        </asp:PlaceHolder>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="col-md-4 control-label">Password Actual</asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword"
                                    CssClass="text-danger" ErrorMessage="Campo de preenchimento obrigatório." />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtNewPassword" CssClass="col-md-4 control-label">Nova Password</asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox runat="server" ID="txtNewPassword" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNewPassword"
                                    CssClass="text-danger" ErrorMessage="Campo de preenchimento obrigatório." />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtNewPasswordConfirm" CssClass="col-md-4 control-label">Confirmar Nova Password</asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox runat="server" ID="txtNewPasswordConfirm" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNewPasswordConfirm"
                                    CssClass="text-danger" ErrorMessage="Campo de preenchimento obrigatório." />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClientClick="javascript:history.back(); return false" />
                        <asp:Button runat="server" ID="btnChangePaswrd" Text="Gravar" OnClick="ChangePassword" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
