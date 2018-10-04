using System;

namespace KeePassLib.Security.Compat
{
    class ProtectedMemory
    {
        internal static void Protect(byte[] pb, object sameProcess)
        {
            throw new NotImplementedException();
        }

        internal static void Unprotect(byte[] m_pbData, MemoryProtectionScope sameProcess)
        {
            throw new NotImplementedException();
        }
    }

    public enum MemoryProtectionScope
    {
        CrossProcess = 1,
        SameLogon = 2,
        SameProcess = 0
    }
}
