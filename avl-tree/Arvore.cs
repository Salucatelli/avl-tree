using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avl_tree;

internal class Arvore
{
    public No? Raiz { get; set; } = null;

    public void Inserir(int valor)
    {
        Raiz = InserirNo(Raiz, valor);
    }

    //Função para inserir um novo nó
    private No? InserirNo(No? noAtual, int valor)
    {
        if (noAtual == null)
        {
            return new No(valor); 
        }

        if (valor < noAtual.Valor)
        {
            noAtual.Esquerda = InserirNo(noAtual.Esquerda, valor);
        }
        else if (valor > noAtual.Valor)
        {
            noAtual.Direita = InserirNo(noAtual.Direita, valor);
        }
        else
        {
            Console.WriteLine("Nó já está na árvore");
            return noAtual; 
        }

        Console.WriteLine($"{valor} inserido");

        return Balancear(noAtual);
    }

    private No EncontrarMenorValor(No no)
    {
        while (no.Esquerda != null)
        {
            no = no.Esquerda;
        }
        return no;
    }

    public void Remover(int valor)
    {
        Raiz = RemoverNo(Raiz, valor);
    }


    // Função para remover um nó da árvore
    private No? RemoverNo(No? noAtual, int valor) 
    {
        if (noAtual == null)
        {
            return null;
        }

        if (valor < noAtual.Valor)
        {
            noAtual.Esquerda = RemoverNo(noAtual.Esquerda, valor);
        }
        else if (valor > noAtual.Valor)
        {
            noAtual.Direita = RemoverNo(noAtual.Direita, valor);
        }
        else 
        {

            if (noAtual.Esquerda == null)
            {
                return noAtual.Direita;
            }
            else if (noAtual.Direita == null)
            {
                return noAtual.Esquerda;
            }
            else
            {
                No sucessor = EncontrarMenorValor(noAtual.Direita);

                noAtual.Valor = sucessor.Valor;

                noAtual.Direita = RemoverNo(noAtual.Direita, sucessor.Valor);
            }
        }

        Console.WriteLine($"{valor} removido");

        return noAtual == null ? null : Balancear(noAtual); 
    }


    public void Busca(int valor)
    {
        No no = BuscaNo(Raiz, valor)!;
        if(no is null)
        {
            Console.WriteLine($"Nó {valor} não encontrado");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine($"Nó com valor {no.Valor} encontrado!");
            Console.WriteLine();
        }
    }

    //Buscar um nó
    private No? BuscaNo(No? noAtual, int valor)
    {
        //Caso base
        if(noAtual == null)
        {
            return null;
        }

        if(valor > noAtual.Valor) //vai para direita
            noAtual = BuscaNo(noAtual.Direita, valor);
        else if(valor < noAtual.Valor) //vai para esquerda
            noAtual = BuscaNo(noAtual.Esquerda, valor);

        return noAtual;
    }

    public void PreOrdem()
    {
        Console.WriteLine("Imprimindo em Pré-Ordem: ");
        PreOrdemNo(Raiz);
        Console.WriteLine("\n");
    }


    private void PreOrdemNo(No? noAtual)
    {
        //Caso base
        if(noAtual == null)
        {
            return;
        }

        if (noAtual != Raiz) { Console.Write("-> "); } else Console.Write("\t");
        Console.Write($"{noAtual.Valor} ");

        //Imprime primeiro o lado esquerdo
        PreOrdemNo(noAtual.Esquerda);

        //E depois vai para o lado direito
        PreOrdemNo(noAtual.Direita);
    }


    public void ObterTodosFatoresBalanceamento()
    {
        Console.WriteLine("Obtendo Fatores de balanceamento:");
        FatorBalanceamento(Raiz);
        Console.WriteLine();
    }

    private void FatorBalanceamento(No? noAtual)
    {
        //Caso base
        if (noAtual == null)
        {
            return;
        }

        Console.WriteLine($"\tNó {noAtual.Valor}: Fator de balanceamento {ObterFatorBalanceamento(noAtual)}");

        //Imprime primeiro o lado esquerdo
        FatorBalanceamento(noAtual.Esquerda);

        //E depois vai para o lado direito
        FatorBalanceamento(noAtual.Direita);
    }


    //Imprime a altura da árvore
    public void AlturaArvore()
    {
        Console.WriteLine($"A altura da árvore é {Raiz!.Altura}\n");
    }


    private int ObterAltura(No? no)
    {
        return no?.Altura ?? 0;
    }

    private void AtualizarAltura(No no)
    {
        no.Altura = 1 + Math.Max(ObterAltura(no.Esquerda), ObterAltura(no.Direita));
    }

    private int ObterFatorBalanceamento(No? no)
    {
        if (no == null)
        {
            return 0;
        }
        return ObterAltura(no.Direita) - ObterAltura(no.Esquerda);
    }

    private No RotacaoEsquerda(No z)
    {
        No y = z.Direita!; 
        No? T2 = y.Esquerda; 

        y.Esquerda = z;
        z.Direita = T2;

        AtualizarAltura(z); 
        AtualizarAltura(y); 

        return y; 
    }
    private No RotacaoDireita(No z)
    {
        No y = z.Esquerda!; 
        No? T3 = y.Direita; 

        y.Direita = z;
        z.Esquerda = T3;

        AtualizarAltura(z); 
        AtualizarAltura(y); 

        return y; 
    }

    private No RotacaoEsquerdaDireita(No z)
    {
        z.Esquerda = RotacaoEsquerda(z.Esquerda!); 
        return RotacaoDireita(z); 
    }

    private No RotacaoDireitaEsquerda(No z)
    {
        z.Direita = RotacaoDireita(z.Direita!); 
        return RotacaoEsquerda(z); 
    }
    private No Balancear(No no)
    {
        AtualizarAltura(no); 

        int fatorBalanceamento = ObterFatorBalanceamento(no);

        if (fatorBalanceamento < -1)
        {
            if (ObterFatorBalanceamento(no.Esquerda) <= 0) 
            {
                return RotacaoDireita(no);
            }
            else
            {
                return RotacaoEsquerdaDireita(no);
            }
        }

        if (fatorBalanceamento > 1)
        {
            if (ObterFatorBalanceamento(no.Direita) >= 0) 
            {
                return RotacaoEsquerda(no);
            }
            else 
            {
                return RotacaoDireitaEsquerda(no);
            }
        }
        return no;
    }
}
