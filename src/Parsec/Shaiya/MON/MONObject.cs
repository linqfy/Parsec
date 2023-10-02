﻿using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.MON;

public sealed class MONObject : IBinary
{
    [JsonConstructor]
    public MONObject()
    {
    }

    public MONObject(SBinaryReader binaryReader)
    {
        Object3DCName = binaryReader.ReadString();
        TextureName = binaryReader.ReadString();
    }

    public string Object3DCName { get; set; } = string.Empty;
    public string TextureName { get; set; } = string.Empty;

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Object3DCName.GetLengthPrefixedBytes(false));
        buffer.AddRange(TextureName.GetLengthPrefixedBytes(false));
        return buffer;
    }
}
