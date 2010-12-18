﻿/* 
 * File: GlobalHideFunc.cs
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
using System.Reflection;
using Urasandesu.NAnonym.DW;

namespace Urasandesu.NAnonym.Cecil.DW
{
    public class GlobalHideFunc<TBase, TResult> : GlobalMethod
    {
        public GlobalHideFunc(GlobalClass<TBase> globalClass, MethodInfo source)
            : base(globalClass, source)
        {
        }

        public GlobalClass<TBase> By(Func<TResult> destination)
        {
            return (GlobalClass<TBase>)HideBy((Delegate)destination);
        }
    }

    public class GlobalHideFunc<TBase, T, TResult> : GlobalMethod
    {
        public GlobalHideFunc(GlobalClass<TBase> globalClass, MethodInfo source)
            : base(globalClass, source)
        {
        }

        public GlobalClass<TBase> By(Func<T, TResult> destination)
        {
            return (GlobalClass<TBase>)HideBy((Delegate)destination);
        }
    }

    public class GlobalHideFunc<TBase, T1, T2, TResult> : GlobalMethod
    {
        public GlobalHideFunc(GlobalClass<TBase> globalClass, MethodInfo source)
            : base(globalClass, source)
        {
        }

        public GlobalClass<TBase> By(Func<T1, T2, TResult> destination)
        {
            return (GlobalClass<TBase>)HideBy((Delegate)destination);
        }

        public GlobalClass<TBase> By(FuncWithPrev<T1, T2, TResult> destination)
        {
            return (GlobalClass<TBase>)HideBy((Delegate)destination);
        }
    }

    public class GlobalHideFunc<TBase, T1, T2, T3, TResult> : GlobalMethod
    {
        public GlobalHideFunc(GlobalClass<TBase> globalClass, MethodInfo source)
            : base(globalClass, source)
        {
        }

        public GlobalClass<TBase> By(Func<T1, T2, T3, TResult> destination)
        {
            return (GlobalClass<TBase>)HideBy((Delegate)destination);
        }
    }

    public class GlobalHideFunc<TBase, T1, T2, T3, T4, TResult> : GlobalMethod
    {
        public GlobalHideFunc(GlobalClass<TBase> globalClass, MethodInfo source)
            : base(globalClass, source)
        {
        }

        public GlobalClass<TBase> By(Func<T1, T2, T3, T4, TResult> destination)
        {
            return (GlobalClass<TBase>)HideBy((Delegate)destination);
        }
    }
}
