/* 
 * File: VariableFormula.g.cs
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
using System.ComponentModel;
using Urasandesu.NAnonym.Mixins.System;

namespace Urasandesu.NAnonym.Formulas
{
    public partial class VariableFormula:Formula
    {

        protected override void InitializeForCodeGeneration()
        {
            base.InitializeForCodeGeneration();
			NodeType = NodeType.Variable;
            VariableName = default(string);
            VariableIndex = default(int);
            Resolved = default(Formula);
        }

        public const string NameOfVariableName = "VariableName";
        string variableName;
        public string VariableName 
        { 
            get { return variableName; } 
            set 
            {
                SetValue(NameOfVariableName, value, ref variableName);
            }
        }
        public const string NameOfVariableIndex = "VariableIndex";
        int variableIndex;
        public int VariableIndex 
        { 
            get { return variableIndex; } 
            set 
            {
                SetValue(NameOfVariableIndex, value, ref variableIndex);
            }
        }
        public const string NameOfResolved = "Resolved";
        Formula resolved;
        public Formula Resolved 
        { 
            get { return resolved; } 
            set 
            {
                SetFormulaAsValue(NameOfResolved, value, ref resolved);
            }
        }


        public override void Accept(IFormulaVisitor visitor)
        {
            visitor.Visit(this);
        }


        protected override void PinCore()
        {
            Formula.Pin(Resolved);
            base.PinCore();
        }


        public override void AppendTo(StringBuilder sb)
        {
            base.AppendTo(sb);
            sb.Append(", ");
            sb.Append("\"");
            sb.Append(NameOfVariableName);
            sb.Append("\": ");
            AppendValueTo(VariableName, sb);
            sb.Append(", ");
            sb.Append("\"");
            sb.Append(NameOfVariableIndex);
            sb.Append("\": ");
            AppendValueTo(VariableIndex, sb);
            sb.Append(", ");
            sb.Append("\"");
            sb.Append(NameOfResolved);
            sb.Append("\": ");
            if (Resolved == null)
            {
                sb.Append("null");
            }
            else
            {
                Resolved.AppendWithBracketTo(sb);
            }
        }
    }
}

