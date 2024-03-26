using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace Task_1
{
    public class Set
    {
        public List<int> elements = new List<int>();

        //належність
        public bool ContainsElement(int element)
        {
            return elements.Contains(element);
        }

        //додавання
        public void AddElement(int element)
        {
            if (!ContainsElement(element))
                elements.Add(element);
        }

        //видалення
        public void RemoveElement(int element)
        {
            elements.Remove(element);
        }

        //підмножина
        public bool SubsetSet(Set set)
        {
            foreach (int element in elements)
            {
                if (!set.ContainsElement(element))
                    return false;
            }
            return true;
        }

        //рівність (нерівність)
        public bool EqualSet(Set set)
        {
            if (elements.Count != set.elements.Count)
                return false;

            foreach (int element in elements)
            {
                if (!set.ContainsElement(element))
                    return false;
            }
            return true;
        }

        //об'єднання
        public Set UnionElement(Set set)
        {
            Set union = new Set();
            foreach (int element in elements)
            {
                union.AddElement(element);
            }

            foreach (int element in set.elements)
            {
                union.AddElement(element);
            }
            return union;
        }

        //перетин
        public Set IntersectionElement(Set set)
        {
            Set intersection = new Set();
            foreach(int element in elements)
            { 
                if (set.ContainsElement(element))
                {
                    intersection.AddElement(element);
                }
            }
            return intersection;
        }

        //різниця
        public Set DifferenceElement(Set set)
        {
            Set difference = new Set();
            foreach (int element in elements)
            {
                if (!set.ContainsElement(element))
                {
                    difference.AddElement(element);
                }
            }
            return difference;
        }

        //симетрична різниця
        public Set SymmetricDifferenceElement(Set set)
        {
            Set symmetricDiff = new Set();
            foreach (int element in elements)
            {
                if (!set.ContainsElement(element))
                    symmetricDiff.AddElement(element);
            }
            foreach (int element in set.elements)
            {
                if (!ContainsElement(element))
                    symmetricDiff.AddElement(element);
            }
            return symmetricDiff;
        }

        //серіалізація (JSON) та збереження у файл
        public void JsonSerialize (string file)
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(file, json);
            Console.WriteLine($"Об'єкт збережено за посиланням: {file}");
        }
        //десеріалізація
        public Set JsonDeserialize(string file)
        {
            string json = File.ReadAllText(file);
            return JsonConvert.DeserializeObject<Set>(json);
        }
    }
}
