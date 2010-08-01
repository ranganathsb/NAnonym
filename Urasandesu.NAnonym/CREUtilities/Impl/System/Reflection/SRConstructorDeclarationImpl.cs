﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Reflection.Emit;

namespace Urasandesu.NAnonym.CREUtilities.Impl.System.Reflection
{
    class SRConstructorDeclarationImpl : SRMethodBaseDeclarationImpl, IConstructorDeclaration
    {
        readonly ConstructorInfo constructorInfo;

        readonly ITypeDeclaration declaringTypeDecl;
        readonly IMethodBodyDeclaration bodyDecl;
        readonly IMethodBodyDeclaration methodBodyMaker;
        public SRConstructorDeclarationImpl(ConstructorInfo constructorInfo)
            : base(constructorInfo)
        {
            this.constructorInfo = constructorInfo;
            declaringTypeDecl = (SRTypeDeclarationImpl)constructorInfo.DeclaringType;
            bodyDecl = null;
            methodBodyMaker = null;
        }

        public static explicit operator SRConstructorDeclarationImpl(ConstructorInfo constructorInfo)
        {
            return new SRConstructorDeclarationImpl(constructorInfo);
        }

        public static explicit operator ConstructorInfo(SRConstructorDeclarationImpl methodDecl)
        {
            return methodDecl.constructorInfo;
        }
    }
}
