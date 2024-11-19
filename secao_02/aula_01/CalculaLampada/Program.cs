// Entrada de dados
Console.WriteLine("Boas vindas ao programa 'Calcula Lâmapada'");
Console.WriteLine("Informe o nome do cômodo: ");
string convenient = Console.ReadLine();

Console.WriteLine("Informe em metros a largura do cômodo: Ex. 2.5 ");
decimal width = decimal.Parse(Console.ReadLine());

Console.WriteLine("Informe em metros o comprimento do cômodo: Ex. 10.0 ");
decimal length = decimal.Parse(Console.ReadLine());

Console.WriteLine("Informe a potência em watts da lâmpada que será utilizada: ");
int power = int.Parse(Console.ReadLine());

// Processamento
decimal squareMeter = width * length;
decimal quotientX = power / 18M;
decimal totalLightBulbs = squareMeter / quotientX;

// Saida de dados
Console.WriteLine("Para iluminar o cômodo: " + convenient + " com " + squareMeter.ToString("N2") + "metros quadrados" + "será necessário a instalação de " + totalLightBulbs.ToString("N2") + "lâmpada(s)");

