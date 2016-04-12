using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestModel.BusinessLayer;
using TestModel.BusinessLayer.Contracts;
using TestModel.BusinessLayer.Implementation;
using TestModel.BusinessLayer.SecondImplementation;
using TestModel.Common;
using TestModel.DataAccess.Contracts;
using TestModel.DataAccess.Implementation.MongoDb;
using TestModel.DataAccess.Objects;

namespace TestModelConsole
{
    class Program
    { 
        static IUserManagement _iuser;
                
        static void Main(string[] args)
        {
            Initialize();

           // new RestaurantsDataAccess().CreateRestaurant();       

            var rest = new RestaurantDto();
            rest.Address = new Address();



            //List<PropertyInfo> addressProperties = rest.Address.GetType().GetProperties().ToList<PropertyInfo>();
            var cor = new List<double>();
            cor.Add(45.4);
            cor.Add(34.56);

            new RestaurantsDataAccess().CreateRestaurant(new RestaurantDto
            {
                Name = "pujanm",
                Price = 89,
                Address = new Address
                {
                    Building = "PujanBuilding",
                    CoOrdinates = cor,
                    Street = "street-pujan",
                    Grade = new Grade() {
                        Date = DateTime.Now,
                        GradeType = "P",
                        Score = 90
                    }
                },
                Grades = new List<Grade>() {
                    new Grade {
                        Date = DateTime.Now,
                        GradeType = "A",
                        Score = 66
                    },
                    new Grade {
                        Date = DateTime.Now.AddDays(-1),
                        GradeType = "A+",
                        Score = 100
                    }
                },
                ListDouble = new List<double>() { 78,89.098,56.23 },
                ListString = new List<string>() { "one","two","three"},
                ObjectList = new List<object>() { 89.33,"haha",98,"i am good"}
            });
            //var usr = new User();
            //retrieve property name
            // string propertyName = PropertySupport.ExtractPropertyName(() => usr.Email);
            // Console.WriteLine();



            //new MongoDbConnectionHelper().ConnectDatabase();

            //get user data access
            //var userDataAccess = MefContainer.GetImplementationObjects<IUserDataAccess>();

            //var mongo = MefContainer.GetImplementationObject<IForMongoDb>();
            //var sqldb = MefContainer.GetImplementationObject<IForSqlServer>();
            var p = 0;

            //var _userManagement = MefContainer.Container.GetExportedValue<IUserManagement>();
            //var _usrBusiness = MefContainer.Container.GetExportedValue<IUserManagementBusinessLayer>();
            //var _goodProduct = MefContainer.Container.GetExportedValue<IGoodProductBusinessLayer>();

            //var uss = MefContainer.GetImplementationObject<IUserManagement>();

            //var goodP = MefContainer.GetImplementationObject<IGoodProductBusinessLayer>();
            //var goodPs = goodP.GetAllProduct();
            //var _is = _iuser;
            //var pe = new Person(null);
            //pe.CUser("");         
            
            //var i = _userManagement.CreateUser("");
            //Console.WriteLine(i);
            Console.ReadLine();

            ////bool exitProgram = false;
            ////Console.WriteLine("Enter [exit] to exit");
            ////while (!exitProgram)
            ////{
            ////    Console.WriteLine("Enter mobile number");
            ////    var mob = new Mobile();
            ////    //mob.MobileNumber = "980827";
            ////    string input = Console.ReadLine();
            ////    if (input == "exit")
            ////    {
            ////        exitProgram = true;
            ////    }
            ////    else {
            ////        mob.MobileNumber = input;
            ////    }
            ////    Console.WriteLine("Telecom: " + mob.Telecom);
            ////    Console.WriteLine("IsNtc: " + mob.IsNtc);
            ////    Console.WriteLine("IsNcell: " + mob.IsNcell);

            ////   // Console.ReadLine();
            ////}
        }

        public static void Initialize()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            //catalog.Catalogs.Add(new AssemblyCatalog(typeof(UserManagementBusinessLayer).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(UserManagementBusinessLayerSecond).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(
                typeof(TestModel.DataAccess.Implementation.MongoDb.UserDataAccess).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(
                typeof(TestModel.DataAccess.Implementation.SqlDatabase.UserDataAccess).Assembly));
            MefContainer.LoadMefContainer(catalog);
        }
    }

    class Mobile
    {
        private string _MobileNumber;
        private string _Telecom;
        private bool _IsNtc;
        private bool _IsNcell;

        public string MobileNumber
        {
            get
            {
                return _MobileNumber;
            }
            set
            {
                _MobileNumber = value;
            }
        }

        public string Telecom
        {
            get
            {
                return GetTelecom().ToString();
            }
        }

        public bool IsNtc
        {
            get
            {
                if (GetTelecom() == TelecomEnum.Ntc)
                {
                    return true;
                }
                else { return false; }
            }
        }

        public bool IsNcell
        {
            get
            {
                if (GetTelecom() == TelecomEnum.Ncell) {
                    return true;
                }
                return false;
            }
        }

        private TelecomEnum GetTelecom()
        {
            Dictionary<string, TelecomEnum> mobilePrefixes = new Dictionary<string, TelecomEnum>();
            mobilePrefixes.Add("980", TelecomEnum.Ncell);
            mobilePrefixes.Add("986", TelecomEnum.Ntc);
            if (!String.IsNullOrWhiteSpace(MobileNumber) && MobileNumber.Length >= 3)
            {
                if (mobilePrefixes.ContainsKey(MobileNumber.Substring(0, 3)))
                {
                    return mobilePrefixes[MobileNumber.Substring(0, 3)];
                }
            }

            return TelecomEnum.None;
        }

    }

    enum TelecomEnum
    {
        None = 0,
        Ntc = 1,
        Ncell = 2
    }
}
