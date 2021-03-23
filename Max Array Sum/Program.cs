using System.Collections.Generic;
using System.Linq;
using System;

class Solution
{
    
    static int maxSubsetSum(int[] arr)
    {
        var subs = new List<List<int>>(arr.GetSubsets(2)); //sending the array to an extension that returns all the subsets
        int[] subSum = new int[subs.Count()];

        //loop through the returned subsets and put the sum in an array
        for (int j = 0; j < subs.Count(); j++ )
        {
            subSum[j] = subs.ElementAt(j).Sum();
        }

        //returns the highest number, 0 if negative
        return subSum.Max() > 0 ? subSum.Max() : 0;
    }



    static void Main(string[] args)
    {

        do
        {
            //Console expects input of numbers, seperated by spaces (eg. 1 2 3 4 5)
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));

            var res = maxSubsetSum(arr);

            Console.WriteLine(res);
            Console.Write("Press <Esc> to exit... ");
            
        }
        while (Console.ReadKey().Key != ConsoleKey.Escape);
    }

}

public static class Extensions
{
    public static IEnumerable<List<T>> GetSubsets<T>
    (
        this IEnumerable<T> source, // the collection we are evaluating
        int minDistance,            // minimum gap between numbers
        List<T> subset = null       // stores the progress of the subset we are evaluating
    )
    {
        for (int i = 0; i < source.Count(); i++)
        {
            var newSubset = new List<T>(subset ?? Enumerable.Empty<T>())
            {
                source.ElementAt(i)
            };

            if (newSubset.Count >= 1) //return subsets of more than one element
                yield return newSubset;

            if (source.Count() < 2) //end of list reached
                yield break;

            foreach (var ss in source.Skip(i + minDistance).GetSubsets(minDistance, newSubset))
                yield return ss;
        }
    }
}
