﻿/****************************************************************************
 * FileName:   Menu.cs
 * Assembly:   TCD.UI.dll
 * Package:    TCD.UI
 * Date:       20181002
 * License:    MIT License
 * LicenseUrl: https://github.com/tacdevel/TDCFx/blob/master/LICENSE.md
 ***************************************************************************/

using System;
using TCD.InteropServices;
using TCD.Native;
using TCD.SafeHandles;
using TCD.UI.Controls.Containers;

namespace TCD.UI.Controls
{
    /// <summary>
    /// Represents a menu control that enables you to add elements associated with commands and event handlers.
    /// </summary>
    public sealed class Menu : MultiChildContainer<MenuItemBase, Menu.MenuItemCollection>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class with the specified name.
        /// </summary>
        /// <param name="name">The specified name.</param>
        internal Menu(string name) : base(new SafeControlHandle(Libui.NewMenu(name))) => Name = name;

        /// <summary>
        /// Gets the name of this <see cref="Menu"/>.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Represents a collection of child <see cref="MenuItemBase"/> objects inside of a <see cref="Menu"/>.
        /// </summary>
        public class MenuItemCollection : ControlCollectionBase<MenuItemBase>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="MenuItemCollection"/> class with the specified parent.
            /// </summary>
            /// <param name="owner">The parent <see cref="Menu"/> of this <see cref="MenuItemCollection"/>.</param>
            public MenuItemCollection(Menu owner) : base(owner) { }

            /// <summary>
            /// <see cref="MenuItemCollection"/> does not support this method, and will throw a <see cref="NotSupportedException"/>.
            /// </summary>
            /// <param name="child">The <see cref="MenuItemBase"/> to be added to the end of the <see cref="MenuItemCollection"/>.</param>
            public override void Add(MenuItemBase child) => throw new NotSupportedException();

            /// <summary>
            /// Adds a <see cref="MenuItem"/> to the end of the <see cref="MenuItemCollection"/>.
            /// </summary>
            /// <param name="name">The name of the <see cref="Control"/> to be added to the end of the <see cref="MenuItemCollection"/>.</param>
            /// <param name="click">The action invoked when the child is clicked.</param>
            public void Add(string name, Action<IntPtr> click = null)
            {
                if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
                if (Owner.IsInvalid) throw new InvalidHandleException();

                MenuItem item = new MenuItem(new SafeControlHandle(Libui.MenuAppendItem(Owner.Handle, name)), name);
                if (click != null)
                {
                    item.Clicked += (data) =>
                    {
                        if (data != null)
                            click(data);
                    };
                }
                base.Add(item);
            }

            /// <summary>
            /// Adds a <see cref="CheckableMenuItem"/> to the end of the <see cref="MenuItemCollection"/>.
            /// </summary>
            /// <param name="name">The name of the <see cref="Control"/> to be added to the end of the <see cref="MenuItemCollection"/>.</param>
            /// <param name="click">The action invoked when the child is clicked.</param>
            public void AddCheckable(string name, Action<IntPtr> click = null)
            {
                if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
                if (Owner.IsInvalid) throw new InvalidHandleException();

                CheckableMenuItem item = new CheckableMenuItem(new SafeControlHandle(Libui.MenuAppendCheckItem(Owner.Handle, name)), name);
                if (click != null)
                {
                    item.Clicked += (data) =>
                    {
                        if (data != null)
                            click(data);
                    };
                }
                base.Add(item);
            }

            /// <summary>
            /// Adds a <see cref="PreferencesMenuItem"/> to the end of the <see cref="MenuItemCollection"/>.
            /// </summary>
            /// <param name="click">The action invoked when the child is clicked.</param>
            public void AddPreferences(Action<IntPtr> click = null)
            {
                if (Owner.IsInvalid) throw new InvalidHandleException();

                PreferencesMenuItem item = new PreferencesMenuItem(new SafeControlHandle(Libui.MenuAppendPreferencesItem(Owner.Handle)));
                if (click != null)
                {
                    item.Clicked += (data) =>
                    {
                        if (data != null)
                            click(data);
                    };
                }
                base.Add(item);
            }

            /// <summary>
            /// Adds a <see cref="AboutMenuItem"/> to the end of the <see cref="MenuItemCollection"/>.
            /// </summary>
            /// <param name="click">The action invoked when the child is clicked.</param>
            public void AddAbout(Action<IntPtr> click = null)
            {
                if (Owner.IsInvalid) throw new InvalidHandleException();

                AboutMenuItem item = new AboutMenuItem(new SafeControlHandle(Libui.MenuAppendAboutItem(Owner.Handle)));
                if (click != null)
                {
                    item.Clicked += (data) =>
                    {
                        if (data != null)
                            click(data);
                    };
                }
                base.Add(item);
            }

            /// <summary>
            /// Adds a <see cref="QuitMenuItem"/> to the end of the <see cref="MenuItemCollection"/>.
            /// </summary>
            public void AddQuit()
            {
                if (Owner.IsInvalid) throw new InvalidHandleException();
                QuitMenuItem item = new QuitMenuItem(new SafeControlHandle(Libui.MenuAppendQuitItem(Owner.Handle)));
                base.Add(item);
            }

            /// <summary>
            /// Adds a separator to the end of the <see cref="MenuItemCollection"/>.
            /// </summary>
            public void AddSeparator()
            {
                if (Owner.IsInvalid) throw new InvalidHandleException();
                Libui.MenuAppendSeparator(Owner.Handle);
            }

            /// <summary>
            /// <see cref="MenuItemCollection"/> does not support this method, and will throw a <see cref="NotSupportedException"/>.
            /// </summary>
            /// <param name="index">The zero-based index at which child should be inserted.</param>
            /// <param name="child">The <see cref="Control"/> to insert into the <see cref="MenuItemCollection"/>.</param>
            public override void Insert(int index, MenuItemBase child) => throw new NotSupportedException();

            /// <summary>
            /// <see cref="MenuItemCollection"/> does not support this method, and will throw a <see cref="NotSupportedException"/>.
            /// </summary>
            /// <param name="child">The <see cref="Control"/> to remove from the <see cref="MenuItemCollection"/>.</param>
            /// <returns>true if child is successfully removed; otherwise, false. This method also returns false if child was not found in the <see cref="MenuItemCollection"/>.</returns>
            public override bool Remove(MenuItemBase child) => throw new NotSupportedException();
        }
    }
}