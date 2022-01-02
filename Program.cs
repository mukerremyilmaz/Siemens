using System;
using System.Collections.Generic;

namespace Siemens
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] A = new int[] { 51, 71, 17, 42 };
			int[] B = new int[] { 42, 33, 60 };
			int[] C = new int[] { 51, 32, 43 };
			Console.WriteLine(Solution(A));
			Console.WriteLine(Solution(B));
			Console.WriteLine(Solution(C));
			Console.Read();
		}

		static int Solution(int[] A)
		{
			Dictionary<int, List<int>> keyValuePairs = new Dictionary<int, List<int>>();
			foreach (var number in A)
			{
				int sumofdigits = 0;
				int num = number;
				while (num > 0)
				{
					sumofdigits += num % 10;
					num /= 10;
				}
				List<int> valueList;
				bool addedBefore = keyValuePairs.TryGetValue(sumofdigits, out valueList);
				if (!addedBefore)
				{
					keyValuePairs.Add(sumofdigits, new List<int>());
					keyValuePairs[sumofdigits].Add(number);
				}
				else
				{
					keyValuePairs[sumofdigits].Add(number);
				}
			}
			int maxSum = 0;
			foreach (var keyValue in keyValuePairs)
			{
				if (keyValue.Value.Count > 1)
				{
					keyValue.Value.Sort();
					int tempMaxsum = 0;
					for (int i = keyValue.Value.Count - 2; i < keyValue.Value.Count; i++)
					{
						tempMaxsum += keyValue.Value[i];
					}
					if (tempMaxsum > maxSum) maxSum = tempMaxsum;
				}
			}
			int result = -1;
			if (maxSum != 0)
			{
				result = maxSum;
			}
			return result;
		}
	}
}
