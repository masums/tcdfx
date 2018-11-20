﻿/***************************************************************************************************
 * FileName:             Surface.cs
 * Date:                 20181008
 * Copyright:            Copyright © 2017-2018 Thomas Corwin, et al. All Rights Reserved.
 * License:              https://github.com/tacdevel/tcdfx/blob/master/LICENSE.md
 **************************************************************************************************/

namespace TCD.Drawing
{
    /// <summary>
    /// Represents a control with a drawable surface.
    /// </summary>
    public class Surface : SurfaceBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Surface"/> class with the specified <see cref="SurfaceHandler"/>.
        /// </summary>
        /// <param name="handler">The specified event handler.</param>
        public Surface(SurfaceHandler handler) : base(handler, false, 0, 0) { }
    }
}