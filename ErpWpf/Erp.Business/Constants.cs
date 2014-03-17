namespace Erp.Business
{
    public class Constants
    {
        public const string MaskCpf = "###,###,###-##";
        public const string MaskCnpj = "##,###,###/####-##";
        public const string MaskDate = "dd/MM/yyyy";
        public const string MaskHour = "HH:mm";
        public const string MaskMoney = "C";
        public const string MaskPercent = "P";
        
        
        public const int MinLengthNames = 4;
        public const int MaxLengthNames = 50;
        public const int MinLengthFone = 8;
        public const int MaxLengthFone = 20;
        public const int MinLengthPassword = 4;
        public const int MaxLengthPassword = 20;
        public const int MinLengthDescriptions = 8;
        public const int MaxLengthDescriptions = 20;
        public const int MaxParcelas = 10;
        public const int MinParcelas = 1;
        public const int MaxDia = 310;
        public const int MinDia = 0;
        public const double MinValorMonetario = 0F;
        public const double MaxValorMonetario = 99999999.99F;
        public const double MinQuantidade = 0F;
        public const double MaxQuantidade = 99999999.99F;
        public const double MaxPercentual = 99.00F;
        public const double MinPercentual = 0.00F;
        

        public const string NullTextGeneroFeminino = "Informe a '{0}'";
        public const string NullTextGeneroMasculino = "Informe o '{0}'";
        public const string MessageRequiredError = "O campo '{0}' é obrigatório";
        public const string MessageRangeError = "O valor campo '{0}' deve estar entre {1} e {2}";
        public const string MessageRangeValorError = "O valor campo '{0}' deve ser de no mínimo {1} e no máximo {2}";
        public const string MessageLengthNameError = "O campo '{0}' deve ter entre {2} e {1} caracteres";
        public const string MessageLengthFoneError = "O campo '{0}' deve ter entre {2} e {1} caracteres";
        public const string MessageLengthPasswordError = "A senha deve ter '{0}' deve ter entre {2} e {1} caracteres";
        public const string MessageLengthDescriptionError = "O campo '{0}' deve ter entre {2} e {1} caracteres";
        
        
        //Mensagens
        public const string MessageModelNotIsValid = "Alguns Campos não foram preenchidos corretamente";
    }
}