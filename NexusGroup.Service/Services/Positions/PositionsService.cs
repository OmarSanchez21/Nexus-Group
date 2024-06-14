using NexusGroup.Data.Models;
using NexusGroup.Data.Repositories.Positions;
using NexusGroup.Service.Core;
using NexusGroup.Service.DTOs.Position;
using NexusGroup.Service.Extention;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.Positions
{
    public class PositionsService : iPositionsService
    {
        private readonly IPositionsRepositories repositories;
        public PositionsService(IPositionsRepositories positions)
        {
            this.repositories = positions;
        }
        public async Task<ServiceResult> GetAll()
        {
            var result = new ServiceResult();
            try
            {
                var positions = await repositories.GetAll();
                result.Success = true;
                result.Data = positions;
            }
            catch (SqlException ex)
            {
                result.Success = false;
                result.Message = "Error al obtener todas las posiciones: " + ex.Message;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error interno: " + ex.Message;
            }
            return result;
        }
        public async Task<ServiceResult> Delete(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                await repositories.Delete(id);
                result.Message = "The positions is delete successfully";
            }
            catch(SqlException ex)
            {
                result.Success = false;
                result.Message = "Sql Error: " + ex.Message;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Internal Error: " + ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> GetValue(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var position = await repositories.GetByID(id);
                if(position == null)
                {
                    result.Success = false;
                    result.Message = "The position is not found";
                    return result;
                }
                else
                {
                    result.Data = position;
                    result.Message = "The position is found";
                }
            }
            catch(SqlException error)
            {
                result.Success = false;
                result.Message = "SQL ERROR: " + error.Message;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Internal Error: " + ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> Save(AddPosition obj)
        {
            var result = new ServiceResult();
            try
            {
                PositionsModels models = obj.GetPositionEntity();
                await this.repositories.Add(models);
                result.Message = "Positions saved successfully";
            }
            catch(SqlException ex)
            {
                result.Success = false;
                result.Message = "Sql Error: " + ex.Message;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Internal Error: " + ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> Update(UpdatePosition obj)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var position = new PositionsModels
                {
                    positionID = obj.Id,
                    name = obj.name,
                    updatedRegistration = obj.updatedRegistration
                };
                await this.repositories.Update(position);
                result.Message = "The position is updated successfully";
            }
            catch(SqlException ex)
            {
                result.Success = false;
                result.Message = "SQL Error: " + ex.Message;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Interal Error: " + ex.Message; 
            }
            return result;
        }
        public Task<ServiceResult> Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
