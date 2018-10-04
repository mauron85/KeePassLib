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
using System.Diagnostics;
using System.IO;
using Org.BouncyCastle.Crypto;

using KeePassLib.Utility;

namespace KeePassLib.Cryptography
{
	public sealed class HashingStreamEx : Stream
	{
		private readonly Stream m_sBaseStream;
		private readonly bool m_bWriting;
        private IDigest m_digest;

        private byte[] m_pbFinalHash = null;

		public byte[] Hash
		{
			get { return m_pbFinalHash; }
		}

		public override bool CanRead
		{
			get { return !m_bWriting; }
		}

		public override bool CanSeek
		{
			get { return false; }
		}

		public override bool CanWrite
		{
			get { return m_bWriting; }
		}

		public override long Length
		{
			get { return m_sBaseStream.Length; }
		}

		public override long Position
		{
			get { return m_sBaseStream.Position; }
			set { Debug.Assert(false); throw new NotSupportedException(); }
		}

        public HashingStreamEx(Stream sBaseStream, bool bWriting, IDigest digest)
        {
            if (sBaseStream == null) throw new ArgumentNullException("sBaseStream");

            m_sBaseStream = sBaseStream;
            m_bWriting = bWriting;

            m_digest = (digest) ?? GetBouncyAlgorithm(System.Security.Cryptography.HashAlgorithmName.SHA256);
        }

        protected override void Dispose(bool disposing)
		{
            if (disposing)
            {
                if(m_digest != null)
				{
					try
					{
                        m_pbFinalHash = new byte[m_digest.GetDigestSize()];
					}
					catch(Exception) { Debug.Assert(false); }

                    m_digest = null;
				}
            }

            base.Dispose(disposing);
        }

		public override void Flush()
		{
			m_sBaseStream.Flush();
		}

		public override long Seek(long lOffset, SeekOrigin soOrigin)
		{
			throw new NotSupportedException();
		}

		public override void SetLength(long lValue)
		{
			throw new NotSupportedException();
		}

		public override int Read(byte[] pbBuffer, int nOffset, int nCount)
		{
			if(m_bWriting) throw new InvalidOperationException();

			int nRead = m_sBaseStream.Read(pbBuffer, nOffset, nCount);
			int nPartialRead = nRead;
			while((nRead < nCount) && (nPartialRead != 0))
			{
				nPartialRead = m_sBaseStream.Read(pbBuffer, nOffset + nRead,
					nCount - nRead);
				nRead += nPartialRead;
			}

#if DEBUG
			byte[] pbOrg = new byte[pbBuffer.Length];
			Array.Copy(pbBuffer, pbOrg, pbBuffer.Length);
#endif

            if ((m_digest != null) && (nRead > 0))
            {
                //TODO check
                m_digest.BlockUpdate(pbBuffer, nOffset, nRead);
            }

#if DEBUG
            Debug.Assert(MemUtil.ArraysEqual(pbBuffer, pbOrg));
#endif

            return nRead;
		}

		public override void Write(byte[] pbBuffer, int nOffset, int nCount)
		{
			if(!m_bWriting) throw new InvalidOperationException();

#if DEBUG
			byte[] pbOrg = new byte[pbBuffer.Length];
			Array.Copy(pbBuffer, pbOrg, pbBuffer.Length);
#endif

			if((m_digest != null) && (nCount > 0))
            {
                //TODO check
                m_digest.BlockUpdate(pbBuffer, nOffset, nCount);
            }


#if DEBUG
            Debug.Assert(MemUtil.ArraysEqual(pbBuffer, pbOrg));
#endif

			m_sBaseStream.Write(pbBuffer, nOffset, nCount);
		}

        private static Org.BouncyCastle.Crypto.IDigest GetBouncyAlgorithm(
            System.Security.Cryptography.HashAlgorithmName hashAlgorithmName)
        {
            if (hashAlgorithmName == System.Security.Cryptography.HashAlgorithmName.MD5)
                return new Org.BouncyCastle.Crypto.Digests.MD5Digest();
            if (hashAlgorithmName == System.Security.Cryptography.HashAlgorithmName.SHA1)
                return new Org.BouncyCastle.Crypto.Digests.Sha1Digest();
            if (hashAlgorithmName == System.Security.Cryptography.HashAlgorithmName.SHA256)
                return new Org.BouncyCastle.Crypto.Digests.Sha256Digest();
            if (hashAlgorithmName == System.Security.Cryptography.HashAlgorithmName.SHA384)
                return new Org.BouncyCastle.Crypto.Digests.Sha384Digest();
            if (hashAlgorithmName == System.Security.Cryptography.HashAlgorithmName.SHA512)
                return new Org.BouncyCastle.Crypto.Digests.Sha512Digest();

            throw new System.Security.Cryptography.CryptographicException(
                $"Unknown hash algorithm \"{hashAlgorithmName.Name}\"."
            );
        } // End Function GetBouncyAlgorithm  

    }
}
