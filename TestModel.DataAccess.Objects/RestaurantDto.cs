using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.DataAccess.Objects
{
    public class RestaurantDto
    {
        public Address Address { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int PriceInt { get; set; }
        public List<string> ListString { get; set; }
        public List<double> ListDouble { get; set; }
        public List<object> ObjectList { get; set; }
        //public string[] StringArray { get; set; }
        //public object[] ObjectArray { get; set; }
        //public Grade[] GradeArray { get; set; }
        //public double[] DoubleInArray { get; set; }
        public List<Grade> Grades { get; set; }


    }

    public class Grade
    {
        public DateTime Date { get; set; }
        public string GradeType { get; set; }
        public int Score { get; set; }
    }

    public class Address
    {
        public Grade Grade { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public List<Double> CoOrdinates { get; set; }
    }
}
