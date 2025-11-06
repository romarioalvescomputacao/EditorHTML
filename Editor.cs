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
            // Limpa a tela completamente
            Console.Clear();
            
            // Define as cores do console: fundo branco, texto preto
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();  // Aplica as cores limpando novamente
            
            // Exibe o cabeçalho do editor
            Console.WriteLine("MODO EDITOR");
            Console.WriteLine("============");
            
            Start();  // Inicia o processo de edição
        }

        /// <summary>
        /// Inicia o processo de captura de texto do usuário.
        /// Permite edição até pressionar ESC, depois oferece opção de salvar o arquivo.
        /// Se o caminho for inválido ou vazio, salva em C:\ com timestamp.
        /// </summary>
        public static void Start()
        {
            // StringBuilder é mais eficiente que string para concatenar muitos textos
            var file = new StringBuilder();
            
            // Loop: continua capturando linhas até o usuário pressionar ESC
            do
            {
                file.Append(Console.ReadLine());  // Adiciona a linha digitada
                file.Append(Environment.NewLine);  // Adiciona quebra de linha (Enter)
            } while (Console.ReadKey().Key != ConsoleKey.Escape);  // Sai quando pressionar ESC
            
            Console.WriteLine("============");
            Console.WriteLine("Deseja salvar o arquivo? S/N");
            
            // Lê a resposta do usuário (se vier null, usa texto padrão)
            var option = Console.ReadLine() ?? "valor veio nulo";
            option = option.ToUpper();  // Converte para maiúscula (s vira S, n vira N)
            
            // Caso o usuário escolha salvar
            if (option == "S")
            {
                Console.WriteLine("Digite o caminho do arquivo para salvar (Exemplo: C:\\meuarquivo.html)");
                var path = Console.ReadLine();
                
                // Extrai apenas o diretório do caminho completo (sem o nome do arquivo)
                var diretorio = Path.GetDirectoryName(path);
                
                // Caso o diretório não exista ou o caminho seja vazio, usa caminho padrão
                if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(diretorio))
                {
                    // Cria nome único com data e hora para não sobrescrever arquivos
                    path = $"C:\\meuarquivo_{DateTime.Now:yyyyMMdd_HHmmss}.html";
                    Console.WriteLine($"Caminho inválido. salvando em {path}...");
                }
                
                // Salva todo o conteúdo do StringBuilder no arquivo
                System.IO.File.WriteAllText(path, file.ToString());
                Console.WriteLine($"Arquivo salvo em {path}");
                
                Menu.Show();  // Retorna ao menu
            }
            // Caso o usuário escolha não salvar
            else if (option == "N")
            {
                Console.WriteLine("❌ Arquivo não salvo.");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();  // Aguarda qualquer tecla
                Menu.Show();  // Volta ao menu
            }
            // Para caso o usuário digite uma opção inválida (não S nem N)
            else
            {
                // Simplesmente volta ao menu sem mensagem
                Menu.Show();
            }
        }
    }
}