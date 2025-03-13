using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XulambsFoods_2025_1.src {
    public class Pedido {
        private static int s_ultimoPedido = 0;
        private const int MaxPizzas = 100;

        private int _idPedido;
        private DateOnly _data;
        private Pizza[] _pizzas;
        private int _quantPizzas;
        private bool _aberto;

        public Pedido() {
            s_ultimoPedido++;
            _idPedido = s_ultimoPedido;
            _data = DateOnly.FromDateTime(DateTime.Now);
            _pizzas = new Pizza[MaxPizzas];
            _quantPizzas = 0;
            _aberto = true;
        }

        /// <summary>
        /// Construtor. Crioa um édido aberto e vazio.
        /// </summary>

        private bool PodeAdicionar() {
            return _aberto;
        }

        /// <summary>
        /// Adiciona uma pizza ao pedido, caso ele esteja aberto. 
        /// Caso contrário, ignora a operação.
        /// Retorna a quantidade de pizzas no pedido ao fim da execução.
        /// </summary>
        /// <param name="pizza">A pizza a ser incluída no pedido.</param>
        /// <returns>Quantidade de pizzas no pedido após a execução.</returns>

        public int Adicionar(Pizza pizza) {
            if (PodeAdicionar()) {
                _pizzas[_quantPizzas] = pizza;
                _quantPizzas++;
            }
            return _quantPizzas;
        }

        public void FecharPedido() {
            _aberto = false;
        }

        public double PrecoAPagar() {
            double preco = 0d;
            for (int i = 0; i < _quantPizzas; i++) {
                preco += _pizzas[i].ValorFinal();
            }
            return preco;
        }

        public string Relatorio() {
            StringBuilder relat = new StringBuilder($"Pedido nº{_idPedido:D2} - {_data}\n");
            relat.AppendLine("==============================");
            for (int i = 0; i < _quantPizzas; i++) {
                relat.AppendLine($"{(i+1):D2} -{_pizzas[i].NotaDeCompra():C2}");
            }
            relat.AppendLine($"\nValor a pagar: {PrecoAPagar():C2}");
            relat.AppendLine("==============================");
            return relat.ToString();
        }
    }
}
