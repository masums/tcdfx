﻿/***************************************************************************************************
 * FileName:             SurfaceBase.cs
 * Date:                 20181008
 * Copyright:            Copyright © 2017-2018 Thomas Corwin, et al. All Rights Reserved.
 * License:              https://github.com/tacdevel/tcdfx/blob/master/LICENSE.md
 **************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Threading;
using TCD.InteropServices;
using TCD.Native;
using TCD.SafeHandles;
using TCD.UI.Controls;

namespace TCD.Drawing
{
    /// <summary>
    /// Implements the basic functonality required by a drawable surface.
    /// </summary>
    public abstract class SurfaceBase : Control
    {
        private static Dictionary<SurfaceBase, Libui.AreaHandler> handlerCache = new Dictionary<SurfaceBase, Libui.AreaHandler>();
        private static Dictionary<IntPtr, SurfaceBase> surfaceCache = new Dictionary<IntPtr, SurfaceBase>();

        internal SurfaceBase(SurfaceHandler handler, bool scrollable, int width, int height, bool cacheable = true) : base(GetHandle(handler, scrollable, width, height, out Libui.AreaHandler outHandler), cacheable)
        {
            handlerCache.Add(this, outHandler);
            surfaceCache.Add(Handle, this);
        }

        /// <summary>
        /// Sets the content size of this <see cref="Surface"/>.
        /// </summary>
        public Size Size
        {
            set
            {
                if (IsInvalid) throw new InvalidHandleException();
                Libui.AreaSetSize(Handle, value.Width, value.Height);
            }
        }

        /// <summary>
        /// Queues a redraw of the surface.
        /// </summary>
        public void QueueRedrawAll()
        {
            Thread.Sleep(200); // Must sleep for 200ms or else crashes
            if (IsInvalid) throw new InvalidHandleException();
            Libui.AreaQueueRedrawAll(Handle);
        }
        
        public void BeginUserWindowMove()
        {
            if (IsInvalid) throw new InvalidHandleException();
            Libui.AreaBeginUserWindowMove(Handle);
        }
        
        public void BeginUserWindowResize(WindowEdge edge)
        {
            if (IsInvalid) throw new InvalidHandleException();
            Libui.AreaBeginUserWindowResize(Handle, edge);
        }

        private static SafeControlHandle GetHandle(SurfaceHandler handler, bool scrollable, int width, int height, out Libui.AreaHandler outHandler)
        {
            outHandler = new Libui.AreaHandler
            {
                Draw = (nativeHandler, surface, args) => handler.Draw(surfaceCache[surface], ref args),
                MouseEvent = (nativeHandler, surface, args) => handler.MouseEvent(surfaceCache[surface], ref args),
                MouseCrossed = (nativeHandler, surface, left) => handler.MouseCrossed(surfaceCache[surface], left),
                DragBroken = (nativeHandler, surface) => handler.DragBroken(surfaceCache[surface]),
                KeyEvent = (nativeHandler, surface, args) => handler.KeyEvent(surfaceCache[surface], ref args)
            };

            return !scrollable
                ? new SafeControlHandle(Libui.NewArea(outHandler))
                : new SafeControlHandle(Libui.NewScrollingArea(outHandler, width, height));
        }
    }
}