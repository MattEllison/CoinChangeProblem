using System;
using System.Collections.Generic;
namespace min_coins_version
{
    public class ChangeHelper
    {
        public class Result
        {

            public int Count { get; set; } = 0;
            public Dictionary<int, int> Bills { get; set; } = new Dictionary<int, int>();
        }
        public static int MinBills(int[] bills, int customerCash)
        {

            // base case 
            if (customerCash == 0) return 0;

            // Initialize result 
            int res = int.MaxValue;

            // Try every coin that has 
            // smaller value than V 
            for (int i = 0; i < bills.Length; i++)
            {
                if (bills[i] <= customerCash)
                {
                    int sub_res = MinBills(bills, customerCash - bills[i]);


                    // Check for INT_MAX to  
                    // avoid overflow and see  
                    // if result can minimized 
                    if (sub_res != int.MaxValue &&
                                sub_res + 1 < res)
                    {
                        res = sub_res + 1;
                    }
                }

            }

            return res;
        }

        public static Result MinBillResult(int[] bills, int customerCash)

        {

            // base case 
            if (customerCash == 0) return new Result();

            // Initialize result 
            int res = int.MaxValue;
            var items = new Dictionary<int, int>();
            // Try every coin that has 
            // smaller value than V 
            for (int i = 0; i < bills.Length; i++)
            {
                if (bills[i] <= customerCash)
                {
                    var sub_res = MinBillResult(bills, customerCash - bills[i]);


                    // Check for INT_MAX to  
                    // avoid overflow and see  
                    // if result can minimized 
                    if (sub_res.Count + 1 < res)
                    {
                        items = sub_res.Bills;
                        if (items.ContainsKey(bills[i]))
                        {
                            items[bills[i]] += 1;
                        }
                        else
                        {
                            items[bills[i]] = sub_res.Count + 1;
                        }



                        //Console.WriteLine($"bill is {bills[i]}");

                        res = sub_res.Count + 1;
                    }
                }

            }


            return new Result()
            {
                Count = res,
                Bills = items
            };
        }
    }
}