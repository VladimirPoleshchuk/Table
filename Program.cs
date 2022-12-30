// See https://aka.ms/new-console-template for more information
StartTable();

static void StartTable()
{
    Console.WriteLine("Давайте начертим таблицу с текстом и двумя рисуенками.");
    Console.WriteLine("Нам потебуется произвольный текст и размерность таблици.");

    int size = GetSize();

    string text = GetText();

    string border = GetBorder(size, text);

    string[] textLine = GetLineText(text, size, border, out int lineHeight);

    string[] gridLine = GetGrid(border, lineHeight);

    string[] crossLine = GetCross(border);

    Console.WriteLine("Выберете в какой последовательности построить таблицу.");
    Console.WriteLine("Текст цифра: 1, Сетка: 2, Крест: 3.");
    Console.WriteLine("Вводите поочередно необходимые числа. ");

    int[] numbers = new int[3];
    int i = 0;
    bool isNumbers3 = false;
    bool isNumbers2 = false;
    bool isNumbers1 = false;

    while (true)
    {
        Console.Write("Введите число:");

        string sequence = Console.ReadLine();

        int number = 4;

        if (string.IsNullOrWhiteSpace(sequence) || !int.TryParse(sequence, out number))
        {
            Console.WriteLine("Вы ввели не корректные данные, попробуйте еще раз:");
        }
        else
        {
            switch (number)
            {
                case 1 when numbers[i] != 1 && !isNumbers1:
                    {
                        numbers[i] += number;
                        Print(i);
                        i++;
                        isNumbers1 = true;
                        break;
                    }
                case 2 when numbers[i] != 2 && !isNumbers2:
                    {
                        numbers[i] += number;
                        Print(i);
                        i++;
                        isNumbers2 = true;
                        break;
                    }
                case 3 when numbers[i] != 3 && !isNumbers3:
                    {
                        numbers[i] += number;
                        Print(i);
                        i++;
                        isNumbers3 = true;
                        break;
                    }
                default:
                    {
                        Print(number);
                        break;
                    }
            }

            static void Print(int count)
            {
                switch (count)
                {
                    case 0:
                        {
                            Console.WriteLine("Вы ввели первое число!");
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine("Вы ввели второе число!");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Вы ввели последнее число!");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Введите цифры от 1 до 3:");
                            break;
                        }
                }
            }

            if (i == 3)
            {
                break;
            }
        }
    }

    int k = 0;

    Console.WriteLine(border);

    do
    {
        switch (numbers[k])
        {
            case 1:
                {
                    foreach (var item in textLine)
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine(border);
                    break;
                }
            case 2:
                {
                    foreach (var item in gridLine)
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine(border);
                    break;
                }
            case 3:
                {
                    foreach (var item in crossLine)
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine(border);
                    break;
                }
        }

        k++;

    } while (k < 3);
}

static string[] GetCross(string border)
{
    string lineCross = "";

    string[] arrayLineCross = new string[border.Length - 2];

    int borderHalfLength;

    if (border.Length % 2 == 0)
    {
        borderHalfLength = border.Length / 2;
    }
    else
    {
        borderHalfLength = (border.Length / 2) + 1;
    }

    for (int i = 0, j = 2; i < borderHalfLength - 1; i++, j += 2)
    {
        if (i == 0)
        {
            lineCross += "++" + new string(' ', border.Length - 4) + "++";
        }
        else if (border.Length % 2 != 0 && arrayLineCross.Length / 2 == i)
        {
            lineCross += "+" + new string(' ', border.Length - 3 - i) + "+" + new string(' ', border.Length - 3 - i) + "+";

            arrayLineCross[i] += lineCross;
            break;
        }
        else
        {
            lineCross += "+" + new string(' ', i) + "+" + new string(' ', border.Length - 2 - j) + "+" + new string(' ', i) + "+";
        }

        arrayLineCross[i] += lineCross;
        arrayLineCross[arrayLineCross.Length - 1 - i] += lineCross;
        lineCross = "";
    }

    return arrayLineCross;
}

static string[] GetGrid(string border, int lineHeight)
{
    int gridHeight = lineHeight;

    string lineGrid = "";
    string lineGrid1 = "";
    string lineGrid2 = "";

    string[] arrayLineGrid = new string[gridHeight];

    for (int j = 0; j < border.Length - 2; j++)
    {
        lineGrid1 += j % 2 == 0 ? " " : "+";

        lineGrid2 += j % 2 == 0 ? "+" : " ";
    }

    for (int i = 0; i < gridHeight; i++)
    {
        lineGrid = i % 2 == 0 ? lineGrid1 : lineGrid2;

        arrayLineGrid[i] += "+" + lineGrid + "+";
    }

    return arrayLineGrid;
}

static string[] GetLineText(string text, int size, string border, out int lineHeight)
{
    int coutLine = 0;
    int padding = size - 1;
    int substringLength = text.Length;
    int lineLength = border.Length - 2 * (padding + 1);

    while (true)
    {
        if (substringLength > lineLength)
        {
            substringLength -= lineLength;
            coutLine++;
            continue;
        }

        coutLine++;

        break;
    }

    string lineText = "";
    string[] arrayLineText = new string[2 * padding + coutLine];
    lineHeight = arrayLineText.Length;

    for (int i = 0; i < lineHeight; i++)
    {
        if (i >= padding && coutLine > 0)
        {
            if (text.Length <= lineLength)
            {
                lineText = "+" + new string(' ', padding) + text + new string(' ', padding) + "+";

                coutLine--;
            }
            else
            {
                string words = "";
                int k = 0;

                for (int j = 0; j < text.Length; j++)
                {
                    if (k <= lineLength)
                    {
                        words += text[j];
                        k++;
                    }

                    if (k - 1 == lineLength)
                    {
                        arrayLineText[i] = "+" + new string(' ', padding) + words + new string(' ', padding - 1) + "+";

                        k = 0;
                        i++;
                        words = "";
                        coutLine--;
                    }
                }

                arrayLineText[i] = "+" + new string(' ', padding) + words + new string(' ', padding + lineLength - words.Length) + "+";

                i++;
                coutLine--;
            }
        }
        else
        {
            lineText = "+" + new string(' ', border.Length - 2) + "+";
        }

        arrayLineText[i] = lineText;
    }

    return arrayLineText;
}

static string GetBorder(int size, string text)
{
    int maxLine = 40;
    string line;
    int lineLength = 2 * size + text.Length;

    if (lineLength > maxLine)
    {
        line = new string('+', maxLine);
    }
    else
    {
        line = new string('+', lineLength);
    }

    return line;
}

static string GetText()
{
    Console.WriteLine("Введите произвольный текст:");

    while (true)
    {
        string? text = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(text))
        {
            Console.WriteLine("Вы ввели не корректную строку, попробуйте снова:");
        }
        else
        {
            return text;
        }
    }
}

static int GetSize()
{
    Console.Write("Введите размерность таблицы: ");

    while (true)
    {
        if (!Int32.TryParse(Console.ReadLine(), out int size))
        {
            Console.Write("Вы ввели не корректные данные, попробуйте еще раз :");
        }
        else if (size < 1 || size > 6)
        {
            Console.Write("Вы ввели не корректное число, введите число от 1 до 6: ");
        }
        else
        {
            return size;
        }
    }
}
