﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;
using System.Reflection.Emit;
using Urasandesu.NAnonym.ILTools;
using SR = System.Reflection;

namespace Urasandesu.NAnonym.DI
{
    public sealed class LocalClass<TBase> where TBase : class
    {
        readonly Type tbaseType = typeof(TBase);

        internal HashSet<TargetInfo> TargetInfoSet { get; private set; }

        Type createdType;

        // TODO: LocalClassBase もたぶん必要。Generic な型に、型パラメータ関係ない処理を括りだした I/F クラスがあると便利なのが世の常。
        public void Load()
        {
            var localClassAssemblyName = new AssemblyName("LocalClassAssembly");
            var localClassAssemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(localClassAssemblyName, AssemblyBuilderAccess.Run);
            var localClassModuleBuilder = localClassAssemblyBuilder.DefineDynamicModule("LocalClassModule");
            var localClassTypeBuilder = localClassModuleBuilder.DefineType("LocalClassType");
            if (tbaseType.IsInterface)
            {
                localClassTypeBuilder.AddInterfaceImplementation(tbaseType);
            }
            else
            {
                throw new NotImplementedException();
            }

            var localClassConstructorBuilder = localClassTypeBuilder.DefineConstructor(
                                                    MethodAttributes.Public | 
                                                    MethodAttributes.HideBySig | 
                                                    MethodAttributes.SpecialName | 
                                                    MethodAttributes.RTSpecialName, 
                                                    CallingConventions.Standard, 
                                                    new Type[] { });
            localClassConstructorBuilder.ExpressBody(
            gen =>
            {
                gen.Eval(_ => _.Base());
            });

            foreach (var targetInfo in TargetInfoSet)
            {
                switch (targetInfo.Mode)
                {
                    case SetupMode.Override:
                        throw new NotImplementedException();
                    case SetupMode.Replace:
                        throw new NotSupportedException();
                    case SetupMode.Implement:
                        {
                            var methodBuilder = localClassTypeBuilder.DefineMethod(
                                                    targetInfo.OldMethod.Name,
                                                    MethodAttributes.Public |
                                                    MethodAttributes.HideBySig |
                                                    MethodAttributes.NewSlot |
                                                    MethodAttributes.Virtual |
                                                    MethodAttributes.Final,
                                                    CallingConventions.HasThis,
                                                    targetInfo.OldMethod.ReturnType,
                                                    targetInfo.OldMethod.ParameterTypes());
                            // とりあえず
                            var parameterBuilder = methodBuilder.DefineParameter(1, ParameterAttributes.In, targetInfo.OldMethod.ParameterNames()[0]);
                            methodBuilder.ExpressBody(
                            gen =>
                            {
                                var CS_d__lt__rt_9__CachedAnonymousMethodDelegate1Method = default(DynamicMethod);
                                gen.Eval(_ => _.Addloc(CS_d__lt__rt_9__CachedAnonymousMethodDelegate1Method, new DynamicMethod("CS$<>9__CachedAnonymousMethodDelegate1Method", typeof(string), new Type[] { typeof(string) }, true)));
                                var method4 = default(MethodInfo);
                                gen.Eval(_ => _.Addloc(method4, typeof(System.Func<,>).MakeGenericType(typeof(String), typeof(String)).GetMethod(
                                                                    "Invoke",
                                                                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                                                                    null,
                                                                    new Type[] 
                                                                    { 
                                                                        typeof(String) 
                                                                    }, null)));
                                var tmpCacheField = TypeAnalyzer.GetCacheFieldIfAnonymousByRunningState(targetInfo.NewMethod);
                                var cacheField = default(FieldInfo);
                                gen.Eval(_ => _.Addloc(cacheField, Type.GetType(_.Expand(tmpCacheField.DeclaringType.AssemblyQualifiedName)).GetField(
                                                                    _.Expand(tmpCacheField.Name),
                                                                    BindingFlags.NonPublic | BindingFlags.Static)));
                                var targetMethod = default(MethodInfo);
                                gen.Eval(_ => _.Addloc(targetMethod, Type.GetType(_.Expand(targetInfo.OldMethod.DeclaringType.AssemblyQualifiedName)).GetMethod(
                                                                    _.Expand(targetInfo.OldMethod.Name),
                                                                    BindingFlags.NonPublic | BindingFlags.Static)));
                                var il = default(ILGenerator);
                                gen.Eval(_ => _.Addloc(il, CS_d__lt__rt_9__CachedAnonymousMethodDelegate1Method.GetILGenerator()));
                                gen.Eval(_ => il.Emit(SR::Emit.OpCodes.Ldsfld, cacheField));
                                gen.Eval(_ => il.Emit(SR::Emit.OpCodes.Ldarg_0));
                                gen.Eval(_ => il.Emit(SR::Emit.OpCodes.Callvirt, method4));
                                gen.Eval(_ => il.Emit(SR::Emit.OpCodes.Ret));
                                var CS_d__lt__rt_9__CachedAnonymousMethodDelegate1Invoker = default(Func<string, string>);
                                gen.Eval(_ => _.Addloc(CS_d__lt__rt_9__CachedAnonymousMethodDelegate1Invoker, (Func<string, string>)CS_d__lt__rt_9__CachedAnonymousMethodDelegate1Method.CreateDelegate(typeof(Func<string, string>))));
                                gen.Eval(_ => _.Return(CS_d__lt__rt_9__CachedAnonymousMethodDelegate1Invoker.Invoke(_.ExpandAndLdarg<string>(targetInfo.OldMethod.ParameterNames()[0]))));

                                // HACK: Expand ～ シリーズはもう少し種類があると良さげ。
                            },
                            parameterBuilder);
                        }
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }
            createdType = localClassTypeBuilder.CreateType();
        }

        public LocalClass()
        {
            TargetInfoSet = new HashSet<TargetInfo>();
        }

        public LocalClass<TBase> Setup(Action<LocalClass<TBase>> setupper)
        {
            Required.NotDefault(setupper, () => setupper);
            setupper(this);
            return this;
        }


        //// HACK: method は MethodInfo と間違いやすい。汎用デリゲートについてはもう、Action -> action、Func -> func みたいな変数命名規則にしたほうがいいかも？
        //public LocalMethod<TBase> Method(Action method)
        //{
        //    throw new NotImplementedException();
        //}

        //public LocalMethod<TBase, TResult> Method<TResult>(Func<TResult> method)
        //{
        //    throw new NotImplementedException();
        //}

        //public LocalMethod<TBase, T, TResult> Method<T, TResult>(Func<T, TResult> func)
        //{
        //    return new LocalMethod<TBase, T, TResult>(this, func);
        //}

        public LocalMethod<TBase, T, TResult> Method<T, TResult>(Expression<Func<TBase, Func<T, TResult>>> expression)
        {
            var method = DependencyUtil.ExtractMethod(expression);
            var oldMethod = typeof(TBase).GetMethod(method);
            return new LocalMethod<TBase, T, TResult>(this, oldMethod);
        }


        public LocalPropertyGet<TBase, T> Property<T>(Func<T> propertyGet)
        {
            throw new NotImplementedException();
        }

        public LocalPropertySet<TBase, T> Property<T>(Action<T> propertySet)
        {
            throw new NotImplementedException();
        }

        

        public TBase New()
        {
            return (TBase)createdType.GetConstructor(new Type[] { }).Invoke(new object[] { });
        }
    }
}
