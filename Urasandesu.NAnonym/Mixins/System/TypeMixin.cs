/* 
 * File: TypeMixin.cs
 * 
 * Author: Akira Sugiura (urasandesu@gmail.com)
 * 
 * 
 * Copyright (c) 2010 Akira Sugiura
 *  
 *  This software is MIT License.
 *  
 *  Permission is hereby granted, free of charge, to any person obtaining a copy
 *  of this software and associated documentation files (the "Software"), to deal
 *  in the Software without restriction, including without limitation the rights
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *  copies of the Software, and to permit persons to whom the Software is
 *  furnished to do so, subject to the following conditions:
 *  
 *  The above copyright notice and this permission notice shall be included in
 *  all copies or substantial portions of the Software.
 *  
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 *  THE SOFTWARE.
 */
 

using System;
using System.Linq;
using System.Reflection;
using Urasandesu.NAnonym.Mixins.System.Reflection;
using Urasandesu.NAnonym.ILTools;
using Urasandesu.NAnonym.ILTools.Impl.System.Reflection;

namespace Urasandesu.NAnonym.Mixins.System
{
    public static class TypeMixin
    {
        public static MethodInfo GetMethod(this Type type, MethodInfo methodInfo)
        {
            return type.GetMethod(
                            methodInfo.Name,
                            methodInfo.ExportBinding(),
                            null,
                            methodInfo.GetParameters().Select(parameter => parameter.ParameterType).ToArray(),
                            null);
        }

        public static readonly BindingFlags StaticNonPublic = BindingFlags.Static | BindingFlags.NonPublic;
        public static readonly BindingFlags InstancePublic = BindingFlags.Instance | BindingFlags.Public;
        public static readonly BindingFlags InstanceNonPublic = BindingFlags.Instance | BindingFlags.NonPublic;

        public static MethodInfo GetMethodStaticNonPublic(this Type type, string name, Type[] types)
        {
            return type.GetMethod(name, StaticNonPublic, null, types, null);
        }

        public static MethodInfo GetMethodInstancePublic(this Type type, string name, Type[] types)
        {
            return type.GetMethod(name, InstancePublic, null, types, null);
        }

        public static FieldInfo GetFieldStaticNonPublic(this Type type, string name)
        {
            return type.GetField(name, StaticNonPublic);
        }

        public static FieldInfo GetFieldInstanceNonPublic(this Type type, string name)
        {
            return type.GetField(name, InstanceNonPublic);
        }

        public static bool IsAssignableFrom(this Type source, ITypeDeclaration target)
        {
            if (source.Equivalent(target))
            {
                return true;
            }
            else
            {
                return source.IsAssignableFrom(target.BaseType);
            }
        }

        public static bool Equivalent(this Type source, ITypeDeclaration target)
        {
            if (source == null && target == null) return true;
            if (source == null || target == null) return false;
            return source.AssemblyQualifiedName == target.AssemblyQualifiedName;
        }

        public static bool Equivalent(this Type source, Type target)
        {
            if (!source.IsGenericTypeDefinition)
            {
                return source == target;
            }
            else
            {
                return target.Name == source.Name &&
                       target.IsGenericType &&
                       target.GetGenericArguments().Length == source.GetGenericArguments().Length &&
                       target == source.MakeGenericType(target.GetGenericArguments());
            }
        }

        public static bool EquivalentWithoutGenericArguments(this Type source, Type target)
        {
            if (!source.IsGenericType)
            {
                return source == target;
            }
            else
            {
                return target.Name == source.Name &&
                       target.IsGenericType &&
                       target.GetGenericArguments().Length == source.GetGenericArguments().Length;
            }
        }

        public static bool EquivalentGenericParameterPosition(this Type source, Type target)
        {
            if (!source.IsGenericParameter && !target.IsGenericParameter)
            {
                return true;
            }
            else if (!source.IsGenericParameter || !target.IsGenericParameter)
            {
                return false;
            }
            else
            {
                return source.GenericParameterPosition == target.GenericParameterPosition;
            }
        }

        public static bool IsAssignableWithoutGenericArgumentsFrom(this Type source, Type target)
        {
            if (!source.IsGenericType || !target.IsGenericType)
            {
                return source.IsAssignableFrom(target);
            }
            else
            {
                return source.GetGenericTypeDefinition().IsAssignableFrom(target.GetGenericTypeDefinition());
            }
        }

        public static ITypeDeclaration ToTypeDecl(this Type source)
        {
            return new SRTypeDeclarationImpl(source);
        }
    }
}

