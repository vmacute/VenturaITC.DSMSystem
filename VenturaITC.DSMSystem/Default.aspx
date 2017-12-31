<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VenturaITC.DSMSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
<%--    <div class="jumbotron" style="text-align: center; background-image: url('Images/home_background.jpg') ; background-repeat: no-repeat; background-size:cover">--%>
    <div class="jumbotron">
        <div style="text-align: center;">
            <asp:Label runat="server" Text="Sistema de Gestão de Escola de Condução" Font-Size="30px" Font-Bold="true" ForeColor="#B11d49" />
            <br />
            <asp:Label runat="server" Text="Escola de Condução Malengane" Font-Size="Large" Font-Bold="true" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div style="text-align: center">
                <h2>Inscrições</h2>
                <asp:Image runat="server" ImageUrl="~/Images/registration.png" Width="100px" Height="100px"></asp:Image>
                <p>
                    Módulo de inscrições e gestão de alunos, quer internos assim como externos.
                </p>
            </div>
        </div>
        <div class="col-md-4">
            <div style="text-align: center">
                <h2>Pagamentos</h2>
                <asp:Image runat="server" ImageUrl="~/Images/payments.png" Width="100px" Height="100px"></asp:Image>
                <p>
                    Módulo de gestão de pagamentos.
                    A modalidade de pagamento pode ser total ou em prestações.
                </p>
            </div>
        </div>
        <div class="col-md-4">
            <div style="text-align: center">
                <h2>Testes</h2>
                <asp:Image runat="server" ImageUrl="~/Images/test.png" Width="100px" Height="100px"></asp:Image>
                <p>
                    Módulo de carregamento de exercícios, realização e gestão de testes.
                </p>

            </div>
        </div>
    </div>
</asp:Content>
