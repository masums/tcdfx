﻿/*******************************************************************************
 * FileName:   Color.cs
 * Date:       20180913
 * License:    MIT License
 * Copyrights: 2018 (c) Thomas Corwin, et al. All Rights Reserved.
 * LicenseUrl: https://github.com/tacdevel/tcdfx/blob/master/LICENSE.md
 ******************************************************************************/

using System;
using System.Runtime.InteropServices;

namespace TCD.Drawing
{
    /// <summary>
    /// Represents an ARGB (alpha, red, green, blue) color.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Color : IEquatable<Color>
    {
        /// <summary>
        /// Represents a color that is <see langword="null"/>.
        /// </summary>
        public static readonly Color Empty = new Color();

        /// <summary>
        /// Initializes a new <see cref="Color"/> structure from an argb value.
        /// </summary>
        /// <param name="argb">An argb value.</param>
        public Color(long argb) : this(((argb >> 16) & 0xFF) / 255.0, ((argb >> 8) & 0xFF) / 255.0, (argb & 0xFF) / 255.0, ((argb >> 24) & 0xFF) / 255.0) { }

        /// <summary>
        /// Initializes a new <see cref="Color"/> structure from red, green, blue, and optionally alpha component values.
        /// </summary>
        /// <param name="r">The red value.</param>
        /// <param name="g">The green value.</param>
        /// <param name="b">The blue value.</param>
        /// <param name="a">The alpha value.</param>
        public Color(double r, double g, double b, double a = 1.0)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        /// <summary>
        /// Gets the red component for this <see cref="Color"/> structure.
        /// </summary>
        public double R { get; }

        /// <summary>
        /// Gets the green component for this <see cref="Color"/> structure.
        /// </summary>
        public double G { get; }

        /// <summary>
        /// Gets the blue component for this <see cref="Color"/> structure.
        /// </summary>
        public double B { get; }

        /// <summary>
        /// Gets the alpha component for this <see cref="Color"/> structure.
        /// </summary>
        public double A { get; }

        /// <summary>
        /// Specifies whether this <see cref="Color"/> structure is uninitialized.
        /// </summary>
        public bool IsEmpty => this == Empty;

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns><see langword="true"/> if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj) => !(obj is Color) ? false : Equals((Color)obj);

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="color">The <see cref="Color"/> to compare with the current instance.</param>
        /// <returns><see langword="true"/> if <paramref name="color"/> and this instance are the same type and represent the same value; otherwise, <see langword="false"/>.</returns>
        public bool Equals(Color color) => R == color.R && G == color.G && B == color.B && A == color.A;

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for this <see cref="Color"/>.</returns>
        public override int GetHashCode() => unchecked(this.GenerateHashCode(R, G, B, A));

        /// <summary>
        /// Returns a string that represents this <see cref="Color"/>.
        /// </summary>
        /// <returns>A string that represents this <see cref="Color"/>.</returns>
        public override string ToString() => $"[R: {R}, G: {G}, B: {B}, A: {A}]";

        /// <summary>
        /// Tests whether two specified <see cref="Color"/> structures are equivalent.
        /// </summary>
        /// <param name="left">The <see cref="Color"/> that is to the left of the equality operator.</param>
        /// <param name="right">The <see cref="Color"/> that is to the right of the equality operator.</param>
        /// <returns><see langword="true"/> if the two <see cref="Color"/> structures are equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(Color left, Color right) => left.Equals(right);

        /// <summary>
        /// Tests whether two specified <see cref="Color"/> structures are different.
        /// </summary>
        /// <param name="left">The <see cref="Color"/> that is to the left of the inequality operator.</param>
        /// <param name="right">The <see cref="Color"/> that is to the right of the inequality operator.</param>
        /// <returns><see langword="true"/> if the two <see cref="Color"/> structures are different; otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(Color left, Color right) => !(left == right);
    }
}