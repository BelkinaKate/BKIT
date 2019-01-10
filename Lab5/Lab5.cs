using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Lab5
    {
        public static int Dist(string s1, string s2)
        {
            if (s1 == s2)
            {
                return 0;
            }

            var M = s1.Length + 1;
            var N = s2.Length + 1;

            var dist = new int[M, N];

            for (var i = 0; i < M; i++)
            {
                dist[i, 0] = i;
            }

            for (var j = 0; j < N; j++)
            {
                dist[0, j] = j;
            }

            for (var i = 1; i < M; i++)
            {
                for (var j = 1; j < N; j++)
                {
                    var diff = (s1[i - 1] == s2[j - 1]) ? 0 : 1;

                    dist[i, j] = Math.Min(
                        Math.Min(
                            dist[i - 1, j] + 1,
                            dist[i, j - 1] + 1
                        ),
                        dist[i - 1, j - 1] + diff
                    );
                }
            }

            return dist[M - 1, N - 1];
        }
    }
}
