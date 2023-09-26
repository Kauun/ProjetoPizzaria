using System;
using System.Collections.Generic;

public class Pizza
{
    public string Nome { get; set; }
    public string Sabor { get; set; }
    public decimal Preco { get; set; }

    public Pizza(string nome, string sabor, decimal preco)
    {
        Nome = nome;
        Sabor = sabor;
        Preco = preco;
    }
}