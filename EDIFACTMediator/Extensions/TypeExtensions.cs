﻿namespace SWMS.EDISolution.Module.Extensions;

public static class TypeExtensions
{
    public static IEnumerable<Type> GetImplementingTypes(this Type type)
    {
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .Where(a => !a.FullName.StartsWith("System"))
            .SelectMany(s => s.GetTypes())
            .Where(p => p != null && type.IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract)
            .ToList();

        return types;
    }

    public static bool IsListType(this Type type)
    {
        return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
    }

    public static bool IsComplexType(this Type type)
    {
        return !type.IsSimpleType() && !type.IsListType();
    }

    public static bool IsSimpleType(this Type type)
    {
        return type.IsPrimitive || type == typeof(string) || type == typeof(DateTime);
    }
}
