
//import controller StatusCode
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Services
{
    public class StatusMessageService<T> : IStatusMessageService<T> where T : class
    {
        public StatusMessage NoneFound() => new() 
        { 
            Message = $"No {typeof(T).Name}s found!" 
        };
        public StatusMessage AlreadyExists() => new()
        {
            Message = $"{typeof(T).Name} already exists!"
        };
        public StatusMessage NotFound(int id) => new()
        {
            Message = $"{typeof(T).Name} with id:'{id}' doesn't exist!"
        };
        public StatusMessage Deleted(int id) => new()
        {
            Message = $"{typeof(T).Name} with id:'{id}' was deleted and everything related to it!"
        };
        public StatusMessage NotUnique() => new()
        {
            Message = $"{typeof(T).Name} has a property that is not unique, but should be!"
        };
        public StatusMessage GenericError() => new()
        {
            Message = "There was a problem!"
        };
        public StatusMessage ANotExistingIdProvided() => new()
        {
            Message = "At least one Id was provided that does not exist in our system!"
        };
    }
}
