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
        public Task<ServiceResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> GetValue(int id)
        {
            throw new NotImplementedException();
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

        public Task<ServiceResult> Update(UpdatePosition obj)
        {
            throw new NotImplementedException();
        }
    }
}
