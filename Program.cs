using System;

namespace min_coins_version
{
    class Program
    {

        static void Main(string[] args)
        {

            int[] bills = { 1, 2 };
            int customerCash = 4;

            //Options would 4 one dollar bills or 2 two dollar bills
            Console.Write("Minimum bills required is " + ChangeHelper.MinBills(bills, customerCash));


        }
    }
}
