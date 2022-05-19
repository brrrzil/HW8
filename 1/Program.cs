using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _1
{
    class Program
    {
        #region Методы задания №1
        static void FillListWithRandom(List<int> list)
        {
            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                list.Add(rand.Next(0, 100));
            }
        }

        static void PrintList(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + "\t");
                if ((i + 1) % 10 == 0) Console.Write("\n");
            }
        }

        static void FilterList(List<int> list)
        {
            int n = list.Count;
            for (int i = 0; i < n; i++)
            {
                if (list[i] > 25 && list[i] < 50)
                {
                    list.RemoveAt(i);
                    i--;
                    n--;
                }
            }
        }
        #endregion

        #region Методы задания №2

        static void Menu(Dictionary<string, string> contacts, string inputPhone, string inputName)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1 - Добавить контакт");
            Console.WriteLine("2 - Найти контакт по номеру телефона");
            Console.WriteLine("0 - Завершение работы");
            string input = Console.ReadLine();
            if (input == "1") AddContact(contacts, inputPhone, inputName);
            if (input == "2") FindContact(contacts, inputName);
            else return;
        }

        static void AddContact(Dictionary<string, string> contacts, string inputPhone, string inputName)
        {
            inputPhone = AddPhoneRequest();
            if (inputPhone != "")
            {
                Console.Write("Введите имя: ");
                inputName = Console.ReadLine();
                contacts.Add(inputPhone, inputName);
                AddContact(contacts, inputPhone, inputName);
                Menu(contacts, inputPhone, inputName);
            }
            else return;
            Console.WriteLine();
        }

        static string AddPhoneRequest()
        {
            string tempPhone = null;
            Console.Write("Введите номер телефона: ");
            try
            {
                tempPhone = Console.ReadLine();
                return tempPhone;
            }
            catch
            {
                return null;
            }
        }

        static void FindContact(Dictionary<string, string> contacts, string inputName)
        {
            string inputPhone = null;
            Console.Write("Введите искомый номер телефона: ");
            inputPhone = Console.ReadLine();
            if (contacts.TryGetValue(inputPhone, out inputName)) Console.WriteLine($"Пользователь с номером телефона {inputPhone}: {contacts[inputPhone]}");
            else Console.WriteLine("Контакт с таким телефоном не найден");
            Menu(contacts, inputPhone, inputName);
        }

        #endregion

        #region Методы задания №3

        static void InputToHash(HashSet<int> hashSet)
        {
            int a;
            Console.Write("Введите число: ");
           
            a = Int32.Parse(Console.ReadLine());
            
            Console.WriteLine("Это не является числом.");
            IsAdd();            

            if (hashSet.Contains(a))
            {
                Console.WriteLine("Данное число уже есть в множестве.\n");
                if (IsAdd()) { InputToHash(hashSet); }
            }

            else
            {
                hashSet.Add(a);
                Console.WriteLine("Число успешно сохранено в множество\n");
                if (IsAdd()) { InputToHash(hashSet); }
                else PrintHashSet(hashSet);
            }
        }

        static bool IsAdd()
        {
            string input = null;

            Console.Write("Добавить ещё одно число? y / n ");
            try
            {
                input = Console.ReadLine();
                if (input == "y") return true;
                else return false;
            }

            catch { return false; }
        }

        static void PrintHashSet(HashSet<int> hashSet)
        {
            foreach (var e in hashSet) { Console.Write(e + " "); }
            Console.WriteLine();
        }

        #endregion

        #region Задание №4

        static void SerializeWorker(Worker worker, string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Worker));

            Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write);

            xmlSerializer.Serialize(fStream, AddWorker());

            fStream.Close();
        }

        static Worker AddWorker()
        {
            string input = null;

            Console.Write("\nВведите ФИО: ");
            string inputedName = Console.ReadLine();

            Console.Write("\nВведите улицу: ");
            string inputerdStreet = Console.ReadLine();

            Console.Write("\nВведите номер дома: ");
            string inputedHouse = Console.ReadLine();

            Console.Write("\nВведите номер квартиры: ");
            string inputedFlat = Console.ReadLine();

            Console.Write("\nВведите мобильный телефон: ");
            string inputedCellPhone = Console.ReadLine();

            Console.Write("\nВведите домашний телефон: ");
            string inputedHomePhone = Console.ReadLine();

            input = $"{inputedName}#{inputerdStreet}#{inputedHouse}#{inputedFlat}#{inputedCellPhone}#{inputedHomePhone}";
            Worker worker = new Worker(input);
            return worker;
        }

        static Worker DeSerializeWorker(string path)
        {
            Worker tempWorker = new Worker("fio#street#house#flat#num1#num2");
            //tempWorker = null;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Worker));
            Stream fStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            tempWorker = xmlSerializer.Deserialize(fStream) as Worker;

            fStream.Close();

            return tempWorker;
        }

        static List<Worker> DeSerializeWorkerList(string path)
        {
            List<Worker> tempWorkerCol = new List<Worker>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Worker>));

            Stream fStream = new FileStream(path, FileMode.Open, FileAccess.Read);

            tempWorkerCol = xmlSerializer.Deserialize(fStream) as List<Worker>;

            fStream.Close();

            return tempWorkerCol;

        }

        static void SerializeWorkerList (List<Worker> ConcreteWorkerList, string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Worker>));

            Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write);

            xmlSerializer.Serialize(fStream, ConcreteWorkerList);

            fStream.Close();
        }

        #endregion

        static void Main(string[] args)
        {
            #region Задание №1
            Console.WriteLine("Задание №1");
            List<int> list = new List<int>();

            FillListWithRandom(list);

            Console.WriteLine("list из 100 элементов от 0 до 100:");
            PrintList(list);

            Console.WriteLine($"\nЭлементов в list: {list.Count}");

            FilterList(list);
            Console.WriteLine("\nlist после удаления элементов больше 25 и меньше 50:");
            PrintList(list);

            Console.WriteLine($"\nЭлементов в list: {list.Count}");

            Console.WriteLine("\nДля перехода к следующему заданию нажмите любую клавишу . . .");
            //Console.ReadLine();
            Console.Clear();

            #endregion

            #region Задание №2
            Console.WriteLine("Задание №2");
            //string inputName = null, inputPhone = null;
            Dictionary<string, string> contacts = new Dictionary<string, string>();

            //Menu(contacts, inputPhone, inputName);
            Console.Clear();
            #endregion

            #region Задание №3

            Console.WriteLine("Задание №3");
            HashSet<int> hashSet = new HashSet<int>();
            //InputToHash(hashSet);
            //Console.ReadKey();
            Console.Clear();

            #endregion

            #region Задание №4
            Console.WriteLine("Задание №4");

            XElement Person = new XElement("Person");
            XElement Address = new XElement("Address");
            XElement Street = new XElement("Street");
            XElement House = new XElement("House");
            XElement Flat = new XElement("Flat");
            XElement Phones = new XElement("Phones");
            XElement MobilePhone = new XElement("MobilePhone");
            XElement FlatPhone = new XElement("FlatPhone");

            Console.Write("Введите название улицы: ");
            XAttribute xAttributeStreet = new XAttribute("Улица", Console.ReadLine());
            Console.Write("Введите номер дома: ");
            XAttribute xAttributeHouse = new XAttribute("Дом", Console.ReadLine());
            Console.Write("Введите номер квартиры: ");
            XAttribute xAttributeFlat = new XAttribute("Квартира", Console.ReadLine());
            Console.Write("Введите мобильный телефон: ");
            XAttribute xAttributeMobilePhone = new XAttribute("Мобильный_телефон", Console.ReadLine());
            Console.WriteLine("Введите домашний телефон: ");
            XAttribute xAttributeFlatPhone = new XAttribute("Домашний_телефон", Console.ReadLine());

            Person.Add(Address, Phones);
            Address.Add(Street, House, Flat);
            Phones.Add(MobilePhone, FlatPhone);

            Street.Add(xAttributeStreet);
            House.Add(xAttributeHouse);
            Flat.Add(xAttributeFlat);
            MobilePhone.Add(xAttributeMobilePhone);
            FlatPhone.Add(xAttributeFlatPhone);

            Person.Save("_Person.xml");

            #endregion
        }
    }
}
