/***************************************************************************************************
 * FileName:             Libdl.cs
 * Date:                 20180913
 * Copyright:            Copyright � 2017-2018 Thomas Corwin, et al. All Rights Reserved.
 * License:              https://github.com/tacdevel/tcdfx/blob/master/LICENSE.md
 **************************************************************************************************/

using System;
using System.Runtime.InteropServices;

namespace TCD.Native
{
    internal static class Libdl
    {
        [DllImport(AssemblyRef.Libdl)]
        internal static extern IntPtr dlopen(string fileName, int flags);

        [DllImport(AssemblyRef.Libdl)]
        internal static extern IntPtr dlsym(IntPtr handle, string name);

        [DllImport(AssemblyRef.Libdl)]
        internal static extern int dlclose(IntPtr handle);
    }
}