using System;

public class Example
{
    public static void Main()
    {
        String s;

        Console.Clear();
        s = Console.ReadLine();
        
        foreach(char c in s)
        {
            if(c >= 'A' && c <= 'Z')
                Console.Write((char)(c + 32));
            else
                Console.Write((char)(c - 32));
        }

//         if (char.IsUpper(c))
//     Console.Write(char.ToLower(c));
// else
//     Console.Write(char.ToUpper(c));
    }
}