using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_Granja_Semana3.Scripts
{
    internal class Plantas:Interfaz_planta
    {
        string name;
        int pricebuy;
        int priceSell;
        bool harvest = false;
        int timeToSell;
        int timeToGrow;

        public Plantas(string name, int pricebuy, int priceSell, bool harvest, int timeToSell, int timeToGrow)
        {
            this.name = name;
            this.pricebuy = pricebuy;
            this.priceSell = priceSell;
            this.harvest = harvest;
            this.timeToSell = timeToSell;
            this.timeToGrow = timeToGrow;
        }
        public string GetName()
        {
            return name;
        }

        public int GetTimeToGrow()
        {
            return timeToGrow;
        }

        public void TimePassed()
        {
            if (timeToGrow > 0)
            {
                timeToGrow--;
            }
        }
        public bool IsHarvest()
        {
            if (timeToGrow == 0)
            {
                return true;
            }
            return false;
        }
        public Consumibles Recolect()
        {
            return new Consumibles(name, 1, priceSell);
        }

    }
}
