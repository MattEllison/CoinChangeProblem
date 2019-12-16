using System.Linq;
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
        public static Dictionary<int, int> MinBills(int[] bills, int customerCash)
        {

            // base case 
            //if (customerCash == 0) return new Dictionary<int, int>();

            // Initialize result 
            int res = int.MaxValue;
            var temp = new Dictionary<int, int>();
            // Try every coin that has 
            // smaller value than V 
            foreach (var bill in bills)
            {

                if (bill <= customerCash)
                {

                    var nextCash = customerCash - bill;
                    var sub_res = nextCash > 0 ? MinBills(bills, nextCash) : new Dictionary<int, int>();
                    // 3,1
                    // 2, 2


                    if (sub_res.ContainsKey(bill))
                    {
                        sub_res[bill]++;
                    }
                    else
                    {
                        sub_res[bill] = 1;
                    }

                    var sum = sub_res.Sum(x => x.Key * x.Value);
                    // Check for INT_MAX to  
                    // if result can minimized 
                    if (sum == customerCash && sub_res.Values.Sum() < res)
                    {
                        res = sub_res.Values.Sum();

                        temp = sub_res;
                    }
                }

            }

            return temp;
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