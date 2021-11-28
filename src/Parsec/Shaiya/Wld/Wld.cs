﻿using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.WLD
{
    public class Wld : FileBase
    {
        /// <summary>
        /// "FLD" or "DUN" as char[4]
        /// </summary>
        public string Type { get; set; }

        #region FLD Only fields

        /// <summary>
        /// 1024 or 2048
        /// </summary>
        public int MapSize { get; set; }

        /// <summary>
        /// 0x0C0C03 bytes if mapSize is 1024, 0x301803 bytes if mapSize is 2048
        /// </summary>
        public byte[] MapHeight { get; set; }

        #endregion

        public override void Read()
        {
        }
    }
}
