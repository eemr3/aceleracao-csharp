//Adição
int a = 50, b = 50;
int result1 = a + b;
Console.WriteLine(a + " + " + b + " = " + result1);

//Subtração
int c = 77, d = 21;
int result2 = c - d;
Console.WriteLine(c + " - " + d + " = " + result2);

//Multiplicação
int e = 5, f = 5;
int result3 = e * f;
Console.WriteLine(e + " * " + f + " = " + result3);

//divisão
int g = 90, h = 9;
int result4 = g / h;
Console.WriteLine(g + " / " + h + " = " + result4);

//módulo
int i = 36, j = 7;
int result5 = i % j;
Console.WriteLine("O resto da divisão de " + i + " por " + j + " é " + result5);

Console.WriteLine("");
Console.WriteLine("Ordem de execução (prescedencia)");
//ordem de execução
int aE = 5, bE = 10, cE = 15;
int result1E = aE + bE * cE;
Console.WriteLine(aE + " + " + bE + " * " + cE + " = " + +result1E);

//utilizando parênteses
int result2E = (aE + bE) * cE;
Console.WriteLine("(" + aE + " + " + bE + ") * " + cE + " = " + result2E);