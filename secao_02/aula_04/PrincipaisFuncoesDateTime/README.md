Pergunta🧐: E se eu quiser adicionar especificamente e de forma mais legível uma quantidade de anos, meses, dias, horas, minutos, segundos ou até mesmo milissegundos?

Resposta🤩: A DateTime possui diversas métodos Add para valores específicos. Olha só:

- `AddYears(int value)`: Adiciona uma quantidade de anos a uma data.
- `AddMonths(int value)`: Adiciona uma quantidade de meses a uma data.
- `AddDays(double value)`: Adiciona uma quantidade de dias a uma data.
- `AddHours(double value)`: Adiciona uma quantidade de horas a uma data.
- `AddMinutes(double value)`: Adiciona uma quantidade de minutos a uma data.
- `AddSeconds(double value)`: Adiciona uma quantidade de segundos a uma data.
- `AddMilliseconds(double value)`: Adiciona uma quantidade de milissegundos a uma data.

.Compare(DateTime t1, DateTime t2);

O método estático .Compare() recebe duas DateTime como parâmetro, compara e retorna um valor número que representa qual data é anterior ou posterior, seguindo o critério:

Retorno Significado

```bash
  -1 A data t1 é anterior à t2
```

```bash
  0	A data t1 é igual à t2
```

```bash
  1	A data t1 é posterior à t2
```

`.ToString()`

O método `.ToString()` converte o valor de um `DateTime` para uma string equivalente utilizando os critérios padrões do C# para tal.

- `.ToString(string? format)`

É possível passar por parâmetro um formato específico para a string de saída, vamos ver alguns:

Formatos padrão: O C# oferece os seguintes formatos `“d”, “D”, “f”, “F”, “g”, “G”, “m”, “o”, “R”, “s”, “t”, “T”, “u”, “U”, “y”`;

Vamos ver a seguinte data em cada um:

```bash
  new DateTime(2008, 6, 15, 21, 15, 07);
```

### Formato Saída

`“d”	6/15/2008`

`“D” Sunday, June 15, 2008`

`“f” Sunday, June 15, 2008 9:15 PM`

`“F” Sunday, June 15, 2008 9:15:07 PM`

`“g” 6/15/2008 9:15 PM`

`“G” 6/15/2008 9:15:07 PM`

`“m” June 15`

`“o” 2008-06-15T21:15:07.0000000`

`“R” Sun, 15 Jun 2008 21:15:07 GMT`

`“s” 2008-06-15T21:15:07`

`“t” 9:15 PM`

`“T” 9:15:07 PM`

`“u” 2008-06-15 21:15:07Z`

`“U” Monday, June 16, 2008 4:15:07 AM`

`“y” June, 2008`
