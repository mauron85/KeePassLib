﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KeePassLib.Cryptography.Hash.Compat
{
    class RijndaelManaged : SymmetricAlgorithm
    {
        public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV)
        {
            throw new NotImplementedException();
        }

        public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV)
        {
            throw new NotImplementedException();
        }

        public override void GenerateIV()
        {
            throw new NotImplementedException();
        }

        public override void GenerateKey()
        {
            throw new NotImplementedException();
        }
    }
}
