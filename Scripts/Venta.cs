using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_Granja_Semana3.Scripts
{
    internal class Venta
    {
        internal class Sale
        {
            Consumibles product;
            int remainingDays;

            public Sale(Consumibles product, int remainingDays)
            {
                this.product = product;
                this.remainingDays = remainingDays;
            }

            public int GetRemainingDays()
            { return remainingDays; }

            public Consumibles GetProduct() { return product; }

            public int GetTotalValue()
            { return product.GetAmount(); }

            public bool IsReady()
            {
                return remainingDays <= 0;
            }

            public void SpendSellingDay()
            {
                remainingDays--;
            }

        }
    }
}

