﻿/* 
 * File: ObjectMixin.cs
 * 
 * Author: Akira Sugiura (urasandesu@gmail.com)
 * 
 * 
 * Copyright (c) 2012 Akira Sugiura
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

namespace Urasandesu.NAnonym.Mixins.System
{
    public static class ObjectMixin
    {
        const string MethodName_MemberwiseClone = "MemberwiseClone";

        class MethodDelegate_MemberwiseClone
        {
            public static readonly Exec Invoke = typeof(Object).GetMethodDelegate(MethodName_MemberwiseClone, Type.EmptyTypes);
        }

        public static Object MemberwiseClone(this Object source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return MethodDelegate_MemberwiseClone.Invoke(source, null);
        }

        public static Object SmartlyClone(this Object source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var cloneable = source as ICloneable;
            if (cloneable != null)
                return cloneable.Clone();

            var valueType = source as ValueType;
            if (valueType != null)
                return valueType.Clone();

            return source;
        }

        public static TResult Maybe<T, TResult>(this T @this, Func<T, TResult> invoker) where T : class
        {
            return Maybe(@this, invoker, default(TResult));
        }

        public static TResult Maybe<T, TResult>(this T @this, Func<T, TResult> invoker, TResult defaultResult) where T : class
        {
            if (invoker == null)
                throw new ArgumentNullException("invoker");

            if (@this == null)
                return defaultResult;

            return invoker(@this);
        }

        public static int GetHashCode<T>(T @this)
        {
            return @this != null ? @this.GetHashCode() : 0;
        }

        public static int NullableGetHashCode<T>(this T @this)
        {
            return @this != null ? @this.GetHashCode() : 0;
        }
    }
}
