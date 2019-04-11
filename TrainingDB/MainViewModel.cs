using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;

namespace TrainingDB
{
    public class MainViewModel
    {
        EmployeeRepository employeeRepository;

        public MainViewModel()
        {
            employeeRepository = new EmployeeRepository();
        }

        public BindingList<Employee>  GetPeople()
        {
            return employeeRepository.FillData();
        }
        public DataSet GetPerson()
        {
            return employeeRepository.FillDataSet();

        }
        public DataSet GetFilter(string name,string surname)
        {
            return employeeRepository.FilterDataSet(name,surname);
        }
    }
}
