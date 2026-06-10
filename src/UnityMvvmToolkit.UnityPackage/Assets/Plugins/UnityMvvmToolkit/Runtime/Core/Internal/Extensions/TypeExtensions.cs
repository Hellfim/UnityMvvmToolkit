using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace UnityMvvmToolkit.Core.Internal.Extensions
{
    internal static class TypeExtensions
    {
        /// <summary>
        /// Gets all members from a given type, including members from all base types if the <see cref="F:System.Reflection.BindingFlags.DeclaredOnly" /> flag isn't set.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MemberInfo[] GetAllMembers(this Type type, BindingFlags flags = BindingFlags.Default)
        {
            if ((flags & BindingFlags.DeclaredOnly) == BindingFlags.DeclaredOnly)
            {
                return type.GetMembers(flags);
            }

            flags |= BindingFlags.DeclaredOnly;

            var currentType = type;
            var members = new List<MemberInfo>();
            do
            {
                members.AddRange(currentType.GetMembers(flags).Where(m => !IsAbstractMember(m)));
                currentType = currentType.BaseType;
            }
            while (currentType != null);

            return members.ToArray();
        }

        private static bool IsAbstractMember(MemberInfo member)
        {
            return member switch
            {
                MethodInfo method => method.IsAbstract,
                PropertyInfo property => property.GetMethod?.IsAbstract == true || property.SetMethod?.IsAbstract == true,
                EventInfo @event => @event.AddMethod?.IsAbstract == true || @event.RemoveMethod?.IsAbstract == true,
                Type type => type.IsAbstract,
                _ => false
            };
        }
    }
}