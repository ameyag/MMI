﻿using System;

namespace Microsoft.Management.Infrastructure.Native
{
    using System.Runtime.InteropServices;

    public class MI_PlatformSpecific
    {
#if !_LINUX
        public const UnmanagedType AppropriateStringType = UnmanagedType.LPWStr;
        public const CharSet AppropriateCharSet = CharSet.Unicode;
        public const CallingConvention MiMainCallConvention = CallingConvention.Cdecl;
        public const CallingConvention MiCallConvention = CallingConvention.StdCall;
        public const string MI = "mi.dll";

        public static string PtrToString(IntPtr ptr)
        {
            return Marshal.PtrToStringUni(ptr);
        }

        public static IntPtr StringToPtr(string str)
        {
            return Marshal.StringToHGlobalUni(str);
        }

#else
        public const UnmanagedType AppropriateStringType = UnmanagedType.LPStr;
        public const CharSet AppropriateCharSet = CharSet.Ansi;
        public const CallingConvention MiMainCallConvention = CallingConvention.Cdecl;
        public const CallingConvention MiCallConvention = CallingConvention.Cdecl;
        public const string MI = "libmi.so";

        public static string PtrToString(IntPtr ptr)
        {
            return Marshal.PtrToStringAnsi(ptr);
        }

        public static IntPtr StringToPtr(string str)
        {
            return Marshal.StringToHGlobalAnsi(str);
        }
#endif
    }
}