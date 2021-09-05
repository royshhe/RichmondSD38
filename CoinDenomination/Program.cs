using System;
using System.Collections.Generic;

namespace CoinDenomination
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int[]> lstPossibleWay = getPossibleWay(500);
            Console.WriteLine($"There are {lstPossibleWay.Count} way");

            Console.WriteLine("{1c, 2c, 5c, 10c, 20c, 50c, 1Euro, 2Euro}");
            foreach (int[] arr in lstPossibleWay)
            {

                //We could output this to a file

                Console.WriteLine(string.Join(",    ", arr));
            }
        }
        static LinkedList<int[]> getPossibleWay(int iAmount)
        {
            LinkedList<int[]> lstPossibleWay = new LinkedList<int[]>();
            int iMax2Euro, iMax1Euro, iMax50c, iMax20c, iMaxDime, iMaxNickel,iMax2c, iMax1c;


            iMax2Euro = (int)Math.Floor((double)iAmount / 200);
            if (iMax2Euro * 200 == iAmount)
            {

                lstPossibleWay.AddLast(new int[8] { 0,0,0,0,0,0,0, iMax2Euro});
            }
            for (int a = 0; a <= iMax2Euro; a++)
            {
                iMax1Euro = (int)Math.Floor((double)(iAmount - (200 * a)) / 100);
                if (100 * iMax1Euro + 200 * a == iAmount && iMax1Euro!=0) lstPossibleWay.AddLast(new int[8] { 0, 0, 0, 0, 0, 0, iMax1Euro, a });
                for (int b = 0; b <= iMax1Euro; b++)
                {
                    iMax50c = (int)Math.Floor((double)(iAmount - (200 * a) - (100 * b)) / 50);
                    if (50 * iMax50c + 100 * b + 200 * a == iAmount && iMax50c != 0) lstPossibleWay.AddLast(new int[8] { 0, 0, 0, 0, 0, iMax50c, b, a });
                    for (int c = 0; c <= iMax50c; c++)
                    {

                        iMax20c = (int)Math.Floor((double)(iAmount - (200 * a) - (100 * b) - (50 * c)) / 20);
                        if (20 * iMax20c + 50 * c + 100 * b + 200 * a == iAmount && iMax20c!=0) lstPossibleWay.AddLast(new int[8] { 0, 0, 0, 0, iMax20c, c, b, a });
                        for (int d = 0; d <= iMax20c; d++)
                        {
                            iMaxDime = (int)Math.Floor((double)(iAmount - (200 * a) - (100 * b) - (50 * c) - (20 * d)) / 10);
                            if (10*iMaxDime + 20 * d + 50 * c + 100 * b + 200 * a == iAmount && iMaxDime!=0) lstPossibleWay.AddLast(new int[8] { 0, 0, 0, iMaxDime, d, c, b, a });
                            for (int e = 0; e <= iMaxDime; e++)
                            {

                                iMaxNickel = (int)Math.Floor((double)(iAmount - (200 * a) - (100 * b) - (50 * c) - (20 * d) - (10 * e)) / 5);

                                if (5* iMaxNickel  + 10 * e + 20 * d + 50 * c + 100 * b + 200 * a == iAmount && iMaxNickel!=0) 
                                    lstPossibleWay.AddLast(new int[8] { 0, 0, iMaxNickel, e, d, c, b, a });

                                for (int f = 0; f <= iMaxNickel; f++)
                                {
                                    iMax2c = (int)Math.Floor((double)(iAmount - (200 * a) - (100 * b) - (50 * c) - (20 * d) - (10 * e) - (5 * f)) / 2);
                                    if (iMax2c * 2 + f * 5 + 10 * e + 20 * d + 50 * c + 100 * b + 200 * a == iAmount && iMax2c!=0)  lstPossibleWay.AddLast(new int[8] { 0, iMax2c, f, e, d, c, b, a });
                                    for (int g = 0; g <= iMax2c; g++)
                                    {
                                       
                                        iMax1c = iAmount - (200 * a) - (100 * b) - (50 * c) - (20 * d) - (10 * e) - (5 * f) - (2 * g);
                                        if (iMax1c>0)
                                        {
                                            lstPossibleWay.AddLast(new int[8] { iMax1c, g, f, e, d, c, b, a });
                                        }
                                        
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return lstPossibleWay;
        }
    }
}
