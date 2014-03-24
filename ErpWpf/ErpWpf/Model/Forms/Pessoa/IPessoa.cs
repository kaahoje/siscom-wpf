using System.Windows.Input;
using Erp.Business.Entity.Contabil.Pessoa.ClassesRelacionadas;

namespace Erp.Model.Forms.Pessoa
{
    public interface IPessoa
    {
        ICommand CmdAddEndereco { get; set; }
        ICommand CmdRemoveEndereco { get; set; }
        ICommand CmdAddContatoTelefonico { get; set; }
        ICommand CmdRemoveContatoTelefonico { get; set; }
        ICommand CmdAddEnderecoEletronico { get; set; }
        ICommand CmdRemoveEnderecoEletronico { get; set; }
        ICommand CmdBuscarEndereco { get; set; }

        PessoaEndereco CurrentEndereco { get; set; }
        PessoaContatoEletronico CurrentEnderecoEletronico { get; set; }
        PessoaTelefone CurrentContatoTelefonico { get; set; }

        void AddEndereco();
        void RemoveEndereco();
        void AddEnderecoEletronico();
        void RemoveEnderecoEletronico();
        void AddContatoTelefonico();
        void RemoveContatoTelefonico();
        void BuscarEndereco();
    }
}
