<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserManager.aspx.cs" Inherits="VenturaITC.DSMSystem.Pages.UserManager" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">

        function RefreshPage() {
            __doPostBack();
        }

    </script>

    <h2>Gestão de Utilizadores</h2>
    <hr />
    <div style="display: table;">
        <div style="display: table-row;">
            <div style="display: table-cell;">
                <asp:Label runat="server" Font-Bold="true" Text="Estado" />
            </div>
            <div style="display: table-cell; padding-left: 10px">
                <asp:DropDownList runat="server" ID="ddlStatusFilter" CssClass="form-control" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="ddlStatusFilter_OnSelectedIndexChanged" />
            </div>
        </div>
    </div>
    <div style="padding-top: 20px; overflow: auto;">
        <telerik:RadGrid ID="rgUsers" runat="server" AllowSorting="True" AllowPaging="True"
            AutoGenerateColumns="False" GroupPanelPosition="Top" ResolvedRenderMode="Classic"
            Culture="pt-BR" Width="102%" Height="100%" RenderMode="Lightweight" ViewStateMode="Enabled"
            ShowFooter="True" AllowFilteringByColumn="True" CellSpacing="-1" PageSize="20"
            Skin="Default" OnNeedDataSource="rgUsers_NeedDataSource" OnItemCommand="rgUsers_ItemCommand">
            <PagerStyle Mode="NextPrevAndNumeric" />
            <GroupingSettings CaseSensitive="false" />
            <ClientSettings>
                <Selecting AllowRowSelect="True" />
                <Scrolling UseStaticHeaders="True" />
            </ClientSettings>
            <MasterTableView DataKeyNames="username" HorizontalAlign="NotSet" Width="100%" CommandItemDisplay="Top">
                <CommandItemTemplate>
                    <div style="padding: 5px;">
                        <asp:LinkButton runat="server" ID="lnkBtnAdd" OnClick="lnkBtnAdd_Click" CausesValidation="false">
                        <asp:Image runat="server" ImageUrl="~/Images/addUser.png" Width="20px" Height="20px"  ToolTip="Adicionar utilizador" AlternateText="Adicionar utilizador"></asp:Image>
                        </asp:LinkButton>
                        &nbsp;&nbsp;
                    <asp:LinkButton runat="server" ID="lnkBtnRefresh" OnClick="lnkBtnRefresh_Click" CausesValidation="false">
                        <asp:Image runat="server" ImageUrl="~/Images/refresh.png" Width="20px" Height="20px" AlternateText="Refresh"  ToolTip="Refresh"></asp:Image>
                    </asp:LinkButton>

                    </div>
                </CommandItemTemplate>
                <NoRecordsTemplate>
                    <div>
                        Nenhum dado encontrado!!!
                    </div>
                </NoRecordsTemplate>
                <Columns>
                    <telerik:GridBoundColumn DataField="username" FilterControlAltText="Filter username column"
                        HeaderText="Username" UniqueName="username" AutoPostBackOnFilter="True"
                        CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="role" FilterControlAltText="Filter role column"
                        HeaderText="Tipo" UniqueName="role" AutoPostBackOnFilter="True"
                        CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="locked" FilterControlAltText="Filter locked column"
                        HeaderText="Bloqueiado" UniqueName="locked" AutoPostBackOnFilter="True"
                        CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="False" AllowFiltering="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="disabled" FilterControlAltText="Filter disabled column"
                        HeaderText="Desabilitado" UniqueName="disabled" AutoPostBackOnFilter="True"
                        CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="False" AllowFiltering="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="logged" FilterControlAltText="Filter logged column"
                        HeaderText="Logado" UniqueName="logged" AutoPostBackOnFilter="True"
                        CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="False" AllowFiltering="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="last_login" FilterControlAltText="Filter last_login column"
                        HeaderText="Último Login" UniqueName="last_login" AutoPostBackOnFilter="True" DataFormatString="{0:dd/MM/yyyy hh:mm:ss}"
                        CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="False" AllowFiltering="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="current_login_attempts" FilterControlAltText="Filter current_login_attempts column"
                        HeaderText="Tent. Login" UniqueName="last_login" AutoPostBackOnFilter="True"
                        CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="False" AllowFiltering="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="status" FilterControlAltText="Filter status column"
                        HeaderText="Estado" UniqueName="status" AutoPostBackOnFilter="True"
                        CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="false" AllowFiltering="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridButtonColumn CommandName="cmdDetails" Text="Detalhes" UniqueName="cmdDetails">
                        <ItemStyle Font-Size="small" ForeColor="#B11D49" Font-Underline="True" />
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn CommandName="cmdEdit" Text="Editar" UniqueName="cmdEdit">
                        <ItemStyle Font-Size="small" ForeColor="#B11D49" Font-Underline="True" />
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn CommandName="cmdResetPassword" Text="Reiniciar_Pswrd" UniqueName="cmdResetPassword">
                        <ItemStyle Font-Size="small" ForeColor="#B11D49" Font-Underline="True" />
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn CommandName="cmdUnlock" Text="Desbloqueiar" UniqueName="cmdUnlock">
                        <ItemStyle Font-Size="small" ForeColor="#B11D49" Font-Underline="True" />
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn CommandName="cmdDisable" Text="Desabilitar" UniqueName="cmdDisable">
                        <ItemStyle Font-Size="small" ForeColor="#B11D49" Font-Underline="True" />
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn CommandName="cmdEnable" Text="Habilitar" UniqueName="cmdEnable">
                        <ItemStyle Font-Size="small" ForeColor="#B11D49" Font-Underline="True" />
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn CommandName="cmdDelete" Text="Eliminar" UniqueName="cmdDelete">
                        <ItemStyle Font-Size="small" ForeColor="#B11D49" Font-Underline="True" />
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn CommandName="cmdRecover" Text="Recuperar" UniqueName="cmdRecover">
                        <ItemStyle Font-Size="small" ForeColor="#B11D49" Font-Underline="True" />
                    </telerik:GridButtonColumn>
                </Columns>
            </MasterTableView>
            <FilterMenu RenderMode="Lightweight">
            </FilterMenu>
            <HeaderContextMenu RenderMode="Lightweight">
            </HeaderContextMenu>
        </telerik:RadGrid>
    </div>
    <!-- End Modals -->
    <div class="modal fade" id="userDetails" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title title" id="myModalLabel">Detalhes do Utilizador</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Fechar">
                        <span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body" style="font-size: small">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtFullNameDetail" CssClass="col-md-3 control-label">Nome Completo</asp:Label><div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtFullNameDetail" CssClass="form-control" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtCellPhoneDetail" CssClass="col-md-3 control-label">Nº Celular</asp:Label><div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtCellPhoneDetail" CssClass="form-control" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtEmailDetail" CssClass="col-md-3 control-label">Email</asp:Label><div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtEmailDetail" CssClass="form-control" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtRegistrationDate" CssClass="col-md-3 control-label">Data Registo</asp:Label><div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtRegistrationDate" CssClass="form-control" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtRegistrationUser" CssClass="col-md-3 control-label">Utilizador Registo</asp:Label><div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtRegistrationUser" CssClass="form-control" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtMustChangePassword" CssClass="col-md-3 control-label">Deve Mudar Pswrd</asp:Label><div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtMustChangePassword" CssClass="form-control" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtLastPasswordChange" CssClass="col-md-3 control-label">Última Mudança Password</asp:Label><div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtLastPasswordChange" CssClass="form-control" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="confirmUserDelete" tabindex="-1" role="dialog" aria-labelledby="modalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title title" id="modalLabel">Confirmação</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Fechar">
                        <span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <asp:Image runat="server" ImageUrl="~/Images/question.png" Width="50px" Height="50px"></asp:Image>
                    &nbsp;
                    <asp:Label runat="server" ID="lblConfirmMsg"></asp:Label>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" Text="Não" CssClass="btn btn-secondary" data-dismiss="modal" />
                    <asp:Button runat="server" ID="btnConfirmDelete" Text="Sim" CssClass="btn btn-primary" OnClick="btnConfirmDelete_Click" CausesValidation="False" />
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="userUpdate" tabindex="-1" role="dialog" aria-labelledby="modalLabel2" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title title" id="modalLabel2">Actualização de Dados de Utilizador</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Fechar">
                        <span aria-hidden="true">&times;</span></button>
                </div>
                <asp:UpdatePanel ID="uPnlUpdateUser" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pnlUpdateUser" runat="server" Width="100%">
                            <div class="modal-body">
                                <asp:Panel runat="server" ID="pnlErrorUserUpdate" Visible="false">
                                    <div class="alert alert-danger" role="alert">
                                        <asp:Literal runat="server" ID="errorUserUpdateMsg" />
                                    </div>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="pnlSucessUserUpdate" Visible="false">
                                    <div class="alert alert-success" role="alert">
                                        <asp:Literal runat="server" ID="sucessUserUpdateMsg" />
                                    </div>
                                </asp:Panel>
                                <div class="form-horizontal">
                                    <div class="form-group required">
                                        <asp:Label runat="server" AssociatedControlID="txtFullName" CssClass="col-md-3 control-label">Nome Completo</asp:Label><div class="col-md-9">
                                            <asp:TextBox runat="server" ID="txtFullName" CssClass="form-control" />
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFullName"
                                                CssClass="text-danger" ErrorMessage="O campo nome completo é de preenchimento obrigatório." />
                                        </div>
                                    </div>
                                    <div class="form-group required">
                                        <asp:Label runat="server" AssociatedControlID="txtCellPhone" CssClass="col-md-3 control-label">Nº Celular</asp:Label><div class="col-md-9">
                                            <asp:TextBox runat="server" ID="txtCellPhone" CssClass="form-control" TextMode="Number" MaxLength="7" />
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCellPhone"
                                                CssClass="text-danger" ErrorMessage="O campo nº celular é de preenchimento obrigatório." Display="Dynamic" />
                                            <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCellPhone"
                                                CssClass="text-danger" ErrorMessage="Nº de celular inválido! Ex. de formato válido: 8212345670"
                                                ValidationExpression="^82(\d{7})|83(\d{7})|84(\d{7})|85(\d{7})|86(\d{7})|87(\d{7})$" Display="Dynamic" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col-md-3 control-label">Email</asp:Label><div class="col-md-9">
                                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" />
                                        </div>
                                    </div>
                                    <div class="form-group required">
                                        <asp:Label runat="server" AssociatedControlID="ddlRole" CssClass="col-md-3 control-label">Tipo</asp:Label><div class="col-md-9">
                                            <asp:DropDownList runat="server" ID="ddlRole" CssClass="form-control" />
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlRole"
                                                CssClass="text-danger" ErrorMessage="O campo tipo é de preenchimento obrigatório." />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="Button2" Text="Fechar" OnClientClick="RefreshPage()" CssClass="btn btn-secondary" CausesValidation="false" />
                                <asp:Button runat="server" ID="btnUpdateUser" Text="Gravar" OnClick="btnUpdateUser_Click" CssClass="btn btn-primary" />
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <div class="modal fade" id="resetUserPassword" tabindex="-1" role="dialog" aria-labelledby="modalLabel3" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title title" id="modalLabel3">Reset de Password</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Fechar">
                        <span aria-hidden="true">&times;</span></button>
                </div>
                <asp:UpdatePanel ID="uPnlResetPassword" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pnlResetPassword" runat="server" Width="100%">
                            <div class="modal-body">
                                <asp:Panel runat="server" ID="pnlErrorResetPass" Visible="false">
                                    <div class="alert alert-danger" role="alert">
                                        <asp:Literal runat="server" ID="errorResetPassMsg" />
                                    </div>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="pnlSucessResetPass" Visible="false">
                                    <div class="alert alert-success" role="alert">
                                        <asp:Literal runat="server" ID="sucessResetPassMsg" />
                                    </div>
                                </asp:Panel>
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtFullName" CssClass="col-md-3 control-label">Username</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control" Enabled="false" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="col-md-3 control-label">Password Inicial</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="Button1" Text="Fechar" OnClientClick="RefreshPage()" CssClass="btn btn-secondary" CausesValidation="false" />
                                <asp:Button runat="server" ID="btnResetPassword" Text="Gravar" OnClick="btnResetPassword_Click" CssClass="btn btn-primary" CausesValidation="false" />
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- End Modals -->
</asp:Content>
