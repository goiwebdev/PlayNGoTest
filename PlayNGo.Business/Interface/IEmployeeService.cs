﻿using PlayNGo.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNGo.Business.Interface
{
    public interface IEmployeeService
    {
        IList<Employee> GetAllEmployees();
    }
}
