using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using Erp.Business.Entity.Vendas.Pedido.ClassesRelacionadas;
using Erp.Business.Entity.Vendas.Pedido.Restaurante;
using Erp.Business.Entity.Vendas.Pedido.Restaurante.ClassesRelacionadas;
using Erp.Business.Enum;
using RestauranteService.DataContracts;
using Util.Seguranca;

namespace RestauranteService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class RestauranteService : IRestauranteService
    {
        public RestauranteService()
        {
            Parciais = new List<ParcialMesaDataContract>();
            FilaEntrega = new List<PedidoRestaurante>();
            FilaSalao = new List<PedidoRestaurante>();
            MesasAbertas = new List<PedidoRestaurante>();
            RestaurarPedidos();
        }

        private void RestaurarPedidos()
        {
            
        }

        private void BackupPedidos()
        {
            
        }
        private int NumeroControle { get; set; }
        private IList<ParcialMesaDataContract> Parciais { get; set; }
        private string LastException { get; set; }
        private IList<PedidoRestaurante> FilaEntrega { get; set; }
        private IList<PedidoRestaurante> FilaSalao { get; set; }
        private IList<PedidoRestaurante> MesasAbertas { get; set; }
        public StatusComando TrocarMesa(int origem, int destino)
        {
            try
            {
                var mOrigem = GetMesa(origem);
                var mDestino = GetMesa(destino);
                if (mOrigem == null)
                {
                    throw new Exception("Mesa de origem não encontrada.");
                }
                if (mDestino != null)
                {
                    LastException = "A mesa de destino já está aberta.";
                    return StatusComando.MesaAberta;
                }
                mOrigem.Mesa = destino;
                return StatusComando.ConcluidoSucesso;
            }
            catch (Exception ex)
            {
                LastException = ex.Message;
            }
            return StatusComando.ErroExecucao;
        }

        public StatusComando JuntarMesa(int origem, int destino)
        {
            try
            {
                var mOrigem = GetMesa(origem);
                var mDestino = GetMesa(destino);
                if (mOrigem == null)
                {
                    throw new Exception("Mesa de origem não encontrada.");
                }
                if (mDestino == null)
                {
                    mOrigem.Mesa = destino;
                }
                else
                {
                    foreach (var prod in mOrigem.Produtos)
                    {
                        mDestino.Produtos.Add(prod);
                    }
                }
                return StatusComando.ConcluidoSucesso;
            }
            catch (Exception ex)
            {
                LastException = ex.Message;
            }
            return StatusComando.ErroExecucao;
        }

        public PedidoRestaurante GetMesa(int mesa)
        {
            return MesasAbertas.SingleOrDefault(x => x.Mesa == mesa);
        }

        public PedidoRestaurante GetEntrega(int controle)
        {
            return FilaEntrega.SingleOrDefault(x => x.Controle.Controle == controle);
        }

        public PedidoRestaurante NovaMesa(int mesa)
        {
            return new PedidoRestaurante()
            {
                Local = LocalPedidoRestaurante.Mesa,
                HoraEntrada = DateTime.Now.TimeOfDay,
                Mesa = mesa
            };
        }

        public PedidoRestaurante NovoBalcao()
        {
            return new PedidoRestaurante()
            {
                Controle = NovoControle(),
                HoraEntrada = DateTime.Now.TimeOfDay,
                Local = LocalPedidoRestaurante.Balcao
            };
        }

        public PedidoRestaurante NovaEntrega()
        {
            return new PedidoRestaurante()
            {
                Controle = NovoControle(),
                HoraEntrada = DateTime.Now.TimeOfDay,
                Local = LocalPedidoRestaurante.Entrega
            };
        }

        public ParcialMesaDataContract ParcialMesa(int mesa, int idGarcon)
        {
            var parcial = new ParcialMesaDataContract()
            {
                Mesa = mesa,
                IdGarcon = idGarcon
            };
            Parciais.Add(parcial);
            return parcial;
        }

        public IList<ParcialMesaDataContract> ParciaisSolicitadas(int idGarcon)
        {
            return Parciais.Where(x => x.IdGarcon == idGarcon).ToList();
        }

        public ParcialMesaDataContract ParcialPendente()
        {
            return Parciais.FirstOrDefault(parcial => parcial.Impressa == false);
        }

        public StatusComando ConfirmarImpressaoParcial(Guid idGuid, int caixa)
        {
            try
            {
                foreach (var parcial in Parciais.Where(parcial => parcial.IdGuid.Equals(idGuid)))
                {
                    parcial.HoraImpressao = DateTime.Now.TimeOfDay;
                    parcial.CaixaEmissor = caixa;
                    parcial.Impressa = true;
                }
            }
            catch (Exception ex)
            {
                LastException = ex.Message;
            }
            return StatusComando.ErroExecucao;
        }

        public PedidoRestaurante ParcialMesa(int mesa)
        {
            return GetMesa(mesa);
        }

        public StatusComando ConfirmarPedido(PedidoRestaurante pedido)
        {
            try
            {
                switch (pedido.Local)
                {
                    case LocalPedidoRestaurante.Mesa:
                        var mesaAberta = GetMesa(pedido.Mesa);
                        if (mesaAberta != null)
                        {
                            // Valida todas as composições que estão entrando para verificar a integridade.
                            foreach (var produto in pedido.Produtos)
                            {
                                ComposicaoProdutoRepository.Validate(produto);
                            }
                            foreach (var prod in pedido.Produtos)
                            {

                                mesaAberta.Produtos.Add(prod);
                            }
                        }
                        else
                        {
                            MesasAbertas.Add(pedido);
                        }
                        break;
                    default:
                        switch (pedido.Local)
                        {
                            case LocalPedidoRestaurante.Balcao:
                                FilaSalao.Add(pedido);
                                break;
                            case LocalPedidoRestaurante.Entrega:
                                FilaEntrega.Add(pedido);
                                break;
                        }
                        break;
                }
                pedido.Confirmado = true;
                return StatusComando.ConcluidoSucesso;
            }
            catch (Exception ex)
            {
                LastException = ex.Message;
            }
            
            return StatusComando.ConcluidoSucesso;
        }

        public StatusComando FecharMesa(int mesa)
        {
            try
            {
                var m = GetMesa(mesa);
                if (m == null)
                {
                    throw new Exception("Mesa não encontrada.");
                }
                PedidoRestauranteRepository.Save(m);
                RemoveMesa(m);
                return StatusComando.ConcluidoSucesso;
            }
            catch (Exception exception)
            {
                LastException = exception.Message;
            }
            return StatusComando.ErroExecucao;
        }

        public StatusComando FecharEntrega(int controle)
        {
            try
            {
                var ent = GetEntrega(controle);
                if (ent == null)
                {
                    throw new Exception("Entrega/Balcão não encontrado.");
                }
                PedidoRestauranteRepository.Save(ent);
                RemoveEntrega(ent);
                return StatusComando.ConcluidoSucesso;
            }
            catch (Exception ex)
            {
                LastException = ex.Message;
            }
            return StatusComando.ErroExecucao;
        }

        public StatusComando CancelarMesa(int mesa)
        {
            try
            {
                var pedidosProduzidos = FilaSalao.Where(x => x.Mesa == mesa && x.StatusProducao == StatusProducaoPedido.Produzido);
                if (pedidosProduzidos.Count() != 0)
                {
                    LastException = "Há pedidos produzidos para esta mesa. Só é possível o cancelamento com a senha do gerênte";
                    return StatusComando.SolicitacaoAdministrador;
                }
                var m = GetMesa(mesa);
                if (m != null)
                {
                    RemoveMesa(m);
                    LimpaFilaMesa(mesa);
                }
                return StatusComando.ConcluidoSucesso;
            }
            catch (Exception ex)
            {
                LastException = ex.Message;
            }
            return StatusComando.ErroExecucao;
        }

        private void RemoveMesa(PedidoRestaurante mesa)
        {
            MesasAbertas.Remove(mesa);
        }

        private void LimpaFilaMesa(int mesa)
        {
            var listRem = FilaSalao.Where(x => x.Mesa == mesa);
            foreach (var m in listRem)
            {
                FilaSalao.Remove(m);
            }
        }
        public StatusComando CancelarEntrega(int controle)
        {
            try
            {
                var entrega = GetEntrega(controle);
                if (entrega.StatusProducao == StatusProducaoPedido.Produzido)
                {
                    LastException = "Pedido já produzido. Somente o gerênte pode excluir o pedido.";
                    return StatusComando.SolicitacaoAdministrador;
                }
                RemoveEntrega(entrega);
                return StatusComando.ConcluidoSucesso;
            }
            catch (Exception ex)
            {
                LastException = ex.Message;
            }
            return StatusComando.ErroExecucao;
        }

        private void RemoveEntrega(PedidoRestaurante entrega)
        {
            FilaEntrega.Remove(entrega);
        }

        public StatusComando CancelarItemMesa(int mesa, ComposicaoProduto composicao)
        {
            try
            {
                ComposicaoProduto comp = null;

                // Cancela o item na fila.
                PedidoRestaurante mesaFilaRem = null;
                foreach (var mesaFila in FilaSalao.Where(x => x.Mesa == mesa))
                {
                    comp = null;
                    foreach (var prod in mesaFila.Produtos.Where(prod => prod.IdGuid == composicao.IdGuid))
                    {
                        // Verifica se o pedido já foi produzido.
                        if (mesaFila.StatusProducao == StatusProducaoPedido.Produzido)
                        {
                            LastException = "O ítem já foi produzido. Somente o gerênte pode cancelar o item.";
                            return StatusComando.SolicitacaoAdministrador;
                        }
                        comp = prod;
                    }
                    if (comp != null)
                    {
                        mesaFila.Produtos.Remove(comp);
                        // Se o pedido na fila não tiver mais produtos remove da fila.
                        if (mesaFila.Produtos.Count == 0)
                        {
                            mesaFilaRem = mesaFila;
                        }
                    }
                }
                // Remove o pedido por completo da fila caso tenha sido marcado para exclusão.
                if (mesaFilaRem != null)
                {
                    RemoveMesaFila(mesaFilaRem);
                }

                var m = GetMesa(mesa);
                if (m == null)
                {
                    throw new Exception(string.Format("A mesa {0} não foi encontrada.", mesa));
                }
                // Cancela o item na mesa.
                foreach (var prod in m.Produtos.Where(prod => prod.IdGuid == composicao.IdGuid))
                {
                    comp = prod;
                }
                if (comp != null)
                {
                    m.Produtos.Remove(comp);
                }
                // Se não houver mais produtos na mesa cancela-o.
                if (m.Produtos.Count == 0)
                {
                    CancelarMesa(mesa);
                }
                return StatusComando.ConcluidoSucesso;
            }
            catch (Exception ex)
            {
                LastException = ex.Message;
            }
            return StatusComando.ErroExecucao;
        }

        public StatusComando CancelarItemComposicaoMesa(int mesa, Guid composicao, Guid produto)
        {
            try
            {
                var mesaAberta = GetMesa(mesa);
                if (mesaAberta == null)
                {
                    throw new Exception("A mesa não está aberta");
                }
                foreach (var m in FilaSalao.Where(x=>x.Mesa == mesa))
                {
                    var comp = m.Produtos.SingleOrDefault(x => x.IdGuid == composicao);
                    
                    if (comp == null )continue;

                    if (m.StatusProducao == StatusProducaoPedido.Produzido)
                    {
                        throw new Exception("Pedido já produzido.");
                    }
                    var prod = comp.Composicao.SingleOrDefault(x=>x.IdGuid == produto);
                    if (prod != null)
                    {
                        comp.Composicao.Remove(prod);
                    }
                }
                var compMesa = mesaAberta.Produtos.SingleOrDefault(x => x.IdGuid == composicao);
                if (compMesa != null)
                {
                    var prodMesa = compMesa.Composicao.SingleOrDefault(x => x.IdGuid == produto);
                    if (prodMesa !=null)
                    {
                        compMesa.Composicao.Remove(prodMesa);
                    }
                }
                return StatusComando.ConcluidoSucesso;
            }
            catch (Exception ex)
            {
                LastException = ex.Message;
            }
            return StatusComando.ErroExecucao;
        }

        private void RemoveMesaFila(PedidoRestaurante mesaFilaRem)
        {
            FilaSalao.Remove(mesaFilaRem);
        }

        public StatusComando AdicionarItemMesa(int mesa, ComposicaoProduto composicao)
        {
            try
            {
                if (ComposicaoProdutoRepository.Validate(composicao))
                {
                    var m = GetMesa(mesa);
                    if (m == null)
                    {
                        throw new Exception(string.Format("A mesa {0} não foi encontrada.", mesa));
                    }
                    m.Produtos.Add(composicao);
                    return StatusComando.ConcluidoSucesso;
                }
            }
            catch (Exception ex)
            {
                LastException = ex.Message;
            }
            return StatusComando.ErroExecucao;
        }
        
        public Dictionary<int, decimal> VerificaProdutoCobranca(IList<ProdutoPedido> produtos)
        {
            var cobrarMaiorValor = ConfigurationManager.AppSettings["CobrarMaiorValor"];
            var ret = new Dictionary<int, decimal>();
            if (cobrarMaiorValor.Equals("true"))
            {
                decimal preco = 0;
                var index = 0;
                for (var i = 0; i < produtos.Count; i++)
                {
                    var prod = produtos[i];
                    if (preco >= prod.Produto.PrecoVenda) continue;
                    preco = prod.Produto.PrecoVenda;
                    index = i;
                }
                ret.Add(index,preco);
            }
            else
            {
                // Calcula a média do preço do produto.
                ret.Add(0,produtos.Average(x=>x.Produto.PrecoVenda));
            }
            return ret;
        }

        public string GetLastException()
        {
            return LastException;
        }

        public ControlePedido NovoControle()
        {
            var ctr = new ControlePedido()
            {
                Controle = NumeroControle,
                Chave = new Criptografia.CriptHash().GetHash(DateTime.Now.ToString("ddMMyyyy") + NumeroControle)
            };
            ControlePedidoRepository.Save(ctr);

            if (NumeroControle + 1 > 500)
            {
                NumeroControle = 1;
            }
            else
            {
                NumeroControle += 1;
            }
            return ctr;
        }
    }
}
