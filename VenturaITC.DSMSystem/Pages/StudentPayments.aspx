<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentPayments.aspx.cs" Inherits="VenturaITC.DSMSystem.Pages.StudentPayments" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Pagamentos</h2>
    <hr />
    <br />
    <div class="form-horizontal">
        <fieldset>
            <legend class="title">Dados do Aluno</legend>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtStudentNumber" CssClass="col-md-2 control-label">Número</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtStudentNumber" CssClass="form-control" TextMode="Number" Enabled="false" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtName" CssClass="col-md-2 control-label">Nome</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtName" CssClass="form-control" TextMode="SingleLine" Enabled="false" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtCategory" CssClass="col-md-2 control-label">Categoria</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtCategory" CssClass="form-control" TextMode="SingleLine" Enabled="false" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtRegistrationDate" CssClass="col-md-2 control-label">Data de Inscrição</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtRegistrationDate" CssClass="form-control" TextMode="Date" Enabled="false" />
                </div>
            </div>

        </fieldset>
        <br />
        <fieldset>
            <legend class="title">Pagamentos</legend>
            <asp:Panel runat="server" ID="pnlPayments" Visible="false">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtCost" CssClass="col-md-2 control-label">Valor Total</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtCost" CssClass="form-control" TextMode="Number" Enabled="false" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtPaidAmount" CssClass="col-md-2 control-label">Valor Pago</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtPaidAmount" CssClass="form-control" TextMode="Number" Enabled="false" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtRemainingAmount" CssClass="col-md-2 control-label">Valor Remanescente </asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtRemainingAmount" CssClass="form-control" TextMode="Number" Enabled="false" ForeColor="Red" />
                    </div>
                </div>
                <hr />
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtInstallment" CssClass="col-md-2 control-label">Prestação</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtInstallment" CssClass="form-control" TextMode="Number" Enabled="false" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtInstallmentAmount" CssClass="col-md-2 control-label">Valor da Prestação</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtInstallmentAmount" CssClass="form-control" TextMode="Number" Enabled="false" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtMinAmount" CssClass="col-md-2 control-label">Valor Mínimo a Pagar</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtMinAmount" CssClass="form-control" TextMode="Number" Enabled="false" />
                    </div>
                </div>
                <div class="form-group required">
                    <asp:Label runat="server" AssociatedControlID="txtAmountToPay" CssClass="col-md-2 control-label">Valor a Pagar</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtAmountToPay" CssClass="form-control" TextMode="Number" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAmountToPay" Display="Dynamic"
                            CssClass="text-danger" ErrorMessage="O campo valor a pagar é de preenchimento obrigatório." />
                        <asp:CompareValidator runat="server" ControlToValidate="txtAmountToPay" ControlToCompare="txtMinAmount" Operator="GreaterThanEqual" Display="Dynamic"
                            Type="Double" CssClass="text-danger" ErrorMessage="O valor a pagar não pode ser inferior ao valor mínimo." />
                    </div>
                </div>
                <div class="form-group required">
                    <asp:Label runat="server" AssociatedControlID="txtReceiptNumber" CssClass="col-md-2 control-label">Nº do Recibo</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtReceiptNumber" CssClass="form-control" TextMode="Number" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtReceiptNumber"
                            CssClass="text-danger" ErrorMessage="O campo nº do recibo é de preenchimento obrigatório." />
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlInfo" Visible="false">
                <div class="alert alert-success" role="alert">
                    <asp:Image runat="server" ImageUrl="~/Images/success.png" Width="40px" Height="40px"></asp:Image>
                    &nbsp;
                    <strong>Aluno com pagamento finalizado!</strong>
                </div>
            </asp:Panel>
        </fieldset>
    </div>
    <div class="modal-footer">
        <asp:Button runat="server" ID="btnBack" Text="<<Voltar" OnClick="btnBack_Click" CssClass="btn btn-default" CausesValidation="False" />
        <asp:Button runat="server" ID="btnSubmit" Text="Submeter" OnClick="btnSubmit_Click" CssClass="btn btn-primary" visible="false" />
    </div>
</asp:Content>
