using System;

namespace min_coins_version
{
    class Program
    {

        static void Main(string[] args)
        {

            int[] bills = { 2, 3 };
            int customerCash = 5;

            //Options would 4 one dollar bills or 2 two dollar bills
            ChangeHelper.MinBillResult(bills, customerCash);
            //Console.Write("Minimum bills required is " + ChangeHelper.MinBills(bills, customerCash));


        }
    }
}
