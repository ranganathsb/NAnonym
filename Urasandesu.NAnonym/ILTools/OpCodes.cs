/* 
 * File: OpCodes.cs
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
using System.Reflection.Emit;
using SR = System.Reflection;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections;
using Urasandesu.NAnonym.Linq;

namespace Urasandesu.NAnonym.ILTools
{
    public static class OpCodes
    {
        public static readonly OpCode Add = new OpCode("add");
        public static readonly OpCode Add_Ovf = new OpCode("add.ovf");
        public static readonly OpCode Add_Ovf_Un = new OpCode("add.ovf.un");
        public static readonly OpCode And = new OpCode("and");
        public static readonly OpCode Arglist = new OpCode("arglist");
        public static readonly OpCode Beq = new OpCode("beq");
        public static readonly OpCode Beq_S = new OpCode("beq.s");
        public static readonly OpCode Bge = new OpCode("bge");
        public static readonly OpCode Bge_S = new OpCode("bge.s");
        public static readonly OpCode Bge_Un = new OpCode("bge.un");
        public static readonly OpCode Bge_Un_S = new OpCode("bge.un.s");
        public static readonly OpCode Bgt = new OpCode("bgt");
        public static readonly OpCode Bgt_S = new OpCode("bgt.s");
        public static readonly OpCode Bgt_Un = new OpCode("bgt.un");
        public static readonly OpCode Bgt_Un_S = new OpCode("bgt.un.s");
        public static readonly OpCode Ble = new OpCode("ble");
        public static readonly OpCode Ble_S = new OpCode("ble.s");
        public static readonly OpCode Ble_Un = new OpCode("ble.un");
        public static readonly OpCode Ble_Un_S = new OpCode("ble.un.s");
        public static readonly OpCode Blt = new OpCode("blt");
        public static readonly OpCode Blt_S = new OpCode("blt.s");
        public static readonly OpCode Blt_Un = new OpCode("blt.un");
        public static readonly OpCode Blt_Un_S = new OpCode("blt.un.s");
        public static readonly OpCode Bne_Un = new OpCode("bne.un");
        public static readonly OpCode Bne_Un_S = new OpCode("bne.un.s");
        public static readonly OpCode Box = new OpCode("box");
        public static readonly OpCode Br = new OpCode("br");
        public static readonly OpCode Br_S = new OpCode("br.s");
        public static readonly OpCode Break = new OpCode("break");
        public static readonly OpCode Brfalse = new OpCode("brfalse");
        public static readonly OpCode Brfalse_S = new OpCode("brfalse.s");
        public static readonly OpCode Brtrue = new OpCode("brtrue");
        public static readonly OpCode Brtrue_S = new OpCode("brtrue.s");
        public static readonly OpCode Call = new OpCode("call");
        public static readonly OpCode Calli = new OpCode("calli");
        public static readonly OpCode Callvirt = new OpCode("callvirt");
        public static readonly OpCode Castclass = new OpCode("castclass");
        public static readonly OpCode Ceq = new OpCode("ceq");
        public static readonly OpCode Cgt = new OpCode("cgt");
        public static readonly OpCode Cgt_Un = new OpCode("cgt.un");
        public static readonly OpCode Ckfinite = new OpCode("ckfinite");
        public static readonly OpCode Clt = new OpCode("clt");
        public static readonly OpCode Clt_Un = new OpCode("clt.un");
        public static readonly OpCode Constrained = new OpCode("constrained.");
        public static readonly OpCode Conv_I = new OpCode("conv.i");
        public static readonly OpCode Conv_I1 = new OpCode("conv.i1");
        public static readonly OpCode Conv_I2 = new OpCode("conv.i2");
        public static readonly OpCode Conv_I4 = new OpCode("conv.i4");
        public static readonly OpCode Conv_I8 = new OpCode("conv.i8");
        public static readonly OpCode Conv_Ovf_I = new OpCode("conv.ovf.i");
        public static readonly OpCode Conv_Ovf_I_Un = new OpCode("conv.ovf.i.un");
        public static readonly OpCode Conv_Ovf_I1 = new OpCode("conv.ovf.i1");
        public static readonly OpCode Conv_Ovf_I1_Un = new OpCode("conv.ovf.i1.un");
        public static readonly OpCode Conv_Ovf_I2 = new OpCode("conv.ovf.i2");
        public static readonly OpCode Conv_Ovf_I2_Un = new OpCode("conv.ovf.i2.un");
        public static readonly OpCode Conv_Ovf_I4 = new OpCode("conv.ovf.i4");
        public static readonly OpCode Conv_Ovf_I4_Un = new OpCode("conv.ovf.i4.un");
        public static readonly OpCode Conv_Ovf_I8 = new OpCode("conv.ovf.i8");
        public static readonly OpCode Conv_Ovf_I8_Un = new OpCode("conv.ovf.i8.un");
        public static readonly OpCode Conv_Ovf_U = new OpCode("conv.ovf.u");
        public static readonly OpCode Conv_Ovf_U_Un = new OpCode("conv.ovf.u.un");
        public static readonly OpCode Conv_Ovf_U1 = new OpCode("conv.ovf.u1");
        public static readonly OpCode Conv_Ovf_U1_Un = new OpCode("conv.ovf.u1.un");
        public static readonly OpCode Conv_Ovf_U2 = new OpCode("conv.ovf.u2");
        public static readonly OpCode Conv_Ovf_U2_Un = new OpCode("conv.ovf.u2.un");
        public static readonly OpCode Conv_Ovf_U4 = new OpCode("conv.ovf.u4");
        public static readonly OpCode Conv_Ovf_U4_Un = new OpCode("conv.ovf.u4.un");
        public static readonly OpCode Conv_Ovf_U8 = new OpCode("conv.ovf.u8");
        public static readonly OpCode Conv_Ovf_U8_Un = new OpCode("conv.ovf.u8.un");
        public static readonly OpCode Conv_R_Un = new OpCode("conv.r.un");
        public static readonly OpCode Conv_R4 = new OpCode("conv.r4");
        public static readonly OpCode Conv_R8 = new OpCode("conv.r8");
        public static readonly OpCode Conv_U = new OpCode("conv.u");
        public static readonly OpCode Conv_U1 = new OpCode("conv.u1");
        public static readonly OpCode Conv_U2 = new OpCode("conv.u2");
        public static readonly OpCode Conv_U4 = new OpCode("conv.u4");
        public static readonly OpCode Conv_U8 = new OpCode("conv.u8");
        public static readonly OpCode Cpblk = new OpCode("cpblk");
        public static readonly OpCode Cpobj = new OpCode("cpobj");
        public static readonly OpCode Div = new OpCode("div");
        public static readonly OpCode Div_Un = new OpCode("div.un");
        public static readonly OpCode Dup = new OpCode("dup");
        public static readonly OpCode Endfilter = new OpCode("endfilter");
        public static readonly OpCode Endfinally = new OpCode("endfinally");
        public static readonly OpCode Initblk = new OpCode("initblk");
        public static readonly OpCode Initobj = new OpCode("initobj");
        public static readonly OpCode Isinst = new OpCode("isinst");
        public static readonly OpCode Jmp = new OpCode("jmp");
        public static readonly OpCode Ldarg = new OpCode("ldarg");
        public static readonly OpCode Ldarg_0 = new OpCode("ldarg.0");
        public static readonly OpCode Ldarg_1 = new OpCode("ldarg.1");
        public static readonly OpCode Ldarg_2 = new OpCode("ldarg.2");
        public static readonly OpCode Ldarg_3 = new OpCode("ldarg.3");
        public static readonly OpCode Ldarg_S = new OpCode("ldarg.s");
        public static readonly OpCode Ldarga = new OpCode("ldarga");
        public static readonly OpCode Ldarga_S = new OpCode("ldarga.s");
        public static readonly OpCode Ldc_I4 = new OpCode("ldc.i4");
        public static readonly OpCode Ldc_I4_0 = new OpCode("ldc.i4.0");
        public static readonly OpCode Ldc_I4_1 = new OpCode("ldc.i4.1");
        public static readonly OpCode Ldc_I4_2 = new OpCode("ldc.i4.2");
        public static readonly OpCode Ldc_I4_3 = new OpCode("ldc.i4.3");
        public static readonly OpCode Ldc_I4_4 = new OpCode("ldc.i4.4");
        public static readonly OpCode Ldc_I4_5 = new OpCode("ldc.i4.5");
        public static readonly OpCode Ldc_I4_6 = new OpCode("ldc.i4.6");
        public static readonly OpCode Ldc_I4_7 = new OpCode("ldc.i4.7");
        public static readonly OpCode Ldc_I4_8 = new OpCode("ldc.i4.8");
        public static readonly OpCode Ldc_I4_M1 = new OpCode("ldc.i4.m1");
        public static readonly OpCode Ldc_I4_S = new OpCode("ldc.i4.s");
        public static readonly OpCode Ldc_I8 = new OpCode("ldc.i8");
        public static readonly OpCode Ldc_R4 = new OpCode("ldc.r4");
        public static readonly OpCode Ldc_R8 = new OpCode("ldc.r8");
        public static readonly OpCode Ldelem = new OpCode("ldelem");
        public static readonly OpCode Ldelem_I = new OpCode("ldelem.i");
        public static readonly OpCode Ldelem_I1 = new OpCode("ldelem.i1");
        public static readonly OpCode Ldelem_I2 = new OpCode("ldelem.i2");
        public static readonly OpCode Ldelem_I4 = new OpCode("ldelem.i4");
        public static readonly OpCode Ldelem_I8 = new OpCode("ldelem.i8");
        public static readonly OpCode Ldelem_R4 = new OpCode("ldelem.r4");
        public static readonly OpCode Ldelem_R8 = new OpCode("ldelem.r8");
        public static readonly OpCode Ldelem_Ref = new OpCode("ldelem.ref");
        public static readonly OpCode Ldelem_U1 = new OpCode("ldelem.u1");
        public static readonly OpCode Ldelem_U2 = new OpCode("ldelem.u2");
        public static readonly OpCode Ldelem_U4 = new OpCode("ldelem.u4");
        public static readonly OpCode Ldelema = new OpCode("ldelema");
        public static readonly OpCode Ldfld = new OpCode("ldfld");
        public static readonly OpCode Ldflda = new OpCode("ldflda");
        public static readonly OpCode Ldftn = new OpCode("ldftn");
        public static readonly OpCode Ldind_I = new OpCode("ldind.i");
        public static readonly OpCode Ldind_I1 = new OpCode("ldind.i1");
        public static readonly OpCode Ldind_I2 = new OpCode("ldind.i2");
        public static readonly OpCode Ldind_I4 = new OpCode("ldind.i4");
        public static readonly OpCode Ldind_I8 = new OpCode("ldind.i8");
        public static readonly OpCode Ldind_R4 = new OpCode("ldind.r4");
        public static readonly OpCode Ldind_R8 = new OpCode("ldind.r8");
        public static readonly OpCode Ldind_Ref = new OpCode("ldind.ref");
        public static readonly OpCode Ldind_U1 = new OpCode("ldind.u1");
        public static readonly OpCode Ldind_U2 = new OpCode("ldind.u2");
        public static readonly OpCode Ldind_U4 = new OpCode("ldind.u4");
        public static readonly OpCode Ldlen = new OpCode("ldlen");
        public static readonly OpCode Ldloc = new OpCode("ldloc");
        public static readonly OpCode Ldloc_0 = new OpCode("ldloc.0");
        public static readonly OpCode Ldloc_1 = new OpCode("ldloc.1");
        public static readonly OpCode Ldloc_2 = new OpCode("ldloc.2");
        public static readonly OpCode Ldloc_3 = new OpCode("ldloc.3");
        public static readonly OpCode Ldloc_S = new OpCode("ldloc.s");
        public static readonly OpCode Ldloca = new OpCode("ldloca");
        public static readonly OpCode Ldloca_S = new OpCode("ldloca.s");
        public static readonly OpCode Ldnull = new OpCode("ldnull");
        public static readonly OpCode Ldobj = new OpCode("ldobj");
        public static readonly OpCode Ldsfld = new OpCode("ldsfld");
        public static readonly OpCode Ldsflda = new OpCode("ldsflda");
        public static readonly OpCode Ldstr = new OpCode("ldstr");
        public static readonly OpCode Ldtoken = new OpCode("ldtoken");
        public static readonly OpCode Ldvirtftn = new OpCode("ldvirtftn");
        public static readonly OpCode Leave = new OpCode("leave");
        public static readonly OpCode Leave_S = new OpCode("leave.s");
        public static readonly OpCode Localloc = new OpCode("localloc");
        public static readonly OpCode Mkrefany = new OpCode("mkrefany");
        public static readonly OpCode Mul = new OpCode("mul");
        public static readonly OpCode Mul_Ovf = new OpCode("mul.ovf");
        public static readonly OpCode Mul_Ovf_Un = new OpCode("mul.ovf.un");
        public static readonly OpCode Neg = new OpCode("neg");
        public static readonly OpCode Newarr = new OpCode("newarr");
        public static readonly OpCode Newobj = new OpCode("newobj");
        public static readonly OpCode Nop = new OpCode("nop");
        public static readonly OpCode Not = new OpCode("not");
        public static readonly OpCode Or = new OpCode("or");
        public static readonly OpCode Pop = new OpCode("pop");
        public static readonly OpCode Readonly = new OpCode("readonly.");
        public static readonly OpCode Refanytype = new OpCode("refanytype");
        public static readonly OpCode Refanyval = new OpCode("refanyval");
        public static readonly OpCode Rem = new OpCode("rem");
        public static readonly OpCode Rem_Un = new OpCode("rem.un");
        public static readonly OpCode Ret = new OpCode("ret");
        public static readonly OpCode Rethrow = new OpCode("rethrow");
        public static readonly OpCode Shl = new OpCode("shl");
        public static readonly OpCode Shr = new OpCode("shr");
        public static readonly OpCode Shr_Un = new OpCode("shr.un");
        public static readonly OpCode Sizeof = new OpCode("sizeof");
        public static readonly OpCode Starg = new OpCode("starg");
        public static readonly OpCode Starg_S = new OpCode("starg.s");
        public static readonly OpCode Stelem = new OpCode("stelem");
        public static readonly OpCode Stelem_I = new OpCode("stelem.i");
        public static readonly OpCode Stelem_I1 = new OpCode("stelem.i1");
        public static readonly OpCode Stelem_I2 = new OpCode("stelem.i2");
        public static readonly OpCode Stelem_I4 = new OpCode("stelem.i4");
        public static readonly OpCode Stelem_I8 = new OpCode("stelem.i8");
        public static readonly OpCode Stelem_R4 = new OpCode("stelem.r4");
        public static readonly OpCode Stelem_R8 = new OpCode("stelem.r8");
        public static readonly OpCode Stelem_Ref = new OpCode("stelem.ref");
        public static readonly OpCode Stfld = new OpCode("stfld");
        public static readonly OpCode Stind_I = new OpCode("stind.i");
        public static readonly OpCode Stind_I1 = new OpCode("stind.i1");
        public static readonly OpCode Stind_I2 = new OpCode("stind.i2");
        public static readonly OpCode Stind_I4 = new OpCode("stind.i4");
        public static readonly OpCode Stind_I8 = new OpCode("stind.i8");
        public static readonly OpCode Stind_R4 = new OpCode("stind.r4");
        public static readonly OpCode Stind_R8 = new OpCode("stind.r8");
        public static readonly OpCode Stind_Ref = new OpCode("stind.ref");
        public static readonly OpCode Stloc = new OpCode("stloc");
        public static readonly OpCode Stloc_0 = new OpCode("stloc.0");
        public static readonly OpCode Stloc_1 = new OpCode("stloc.1");
        public static readonly OpCode Stloc_2 = new OpCode("stloc.2");
        public static readonly OpCode Stloc_3 = new OpCode("stloc.3");
        public static readonly OpCode Stloc_S = new OpCode("stloc.s");
        public static readonly OpCode Stobj = new OpCode("stobj");
        public static readonly OpCode Stsfld = new OpCode("stsfld");
        public static readonly OpCode Sub = new OpCode("sub");
        public static readonly OpCode Sub_Ovf = new OpCode("sub.ovf");
        public static readonly OpCode Sub_Ovf_Un = new OpCode("sub.ovf.un");
        public static readonly OpCode Switch = new OpCode("switch");
        public static readonly OpCode Tailcall = new OpCode("tail.");
        public static readonly OpCode Throw = new OpCode("throw");
        public static readonly OpCode Unaligned = new OpCode("unaligned.");
        public static readonly OpCode Unbox = new OpCode("unbox");
        public static readonly OpCode Unbox_Any = new OpCode("unbox.any");
        public static readonly OpCode Volatile = new OpCode("volatile.");
        public static readonly OpCode Xor = new OpCode("xor");
    }
}

