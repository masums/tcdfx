﻿/****************************************************************************
 * FileName:   Label.cs
 * Assembly:   TCD.UI.dll
 * Package:    TCD.UI
 * Date:       20181001
 * License:    MIT License
 * LicenseUrl: https://github.com/tacdevel/TDCFx/blob/master/LICENSE.md
 ***************************************************************************/

using TCD.InteropServices;
using TCD.Native;
using TCD.SafeHandles;

namespace TCD.UI.Controls
{
    /// <summary>
    /// Represents a standard label, which contains and shows text.
    /// </summary>
    public class Label : Control
    {
        private string text;

        /// <summary>
        /// Initializes a new instance of the <see cref="Label"/> class with the specified text.
        /// </summary>
        /// <param name="text">The specified text for this <see cref="Label"/>.</param>
        public Label(string text) : base(new SafeControlHandle(Libui.NewLabel(text))) => this.text = text;

        /// <summary>
        /// Gets or sets this <see cref="Label"/>'s text.
        /// </summary>
        public string Text
        {
            get
            {
                if (IsInvalid) throw new InvalidHandleException();
                text = Libui.LabelText(Handle);
                return text;
            }
            set
            {
                if (text == value) return;
                if (IsInvalid) throw new InvalidHandleException();
                Libui.LabelSetText(Handle, value);
                text = value;
            }
        }
    }
}