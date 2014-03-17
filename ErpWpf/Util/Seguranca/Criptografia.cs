using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Util.Seguranca
{
    public class Criptografia
    {
        public enum HashProvider
        {
            SHA1,
            SHA256,
            SHA384,
            SHA512,
            MD5
        }
        /// <summary>
        /// Cria hash dos dados inseridos.
        /// </summary>
        public class CriptHash
        {
            #region Privado
            private static HashAlgorithm _algorithm;
            #endregion

            #region Construtor
            public CriptHash(HashProvider hashProvider = HashProvider.SHA1)
            {
                switch (hashProvider)
                {
                    case HashProvider.MD5:
                        _algorithm = new MD5CryptoServiceProvider();
                        break;
                    case HashProvider.SHA1:
                        _algorithm = new SHA1Managed();
                        break;
                    case HashProvider.SHA256:
                        _algorithm = new SHA256Managed();
                        break;
                    case HashProvider.SHA384:
                        _algorithm = new SHA384Managed();
                        break;
                    case HashProvider.SHA512:
                        _algorithm = new SHA512Managed();
                        break;
                }
            }
            #endregion

            #region Publico
            /// <summary>
            /// Monta hash para algum dado texto.
            /// </summary>
            /// <param name="plainText">Texto a ser criado o hash.</param>
            /// <returns>Hash do texto inserido.</returns>
            public string GetHash(string plainText)
            {
                var cryptoByte = _algorithm.ComputeHash(Encoding.ASCII.GetBytes(plainText));

                return Convert.ToBase64String(cryptoByte, 0, cryptoByte.Length);
            }
            /// <summary>
            /// Cria hash para algum tipo de stream.
            /// </summary>
            /// <param name="fileStream">Stream a ser criado o hash.</param>
            /// <returns>Hash do stream inserido.</returns>
            public string GetHash(FileStream fileStream)
            {
                var cryptoByte = _algorithm.ComputeHash(fileStream);
                fileStream.Close();

                return Convert.ToBase64String(cryptoByte, 0, cryptoByte.Length);
            }
            #endregion

        }

        public static string CriptografarSenha(string senha)
        {
            return new CriptHash(HashProvider.SHA512).GetHash(senha);
        }
    }
}
