using System;

namespace min_coins_version
{
    class Program
    {

        static void Main(string[] args)
        {

            int[] bills = { 2, 6, 3 };
            int customerCash = 9;

            //Options would 4 one dollar bills or 2 two dollar bills
            var final = ChangeHelper.MinBills(bills, customerCash);
            foreach (var item in final)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
            //Console.Write("Minimum bills required is " + ChangeHelper.MinBills(bills, customerCash));


        }
    }
}
