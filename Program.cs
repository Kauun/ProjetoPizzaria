using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Pizzaria pizzaria = new Pizzaria();
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("1 - Adicionar Pizza");
            Console.WriteLine("2 - Listar Pizzas");
            Console.WriteLine("3 - Criar Novo Pedido");
            Console.WriteLine("4 - Listar Pedidos");
            Console.WriteLine("5 - Pagar Pedido");
            Console.WriteLine("6 - Sair");

            int escolha = Convert.ToInt32(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    Console.Write("Digite o nome da pizza: ");
                    string nome = Console.ReadLine();
                    Console.Write("Digite o sabor da pizza: ");
                    string sabor = Console.ReadLine();
                    Console.Write("Digite o preço da pizza: ");
                    decimal preco = Convert.ToDecimal(Console.ReadLine());
                    pizzaria.AdicionarPizza(nome, sabor, preco);
                    break;
                case 2:
                    pizzaria.ListarPizzas();
                    break;
                case 3:
                    Console.Write("Digite o telefone do cliente: ");
                    string telefone = Console.ReadLine();
                    Console.WriteLine("Selecione as pizzas pelo número (separado por vírgula):");
                    string[] numerosPizzas = Console.ReadLine().Split(',');
                    List<int> listaNumerosPizzas = new List<int>();

                    foreach (var numero in numerosPizzas)
                    {
                        listaNumerosPizzas.Add(Convert.ToInt32(numero));
                    }

                    pizzaria.FazerPedido(telefone, listaNumerosPizzas);
                    break;
                case 4:
                    Console.Write("Digite o número do pedido: ");
                    int numeroPedido = Convert.ToInt32(Console.ReadLine());
                    pizzaria.VerDetalhesPedido(numeroPedido);
                    break;
                case 5:
                    Console.Write("Digite o número do pedido: ");
                    int numeroPedidoPagamento = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Selecione a forma de pagamento (dinheiro, cartão, vale-refeição): ");
                    string formaPagamento = Console.ReadLine();
                    Console.Write("Digite o valor pago: ");
                    decimal valorPago = Convert.ToDecimal(Console.ReadLine());
                    pizzaria.FazerPagamento(numeroPedidoPagamento, formaPagamento, valorPago);
                    break;
                case 6:
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Escolha inválida. Tente novamente.");
                    break;
            }
        }
    }
}
