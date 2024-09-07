using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusGroup.Service.Base
{
    public static class ServiceMessages
    {
        //Mensajes de Exito
        public const string AddSuccess = "Added successfully.";
        public const string EditSuccess = "Edited successfully.";
        public const string DeleteSuccess = "Deleted successfully.";
        public const string RecoverSuccess = "Recovered successfully.";
        public const string GetAllSuccess = "Get All successfully";
        public const string GetValue = "Item Found";
        //Mensaje de Error
        public const string AddFail = "Failed to add.";
        public const string EditFail = "Failed to edit.";
        public const string DeleteFail = "Failed to delete.";
        public const string RecoverFail = "Failed to recover.";
        //Mensajes de Excepcion
        public const string NotFound = "The item was not found.";
        public const string NotFoundAll = "The List is empty";
        public const string DatabaseError = "Error in the database.";
        public const string InternalError = "Internal server error.";

        //Login
        public const string LoginSuccess = "Login success";
        public const string LoginFail = "Login failed, username or password incorrect";
        public const string PasswordSuccess = "Change Password successfully";
        public const string PasswordFail = "Failed to change password";
        public static string LogHelper(string accion, string table)
        {
            return GetErrorLog(accion, table);
        }
        private static string GetErrorLog(string type, string table)
        {
            return type switch
            {
                "add" => $"Failed to Add {table}",
                "edit" => $"Failed to Edit {table}",
                "delete" => $"Failed to Delete {table}",
                "perm" => $"Failed to Delete Permantly {table}",
                "get" => $"Failed to GetValue {table}",
                "all" => $"Failed to Get All {table}",
                "recover" => $"Failed to Recover {table}",
                "alld" => $"Failed to Get All Deleted {table}",
                _ => $"Error ocurred with {table}"
            };
        }
    }

}
