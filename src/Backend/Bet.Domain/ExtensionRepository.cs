﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Domain;
public static class ExtensionRepository
{
    public static string GetDataBaseName(this IConfiguration configurationManager)
    {
        var databaseName = configurationManager.GetConnectionString("DataBaseName");

        return databaseName;
    }

    public static string GetConnection(this IConfiguration configurationManager)
    {
        var connection = configurationManager.GetConnectionString("Connection");

        return connection;
    }
    public static string GetConnection2(this IConfiguration configurationManager)
    {
        var connection = configurationManager.GetConnectionString("Connection2");

        return connection;
    }

    public static string GetFullConnection(this IConfiguration configurationManager)
    {
        var databaseName = configurationManager.GetDataBaseName();
        var connection = configurationManager.GetConnection();

        return $"{connection}Database={databaseName}";
    }
}