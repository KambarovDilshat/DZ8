using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ8_2
{
    class UtilityBill
    {
        private double area; // площадь помещения
        private int residents; // количество жителей
        private bool isWinter; // признак зимнего сезона
        private bool isVeteran; // льготы для ветерана труда
        private bool isWarVeteran; // льготы для ветерана войны

        private const double HeatingRate = 1.2; // тариф на отопление
        private const double WaterRate = 200; // тариф на воду
        private const double GasRate = 150; // тариф на газ
        private const double RepairRate = 0.5; // тариф на текущий ремонт

        public UtilityBill(double area, int residents, bool isWinter, bool isVeteran, bool isWarVeteran)
        {
            this.area = area;
            this.residents = residents;
            this.isWinter = isWinter;
            this.isVeteran = isVeteran;
            this.isWarVeteran = isWarVeteran;
        }

        public void CalculateBill()
        {
            double heating = HeatingRate * area * (isWinter ? 1.5 : 1.0); // Зимой отопление дороже
            double water = WaterRate * residents;
            double gas = GasRate * residents;
            double repair = RepairRate * area;

            double veteranDiscount = isVeteran ? 0.3 : 0;
            double warVeteranDiscount = isWarVeteran ? 0.5 : 0;

            double total = heating + water + gas + repair;

            // Применение льгот
            double totalDiscount = total * (veteranDiscount + warVeteranDiscount);
            double finalTotal = total - totalDiscount;

            Console.WriteLine("Вид платежа\tНачислено\tЛьготная скидка\tИтого");
            Console.WriteLine($"Отопление\t{heating:C}\t\t{heating * (veteranDiscount + warVeteranDiscount):C}\t\t{heating - heating * (veteranDiscount + warVeteranDiscount):C}");
            Console.WriteLine($"Вода\t\t{water:C}\t\t{0:C}\t\t\t{water:C}");
            Console.WriteLine($"Газ\t\t{gas:C}\t\t{0:C}\t\t\t{gas:C}");
            Console.WriteLine($"Ремонт\t\t{repair:C}\t\t{0:C}\t\t\t{repair:C}");
            Console.WriteLine($"Общая сумма\t{total:C}\t\t{totalDiscount:C}\t\t{finalTotal:C}");
        }
    }

    class Program
    {
        static void Main()
        {
            UtilityBill bill = new UtilityBill(100, 3, true, true, false); // Пример: площадь 100 м2, 3 человека, зима, ветеран тру

        }
    }
}