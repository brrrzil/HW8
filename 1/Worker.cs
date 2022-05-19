using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    public class Worker
    {
        //public int ID { get; set; }
        //public DateTime CreateTime { get; set; }
        public string FullName { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Flat { get; set; }
        public string CellNumber { get; set; }
        public string HomeNumber { get; set; }
        //public DateTime BirthDate { get; set; }
        //public int Age { get; set; }
        //public string Birthplace { get; set; }

        public Worker()
        {

        }

        public Worker(string input)
        {
            string[] arr = input.Split('#', '\t');

            FullName = arr[0];
            Street = arr[1];
            House = arr[2];
            Flat = arr[3];
            CellNumber = arr[4];
            HomeNumber = arr[5];
            //ID = int.Parse(arr[0]);
            //CreateTime = Convert.ToDateTime(arr[1]);
            //BirthDate = DateTime.Parse(arr[3]);
            //Birthplace = arr[4];
            //Age = (DateTime.Now.Year - BirthDate.Year);                                                                                        // Вычисление
            //if (DateTime.Now.Month < BirthDate.Month || (DateTime.Now.Month == BirthDate.Month && DateTime.Now.Day < BirthDate.Day)) Age -- ;  //  возраста
        }

        public string Print()
        {
            return $"{FullName}#{Street}#{House}#{Flat}#{CellNumber}#{HomeNumber}";
            //return $"{ID}\t{CreateTime.ToString()}\t{FullName}\t{Age}\t{Birthplace}";
        }
    }
}