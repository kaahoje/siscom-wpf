namespace Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaFisica.SubClass.ParceiroNegocio.ClassesRelacionadas
{
    public class CustoFixoParceiroNegocioPessoaFisica : CustoFixo
    {
        private ParceiroNegocioPessoaFisica _parceiroNegocioPessoaFisica;

        public ParceiroNegocioPessoaFisica ParceiroNegocioPessoaFisica
        {
            get { return _parceiroNegocioPessoaFisica; }
            set
            {
                if (Equals(value, _parceiroNegocioPessoaFisica)) return;
                _parceiroNegocioPessoaFisica = value;
                OnPropertyChanged();
            }
        }
    }
}
