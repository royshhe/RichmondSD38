using System;
using System.Collections.Generic;

namespace CoinDenomination
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int[]> lstPossibleWay = getPossibleWay(125);
            foreach(int[] arr in lstPossibleWay)
            {
                Console.WriteLine("possible way:");
                for (int i=0;i<arr.Length;i++)
                Console.WriteLine(arr[i]);
            }
        }
        static LinkedList<int[]> getPossibleWay(int iAmount)
        {
            LinkedList<int[]> lstPossibleWay = new LinkedList<int[]>();
            int iMaxQuarter, iMaxDime, iMaxNickel, iMaxPenny;          
            
            iMaxQuarter = (int)Math.Floor((double)iAmount / 25);
            if (iMaxQuarter * 25 == iAmount) {                
                 
                lstPossibleWay.AddLast(new int[4] { 0, 0, 0, iMaxQuarter }); 
            }
            for (int i=0; i < iMaxQuarter; i++)
            {
                iMaxDime =(int) Math.Floor((double)(iAmount - (25 * i)) / 10);
                if (iMaxDime * 10 + 25 * i == iAmount) lstPossibleWay.AddLast(new int[4] { 0, 0, iMaxDime, i });
                for (int j = 0; j < iMaxDime; j++)
                {
                    iMaxNickel = (int)Math.Floor((double)(iAmount - (25 * i)-(10*j)) / 5);
                    if (5* iMaxNickel + 10*j + 25 * i == iAmount) lstPossibleWay.AddLast(new int[4] { 0, iMaxNickel, j, i });
                    for (int k=0; k<iMaxNickel; k++)
                    {
                        iMaxPenny = iAmount - 25 * i - 10 * j - 5 * k;
                        lstPossibleWay.AddLast(new int[4] { iMaxPenny, k, j, i });
                    }
                }
            }

            return lstPossibleWay;
        }
    }
}
