using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tarea_Granja_Semana3.Scripts
{
    internal class Game
    {
        List<Interfaz_planta> plantas;
        List<Interfaz_animales> animales;
        List<Consumibles> consumibles;
        List<Venta> VentaPendiente;

        int money = 100;
        int slots = 5;

        public void Start()
        {
            Console.WriteLine("Hola! Bienvenidos a tu Granja virutal");

            plantas=new List<Interfaz_planta>();
            animales=new List<Interfaz_animales>();
            consumibles=new List<Consumibles>();
        }

        public void Partida()
        {
            while (true)
            {
                Console.WriteLine("1.- Comprar Animales");
                Console.WriteLine("2.- Comprar Plantas");
                Console.WriteLine("3.- Comprar espacios");
                Console.WriteLine("4.- Recolectar recursos Animales");
                Console.WriteLine("5.- Recolectar recursos Plantas");
                Console.WriteLine("6.- Avanzar dias");
                Console.WriteLine("7.- Vender");

                Console.WriteLine("0.- Salir");
                int answer = int.Parse(Console.ReadLine());

                switch (answer)
                { 
                    case 1:
                        ComprarAnimales();
                        break;
                    case 2:
                        ComprarPlantas();
                        break;
                    case 3:
                        ComprarEspacios();
                        break;
                    case 4:
                        RecolectarAnimales();
                        break;
                    case 5:
                        RecolectarPlantas();
                        break;
                    case 6:
                        Avanzar();
                        break;
                    case 7:
                        Vender();
                        break;
                    case 0:
                        return;
                }

            }
        }
        private void ComprarAnimales()
        {
            if(slots<=0)
            {
                Console.WriteLine("Error No te quedan espacios");
                return;
            }
            Console.WriteLine("Puedes comprar:");
            Console.WriteLine("1.- Gallina (cuesta $40, crece en 5 turnos, se vende en $60)");
            Console.WriteLine("2.- Oveja (cuesta $50, crece en 6 turnos, se vende en $80)");
            Console.WriteLine("3.- Vaca (cuesta $30, crece en 3 turnos, se vende en $50)");
            int answer = int.Parse(Console.ReadLine());
            string name = "";
            int timeGrow = 0;
            int price = 0;
            int priceToSell = 0;

            switch (answer)
            {
                case 1:
                    name = "Gallina";
                    timeGrow = 5;
                    price = 40;
                    priceToSell = 60;
                    break;
                case 2:
                    name = "Oveja";
                    timeGrow = 6;
                    price = 80;
                    priceToSell = 80;

                    break;
                case 3:
                    name = "vaca";
                    timeGrow = 3;
                    price = 30;
                    priceToSell = 50;

                    break;
                case 0:
                    break;
            }
            if (money < price)
            {
                Console.WriteLine("No hay dinero suficiente");
                return;
            }

            money -= price;
            slots--;
            animales.Add(new Animales(name, price, priceToSell, false, 5, timeGrow));

        }
        private void ComprarPlantas()
        {
            if (slots <= 0)
            {
                Console.WriteLine("Error No te quedan espacios");
                return;
            }
            Console.WriteLine("Puedes comprar:");
            Console.WriteLine("1.- Lechuga (cuesta $4, crece en 5 turnos, se vende en $6)");
            Console.WriteLine("2.- Tomate (cuesta $5, crece en 6 turnos, se vende en $8)");
            Console.WriteLine("3.- Papa (cuesta $3, crece en 3 turnos, se vende en $5)");
            int answer = int.Parse(Console.ReadLine());
            string name = "";
            int timeGrow =0;
            int price = 0;
            int priceToSell = 0;

            switch (answer)
            {
                case 1:
                    name ="Lechuga";
                    timeGrow = 5;
                    price = 4;
                    priceToSell = 6;
                    break;
                case 2:
                    name = "Tomate";
                    timeGrow = 6;
                    price = 8;
                    priceToSell = 8;

                    break;
                case 3:
                    name = "papa";
                    timeGrow = 3;
                    price = 3;
                    priceToSell = 5;

                    break;
                case 0:
                    break;
            }
            if(money < price)
            {
                Console.WriteLine("No hay dinero suficiente");
                return;
            }

            money-=price;
            slots--;
            plantas.Add(new Plantas(name, price, priceToSell, false, 5, timeGrow));


        }
        private void ComprarEspacios()
        {
            Console.WriteLine("Un espacio cuesta $20. Quieres comprarlo?");
            Console.WriteLine("1.- Si");
            Console.WriteLine("2.- No");

            int answer = int.Parse(Console.ReadLine());
            switch (answer)
            {
                case 1:
                    int price = 20;
                    if (money < price)
                    {
                        Console.WriteLine("No hay dinero suficiente");
                        return;

                    }
                    money-= price;
                    slots++;
                    Console.WriteLine("Haz comprado 1 espacio");

                    break;
                case 2:

                    break;
                case 0:
                    break;
            }
        }

        private void RecolectarAnimales()
        {
            List<Interfaz_animales> recolectarAnimales= new List<Interfaz_animales>();
           foreach (var producto in recolectarAnimales)
            {
                Animales a = producto as Animales;
                if(a.IsRecolect())
                {
                    Consumibles con =a.Recolect();
                    consumibles.Add(con);
                    recolectarAnimales.Add(a);
                }
            }
        }
        private void RecolectarPlantas()
        {
            List<Interfaz_planta> recolectarPlantas = new List<Interfaz_planta>();
            foreach (var producto in recolectarPlantas)
            {
                Plantas b = producto as Plantas;
                if (b.IsHarvest())
                {
                    Consumibles con = b.Recolect();
                    consumibles.Add(con);
                    recolectarPlantas.Add(b);
                }
            }
        }
        private void Avanzar()
        {
            foreach(var item in plantas)
            {
                item.TimePassed();
            }
            foreach (var item in animales)
            {
                item.TimePassed();
            }
        }
        private void Vender()
        {
            Console.WriteLine("Inventario para ventas");

            if (consumibles.Count == 0)
            {
                Console.WriteLine("Inventario vacio");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Elige el producto a vender:");
            int choice = int.Parse(Console.ReadLine()) - 1;

            if (choice < 0 || choice >= consumibles.Count)
            { return; }

            Console.WriteLine($"¿cuanto planeas deseas vender?");
            int amount = int.Parse(Console.ReadLine());

            Console.WriteLine("Producto puesto en venta");
            Console.ReadKey();
        }
    }
    
}
