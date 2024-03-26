using System;

namespace Task_1
{
    internal class Program
    {       
        static void Main(string[] args)
        {
            try
            {
                Set set1 = new Set();
                set1.AddElement(12);
                set1.AddElement(24);
                set1.AddElement(-48);
                set1.AddElement(8);

                set1.JsonSerialize("C:\\Users\\iclownic\\Documents\\Visual Studio 2022\\Project\\IK_33_2term\\Lab_3\\set1.json");
                Set set1Deserialized = set1.JsonDeserialize("C:\\\\Users\\\\iclownic\\\\Documents\\\\Visual Studio 2022\\\\Project\\\\IK_33_2term\\\\Lab_3\\\\set1.json");

                set1Deserialized.RemoveElement(8);

                Set set2 = new Set();
                set2.AddElement(12);
                set2.AddElement(24);
                set2.AddElement(-48);
                set2.AddElement(8);
                
                int x;
                Console.Write("Число, яке ви хочете перевiрити на належнiсть: ");
                x = int.Parse(Console.ReadLine());
                Console.WriteLine($"Чи належить {x} set1? {set1Deserialized.ContainsElement(x)} \nЧи належить {x} set2? {set2.ContainsElement(x)}");

                Console.WriteLine($"Чи є set1 пiдмножиною set2? {set1Deserialized.SubsetSet(set2)}");

                Console.WriteLine($"Чи рiвнi set1 та set2? {set1Deserialized.EqualSet(set2)}");

                Set set3 = new Set();
                set3.AddElement(12);
                set3.AddElement(14);
                set3.AddElement(-48);

                Set set4 = new Set();
                set4.AddElement(6);
                set4.AddElement(14);
                set4.AddElement(28);

                Set union = set3.UnionElement(set4);
                Console.Write("Об'єднання set3 та set4: ");
                foreach (int element in union.elements)
                    Console.Write(element + " ");

                Set intersection = set3.IntersectionElement(set4);
                Console.Write("\nПеретин set3 та set4: ");
                foreach (int element in intersection.elements)
                    Console.Write(element + " ");

                Set difference = set3.DifferenceElement(set4);
                Console.Write("\nРізниця set3 від set4: ");
                foreach (int element in difference.elements)
                    Console.Write(element + " ");

                Set symmetricDiff = set3.SymmetricDifferenceElement(set4);
                Console.Write("\nСиметрична різниця set3 та set4: ");
                foreach (int element in symmetricDiff.elements)
                    Console.Write(element + " " );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
            Console.ReadKey();
        }       
    }       
}
