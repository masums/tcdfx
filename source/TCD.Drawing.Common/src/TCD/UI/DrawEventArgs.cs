﻿/***************************************************************************************************
 * FileName:             DrawEventArgs.cs
 * Date:                 20181003
 * Copyright:            Copyright © 2017-2018 Thomas Corwin, et al. All Rights Reserved.
 * License:              https://github.com/tacdevel/tcdfx/blob/master/LICENSE.md
 **************************************************************************************************/

using System;
using System.Runtime.InteropServices;

namespace TCD.Drawing
{
    /// <summary>
    /// Provides drawing data for an event.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public sealed class DrawEventArgs : NativeEventArgs
    {
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable IDE0032 // Use auto property
        private IntPtr contextPtr;
        private double surfaceWidth, surfaceHeight; //! Only defined for non-scrolling areas.
        private double clipX, clipY, clipWidth, clipHeight;
        private Context context;
#pragma warning restore IDE0032 // Use auto property
#pragma warning restore IDE0044 // Add readonly modifier

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawEventArgs"/> class with the specified event data.
        /// </summary>
        /// <param name="context">The drawing context.</param>
        /// <param name="clip">The rectangle that has been requested to be redrawn.</param>
        /// <param name="surfaceSize">The current size of the surface.</param>
        public DrawEventArgs(Context context, RectangleD clip, SizeD surfaceSize)
        {
            this.context = context;
            contextPtr = this.context.Surface.Handle;
            surfaceWidth = surfaceSize.Width;
            surfaceHeight = surfaceSize.Height;
            clipX = clip.X;
            clipY = clip.Y;
            clipWidth = clip.Width;
            clipHeight = clip.Height;
        }

        /// <summary>
        /// Gets the drawing context.
        /// </summary>
        public Context Context => context;

        /// <summary>
        /// Gets the clip to be redrawn.
        /// </summary>
        public RectangleD Clip => new RectangleD(clipX, clipY, clipWidth, clipHeight);

        /// <summary>
        /// Gets the surface's current size.
        /// </summary>
        public SizeD SurfaceSize => new SizeD(surfaceWidth, surfaceHeight);
    }
}