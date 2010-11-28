/* 
 * File: OpCodeMixin.cs
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
using SRE = System.Reflection.Emit;
using Urasandesu.NAnonym.ILTools;

namespace Urasandesu.NAnonym.Mixins.Urasandesu.NAnonym.ILTools
{
    public static class OpCodeMixin
    {
        public static SRE::OpCode ToClr(this OpCode opcode)
        {
            if (opcode == OpCodes.Add) return SRE::OpCodes.Add;
            else if (opcode == OpCodes.Add_Ovf) return SRE::OpCodes.Add_Ovf;
            else if (opcode == OpCodes.Add_Ovf_Un) return SRE::OpCodes.Add_Ovf_Un;
            else if (opcode == OpCodes.And) return SRE::OpCodes.And;
            else if (opcode == OpCodes.Arglist) return SRE::OpCodes.Arglist;
            else if (opcode == OpCodes.Beq) return SRE::OpCodes.Beq;
            else if (opcode == OpCodes.Beq_S) return SRE::OpCodes.Beq_S;
            else if (opcode == OpCodes.Bge) return SRE::OpCodes.Bge;
            else if (opcode == OpCodes.Bge_S) return SRE::OpCodes.Bge_S;
            else if (opcode == OpCodes.Bge_Un) return SRE::OpCodes.Bge_Un;
            else if (opcode == OpCodes.Bge_Un_S) return SRE::OpCodes.Bge_Un_S;
            else if (opcode == OpCodes.Bgt) return SRE::OpCodes.Bgt;
            else if (opcode == OpCodes.Bgt_S) return SRE::OpCodes.Bgt_S;
            else if (opcode == OpCodes.Bgt_Un) return SRE::OpCodes.Bgt_Un;
            else if (opcode == OpCodes.Bgt_Un_S) return SRE::OpCodes.Bgt_Un_S;
            else if (opcode == OpCodes.Ble) return SRE::OpCodes.Ble;
            else if (opcode == OpCodes.Ble_S) return SRE::OpCodes.Ble_S;
            else if (opcode == OpCodes.Ble_Un) return SRE::OpCodes.Ble_Un;
            else if (opcode == OpCodes.Ble_Un_S) return SRE::OpCodes.Ble_Un_S;
            else if (opcode == OpCodes.Blt) return SRE::OpCodes.Blt;
            else if (opcode == OpCodes.Blt_S) return SRE::OpCodes.Blt_S;
            else if (opcode == OpCodes.Blt_Un) return SRE::OpCodes.Blt_Un;
            else if (opcode == OpCodes.Blt_Un_S) return SRE::OpCodes.Blt_Un_S;
            else if (opcode == OpCodes.Bne_Un) return SRE::OpCodes.Bne_Un;
            else if (opcode == OpCodes.Bne_Un_S) return SRE::OpCodes.Bne_Un_S;
            else if (opcode == OpCodes.Box) return SRE::OpCodes.Box;
            else if (opcode == OpCodes.Br) return SRE::OpCodes.Br;
            else if (opcode == OpCodes.Br_S) return SRE::OpCodes.Br_S;
            else if (opcode == OpCodes.Break) return SRE::OpCodes.Break;
            else if (opcode == OpCodes.Brfalse) return SRE::OpCodes.Brfalse;
            else if (opcode == OpCodes.Brfalse_S) return SRE::OpCodes.Brfalse_S;
            else if (opcode == OpCodes.Brtrue) return SRE::OpCodes.Brtrue;
            else if (opcode == OpCodes.Brtrue_S) return SRE::OpCodes.Brtrue_S;
            else if (opcode == OpCodes.Call) return SRE::OpCodes.Call;
            else if (opcode == OpCodes.Calli) return SRE::OpCodes.Calli;
            else if (opcode == OpCodes.Callvirt) return SRE::OpCodes.Callvirt;
            else if (opcode == OpCodes.Castclass) return SRE::OpCodes.Castclass;
            else if (opcode == OpCodes.Ceq) return SRE::OpCodes.Ceq;
            else if (opcode == OpCodes.Cgt) return SRE::OpCodes.Cgt;
            else if (opcode == OpCodes.Cgt_Un) return SRE::OpCodes.Cgt_Un;
            else if (opcode == OpCodes.Ckfinite) return SRE::OpCodes.Ckfinite;
            else if (opcode == OpCodes.Clt) return SRE::OpCodes.Clt;
            else if (opcode == OpCodes.Clt_Un) return SRE::OpCodes.Clt_Un;
            else if (opcode == OpCodes.Constrained) return SRE::OpCodes.Constrained;
            else if (opcode == OpCodes.Conv_I) return SRE::OpCodes.Conv_I;
            else if (opcode == OpCodes.Conv_I1) return SRE::OpCodes.Conv_I1;
            else if (opcode == OpCodes.Conv_I2) return SRE::OpCodes.Conv_I2;
            else if (opcode == OpCodes.Conv_I4) return SRE::OpCodes.Conv_I4;
            else if (opcode == OpCodes.Conv_I8) return SRE::OpCodes.Conv_I8;
            else if (opcode == OpCodes.Conv_Ovf_I) return SRE::OpCodes.Conv_Ovf_I;
            else if (opcode == OpCodes.Conv_Ovf_I_Un) return SRE::OpCodes.Conv_Ovf_I_Un;
            else if (opcode == OpCodes.Conv_Ovf_I1) return SRE::OpCodes.Conv_Ovf_I1;
            else if (opcode == OpCodes.Conv_Ovf_I1_Un) return SRE::OpCodes.Conv_Ovf_I1_Un;
            else if (opcode == OpCodes.Conv_Ovf_I2) return SRE::OpCodes.Conv_Ovf_I2;
            else if (opcode == OpCodes.Conv_Ovf_I2_Un) return SRE::OpCodes.Conv_Ovf_I2_Un;
            else if (opcode == OpCodes.Conv_Ovf_I4) return SRE::OpCodes.Conv_Ovf_I4;
            else if (opcode == OpCodes.Conv_Ovf_I4_Un) return SRE::OpCodes.Conv_Ovf_I4_Un;
            else if (opcode == OpCodes.Conv_Ovf_I8) return SRE::OpCodes.Conv_Ovf_I8;
            else if (opcode == OpCodes.Conv_Ovf_I8_Un) return SRE::OpCodes.Conv_Ovf_I8_Un;
            else if (opcode == OpCodes.Conv_Ovf_U) return SRE::OpCodes.Conv_Ovf_U;
            else if (opcode == OpCodes.Conv_Ovf_U_Un) return SRE::OpCodes.Conv_Ovf_U_Un;
            else if (opcode == OpCodes.Conv_Ovf_U1) return SRE::OpCodes.Conv_Ovf_U1;
            else if (opcode == OpCodes.Conv_Ovf_U1_Un) return SRE::OpCodes.Conv_Ovf_U1_Un;
            else if (opcode == OpCodes.Conv_Ovf_U2) return SRE::OpCodes.Conv_Ovf_U2;
            else if (opcode == OpCodes.Conv_Ovf_U2_Un) return SRE::OpCodes.Conv_Ovf_U2_Un;
            else if (opcode == OpCodes.Conv_Ovf_U4) return SRE::OpCodes.Conv_Ovf_U4;
            else if (opcode == OpCodes.Conv_Ovf_U4_Un) return SRE::OpCodes.Conv_Ovf_U4_Un;
            else if (opcode == OpCodes.Conv_Ovf_U8) return SRE::OpCodes.Conv_Ovf_U8;
            else if (opcode == OpCodes.Conv_Ovf_U8_Un) return SRE::OpCodes.Conv_Ovf_U8_Un;
            else if (opcode == OpCodes.Conv_R_Un) return SRE::OpCodes.Conv_R_Un;
            else if (opcode == OpCodes.Conv_R4) return SRE::OpCodes.Conv_R4;
            else if (opcode == OpCodes.Conv_R8) return SRE::OpCodes.Conv_R8;
            else if (opcode == OpCodes.Conv_U) return SRE::OpCodes.Conv_U;
            else if (opcode == OpCodes.Conv_U1) return SRE::OpCodes.Conv_U1;
            else if (opcode == OpCodes.Conv_U2) return SRE::OpCodes.Conv_U2;
            else if (opcode == OpCodes.Conv_U4) return SRE::OpCodes.Conv_U4;
            else if (opcode == OpCodes.Conv_U8) return SRE::OpCodes.Conv_U8;
            else if (opcode == OpCodes.Cpblk) return SRE::OpCodes.Cpblk;
            else if (opcode == OpCodes.Cpobj) return SRE::OpCodes.Cpobj;
            else if (opcode == OpCodes.Div) return SRE::OpCodes.Div;
            else if (opcode == OpCodes.Div_Un) return SRE::OpCodes.Div_Un;
            else if (opcode == OpCodes.Dup) return SRE::OpCodes.Dup;
            else if (opcode == OpCodes.Endfilter) return SRE::OpCodes.Endfilter;
            else if (opcode == OpCodes.Endfinally) return SRE::OpCodes.Endfinally;
            else if (opcode == OpCodes.Initblk) return SRE::OpCodes.Initblk;
            else if (opcode == OpCodes.Initobj) return SRE::OpCodes.Initobj;
            else if (opcode == OpCodes.Isinst) return SRE::OpCodes.Isinst;
            else if (opcode == OpCodes.Jmp) return SRE::OpCodes.Jmp;
            else if (opcode == OpCodes.Ldarg) return SRE::OpCodes.Ldarg;
            else if (opcode == OpCodes.Ldarg_0) return SRE::OpCodes.Ldarg_0;
            else if (opcode == OpCodes.Ldarg_1) return SRE::OpCodes.Ldarg_1;
            else if (opcode == OpCodes.Ldarg_2) return SRE::OpCodes.Ldarg_2;
            else if (opcode == OpCodes.Ldarg_3) return SRE::OpCodes.Ldarg_3;
            else if (opcode == OpCodes.Ldarg_S) return SRE::OpCodes.Ldarg_S;
            else if (opcode == OpCodes.Ldarga) return SRE::OpCodes.Ldarga;
            else if (opcode == OpCodes.Ldarga_S) return SRE::OpCodes.Ldarga_S;
            else if (opcode == OpCodes.Ldc_I4) return SRE::OpCodes.Ldc_I4;
            else if (opcode == OpCodes.Ldc_I4_0) return SRE::OpCodes.Ldc_I4_0;
            else if (opcode == OpCodes.Ldc_I4_1) return SRE::OpCodes.Ldc_I4_1;
            else if (opcode == OpCodes.Ldc_I4_2) return SRE::OpCodes.Ldc_I4_2;
            else if (opcode == OpCodes.Ldc_I4_3) return SRE::OpCodes.Ldc_I4_3;
            else if (opcode == OpCodes.Ldc_I4_4) return SRE::OpCodes.Ldc_I4_4;
            else if (opcode == OpCodes.Ldc_I4_5) return SRE::OpCodes.Ldc_I4_5;
            else if (opcode == OpCodes.Ldc_I4_6) return SRE::OpCodes.Ldc_I4_6;
            else if (opcode == OpCodes.Ldc_I4_7) return SRE::OpCodes.Ldc_I4_7;
            else if (opcode == OpCodes.Ldc_I4_8) return SRE::OpCodes.Ldc_I4_8;
            else if (opcode == OpCodes.Ldc_I4_M1) return SRE::OpCodes.Ldc_I4_M1;
            else if (opcode == OpCodes.Ldc_I4_S) return SRE::OpCodes.Ldc_I4_S;
            else if (opcode == OpCodes.Ldc_I8) return SRE::OpCodes.Ldc_I8;
            else if (opcode == OpCodes.Ldc_R4) return SRE::OpCodes.Ldc_R4;
            else if (opcode == OpCodes.Ldc_R8) return SRE::OpCodes.Ldc_R8;
            else if (opcode == OpCodes.Ldelem) return SRE::OpCodes.Ldelem;
            else if (opcode == OpCodes.Ldelem_I) return SRE::OpCodes.Ldelem_I;
            else if (opcode == OpCodes.Ldelem_I1) return SRE::OpCodes.Ldelem_I1;
            else if (opcode == OpCodes.Ldelem_I2) return SRE::OpCodes.Ldelem_I2;
            else if (opcode == OpCodes.Ldelem_I4) return SRE::OpCodes.Ldelem_I4;
            else if (opcode == OpCodes.Ldelem_I8) return SRE::OpCodes.Ldelem_I8;
            else if (opcode == OpCodes.Ldelem_R4) return SRE::OpCodes.Ldelem_R4;
            else if (opcode == OpCodes.Ldelem_R8) return SRE::OpCodes.Ldelem_R8;
            else if (opcode == OpCodes.Ldelem_Ref) return SRE::OpCodes.Ldelem_Ref;
            else if (opcode == OpCodes.Ldelem_U1) return SRE::OpCodes.Ldelem_U1;
            else if (opcode == OpCodes.Ldelem_U2) return SRE::OpCodes.Ldelem_U2;
            else if (opcode == OpCodes.Ldelem_U4) return SRE::OpCodes.Ldelem_U4;
            else if (opcode == OpCodes.Ldelema) return SRE::OpCodes.Ldelema;
            else if (opcode == OpCodes.Ldfld) return SRE::OpCodes.Ldfld;
            else if (opcode == OpCodes.Ldflda) return SRE::OpCodes.Ldflda;
            else if (opcode == OpCodes.Ldftn) return SRE::OpCodes.Ldftn;
            else if (opcode == OpCodes.Ldind_I) return SRE::OpCodes.Ldind_I;
            else if (opcode == OpCodes.Ldind_I1) return SRE::OpCodes.Ldind_I1;
            else if (opcode == OpCodes.Ldind_I2) return SRE::OpCodes.Ldind_I2;
            else if (opcode == OpCodes.Ldind_I4) return SRE::OpCodes.Ldind_I4;
            else if (opcode == OpCodes.Ldind_I8) return SRE::OpCodes.Ldind_I8;
            else if (opcode == OpCodes.Ldind_R4) return SRE::OpCodes.Ldind_R4;
            else if (opcode == OpCodes.Ldind_R8) return SRE::OpCodes.Ldind_R8;
            else if (opcode == OpCodes.Ldind_Ref) return SRE::OpCodes.Ldind_Ref;
            else if (opcode == OpCodes.Ldind_U1) return SRE::OpCodes.Ldind_U1;
            else if (opcode == OpCodes.Ldind_U2) return SRE::OpCodes.Ldind_U2;
            else if (opcode == OpCodes.Ldind_U4) return SRE::OpCodes.Ldind_U4;
            else if (opcode == OpCodes.Ldlen) return SRE::OpCodes.Ldlen;
            else if (opcode == OpCodes.Ldloc) return SRE::OpCodes.Ldloc;
            else if (opcode == OpCodes.Ldloc_0) return SRE::OpCodes.Ldloc_0;
            else if (opcode == OpCodes.Ldloc_1) return SRE::OpCodes.Ldloc_1;
            else if (opcode == OpCodes.Ldloc_2) return SRE::OpCodes.Ldloc_2;
            else if (opcode == OpCodes.Ldloc_3) return SRE::OpCodes.Ldloc_3;
            else if (opcode == OpCodes.Ldloc_S) return SRE::OpCodes.Ldloc_S;
            else if (opcode == OpCodes.Ldloca) return SRE::OpCodes.Ldloca;
            else if (opcode == OpCodes.Ldloca_S) return SRE::OpCodes.Ldloca_S;
            else if (opcode == OpCodes.Ldnull) return SRE::OpCodes.Ldnull;
            else if (opcode == OpCodes.Ldobj) return SRE::OpCodes.Ldobj;
            else if (opcode == OpCodes.Ldsfld) return SRE::OpCodes.Ldsfld;
            else if (opcode == OpCodes.Ldsflda) return SRE::OpCodes.Ldsflda;
            else if (opcode == OpCodes.Ldstr) return SRE::OpCodes.Ldstr;
            else if (opcode == OpCodes.Ldtoken) return SRE::OpCodes.Ldtoken;
            else if (opcode == OpCodes.Ldvirtftn) return SRE::OpCodes.Ldvirtftn;
            else if (opcode == OpCodes.Leave) return SRE::OpCodes.Leave;
            else if (opcode == OpCodes.Leave_S) return SRE::OpCodes.Leave_S;
            else if (opcode == OpCodes.Localloc) return SRE::OpCodes.Localloc;
            else if (opcode == OpCodes.Mkrefany) return SRE::OpCodes.Mkrefany;
            else if (opcode == OpCodes.Mul) return SRE::OpCodes.Mul;
            else if (opcode == OpCodes.Mul_Ovf) return SRE::OpCodes.Mul_Ovf;
            else if (opcode == OpCodes.Mul_Ovf_Un) return SRE::OpCodes.Mul_Ovf_Un;
            else if (opcode == OpCodes.Neg) return SRE::OpCodes.Neg;
            else if (opcode == OpCodes.Newarr) return SRE::OpCodes.Newarr;
            else if (opcode == OpCodes.Newobj) return SRE::OpCodes.Newobj;
            else if (opcode == OpCodes.Nop) return SRE::OpCodes.Nop;
            else if (opcode == OpCodes.Not) return SRE::OpCodes.Not;
            else if (opcode == OpCodes.Or) return SRE::OpCodes.Or;
            else if (opcode == OpCodes.Pop) return SRE::OpCodes.Pop;
            else if (opcode == OpCodes.Readonly) return SRE::OpCodes.Readonly;
            else if (opcode == OpCodes.Refanytype) return SRE::OpCodes.Refanytype;
            else if (opcode == OpCodes.Refanyval) return SRE::OpCodes.Refanyval;
            else if (opcode == OpCodes.Rem) return SRE::OpCodes.Rem;
            else if (opcode == OpCodes.Rem_Un) return SRE::OpCodes.Rem_Un;
            else if (opcode == OpCodes.Ret) return SRE::OpCodes.Ret;
            else if (opcode == OpCodes.Rethrow) return SRE::OpCodes.Rethrow;
            else if (opcode == OpCodes.Shl) return SRE::OpCodes.Shl;
            else if (opcode == OpCodes.Shr) return SRE::OpCodes.Shr;
            else if (opcode == OpCodes.Shr_Un) return SRE::OpCodes.Shr_Un;
            else if (opcode == OpCodes.Sizeof) return SRE::OpCodes.Sizeof;
            else if (opcode == OpCodes.Starg) return SRE::OpCodes.Starg;
            else if (opcode == OpCodes.Starg_S) return SRE::OpCodes.Starg_S;
            else if (opcode == OpCodes.Stelem) return SRE::OpCodes.Stelem;
            else if (opcode == OpCodes.Stelem_I) return SRE::OpCodes.Stelem_I;
            else if (opcode == OpCodes.Stelem_I1) return SRE::OpCodes.Stelem_I1;
            else if (opcode == OpCodes.Stelem_I2) return SRE::OpCodes.Stelem_I2;
            else if (opcode == OpCodes.Stelem_I4) return SRE::OpCodes.Stelem_I4;
            else if (opcode == OpCodes.Stelem_I8) return SRE::OpCodes.Stelem_I8;
            else if (opcode == OpCodes.Stelem_R4) return SRE::OpCodes.Stelem_R4;
            else if (opcode == OpCodes.Stelem_R8) return SRE::OpCodes.Stelem_R8;
            else if (opcode == OpCodes.Stelem_Ref) return SRE::OpCodes.Stelem_Ref;
            else if (opcode == OpCodes.Stfld) return SRE::OpCodes.Stfld;
            else if (opcode == OpCodes.Stind_I) return SRE::OpCodes.Stind_I;
            else if (opcode == OpCodes.Stind_I1) return SRE::OpCodes.Stind_I1;
            else if (opcode == OpCodes.Stind_I2) return SRE::OpCodes.Stind_I2;
            else if (opcode == OpCodes.Stind_I4) return SRE::OpCodes.Stind_I4;
            else if (opcode == OpCodes.Stind_I8) return SRE::OpCodes.Stind_I8;
            else if (opcode == OpCodes.Stind_R4) return SRE::OpCodes.Stind_R4;
            else if (opcode == OpCodes.Stind_R8) return SRE::OpCodes.Stind_R8;
            else if (opcode == OpCodes.Stind_Ref) return SRE::OpCodes.Stind_Ref;
            else if (opcode == OpCodes.Stloc) return SRE::OpCodes.Stloc;
            else if (opcode == OpCodes.Stloc_0) return SRE::OpCodes.Stloc_0;
            else if (opcode == OpCodes.Stloc_1) return SRE::OpCodes.Stloc_1;
            else if (opcode == OpCodes.Stloc_2) return SRE::OpCodes.Stloc_2;
            else if (opcode == OpCodes.Stloc_3) return SRE::OpCodes.Stloc_3;
            else if (opcode == OpCodes.Stloc_S) return SRE::OpCodes.Stloc_S;
            else if (opcode == OpCodes.Stobj) return SRE::OpCodes.Stobj;
            else if (opcode == OpCodes.Stsfld) return SRE::OpCodes.Stsfld;
            else if (opcode == OpCodes.Sub) return SRE::OpCodes.Sub;
            else if (opcode == OpCodes.Sub_Ovf) return SRE::OpCodes.Sub_Ovf;
            else if (opcode == OpCodes.Sub_Ovf_Un) return SRE::OpCodes.Sub_Ovf_Un;
            else if (opcode == OpCodes.Switch) return SRE::OpCodes.Switch;
            else if (opcode == OpCodes.Tailcall) return SRE::OpCodes.Tailcall;
            else if (opcode == OpCodes.Throw) return SRE::OpCodes.Throw;
            else if (opcode == OpCodes.Unaligned) return SRE::OpCodes.Unaligned;
            else if (opcode == OpCodes.Unbox) return SRE::OpCodes.Unbox;
            else if (opcode == OpCodes.Unbox_Any) return SRE::OpCodes.Unbox_Any;
            else if (opcode == OpCodes.Volatile) return SRE::OpCodes.Volatile;
            else if (opcode == OpCodes.Xor) return SRE::OpCodes.Xor;

            throw new NotSupportedException();
        }
    }
}

