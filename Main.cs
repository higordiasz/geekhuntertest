using System;
using System.Collections.Generic;

public class Itens {
    public string itemName {get; set;}
    public int itemPrice {get; set;}
}

public class Comanda {
    public List<Itens> Pedido {get; set;}
    public int Total {get; set;}
    public int Clientes {get; set;}
    public List<string> Remover {get;set;}
}

public class Test
{
    public static Comanda Mesa;
    public static int Remover = 0;
    public static void processInput(string input)
    {
        var arr = input.Split(' ');
        Itens aux = new Itens {
            itemName = arr[0],
            itemPrice = Convert.ToInt32(arr[1])
        };
        Mesa.Pedido.Add(aux);
        Mesa.Total += aux.itemPrice;
    }
    
    public static void processRemoveString(string input) {
        var arr = input.Split(' ');
        for (int i = 0; i < arr.Length; i++) {
            foreach (var item in Mesa.Pedido)
            {
                if (item.itemName == arr[i]) {
                    Remover += item.itemPrice;
                    break;
                }
            }
        }
    }

    public static void printResult() {
        Console.WriteLine(Mesa.Total);
        Console.WriteLine((Mesa.Total - Remover) / Mesa.Clientes);
        Console.WriteLine(Remover);
    }

    //Este e um exemplo de processamento de entradas (inputs), sinta-se a vontade para altera-lo conforme necessidade da questao.
    public static void Main()
    {
        Mesa = new Comanda {
            Pedido = new List<Itens>(),
            Total = 0,
            Clientes = 0,
            Remover = new List<string>()
        };
        string line;
        Mesa.Clientes = Convert.ToInt32(Console.ReadLine());
        int itens = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < itens; i++) {
            line = Console.ReadLine();
            processInput(line);
        }
        processRemoveString(Console.ReadLine());
        printResult();
    }
}