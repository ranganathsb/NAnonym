/* 
 * File: MCMemberDeclarationImpl.cs
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
using Mono.Cecil;
using System.Runtime.Serialization;
using UN = Urasandesu.NAnonym;
using UNI = Urasandesu.NAnonym.ILTools;

namespace Urasandesu.NAnonym.Cecil.ILTools.Impl.Mono.Cecil
{
    [Serializable]
    class MCMemberDeclarationImpl : UN::ManuallyDeserializable, UNI::IMemberDeclaration
    {
        [NonSerialized]
        MemberReference memberRef;
        UNI::ITypeDeclaration declaringType;

        public MCMemberDeclarationImpl(MemberReference memberRef)
            : base(true)
        {
            Initialize(memberRef);
        }

        void Initialize(MemberReference memberRef)
        {
            Required.NotDefault(memberRef, () => memberRef);
            this.memberRef = memberRef;
        }

        public string Name
        {
            get { return memberRef.Name; }
        }

        protected override void OnDeserializedManually(StreamingContext context)
        {
            var memberRef = default(MemberReference);
            if ((memberRef = context.Context as MemberReference) != null)
            {
                Initialize(memberRef);
            }
        }

        public MemberReference Source
        {
            get { return memberRef; }
        }

        public UNI::ITypeDeclaration DeclaringType
        {
            get 
            {
                if (declaringType == null)
                {
                    declaringType = memberRef.DeclaringType == null ? default(UNI::ITypeDeclaration) : new MCTypeGeneratorImpl(memberRef.DeclaringType.Resolve());
                }
                return declaringType; 
            }
        }

        object UNI::IMemberDeclaration.Source
        {
            get { return Source; }
        }
    }
}

