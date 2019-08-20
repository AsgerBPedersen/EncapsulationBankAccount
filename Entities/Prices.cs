using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public static class Prices
    {
        public static (int freeTransactions, decimal price) Transaction(int rating)
        {
            if (rating > 0 && rating < 3)
            {
                return (40, 0.78m);
            } else if (rating > 2 && rating < 5)
            {
                return (20, 0.99m);
            } else
            {
                return (10, 1.99m);
            }
        }

        public static decimal Accounts(int rating, int accounts)
        {
            if (rating > 0 && rating < 3)
            {
                if (accounts < 4)
                {
                    return 23;
                } else if(accounts < 10)
                {
                    return 60;
                } else
                {
                    return accounts * 6;
                }
            }
            else if (rating > 2 && rating < 5)
            {
                if (accounts < 4)
                {
                    return 29;
                }
                else if (accounts < 10)
                {
                    return 87;
                }
                else
                {
                    return accounts * 13;
                }
            }
            else
            {
                if (accounts < 4)
                {
                    return 38;
                }
                else if (accounts < 10)
                {
                    return 114;
                }
                else
                {
                    return accounts * 19.75m;
                }
            }
        }
    }
}
