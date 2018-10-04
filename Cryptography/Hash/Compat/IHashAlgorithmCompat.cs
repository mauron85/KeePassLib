namespace KeePassLib.Cryptography.Hash.Compat
{
    interface IHashAlgorithmCompat
    {
        void Clear();
        void TransformBlock(byte[] pbBuf1, int v1, int length, byte[] pbBuf2, int v2);
        void TransformFinalBlock(byte[] emptyByteArray, int v1, int v2);
    }
}
