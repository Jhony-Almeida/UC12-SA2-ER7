// See https://aka.ms/new-console-template for more information

//Console.Clear();
//Console.WriteLine("Hello, World!");
//Console.WriteLine("Turma13");

using ProgBackEnd.Classes;


Console.Clear();

Utils.BarraCarregamento("iniciando", 3, ".");

List<PessoaFisica> listaPf = new List<PessoaFisica>();
List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

string? opcao;

do
{   
    Console.Clear();
    Console.WriteLine(@$"
    
    ==================================================
    |         Bem-Vindo ao Sistema de Cadastro       |
    |           de Pessoa Física ou Juridica         |
    ==================================================
    |        Digite o número da opção desejada       |
    ==================================================
    |                                                |
    |               1-Pessoa Física                  |
    |               2-Pessoa Juridica                |
    |                                                |
    |               0-Sair                           |
    ==================================================
");


opcao = Console.ReadLine();
Thread.Sleep(1000);

        switch (opcao)
        {
            case "1":

                    PessoaFisica metodoPf = new PessoaFisica();


                    string? opcaoPf;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine(@$"
    

    ==================================================
    |        Digite o número da opção desejada       |
    ==================================================
    |                                                |
    |            1-Cadastrar Pessoa Fisica           |
    |            2-Mostrar Pessoas Fisicas           |
    |                                                |
    |            0-Voltar ao menu anterior           | 
    ==================================================
");
                
                     opcaoPf = Console.ReadLine();
            
                   switch (opcaoPf)
                   {
                    case "1":
                        Console.Clear();
                        PessoaFisica novaPf = new PessoaFisica();
                        Endereco novaEndPF = new Endereco();
                        
                        Console.WriteLine($"Digite o nome da pessoa fisica que deseja cadastrar:");
                        novaPf.nome = Console.ReadLine();
           
                        bool dataValida;
                        do
                        {
                            Console.WriteLine($"Digite a data de nascimento:");
                            string? dataNasc = Console.ReadLine();
                            
                            dataValida = metodoPf.ValidarDataNasc(dataNasc);

                            if (dataValida)
                            {
                                novaPf.dataNasc = dataNasc;
                            }
                            else{
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"Data digitada invalida, por favor digite uma outra data");
                                Console.ResetColor();
                            }

                        } while (dataValida == false); 

                        Console.WriteLine($"Digite o número do cpf:");
                        novaPf.cpf = Console.ReadLine();

                        Console.WriteLine($"Digite o rendimento mensal (apenas números):");
                        novaPf.rendimento = float.Parse(Console.ReadLine());
                        
                        Console.WriteLine($"Digita o logradouro:");
                        novaEndPF.logradouro = Console.ReadLine();
                       
                        Console.WriteLine($"Digite o número:");
                        novaEndPF.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento (aperte ENTER para vazio):");
                        novaEndPF.complemento = Console.ReadLine();

                        Console.WriteLine($"Esse endereço é comercial? S ou N");
                        string endCom = Console.ReadLine().ToUpper();
                        if (endCom == "S")
                        {
                            novaEndPF.endComercial = true;
                        }else{
                            novaEndPF.endComercial = false;
                        }

                        novaPf.endereco = novaEndPF;
                        listaPf.Add(novaPf);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastro Realizado com sucesso!!!");
                        Thread.Sleep(3000);
                        Console.ResetColor();

                        break;
                    case "2":
                        if (listaPf.Count > 0)
                        {
                            foreach (PessoaFisica cadaPessoa in listaPf)
                            {
                                Console.WriteLine(@$"
                                Nome: {cadaPessoa.nome}
                                Data de Nascimento: {cadaPessoa.dataNasc}
                                CPF: {cadaPessoa.cpf}
                                Rendimento: {cadaPessoa.rendimento.ToString("C")}
                                Logradouro: {cadaPessoa.endereco.logradouro}
                                Número: {cadaPessoa.endereco.numero}
                                Complemento: {cadaPessoa.endereco.complemento}
                                Endereço Comercial? {((bool)(cadaPessoa.endereco.endComercial)?"Sim":"Não")}
                                Taxa de Imposto a ser paga: {cadaPessoa.CalcularImposto(cadaPessoa.rendimento).ToString("C")}
                                ");
                                
                            }
                            Console.WriteLine($"Apaerte 'Enter' para continuar...");
                            Console.ReadLine();
                            

                        }else{
                            Console.WriteLine($"Lista Vazia");
                            Thread.Sleep(3000);
                        }
                        break;
                    case "0":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção invalida, por favor digite outra opção");
                        Thread.Sleep(3000);
                        break;
                   }
                   
                    } while (opcaoPf != "0");
                break;

            case "2":

                    PessoaJuridica novaPj = new PessoaJuridica();

                    string? opcaoPj;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine(@$"

    ==================================================
    |        Digite o número da opção desejada       |
    ==================================================
    |                                                |
    |            1-Cadastrar Pessoa Juridica         |
    |            2-Mostrar Pessoas Juridica          |
    |                                                |
    |            0-Voltar ao menu anterior           | 
    ==================================================
");
                
                    opcaoPj = Console.ReadLine();
                    switch (opcaoPj)
                    {
                        case "1":
                            Console.Clear();
                            Endereco novaEndPj = new Endereco();
                         
                        Console.WriteLine($"Digite cnpj:");
                        novaPj.cnpj = Console.ReadLine();

                        Console.WriteLine($"Digite o logradouro:");
                        novaEndPj.logradouro = Console.ReadLine();
                       
                        Console.WriteLine($"Digite o numero:");
                        novaEndPj.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemetento (Aperte ENTER para vazio)");
                        novaEndPj.complemento = Console.ReadLine();
  
                        listaPj.Add(novaPj);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastro Realizado com sucesso!!!");
                        Thread.Sleep(3000);
                        Console.ResetColor();
                        
                        novaEndPj.endComercial = true;
                        novaPj.endereco = novaEndPj;

                            break;
                        case "2":

                        float impostoPagar = novaPj.CalcularImposto(12000.5f);

                        Console.WriteLine(@$"
                
                        CNPJ: {novaPj.cnpj}
                        Valido: {novaPj.ValidarCnpj(novaPj.cnpj)}  
                        Impsoto: {impostoPagar.ToString("C")}
                        
                        ");
                        Console.WriteLine($"Para continuar, aperte a tecla ENTER");
                        Console.ReadLine();
                            break;
                        default:
                        Console.Clear();
                        Console.WriteLine($"Opção invalida, por favor digite outra opção");
                        Thread.Sleep(3000);
                            break;
                    }
                    
                    } while (opcaoPj != "0");

                break;

            case "0":

                Console.WriteLine($"Obrigado por utilizar nosso sistema");
                
                break;

            default:

            Console.WriteLine("Opção invalida, digite um valor disponivel");
            Console.WriteLine($"Para continuar, aperte a tecla ENTER");
            Console.ReadLine();
            
                break;
        }

} while (opcao != "0");

Utils.BarraCarregamento("Finalizando", 9, ".");