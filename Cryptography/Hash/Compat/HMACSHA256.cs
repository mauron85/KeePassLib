﻿using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Security.Cryptography.Core;

namespace KeePassLib.Cryptography.Hash.Compat
{
    public class HMACSHA256 : HashAlgorithm
    {
        public HMACSHA256(byte[] key) : base(MacAlgorithmProvider.OpenAlgorithm(MacAlgorithmNames.HmacSha256).CreateHash(key.AsBuffer())) { }
    }
}
