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
using MCC = Mono.Cecil.Cil;
using UNI = Urasandesu.NAnonym.ILTools;

namespace Urasandesu.NAnonym.Cecil.Mixins.Urasandesu.NAnonym.ILTools
{
    public static class OpCodeMixin
    {
        public static MCC::OpCode ToCecil(this UNI::OpCode opcode)
        {
            if (opcode == UNI::OpCodes.Add) return MCC::OpCodes.Add;
            else if (opcode == UNI::OpCodes.Add_Ovf) return MCC::OpCodes.Add_Ovf;
            else if (opcode == UNI::OpCodes.Add_Ovf_Un) return MCC::OpCodes.Add_Ovf_Un;
            else if (opcode == UNI::OpCodes.And) return MCC::OpCodes.And;
            else if (opcode == UNI::OpCodes.Arglist) return MCC::OpCodes.Arglist;
            else if (opcode == UNI::OpCodes.Beq) return MCC::OpCodes.Beq;
            else if (opcode == UNI::OpCodes.Beq_S) return MCC::OpCodes.Beq_S;
            else if (opcode == UNI::OpCodes.Bge) return MCC::OpCodes.Bge;
            else if (opcode == UNI::OpCodes.Bge_S) return MCC::OpCodes.Bge_S;
            else if (opcode == UNI::OpCodes.Bge_Un) return MCC::OpCodes.Bge_Un;
            else if (opcode == UNI::OpCodes.Bge_Un_S) return MCC::OpCodes.Bge_Un_S;
            else if (opcode == UNI::OpCodes.Bgt) return MCC::OpCodes.Bgt;
            else if (opcode == UNI::OpCodes.Bgt_S) return MCC::OpCodes.Bgt_S;
            else if (opcode == UNI::OpCodes.Bgt_Un) return MCC::OpCodes.Bgt_Un;
            else if (opcode == UNI::OpCodes.Bgt_Un_S) return MCC::OpCodes.Bgt_Un_S;
            else if (opcode == UNI::OpCodes.Ble) return MCC::OpCodes.Ble;
            else if (opcode == UNI::OpCodes.Ble_S) return MCC::OpCodes.Ble_S;
            else if (opcode == UNI::OpCodes.Ble_Un) return MCC::OpCodes.Ble_Un;
            else if (opcode == UNI::OpCodes.Ble_Un_S) return MCC::OpCodes.Ble_Un_S;
            else if (opcode == UNI::OpCodes.Blt) return MCC::OpCodes.Blt;
            else if (opcode == UNI::OpCodes.Blt_S) return MCC::OpCodes.Blt_S;
            else if (opcode == UNI::OpCodes.Blt_Un) return MCC::OpCodes.Blt_Un;
            else if (opcode == UNI::OpCodes.Blt_Un_S) return MCC::OpCodes.Blt_Un_S;
            else if (opcode == UNI::OpCodes.Bne_Un) return MCC::OpCodes.Bne_Un;
            else if (opcode == UNI::OpCodes.Bne_Un_S) return MCC::OpCodes.Bne_Un_S;
            else if (opcode == UNI::OpCodes.Box) return MCC::OpCodes.Box;
            else if (opcode == UNI::OpCodes.Br) return MCC::OpCodes.Br;
            else if (opcode == UNI::OpCodes.Br_S) return MCC::OpCodes.Br_S;
            else if (opcode == UNI::OpCodes.Break) return MCC::OpCodes.Break;
            else if (opcode == UNI::OpCodes.Brfalse) return MCC::OpCodes.Brfalse;
            else if (opcode == UNI::OpCodes.Brfalse_S) return MCC::OpCodes.Brfalse_S;
            else if (opcode == UNI::OpCodes.Brtrue) return MCC::OpCodes.Brtrue;
            else if (opcode == UNI::OpCodes.Brtrue_S) return MCC::OpCodes.Brtrue_S;
            else if (opcode == UNI::OpCodes.Call) return MCC::OpCodes.Call;
            else if (opcode == UNI::OpCodes.Calli) return MCC::OpCodes.Calli;
            else if (opcode == UNI::OpCodes.Callvirt) return MCC::OpCodes.Callvirt;
            else if (opcode == UNI::OpCodes.Castclass) return MCC::OpCodes.Castclass;
            else if (opcode == UNI::OpCodes.Ceq) return MCC::OpCodes.Ceq;
            else if (opcode == UNI::OpCodes.Cgt) return MCC::OpCodes.Cgt;
            else if (opcode == UNI::OpCodes.Cgt_Un) return MCC::OpCodes.Cgt_Un;
            else if (opcode == UNI::OpCodes.Ckfinite) return MCC::OpCodes.Ckfinite;
            else if (opcode == UNI::OpCodes.Clt) return MCC::OpCodes.Clt;
            else if (opcode == UNI::OpCodes.Clt_Un) return MCC::OpCodes.Clt_Un;
            else if (opcode == UNI::OpCodes.Constrained) return MCC::OpCodes.Constrained;
            else if (opcode == UNI::OpCodes.Conv_I) return MCC::OpCodes.Conv_I;
            else if (opcode == UNI::OpCodes.Conv_I1) return MCC::OpCodes.Conv_I1;
            else if (opcode == UNI::OpCodes.Conv_I2) return MCC::OpCodes.Conv_I2;
            else if (opcode == UNI::OpCodes.Conv_I4) return MCC::OpCodes.Conv_I4;
            else if (opcode == UNI::OpCodes.Conv_I8) return MCC::OpCodes.Conv_I8;
            else if (opcode == UNI::OpCodes.Conv_Ovf_I) return MCC::OpCodes.Conv_Ovf_I;
            else if (opcode == UNI::OpCodes.Conv_Ovf_I_Un) return MCC::OpCodes.Conv_Ovf_I_Un;
            else if (opcode == UNI::OpCodes.Conv_Ovf_I1) return MCC::OpCodes.Conv_Ovf_I1;
            else if (opcode == UNI::OpCodes.Conv_Ovf_I1_Un) return MCC::OpCodes.Conv_Ovf_I1_Un;
            else if (opcode == UNI::OpCodes.Conv_Ovf_I2) return MCC::OpCodes.Conv_Ovf_I2;
            else if (opcode == UNI::OpCodes.Conv_Ovf_I2_Un) return MCC::OpCodes.Conv_Ovf_I2_Un;
            else if (opcode == UNI::OpCodes.Conv_Ovf_I4) return MCC::OpCodes.Conv_Ovf_I4;
            else if (opcode == UNI::OpCodes.Conv_Ovf_I4_Un) return MCC::OpCodes.Conv_Ovf_I4_Un;
            else if (opcode == UNI::OpCodes.Conv_Ovf_I8) return MCC::OpCodes.Conv_Ovf_I8;
            else if (opcode == UNI::OpCodes.Conv_Ovf_I8_Un) return MCC::OpCodes.Conv_Ovf_I8_Un;
            else if (opcode == UNI::OpCodes.Conv_Ovf_U) return MCC::OpCodes.Conv_Ovf_U;
            else if (opcode == UNI::OpCodes.Conv_Ovf_U_Un) return MCC::OpCodes.Conv_Ovf_U_Un;
            else if (opcode == UNI::OpCodes.Conv_Ovf_U1) return MCC::OpCodes.Conv_Ovf_U1;
            else if (opcode == UNI::OpCodes.Conv_Ovf_U1_Un) return MCC::OpCodes.Conv_Ovf_U1_Un;
            else if (opcode == UNI::OpCodes.Conv_Ovf_U2) return MCC::OpCodes.Conv_Ovf_U2;
            else if (opcode == UNI::OpCodes.Conv_Ovf_U2_Un) return MCC::OpCodes.Conv_Ovf_U2_Un;
            else if (opcode == UNI::OpCodes.Conv_Ovf_U4) return MCC::OpCodes.Conv_Ovf_U4;
            else if (opcode == UNI::OpCodes.Conv_Ovf_U4_Un) return MCC::OpCodes.Conv_Ovf_U4_Un;
            else if (opcode == UNI::OpCodes.Conv_Ovf_U8) return MCC::OpCodes.Conv_Ovf_U8;
            else if (opcode == UNI::OpCodes.Conv_Ovf_U8_Un) return MCC::OpCodes.Conv_Ovf_U8_Un;
            else if (opcode == UNI::OpCodes.Conv_R_Un) return MCC::OpCodes.Conv_R_Un;
            else if (opcode == UNI::OpCodes.Conv_R4) return MCC::OpCodes.Conv_R4;
            else if (opcode == UNI::OpCodes.Conv_R8) return MCC::OpCodes.Conv_R8;
            else if (opcode == UNI::OpCodes.Conv_U) return MCC::OpCodes.Conv_U;
            else if (opcode == UNI::OpCodes.Conv_U1) return MCC::OpCodes.Conv_U1;
            else if (opcode == UNI::OpCodes.Conv_U2) return MCC::OpCodes.Conv_U2;
            else if (opcode == UNI::OpCodes.Conv_U4) return MCC::OpCodes.Conv_U4;
            else if (opcode == UNI::OpCodes.Conv_U8) return MCC::OpCodes.Conv_U8;
            else if (opcode == UNI::OpCodes.Cpblk) return MCC::OpCodes.Cpblk;
            else if (opcode == UNI::OpCodes.Cpobj) return MCC::OpCodes.Cpobj;
            else if (opcode == UNI::OpCodes.Div) return MCC::OpCodes.Div;
            else if (opcode == UNI::OpCodes.Div_Un) return MCC::OpCodes.Div_Un;
            else if (opcode == UNI::OpCodes.Dup) return MCC::OpCodes.Dup;
            else if (opcode == UNI::OpCodes.Endfilter) return MCC::OpCodes.Endfilter;
            else if (opcode == UNI::OpCodes.Endfinally) return MCC::OpCodes.Endfinally;
            else if (opcode == UNI::OpCodes.Initblk) return MCC::OpCodes.Initblk;
            else if (opcode == UNI::OpCodes.Initobj) return MCC::OpCodes.Initobj;
            else if (opcode == UNI::OpCodes.Isinst) return MCC::OpCodes.Isinst;
            else if (opcode == UNI::OpCodes.Jmp) return MCC::OpCodes.Jmp;
            else if (opcode == UNI::OpCodes.Ldarg) return MCC::OpCodes.Ldarg;
            else if (opcode == UNI::OpCodes.Ldarg_0) return MCC::OpCodes.Ldarg_0;
            else if (opcode == UNI::OpCodes.Ldarg_1) return MCC::OpCodes.Ldarg_1;
            else if (opcode == UNI::OpCodes.Ldarg_2) return MCC::OpCodes.Ldarg_2;
            else if (opcode == UNI::OpCodes.Ldarg_3) return MCC::OpCodes.Ldarg_3;
            else if (opcode == UNI::OpCodes.Ldarg_S) return MCC::OpCodes.Ldarg_S;
            else if (opcode == UNI::OpCodes.Ldarga) return MCC::OpCodes.Ldarga;
            else if (opcode == UNI::OpCodes.Ldarga_S) return MCC::OpCodes.Ldarga_S;
            else if (opcode == UNI::OpCodes.Ldc_I4) return MCC::OpCodes.Ldc_I4;
            else if (opcode == UNI::OpCodes.Ldc_I4_0) return MCC::OpCodes.Ldc_I4_0;
            else if (opcode == UNI::OpCodes.Ldc_I4_1) return MCC::OpCodes.Ldc_I4_1;
            else if (opcode == UNI::OpCodes.Ldc_I4_2) return MCC::OpCodes.Ldc_I4_2;
            else if (opcode == UNI::OpCodes.Ldc_I4_3) return MCC::OpCodes.Ldc_I4_3;
            else if (opcode == UNI::OpCodes.Ldc_I4_4) return MCC::OpCodes.Ldc_I4_4;
            else if (opcode == UNI::OpCodes.Ldc_I4_5) return MCC::OpCodes.Ldc_I4_5;
            else if (opcode == UNI::OpCodes.Ldc_I4_6) return MCC::OpCodes.Ldc_I4_6;
            else if (opcode == UNI::OpCodes.Ldc_I4_7) return MCC::OpCodes.Ldc_I4_7;
            else if (opcode == UNI::OpCodes.Ldc_I4_8) return MCC::OpCodes.Ldc_I4_8;
            else if (opcode == UNI::OpCodes.Ldc_I4_M1) return MCC::OpCodes.Ldc_I4_M1;
            else if (opcode == UNI::OpCodes.Ldc_I4_S) return MCC::OpCodes.Ldc_I4_S;
            else if (opcode == UNI::OpCodes.Ldc_I8) return MCC::OpCodes.Ldc_I8;
            else if (opcode == UNI::OpCodes.Ldc_R4) return MCC::OpCodes.Ldc_R4;
            else if (opcode == UNI::OpCodes.Ldc_R8) return MCC::OpCodes.Ldc_R8;
            else if (opcode == UNI::OpCodes.Ldelem) return MCC::OpCodes.Ldelem_Any;
            else if (opcode == UNI::OpCodes.Ldelem_I) return MCC::OpCodes.Ldelem_I;
            else if (opcode == UNI::OpCodes.Ldelem_I1) return MCC::OpCodes.Ldelem_I1;
            else if (opcode == UNI::OpCodes.Ldelem_I2) return MCC::OpCodes.Ldelem_I2;
            else if (opcode == UNI::OpCodes.Ldelem_I4) return MCC::OpCodes.Ldelem_I4;
            else if (opcode == UNI::OpCodes.Ldelem_I8) return MCC::OpCodes.Ldelem_I8;
            else if (opcode == UNI::OpCodes.Ldelem_R4) return MCC::OpCodes.Ldelem_R4;
            else if (opcode == UNI::OpCodes.Ldelem_R8) return MCC::OpCodes.Ldelem_R8;
            else if (opcode == UNI::OpCodes.Ldelem_Ref) return MCC::OpCodes.Ldelem_Ref;
            else if (opcode == UNI::OpCodes.Ldelem_U1) return MCC::OpCodes.Ldelem_U1;
            else if (opcode == UNI::OpCodes.Ldelem_U2) return MCC::OpCodes.Ldelem_U2;
            else if (opcode == UNI::OpCodes.Ldelem_U4) return MCC::OpCodes.Ldelem_U4;
            else if (opcode == UNI::OpCodes.Ldelema) return MCC::OpCodes.Ldelema;
            else if (opcode == UNI::OpCodes.Ldfld) return MCC::OpCodes.Ldfld;
            else if (opcode == UNI::OpCodes.Ldflda) return MCC::OpCodes.Ldflda;
            else if (opcode == UNI::OpCodes.Ldftn) return MCC::OpCodes.Ldftn;
            else if (opcode == UNI::OpCodes.Ldind_I) return MCC::OpCodes.Ldind_I;
            else if (opcode == UNI::OpCodes.Ldind_I1) return MCC::OpCodes.Ldind_I1;
            else if (opcode == UNI::OpCodes.Ldind_I2) return MCC::OpCodes.Ldind_I2;
            else if (opcode == UNI::OpCodes.Ldind_I4) return MCC::OpCodes.Ldind_I4;
            else if (opcode == UNI::OpCodes.Ldind_I8) return MCC::OpCodes.Ldind_I8;
            else if (opcode == UNI::OpCodes.Ldind_R4) return MCC::OpCodes.Ldind_R4;
            else if (opcode == UNI::OpCodes.Ldind_R8) return MCC::OpCodes.Ldind_R8;
            else if (opcode == UNI::OpCodes.Ldind_Ref) return MCC::OpCodes.Ldind_Ref;
            else if (opcode == UNI::OpCodes.Ldind_U1) return MCC::OpCodes.Ldind_U1;
            else if (opcode == UNI::OpCodes.Ldind_U2) return MCC::OpCodes.Ldind_U2;
            else if (opcode == UNI::OpCodes.Ldind_U4) return MCC::OpCodes.Ldind_U4;
            else if (opcode == UNI::OpCodes.Ldlen) return MCC::OpCodes.Ldlen;
            else if (opcode == UNI::OpCodes.Ldloc) return MCC::OpCodes.Ldloc;
            else if (opcode == UNI::OpCodes.Ldloc_0) return MCC::OpCodes.Ldloc_0;
            else if (opcode == UNI::OpCodes.Ldloc_1) return MCC::OpCodes.Ldloc_1;
            else if (opcode == UNI::OpCodes.Ldloc_2) return MCC::OpCodes.Ldloc_2;
            else if (opcode == UNI::OpCodes.Ldloc_3) return MCC::OpCodes.Ldloc_3;
            else if (opcode == UNI::OpCodes.Ldloc_S) return MCC::OpCodes.Ldloc_S;
            else if (opcode == UNI::OpCodes.Ldloca) return MCC::OpCodes.Ldloca;
            else if (opcode == UNI::OpCodes.Ldloca_S) return MCC::OpCodes.Ldloca_S;
            else if (opcode == UNI::OpCodes.Ldnull) return MCC::OpCodes.Ldnull;
            else if (opcode == UNI::OpCodes.Ldobj) return MCC::OpCodes.Ldobj;
            else if (opcode == UNI::OpCodes.Ldsfld) return MCC::OpCodes.Ldsfld;
            else if (opcode == UNI::OpCodes.Ldsflda) return MCC::OpCodes.Ldsflda;
            else if (opcode == UNI::OpCodes.Ldstr) return MCC::OpCodes.Ldstr;
            else if (opcode == UNI::OpCodes.Ldtoken) return MCC::OpCodes.Ldtoken;
            else if (opcode == UNI::OpCodes.Ldvirtftn) return MCC::OpCodes.Ldvirtftn;
            else if (opcode == UNI::OpCodes.Leave) return MCC::OpCodes.Leave;
            else if (opcode == UNI::OpCodes.Leave_S) return MCC::OpCodes.Leave_S;
            else if (opcode == UNI::OpCodes.Localloc) return MCC::OpCodes.Localloc;
            else if (opcode == UNI::OpCodes.Mkrefany) return MCC::OpCodes.Mkrefany;
            else if (opcode == UNI::OpCodes.Mul) return MCC::OpCodes.Mul;
            else if (opcode == UNI::OpCodes.Mul_Ovf) return MCC::OpCodes.Mul_Ovf;
            else if (opcode == UNI::OpCodes.Mul_Ovf_Un) return MCC::OpCodes.Mul_Ovf_Un;
            else if (opcode == UNI::OpCodes.Neg) return MCC::OpCodes.Neg;
            else if (opcode == UNI::OpCodes.Newarr) return MCC::OpCodes.Newarr;
            else if (opcode == UNI::OpCodes.Newobj) return MCC::OpCodes.Newobj;
            else if (opcode == UNI::OpCodes.Nop) return MCC::OpCodes.Nop;
            else if (opcode == UNI::OpCodes.Not) return MCC::OpCodes.Not;
            else if (opcode == UNI::OpCodes.Or) return MCC::OpCodes.Or;
            else if (opcode == UNI::OpCodes.Pop) return MCC::OpCodes.Pop;
            else if (opcode == UNI::OpCodes.Readonly) return MCC::OpCodes.Readonly;
            else if (opcode == UNI::OpCodes.Refanytype) return MCC::OpCodes.Refanytype;
            else if (opcode == UNI::OpCodes.Refanyval) return MCC::OpCodes.Refanyval;
            else if (opcode == UNI::OpCodes.Rem) return MCC::OpCodes.Rem;
            else if (opcode == UNI::OpCodes.Rem_Un) return MCC::OpCodes.Rem_Un;
            else if (opcode == UNI::OpCodes.Ret) return MCC::OpCodes.Ret;
            else if (opcode == UNI::OpCodes.Rethrow) return MCC::OpCodes.Rethrow;
            else if (opcode == UNI::OpCodes.Shl) return MCC::OpCodes.Shl;
            else if (opcode == UNI::OpCodes.Shr) return MCC::OpCodes.Shr;
            else if (opcode == UNI::OpCodes.Shr_Un) return MCC::OpCodes.Shr_Un;
            else if (opcode == UNI::OpCodes.Sizeof) return MCC::OpCodes.Sizeof;
            else if (opcode == UNI::OpCodes.Starg) return MCC::OpCodes.Starg;
            else if (opcode == UNI::OpCodes.Starg_S) return MCC::OpCodes.Starg_S;
            else if (opcode == UNI::OpCodes.Stelem) return MCC::OpCodes.Stelem_Any;
            else if (opcode == UNI::OpCodes.Stelem_I) return MCC::OpCodes.Stelem_I;
            else if (opcode == UNI::OpCodes.Stelem_I1) return MCC::OpCodes.Stelem_I1;
            else if (opcode == UNI::OpCodes.Stelem_I2) return MCC::OpCodes.Stelem_I2;
            else if (opcode == UNI::OpCodes.Stelem_I4) return MCC::OpCodes.Stelem_I4;
            else if (opcode == UNI::OpCodes.Stelem_I8) return MCC::OpCodes.Stelem_I8;
            else if (opcode == UNI::OpCodes.Stelem_R4) return MCC::OpCodes.Stelem_R4;
            else if (opcode == UNI::OpCodes.Stelem_R8) return MCC::OpCodes.Stelem_R8;
            else if (opcode == UNI::OpCodes.Stelem_Ref) return MCC::OpCodes.Stelem_Ref;
            else if (opcode == UNI::OpCodes.Stfld) return MCC::OpCodes.Stfld;
            else if (opcode == UNI::OpCodes.Stind_I) return MCC::OpCodes.Stind_I;
            else if (opcode == UNI::OpCodes.Stind_I1) return MCC::OpCodes.Stind_I1;
            else if (opcode == UNI::OpCodes.Stind_I2) return MCC::OpCodes.Stind_I2;
            else if (opcode == UNI::OpCodes.Stind_I4) return MCC::OpCodes.Stind_I4;
            else if (opcode == UNI::OpCodes.Stind_I8) return MCC::OpCodes.Stind_I8;
            else if (opcode == UNI::OpCodes.Stind_R4) return MCC::OpCodes.Stind_R4;
            else if (opcode == UNI::OpCodes.Stind_R8) return MCC::OpCodes.Stind_R8;
            else if (opcode == UNI::OpCodes.Stind_Ref) return MCC::OpCodes.Stind_Ref;
            else if (opcode == UNI::OpCodes.Stloc) return MCC::OpCodes.Stloc;
            else if (opcode == UNI::OpCodes.Stloc_0) return MCC::OpCodes.Stloc_0;
            else if (opcode == UNI::OpCodes.Stloc_1) return MCC::OpCodes.Stloc_1;
            else if (opcode == UNI::OpCodes.Stloc_2) return MCC::OpCodes.Stloc_2;
            else if (opcode == UNI::OpCodes.Stloc_3) return MCC::OpCodes.Stloc_3;
            else if (opcode == UNI::OpCodes.Stloc_S) return MCC::OpCodes.Stloc_S;
            else if (opcode == UNI::OpCodes.Stobj) return MCC::OpCodes.Stobj;
            else if (opcode == UNI::OpCodes.Stsfld) return MCC::OpCodes.Stsfld;
            else if (opcode == UNI::OpCodes.Sub) return MCC::OpCodes.Sub;
            else if (opcode == UNI::OpCodes.Sub_Ovf) return MCC::OpCodes.Sub_Ovf;
            else if (opcode == UNI::OpCodes.Sub_Ovf_Un) return MCC::OpCodes.Sub_Ovf_Un;
            else if (opcode == UNI::OpCodes.Switch) return MCC::OpCodes.Switch;
            else if (opcode == UNI::OpCodes.Tailcall) return MCC::OpCodes.Tail;
            else if (opcode == UNI::OpCodes.Throw) return MCC::OpCodes.Throw;
            else if (opcode == UNI::OpCodes.Unaligned) return MCC::OpCodes.Unaligned;
            else if (opcode == UNI::OpCodes.Unbox) return MCC::OpCodes.Unbox;
            else if (opcode == UNI::OpCodes.Unbox_Any) return MCC::OpCodes.Unbox_Any;
            else if (opcode == UNI::OpCodes.Volatile) return MCC::OpCodes.Volatile;
            else if (opcode == UNI::OpCodes.Xor) return MCC::OpCodes.Xor;

            throw new NotSupportedException();
        }
    }
}

