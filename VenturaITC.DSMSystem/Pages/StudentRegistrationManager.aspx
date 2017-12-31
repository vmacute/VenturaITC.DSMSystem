<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentRegistrationManager.aspx.cs" Inherits="VenturaITC.DSMSystem.Pages.StudentRegistrationManager" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Gestão de Alunos</h2>
    <hr />
    <div>
        <telerik:RadGrid ID="rgStudents" runat="server" AllowSorting="True" AllowPaging="True"
            AutoGenerateColumns="False" GroupPanelPosition="Top" ResolvedRenderMode="Classic"
            Culture="pt-BR" Width="100%" Height="100%" RenderMode="Lightweight" ViewStateMode="Enabled"
            ShowFooter="True" AllowFilteringByColumn="True" CellSpacing="-1" PageSize="20"
            Skin="Default" OnNeedDataSource="rgStudents_NeedDataSource" OnItemCommand="rgStudents_ItemCommand" OnItemDataBound="rgStudents_ItemDataBound">
            <PagerStyle Mode="NextPrevAndNumeric" />
            <GroupingSettings CaseSensitive="false" />
            <ClientSettings>
                <Selecting AllowRowSelect="True" />
                <Scrolling UseStaticHeaders="True" />
            </ClientSettings>
            <MasterTableView DataKeyNames="student_number" HorizontalAlign="NotSet" Width="100%">
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
                    <telerik:GridTemplateColumn HeaderText="Documentação" AllowFiltering="false">
                        <ItemTemplate>
                            <asp:DropDownList runat="server" ID="ddlDocumentation" Width="190px" Font-Size="Small" CssClass="btn btn-default" />
                            &nbsp;
                           <asp:Button runat="server" ID="btnOpenDoc" Text="Abrir" Font-Size="Small" CssClass="btn btn-default" CommandName="cmdOpenDocument" />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridButtonColumn CommandName="cmdDetails" Text="Detalhes" UniqueName="cmdDetails">
                        <ItemStyle Font-Size="small" ForeColor="#B11D49" Font-Underline="True" />
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn CommandName="cmdPrintFile" Text="Imprimir_Ficha" UniqueName="cmdPrintFile">
                        <ItemStyle Font-Size="small" ForeColor="#B11D49" Font-Underline="True" />
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn CommandName="cmdEdit" Text="Editar" UniqueName="cmdEdit">
                        <ItemStyle Font-Size="small" ForeColor="#B11D49" Font-Underline="True" />
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn CommandName="cmdDelete" Text="Eliminar" UniqueName="cmdDelete">
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
    <!-- Modals -->
    <div class="modal fade" id="studentDetailsModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title title" id="myModalLabel">Detalhes do Aluno</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Fechar">
                        <span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body" style="font-size: small">
                    <div style="display: table;">
                        <div style="display: table-row;">
                            <div style="display: table-cell; vertical-align: top">
                                <div style="display: table;">
                                    <div>
                                        <div style="display: table-row;">
                                            <div style="display: table-cell; padding-left: 10px; text-align: right">
                                                <fieldset>
                                                    <legend style="color: #B11D49; font-size: medium; padding-top: 5px;">Dados do Aluno</legend>
                                                </fieldset>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell; padding-left: 10px; text-align: right">
                                            <asp:Label runat="server" Text="Número:" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px;">
                                            <asp:Label runat="server" ID="lblNumber"></asp:Label>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell; padding-left: 10px; padding-top: 5px; text-align: right">
                                            <asp:Label runat="server" Text="Nome:" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px;">
                                            <asp:Label runat="server" ID="lblName"></asp:Label>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell; padding-top: 5px; text-align: right">
                                            <asp:Label runat="server" Text="Data de Nascimento:" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px;">
                                            <asp:Label runat="server" ID="lblBirthDate"></asp:Label>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell; padding-top: 5px; text-align: right">
                                            <asp:Label runat="server" Text="Naturalidade:" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px;">
                                            <asp:Label runat="server" ID="lblPlaceOfBirth"></asp:Label>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell; padding-left: 10px; padding-top: 5px; text-align: right">
                                            <asp:Label runat="server" Text="Província:" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px;">
                                            <asp:Label runat="server" ID="lblProvinceOfBirth"></asp:Label>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell; padding-top: 5px; text-align: right">
                                            <asp:Label runat="server" Text="Nome do pai:" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px;">
                                            <asp:Label runat="server" ID="lblFathersName"></asp:Label>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell; padding-top: 5px; text-align: right">
                                            <asp:Label runat="server" Text="Nome da Mãe:" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px;">
                                            <asp:Label runat="server" ID="lblMothersName"></asp:Label>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell; padding-left: 10px; padding-top: 5px; text-align: right">
                                            <asp:Label runat="server" Text="Estado Civil:" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px;">
                                            <asp:Label runat="server" ID="lblMaritalStatus"></asp:Label>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell; padding-left: 10px; padding-top: 5px; text-align: right">
                                            <asp:Label runat="server" Text="Sexo:" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px;">
                                            <asp:Label runat="server" ID="lblGender"></asp:Label>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell; padding-top: 5px; text-align: right">
                                            <asp:Label runat="server" Text="Residência:" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px;">
                                            <asp:Label runat="server" ID="lblAddress"></asp:Label>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell; padding-left: 10px; padding-top: 5px; text-align: right">
                                            <asp:Label runat="server" Text="Número de BI:" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px;">
                                            <asp:Label runat="server" ID="lblIDNumber"></asp:Label>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell; padding-left: 10px; padding-top: 5px; text-align: right">
                                            <asp:Label runat="server" Text="Local de Emissão:" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px;">
                                            <asp:Label runat="server" ID="lblIDIssuancePlace"></asp:Label>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell; padding-top: 5px; text-align: right">
                                            <asp:Label runat="server" Text="Data de Emissão:" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px;">
                                            <asp:Label runat="server" ID="lblIDIssuanceDate"></asp:Label>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell; padding-top: 5px; text-align: right">
                                            <asp:Label runat="server" Text="Validade" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px;">
                                            <asp:Label runat="server" ID="lblIDExpiryDate"></asp:Label>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell; padding-left: 10px; padding-top: 5px; text-align: right">
                                            <asp:Label runat="server" Text="Nível Académico" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px;">
                                            <asp:Label runat="server" ID="lblAcademicLevel"></asp:Label>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell; padding-top: 5px; text-align: right">
                                            <asp:Label runat="server" Text="Profissão:" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px;">
                                            <asp:Label runat="server" ID="lblJobTitle"></asp:Label>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell;">
                                            <fieldset>
                                                <legend style="color: #B11D49; font-size: medium; padding-top: 20px">Informação da Carta</legend>
                                            </fieldset>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell; text-align: right">
                                            <asp:Label runat="server" Text="Categoria:" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px;">
                                            <asp:Label runat="server" ID="lblCategory"></asp:Label>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell; padding-left: 10px; padding-top: 5px; text-align: right">
                                            <asp:Label runat="server" Text="Data de Inscrição:" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px;">
                                            <asp:Label runat="server" ID="lblRegistrationDate"></asp:Label>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell; padding-left: 10px; padding-top: 5px; text-align: right">
                                            <asp:Label runat="server" Text="Utilizador:" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px;">
                                            <asp:Label runat="server" ID="lblRegistrationUser"></asp:Label>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell; padding-left: 10px; padding-top: 5px; text-align: right">
                                            <asp:Label runat="server" Text="Tipo de Aluno:" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px;">
                                            <asp:Label runat="server" ID="lblStudentType"></asp:Label>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell;">
                                            <fieldset>
                                                <legend style="color: #B11D49; font-size: medium; padding-top: 20px">Contactos</legend>
                                            </fieldset>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell; padding-left: 10px; text-align: right">
                                            <asp:Label runat="server" Text="Nº Telefone:" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px;">
                                            <asp:Label runat="server" ID="lblPhoneNumber"></asp:Label>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell; padding-left: 10px; padding-top: 5px; text-align: right">
                                            <asp:Label runat="server" Text="Nº Celular (Principal)" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px;">
                                            <asp:Label runat="server" ID="lblCellPhone1"></asp:Label>
                                        </div>
                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell; padding-left: 10px; padding-top: 5px; text-align: right">
                                            <asp:Label runat="server" Text="Nº Celular (Alternativo):" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px;">
                                            <asp:Label runat="server" ID="lblCellPhone2"></asp:Label>
                                        </div>

                                    </div>
                                    <div style="display: table-row;">
                                        <div style="display: table-cell; padding-top: 5px; text-align: right">
                                            <asp:Label runat="server" Text="Email" Font-Bold="true"></asp:Label>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px;">
                                            <asp:Label runat="server" ID="lblEmail"></asp:Label>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div style="display: table-cell; padding-left: 75px; text-align: right">
                                <asp:Image ID="imgPicture" runat="server" Width="140px" Height="160px" />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="confirmStudentDelete" tabindex="-1" role="dialog" aria-labelledby="modalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title title" id="modalLabel">Confirmação</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Fechar">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:Image runat="server" ImageUrl="~/Images/question.png" Width="50px" Height="50px"></asp:Image>
                    &nbsp;
                    <asp:Label runat="server" ID="lblConfirmMsg"></asp:Label>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" Text="Não" CssClass="btn btn-secondary" />
                    <asp:Button runat="server" ID="btnConfirmDelete" Text="Sim" CssClass="btn btn-primary" OnClick="btnConfirmDelete_Click" />
                </div>
            </div>
        </div>
    </div>
    <!-- End Modals -->
</asp:Content>
