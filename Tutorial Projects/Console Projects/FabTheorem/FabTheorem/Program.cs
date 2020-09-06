using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabTheorem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(therom(0, 100));
            Console.ReadKey();
        }

        private static string therom(int lowerIndx, int upperIndx)
        {

            int mx = 0;
            int[] fb=new int[] { };

            int l;
            int u;

            string str = "";
            int isize = 1;
            for (int i=0; i <= 100; i++ )
            {
                Array.Resize(ref fb, isize);
                if (i == 0)
                {
                    fb[isize - 1] = i;
                }
                else
                {
                    l = i - 1;
                    u = i + 1;
                    fb[isize - 1] = i + u;
                }

                

                str += fb[isize - 1] + ",";
                isize++;


            }
            return str;

        }
    }
}
