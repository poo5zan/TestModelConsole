using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TestModel.BusinessLayer;
using TestModel.BusinessLayer.Contracts;
using TestModel.BusinessLayer.Implementation;
using TestModel.BusinessLayer.SecondImplementation;
using TestModel.Common;
using TestModel.DataAccess.Contracts;
//using TestModel.DataAccess.Implementation.MongoDb;
using TestModel.DataAccess.Objects;

namespace TestModelConsole
{
    class Program
    {      

       // static IUserManagement _iuser;
       // [Import]
       // public static IUserManagement UserMgmt { get; set; }


        static void Main(string[] args)
        {

            Console.WriteLine("hello pujan");
            Console.WriteLine("Started SqlBulkCopyToDumpCsvToTable, " + DateTime.Now);
            new SqlBulkCopyTrial().SqlBulkCopyToDumpCsvToTable();
            Console.WriteLine("Completed SqlBulkCopyToDumpCsvToTable, " + DateTime.Now);
            //new DownloadFiles().DownloadAllFiles();

            //            var rev = new Reviewer();

            //            var someDict = new Dictionary<string, object>();
            //            someDict.Add("one",1);
            //            someDict.Add("two","two");

            //            var someDictJson = JsonConvert.SerializeObject(someDict);



            //            string json = @"{
            //  'Name': 'Bad Boys',
            //  'ReleaseDate': '1995-4-7T00:00:00',
            //  'Id':6,
            //'ArkoId':3.214,
            //  'Genres': [
            //    'Action',
            //    'Comedy'
            //  ]
            //}";

            //            //Object oj = JsonConvert.DeserializeObject<Object>(json);
            //            //var jobj = oj as JObject;
            //            //foreach (var j in jobj.Properties())
            //            //{
            //            //    Console.WriteLine("Key=" + j.Name);
            //            //    Console.WriteLine("Value="+j.Value);
            //            //    Console.WriteLine("ValueType="+j.Value.Type);
            //            //}


            //            var user = new User();
            //            user.Name = "Pujan";
            //            user.Id = 4;
            //            user.Roles = new List<string>() {"Admin","User","SuperAdmin"};
            //            user.UserType = UserType.Candidate;
            //            user.AttemptedQuestions = new List<AttemptedQuestion>()
            //            {
            //                new AttemptedQuestion()
            //                {
            //                    //ApplicationStatus = ApplicationStatus.Completed,
            //                    QuestionCategory = "Science",
            //                    QuestionId = 23,
            //                    WorkFlowId = "256",
            //                    QuestionAnswers = new List<CandidateQuestionAnswer>()
            //                    {
            //                        new CandidateQuestionAnswer()
            //                        {
            //                            AttemptedQuestionId = 12,
            //                            Question = "What's your name",
            //                            CorrectAnswer = "Haha",
            //                            AnswerOptions = new List<string>() { "Haha","Jaja"},
            //                            UserEnteredAnswer = "Jaja"
            //                        }
            //                    }
            //                },
            //                new AttemptedQuestion()
            //                {
            //                    //ApplicationStatus = ApplicationStatus.Completed,
            //                    QuestionCategory = "IT",
            //                    QuestionId = 233,
            //                    WorkFlowId = "2",
            //                    QuestionAnswers = new List<CandidateQuestionAnswer>()
            //                    {
            //                        new CandidateQuestionAnswer()
            //                        {
            //                            AttemptedQuestionId = 132,
            //                            Question = "Do you want to build snowman?",
            //                            CorrectAnswer = "Yes",
            //                            AnswerOptions = new List<string>() { "Yes","No"},
            //                            UserEnteredAnswer = "Yes"
            //                        }
            //                    }
            //                }
            //            };

            //            var userJson = JsonConvert.SerializeObject(user);

            //            var nest0Object = JsonConvert.DeserializeObject<Object>(userJson);
            //            var nest0JObject = nest0Object as JObject;
            //            JsonHelper.GetJObjectKeyValue(nest0JObject,"RootObject");


            //foreach (var uj in nest0JObject.Properties())
            //{
            //    Console.WriteLine("Nest 0--------");
            //    Console.WriteLine("Key="+uj.Name);
            //    Console.WriteLine("Value="+uj.Value);
            //    Console.WriteLine("ValueType="+uj.Value.Type);
            //    if (uj.Value.Type == JTokenType.Array)
            //    {
            //        var nest0Array = uj.Value as JArray;

            //        foreach (var nest1JObject in nest0Array.Children<JObject>())
            //        {
            //            Console.WriteLine("Nest 1--------");
            //            foreach (var nest1JProperty in nest1JObject.Properties())
            //            {
            //                Console.WriteLine(nest1JProperty.Name);
            //                Console.WriteLine(nest1JProperty.Value);
            //                Console.WriteLine(nest1JProperty.Value.Type);
            //            }
            //        }
            //    }
            //}

            var u = 0;
            //string name = m.Name;
            // Bad Boys

            //    new Program().Initialize();

            //    var u = UserMgmt;

            //    new UserManagement().CreateUser("a");

            //    new UserManagementBusinessLayer().CreateUserBusinessLayer("fda");

            //// new RestaurantsDataAccess().CreateRestaurant();       

            //    var rest = new RestaurantDto();
            //    rest.Address = new Address();

            //FindGreatest(3,6,9,2);
            //FindGreatest(5, 3);


            //    //List<PropertyInfo> addressProperties = rest.Address.GetType().GetProperties().ToList<PropertyInfo>();
            //    var cor = new List<double>();
            //    cor.Add(45.4);
            //    cor.Add(34.56);

            //new RestaurantsDataAccess().CreateRestaurant(new RestaurantDto
            //{
            //    Name = "pujanm",
            //    Price = 89,
            //    Address = new Address
            //    {
            //        Building = "PujanBuilding",
            //        CoOrdinates = cor,
            //        Street = "street-pujan",
            //        Grade = new Grade() {
            //            Date = DateTime.Now,
            //            GradeType = "P",
            //            Score = 90
            //        }
            //    },
            //    Grades = new List<Grade>() {
            //        new Grade {
            //            Date = DateTime.Now,
            //            GradeType = "A",
            //            Score = 66
            //        },
            //        new Grade {
            //            Date = DateTime.Now.AddDays(-1),
            //            GradeType = "A+",
            //            Score = 100
            //        }
            //    },
            //    ListDouble = new List<double>() { 78,89.098,56.23 },
            //    ListString = new List<string>() { "one","two","three"},
            //    ObjectList = new List<object>() { 89.33,"haha",98,"i am good"}
            //});
            //var usr = new User();
            //retrieve property name
            // string propertyName = PropertySupport.ExtractPropertyName(() => usr.Email);
            // Console.WriteLine();



           // //new MongoDbConnectionHelper().ConnectDatabase();

           // //get user data access
           // //var userDataAccess = MefContainer.GetImplementationObjects<IUserDataAccess>();

           // //var mongo = MefContainer.GetImplementationObject<IForMongoDb>();
           // //var sqldb = MefContainer.GetImplementationObject<IForSqlServer>();
           // var p = 0;

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

        private static bool IsNumberPalindrome(long inputNumber)
        {
            bool isPalindrome = true;
            if (inputNumber != ReverseNumber(inputNumber))
            {
                isPalindrome = false;
            }
            return isPalindrome;
        }

        private static long ReverseNumber(long inputNumber)
        {
            long returnValue = 0;
            while (inputNumber != 0)
            {
                //get last digit
                returnValue = (returnValue * 10) + (inputNumber % 10);
                //drop the last digit from the number
                inputNumber = inputNumber / 10;
            }
            
            return returnValue;
        }

        private static bool IsStringPalindrome(string strInput)
        {
            //assign default value of true
            bool isPalindrome = true;
            //loop through string, looping just the half of the array will suffice
            for(int i = 0, j = strInput.Length - 1; i < strInput.Length/2;i++,j--)
            {
                if (strInput[i] != strInput[j])
                {
                    isPalindrome = false;
                    break;
                }                
            }
            return isPalindrome;
        }

        static long FindGreatest(params long[] parameters)
        {
            long greatest = 0;
            if (parameters.Count() == 0) { return 0; }
            foreach (var p in parameters)
            {
                if (p > greatest)
                {
                    greatest = p;
                }

            }
            return greatest;
        }


        public static void Initialize()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            //catalog.Catalogs.Add(new AssemblyCatalog(typeof(UserManagementBusinessLayer).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(UserManagementBusinessLayerSecond).Assembly));
            //catalog.Catalogs.Add(new AssemblyCatalog(
            //    typeof(TestModel.DataAccess.Implementation.MongoDb.UserDataAccess).Assembly));
            //
            catalog.Catalogs.Add(new AssemblyCatalog(
                typeof(TestModel.DataAccess.Implementation.SqlDatabase.UserDataAccess).Assembly));
            MefContainer.LoadMefContainer(catalog);
            //MefContainer.Container.ComposeParts(this);
           // MefContainer.Container.SatisfyImportsOnce(this);

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
                if (GetTelecom() == TelecomEnum.Ncell)
                {
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
