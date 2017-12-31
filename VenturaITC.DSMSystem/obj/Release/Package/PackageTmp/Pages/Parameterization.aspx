<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Parameterization.aspx.cs" Inherits="VenturaITC.DSMSystem.Pages.Parameterization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        function RefreshPage() {
            __doPostBack();
        }
    </script>

    <h2>Parametrização</h2>
    <hr />
    <br />
    <div class="form-horizontal">
        <fieldset>
            <legend class="title">Preçário</legend>
            <div class="form-group required">
                <asp:Label runat="server" AssociatedControlID="txtLightVehiclePrice" CssClass="col-md-2 control-label">Ligeiro</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtLightVehiclePrice" CssClass="form-control" TextMode="Number" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLightVehiclePrice"
                        CssClass="text-danger" ErrorMessage="Campo de preenchimento obrigatório." />
                </div>
            </div>
            <div class="form-group required">
                <asp:Label runat="server" AssociatedControlID="txtHeavyVehiclePrice" CssClass="col-md-2 control-label">Pesado</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtHeavyVehiclePrice" CssClass="form-control" TextMode="Number" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtHeavyVehiclePrice"
                        CssClass="text-danger" ErrorMessage="Campo de preenchimento obrigatório." />
                </div>
            </div>
            <div class="form-group required">
                <asp:Label runat="server" AssociatedControlID="txtMotorcyclePrice" CssClass="col-md-2 control-label">Moto</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtMotorcyclePrice" CssClass="form-control" TextMode="Number" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMotorcyclePrice"
                        CssClass="text-danger" ErrorMessage="Campo de preenchimento obrigatório." />
                </div>
            </div>
            <div class="form-group required">
                <asp:Label runat="server" AssociatedControlID="txtMechanicsPrice" CssClass="col-md-2 control-label">Mecânica</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtMechanicsPrice" CssClass="form-control" TextMode="Number" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMechanicsPrice"
                        CssClass="text-danger" ErrorMessage="Campo de preenchimento obrigatório." />
                </div>
            </div>
        </fieldset>
        <br />
        <fieldset>
            <legend class="title">Pagamentos</legend>
            <div class="panel panel-default">
                <div class="panel-heading">Modalidade de pagamento em prestações</div>
                <div class="panel-body">
                    <label class="switch">
                        <asp:CheckBox runat="server" ID="chkEnableInstallments" AutoPostBack="true" OnCheckedChanged="chkEnableInstallments_OnCheckedChanged" />
                        <span class="slider round"></span>
                    </label>
                    <br />
                    <asp:Label ID="lblInstallmentsStatus" runat="server"></asp:Label>
                    <br />
                    <asp:LinkButton runat="server" ID="lnkBtnEnableInstallments" Text="Definir/alterar taxas" OnClick="lnkBtnEnableInstallments_Click"></asp:LinkButton>
                </div>
            </div>
        </fieldset>
    </div>
    <br />
    <div class="modal-footer">
        <asp:Button runat="server" ID="btnSave" Text="Gravar" OnClick="btnSave_Click" CssClass="btn btn-primary" />
    </div>
    <%-- Modals --%>
    <div class="modal fade" id="modalEnableInstallments" tabindex="-1" role="dialog" aria-labelledby="modalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h3 class="modal-title title" id="modalLabel">Taxas de Prestações</></h3>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <asp:UpdatePanel ID="uPnlEnableInstallments" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pnlEnableInstallments" runat="server" Width="100%">
                            <div class="modal-body">
                                <asp:Panel runat="server" ID="pnlError" Visible="false">
                                    <div class="alert alert-danger" role="alert">
                                        <asp:Literal runat="server" ID="erroMsg" />
                                    </div>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="pnlSucess" Visible="false">
                                    <div class="alert alert-success" role="alert">
                                        <asp:Literal runat="server" ID="successMsg" />
                                    </div>
                                </asp:Panel>
                                <div class="panel panel-default">
                                    <div class="panel-heading">Quantidade de prestações</div>
                                    <div class="panel-body">
                                        <div style="display: table;">
                                            <div style="display: table-row;">
                                                <div style="display: table-cell;">
                                                    <asp:RadioButton  ID="rbInstallments2" runat="server" GroupName="grpRbInstallments" AutoPostBack="true" OnCheckedChanged="rbInstallments2_OnCheckedChanged" />
                                                    <asp:Label ID="Label1" runat="server" Text="2"></asp:Label>
                                                </div>
                                                <div style="display: table-cell; padding-left: 30px;">
                                                    <asp:RadioButton ID="rbInstallments3" runat="server" GroupName="grpRbInstallments" AutoPostBack="true" OnCheckedChanged="rbInstallments3_OnCheckedChanged" />
                                                    <asp:Label ID="Label2" runat="server" Text="3"></asp:Label>
                                                </div>
                                                <div style="display: table-cell; padding-left: 30px;">
                                                    <asp:RadioButton ID="rbInstallments4" runat="server" GroupName="grpRbInstallments" AutoPostBack="true" OnCheckedChanged="rbInstallments4_OnCheckedChanged" />
                                                    <asp:Label ID="Label3" runat="server" Text="4"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="form-horizontal">
                                    <asp:Panel runat="server" ID="pnlInstallment1" Visible="false">
                                        <div class="form-group required">
                                            <asp:Label runat="server" AssociatedControlID="txtInstallment1" CssClass="col-md-3 control-label"> % Prestação 1</asp:Label>
                                            <div class="col-md-9    ">
                                                <asp:TextBox runat="server" ID="txtInstallment1" CssClass="form-control" TextMode="Number" Width="200px" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="pnlInstallment2" Visible="false">
                                        <div class="form-group required">
                                            <asp:Label runat="server" AssociatedControlID="txtInstallment2" CssClass="col-md-3 control-label">% Prestação 2</asp:Label>
                                            <div class="col-md-9">
                                                <asp:TextBox runat="server" ID="txtInstallment2" CssClass="form-control" TextMode="Number" Width="200px" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="pnlInstallment3" Visible="false">
                                        <div class="form-group required">
                                            <asp:Label runat="server" AssociatedControlID="txtInstallment3" CssClass="col-md-3 control-label"> % Prestação 3</asp:Label>
                                            <div class="col-md-9    ">
                                                <asp:TextBox runat="server" ID="txtInstallment3" CssClass="form-control" TextMode="Number" Width="200px" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="pnlInstallment4" Visible="false">
                                        <div class="form-group required">
                                            <asp:Label runat="server" AssociatedControlID="txtInstallment4" CssClass="col-md-3 control-label">% Prestação 4</asp:Label>
                                            <div class="col-md-9">
                                                <asp:TextBox runat="server" ID="txtInstallment4" CssClass="form-control" TextMode="Number" Width="200px" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="Button1" Text="Fechar" OnClientClick="RefreshPage()" CssClass="btn btn-default" CausesValidation="false" />
                                <asp:Button runat="server" ID="btnSaveInstallments" Text="Gravar" OnClick="btnSaveInstallments_Click" CssClass="btn btn-primary" />
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <%-- End Modals --%>
</asp:Content>
