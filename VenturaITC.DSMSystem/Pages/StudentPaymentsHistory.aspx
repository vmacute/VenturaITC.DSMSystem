<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentPaymentsHistory.aspx.cs" Inherits="VenturaITC.DSMSystem.Pages.StudentPaymentsHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Histórico de Pagamentos</h2>
    <hr />
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
    </div>
    <br />
    <telerik:RadGrid ID="rgPayments" runat="server" AllowSorting="True" AllowPaging="True"
        AutoGenerateColumns="False" GroupPanelPosition="Top" ResolvedRenderMode="Classic"
        Culture="pt-BR" Width="100%" Height="100%" RenderMode="Lightweight" ViewStateMode="Enabled"
        ShowFooter="True" AllowFilteringByColumn="False" CellSpacing="-1" PageSize="20"
        Skin="Default" OnItemCommand="rgPayments_ItemCommand">
        <PagerStyle Mode="NextPrevAndNumeric" />
        <GroupingSettings CaseSensitive="false" />
        <ClientSettings>
            <Selecting AllowRowSelect="True" />
            <Scrolling UseStaticHeaders="True" />
        </ClientSettings>
        <MasterTableView DataKeyNames="student_number" HorizontalAlign="NotSet" Width="100%" CommandItemDisplay="Top">
            <CommandItemTemplate>
                <div style="padding: 5px;">
                    <asp:Button ID="btnPrintStatement" runat="server" Text="Imprimir Extracto" CommandName="cmdPrintStatement" Font-Size="Small" CssClass="btn btn-primary"></asp:Button>
                </div>
            </CommandItemTemplate>
            <NoRecordsTemplate>
                <div>
                    Nenhum dado encontrado!!!
                </div>
            </NoRecordsTemplate>
            <Columns>
                <telerik:GridBoundColumn DataField="student_number" FilterControlAltText="Filter student_number column"
                    HeaderText="Número" UniqueName="student_number" AutoPostBackOnFilter="True"
                    CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="False" Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="date" FilterControlAltText="Filter date column"
                    HeaderText="Data" UniqueName="date" AutoPostBackOnFilter="True" DataFormatString="{0:dd/MM/yyyy}"
                    CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="receipt_number" FilterControlAltText="Filter receipt_number column"
                    HeaderText="Nº Recibo" UniqueName="receipt_number"
                    CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="installment_number" FilterControlAltText="Filter receipt_number column"
                    HeaderText="Prestação" UniqueName="installment_number"
                    CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="amount" FilterControlAltText="Filter amount column"
                    HeaderText="Valor Pago" UniqueName="amount" DataFormatString="{0:N}"
                    CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="total_paid_amount" FilterControlAltText="Filter total_paid_amount column"
                    HeaderText="Total Valor Pago" UniqueName="total_paid_amount" DataFormatString="{0:N}"
                    CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="remaining_amount" FilterControlAltText="Filter remaining_amount column"
                    HeaderText="Valor Remanescente" UniqueName="remaining_amount" DataFormatString="{0:N}" ItemStyle-ForeColor="Red"
                    CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="username" FilterControlAltText="Filter username column"
                    HeaderText="Utilizador" UniqueName="username"
                    CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="False">
                </telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
        <FilterMenu RenderMode="Lightweight">
        </FilterMenu>
        <HeaderContextMenu RenderMode="Lightweight">
        </HeaderContextMenu>
    </telerik:RadGrid>
    <br />
    <div class="modal-footer">
        <asp:Button runat="server" ID="btnBack" Text="<<Voltar" CssClass="btn btn-default" CausesValidation="False" OnClick="btnBack_Click" />
    </div>
</asp:Content>
