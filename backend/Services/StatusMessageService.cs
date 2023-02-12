// import controller StatusCode
using backend.Interfaces.Services;
using backend.Models;

namespace backend.Services;

public class StatusMessageService<T> : IStatusMessageService<T>
    where T : class
{
    public StatusMessage NoneFound()
    {
        return new()
        {
            Message = $"No {typeof(T).Name}s found!"
        };
    }

    public StatusMessage AlreadyExists()
    {
        return new()
        {
            Message = $"{typeof(T).Name} already exists!"
        };
    }

    public StatusMessage NotFound(int id)
    {
        return new()
        {
            Message = $"{typeof(T).Name} with id:'{id}' doesn't exist!"
        };
    }

    public StatusMessage Deleted(int id)
    {
        return new()
        {
            Message = $"{typeof(T).Name} with id:'{id}' was deleted and everything related to it!"
        };
    }

    public StatusMessage NotUnique()
    {
        return new()
        {
            Message = $"{typeof(T).Name} has a property that is not unique, but should be!"
        };
    }

    public StatusMessage GenericError()
    {
        return new()
        {
            Message = "There was a problem!"
        };
    }

    public StatusMessage ANotExistingIdProvided()
    {
        return new()
        {
            Message = "At least one Id was provided that does not exist in our system!"
        };
    }
}