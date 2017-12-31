using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenturaITC.DSMSystem.MODEL.Class
{
    /// <summary>
    /// Class for application constants.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170630    Ventura Macute    [+]    Inicial version
    /// _____________
    public class AppConstants
    {

        /// <summary>
        /// General constants.
        /// </summary>
        public struct General
        {
            public const string DROPDOWNLIST_DEFAULT_TEXT = "Seleccionar";
            public const string ERROR_MSG_TOOLTIP = "Contacte o Administrador do sistema e inclua a informação acima na comunicação do erro.";
            public const string ENABLED_TEXT = "Activado";
            public const string DISABLED_TEXT = "Desactivado";
            public const string ALL_TEXT = "Todos";
            public const string SYS_ADMIN_USERNAME = "sysadmin";
        }

        /// <summary>
        /// Connection strings.
        /// </summary>
        public struct ConnectionString
        {
            public const string DSMS_ENTITY = "dsmsEntities";
        }

        /// <summary>
        /// Sucess messages.
        /// </summary>
        public struct SucessMessage
        {
            public const string SUCCESS_OPERATION_EXECUTION = "Operação executada com sucesso!";
        }

        /// <summary>
        /// Information messages.
        /// </summary>
        public struct InfoMessage
        {
            public const string INFO_USER_LOCKEDOUT = "Utilizador bloqueiado por tentativas falhadas de login! Contacte o Administrador do sistema.";
            public const string INFO_USER_DISABLED= "Utilizador desabilitado! Contacte o Administrador do sistema.";
            public const string INFO_LOGIN_FAILURE = "Erro ao efectuar login! Contacte o Administrador do sistema.";
            public const string INFO_CHANGE_PASSWORD_FAILURE = "Erro ao mudar password! Contacte o Administrador do sistema.";
        }

        /// <summary>
        /// Warnig messages.
        /// </summary>
        public struct WarningMessage
        {
            public const string WARN_NOT_SELECTED_DOCUMENT_TYPE = "Por favor, seleccione o documento.";
            public const string WARN_OPERATION_NOT_ALLOWED = "Operação não permitida!";
        }

        /// <summary>
        /// Error messages.
        /// </summary>
        public struct ErrorMessage
        {
            public const string ERROR_INVALID_STUDENT_NAME = "Nome do aluno inválido!";
            public const string ERROR_INVALID_FATHERS_NAME = "Nome do pai inválido!";
            public const string ERROR_INVALID_MOTHERST_NAME = "Nome da mãe inválido!";
            public const string ERROR_DATE_OF_BIRTH_IN_FUTURE = "Data de nascimento futura!";
            public const string ERROR_ALREADY_EXISTS_RECEIPT_NUMBER = "Número do Recibo já existente!";
            public const string ERROR_DOC_EXCEEDS_SIZE_PICTURE = "A fotografia excede o tamanho máximo permitido";
            public const string ERROR_DOC_EXCEEDS_SIZE_IDCOPY = "A cópia de BI excede o tamanho máximo permitido";
            public const string ERROR_DOC_EXCEEDS_SIZE_CRIMINAL_RECORD = "O documento de registo criminal excede o tamanho máximo permitido";
            public const string ERROR_DOC_EXCEEDS_SIZE_MEDICAL_CERTIFICATE = "O atestado médico excede o tamanho máximo permitido";
            public const string ERROR_DOC_EXCEEDS_SIZE_MILITAR_SERV_DECL = "O registo criminal excede o tamanho máximo permitido";
            public const string ERROR_INSTALLMENTS_PERCENT_SUM = "O somatório das percentagens deve ser igual a 100%.";
            public const string ERROR_INSTALLMENTS_NOT_SET = "Deve definir as prestações e taxas.";
            public const string ERROR_INVALID_USERNAME = "Username inválido!";
            public const string ERROR_INCORRECT_PASSWORD = "Password incorrecta!";
            public const string ERROR_INCORRECT_CURRENT_PASSWORD = "Password actual incorrecta!";
            public const string ERROR_INVALID_PASSWORD = "Password inválida! Deverá conter pelo menos uma letra maíuscula, uma minúscula, um dígito e com tamanho entre 8 e 15 caracteres.";
            public const string ERROR_PASSWORD_CONFIRM = "A nova password difere da password de confirmação.";
            public const string ERROR_NEW_PASSWORD_EQUAL_TO_CURRENT = "A nova password não pode ser igua à actual.";
            public const string ERROR_INVALID_USER_FULLNAME = "Nome completo do utilizador inválido!";
            public const string ERROR_REQUIRED_PASSWORD = "O campo password é de preenchimento obrigatório.";
            public const string ERROR_ALREADY_EXISTS_USERNAME = "Já existe um utilizador com o mesmo Username";

        }

        /// <summary>
        /// Exception messages.
        /// </summary>
        public struct ExceptionMessage
        {
            public const string EXCEP_ERROR_GETTING_STUDENT_NUMBER = "Erro ao buscar número do Aluno.";
            public const string EXCEP_ERROR_GETTING_STUDENT_DATA = "Erro ao buscar dados do Aluno.";
            public const string EXCEP_ERROR_GETTING_STUDENT_REGISTRATION = "Erro ao buscar dados de inscrição do Aluno.";
            public const string EXCEP_ERROR_GETTING_STUDENT_PAYMENT_DATA = "Erro ao buscar informação de pagamentos do Aluno.";
            public const string EXCEP_ERROR_GETTING_STUDENT_DOCUMENTATION = "Erro ao buscar documentos do Aluno.";
            public const string EXCEP_ERROR_GETTING_DOCUMENT_TYPES = "Erro ao buscar tipos de documentos.";
            public const string EXCEP_FILE_NOT_FOUND = "Ficheiro não encontrado";
            public const string EXCEP_NOT_FOUND_INSTALLMENTS_INFO = "Informação de parametrização de prestações não encontrada.";
            public const string EXCEP_NOT_FOUND_INSTALLMENT_INFO = "Informação de parametrização da prestação não encontrada.";
            public const string EXCEP_NOT_FOUND_FINES_INFO = "Informação de parametrização de multas não encontrada.";
            public const string EXCEP_ERROR_GETTING_CATEGORIES = "Erro ao buscar Categorias.";
            public const string EXCEP_NOT_FOUND_PARAMETERIZATION_DATA = "Dados de parametrização não encontrados.";
            public const string EXCEP_NOT_FOUND_USER = "Utilizador não encontrado.";
            public const string EXCEP_NOT_FOUND_USERNAME = "Nome do utilizador não encontrado.";
            public const string EXCEP_NOT_FOUND_USER_ROLE = "Papel do utilizador não encontrado.";
            public const string EXCEP_NOT_FOUND_USER_FULL_NAME = "Nome completo do utilizador não encontrado.";
                  }

        /// <summary>
        /// Confirmation messages.
        /// </summary>
        public struct ConfirmMessage
        {
            public const string CONF_DELETE_STUDENT = "Tem certeza que pretende eliminar o aluno seleccionado?";
            public const string CONF_DELETE_USER = "Tem certeza que pretende eliminar o utilizador seleccionado?";
        }

        /// <summary>
        /// Files names.
        /// </summary>
        public struct FileNames
        {
            public const string PDF_STUDENT_FILE = "Ficha do Aluno.pdf";
            public const string PDF_PAYMENTS_STATEMENT = "Extracto de Pagamentos.pdf";
            public const string EXCEL_STUDENT_LIST = "Lista de Alunos.xls";
        }

        /// <summary>
        /// Session variables.
        /// </summary>
        public struct SessionVariables
        {
            public const string USERNAME = "username";
            public const string USER_ROLE = "role";
            public const string USER_FULL_NAME = "user_fullName";
            public const string FILE_PATH = "filePath";
        }

        /// <summary>
        /// Query strings.
        /// </summary>
        public struct QueryString
        {
            public const string STUDENT_NUMBER = "studentNumber";
        }

        /// <summary>
        /// Pages.
        /// </summary>
        public struct Page
        {
            public const string DEFAULT = "~/Default.aspx";
            public const string PDF_VIEWER = "PDFViewer.aspx";
            public const string STUDENT_DATA_UPDATE = "~/Pages/StudentDataUpdate.aspx";
            public const string PARAMETERIZATION = "~/Pages/parameterization.aspx";
            public const string PAYMENTS = "~/Pages/Payments.aspx";
            public const string STUDENT_PAYMENTS = "~/Pages/StudentPayments.aspx";
            public const string STUDENT_PAYMENTS_HISTORY = "~/Pages/StudentPaymentsHistory.aspx";
            public const string STUDENT_REGISTRATION = "~/Pages/student_enrollment.aspx";
            public const string STUDENT_REGISTRATION_MANAGER = "~/Pages/StudentRegistrationManager.aspx";
            public const string INFO = "~/Pages/Info.aspx";
            public const string ERROR = "~/Pages/Error.aspx";
            public const string PASSWORD_CHANGE = "~/Pages/PasswordChange.aspx";
            public const string LOGIN = "~/Pages/Login.aspx";
            public const string USER_REGISTRATION = "~/Pages/UserRegistration.aspx";
            public const string USER_MANAGER= "~/Pages/UserManager.aspx";
            public const string ACCESS_DENIED = "~/Pages/AccessDenied.aspx";
        }

        /// <summary>
        /// Pages.
        /// </summary>
        public struct Reports
        {
            public const string SUB_RPT_PAYMENT_STATEMENT = "SubRptPaymentStatement.rpt";
        }

        /// <summary>
        /// parameterization keys.
        /// </summary>
        public struct ParameterizationKeys
        {
            // public const string ENABLE_FINES = "ENABLE_FINES";
            public const string ENABLE_INSTALLMENTS = "ENABLE_INSTALLMENTS";

            /// <summary>
            /// Maximum document size.
            /// </summary>
            public const string MAX_DOC_SIZE = "MAX_DOC_SIZE";

            /// <summary>
            /// When is set to true enables the sysadmin's password reset.
            /// </summary>
            public const string BYPASS = "BYPASS";
        }
    }
}
