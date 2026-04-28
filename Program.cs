using System;
string ReadNonEmpty(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        var input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) return input.Trim();
        Console.WriteLine("please enter something");
            
        }
    }
double ReadMark(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        var input = Console.ReadLine();
        if (double.TryParse(input, out var mark))
        {
            if (mark < 0)
            {
                Console.WriteLine("mark can not be negative");
                continue;
            }
            return mark;
        }
        Console.WriteLine("enter a number");
    }
}

var studentName = ReadNonEmpty("student name:  ");
var mark1 = ReadMark("subject 1 mark: ");
var mark2 = ReadMark("subject 2 mark: ");
var mark3 = ReadMark("subject 3 mark: ");

var total = mark1 + mark2 + mark3;
var average = total / 3;

//pass if average is 50 or more
var result = average >= 50 ? "PASS" : "FAIL";

Console.WriteLine(); Console.WriteLine("Name: " + studentName);
Console.WriteLine("Marks" + mark1 + "," + mark2 + "," + mark3);
Console.WriteLine("Total: " + total);
Console.WriteLine("Average: " + average.ToString("F2"));
Console.WriteLine("Result: " + result);

Console.WriteLine();
Console.WriteLine("done,press any key");
Console.ReadKey(true);