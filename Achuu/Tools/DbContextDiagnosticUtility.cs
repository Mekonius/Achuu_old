using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

public static class DbContextDiagnosticUtility
{
    public static void CheckDbContextUsage(Type targetType)
    {
        var asyncMethods = targetType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Where(m => m.GetCustomAttributes(typeof(AsyncStateMachineAttribute), false).Any());

        foreach (var method in asyncMethods)
        {
            var dbContextParameters = method.GetParameters()
                .Where(p => typeof(DbContext).IsAssignableFrom(p.ParameterType));

            if (dbContextParameters.Any())
            {
                Console.WriteLine($"Potential issue found in method: {method.Name}");
                Console.WriteLine($"Method uses DbContext parameters: {string.Join(", ", dbContextParameters.Select(p => p.Name))}");
            }
        }
    }
}
