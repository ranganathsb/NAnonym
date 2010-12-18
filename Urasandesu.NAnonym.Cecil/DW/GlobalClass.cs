/* 
 * File: GlobalClass.cs
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
using System.Linq.Expressions;
using Urasandesu.NAnonym.DW;
using Urasandesu.NAnonym.Mixins.System;

namespace Urasandesu.NAnonym.Cecil.DW
{
    // GlobalClass が Generic Type 持っちゃうから、共通で引き回せるような口用。
    public abstract class GlobalClass : DependencyClass
    {
        public static readonly string CacheFieldPrefix = "UNCD$<>0__Cached";
        public static readonly string MethodPrefix = "UNCD$<>0__Method";
        protected internal abstract string CodeBase { get; }
        protected internal abstract string Location { get; }

        public GlobalFieldInt DefineField(Expression<Func<int>> methodReference) { return new GlobalFieldInt(this, methodReference); }
        public GlobalField<T> DefineField<T>(Expression<Func<T>> methodReference) { return new GlobalField<T>(this, methodReference); }
        protected sealed override void OnLoad(DependencyClassLoadParameter parameter)
        {
            OnLoadGlobal((GlobalClassLoadParameter)parameter);
        }

        protected virtual void OnLoadGlobal(GlobalClassLoadParameter parameter)
        {
        }
    }

    public class GlobalClass<TBase> : GlobalClass
    {
        Action<GlobalClass<TBase>> setupper;
        public void Setup(Action<GlobalClass<TBase>> setupper)
        {
            this.setupper = Required.NotDefault(setupper, () => setupper);
        }

        protected override DependencyClass OnRegister()
        {
            setupper(this);
            return null;
        }

        public GlobalHideFunc<TBase, TResult> HideMethod<TResult>(Expression<FuncReference<TBase, TResult>> methodReference)
        {
            var method = TypeSavable.ExtractMethod(methodReference);
            var source = typeof(TBase).GetMethod(method);
            return new GlobalHideFunc<TBase,TResult>(this, source);
        }

        public GlobalHideFunc<TBase, T, TResult> HideMethod<T, TResult>(Expression<FuncReference<TBase, T, TResult>> methodReference)
        {
            var method = TypeSavable.ExtractMethod(methodReference);
            var source = typeof(TBase).GetMethod(method);
            return new GlobalHideFunc<TBase, T, TResult>(this, source);
        }

        public GlobalHideFunc<TBase, T1, T2, TResult> HideMethod<T1, T2, TResult>(Expression<FuncReference<TBase, T1, T2, TResult>> methodReference)
        {
            var method = TypeSavable.ExtractMethod(methodReference);
            var source = typeof(TBase).GetMethod(method);
            return new GlobalHideFunc<TBase, T1, T2, TResult>(this, source);
        }

        public GlobalHideFunc<TBase, T1, T2, T3, TResult> HideMethod<T1, T2, T3, TResult>(Expression<FuncReference<TBase, T1, T2, T3, TResult>> methodReference)
        {
            var method = TypeSavable.ExtractMethod(methodReference);
            var source = typeof(TBase).GetMethod(method);
            return new GlobalHideFunc<TBase, T1, T2, T3, TResult>(this, source);
        }

        public GlobalHideFunc<TBase, T1, T2, T3, T4, TResult> HideMethod<T1, T2, T3, T4, TResult>(Expression<FuncReference<TBase, T1, T2, T3, T4, TResult>> methodReference)
        {
            var method = TypeSavable.ExtractMethod(methodReference);
            var source = typeof(TBase).GetMethod(method);
            return new GlobalHideFunc<TBase, T1, T2, T3, T4, TResult>(this, source);
        }

        public GlobalHideAction<TBase> HideMethod(Expression<ActionReference<TBase>> methodReference)
        {
            var method = TypeSavable.ExtractMethod(methodReference);
            var source = typeof(TBase).GetMethod(method);
            return new GlobalHideAction<TBase>(this, source);
        }

        public GlobalHideAction<TBase, T> HideMethod<T>(Expression<ActionReference<TBase, T>> methodReference)
        {
            var method = TypeSavable.ExtractMethod(methodReference);
            var source = typeof(TBase).GetMethod(method);
            return new GlobalHideAction<TBase, T>(this, source);
        }

        public GlobalHideAction<TBase, T1, T2> HideMethod<T1, T2>(Expression<ActionReference<TBase, T1, T2>> methodReference)
        {
            var method = TypeSavable.ExtractMethod(methodReference);
            var source = typeof(TBase).GetMethod(method);
            return new GlobalHideAction<TBase, T1, T2>(this, source);
        }

        public GlobalHideAction<TBase, T1, T2, T3> HideMethod<T1, T2, T3>(Expression<ActionReference<TBase, T1, T2, T3>> methodReference)
        {
            var method = TypeSavable.ExtractMethod(methodReference);
            var source = typeof(TBase).GetMethod(method);
            return new GlobalHideAction<TBase, T1, T2, T3>(this, source);
        }

        public GlobalHideAction<TBase, T1, T2, T3, T4> HideMethod<T1, T2, T3, T4>(Expression<ActionReference<TBase, T1, T2, T3, T4>> methodReference)
        {
            var method = TypeSavable.ExtractMethod(methodReference);
            var source = typeof(TBase).GetMethod(method);
            return new GlobalHideAction<TBase, T1, T2, T3, T4>(this, source);
        }

        public GlobalBeforeFunc<TBase, TResult> BeforeMethod<TResult>(Expression<FuncReference<TBase, TResult>> methodReference)
        {
            var method = TypeSavable.ExtractMethod(methodReference);
            var source = typeof(TBase).GetMethod(method);
            return new GlobalBeforeFunc<TBase, TResult>(this, source);
        }

        public GlobalBeforeFunc<TBase, T, TResult> BeforeMethod<T, TResult>(Expression<FuncReference<TBase, T, TResult>> methodReference)
        {
            var method = TypeSavable.ExtractMethod(methodReference);
            var source = typeof(TBase).GetMethod(method);
            return new GlobalBeforeFunc<TBase, T, TResult>(this, source);
        }

        public GlobalAfterFunc<TBase, TResult> AfterMethod<TResult>(Expression<FuncReference<TBase, TResult>> methodReference)
        {
            var method = TypeSavable.ExtractMethod(methodReference);
            var source = typeof(TBase).GetMethod(method);
            return new GlobalAfterFunc<TBase, TResult>(this, source);
        }

        public GlobalAfterFunc<TBase, T, TResult> AfterMethod<T, TResult>(Expression<FuncReference<TBase, T, TResult>> methodReference)
        {
            var method = TypeSavable.ExtractMethod(methodReference);
            var source = typeof(TBase).GetMethod(method);
            return new GlobalAfterFunc<TBase, T, TResult>(this, source);
        }



        protected override void OnLoadGlobal(GlobalClassLoadParameter parameter)
        {
            var globalClassTypeGen = parameter.Assembly.Module.Types.FirstOrDefault(typeGen => typeGen.AssemblyQualifiedName == typeof(TBase).AssemblyQualifiedName);

            var constructorWeaver = new GlobalConstructorWeaver(globalClassTypeGen, FieldSet);
            constructorWeaver.Apply();

            var methodWeaver = new GlobalMethodWeaver(constructorWeaver, MethodSet);
            methodWeaver.Apply();
        }

        protected internal override string CodeBase
        {
            get { return typeof(TBase).Assembly.CodeBase; }
        }

        protected internal override string Location
        {
            get { return typeof(TBase).Assembly.Location; }
        }
    }
}

