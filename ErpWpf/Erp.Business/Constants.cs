namespace Erp.Business
{
    public class Constants
    {
        public const string MaskCpf = "###,###,###-##";
        public const string MaskCnpj = "##,###,###/####-##";
        public const string MaskDate = "dd/MM/yyyy";
        public const string MaskHour = "HH:mm";
        public const string MaskMoney = "{0:C}";
        public const string MaskPercent = "P";

        public string MaskCpfProperty { get { return MaskCpf; } }
        public string MaskCnpjProperty { get { return MaskCnpj; } }
        public string MaskDateProperty { get { return MaskDate; } }
        public string MaskHourProperty { get { return MaskHour; } }
        public string MaskMoneyProperty { get { return MaskMoney; } }
        public string MaskPercentProperty { get { return MaskPercent; } }

        
        public const int MinLengthNames = 4;
        public const int MaxLengthNames = 60;
        public const int MinLengthFone = 8;
        public const int MaxLengthFone = 20;
        public const int MinLengthPassword = 4;
        public const int MaxLengthPassword = 20;
        public const int MinLengthDescriptions = 8;
        public const int MaxLengthDescriptions = 50;
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

        public int MinLengthNamesProperty { get { return MinLengthNames; } }
        public int MaxLengthNamesProperty { get { return MaxLengthNames; } }
        public int MinLengthFoneProperty { get { return MinLengthFone; } }
        public int MaxLengthFoneProperty { get { return MaxLengthFone; } }
        public int MinLengthPasswordProperty { get { return MinLengthPassword; } }
        public int MaxLengthPasswordProperty { get { return MaxLengthPassword; } }
        public int MinLengthDescriptionsProperty { get { return MinLengthDescriptions; } }
        public int MaxLengthDescriptionsProperty { get { return MaxLengthDescriptions; } }
        public int MaxParcelasProperty { get { return MaxParcelas; } }
        public int MinParcelasProperty { get { return MinParcelas; } }
        public int MaxDiaProperty { get { return MaxDia; } }
        public int MinDiaProperty { get { return MinDia; } }
        public double MinValorMonetarioProperty { get { return MinValorMonetario; } }
        public double MaxValorMonetarioProperty { get { return MaxValorMonetario; } }
        public double MinQuantidadeProperty { get { return MinQuantidade; } }
        public double MaxQuantidadeProperty { get { return MaxQuantidade; } }
        public double MaxPercentualProperty { get { return MaxPercentual; } }
        public double MinPercentualProperty { get { return MinPercentual; } }
        

        public const string NullTextGeneroFeminino = "Informe a '{0}'";
        public const string NullTextGeneroMasculino = "Informe o '{0}'";
        public const string MessageRequiredError = "O campo '{0}' é obrigatório";
        public const string MessageRangeError = "O valor campo '{0}' deve estar entre {1} e {2}";
        public const string MessageRangeValorError = "O valor campo '{0}' deve ser de no mínimo {1} e no máximo {2}";
        public const string MessageLengthNameError = "O campo '{0}' deve ter entre {2} e {1} caracteres";
        public const string MessageLengthFoneError = "O campo '{0}' deve ter entre {2} e {1} caracteres";
        public const string MessageLengthPasswordError = "A senha deve ter '{1}' e '{2}' caracteres";
        public const string MessageLengthDescriptionError = "O campo '{0}' deve ter entre '{2}' e '{1}' caracteres";
        public const string MessageModelNotIsValid = "Alguns Campos não foram preenchidos corretamente";

        public string NullTextGeneroFemininoProperty { get { return NullTextGeneroFeminino; } }
        public string NullTextGeneroMasculinoProperty { get { return NullTextGeneroMasculino; } }
        public string MessageRequiredErrorProperty {get { return MessageRequiredError; }}
        public string MessageRangeErrorProperty { get { return MessageRangeError; } }
        public string MessageRangeValorErrorProperty { get { return MessageRangeValorError; } }
        public string MessageLengthNameErrorProperty { get { return MessageLengthNameError; } }
        public string MessageLengthFoneErrorProperty { get { return MessageLengthFoneError; } }
        public string MessageLengthPasswordErrorProperty { get { return MessageLengthPasswordError; } }
        public string MessageLengthDescriptionErrorProperty { get { return MessageLengthDescriptionError; } }
        //Mensagens
        
        public string MessageModelNotIsValidProperty{get { return MessageModelNotIsValid; }}
        
    }
}