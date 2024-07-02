﻿using NexusGroup.Data.Base;
using NexusGroup.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Data.Repositories.Employees
{
    public interface IEmployeesRepositories: IService<EmployeesModels>
    {
        Task ChangePassword(int id, string password);
    }
}
