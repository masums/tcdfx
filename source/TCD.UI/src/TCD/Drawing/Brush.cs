﻿/****************************************************************************
 * FileName:   Brush.cs
 * Assembly:   TCD.UI.dll
 * Package:    TCD.UI
 * Date:       20181002
 * License:    MIT License
 * LicenseUrl: https://github.com/tacdevel/TDCFx/blob/master/LICENSE.md
 ***************************************************************************/

using System;
using System.Runtime.InteropServices;

namespace TCD.Drawing
{
    /// <summary>
    /// Defines objects used to paint graphical objects. Classes that derive from <see cref="Brush"/> describe how the area is painted.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public abstract class Brush
    {
        [MarshalAs(UnmanagedType.I4)]
        internal BrushType type;

        // Solid Brushes
        internal double r, g, b, a;

        // Gradient Brushes
        // X0          - Linear: StartX, Radial: StartX
        // Y0          - Linear: StartY, Radial: StartY
        // X1          - Linear: EndX,   Radial: CenterX (of outer circle)
        // Y1          - Linear: EndY,   Radial: CenterY (of outer circle)
        // outerRadius - Linear: Unused, Radial: Used
        internal double x0, y0, x1, y1, outerRadius;
        internal IntPtr stops;
        internal UIntPtr numStops;
    }
}