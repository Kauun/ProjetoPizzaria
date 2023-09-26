using System;
using System.Collections.Generic;

public class Pedido
{
    public string TelefoneCliente { get; set; }
    public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
    public bool Pago { get; set; } = false;

    public decimal CalcularTotal()
    {
        decimal total = 0;
        foreach (var pizza in Pizzas)
        {
            total += pizza.Preco;
        }
        return total;
    }
}