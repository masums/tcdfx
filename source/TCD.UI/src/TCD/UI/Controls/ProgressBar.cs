﻿/***************************************************************************************************
 * FileName:             ProgressBar.cs
 * Date:                 20181001
 * Copyright:            Copyright © 2017-2018 Thomas Corwin, et al. All Rights Reserved.
 * License:              https://github.com/tacdevel/tcdfx/blob/master/LICENSE.md
 **************************************************************************************************/

using TCD.InteropServices;
using TCD.Native;
using TCD.SafeHandles;

namespace TCD.UI.Controls
{
    /// <summary>
    /// Represents a control that indicates the progress of an operation.
    /// </summary>
    public class ProgressBar : Control
    {
        private int value = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressBar"/> class.
        /// </summary>
        public ProgressBar() : base(new SafeControlHandle(Libui.NewProgressBar())) { }

        /// <summary>
        /// Gets or sets the current value of this <see cref="ProgressBar"/>.
        /// </summary>
        public int Value
        {
            get
            {
                if (IsInvalid) throw new InvalidHandleException();
                value = Libui.ProgressBarValue(Handle);
                return value;
            }
            set
            {
                if (this.value == value) return;
                if (IsInvalid) throw new InvalidHandleException();
                Libui.ProgressBarSetValue(Handle, value);
                this.value = value;
            }
        }
    }
}