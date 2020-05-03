using System.Globalization;

namespace Linq
    {
    class Employee
        {
        public string Name { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }

        public Employee(string name, string email, double _salary)
            {
            Name = name;
            Email = email;
            Salary = _salary;
            }
        public override string ToString()
            {
            return  Name
                + "," 
                + Email
                + ","
                + Salary.ToString("f2", CultureInfo.InvariantCulture) ;
            }
        }
    }
