using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModel.Common;

namespace TestModelConsole
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public List<string> Roles { get; set; }
        public UserType UserType { get; set; }
        public List<AttemptedQuestion> AttemptedQuestions { get; set; }
        
    }
}
