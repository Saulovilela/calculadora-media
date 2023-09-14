using System;
using System.Threading;
using System.Globalization; //vai usar o culture info que converte numeros com . em ,

namespace CalculadoraMedia

{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Carregando...");
            Console.WriteLine(@"

 #####     ##                ##       ####     ##     #####    #######  ##   ##  ##  ##
##   ##   ####              ####     ##  ##   ####     ## ##    ##   #  ### ###  ##  ##
##   ##  ##  ##            ##  ##   ##       ##  ##    ##  ##   ## #    #######  ##  ##
##   ##  ##  ##            ##  ##   ##       ##  ##    ##  ##   ####    #######   ####
##   ##  ######            ######   ##       ######    ##  ##   ## #    ## # ##    ##
##  ###  ##  ##            ##  ##    ##  ##  ##  ##    ## ##    ##   #  ##   ##    ##
 #####   ##  ##            ##  ##     ####   ##  ##   #####    #######  ##   ##   ####
    ###
"
            );

            for (int i = 0; i < 10; i++) //gerará os pontinhos abaixo no caso 10
            {
                Console.Write("."); //escreve os pontinhos da pagina
                Thread.Sleep(300); //pausa de 0.3 milisegundos
            }

            Console.WriteLine("\nCarregamento concluído!");

            Console.WriteLine("Bem vindo ao calculador de notas da QA Academy");

            ////////
            string nome;
            int idade;
            double nota1, nota2, nota3;
            double resultado; //pois vai transformar qualquer numero em decimal

            //função para validação de contem numeros
            static bool ContemNumeros(string texto)
            {
                foreach (char caractere in texto)
                {
                    if (char.IsDigit(caractere))
                    {
                        return true;
                    }
                }
                return false;
            }


            while (true) // Loop para continuar pedindo até que o nome seja válido
            {
                Console.WriteLine("Por favor, digite seu nome");

                nome = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.WriteLine("Nome inválido. Por favor, digite um nome válido.");
                }
                else if (ContemNumeros(nome))
                {
                    Console.WriteLine("Numeros não serão aceitos");
                }
                else if (nome.Length > 30)
                {
                    Console.WriteLine("Nome muito longo. Por favor, digite um nome com no máximo 30 caracteres.");
                }
                else
                {
                    break;
                }
            }

            ///////
            while (true) // Loop para continuar pedindo até que a idade seja válida
            {
                Console.WriteLine("Digite sua idade");

                if (!int.TryParse(Console.ReadLine(), out idade))
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número válido.");
                }
                else if (idade < 0) //se a idade for menor de 0 ano não será validada
                {
                    Console.WriteLine("Idade inválida. A idade não pode ser negativa.");
                }
                else if (idade == 0) // se a idade for zero vai falar isso
                {
                    Console.WriteLine("Você tem zero anos e já sabe programar? Você é um bixão mesmo hein");
                }
                else if (idade > 120) //se idade for menor de 120 anos vai executar a mensagem abaixo
                {
                    Console.WriteLine("Idade tem que ser menor de 120 anos.");
                }
                else
                {
                    break; // Idade válida, sair do loop
                }
            }

            ////////colocação da extrutura do while com um looping para digitação de nota incorreta nao quebrar o projeto

            do
            {
                Console.WriteLine("Digite a primeira nota");
                if (!double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out nota1)) //if (!double.TryParse(Console.ReadLine(), out nota1)): Lê a entrada do usuário usando Console.ReadLine()
                {                                                                                                    //tenta convertê-la em um número decimal usando double.TryParse(), Se a conversão falhar executa o bloco de baixo
                    Console.WriteLine("Entrada inválida. Por favor, digite um número válido.");
                }
                else if (nota1 < 0 || nota1 > 10) //Se a conversão for bem-sucedida, verifica se a nota está fora do intervalo válido (0 a 10).
                {
                    Console.WriteLine("Nota inválida. Digite um valor entre 0 e 10.");
                }
                else // Se a nota inserida for um número válido e estiver dentro do intervalo válido
                {
                    break; /// Nota válida, sair do loop
                }
            } while (true); /// Continuar pedindo até que uma nota válida seja inserida


            do
            {
                Console.WriteLine("Digite a segunda nota");
                if (!double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out nota2)) //se nao for um numero double 
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número válido.");
                }
                else if (nota2 < 0 || nota2 > 10)
                {
                    Console.WriteLine("Nota inválida. Digite um valor entre 0 e 10.");
                }
                else
                {
                    break; // Nota válida, sair do loop
                }
            } while (true); // Continuar pedindo até que uma nota válida seja inserida


            do
            {
                Console.WriteLine("Digite a terceira nota");
                if (!double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out nota3))
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número válido.");
                }
                else if (nota3 < 0 || nota3 > 10)
                {
                    Console.WriteLine("Nota inválida. Digite um valor entre 0 e 10.");
                }
                else
                {
                    break;
                }
            } while (true);


            resultado = (nota1 + nota2 + nota3) / 3;

            int resultadoArredondado = (int)Math.Round(resultado, MidpointRounding.AwayFromZero); //Math.Round é usado para arredondar um número decimal,
                                                                                                  //MidpointRounding.AwayFromZero significa que os valores no ponto médio serão arredondados

            if (resultadoArredondado >= 6)
            {
                Console.WriteLine($"Sua idade é {idade}. Você foi aprovado {nome}, meus parabéns pelo resultado de {resultadoArredondado}");
            }
            else
            {
                Console.WriteLine($"{nome} Você têm {idade} anos e infelizmente não passou. Estude mais porque sua nota foi {resultadoArredondado}");
            }

            if (resultado >= 0 && resultado <= 10)
            {
                Console.WriteLine($"Seu resultado é {resultadoArredondado}");
            }
            else
            {
                Console.WriteLine("Resultado inválido");
            }

            Console.WriteLine(@"

 ##   ##    ####            #####     ####      ####    ####    ######     ##     ####
 ##   ##   ##  ##            ## ##     ##      ##  ##    ##     # ## #    ####     ##
 ##   ##  ##                 ##  ##    ##     ##         ##       ##     ##  ##    ##
 #######  ##                 ##  ##    ##     ##         ##       ##     ##  ##    ##
 ##   ##  ##  ###            ##  ##    ##     ##  ###    ##       ##     ######    ##   #
 ##   ##   ##  ##            ## ##     ##      ##  ##    ##       ##     ##  ##    ##  ##
 ##   ##    #####           #####     ####      #####   ####     ####    ##  ##   #######

"
            );
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();

        }
    }
}