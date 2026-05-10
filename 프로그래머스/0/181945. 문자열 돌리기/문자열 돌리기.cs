using System;

public class Example
{
    public static void Main()
    {
        String s;

        Console.Clear();
        s = Console.ReadLine();

        foreach(char l in s)
        {
            Console.WriteLine(l);
        }
    }
}