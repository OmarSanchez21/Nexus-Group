using NexusGroup.Data.Models;
using NexusGroup.Data.Repositories.Position;
using NexusGroup.Service.Base;
using NexusGroup.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Services.Position
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepositories _repositories;
        public PositionService(IPositionRepositories positionRepositories)
        {
            this._repositories = positionRepositories;
        }
        public async Task<ServiceResult> Add(AddPositionDTO dto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var entity = new M_Position
                {
                    Title = dto.Title
                };
                var rowsAffected = await _repositories.Add(entity);
                if (rowsAffected <= 0) 
                {
                    result.Success = false;
                    result.Message = "Failed to add position.";
                    return result;
                }
                result.Message = "Position added successfully";
                result.Data = entity;
            }
            catch (SqlException sqlexception)
            {
                new LogConfiguration.ExceptionServer("Added a Position.", sqlexception);
                result.Success = false;
                result.Message = "Error on DataBase.";
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                new LogConfiguration.ExceptionServer("Internal Error", ex);
                result.Success = false;
                result.Message = "Internal Error.";
                result.Data = ex.Message;
                return result;
            }
            return result;
        }

        public async Task<ServiceResult> Delete(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var rowsAffected = await _repositories.Delete(id);
                if(rowsAffected <= 0)
                {
                    result.Success = false;
                    result.Message = "Failed to delete the position.";
                    return result;
                }
                result.Message = "Position deleted successfully.";
            }
            catch (SqlException sqlexception)
            {
                new LogConfiguration.ExceptionServer("Deleted a Position.", sqlexception);
                result.Success = false;
                result.Message = "Error on DataBase.";
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                new LogConfiguration.ExceptionServer("Internal Error", ex);
                result.Success = false;
                result.Message = "Internal Error.";
                result.Data = ex.Message;
                return result;
            }
            return result;
        }

        public async Task<ServiceResult> DeletePermantly(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var rowsAffected = await _repositories.DeletePermantly(id);
                if (rowsAffected <= 0)
                {
                    result.Success = false;
                    result.Message = "Failed to delete permantly the position.";
                    return result;
                }
                result.Message = "Position deleted permantly successfully.";
            }
            catch (SqlException sqlexception)
            {
                new LogConfiguration.ExceptionServer("Deleted Permently a Position.", sqlexception);
                result.Success = false;
                result.Message = "Error on DataBase.";
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                new LogConfiguration.ExceptionServer("Internal Error", ex);
                result.Success = false;
                result.Message = "Internal Error.";
                result.Data = ex.Message;
                return result;
            }
            return result;
        }

        public async Task<ServiceResult> Edit(EditPositionDTO dto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var entity = new M_Position
                {
                    PositionID = dto.Id,
                    Title = dto.Title
                };
                var rowsAffected = await this._repositories.Edit(entity);
                if(rowsAffected <= 0)
                {
                    result.Success = false;
                    result.Message = "Failed to Edit the Position.";
                    return result;
                }
                result.Message = "Position was edit successfully.";
                result.Data = entity;
            }
            catch (SqlException sqlexception)
            {
                new LogConfiguration.ExceptionServer("Edit a Position.", sqlexception);
                result.Success = false;
                result.Message = "Error on DataBase.";
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                new LogConfiguration.ExceptionServer("Internal Error", ex);
                result.Success = false;
                result.Message = "Internal Error.";
                result.Data = ex.Message;
                return result;
            }
            return result;
        }

        public async Task<ServiceResult> Get(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var position = await this._repositories.GetValue(id);
                if (position == null)
                {
                    result.Success = false;
                    result.Message = "No item found";
                    result.Data = $"This id:{id} don't exists.";
                    return result;
                }
                result.Message = "Item Found";
                result.Data = position;
            }
            catch (SqlException sqlexception)
            {
                new LogConfiguration.ExceptionServer("Get a Position.", sqlexception);
                result.Success = false;
                result.Message = "Error on DataBase.";
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                new LogConfiguration.ExceptionServer("Internal Error", ex);
                result.Success = false;
                result.Message = "Internal Error.";
                result.Data = ex.Message;
                return result;
            }
            return result;
        }

        public async Task<ServiceResult> GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var positions = await this._repositories.GetAll();
                if(positions == null)
                {
                    result.Success = false;
                    result.Message = "No items found";
                    return result;
                }
                result.Message = "Items Found";
                result.Data = positions;
            }
            catch (SqlException sqlexception)
            {
                new LogConfiguration.ExceptionServer("GetAll a Position.", sqlexception);
                result.Success = false;
                result.Message = "Error on DataBase.";
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                new LogConfiguration.ExceptionServer("Internal Error", ex);
                result.Success = false;
                result.Message = "Internal Error.";
                result.Data = ex.Message;
                return result;
            }
            return result;  
        }

        public async Task<ServiceResult> GetAllDeletd()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var positions = await this._repositories.GetAll();
                if (positions == null)
                {
                    result.Success = false;
                    result.Message = "No items found";
                    return result;
                }
                result.Message = "Items Found";
                result.Data = positions;
            }
            catch (SqlException sqlexception)
            {
                new LogConfiguration.ExceptionServer("GetAll Deleted a Position.", sqlexception);
                result.Success = false;
                result.Message = "Error on DataBase.";
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                new LogConfiguration.ExceptionServer("Internal Error", ex);
                result.Success = false;
                result.Message = "Internal Error.";
                result.Data = ex.Message;
                return result;
            }
            return result;
        }

        public async Task<ServiceResult> Recover(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var rowsAffected = await this._repositories.Recover(id);
                if(rowsAffected <= 0)
                {
                    result.Success = false;
                    result.Message = "Failed to recover position";
                }
                result.Message = "Position was recovered successfully.";
            }
            catch (SqlException sqlexception)
            {
                new LogConfiguration.ExceptionServer("Recover a Position.", sqlexception);
                result.Success = false;
                result.Message = "Error on DataBase.";
                result.Data = sqlexception.Message;
                return result;

            }
            catch (Exception ex)
            {
                new LogConfiguration.ExceptionServer("Internal Error", ex);
                result.Success = false;
                result.Message = "Internal Error.";
                result.Data = ex.Message;
                return result;
            }
            return result;
        }
    }
}
