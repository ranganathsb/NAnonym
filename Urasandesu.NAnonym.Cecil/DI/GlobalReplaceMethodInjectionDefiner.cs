﻿using System.Linq;
using Urasandesu.NAnonym.Cecil.ILTools.Impl.Mono.Cecil;
using Urasandesu.NAnonym.Cecil.ILTools.Mixins.Mono.Cecil;
using Urasandesu.NAnonym.DI;
using UNI = Urasandesu.NAnonym.ILTools;

namespace Urasandesu.NAnonym.Cecil.DI
{
    class GlobalReplaceMethodInjectionDefiner : GlobalMethodInjectionDefiner
    {
        public GlobalReplaceMethodInjectionDefiner(GlobalMethodInjection parent, InjectionMethodInfo injectionMethod)
            : base(parent, injectionMethod)
        {
        }

        protected override UNI::IMethodGenerator GetMethodInterface()
        {
            var declaringTypeDef = ((MCTypeGeneratorImpl)Parent.ConstructorInjection.DeclaringTypeGenerator).TypeDef;
            var source = declaringTypeDef.Methods.FirstOrDefault(methodDef => methodDef.Equivalent(InjectionMethod.Source));
            string sourceName = source.Name;
            source.Name = "__" + source.Name;
            baseMethod = new MCMethodGeneratorImpl(source);

            var destination = source.DuplicateWithoutBody();
            destination.Name = sourceName;
            declaringTypeDef.Methods.Add(destination);
            var destinationGen = new MCMethodGeneratorImpl(destination);

            return destinationGen;
        }

        UNI::IMethodDeclaration baseMethod;
        public override UNI::IMethodDeclaration BaseMethod
        {
            get { return baseMethod; }
        }
    }
}
