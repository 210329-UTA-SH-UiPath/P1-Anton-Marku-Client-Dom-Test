using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PbClient.Controllers
{
    public static class IFS
    {
        public static int CustomerId = -1;
        public static int StoreId = -1;
        public static List<int> OrderIds = new List<int>();
        public static List<int> OrderPizzas = new List<int>();

        public static int inOrders(int num)
        {
            if (OrderIds.Contains(num))
            {
                return num;
            }
            return -1;
        }

        public static int inOrderPizzas(int num)
        {
            if (OrderPizzas.Contains(num))
            {
                return num;
            }
            return -1;
        }
    }
}
