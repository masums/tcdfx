﻿/****************************************************************************
 * FileName:   TimePicker.cs
 * Assembly:   TCD.UI.dll
 * Package:    TCD.UI
 * Date:       20181001
 * License:    MIT License
 * LicenseUrl: https://github.com/tacdevel/TDCFx/blob/master/LICENSE.md
 ***************************************************************************/

using System;
using TCD.Native;
using TCD.SafeHandles;

namespace TCD.UI.Controls
{
    /// <summary>
    /// Represents a control that allows the user to select and display a time.
    /// </summary>
    public class TimePicker : DateTimePickerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimePicker"/> class.
        /// </summary>
        public TimePicker() : base(new SafeControlHandle(Libui.NewTimePicker())) => InitializeEvents();

        /// <summary>
        /// Gets the hour component from <see cref="DateTime"/>.
        /// </summary>
        public int Hour => DateTime.Hour;

        /// <summary>
        /// Gets the minute component from <see cref="DateTime"/>.
        /// </summary>
        public int Minute => DateTime.Minute;

        /// <summary>
        /// Gets the second component from <see cref="DateTime"/>.
        /// </summary>
        public int Second => DateTime.Second;
    }
}