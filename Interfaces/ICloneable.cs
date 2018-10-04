/*
  KeePass Password Safe - The Open-Source Password Manager
  Copyright (C) 2003-2018 Dominik Reichl <dominik.reichl@t-online.de>

  This program is free software; you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation; either version 2 of the License, or
  (at your option) any later version.

  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program; if not, write to the Free Software
  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/

namespace KeePassLib.Collections
{

    public interface ICloneable
    {

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        object Clone();
    }

    /// <summary>
    /// Supports cloning, which creates a new instance of a class with the same value as an existing instance.
    /// </summary>
    /// <typeparam name="T">The concrete type of the clone instance.</typeparam>
    public interface ICloneable<T>
    {

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        T Clone();
    }
}