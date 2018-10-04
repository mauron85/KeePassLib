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

using System;
using Windows.Security.Cryptography.Core;

namespace KeePassLib.Cryptography.Hash.Compat
{
    public class SHA512Managed : HashAlgorithm, IHashAlgorithmCompat
    {
        public SHA512Managed() : base(HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha512).CreateHash()) { }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        void IHashAlgorithmCompat.TransformBlock(byte[] pbBuf1, int v1, int length, byte[] pbBuf2, int v2)
        {
            throw new NotImplementedException();
        }

        void IHashAlgorithmCompat.TransformFinalBlock(byte[] emptyByteArray, int v1, int v2)
        {
            throw new NotImplementedException();
        }
    }
}