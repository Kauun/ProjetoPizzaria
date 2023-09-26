using System;
using System.Collections.Generic;

public class Pizzaria
{
    public List<Pizza> PizzasCriadas { get; set; } = new List<Pizza>();
    public List<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public void AdicionarPizza(string nome, string sabor, decimal preco)
    {
        Pizza pizza = new Pizza(nome, sabor, preco);
        PizzasCriadas.Add(pizza);
    }

    public void ListarPizzas()
    {
        foreach (var pizza in PizzasCriadas)
        {
            Console.WriteLine($"Nome: {pizza.Nome}, Sabor: {pizza.Sabor}, Preço: {pizza.Preco}");
        }
    }

    public void FazerPedido(string telefoneCliente, List<int> numerosPizzas)
    {
        Pedido pedido = new Pedido();
        pedido.TelefoneCliente = telefoneCliente;

        foreach (var numero in numerosPizzas)
        {
            int index = numero - 1;
            if (index >= 0 && index < PizzasCriadas.Count)
            {
                pedido.Pizzas.Add(PizzasCriadas[index]);
            }
        }

        Pedidos.Add(pedido);
    }

    public void VerDetalhesPedido(int numeroPedido)
    {
        if (numeroPedido >= 1 && numeroPedido <= Pedidos.Count)
        {
            Pedido pedido = Pedidos[numeroPedido - 1];
            Console.WriteLine($"Telefone do Cliente: {pedido.TelefoneCliente}");
            Console.WriteLine("Pizzas:");
            foreach (var pizza in pedido.Pizzas)
            {
                Console.WriteLine($"Nome: {pizza.Nome}, Sabor: {pizza.Sabor}, Preço: {pizza.Preco}");
            }
            Console.WriteLine($"Total: {pedido.CalcularTotal()}");
            Console.WriteLine($"Pago: {(pedido.Pago ? "Sim" : "Não")}");
        }
        else
        {
            Console.WriteLine("Pedido não encontrado.");
        }
    }

    public void FazerPagamento(int numeroPedido, string formaPagamento, decimal valorPago)
    {
        if (numeroPedido >= 1 && numeroPedido <= Pedidos.Count)
        {
            Pedido pedido = Pedidos[numeroPedido - 1];
            if (!pedido.Pago)
            {
                if (valorPago >= pedido.CalcularTotal())
                {
                    Console.WriteLine("Pagamento realizado com sucesso!");
                    pedido.Pago = true;

                    if (valorPago > pedido.CalcularTotal() && formaPagamento.ToLower() == "dinheiro")
                    {
                        decimal troco = valorPago - pedido.CalcularTotal();
                        Console.WriteLine($"Troco a ser devolvido: {troco}");
                    }
                }
                else
                {
                    Console.WriteLine("Valor insuficiente para o pagamento.");
                }
            }
            else
            {
                Console.WriteLine("Este pedido já foi pago.");
            }
        }
        else
        {
            Console.WriteLine("Pedido não encontrado.");
        }
    }
}