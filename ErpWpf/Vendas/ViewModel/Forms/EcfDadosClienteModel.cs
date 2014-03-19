using System;
using Ecf;
using Erp.Business;
using Erp.Business.Dicionary;
using Erp.Business.Entity.Contabil.Pessoa;

namespace Vendas.ViewModel.Forms
{
    public class EcfDadosClienteModel : FormModelBase
    {
        public EcfDadosClienteModel()
        {
            ClienteCupom = new ClienteCupom();
        }
        private String _tipoPessoa;
        private Pessoa _cliente;
        
        private string _maskCpfCnpj;
        private string _labelCpfCnpj;
        private ClienteCupom _clienteCupom;

        public TipoPessoaDictionary TipoPessoaDictionary { get { return new TipoPessoaDictionary(); } }
        public string LabelCpfCnpj
        {
            get
            {
                if (string.IsNullOrEmpty(_labelCpfCnpj))
                {
                    _labelCpfCnpj = "Cpf:";
                }
                return _labelCpfCnpj;
            }
            set
            {
                _labelCpfCnpj = value; 
                OnPropertyChanged("LabelCpfCnpj");
            }
        }

        public string MaskCpfCnpj
        {
            get { return _maskCpfCnpj ??(_maskCpfCnpj = Constants.MaskCpf); }
            set
            {
                _maskCpfCnpj = value; 
                OnPropertyChanged("MaskCpfCnpj");
            }
        }

        public Pessoa Cliente
        {
            get { return _cliente; }
            set
            {
                _cliente = value; 
                OnPropertyChanged("Cliente");
            }
        }

        public String TipoPessoa
        {
            get { return _tipoPessoa; }
            set
            {
                _tipoPessoa = value;
                if (value == "FISICA")
                {
                    LabelCpfCnpj = "CPF:";
                    MaskCpfCnpj = Constants.MaskCpf;
                }
                else
                {
                    LabelCpfCnpj = "CNPJ:";
                    MaskCpfCnpj = Constants.MaskCnpj;
                }
                OnPropertyChanged("TipoPessoa");
            }
        }

        public ClienteCupom ClienteCupom
        {
            get { return _clienteCupom; }
            set
            {
                _clienteCupom = value;
                OnPropertyChanged("ClienteCupom");
            }
        }
    }
}
