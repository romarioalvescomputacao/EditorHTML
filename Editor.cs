using System;
using System.Text;

namespace EditorHtml
{
    /// <summary>
    /// Classe responsável pelo editor de texto HTML
    /// </summary>
    public static class Editor
    {
        /// <summary>
        /// Exibe a interface do editor e inicia o modo de edição
        /// </summary>
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO EDITOR");
            Console.WriteLine("============");
            Start();
        }

        /// <summary>
        /// Inicia o processo de captura de texto do usuário.
        /// Permite edição até pressionar ESC, depois oferece opção de salvar o arquivo.
        /// Se o caminho for inválido ou vazio, salva em C:\ com timestamp.
        /// </summary>
        public static void Start()
        {
            var file = new StringBuilder();
            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            
            Console.WriteLine("============");
            Console.WriteLine("Deseja salvar o arquivo? S/N");
            var option = Console.ReadLine() ?? "valor veio nulo";
            option = option.ToUpper();
            //Caso o usuário escolha salvar
            if (option == "S")
            {
                Console.WriteLine("Digite o caminho do arquivo para salvar (Exemplo: C:\\meuarquivo.html)");
                var path = Console.ReadLine();
                var diretorio = Path.GetDirectoryName(path);
                //Caso o diretório não exista ou o caminho seja vazio, salva na pasta C:\DataTime
                if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(diretorio))
                {
                    path = $"C:\\meuarquivo_{DateTime.Now:yyyyMMdd_HHmmss}.html";
                    Console.WriteLine($"Caminho inválido. salvando em {path}...");
                }
                //Salva o conteúdo no arquivo
                System.IO.File.WriteAllText(path, file.ToString());
                Console.WriteLine($"Arquivo salvo em {path}");
                Menu.Show();
            }
            //Caso o usuário escolha não salvar
            else if (option == "N")
            {
                Console.WriteLine("Arquivo não salvo.");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();

                Menu.Show();
            }
            //para caso o usuário digite uma opção inválida
            else
            {
                Menu.Show();
            }
        }
    }
}