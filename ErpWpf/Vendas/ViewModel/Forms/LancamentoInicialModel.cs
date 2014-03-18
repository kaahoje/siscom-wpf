using System;
using System.Windows.Input;
using Ecf;
using Erp.Business;
using Erp.Business.Entity.Contabil.Pessoa.SubClass.PessoaJuridica;
using Erp.Business.Entity.Vendas.MovimentacaoCaixa.SubClass.LancamentoInicial;
using Erp.Business.Enum;
using Util.Wpf;
using Settings = Vendas.Properties.Settings;

namespace Vendas.ViewModel.Forms
{
    public delegate void LancamentoEfetuadoHandler(object sender, EventArgs e);
    public class LancamentoInicialModel : FormModelBase<LancamentoInicial>
    {
        public LancamentoInicialModel()
        {
            Entity = new LancamentoInicial();
        }
        public event LancamentoEfetuadoHandler LancamentoEfetuado;

        protected virtual void OnLancamentoEfetuado()
        {
            LancamentoEfetuadoHandler handler = LancamentoEfetuado;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private ICommand _salvarLancamento;

        public ICommand SalvarLancamento
        {
            get { return _salvarLancamento ?? (_salvarLancamento = new RelayCommandBase(o=>Salvar())); }
            set { _salvarLancamento = value; }
        }

        private void Salvar()
        {
            if (Entity.Valor > 0)
            {
                EcfHelper.Ecf.ImprimeLeituraX(Entity.Valor);
            }
            else
            {
                EcfHelper.Ecf.ImprimeLeituraX();
            }
            var session = NHibernateHttpModule.Session;
            Entity.Caixa = Settings.Default.Caixa;
            Entity.DataMovimento = EcfHelper.Ecf.DataMovimento();
            Entity.Historico = "LANCAMENTO INICIAL";
            Entity.Usuario = App.Usuario;
            Entity.Empresa = session.Get<PessoaJuridica>(Settings.Default.IdEmpresa);
            Entity.Status = Status.Ativo;
            LancamentoInicialRepository.Save(Entity);
            OnLancamentoEfetuado();
        }
    }
}
