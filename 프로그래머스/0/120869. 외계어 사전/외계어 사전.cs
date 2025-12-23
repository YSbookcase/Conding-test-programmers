using System;
using System.Linq;

public class Solution {
    public int solution(string[] spell, string[] dic) {
                
        string target = new string(spell.SelectMany(s => s).OrderBy(c => c).ToArray());
                
                foreach (string word in dic)
                {
                    if (word.Length != spell.Length)
                        continue;

                    string sorted = new string(word.OrderBy(c => c).ToArray());
                    if (sorted == target)
                        return 1;


                }

                return 2;

    }
}