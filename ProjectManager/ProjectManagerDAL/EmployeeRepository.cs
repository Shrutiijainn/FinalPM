﻿using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerDAL
{
    public class EmployeeRepository : IRepository<Employee>
    {
        ProjectManagerModel _dbContext;

        public EmployeeRepository()
        {
            _dbContext = new ProjectManagerModel();
        }

        public bool Add(Employee item)
        {
            var IsAdded = false;
            try
            {
                _dbContext.Employees.Add(item);
                IsAdded = _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new ProjectManagerException("error adding data" + ex);
            }
            return IsAdded;
        }

        public Employee Find(int id)
        {
            try
            {
                return _dbContext.Employees.Find(id);
            }
            catch (Exception ex)
            {
                throw new ProjectManagerException("Error finding Task" + ex);
            }
        }

        public List<Employee> Display()
        {
            try
            {
                return _dbContext.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw new ProjectManagerException("Error getting data" + ex);
            }
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}