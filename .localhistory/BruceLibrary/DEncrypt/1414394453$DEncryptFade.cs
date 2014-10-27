using System;
using System.Security.Cryptography;
using System.Text;

namespace BruceLibrary.DEncrypt
{
    /// <summary>
    /// Encrypt 的摘要说明。
    /// LiTianPing
    /// </summary>
    public class DEncryptFade
    {
        #region Fields
        private const string DefaultKey = "Bruce";
        #endregion

        #region Init
        public static DEncryptFade Current = new DEncryptFade();
        private DEncryptFade()
        {
        }
        #endregion
    }
}
