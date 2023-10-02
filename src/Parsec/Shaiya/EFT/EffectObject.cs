﻿using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.EFT;

public sealed class EffectObject : IBinary
{
    [JsonConstructor]
    public EffectObject()
    {
    }

    public EffectObject(SBinaryReader binaryReader, int index)
    {
        Index = index;
        Name = binaryReader.ReadString();
    }

    public int Index { get; set; }
    public string Name { get; set; } = string.Empty;

    public IEnumerable<byte> GetBytes(params object[] options) => Name.GetLengthPrefixedBytes();
}
