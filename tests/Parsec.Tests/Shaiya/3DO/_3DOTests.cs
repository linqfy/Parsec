﻿using Parsec.Common;

namespace Parsec.Tests.Shaiya._3DO;

public class _3DOTests
{
    [Fact]
    public void _3DOReadWriteTest()
    {
        const string filePath = "Shaiya/3DO/F_34_a002.3DO";
        var obj = ParsecReader.FromFile<Parsec.Shaiya._3do._3do>(filePath);

        // Check original EFT values
        Assert.Equal(1087, obj.Vertices.Count);
        Assert.Equal(964, obj.Faces.Count);
        Assert.Equal(Episode.EP5, obj.Episode);

        // Export to json
        const string jsonPath = "Shaiya/3DO/F_34_a002.3DO.json";
        obj.WriteJson(jsonPath);
        var objFromJson = ParsecReader.FromJsonFile<Parsec.Shaiya._3do._3do>(jsonPath);

        // Check fields
        Assert.Equal(obj.Vertices.Count, objFromJson.Vertices.Count);
        Assert.Equal(obj.Faces.Count, objFromJson.Faces.Count);

        // Check bytes
        Assert.Equal(obj.GetBytes(), objFromJson.GetBytes());

        const string newObjPath = "Shaiya/3DO/F_34_a002.new.3DO";
        objFromJson.Write(newObjPath);

        var newObj = ParsecReader.FromFile<Parsec.Shaiya._3do._3do>(newObjPath);

        // Check fields
        Assert.Equal(obj.Vertices.Count, newObj.Vertices.Count);
        Assert.Equal(obj.Faces.Count, newObj.Faces.Count);

        // Check bytes
        Assert.Equal(obj.GetBytes(), newObj.GetBytes());
    }

    [Theory]
    [InlineData("01211.3DO")]
    [InlineData("06101.3DO")]
    [InlineData("07151.3DO")]
    [InlineData("07331.3DO")]
    [InlineData("13001.3DO")]
    [InlineData("13171.3DO")]
    [InlineData("14251.3DO")]
    [InlineData("34091.3DO")]
    [InlineData("F_34_a002.3DO")]
    public void _3DOMultipleReadWriteTest(string fileName)
    {
        string filePath = $"Shaiya/3DO/{fileName}";
        string jsonPath = $"Shaiya/3DO/{fileName}.json";
        string newObjPath = $"Shaiya/3DO/new_{fileName}";

        var obj = ParsecReader.FromFile<Parsec.Shaiya._3do._3do>(filePath);
        obj.WriteJson(jsonPath);
        var objFromJson = ParsecReader.FromJsonFile<Parsec.Shaiya._3do._3do>(jsonPath);

        // Check bytes
        Assert.Equal(obj.GetBytes(), objFromJson.GetBytes());

        objFromJson.Write(newObjPath);
        var newObj = ParsecReader.FromFile<Parsec.Shaiya._3do._3do>(newObjPath);

        // Check bytes
        Assert.Equal(obj.GetBytes(), newObj.GetBytes());
    }
}
