using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.View
{
    public static class Mensagens
    {
        public static void BoasVindas()
        {
            Console.WriteLine("*-----------------------------------------------------*");
            Console.WriteLine("Bemmm vindooo ao centro Tamagotchi!!");
            Console.WriteLine("Você deseja: ");
            Console.WriteLine("1 - Adotar um mascote");
            Console.WriteLine("2 - Ver seus Mascotes");
            Console.WriteLine("3 - Sair");
            Console.WriteLine();
        }

        public static void BoasVindasAdocao()
        {
            Console.WriteLine("*-----------------------------------------------------*");
            Console.WriteLine("Adotando um mascotinhuuu");
            Console.WriteLine("*-----------------------------------------------------*");
            
        }

        public static void OpcoesDeAdocao()
        {
            Console.WriteLine("*-----------------------------------------------------*");
            Console.WriteLine("1 - Escolher mascote");
            Console.WriteLine("2 - Próxima pagina");
            Console.WriteLine("3 - Página Anterior");
            Console.WriteLine("4 - Voltar para o menu");
            Console.WriteLine("*-----------------------------------------------------*");

        }
        public static void EscolherMascote()
        {
            Console.WriteLine("*-----------------------------------------------------*");
            Console.Write("Nome do mascote escolhido: ");
        }

        public static void FalhaAoAdicionar()
        {
            Console.WriteLine("*-----------------------------------------------------*");
            Console.WriteLine("Falha ao adicionar");
            Console.WriteLine("*-----------------------------------------------------*");
            
        }
        public static void AdicionadoComSucesso()
        {
            Console.WriteLine("*-----------------------------------------------------*");
            Console.WriteLine("Adicionado com sucesso");
            Console.WriteLine("*-----------------------------------------------------*");
            
        }

        public static void UltimaPagina()
        {
            Console.WriteLine("*-----------------------------------------------------*");
            Console.WriteLine("Última Página");
            Console.WriteLine("*-----------------------------------------------------*");
            Console.WriteLine();
        }

        public static void PrimeiraPagina()
        {
            Console.WriteLine("*-----------------------------------------------------*");
            Console.WriteLine("Primeira Página");
            Console.WriteLine("*-----------------------------------------------------*");
            Console.WriteLine();
        }

        public static void BoasVindasMeusMascotes()
        {
            Console.WriteLine("*-----------------------------------------------------*");
            Console.WriteLine("Meus bixinhuuuusss");
            Console.WriteLine("*-----------------------------------------------------*");
        }

        public static void OpcoesMeusMascotes()
        {
            Console.WriteLine("*-----------------------------------------------------*");
            Console.WriteLine("1 - Ver informações do meu mascote");
            Console.WriteLine("2 - Voltar ao menu inicial");
            Console.WriteLine("*-----------------------------------------------------*");
        }
        public static void MascoteNaoEncontrado()
        {
            Console.WriteLine("*-----------------------------------------------------*");
            Console.WriteLine("Pokemon não encontrado!!");
            Console.WriteLine("*-----------------------------------------------------*");
        }
        public static void Sair()
        {
            Console.WriteLine("*-----------------------------------------------------*");
            Console.WriteLine("Tchauzinhuuu");
            Console.WriteLine("*-----------------------------------------------------*");
        }
    }
}
