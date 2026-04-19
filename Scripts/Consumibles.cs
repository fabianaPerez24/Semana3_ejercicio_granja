using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_Granja_Semana3.Scripts
{
    internal class Consumibles
    {
        string name;
        int amount;
        int valuePerAmount;

        public Consumibles(string name, int amount, int valuePerAmount) 
        { 
            this.name = name;
            this.amount = amount;
            this.valuePerAmount = valuePerAmount;
        }

        public int Value()
        {
            return amount * valuePerAmount;
        }
        public string GetName()
        {
            return name;
        }
        public int GetAmount()
        {
            return amount;
        }
    }
}
