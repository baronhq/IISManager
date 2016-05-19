﻿using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static IList<Employee> employees;

        static EmployeeRepository()
        {
            employees = new List<Employee>();
            employees.Add(new Employee("001", "张三", "男", new DateTime(1981, 8, 24),"销售部"));
            employees.Add(new Employee("002", "李四", "女", new DateTime(1982, 7, 10),"人事部"));
            employees.Add(new Employee("003", "王五", "男", new DateTime(1981, 9, 21),"人事部"));
        }

        public IEnumerable<Employee> GetEmployees(string id = "")
        {
            return employees.Where(e => e.Id == id || string.IsNullOrEmpty(id));
        }
    }
}