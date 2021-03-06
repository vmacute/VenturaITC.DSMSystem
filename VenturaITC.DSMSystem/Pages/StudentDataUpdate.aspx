﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentDataUpdate.aspx.cs" Inherits="VenturaITC.DSMSystem.Pages.StudentDataUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Alteração de Dados do Aluno</h2>
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
            <div class="form-group required">
                <asp:Label runat="server" AssociatedControlID="ddlStudentType" CssClass="col-md-2 control-label">Tipo</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList runat="server" ID="ddlStudentType" CssClass="form-control" Enabled="false" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlStudentType"
                        CssClass="text-danger" ErrorMessage="O campo tipo de aluno é de selecção obrigatória." />
                </div>
            </div>
            <div class="form-group required">
                <asp:Label runat="server" AssociatedControlID="txtName" CssClass="col-md-2 control-label">Nome</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtName" CssClass="form-control long-textbox" TextMode="SingleLine" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName"
                        CssClass="text-danger" ErrorMessage="O campo nome é de preenchimento obrigatório." />
                </div>
            </div>
            <div class="form-group required">
                <asp:Label runat="server" AssociatedControlID="txtBirthDate" CssClass="col-md-2 control-label">Data de Nascimento</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtBirthDate" CssClass="form-control" TextMode="Date" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtBirthDate"
                        CssClass="text-danger" ErrorMessage="O campo data de nascimento é de preenchimento obrigatório." />
                </div>
            </div>
            <div class="form-group required">
                <asp:Label runat="server" AssociatedControlID="ddlGender" CssClass="col-md-2 control-label">Sexo</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList runat="server" ID="ddlGender" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlGender"
                        CssClass="text-danger" ErrorMessage="O campo sexo é de selecção obrigatória." />
                </div>
            </div>
            <div class="form-group required">
                <asp:Label runat="server" AssociatedControlID="ddlMaritalStatus" CssClass="col-md-2 control-label">Estado Civil</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList runat="server" ID="ddlMaritalStatus" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlMaritalStatus"
                        CssClass="text-danger" ErrorMessage="O campo estado civil é de selecção obrigatória." />
                </div>
            </div>
            <div class="form-group required">
                <asp:Label runat="server" AssociatedControlID="txtPlaceOfBirth" CssClass="col-md-2 control-label">Naturalidade</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtPlaceOfBirth" CssClass="form-control" TextMode="SingleLine" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPlaceOfBirth"
                        CssClass="text-danger" ErrorMessage="O campo naturalidade é de preenchimento obrigatório." />
                </div>
            </div>
            <div class="form-group required">
                <asp:Label runat="server" AssociatedControlID="ddlProvinceOfBirth" CssClass="col-md-2 control-label">Província</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList runat="server" ID="ddlProvinceOfBirth" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlProvinceOfBirth"
                        CssClass="text-danger" ErrorMessage="O campo província é de selecção obrigatória." />
                </div>
            </div>
            <div class="form-group required">
                <asp:Label runat="server" AssociatedControlID="txtFathersName" CssClass="col-md-2 control-label">Nome do Pai</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtFathersName" CssClass="form-control" TextMode="SingleLine" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFathersName"
                        CssClass="text-danger" ErrorMessage="O campo nome do pai é de preenchimento obrigatório." />
                </div>
            </div>
            <div class="form-group required">
                <asp:Label runat="server" AssociatedControlID="txtMothersName" CssClass="col-md-2 control-label">Nome da Mãe</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtMothersName" CssClass="form-control" TextMode="SingleLine" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMothersName"
                        CssClass="text-danger" ErrorMessage="O campo nome da mãe é de preenchimento obrigatório." />
                </div>
            </div>
            <div class="form-group required">
                <asp:Label runat="server" AssociatedControlID="txtAddress" CssClass="col-md-2 control-label">Residência</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" TextMode="MultiLine" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAddress"
                        CssClass="text-danger" ErrorMessage="O campo residência é de preenchimento obrigatório." />
                </div>
            </div>
            <div class="form-group required">
                <asp:Label runat="server" AssociatedControlID="txtIDNumber" CssClass="col-md-2 control-label">Nº de BI</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtIDNumber" CssClass="form-control" TextMode="SingleLine" MaxLength="13" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtIDNumber"
                        CssClass="text-danger" ErrorMessage="O campo número de BI é de preenchimento obrigatório." Display="Dynamic" />
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtIDNumber"
                        CssClass="text-danger" ErrorMessage="Nº de BI inválido!" ValidationExpression="^\d{12}[A-Z]$" Display="Dynamic" />
                </div>
            </div>
            <div class="form-group required">
                <asp:Label runat="server" AssociatedControlID="ddlIDIssuancePlace" CssClass="col-md-2 control-label">Local de Emissão</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList runat="server" ID="ddlIDIssuancePlace" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlIDIssuancePlace"
                        CssClass="text-danger" ErrorMessage="O campo local de emissão é de selecção obrigatória." />
                </div>
            </div>
            <div class="form-group required">
                <asp:Label runat="server" AssociatedControlID="txtIDIssuanceDate" CssClass="col-md-2 control-label">Data de Emissão</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtIDIssuanceDate" CssClass="form-control" TextMode="Date" ClientIDMode="Static" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtIDIssuanceDate"
                        CssClass="text-danger" ErrorMessage="O campo data de emissão é de preenchimento obrigatório." />
                </div>
            </div>
            <div class="form-group required">
                <asp:Label runat="server" AssociatedControlID="txtIDExpiryDate" CssClass="col-md-2 control-label">Data de Validade</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtIDExpiryDate" CssClass="form-control" TextMode="Date" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtIDExpiryDate" Display="Dynamic"
                        CssClass="text-danger" ErrorMessage="O campo data de validade é de preenchimento obrigatório." />
                    <asp:CompareValidator runat="server" ControlToValidate="txtIDExpiryDate" ControlToCompare="txtIDIssuanceDate" Operator="GreaterThan" Display="Dynamic"
                        Type="Date" CssClass="text-danger" ErrorMessage="A data de validade não pode ser anterior à data de emissão." />
                </div>
            </div>
            <div class="form-group required">
                <asp:Label runat="server" AssociatedControlID="ddlAcademicLevel" CssClass="col-md-2 control-label">Nível Académico</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList runat="server" ID="ddlAcademicLevel" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlAcademicLevel"
                        CssClass="text-danger" ErrorMessage="O campo nível académico é de selecção obrigatória." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtJobTitle" CssClass="col-md-2 control-label">Profissão</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtJobTitle" CssClass="form-control" TextMode="SingleLine" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtPhoneNumber" CssClass="col-md-2 control-label">Nº de Telefone</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtPhoneNumber" CssClass="form-control" TextMode="Number" />
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtPhoneNumber"
                        CssClass="text-danger" ErrorMessage="Nº de telefone inválido! Ex. de formato válido: 21654321/293123456"
                        ValidationExpression="^21(\d{6})|281(\d{6})|282(\d{6})|293(\d{6})|23(\d{6})|251(\d{6})252(\d{6})|24(\d{6})|26(\d{6})|271(\d{6})|272(\d{6})$" Display="Dynamic" />
                </div>
            </div>
            <div class="form-group required">
                <asp:Label runat="server" AssociatedControlID="txtCellPhone1" CssClass="col-md-2 control-label">Nº Celular (Principal)</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtCellPhone1" CssClass="form-control" TextMode="Number" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCellPhone1"
                        CssClass="text-danger" ErrorMessage="O campo nº celular (principal) é de preenchimento obrigatório." Display="Dynamic" />
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCellPhone1"
                        CssClass="text-danger" ErrorMessage="Nº de celular inválido! Ex. de formato válido: 8212345670"
                        ValidationExpression="^82(\d{7})|83(\d{7})|84(\d{7})|85(\d{7})|86(\d{7})|87(\d{7})$" Display="Dynamic" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtCellPhone2" CssClass="col-md-2 control-label">Nº Celular (Alternativo)</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtCellPhone2" CssClass="form-control" TextMode="Number" />
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCellPhone2"
                        CssClass="text-danger" ErrorMessage="Nº de celular inválido! Ex. de formato válido: 8212345670"
                        ValidationExpression="^82(\d{7})|83(\d{7})|84(\d{7})|85(\d{7})|86(\d{7})|87(\d{7})$" Display="Dynamic" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label">Email</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" />
                </div>
            </div>
        </fieldset>
        <br />
        <fieldset>
            <legend class="title">Documentos</legend>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="fUpldPicture" CssClass="col-md-2 control-label">Fotografia</asp:Label>
                <div class="col-md-10">
                    <asp:FileUpload runat="server" ID="fUpldPicture" CssClass="form-control" />
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="fUpldPicture"
                        CssClass="text-danger" ErrorMessage="Formato inválido! Formatos permitidos: jpg, jpeg e png"
                        ValidationExpression="(.*\.([jJ][pP][gG]|[jJ][pP][eE][gG]|[pP][nN][gG])$)" Display="Dynamic" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="fUpldIDCopy" CssClass="col-md-2 control-label">Cópia de BI</asp:Label>
                <div class="col-md-10">
                    <asp:FileUpload runat="server" ID="fUpldIDCopy" CssClass="form-control" />
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="fUpldIDCopy"
                        CssClass="text-danger" ErrorMessage="Formato inválido! Formato permitido: pdf."
                        ValidationExpression=".*\.([pP][dD][fFG])$" Display="Dynamic" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="fUpldCriminalRecord" CssClass="col-md-2 control-label">Registo Criminal</asp:Label>
                <div class="col-md-10">
                    <asp:FileUpload runat="server" ID="fUpldCriminalRecord" CssClass="form-control" />
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="fUpldCriminalRecord"
                        CssClass="text-danger" ErrorMessage="Formato inválido! Formato permitido: pdf."
                        ValidationExpression=".*\.([pP][dD][fFG])$" Display="Dynamic" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="fUpldMedicalCertificate" CssClass="col-md-2 control-label">Atestado Médico</asp:Label>
                <div class="col-md-10">
                    <asp:FileUpload runat="server" ID="fUpldMedicalCertificate" CssClass="form-control" />
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="fUpldMedicalCertificate"
                        CssClass="text-danger" ErrorMessage="Formato inválido! Formato permitido: pdf."
                        ValidationExpression=".*\.([pP][dD][fFG])$" Display="Dynamic" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="fUpldMilitarServDeclaration" CssClass="col-md-2 control-label">Decl. de Serviço Militar</asp:Label>
                <div class="col-md-10">
                    <asp:FileUpload runat="server" ID="fUpldMilitarServDeclaration" CssClass="form-control" />
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="fUpldMilitarServDeclaration"
                        CssClass="text-danger" ErrorMessage="Formato inválido! Formato permitido: pdf."
                        ValidationExpression=".*\.([pP][dD][fFG])$" Display="Dynamic" />
                </div>
            </div>
        </fieldset>
    </div>
    <br />
   <div class="modal-footer">
        <asp:Button runat="server" ID="btnBack" Text="<<Voltar" CssClass="btn btn-default" CausesValidation="False" OnClick="btnBack_Click" />
        <asp:Button runat="server" ID="btnUpdate" Text="Gravar" OnClick="btnUpdate_Click" CssClass="btn btn-primary" />
    </div>
</asp:Content>

<%--OnClick="btnUpdater_Click"  OnClick="btnClear_Click" --%>


