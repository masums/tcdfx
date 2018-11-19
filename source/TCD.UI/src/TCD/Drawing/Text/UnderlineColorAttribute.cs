﻿/***************************************************************************************************
 * FileName:             UnderlineColorAttribute.cs
 * Date:                 20181119
 * Copyright:            Copyright © 2017-2018 Thomas Corwin, et al. All Rights Reserved.
 * License:              https://github.com/tacdevel/tcdfx/blob/master/LICENSE.md
 **************************************************************************************************/

using static LibUISharp.Native.NativeMethods;

namespace LibUISharp.Drawing
{
    public sealed class UnderlineColorAttribute : TextAttribute
    {
        public UnderlineColorAttribute(UnderlineColor u, Color color) => Handle = Libui.uiNewUnderlineColorAttribute(u, color.R, color.G, color.B, color.A);

        public UnderlineColor UnderlineColor
        {
            get
            {
                Libui.uiAttributeUnderlineColor(this, out UnderlineColor u, out double r, out double g, out double b, out double a);
                return u;
            }
        }

        public Color Color
        {
            get
            {
                Libui.uiAttributeUnderlineColor(this, out UnderlineColor u, out double r, out double g, out double b, out double a);
                return new Color(r, g, b, a);
            }
        }
    }
}