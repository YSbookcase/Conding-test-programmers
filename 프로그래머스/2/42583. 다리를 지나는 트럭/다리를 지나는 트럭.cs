using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int bridge_length, int weight, int[] truck_weights) {
                
        Queue<int> bridge = new Queue<int>();
        int time = 0;
        int bridgeWeight = 0;
        int index = 0;

        while (index < truck_weights.Length)
        {
            time++;

            if (bridge.Count == bridge_length)
            {
                bridgeWeight -= bridge.Dequeue();
            }

            int truckWeight = truck_weights[index];
            if (bridgeWeight + truckWeight <= weight)
            {
                bridge.Enqueue(truckWeight);
                bridgeWeight += truckWeight;
                index++;
            }
            else
            {
                bridge.Enqueue(0);
            }

        }

        return time + bridge_length;

    }
}