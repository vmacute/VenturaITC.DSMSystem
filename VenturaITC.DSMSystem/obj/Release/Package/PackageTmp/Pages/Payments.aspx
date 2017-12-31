<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Payments.aspx.cs" Inherits="VenturaITC.DSMSystem.Pages.Payments" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Pagamentos</h2>
    <hr />
    <div style="display: table;">
        <div style="display: table-row;">
            <div style="display: table-cell;">
                <asp:Label runat="server" Font-Bold="true" Text="Filtro" />
            </div>
            <div style="display: table-cell; padding-left: 10px">
                <asp:DropDownList runat="server" ID="ddlFilter" CssClass="form-control" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="ddlFilter_OnSelectedIndexChanged" />
            </div>
        </div>
    </div>
    <div style="padding-top: 20px">
        <telerik:RadGrid ID="rgPayments" runat="server" AllowSorting="True" AllowPaging="True"
            AutoGenerateColumns="False" GroupPanelPosition="Top" ResolvedRenderMode="Classic"
            Culture="pt-BR" Width="100%" Height="100%" RenderMode="Lightweight" ViewStateMode="Enabled"
            ShowFooter="True" AllowFilteringByColumn="True" CellSpacing="-1" PageSize="20"
            Skin="Default" OnNeedDataSource="rgPayments_NeedDataSource" OnItemCommand="rgPayments_ItemCommand">
            <PagerStyle Mode="NextPrevAndNumeric" />
            <GroupingSettings CaseSensitive="false" />
            <ClientSettings>
                <Selecting AllowRowSelect="True" />
                <Scrolling UseStaticHeaders="True" />
            </ClientSettings>
            <MasterTableView DataKeyNames="student_number" HorizontalAlign="NotSet" Width="100%" CommandItemDisplay="Top">
                <CommandItemTemplate>
  <%--                  <div style="padding: 5px;">
                        <asp:LinkButton runat="server" ID="lnkBtnExportExcel" OnClick="lnkBtnExportExcel_Click">
                        <asp:Image runat="server" ImageUrl="~/Images/excel.png" Width="25px" Height="25px" ToolTip="Extrair Excel" AlternateText="Extrair Excel"></asp:Image>
                        </asp:LinkButton>
                        &nbsp;&nbsp;
                    <asp:LinkButton runat="server" ID="lnkBtnPDF" CausesValidation="false">
                        <asp:Image runat="server" ImageUrl="~/Images/pdf.png" Width="25px" Height="25px" ToolTip="Extrair PDF" AlternateText="Extrair PDF"  CssClass="img-rounded"></asp:Image>
                    </asp:LinkButton>
                    </div>--%>
                </CommandItemTemplate>
                <NoRecordsTemplate>
                    <div>
                        Nenhum dado encontrado!!!
                    </div>
                </NoRecordsTemplate>
                <Columns>
                    <telerik:GridBoundColumn DataField="student_number" FilterControlAltText="Filter student_number column"
                        HeaderText="Número" UniqueName="student_number" AutoPostBackOnFilter="True"
                        CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="full_name" FilterControlAltText="Filter full_name column"
                        HeaderText="Nome" UniqueName="full_name" AutoPostBackOnFilter="True"
                        CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="category" FilterControlAltText="Filter category column"
                        HeaderText="Categoria" UniqueName="category" AutoPostBackOnFilter="True"
                        CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="enrollment_date" FilterControlAltText="Filter enrollment_date column"
                        HeaderText="Data de Inscrição" UniqueName="enrollment_date" AutoPostBackOnFilter="True" DataFormatString="{0:dd/MM/yyyy}"
                        CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="student_type" FilterControlAltText="Filter student_type column"
                        HeaderText="Tipo" UniqueName="student_type" AutoPostBackOnFilter="True"
                        CurrentFilterFunction="Contains" FilterDelay="2000" ShowFilterIcon="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridButtonColumn CommandName="cmdShowPayments" Text="Efectuar_Pagamento" UniqueName="cmdShowPayments">
                        <ItemStyle Font-Size="small" ForeColor="#B11D49" Font-Underline="True" />
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn CommandName="cmdShowPaymentsHist" Text="Histórico" UniqueName="cmdShowPaymentsHist">
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
</asp:Content>
