﻿using API.Models;
using BeaversDB.Model;
using System.Net;

namespace API.Converters;

public static class BeaverExtensions
{
    public static BeaverModel ToModel(this Beaver beaver)
    {
        return new BeaverModel
        {
            Id = beaver.Id,
            Name = beaver.Name,
            Age = beaver.Age,
            Fluffiness = beaver.Fluffiness.ToString(),
            Size = beaver.Size
        };
    }

    public static Beaver ToEntity(this BeaverModel beaver)
    {
        return new Beaver
        {
            Name = beaver.Name,
            Fluffiness = Enum.Parse<FluffinessEnum>(beaver.Fluffiness),
            Size = beaver.Size,
            Age = beaver.Age,
            IpAddress = IPAddress.Parse("127.0.0.1")
        };
    }

    public static string GetFluffiness(this Beaver beaver)
    {
        return beaver.Fluffiness.ToString();
    }
}