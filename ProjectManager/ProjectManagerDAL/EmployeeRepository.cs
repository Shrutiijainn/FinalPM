using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerDAL
{
    public class EmployeeRepository : IRepository<Employee>,IDisposable
    {
        ProjectManagerModel _dbContext;

        public EmployeeRepository()
        {
            _dbContext = new ProjectManagerModel();
        }

        public bool Add(Employee item)
        {
            throw new NotImplementedException();
        }

        public Employee Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> Display()
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}
