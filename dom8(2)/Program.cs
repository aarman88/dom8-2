using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите метраж помещения (в м2):");
        double squareMeterage = double.Parse(Console.ReadLine());

        Console.WriteLine("Введите количество проживающих людей:");
        int numberOfResidents = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите сезон (осень/зима/лето):");
        string season = Console.ReadLine().ToLower();

        Console.WriteLine("Есть ли льготы? (да/нет):");
        string hasDiscounts = Console.ReadLine().ToLower();

        double heatingRate = 5.0; // Тариф на отопление на 1 м2
        double waterRate = 2.0; // Тариф на воду на 1 человека
        double gasRate = 3.0; // Тариф на газ на 1 человека
        double repairRate = 4.0; // Тариф на текущий ремонт на 1 м2

        if (season == "осень" || season == "зима")
        {
            heatingRate *= 1.2; // Увеличиваем тариф на отопление в холодный сезон
        }

        double heatingCost = heatingRate * squareMeterage;
        double waterCost = waterRate * numberOfResidents;
        double gasCost = gasRate * numberOfResidents;
        double repairCost = repairRate * squareMeterage;

        double totalCost = heatingCost + waterCost + gasCost + repairCost;

        double discount = 0.0;
        if (hasDiscounts == "да")
        {
            Console.WriteLine("Укажите вид льготы (ветеран войны/инвалид):");
            string discountType = Console.ReadLine().ToLower();

            if (discountType == "ветеран войны")
            {
                discount = (heatingCost + waterCost + gasCost + repairCost) * 0.3; // Льгота для ветерана труда (30%)
            }
            else if (discountType == "инвалид")
            {
                discount = (heatingCost + waterCost + gasCost + repairCost) * 0.5; // Льгота для ветерана войны (50%)
            }
        }

        Console.WriteLine("Таблица коммунальных платежей:");
        Console.WriteLine("Вид платежа\tНачислено\tЛьготная скидка\tИтого");
        Console.WriteLine("Отопление\t" + heatingCost + "\t" + discount + "\t" + (heatingCost - discount));
        Console.WriteLine("Вода\t" + waterCost + "\t" + discount + "\t" + (waterCost - discount));
        Console.WriteLine("Газ\t" + gasCost + "\t" + discount + "\t" + (gasCost - discount));
        Console.WriteLine("Текущий ремонт\t" + repairCost + "\t" + discount + "\t" + (repairCost - discount));

        Console.WriteLine("Итоговая сумма: " + (totalCost - discount));
    }
}