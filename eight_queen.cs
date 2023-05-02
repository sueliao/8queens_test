using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		var result = Queens(8).Select(solution => string.Join(" ", solution.Select((r, f) => $"{(char)('A' + f)}{r + 1}")));
		Console.Write(string.Join(Environment.NewLine, result));
	}
	
	 private static IEnumerable<int[]> Queens(int n) {
      if (n <= 0)
        yield break;
      
      int[] position = new int[n];

      if (n == 1) {
        yield return position;
        yield break;
      }

      while (true) {
        for (int file = 1; file < n; ) {
          int rank = position[file];

          if (position.Take(file).Select((r, c) => r == rank || 
                rank - r == file - c || 
                rank - r == c - file).Any(x => x)) {
            while (position[file] >= n - 1) {
              position[file] = 0;

              if (--file < 0)
                yield break;
            }

            position[file] += 1;
          }
          else 
            file += 1;
        }

        yield return position.ToArray();

        for (int i = n - 1; i >= 0; --i)
          if (++position[i] >= n)
            position[i] = 0;
          else
            break;
      }
    }
}
