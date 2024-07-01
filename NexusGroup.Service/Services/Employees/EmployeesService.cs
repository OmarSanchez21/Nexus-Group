﻿using NexusGroup.Data.Models;
using NexusGroup.Data.Repositories.Employees;
using NexusGroup.Service.Core;
using NexusGroup.Service.DTOs.Employees;
using NexusGroup.Service.DTOs.JobOffers;
using NexusGroup.Service.Extention;
using NexusGroup.Service.Validations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.Employees
{
    public class EmployeesService : iEmployeesService
    {
        private readonly IEmployeesRepositories repositories;
        public EmployeesService(IEmployeesRepositories employeesService)
        {
            repositories = employeesService;
        }

        public async Task<ServiceResult> Delete(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                await this.repositories.Delete(id);
                result.Message = "The employees is deleted successfully";
            }
            catch (SqlException ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error en la base de datos";
                ExcetionLogs.LogSQLError(ex);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Internal Error";
                ExcetionLogs.LogInternalError(ex);
            }
            return result;
        }

        public async Task<ServiceResult> GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var employees = await repositories.GetAll();
                var employeesDTO = employees.Select(emp => new AllEmployees()
                {
                    employeeID = emp.employeeID,
                    name = emp.name,
                    lastName = emp.lastName,
                    photo = emp.photo,
                    email = emp.email,
                    joinDate = DateOnly.FromDateTime(emp.joinDate),
                    accessLevelID = emp.accessLevelID,
                    positionID = emp.positionID,
                }).ToList();
                result.Success = true;
                result.Data = employeesDTO;
            }
            catch (SqlException ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error en la base de datos";
                ExcetionLogs.LogSQLError(ex);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Internal Error";
                ExcetionLogs.LogInternalError(ex);
            }
            return result;
        }

        public async Task<ServiceResult> GetAllDeleted()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var employees = await repositories.GetAllDeleted();
                var employeesDTO = employees.Select(emp => new AllEmployees()
                {
                    employeeID = emp.employeeID,
                    name = emp.name,
                    lastName = emp.lastName,
                    photo = emp.photo,
                    email = emp.email,
                    joinDate = DateOnly.FromDateTime(emp.joinDate),
                    accessLevelID = emp.accessLevelID,
                    positionID = emp.positionID,
                });
                result.Success = true;
                result.Data = employeesDTO;
            }
            catch (SqlException ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error en la base de datos";
                ExcetionLogs.LogSQLError(ex);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Internal Error";
                ExcetionLogs.LogInternalError(ex);
            }
            return result;
        }

        public async Task<ServiceResult> GetValue(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var employee = await this.repositories.GetByID(id);
                if (employee == null) 
                {
                    result.Success = false;
                    result.Message = "The employee doesnt exists";
                    return result;
                }
                else
                {
                    result.Data = employee;
                    result.Message = "The employee is founded.";
                }
            }
            catch (SqlException ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error en la base de datos";
                ExcetionLogs.LogSQLError(ex);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Internal Error";
                ExcetionLogs.LogInternalError(ex);
            }
            return result;
        }

        public async Task<ServiceResult> Recover(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                await this.repositories.Recover(id);
                result.Message = "The Job Offers is recovered succesfully";
            }
            catch (SqlException ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error en la base de datos";
                ExcetionLogs.LogSQLError(ex);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Internal Error";
                ExcetionLogs.LogInternalError(ex);
            }
            return result;
        }

        public async Task<ServiceResult> Remove(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                await this.repositories.RemovePermantly(id);
                result.Message = "The Job Offers is removed permantly";
            }
            catch (SqlException ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error en la base de datos";
                ExcetionLogs.LogSQLError(ex);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Internal Error";
                ExcetionLogs.LogInternalError(ex);
            }
            return result;
        }

        public async Task<ServiceResult> Save(AddEmployees obj)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                EmployeesModels models = obj.GetEmployeesEntity();
                await this.repositories.Add(models);
                result.Message = "Employees saved successfully";
            }
            catch (SqlException ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error en la base de datos";
                ExcetionLogs.LogSQLError(ex);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Internal Error";
                ExcetionLogs.LogInternalError(ex);
            }
            return result;
        }

        public async Task<ServiceResult> Update(UpdateEmployees obj)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                EmployeesModels employees = obj.GetUpdatedEmployee();
                await this.repositories.Update(employees);
                result.Message = "The Employee is updated successfully";
            }
            catch (SqlException ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error en la base de datos";
                ExcetionLogs.LogSQLError(ex);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Internal Error";
                ExcetionLogs.LogInternalError(ex);
            }
            return result;
        }
    }
}
