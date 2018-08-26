using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducaRank.MVC.Utilitarios
{
    public class SortAlgorithm
    {
        //Esse código foi baseado na ideia original de um quicksort, mas pegando uma variável a menos para o
        //particionamento e, nesse caso, retornando uma lista. vai servir só para popular os dados de posicionamento
        //no rank. 

        static public List<ViewModels.EscolaRank> QuickSortModificado(List<ViewModels.EscolaRank> escolasRank)
        {
            ViewModels.EscolaRank[] vetor = escolasRank.ToArray();
            QuickSortRecursive(vetor, 0, vetor.Length - 1);

            int contador = 1;
            for (int i = vetor.Length-1; i >= 0; i--)
            {
                if (i < vetor.Length-1)
                {
                    if (vetor[i].Nota != vetor[i + 1].Nota)
                        vetor[i].Colocacao = contador;
                    else
                        vetor[i].Colocacao = vetor[i + 1].Colocacao;
                }
                else
                {
                    vetor[i].Colocacao = contador;
                }
                contador++;
            }
           
            return new List<ViewModels.EscolaRank>(vetor);
        }

        static public int Partition(ViewModels.EscolaRank[] vetor, int esquerda, int direita)

        {
            ViewModels.EscolaRank pivot = vetor[esquerda];
            while (true)
            {
                while (vetor[esquerda].Nota < pivot.Nota)
                    esquerda++;
                while (vetor[direita].Nota > pivot.Nota)
                    direita--;
                
                if (vetor[direita].Nota == pivot.Nota && vetor[esquerda].Nota == pivot.Nota)
                    esquerda++;

                if (esquerda < direita)
                {
                    ViewModels.EscolaRank temp = vetor[direita];
                    vetor[direita] = vetor[esquerda];
                    vetor[esquerda] = temp;
                }
                else
                {
                    return direita;
                }
            }

        }

        static public void QuickSortRecursive(ViewModels.EscolaRank[] vetor, int esquerda, int direita)

        {
            if (esquerda < direita)
            {
                int pivot = Partition(vetor, esquerda, direita);
                if (pivot > 1)
                    QuickSortRecursive(vetor, esquerda, pivot - 1);
                if (pivot + 1 < direita)
                    QuickSortRecursive(vetor, pivot + 1, direita);
            }
        }

    }
}