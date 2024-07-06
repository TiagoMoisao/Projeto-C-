using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projeto_final_M7
{

    struct Escola 
    {
        public string Turma, Alunos, Nome, Apelido;
        public ulong alunos, Idade, NumAlunos;
    }

    struct Professores
    {
        public string Professor, Nome, Apelido, Disciplina;
        public ulong professores, Idade, NumProfessores,numero;
    }

    class Program
    {
        static ulong ValorValido(string mensagem) // Recebe uma mensagem como parâmetro e retorna um número ulong que representa o valor inserido pelo utilizador.
        {
            ulong opção; // Para armazenar o número fornecido.
            while (true) // Loop que só será interrompido quando um valor válido for inserido.
            {
                Console.Write(mensagem); // Escreve o argumento que foi enviado pelo main, substituindo o Console.writeLine();
                if (ulong.TryParse(Console.ReadLine(), out opção) && opção >= 0 ) // Pede o input, tenta converter para ulong e valida se o valor é um número e diferente de 0.
                    return opção; // retorna o valor da váriavel temporária criada dentro do método.
                else
                    Console.WriteLine("Valor inválido."); // Avisa que foi inserido um valor inválido.
            }
        }

        static void Main(string[] args)
        {
            MainMenu(); //Chama o subprograma para apresentar o primeiro menu.
        }


        static void MainMenu() //Subprograma que apresenta o main menu.
        {
            Console.Clear(); //Apaga o cmd.
            ulong opção; //declara a variavel que é usada para o utilizador selecionar a opção que deseja.
            Console.WriteLine("|_Bem_Vindo_á_gerência_da_Escola_de_Surf_do_Zequinha_|"); //mensagem de bem vindo para o utilizador.
            menu: //função de goto utilizada caso o utilizador selecione uma opção que não exista.
            Console.WriteLine("Escolha a opção do que deseja fazer:"); //mensagem para o utilizador.
            Console.WriteLine("\n 1- Menu Turmas \n 2- Menu Professores"); //lista de opções apresentada ao utilizador.
            opção = ValorValido("\n Selecione a opção que deseja: "); //Chama o método de verificação de dados inseridos.

            switch (opção) //switch com as opções da lista apresentada.
            {
                case 1:
                    MenuTurmas(); //Chama o método para mostrar o menu de turmas.
                    break;
                case 2:
                    MenuProfessores();  //Chama o método para mostrar o menu de professores.
                    break;
                default:
                    Console.WriteLine("Essa opção não existe!"); //mensagem para o utilizador caso o mesmo selecione uma opção inexistente.
                    goto menu; //função goto para voltar ao menu das opções caso o utilizador selecione uma opção inexistente.
            }
        }

        static void MenuTurmas() //Subprograma para mostrar o menu de turmas.
        {
            Console.Clear(); //Apaga o cmd.
            ulong opção; //declara a variavel que é usada para o utilizador selecionar a opção que deseja.
            menu: //função de goto utilizada caso o utilizador selecione uma opção que não exista. 
            Console.WriteLine("Selecionou a opção Menu Turmas"); //mensagem para o utilizador.
            Console.WriteLine("Escolha a opção do que deseja fazer:"); //mensagem para o utilizador
            Console.WriteLine("\n 1- Criar Turma \n 2- Remover Turma \n 3- Ver Turma \n 4- Informações da lista da Turma \n 5- Menu inicial");//lista de opções apresentada ao utilizador.
            opção = ValorValido("\n Selecione a opção que deseja: "); //Chama o método de verificação de dados inseridos.

            switch (opção)  //switch com as opções da lista apresentada.
            {
                case 1:
                    CriarTurmas(); //Chama o método para criar o ficheiro turmas.txt
                    break;
                case 2:
                   RemoverTurmas();  //Chama o método para remover o ficheiro turmas.txt
                    break;
                case 3:
                    VMTurmas();  //Chama o método para mostrar o conteudo do ficheiro turmas.txt
                    break;                               
                case 4:
                    InformaçõesTurmas(); //Chama o método para mostrar as informações do ficheiro turmas.txt
                    break;
                case 5:
                    MainMenu(); //Chama o método para mostrar o menu principal.
                    break;
                default:
                    Console.WriteLine("Essa opção não existe!"); //mensagem para o utilizador caso o mesmo selecione uma opção inexistente.
                    goto menu; //função goto para voltar ao menu das opções caso o utilizador selecione uma opção inexistente.
            }
        }

        static void CriarTurmas() //Subprograma para criar ficheiro e preencher com as informações da turma.
        { 
            Escola ficheiro,nficheiro,TAM; //declarar variaveis do tipo struct.
            ulong opção; //declara a variavel que é usada para o utilizador selecionar a opção que deseja.
            criar: //função de goto utilizada se o utilizador quiser adicionar mais uma turma.
            Console.Clear(); //Apaga o cmd.
            Console.WriteLine("Selecionou a opção Criar Turma"); //mensagem para o utilizador.
            Console.WriteLine("Qual a turma que deseja intruduzir(Ex.: 9ºC):"); //mensagem para o utilizador.
            nficheiro.Nome = Console.ReadLine(); //lê o nome da turma que vai ser dado ao nome do ficheiro.
            ficheiro.Turma = $"{nficheiro.Nome}.txt"; //recebe o nome da turma e insere como nome do ficheiro.
            FileStream ficheiros = new FileStream(ficheiro.Turma, FileMode.OpenOrCreate, FileAccess.Write); //acede ou cria o ficheiro caso não exista e dá acesso para escrever no ficheiro.
            StreamWriter escritor = new StreamWriter(ficheiros); //cria variavel que serve para escrever dentro do ficheiro.
            TAM.NumAlunos = ValorValido("Digite quantos alunos tem a turma: "); //lê a quantidade de alunos que o utilizador deseja inserir e verifica se é um numero acima de 0 e sem letras.
            Escola[] alunos = new Escola[TAM.NumAlunos]; //Cria vetor para armazenar os dados.

            for (ulong i = 0; i < TAM.NumAlunos; i++) //Ciclo for para ler os dados da quantidade de alunos que o utilizador indicou.
            {
                Console.WriteLine($"Detalhes do {i+1}º Aluno:"); //mensagem para o utilizador.
                alunos[i] = LerDetalhesAluno(escritor); //Chama o subprograma que vai ler os dados de cada aluno.
                
                Console.WriteLine();
            }


            escritor.Close(); //fecha o ficheiro.
            ficheiros.Close(); //fecha o ficheiro.

            menu: //função de goto utilizada caso o utilizador selecione uma opção que não exista.
            Console.WriteLine("  ");
            Console.WriteLine("Escolha a opção que deseja fazer: "); //mensagem para o utilizador.
            Console.WriteLine("\n 1- Criar outra Turma \n 2- Menu inicial \n 3- Menu Turma \n 4- Sair"); //lista de opções apresentada ao utilizador.
            opção = ValorValido("\n Selecione a opção que deseja: "); //lê a variavel e leva até ao subprograma que vai verificar se o utilizador escreveu um numero sem letras.
            switch (opção) //switch com as opções da lista apresentada.
            {
                case 1:
                    goto criar; //função goto que volta para o inicio do subprograma caso o utilizador queira adicionar outra turma.
                case 2:
                    MainMenu(); //Chama o subprograma que volta ao menu principal.
                    break;
                case 3:
                    MenuTurmas(); //Chama o subprograma que volta ao menu de turmas.
                    break;
                case 4:
                    Environment.Exit(0); //fecha o programa.
                    break;
                default:
                    Console.WriteLine("Essa opção não existe!");  //mensagem para o utilizador caso o mesmo selecione uma opção inexistente.
                    goto menu; //função goto para voltar ao menu das opções caso o utilizador selecione uma opção inexistente.
            }
        }

        static Escola LerDetalhesAluno(StreamWriter fich) //Subprograma que lê os dados dos alunos e escreve-os no ficheiro.
        {
            Escola aluno = new Escola();
            Console.Write("Nome: "); //solicita ao utilizador.
            aluno.Nome = Console.ReadLine(); //recebe a resposta do utilizador.
            fich.Write("Nome: "+ aluno.Nome+ " ;"+ " "); //escreve no ficheiro.
            Console.Write("Apelido: "); //solicita ao utilizador.
            aluno.Apelido = Console.ReadLine(); //recebe a resposta do utilizador.
            fich.Write("Apelido: "+ aluno.Apelido + " ;" + " "); //escreve no ficheiro.
            aluno.Idade =ValorValido("Idade: "); //recebe a resposta do utilizador.
            fich.WriteLine("Idade: "+ aluno.Idade + " ;"); //escreve no ficheiro.
            return aluno;
        }

        static void RemoverTurmas() //Subprograma para eliminar um ficheiro de uma turma.
        {
            Escola ficheiro, nficheiro; //declarar variaveis do tipo struct.
            ulong opção; //declara a variavel que é usada para o utilizador selecionar a opção que deseja.
            remover: //função de goto utilizada se o utilizador quiser remover mais uma turma.
            Console.Clear(); //Apaga a cmd.
            Console.WriteLine("Selecionou a opção Remover Turma"); //mensagem para o utilizador.
            Console.WriteLine("Qual a turma que deseja remover: "); //mensagem para o utilizador.
            nficheiro.Nome = Console.ReadLine();  //lê o nome da turma que vai ser dado ao nome do ficheiro.
            ficheiro.Turma = $"{nficheiro.Nome}.txt"; //recebe o nome da turma e insere como nome do ficheiro.
            File.Delete(ficheiro.Turma); //Apaga o ficheiro que tem o nome da turma que o utilizador inseriu.
            Console.WriteLine($"A turma {nficheiro.Nome} foi removida."); //mensagem para o utilizador.

            menu: //função de goto utilizada caso o utilizador selecione uma opção que não exista.
            Console.WriteLine("  ");
            Console.WriteLine("Escolha a opção que deseja fazer: "); //mensagem para o utilizador.
            Console.WriteLine("\n 1- Remover outra Turma \n 2- Menu inicial \n 3- Menu Turma \n 4- Sair");  //lista de opções apresentada ao utilizador.
            opção = ValorValido("\n Selecione a opção que deseja: "); //lê a variavel e leva até ao subprograma que vai verificar se o utilizador escreveu um numero sem letras.
            switch (opção) //switch com as opções da lista apresentada.
            {
                case 1:
                    goto remover; //função goto que volta para o inicio do subprograma caso o utilizador queira remover outra turma.
                case 2:
                    MainMenu(); //Chama o subprograma que volta ao menu principal.
                    break;
                case 3:
                    MenuTurmas(); //Chama o subprograma que volta ao menu de turmas.
                    break;
                case 4:
                    Environment.Exit(0); //fecha o programa.  
                    break;
                default:
                    Console.WriteLine("Essa opção não existe!"); //mensagem para o utilizador caso o mesmo selecione uma opção inexistente.
                    goto menu; //função goto para voltar ao menu das opções caso o utilizador selecione uma opção inexistente.

            }
        }
        static void VMTurmas() //Subprograma para demonstrar e modificar um ficheiro de uma turma.
        {
            Escola ficheiro, nficheiro; //declarar variaveis do tipo struct.
            ulong opção; //declara a variavel que é usada para o utilizador selecionar a opção que deseja.
            vm: //função de goto utilizada se o utilizador quiser ver mais uma turma.
            Console.Clear(); //Apaga o cmd.
            Console.WriteLine("Selecionou a opção Ver Turma"); //mensagem para o utilizador.
            Console.WriteLine("Qual a turma que deseja ver: "); //mensagem para o utilizador.
            nficheiro.Nome = Console.ReadLine(); //lê o nome da turma que vai ser dado ao nome do ficheiro.
            ficheiro.Turma = $"{nficheiro.Nome}.txt"; //recebe o nome da turma e insere como nome do ficheiro.
            String[] lines; //declarar variavel para armazenar as linhas do ficheiro.
            lines = File.ReadAllLines(ficheiro.Turma); //copia as linhas do ficheiro para a variavel.
            for (int i=0;i<lines.Length;i++) //ciclo for para mostrar as linhas do ficheiro ao utilizador.
            {
                Console.WriteLine(lines[i]); //mostra as linhas ao utilizador.
            }
            menu: //função de goto utilizada caso o utilizador selecione uma opção que não exista.
            Console.WriteLine("  ");
            Console.WriteLine("Escolha a opção que deseja fazer: "); //mensagem para o utilizador.
            Console.WriteLine("\n 1- Ver outra Turma \n 2- Menu inicial \n 3- Menu Turma \n 4- Sair"); //lista de opções apresentada ao utilizador.
            opção = ValorValido("\n Selecione a opção que deseja: "); //lê a variavel e leva até ao subprograma que vai verificar se o utilizador escreveu um numero sem letras.
            switch (opção) //switch com as opções da lista apresentada.
            {
                case 1:
                    goto vm; //função goto que volta para o inicio do subprograma caso o utilizador queira ver outra turma.
                case 2:
                    MainMenu(); //Chama o subprograma que volta ao menu principal.
                    break;
                case 3:
                    MenuTurmas(); //Chama o subprograma que volta ao menu de turmas.
                    break;
                case 4:
                    Environment.Exit(0); //fecha o programa.
                    break;
                default:
                    Console.WriteLine("Essa opção não existe!"); //mensagem para o utilizador caso o mesmo selecione uma opção inexistente.
                    goto menu; //função goto para voltar ao menu das opções caso o utilizador selecione uma opção inexistente.
            }
        }


        static void InformaçõesTurmas() //Subprograma que mostra as informações dos ficheiros das turmas.
        {
            Escola ficheiro, nficheiro; //declarar variaveis do tipo struct.
            ulong opção; //declara a variavel que é usada para o utilizador selecionar a opção que deseja.
            info: //função de goto utilizada se o utilizador quiser ver informações de outra turma.
            Console.Clear(); //Apaga cmd.
            Console.WriteLine("Selecionou a opção Informações da lista da Turma"); //mensagem para o utilizador.
            Console.WriteLine("Qual a turma que deseja ver as informações: "); //mensagem para o utilizador.
            nficheiro.Nome = Console.ReadLine(); //lê o nome da turma que vai ser dado ao nome do ficheiro.
            ficheiro.Turma = $"{nficheiro.Nome}.txt"; //recebe o nome da turma e insere como nome do ficheiro.

            if (File.Exists(ficheiro.Turma)) //Verificar a existência do ficheiro.
            {
                FileInfo informações = new FileInfo(ficheiro.Turma); //Informações do ficheiro. 

                Console.WriteLine($"\n Nome do ficheiro: {informações.Name}"); //Informações do ficheiro. 
                Console.WriteLine($"\n Data de criação: {informações.CreationTime}"); //Informações do ficheiro. 
                Console.WriteLine($"\n Tipo de ficheiro: {informações.Extension}"); //Informações do ficheiro. 
                Console.WriteLine($"\n Diretoria do ficheiro: {informações.Directory}"); //Informações do ficheiro. 
                Console.WriteLine($"\n Tamanho do ficheiro: {informações.Length} bytes"); //Informações do ficheiro. 
                Console.WriteLine($"\n Data de modificação: {informações.LastWriteTime}"); //Informações do ficheiro. 


            }
            else
            {
                Console.WriteLine("Turma não encontrada."); //mensagem para o utilizador.
            }
            menu: //função de goto utilizada caso o utilizador selecione uma opção que não exista.
            Console.WriteLine("  ");
            Console.WriteLine("Escolha a opção que deseja fazer: "); //mensagem para o utilizador.
            Console.WriteLine("\n 1- Informações de outra lista \n 2- Menu inicial \n 3- Menu Turma \n 4- Sair"); //mensagem para o utilizador.
            opção = ValorValido("\n Selecione a opção que deseja: "); //lê a variavel e leva até ao subprograma que vai verificar se o utilizador escreveu um numero sem letras.
            switch (opção) //switch com as opções da lista apresentada.
            {
                case 1:
                    goto info; //função goto para voltar ao inicio caso o utilizador selecione a opção Informações de outra lista.
                case 2:
                    MainMenu(); //Chama o subprograma do menu inicial.
                    break;
                case 3:
                    MenuTurmas(); //Chama o subprograma do menu das turmas.
                    break;
                case 4:
                    Environment.Exit(0); //Fecha o programa.
                    break;
                default:
                    Console.WriteLine("Essa opção não existe!"); //mensagem para o utilizador caso o mesmo selecione uma opção inexistente.
                    goto menu; //função goto para voltar ao menu das opções caso o utilizador selecione uma opção inexistente.
            }
        }
        static void MenuProfessores() //Subprograma para mostrar o menu de professores.
        {
            ulong opção; //declara a variavel que é usada para o utilizador selecionar a opção que deseja.
            menu: //função de goto utilizada caso o utilizador selecione uma opção que não exista.
            Console.Clear(); //Apaga o cmd.
            Console.WriteLine("Selecionou a opção Menu Professores"); //mensagem para o utilizador.
            Console.WriteLine("Escolha a opção do que deseja fazer:"); //mensagem para o utilizador.
            Console.WriteLine("\n 1- Admitir Professores \n 2- Ver/Despedir professores \n 3- Informações da lista dos Professores \n 4- Menu inicial"); //lista de opções apresentadas ao utilizador.
            opção = ValorValido("\n Selecione a opção que deseja: "); //Chama o método de verificação de dados inseridos.

            switch (opção) //switch com as opções da lista apresentada.
            {
                case 1:
                    AdmitirProfessores();   //Chama o método para criar o ficheiro professores.txt
                    break;
                case 2:
                    VMProfessores();    //Chama o método para mostrar a lista de professores do ficheiro professores.txt
                    break;
                case 3:
                    InformaçõesProfessores();   //Chama o método para mostrar as informações do ficheiro professores.txt
                    break;
                case 4:
                    MainMenu(); //Chama o subprograma do menu inicial.
                    break;
                default:
                    Console.WriteLine("Essa opção não existe!"); //mensagem para o utilizador caso o mesmo selecione uma opção inexistente.
                    goto menu; //função goto para voltar ao menu das opções caso o utilizador selecione uma opção inexistente.

            }
        }

        static void AdmitirProfessores() //Subprograma para criar ficheiros com os dados dos professores.
        {
            Professores ficheiro,TAM; //declarar variaveis do tipo struct.
            ulong opção; //declara a variavel que é usada para o utilizador selecionar a opção que deseja.
            admitir:  //função de goto utilizada se o utilizador quiser adimitir mais professores.
            Console.Clear(); //Apaga a cmd.
            Console.WriteLine("Selecionou a opção Admitir Professores"); //mensagem para o utilizador.                   
            TAM.NumProfessores = ValorValido("Quantos professores quer admitir: ");  //Chama o método de verificação de dados inseridos.
            Professores[] professores = new Professores[TAM.NumProfessores]; //Cria vetor para armazenar os dados.
            for (ulong i = 0; i < TAM.NumProfessores; i++) //ciclo for que cria os ficheiros
            {
                Console.WriteLine($"Detalhes do Professor:"); //mensagem para o utilizador.
                ficheiro.Professor = $"Professor{i+1}.txt"; //Cria um ficheiro.
                FileStream ficheiros = new FileStream(ficheiro.Professor, FileMode.OpenOrCreate, FileAccess.Write); //acede ou cria o ficheiro caso não exista e dá acesso para escrever no ficheiro.
                StreamWriter escritor = new StreamWriter(ficheiros); //cria variavel que serve para escrever dentro do ficheiro.
                professores[i] = LerDetalhesProfessor(escritor); //Chama o subprograma que vai ler os dados de cada professor.

                Console.WriteLine();
                escritor.Close(); //fecha o ficheiro.
                ficheiros.Close(); //fecha o ficheiro.
            }

            Console.WriteLine();
                      
            menu: //função de goto utilizada caso o utilizador selecione uma opção que não exista.
            Console.WriteLine("  ");
            Console.WriteLine("Escolha a opção que deseja fazer: "); //mensagem para o utilizador.
            Console.WriteLine("\n 1- Admitir mais professores \n 2- Menu inicial \n 3- Menu Professores \n 4- Sair"); //lista de opções apresentadas ao utilizador.
            opção = ValorValido("\n Selecione a opção que deseja: "); //lê a variavel e leva até ao subprograma que vai verificar se o utilizador escreveu um numero sem letras.
            switch (opção) //switch com as opções da lista apresentada.
            {
                case 1:
                    goto admitir; //função goto para voltar ao inicio caso o utilizador selecione a opção Admitir mais professores.                   
                case 2:
                    MainMenu(); //Chama o subprograma do menu inicial.
                    break;
                case 3:
                    MenuProfessores(); //Chama o subprograma do menu dos professores.
                    break;
                case 4:
                    Environment.Exit(0); //Fecha o programa.
                    break;
                default:
                    Console.WriteLine("Essa opção não existe!"); //mensagem para o utilizador caso o mesmo selecione uma opção inexistente.
                    goto menu; //função goto para voltar ao menu das opções caso o utilizador selecione uma opção inexistente.

            }

        }

        static Professores LerDetalhesProfessor(StreamWriter fich)
        {
            Professores professor = new Professores();
            Console.Write("Nome: "); //solicita ao utilizador.
            professor.Nome = Console.ReadLine(); //recebe a resposta do utilizador.
            fich.Write("Nome: " + professor.Nome + " ;" + " "); //escreve no ficheiro a resposta.
            Console.Write("Apelido: "); //solicita ao utilizador.
            professor.Apelido = Console.ReadLine(); //recebe a resposta do utilizador.
            fich.Write("Apelido: " + professor.Apelido + " ;" + " "); //escreve no ficheiro a resposta.         
            professor.Idade = ValorValido("Idade: "); //recebe a resposta do utilizador.
            fich.Write("Idade: " + professor.Idade + " ;"); //escreve no ficheiro a resposta.
            Console.Write("Disciplina: "); //solicita ao utilizador.
            professor.Disciplina = Console.ReadLine(); //recebe a resposta do utilizador.
            fich.Write("Disciplina: " + professor.Disciplina + " ;" + " "); //escreve no ficheiro a resposta.
            return professor;
        }

        static void DespedirProfessores()
        {
            Professores ficheiro, nficheiro; //declarar variaveis do tipo struct.
            ulong opção; //declara a variavel que é usada para o utilizador selecionar a opção que deseja.
            despedir: //função de goto utilizada se o utilizador quiser despedir mais professores.
            Console.WriteLine("Selecionou a opção Despedir Professor"); //mensagem para o utilizador.
            nficheiro.numero = ValorValido("Qual o numero do professor que quer despedir: "); //lê a variavel e leva até ao subprograma que vai verificar se o utilizador escreveu um numero sem letras e positivo.
            ficheiro.Professor = ($"Professor{nficheiro.numero}.txt");  //recebe o numero do professor para despedir e dá ao nome do ficheiro.
            File.Delete(ficheiro.Professor); //Apaga o ficheiro com o numero do professor escolhido.
            Console.WriteLine($"O professor foi despedido."); //mensagem para o utilizador.

            menu: //função de goto utilizada caso o utilizador selecione uma opção que não exista.
            Console.WriteLine("  ");
            Console.WriteLine("\nEscolha a opção que deseja fazer: ");//mensagem para o utilizador.
            Console.WriteLine("\n 1- Despedir outro professor \n 2- Menu inicial \n 3- Menu Professores \n 4- Sair"); //lista de opções apresentadas ao utilizador.
            opção = ValorValido("\n Selecione a opção que deseja: "); //lê a variavel e leva até ao subprograma que vai verificar se o utilizador escreveu um numero sem letras.
            switch (opção) //switch com as opções da lista apresentada.
            {
                case 1:
                    goto despedir; //função goto para voltar ao inicio caso o utilizador selecione a opção despedir mais professores.
                case 2:
                    MainMenu(); //Chama o subprograma do menu inicial.
                    break;
                case 3:
                    MenuProfessores(); //Chama o subprograma do menu dos professores.
                    break;
                case 4:
                    Environment.Exit(0); //fecha o programa.
                    break;
                default:
                    Console.WriteLine("Essa opção não existe!"); //mensagem para o utilizador.
                    goto menu; //função goto para voltarao menu das opções caso o utilizador selecione uma opção inexistente.

            }
        }

        static void VMProfessores()
        {
            ulong opção ,s=0; //declarar variaveis.
            Console.Clear(); //Apaga o cmd.
            Console.WriteLine("Selecionou a opção Ver lista de professores"); //mensagem para o utilizador.
            for (ulong m=1; m<100;m++) //ciclo for para verificar quantos ficheiros de professores existem.
            {
                if (File.Exists($"Professor{m}.txt")) //verifica se os ficheiros existem e adiciona mais um á variavel S cada vez que um ficheiro exista.
                {
                    s++;
                }
            }
            for (ulong l = 1; l-1 < s; l++) //ciclo for para apresentar os conteudos de cada ficheiro.
            {
              numcerto: //goto utilizado para sempre que exista alguma falha na contagem ex.: 2,4,5; quando passar no 3 passa á frente e vai para o 4.
                if (File.Exists($"Professor{l}.txt")) //verifica se o numero do ficheiro existe ou não.
                {
                    String[] lines; // variavel linhas usada para ler as linhas do ficheiro.
                    lines = File.ReadAllLines($"Professor{l}.txt"); //passa o conteudo do ficheiro para a variavel linhas.
                    Console.WriteLine($"Num. Professor: {l} ; " + lines[0]); //apresenta os conteudos dos ficheiros.
                }
                else
                {
                    l++; //adiciona mais um caso exista falha na contagem.
                    goto numcerto; //goto caso exist falha na contagem.
                }
            }
            menu: //função de goto utilizada caso o utilizador selecione uma opção que não exista.
            Console.WriteLine("  ");
            Console.WriteLine("Escolha a opção que deseja fazer: "); //mensagem para o utilizador.
            Console.WriteLine("\n 1- Despedir Professor \n 2- Menu inicial \n 3- Menu Professores \n 4- Sair"); //lista de opções apresentada ao utilizador.
            opção = ValorValido("\n Selecione a opção que deseja: "); //lê a variavel e leva até ao subprograma que vai verificar se o utilizador escreveu um numero sem letras.
            switch (opção) //switch com as opções da lista apresentada.
            {
                case 1:
                    DespedirProfessores();  //Chama o método para remover o ficheiro professores.txt
                    break;
                case 2:
                    MainMenu(); //Chama o subprograma do menu inicial.
                    break;
                case 3:
                    MenuProfessores(); //Chama o subprograma do menu dos professores.
                    break;
                case 4:
                    Environment.Exit(0); //fecha o programa.
                    break;
                default:
                    Console.WriteLine("Essa opção não existe!"); //mensagem para o utilizador.
                    goto menu; //função goto utilizada caso o utilizador selecione uma opção inexistente.
            }
        }
        
        static void InformaçõesProfessores() //Subprograma para dar as informações sobre os ficheiros dos professores.
        {
            ulong opção,s=0; //declara variaveis.
            Console.Clear(); //Apaga o cmd.
            Console.WriteLine("Selecionou a opção Informações da lista dos Professores"); //mensagem para o utilizador.
            for (ulong m = 1; m < 100; m++) //ciclo for para verificar quantos ficheiros de professores existem.
            {
                if (File.Exists($"Professor{m}.txt")) //verifica se os ficheiros existem e adiciona mais um á variavel S cada vez que um ficheiro exista.
                {
                    s++;
                }
            }
            for (ulong l = 1; l - 1 < s; l++) //ciclo for para apresentar os conteudos de cada ficheiro.
            {
            numcerto: //goto utilizado para sempre que exista alguma falha na contagem ex.: 2,4,5; quando passar no 3 passa á frente e vai para o 4.
                if (File.Exists($"Professor{l}.txt")) //verifica se o numero do ficheiro existe ou não.
                {
                    FileInfo informações = new FileInfo($"Professor{l}.txt"); //Informações do ficheiro. 

                    Console.WriteLine($"\n Nome do ficheiro: {informações.Name}"); //Informações do ficheiro. 
                    Console.WriteLine($"\n Data de criação: {informações.CreationTime}"); //Informações do ficheiro. 
                    Console.WriteLine($"\n Tipo de ficheiro: {informações.Extension}"); //Informações do ficheiro. 
                    Console.WriteLine($"\n Diretoria do ficheiro: {informações.Directory}"); //Informações do ficheiro. 
                    Console.WriteLine($"\n Tamanho do ficheiro: {informações.Length} bytes"); //Informações do ficheiro. 
                    Console.WriteLine($"\n Data de modificação: {informações.LastWriteTime}"); //Informações do ficheiro. 
                }
                else
                {
                    l++; //adiciona mais um caso exista falha na contagem.
                    goto numcerto; //goto caso exist falha na contagem.
                }
            }
            menu: //função de goto utilizada caso o utilizador selecione uma opção que não exista.
            Console.WriteLine("  ");
            Console.WriteLine("Escolha a opção que deseja fazer: ");
            Console.WriteLine("\n 1- Menu inicial \n 2- Menu Professores \n 3- Sair");
            opção = ValorValido("\n Selecione a opção que deseja: "); //lê a variavel e leva até ao subprograma que vai verificar se o utilizador escreveu um numero sem letras.
            switch (opção) //switch com as opções da lista apresentada.
            {
                case 1:
                    MainMenu(); //Chama o subprograma para voltar ao menu inicial.
                    break;
                case 2:
                    MenuProfessores(); //Chama o subprograma para voltar ao menu dos professores.
                    break;
                case 3:
                    Environment.Exit(0); //fecha o programa.
                    break;
                default:
                    Console.WriteLine("Essa opção não existe!"); //mensagem para o utilizador.
                   goto menu; //função goto utilizada caso o utilizador selecione uma opção inexistente volta a questionar qual a opção.
            }
        }


    }
}
