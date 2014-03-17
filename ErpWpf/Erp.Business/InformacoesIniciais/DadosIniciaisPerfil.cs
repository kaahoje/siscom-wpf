//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using Business.Entity.Contabil.Pessoa.SubClass.Usuario.ClassesRelacionadas;
//using Business.Entity.Sistema;
//using Business.Enum;
//using NHibernate;

//namespace Business.InformacoesIniciais
//{
//    public class DadosIniciaisPerfil
//    {
//        // Constantes com os nomes dos formulários.
//        public const string Cliente = "Cliente";
//        public const string Conta = "Conta";
//        public const string CustoFixo = "CustosFixos";
//        public const string Endereco = "Endereco";
//        public const string Fornecedor = "Fornecedor";
//        public const string Lancamento = "Lancamento";
//        public const string TipoLancamento = "TipoLancamento";
//        public const string TipoTitulo = "TipoTitulo";
//        public const string Titulo = "Titulo";
//        public const string TituloAPagar = "TituloAPagar";
//        public const string TituloAReceber = "TituloAReceber";
//        public const string Transferencia = "Transferencia";
//        public const string GrupoProduto = "GrupoProduto";
//        public const string Produto = "Produto";
//        public const string SubGrupoProduto = "SubGrupoProduto";
//        public const string Unidade = "Unidade";
//        public const string NotaFiscalSaida = "NotaFiscalSaida";
//        public const string Usuario = "Usuario";
//        public const string CondicaoPagamento = "CondicaoPagamento";
//        public const string FormaPagamento = "aPagamento";
//        public const string Funcoes = "Funcoes";
//        public const string GeraIdCliente = "GeraIdCliente";
//        public const string Fechamento = "Fechamento";
//        public const string PagamentoCliente = "PagamentoCliente";
//        public const string Sangria = "Sangria";
//        public const string Suprimento = "Suprimento";
//        public const string LancamentoInicial = "LancamentoInicial";
//        public const string MenuFiscal = "MenuFiscal";
//        public const string LeituraMemoriaFiscal = "LeituraMemoriaFiscal";
//        public const string PlanoContaReferencial = "PlanoContaReferencial";
//        public const string Ncm = "Ncm";
//        public const string PagamentoPedido = "PagamentoPedido";
//        public const string CadastrarAliquota = "CadastrarAliquota";
//        public const string CadastrarFormaPagameto = "CadastrarFormaPagameto";
//        public const string NotaFiscalEntrada = "NotaFiscalEntrada";
//        public const string ConfTerminal = "ConfTerminal";
//        public const string Pedido = "Pedido";
//        public const string AtualizacaoProduto = "AtualizacaoProduto";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";


//        // Constantes com os nomes dos relatórios.
//        public const string RelLancamentoPeriodoLancamento = "RelLancamentoPeriodoLancamento";
//        public const string RelPeriodoLancamentoEntradas = "RelPeriodoLancamentoEntradas";
//        public const string RelNotaFiscalSaidaResumidaPeriodoEmissao = "RelNotaFiscalSaidaResumidaPeriodoEmissao";
//        public const string RelPedidoMerceariaDetalhadoPorData = "RelPedidoMerceariaDetalhadoPorData";
//        public const string RelPedidoMerceariaDetalhadoPorPeriodo = "RelPedidoMerceariaDetalhadoPorPeriodo";
//        public const string RelPedidoResumidoPorDia = "RelPedidoResumidoPorDia";
//        public const string RelPedidoResumidoPorPeriodo = "RelPedidoResumidoPorPeriodo";
//        private static readonly InterceptorDadosIniciais Interceptor = new InterceptorDadosIniciais();

//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";
//        //public const string  = "";


//        public static readonly Dictionary<String, Formulario> ListForms = new Dictionary<string, Formulario>();
//        public static readonly Dictionary<String, Relatorio> ListRelatorios = new Dictionary<string, Relatorio>();
//        public static readonly IList<Perfil> ListPerfil = new List<Perfil>();

//        public static void IniciarDados(ISession session)
//        {
//            IniciaForms(session);
//            IniciaRelatorios(session);

//            ListPerfil.Add(PerfilCaixa());
//            ListPerfil.Add(PerfilAnalista());
//            ListPerfil.Add(PerfilAdministrador());

//            foreach (Perfil perfil in ListPerfil)
//            {
//                session.Save(perfil);
//            }
//        }

//        private static Perfil PerfilAdministrador()
//        {
//            var perfil = new Perfil
//            {
//                Nome = "ADMINISTRADOR"
//            };

//            PreencherPerfilInicial(perfil);

//            // Concede permissões para os formulários.
//            AlterarPermissaoForm(AtualizacaoProduto, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(CadastrarAliquota, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(CadastrarFormaPagameto, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(Cliente, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(CondicaoPagamento, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(ConfTerminal, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(Conta, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(CustoFixo, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(Endereco, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(Fechamento, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(FormaPagamento, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(Fornecedor, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(Funcoes, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(GeraIdCliente, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(GrupoProduto, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(Lancamento, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(LancamentoInicial, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(LeituraMemoriaFiscal, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(MenuFiscal, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(NotaFiscalSaida, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(NotaFiscalEntrada, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(Ncm, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(PagamentoCliente, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(PagamentoPedido, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(Pedido, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(PlanoContaReferencial, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(Produto, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(Sangria, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(SubGrupoProduto, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(Suprimento, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(TipoLancamento, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(Titulo, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(TituloAPagar, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(TituloAReceber, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(TipoTitulo, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(Transferencia, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(Unidade, perfil, true, true, true, true, true);
//            AlterarPermissaoForm(Usuario, perfil, true, true, true, true, true);

//            // Concede permissões para os relatórios.
//            AlterarPermissaoRelatorio(RelLancamentoPeriodoLancamento, perfil, true);
//            AlterarPermissaoRelatorio(RelNotaFiscalSaidaResumidaPeriodoEmissao, perfil, true);
//            AlterarPermissaoRelatorio(RelPedidoMerceariaDetalhadoPorData, perfil, true);
//            AlterarPermissaoRelatorio(RelPedidoMerceariaDetalhadoPorPeriodo, perfil, true);
//            AlterarPermissaoRelatorio(RelPedidoResumidoPorDia, perfil, true);
//            AlterarPermissaoRelatorio(RelPedidoResumidoPorPeriodo, perfil, true);
//            AlterarPermissaoRelatorio(RelPeriodoLancamentoEntradas, perfil, true);

//            return perfil;
//        }

//        private static Perfil PerfilAnalista()
//        {
//            var perfil = new Perfil
//            {
//                Nome = "ANALISTA"
//            };

//            PreencherPerfilInicial(perfil);

//            // Concede as permissões de analista.
//            AlterarPermissaoRelatorio(RelLancamentoPeriodoLancamento, perfil, true);
//            AlterarPermissaoRelatorio(RelNotaFiscalSaidaResumidaPeriodoEmissao, perfil, true);
//            AlterarPermissaoRelatorio(RelPedidoMerceariaDetalhadoPorData, perfil, true);
//            AlterarPermissaoRelatorio(RelPedidoMerceariaDetalhadoPorPeriodo, perfil, true);
//            AlterarPermissaoRelatorio(RelPedidoResumidoPorDia, perfil, true);
//            AlterarPermissaoRelatorio(RelPedidoResumidoPorPeriodo, perfil, true);
//            AlterarPermissaoRelatorio(RelPeriodoLancamentoEntradas, perfil, true);

//            return perfil;
//        }

//        private static Perfil PerfilCaixa()
//        {
//            var perfil = new Perfil
//            {
//                Nome = "CAIXA"
//            };

//            PreencherPerfilInicial(perfil);


//            // Libera os formulários.
//            AlterarPermissaoForm(Sangria, perfil, true, true, true, false, false);
//            AlterarPermissaoForm(Suprimento, perfil, true, true, true, false, false);
//            AlterarPermissaoForm(PagamentoCliente, perfil, true, true, true, false, false);
//            AlterarPermissaoForm(PagamentoPedido, perfil, true, true, true, false, false);
//            AlterarPermissaoForm(LancamentoInicial, perfil, true, true, true, false, false);

//            return perfil;
//        }

//        private static void PreencherPerfilInicial(Perfil perfil)
//        {
//            foreach (var formulario in ListForms)
//            {
//                perfil.PermissoesFormulario.Add(new PermissaoForm
//                {
//                    Formulario = formulario.Value,
//                    PermissaoAcesso = false,
//                    PermissaoDelete = false,
//                    PermissaoInsert = false,
//                    PermissaoSelect = false,
//                    PermissaoUpdate = false
//                });
//            }
//            foreach (var relatorio in ListRelatorios)
//            {
//                perfil.PermissoesRelatorio.Add(new PermissaoRelatorio
//                {
//                    Habilitado = false,
//                    Relatorio = relatorio.Value
//                });
//            }
//        }

//        private static void AlterarPermissaoForm(string form, Perfil perfil, bool ativo, bool select, bool insert,
//            bool update,
//            bool delete)
//        {
//            PermissaoForm permissao = BuscaPermissaoForm(form, perfil.PermissoesFormulario);

//            if (permissao != null)
//            {
//                permissao.PermissaoAcesso = ativo;
//                permissao.PermissaoDelete = delete;
//                permissao.PermissaoInsert = insert;
//                permissao.PermissaoSelect = select;
//                permissao.PermissaoUpdate = update;
//            }
//            else
//            {
//                throw new Exception("Formulário " + form + " não registrado.");
//                Interceptor.Escrever("Formulario não registrado: " + form);
//            }
//        }

//        private static void AlterarPermissaoRelatorio(string rel, Perfil perfil, bool habilitado)
//        {
//            PermissaoRelatorio permissao = BuscaPermissaoRelatorio(rel, perfil.PermissoesRelatorio);
//            if (permissao != null)
//            {
//                permissao.Habilitado = habilitado;
//            }
//            else
//            {
//                throw new Exception("Relatório" + rel + " não registrado.");
//                Interceptor.Escrever("Relatório não registrado: " + rel);
//            }
//        }

//        private static PermissaoForm BuscaPermissaoForm(string frm, IList<PermissaoForm> list)
//        {
//            foreach (PermissaoForm permissaoForm in list)
//            {
//                if (permissaoForm.Formulario.Nome.Equals(frm))
//                {
//                    return permissaoForm;
//                }
//            }
//            return null;
//        }

//        private static PermissaoRelatorio BuscaPermissaoRelatorio(string rel, IList<PermissaoRelatorio> list)
//        {
//            foreach (PermissaoRelatorio permissaoRelatorio in list)
//            {
//                if (permissaoRelatorio.Relatorio.Nome.Equals(rel))
//                {
//                    return permissaoRelatorio;
//                }
//            }
//            return null;
//        }

//        private static void IniciaRelatorios(ISession session)
//        {
//            MontaListRels();
//            foreach (var relatorio in ListRelatorios)
//            {
//                session.Save(relatorio.Value);
//            }
//        }

//        public static void MontaListRels()
//        {
//            ListRelatorios.Add(RelLancamentoPeriodoLancamento,
//                new Relatorio { Nivel = NivelRelatorio.Operacional, Nome = RelLancamentoPeriodoLancamento });
//            ListRelatorios.Add(RelNotaFiscalSaidaResumidaPeriodoEmissao,
//                new Relatorio { Nivel = NivelRelatorio.Operacional, Nome = RelNotaFiscalSaidaResumidaPeriodoEmissao });
//            ListRelatorios.Add(RelPeriodoLancamentoEntradas,
//                new Relatorio { Nivel = NivelRelatorio.Operacional, Nome = RelPeriodoLancamentoEntradas });
//            ListRelatorios.Add(RelPedidoMerceariaDetalhadoPorData,
//                new Relatorio { Nivel = NivelRelatorio.Operacional, Nome = RelPedidoMerceariaDetalhadoPorData });
//            ListRelatorios.Add(RelPedidoMerceariaDetalhadoPorPeriodo,
//                new Relatorio { Nivel = NivelRelatorio.Operacional, Nome = RelPedidoMerceariaDetalhadoPorPeriodo });
//            ListRelatorios.Add(RelPedidoResumidoPorDia,
//                new Relatorio { Nivel = NivelRelatorio.Operacional, Nome = RelPedidoResumidoPorDia });
//            ListRelatorios.Add(RelPedidoResumidoPorPeriodo,
//                new Relatorio { Nivel = NivelRelatorio.Operacional, Nome = RelPedidoResumidoPorPeriodo });

//        }

//        private static void IniciaForms(ISession session)
//        {
//            MontaListForms();
//            foreach (var formulario in ListForms)
//            {
//                session.Save(formulario.Value);
//            }
//        }

//        public static void MontaListForms()
//        {
//            ListForms.Add(AtualizacaoProduto,
//                new Formulario { Nome = CadastrarAliquota, Descricao = "Atualização de produtos", Ativa = false });
//            ListForms.Add(CadastrarAliquota,
//                new Formulario { Nome = CadastrarAliquota, Descricao = "Alíquotas ECF", Ativa = false });
//            ListForms.Add(CadastrarFormaPagameto,
//                new Formulario { Nome = CadastrarFormaPagameto, Descricao = "Formas de pagamento ECF", Ativa = false });
//            ListForms.Add(Cliente, new Formulario { Nome = Cliente, Descricao = "Clientes", Ativa = true });
//            ListForms.Add(CondicaoPagamento,
//                new Formulario { Nome = CondicaoPagamento, Descricao = "Condições de pagamento." });
//            ListForms.Add(ConfTerminal,
//                new Formulario { Nome = ConfTerminal, Descricao = "Configuração de terminal", Ativa = false });
//            ListForms.Add(Conta, new Formulario { Nome = Conta, Descricao = "Contas", Ativa = false });
//            ListForms.Add(CustoFixo, new Formulario { Nome = CustoFixo, Descricao = "Custos fixos", Ativa = false });
//            ListForms.Add(Endereco, new Formulario { Nome = Endereco, Descricao = "Endereços", Ativa = false });
//            ListForms.Add(Fechamento,
//                new Formulario { Nome = Fechamento, Descricao = "Fechamento de pedido", Ativa = false });
//            ListForms.Add(FormaPagamento,
//                new Formulario { Nome = FormaPagamento, Descricao = "Formas de pagamento", Ativa = true });
//            ListForms.Add(Fornecedor, new Formulario { Nome = Fornecedor, Descricao = "Fornecedores", Ativa = false });
//            ListForms.Add(Funcoes, new Formulario { Nome = Funcoes, Descricao = "Funções", Ativa = false });
//            ListForms.Add(GeraIdCliente, new Formulario { Nome = GeraIdCliente, Ativa = false });
//            ListForms.Add(GrupoProduto, new Formulario { Nome = GrupoProduto, Descricao = "Grupos", Ativa = false });
//            ListForms.Add(Lancamento, new Formulario { Nome = Lancamento, Descricao = "Lançamentos", Ativa = false });
//            ListForms.Add(LancamentoInicial,
//                new Formulario { Nome = LancamentoInicial, Descricao = "Lançamento inicial", Ativa = false });
//            ListForms.Add(LeituraMemoriaFiscal,
//                new Formulario { Nome = LeituraMemoriaFiscal, Descricao = "LMF", Ativa = false });
//            ListForms.Add(MenuFiscal, new Formulario { Nome = MenuFiscal, Descricao = "Menu fiscal", Ativa = false });
//            ListForms.Add(Ncm, new Formulario { Nome = Ncm, Descricao = "NCM", Ativa = false });
//            ListForms.Add(NotaFiscalSaida,
//                new Formulario { Nome = NotaFiscalSaida, Descricao = "Notas de saída", Ativa = false });
//            ListForms.Add(NotaFiscalEntrada,
//                new Formulario { Nome = NotaFiscalEntrada, Descricao = "Notas de entrada", Ativa = false });
//            ListForms.Add(PagamentoCliente,
//                new Formulario { Nome = PagamentoCliente, Descricao = "Pagamento de cliente", Ativa = false });
//            ListForms.Add(PagamentoPedido,
//                new Formulario { Nome = PagamentoPedido, Descricao = "Pagamento de pedido", Ativa = false });
//            ListForms.Add(Pedido, new Formulario { Nome = Pedido, Descricao = "Pedidos", Ativa = false });
//            ListForms.Add(PlanoContaReferencial,
//                new Formulario { Nome = PlanoContaReferencial, Descricao = "Plano de contas", Ativa = false });
//            ListForms.Add(Produto, new Formulario { Nome = Produto, Descricao = "Produto", Ativa = true });
//            ListForms.Add(Sangria, new Formulario { Nome = Sangria, Descricao = "Sangrias", Ativa = false });
//            ListForms.Add(SubGrupoProduto, new Formulario { Nome = SubGrupoProduto, Descricao = "Subgrupo", Ativa = true });
//            ListForms.Add(Suprimento, new Formulario { Nome = Suprimento, Descricao = "Suprimento", Ativa = false });
//            ListForms.Add(TipoLancamento,
//                new Formulario { Nome = TipoLancamento, Descricao = "Tipos de lançamento", Ativa = false });
//            ListForms.Add(TipoTitulo, new Formulario { Nome = TipoTitulo, Descricao = "Tipos de título", Ativa = true });
//            ListForms.Add(Titulo, new Formulario { Nome = Titulo, Descricao = "Títulos", Ativa = true });
//            ListForms.Add(TituloAPagar,
//                new Formulario { Nome = TituloAPagar, Descricao = "Títulos à pagar", Ativa = false });
//            ListForms.Add(TituloAReceber,
//                new Formulario { Nome = TituloAReceber, Descricao = "Títulos à receber", Ativa = true });
//            ListForms.Add(Transferencia,
//                new Formulario { Nome = Transferencia, Descricao = "Transferências", Ativa = false });
//            ListForms.Add(Unidade, new Formulario { Nome = Unidade, Descricao = "Unidades", Ativa = true });
//            ListForms.Add(Usuario, new Formulario { Nome = Usuario, Descricao = "Usuários", Ativa = true });
//        }

//        private class InterceptorDadosIniciais
//        {
//            public void Escrever(string mensagem)
//            {
//                Trace.WriteLine(mensagem);
//            }
//        }
//    }
//}