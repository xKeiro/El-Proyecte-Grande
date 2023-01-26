﻿using ElProyecteGrande.Models;

namespace ElProyecteGrande.Interfaces.Services
{
    public interface IStatusMessageService<T> where T: class
    {
        StatusMessage AlreadyExists();
        StatusMessage Deleted(int id);
        StatusMessage NoneFound();
        StatusMessage NotFound(int id);
        StatusMessage NotUnique();
        StatusMessage GenericError();
    }
}