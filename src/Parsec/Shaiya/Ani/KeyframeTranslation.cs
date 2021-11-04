﻿using System;
using System.Collections.Generic;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.ANI
{
    public class KeyframeTranslation : IBinary
    {
        public int Keyframe { get; set; }
        public Vector3 Translation { get; set; }

        public KeyframeTranslation(ShaiyaBinaryReader binaryReader)
        {
            Keyframe = binaryReader.Read<int>();
            Translation = new Vector3(binaryReader);
        }

        public byte[] GetBytes()
        {
            var buffer = new List<byte>();
            buffer.AddRange(BitConverter.GetBytes(Keyframe));
            buffer.AddRange(BitConverter.GetBytes(Translation.X));
            buffer.AddRange(BitConverter.GetBytes(Translation.Y));
            buffer.AddRange(BitConverter.GetBytes(Translation.Z));
            return buffer.ToArray();
        }
    }
}
