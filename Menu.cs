namespace EditorHtml
{
    /// <summary>
    /// Classe responsável por exibir e gerenciar o menu principal da aplicação
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// Exibe o menu principal e processa a opção escolhida pelo usuário
        /// </summary>
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            
            DrawScreen();  // Desenha a moldura do menu
            WriteOptions();  // Escreve as opções dentro da moldura
            
            // Lê a opção digitada e converte para número (short)
            var option = short.Parse(Console.ReadLine()!);
            
            HandleMenuOption(option);  // Processa a opção escolhida
        }

        /// <summary>
        /// Desenha a moldura visual do menu usando caracteres ASCII
        /// </summary>
        public static void DrawScreen()
        {
            // Define o tamanho da moldura
            int nLinhas = 10;
            int nColunas = 30;
            
            // Desenha a linha superior: +-----+
            Console.Write("+");
            for (int i = 0; i <= nColunas; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            Console.Write("\n");
            
            // Desenha as linhas do meio: |     |
            for (int lines = 0; lines <= nLinhas; lines++)
            {
                Console.Write("|");  // Borda esquerda
                
                // Espaços vazios no meio (onde vão as opções)
                for (int i = 0; i <= nColunas; i++)
                {
                    Console.Write(" ");
                }
                
                Console.Write("|");  // Borda direita
                Console.Write("\n");
            }
            
            // Desenha a linha inferior: +-----+
            Console.Write("+");
            for (int i = 0; i <= nColunas; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            Console.Write("\n");
        }

        /// <summary>
        /// Escreve as opções do menu em posições específicas dentro da moldura
        /// </summary>
        public static void WriteOptions()
        {
            // SetCursorPosition(coluna, linha) posiciona o cursor na tela
            
            Console.SetCursorPosition(3, 1);
            Console.WriteLine("Editor HTML");
            
            Console.SetCursorPosition(3, 2);
            Console.WriteLine("============");
            
            Console.SetCursorPosition(3, 3);
            Console.WriteLine("Selecione uma opção abaixo");
            
            // Opções disponíveis
            Console.SetCursorPosition(3, 5);
            Console.WriteLine("1 - Novo arquivo");
            
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("2 - Abrir arquivo");
            
            Console.SetCursorPosition(3, 8);
            Console.WriteLine("0 - Sair");
            
            // Posiciona o cursor para o usuário digitar
            Console.SetCursorPosition(3, 10);
            Console.Write("Opção: ");
        }

        /// <summary>
        /// Processa a opção escolhida pelo usuário e direciona para a funcionalidade correspondente
        /// </summary>
        /// <param name="option">Número da opção escolhida</param>
        public static void HandleMenuOption(short option)
        {
            switch (option)
            {
                case 1:
                    // Abre o editor para criar novo arquivo
                    Editor.Show();
                    break;
                    
                case 2:
                    // Abre o visualizador de arquivos
                    Viewer.Show();
                    break;
                    
                case 0:
                    // Limpa a tela e encerra a aplicação
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                    
                default:
                    // Se digitar opção inválida, mostra o menu novamente
                    Show();
                    break;
            }
        }
    }
}