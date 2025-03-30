using System;

public class Solution {
    public string solution(string letter){
    string answer = "";


    string[] analysisWords = letter.Split(' ');

    foreach (string analysisWord in analysisWords)
    {

        switch (analysisWord)
        {


            case ".-":
                answer = string.Concat(answer, "a");
                break;
            case "-...":
                answer = string.Concat(answer, "b");
                break;
            case "-.-.":
                answer = string.Concat(answer, "c");
                break;
            case "-..":
                answer = string.Concat(answer, "d");
                break;
            case ".":
                answer = string.Concat(answer, "e");
                break;


            case "..-.":
                answer = string.Concat(answer, "f");
                break;
            case "--.":
                answer = string.Concat(answer, "g");
                break;
            case "....":
                answer = string.Concat(answer, "h");
                break;
            case "..":
                answer = string.Concat(answer, "i");
                break;
            case ".---":
                answer = string.Concat(answer, "j");
                break;
            case "-.-":
                answer = string.Concat(answer, "k");
                break;
            case ".-..":
                answer = string.Concat(answer, "l");
                break;
            case "--":
                answer = string.Concat(answer, "m");
                break;




            case "-.":
                answer = string.Concat(answer, "n");
                break;
            case "---":
                answer = string.Concat(answer, "o");
                break;
            case ".--.":
                answer = string.Concat(answer, "p");
                break;
            case "--.-":
                answer = string.Concat(answer, "q");
                break;
            case ".-.":
                answer = string.Concat(answer, "r");
                break;
            case "...":
                answer = string.Concat(answer, "s");
                break;
            case "-":
                answer = string.Concat(answer, "t");
                break;
            case "..-":
                answer = string.Concat(answer, "u");
                break;
            case "...-":
                answer = string.Concat(answer, "v");
                break;
            case ".--":
                answer = string.Concat(answer, "w");
                break;
            case "-..-":
                answer = string.Concat(answer, "x");
                break;
            case "-.--":
                answer = string.Concat(answer, "y");
                break;
            case "--..":
                answer = string.Concat(answer, "z");
                break;


        }





    }






    return answer;
}
}