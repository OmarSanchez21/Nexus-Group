using NexusGroup.Data.Repositories.AccessLevels;
using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.AccessLevels
{
    public class AccessLevelsServices : IAccessLevelsServices
    {
        private readonly IAccessLevelsRepositories _repositories;
        private const string TablaName = "Acccess Levels";
        public AccessLevelsServices(IAccessLevelsRepositories repositories)
        {
            this._repositories = repositories;
        }
        public async Task<ServiceResult> GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var access = await _repositories.GetAll();
                if (access == null)
                {
                    result.Success = false;
                    result.Message = ServiceMessages.NotFoundAll;
                    return result;
                }
                else 
                {
                    var dtos = access.Select(ace => new AccessLevelsDTO()
                    {
                        AccessLevelsID = ace.AccessLevelsID,
                        Name = ace.Name,
                        CreateAt = DateOnly.FromDateTime(ace.CreateAt)
                    }).AsEnumerable();
                    result.Message = ServiceMessages.GetAllSuccess;
                    result.Data = dtos;
                }
            }
            catch (SqlException sqlexception)
            {
                string accion = ServiceMessages.LogHelper("all", TablaName);
                new LogConfiguration.ExceptionSQL(accion, sqlexception);
                result.Success = false;
                result.Message = ServiceMessages.DatabaseError;
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                string accion = ServiceMessages.LogHelper("all", TablaName);
                new LogConfiguration.ExceptionServer(accion, ex);
                result.Success = false;
                result.Message = ServiceMessages.InternalError;
                result.Data = ex.Message;
                return result;
            }
            return result;
        }

        public async Task<ServiceResult> GetValue(string id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var access = await _repositories.GetValue(id);
                if(access == null)
                {
                    result.Success = false;
                    result.Message = ServiceMessages.NotFound;
                    return result;
                }
                result.Message = ServiceMessages.GetValue;
                result.Data = access;
            }
            catch (SqlException sqlexception)
            {
                string accion = ServiceMessages.LogHelper("get", TablaName);
                new LogConfiguration.ExceptionServer(accion, sqlexception);
                result.Success = false;
                result.Message = ServiceMessages.DatabaseError;
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                string accion = ServiceMessages.LogHelper("get", TablaName);
                new LogConfiguration.ExceptionServer(accion, ex);
                result.Success = false;
                result.Message = ServiceMessages.InternalError;
                result.Data = ex.Message;
                return result;
            }
            return result;
        }
    }
}
