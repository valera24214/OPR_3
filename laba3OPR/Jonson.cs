using System.Collections.Generic;
using System.Linq;

namespace laba3OPR
{
    public class Jonson
    {
        List<int> a = new List<int>();
        List<int> b = new List<int>();

        public Jonson(List<int> a, List<int> b)
        {
            this.a = a;
            this.b = b;
        }

        public void sort(List<int> Index, out int[] _sortInd)
        {
            int n = a.Count;
            int l = n - 1;
            int f = 0;
            int temp = 0;

            List<int> Atemp = new List<int>(a);
            List<int> Btemp = new List<int>(b);
            List<int> IndTemp = new List<int>(Index);

            int[] sortindex = new int[n];

            List<int> sortInd = new List<int>();

            for (int i = 0; i < n; i++)
            {
                if (Atemp.Min() <= Btemp.Min())
                {
                    sortindex[f] = IndTemp[Atemp.IndexOf(Atemp.Min())];
                    temp = Atemp.IndexOf(Atemp.Min());
                    IndTemp.RemoveAt(temp);
                    Atemp.RemoveAt(temp);
                    Btemp.RemoveAt(temp);

                    f += 1;
                }

                else
                {
                    sortindex[l] = IndTemp[Btemp.IndexOf(Btemp.Min())];
                    temp = Btemp.IndexOf(Btemp.Min());
                    IndTemp.RemoveAt(temp);
                    Atemp.RemoveAt(temp);
                    Btemp.RemoveAt(temp);

                    l -= 1;
                }
            }

            _sortInd = sortindex;
        }

        public void solveJonson(int[] Ind, List<int> a, List<int> b, out List<int> downtimes, out int downtimeRes, out int result)
        {
            int n = a.Count;

            List<int> Ldowntime = new List<int>();
            List<int> TimesA = new List<int>();
            List<int> TimesB = new List<int>();

            int res = 0;
            int downtime = 0;
            int TimeA = 0;
            int TimeB = 0;

            for (int i = 0; i < n; i++)
            {
                TimeA += a[Ind[i] - 1];
                if ((TimeA - TimeB) > 0)
                {
                    Ldowntime.Add(TimeA - TimeB);
                    downtime += TimeA - TimeB;
                    TimeB += TimeA - TimeB;
                    TimeB += b[Ind[i] - 1];
                }

                else
                {
                    TimeB += b[Ind[i] - 1];
                }
            }

            res += TimeB;
            downtimes = Ldowntime;
            downtimeRes = downtime;
            result = res;
        }
    }
}
