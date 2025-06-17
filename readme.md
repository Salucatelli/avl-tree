# 🌲  Árvore AVL

## Visão Geral do Projeto

Este projeto foi desenvolvido para a disciplina de Análise e projetos orientados a objetos I e consiste na implementação de uma Arvore Binária de Busca com auto-balanceamento (Árvore AVL).

## 📁 Estrutura do Projeto

A solução está dividida em três arquivos principais:



* `Program.cs`: Responsável por ler o arquivo inputFile.txt, interpretar as instruções a serem realizadas, e executa-las corretamente.

* `No.cs`: Representa o modelo de um nó da árvore, com valor(int), Nó direito(No), Nó esquerdo(No) e altura do Nó(int).

* `Arvore.cs`: Este arquivo contém todos os métodos necessários para as operações da árvore, são eles:
    * `Inserir` 
    * `Remover` 
    * `Busca` 
    * `PreOrdem` 
    * `ObterTodosFatoresBalanceamento` 
    * `ObterAltura` 

## 📃 Arquivo .txt

O arquivo inputFile.txt funciona com uma instrução por linha, onde primeiro vem a instrução e, dependendo da instrução, vem um numero na frente separaro por vírgula, por exemplo:

    I 10 
    I 20
    P
    I 15
    P
    R 20
    P
    B 15
    F
    H

As instruções são:

* `I (valor)` inserir um novo valor
* `R (valor)` remover um  valor
* `B (valor)` buscar um valor
* `P` imprimir a árvore e pré-ordem
* `F` imprimir o fator de balanceamento de todos os nós
* `H` imprimir a altura da árvore

## 💻 Como Usar

Para usar este Projeto:

1.  **Clone o Repositório:**
    O primeiro passo é clonar o repositóro do projeto para ter acesso a ele.
3.  **Arquivo .txt:**
    Existe já um arquivo inputFile.txt com instruções prontas, mas caso quera pode mudar este arquivo para realizar outras operações.

        I 10 
        I 20
        P
        I 15
        P
        R 20
        P
        B 15
        F
        H


4.  **Executar:**
    Abra a solução atravez da IDE de sua preferência (recomendo o Visual Studio), e execute o programa.