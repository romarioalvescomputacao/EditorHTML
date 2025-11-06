using System;
using System.IO;

namespace EditorHtml
{
    /// <summary>
    /// Classe responsável por visualizar o conteúdo de arquivos HTML salvos
    /// </summary>
    public static class Viewer
    {
        /// <summary>
        /// Exibe a interface de visualização e mostra o conteúdo do arquivo selecionado.
        /// Se o arquivo não existir ou o caminho for inválido, retorna ao menu principal.
        /// </summary>
        public static void Show()
        {   
            // Limpa a tela e configura as cores
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            
            // Solicita o caminho do arquivo ao usuário
            Console.WriteLine("Inserir o caminho completo do arquivo para visualização (ex: C:\\meuarquivo.html):");
            var path = Console.ReadLine() ?? "valor veio nulo";
            
            // Validação: verifica se o caminho está vazio OU se o arquivo não existe
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                Console.WriteLine("❌ Caminho inválido ou arquivo inexistente. Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();  // Espera o usuário pressionar qualquer tecla
                Menu.Show();  // Retorna ao menu principal
            }
            
            // Lê todo o conteúdo do arquivo e armazena na variável
            var conteudo = File.ReadAllText(path);
            
            // Limpa a tela para exibir apenas o conteúdo
            Console.Clear();
            Console.WriteLine("MODO VISUALIZAÇÃO");
            Console.WriteLine("============");
            
            // Exibe o conteúdo do arquivo
            Console.WriteLine(conteudo);
            
            Console.WriteLine("============");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            
            Console.ReadKey();  // Aguarda o usuário ler o conteúdo
            Menu.Show();  // Volta ao menu principal
        }
    }
}