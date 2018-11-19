﻿/***************************************************************************************************
 * FileName:             FontFamilyAttribute.cs
 * Date:                 20181119
 * Copyright:            Copyright © 2017-2018 Thomas Corwin, et al. All Rights Reserved.
 * License:              https://github.com/tacdevel/tcdfx/blob/master/LICENSE.md
 **************************************************************************************************/

using static LibUISharp.Native.NativeMethods;

namespace LibUISharp.Drawing
{
    public sealed class FontFamilyAttribute : TextAttribute
    {
        public FontFamilyAttribute(string family) => Handle = Libui.uiNewFamilyAttribute(family);

        public string FontFamily => Libui.uiAttributeFamily(this);
    }
}