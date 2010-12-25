/* 
 * File: ExpressiveGeneratorMixin.cs
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Urasandesu.NAnonym.ILTools;
using System.Linq.Expressions;
using System.Reflection;
using SRE = System.Reflection.Emit;

namespace Urasandesu.NAnonym.Mixins.Urasandesu.NAnonym.ILTools
{
    public static class ExpressiveGeneratorMixin
    {
        static readonly FieldInfo OpcodesRetInfo = typeof(SRE::OpCodes).GetField("Ret");
        static readonly MethodInfo ILGeneratorEmit = typeof(SRE::ILGenerator).GetMethod("Emit", BindingFlags.Public | BindingFlags.Instance, null, new Type[] { typeof(SRE::OpCode) }, null);

        internal static void ExpressBodyEnd(this ExpressiveGenerator gen, Action<ExpressiveGenerator> expression)
        {
            expression(gen);
            if (gen.Directives.Last().OpCode != OpCodes.Ret)
            {
                gen.Eval(_ => _.End());
            }
        }

        public static void ExpressEmit(this ExpressiveGenerator gen, Expression<Func<SRE::ILGenerator>> ilIdentifier, Action<GenerativeEmitter> expression)
        {
            var ilName = TypeSavable.GetName(ilIdentifier);
            expression(new GenerativeEmitter(gen, ilName));

            var lastDirectives = gen.Directives.Skip(gen.Directives.Count - 3).ToArray();

            var localDecl = default(ILocalDeclaration);
            var isLastDirectives0Ldloc = 
                lastDirectives[0].OpCode == OpCodes.Ldloc && 
                (localDecl = lastDirectives[0].NAnonymOperand as ILocalDeclaration) != null && localDecl.Name == ilName;
            
            var fieldInfo = default(FieldInfo);
            var isLastDirectives1Ldsfld = 
                lastDirectives[1].OpCode == OpCodes.Ldsfld && 
                (fieldInfo = lastDirectives[1].ClrOperand as FieldInfo) != null && fieldInfo == OpcodesRetInfo;
            
            var methodInfo = default(MethodInfo);
            var isLastDirectives2Callvirt = 
                lastDirectives[2].OpCode == OpCodes.Callvirt && 
                (methodInfo = lastDirectives[2].ClrOperand as MethodInfo) != null && methodInfo == ILGeneratorEmit;

            if (!isLastDirectives0Ldloc || !isLastDirectives1Ldsfld || !isLastDirectives2Callvirt)
            {
                gen.Eval(_ => _.Ld<SRE::ILGenerator>(ilName).Emit(SRE::OpCodes.Ret));
            }
        }

        public static void ExpressReflection(this ExpressiveGenerator gen, Action<ReflectiveDesigner> expression)
        {
            expression(new ReflectiveDesigner(gen));
            if (gen.Directives.Last().OpCode != OpCodes.Ret)
            {
                gen.Eval(_ => _.End());
            }
        }
    }
}
