// ***********************************************************************
// Assembly         : CS.Common
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="CommonUtils.cs" company="CS.Common">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace CS.Common.Helpers
{
    /// <summary>
    ///     Class CommonUtils.
    /// </summary>
    public static class CommonUtils
    {
        /// <summary>
        ///     Converts the string array to string.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>System.String.</returns>
        public static string ConvertStringArrayToString(string[] array)
        {
            // Concatenate all the elements into a StringBuilder.
            var builder = new StringBuilder();
            foreach (var value in array)
            {
                builder.Append(value);
                builder.Append(';');
            }

            return builder.ToString();
        }

        public static string GetEnumMemberValue<T>(T value)
            where T : struct, IConvertible
        {
            return typeof(T)
                .GetTypeInfo()
                .DeclaredMembers
                .SingleOrDefault(x => x.Name == value.ToString())
                ?.GetCustomAttribute<EnumMemberAttribute>(false)
                ?.Value;
        }

        /// <summary>
        ///     Trims the string properties.
        /// </summary>
        /// <typeparam name="TSelf">The type of the t self.</typeparam>
        /// <param name="input">The input.</param>
        /// <returns>TSelf.</returns>
        public static TSelf TrimStringProperties<TSelf>(this TSelf input)
        {
            var stringProperties = input.GetType().GetProperties()
                .Where(p => p.PropertyType == typeof(string));

            foreach (var stringProperty in stringProperties)
            {
                var currentValue = (string)stringProperty.GetValue(input, null);
                if (currentValue != null)
                    stringProperty.SetValue(input, currentValue.Trim(), null);
            }

            return input;
        }
    }
}