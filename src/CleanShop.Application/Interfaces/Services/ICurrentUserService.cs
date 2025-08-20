﻿namespace CleanShop.Application.Interfaces.Services
{
    public interface ICurrentUserService
    {
        string? UserId { get; }
        bool IsAuthenticated { get; }
    }
}