using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_Granja_Semana3.Scripts
{
    internal class Animales:Interfaz_animales
    {

        string name;
        int pricebuy;
        int priceSell;
        bool recolect = false;

        int timeToSell;
        int timeToGrow;

        public Animales(string name, int pricebuy, int priceSell, bool recolect, int timeToGrow, int timeToSell)
        {
            this.name = name;
            this.pricebuy = pricebuy;
            this.priceSell = priceSell;
            this.recolect = recolect;
            this.timeToGrow = timeToGrow;
            this.timeToSell = timeToSell;
        }
        public string GetName()
        {
            return name;
        }
        public void TimePassed()
        {
            if (timeToGrow > 0)
            {
                timeToGrow--;
            }
        }
        public bool IsRecolect()
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
