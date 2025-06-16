using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avl_tree;

internal class No
{
    public int Valor { get; set; }
    public No? Direita { get; set; }
    public No? Esquerda { get; set; }
    public int Altura { get; set; }

    public No(int valor)
    {
        this.Valor = valor;
        this.Direita = null;
        this.Esquerda = null;
        Altura = 1;
    }
}
