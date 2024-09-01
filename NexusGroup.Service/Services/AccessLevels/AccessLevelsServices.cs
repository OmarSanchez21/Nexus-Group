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
                    result.Message = "No hay ningun registro.";
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
                    result.Message = "Se han encontrado.";
                    result.Data = dtos;
                }
            }
            catch (SqlException sqlexception)
            {
                new LogConfiguration.ExceptionServer("Obteniendo todos los access levels.", sqlexception);
                result.Success = false;
                result.Message = "Ha ocurrido un error con la base de datos.";
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                new LogConfiguration.ExceptionServer("Error interno con el servidor", ex);
                result.Success = false;
                result.Message = "Ha ocurrido un error interno.";
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
                var access = await this._repositories.GetValue(id);
                if(access == null)
                {
                    result.Success = false;
                    result.Message = "No se ha encontrado ningun accesso";
                    return result;
                }
                result.Message = "Se encontro.";
                result.Data = access;
            }
            catch (SqlException sqlexception)
            {
                new LogConfiguration.ExceptionServer("Obteniendo todos los access levels.", sqlexception);
                result.Success = false;
                result.Message = "Ha ocurrido un error con la base de datos.";
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                new LogConfiguration.ExceptionServer("Error interno con el servidor", ex);
                result.Success = false;
                result.Message = "Ha ocurrido un error interno.";
                result.Data = ex.Message;
                return result;
            }
            return result;
        }
    }
}
