using System;
 using global::System.Collections.Generic;
 using global::System.IO;
 using global::System.Linq;
 using global::System.Net.Http;
 using global::System.Threading;
 using global::System.Threading.Tasks;

public class Solution {
    public int solution(int order) {
          int count = 0;

          foreach (char c in order.ToString())
          {
              if (c == '3' || c == '6' || c == '9')
              {
                  count++;
              }
          }

          return count;
        
    }
}