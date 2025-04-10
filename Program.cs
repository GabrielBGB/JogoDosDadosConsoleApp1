using System;

class Program
{
    static Random random = new Random();

    static void Main()
    {
        MostrarIntroducao();

        #region Inicialização
        const int posicaoFinal = 30;
        int posicaoJogador = 0;
        int posicaoComputador = 0;
        #endregion

        #region Loop Principal do Jogo
        while (posicaoJogador < posicaoFinal && posicaoComputador < posicaoFinal)
        {
            // Turno do Jogador
            Console.WriteLine("\nSua vez! Pressione ENTER para rolar o dado...");
            Console.ReadLine();
            int dadoJogador = RolarDado();
            Console.WriteLine($"Você tirou {dadoJogador}!");

            posicaoJogador = AtualizarPosicao("Jogador", posicaoJogador, dadoJogador);
            ExibirPosicoes(posicaoJogador, posicaoComputador);

            // Verifica vitória do jogador
            if (posicaoJogador >= posicaoFinal)
            {
                Console.WriteLine("\n Parabéns! Você venceu a corrida!");
                break;
            }

            // Rodada extra se tirou 6
            while (dadoJogador == 6)
            {
                Console.WriteLine("Você tirou 6! Jogue novamente.");
                Console.ReadLine();
                dadoJogador = RolarDado();
                Console.WriteLine($"Você tirou {dadoJogador}!");
                posicaoJogador = AtualizarPosicao("Jogador", posicaoJogador, dadoJogador);
                ExibirPosicoes(posicaoJogador, posicaoComputador);
                if (posicaoJogador >= posicaoFinal)
                {
                    Console.WriteLine("\n Parabéns! Você venceu a corrida!");
                    return;
                }
            }

            // Turno do Computador
            Console.WriteLine("\nVez do computador...");
            System.Threading.Thread.Sleep(1000);
            int dadoComputador = RolarDado();
            Console.WriteLine($"Computador tirou {dadoComputador}.");

            posicaoComputador = AtualizarPosicao("Computador", posicaoComputador, dadoComputador);
            ExibirPosicoes(posicaoJogador, posicaoComputador);

            // Verifica vitória do computador
            if (posicaoComputador >= posicaoFinal)
            {
                Console.WriteLine("\n O computador venceu a corrida!");
                break;
            }

            // Rodada extra se tirou 6
            while (dadoComputador == 6)
            {
                Console.WriteLine("Computador tirou 6! Jogando novamente...");
                System.Threading.Thread.Sleep(1000);
                dadoComputador = RolarDado();
                Console.WriteLine($"Computador tirou {dadoComputador}.");
                posicaoComputador = AtualizarPosicao("Computador", posicaoComputador, dadoComputador);
                ExibirPosicoes(posicaoJogador, posicaoComputador);
                if (posicaoComputador >= posicaoFinal)
                {
                    Console.WriteLine("\n O computador venceu a corrida!");
                    return;
                }
            }
        }
        #endregion

        Console.WriteLine("\nFim de jogo!");
    }

    #region Métodos Auxiliares

    static void MostrarIntroducao()
    {
        Console.WriteLine("=======================================");
        Console.WriteLine(" Jogo de Corrida de Dados");
        Console.WriteLine("=======================================");
        Console.WriteLine("Objetivo: Seja o primeiro a chegar na posição 30!");
        Console.WriteLine("Dica: Se cair em certas casas, há surpresas...");
        Console.WriteLine("Pressione ENTER para começar!");
        Console.ReadLine();
    }

    static int RolarDado()
    {
        return random.Next(1, 7);
    }

    static int AtualizarPosicao(string nome, int posicaoAtual, int valorDado)
    {
        posicaoAtual += valorDado;

        // Eventos Especiais
        if (posicaoAtual == 5 || posicaoAtual == 10 || posicaoAtual == 15)
        {
            Console.WriteLine($"{nome} caiu em uma casa de AVANÇO! +3 casas.");
            posicaoAtual += 3;
        }
        else if (posicaoAtual == 7 || posicaoAtual == 13 || posicaoAtual == 20)
        {
            Console.WriteLine($"{nome} caiu em uma casa de RECUO! -2 casas.");
            posicaoAtual -= 2;
            if (posicaoAtual < 0) posicaoAtual = 0;
        }

        return posicaoAtual;
    }

    static void ExibirPosicoes(int jogador, int computador)
    {
        Console.WriteLine($"\n Posição Atual:");
        Console.WriteLine($"Você: {jogador} | Computador: {computador}");
    }

    #endregion
}