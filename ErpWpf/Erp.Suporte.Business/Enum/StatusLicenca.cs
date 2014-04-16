namespace Erp.Suporte.Business.Enum
{
    public enum StatusLicenca
    {
        Ativa,
        Bloqueada,
        Revogada,
        Vencida,
        // Este status deve ser usado para o caso de o cliente perder a instalação do aplicativo e solicitar a
        // reativação do sistema.
        ReenviarCodigo
    }
}
