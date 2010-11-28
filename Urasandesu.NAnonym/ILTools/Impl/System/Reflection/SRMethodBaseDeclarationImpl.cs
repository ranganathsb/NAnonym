/* 
 * File: SRMethodBaseDeclarationImpl.cs
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
using System.Reflection;
using System.Collections.ObjectModel;

namespace Urasandesu.NAnonym.ILTools.Impl.System.Reflection
{
    class SRMethodBaseDeclarationImpl : SRMemberDeclarationImpl, IMethodBaseDeclaration
    {
        readonly MethodBase methodBase;
        public SRMethodBaseDeclarationImpl(MethodBase methodBase)
            : base(methodBase)
        {
            this.methodBase = methodBase;
        }

        public MethodBase MethodBase { get { return (MethodBase)base.Source; } }

        #region IMethodBaseDeclaration メンバ

        public IMethodBodyDeclaration Body
        {
            get { throw new NotImplementedException(); }
        }

        public ITypeDeclaration DeclaringType
        {
            get { throw new NotImplementedException(); }
        }

        public ReadOnlyCollection<IParameterDeclaration> Parameters
        {
            get { return new ReadOnlyCollection<IParameterDeclaration>(new IParameterDeclaration[] { }); }
        }

        public IPortableScopeItem NewPortableScopeItem(PortableScopeItemRawData itemRawData, object value)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

