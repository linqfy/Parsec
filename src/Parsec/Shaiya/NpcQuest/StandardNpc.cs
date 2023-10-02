﻿using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Serialization;

namespace Parsec.Shaiya.NpcQuest;

public class StandardNpc : BaseNpc
{
    public StandardNpc(SBinaryReader binaryReader, Episode episode)
    {
        ReadNpcBaseComplete(binaryReader, episode);
    }

    [JsonConstructor]
    public StandardNpc()
    {
    }
}
