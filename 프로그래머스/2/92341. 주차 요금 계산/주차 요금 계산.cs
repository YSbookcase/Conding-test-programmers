using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(int[] fees, string[] records) 
     {
        int defaultTime = fees[0];
        int defaultFee = fees[1];
        int unitTime = fees[2];
        int unitFee = fees[3];
        Dictionary<string, int> inTimeByCar = new Dictionary<string, int>();
        Dictionary<string, int> totalTimeByCar = new Dictionary<string, int>();
        foreach (string record in records)
        {
            string[] parts = record.Split(' ');
            int time = ToMinutes(parts[0]);
            string car = parts[1];
            string action = parts[2];
            if (action == "IN")
            {
                inTimeByCar[car] = time;
            }
            else
            {
                totalTimeByCar.TryGetValue(car, out int total);
                totalTimeByCar[car] = total + (time - inTimeByCar[car]);
                inTimeByCar.Remove(car);
            }
        }
        foreach (KeyValuePair<string, int> pair in inTimeByCar)
        {
            totalTimeByCar.TryGetValue(pair.Key, out int total);
            totalTimeByCar[pair.Key] = total + (ToMinutes("23:59") - pair.Value);
        }
        List<string> cars = totalTimeByCar.Keys.ToList();
        cars.Sort();
        int[] answer = new int[cars.Count];
        for (int index = 0; index < cars.Count; index++)
            answer[index] = GetFee(totalTimeByCar[cars[index]], defaultTime, defaultFee, unitTime, unitFee);
        return answer;
    }
    int ToMinutes(string time)
    {
        string[] parts = time.Split(':');
        int hour = int.Parse(parts[0]);
        int minute = int.Parse(parts[1]);
        return hour * 60 + minute;
    }
    int GetFee(int totalTime, int defaultTime, int defaultFee, int unitTime, int unitFee)
    {
        if (totalTime <= defaultTime)
            return defaultFee;
        int extra = totalTime - defaultTime;
        int unitCount = (extra + unitTime - 1) / unitTime;
        return defaultFee + unitCount * unitFee;
    }
}