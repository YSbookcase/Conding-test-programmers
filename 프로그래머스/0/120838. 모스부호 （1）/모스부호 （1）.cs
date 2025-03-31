using System;

public class Solution {
    public string solution(string letter)    {
        string answer = "";
       

        string[] analysisWords = letter.Split(' ');
        string[] container = new string[analysisWords.Length];


        for(int i =0; i < analysisWords.Length; i++)
        {

            switch (analysisWords[i])
            {


                case ".-":
                    container[i] =  "a";
                    break;
                case "-...":
                    container[i] = string.Concat(container[i], "b");
                    break;
                case "-.-.":
                    container[i] = string.Concat(container[i], "c");
                    break;
                case "-..":
                    container[i] = string.Concat(container[i], "d");
                    break;
                case ".":
                    container[i] = string.Concat(container[i], "e");
                    break;


                case "..-.":
                    container[i] = string.Concat(container[i], "f");
                    break;
                case "--.":
                    container[i] = string.Concat(container[i], "g");
                    break;
                case "....":
                    container[i] = string.Concat(container[i], "h");
                    break;
                case "..":
                    container[i] = string.Concat(container[i], "i");
                    break;
                case ".---":
                    container[i] = string.Concat(container[i], "j");
                    break;
                case "-.-":
                    container[i] = string.Concat(container[i], "k");
                    break;
                case ".-..":
                    container[i] = string.Concat(container[i], "l");
                    break;
                case "--":
                    container[i] = string.Concat(container[i], "m");
                    break;




                case "-.":
                    container[i] = string.Concat(container[i], "n");
                    break;
                case "---":
                    container[i] = string.Concat(container[i], "o");
                    break;
                case ".--.":
                    container[i] = string.Concat(container[i], "p");
                    break;
                case "--.-":
                    container[i] = string.Concat(container[i], "q");
                    break;
                case ".-.":
                    container[i] = string.Concat(container[i], "r");
                    break;
                case "...":
                    container[i] = string.Concat(container[i], "s");
                    break;
                case "-":
                    container[i] = string.Concat(container[i], "t");
                    break;
                case "..-":
                    container[i] = string.Concat(container[i], "u");
                    break;
                case "...-":
                    container[i] = string.Concat(container[i], "v");
                    break;
                case ".--":
                    container[i] = string.Concat(container[i], "w");
                    break;
                case "-..-":
                    container[i] = string.Concat(container[i], "x");
                    break;
                case "-.--":
                    container[i] = string.Concat(container[i], "y");
                    break;
                case "--..":
                    container[i] = string.Concat(container[i], "z");
                    break;


            }





        }



        answer = string.Join("", container);


        return answer;
    }

}