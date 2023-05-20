using System;
using System.Linq;
using GoogleApi.Entities.Maps.AerialView.GetVideo.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.AerialView.GetVideo;

[TestFixture]
public class GetVideoRequestTests
{
    [Test]
    public void GetQueryStringParametersWhenAddressTest()
    {
        var request = new GetVideoRequest
        {
            Key = "key",
            Address = "address"
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var key = queryStringParameters.FirstOrDefault(x => x.Key == "key");
        var keyExpected = request.Key;
        Assert.IsNotNull(key);
        Assert.AreEqual(keyExpected, key.Value);

        var address = queryStringParameters.FirstOrDefault(x => x.Key == "address");
        var originExpected = request.Address;
        Assert.IsNotNull(address);
        Assert.AreEqual(originExpected, address.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenVideoIdTest()
    {
        var request = new GetVideoRequest
        {
            Key = "key",
            VideoId = "videoid"
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var key = queryStringParameters.FirstOrDefault(x => x.Key == "key");
        var keyExpected = request.Key;
        Assert.IsNotNull(key);
        Assert.AreEqual(keyExpected, key.Value);

        var videoId = queryStringParameters.FirstOrDefault(x => x.Key == "videoId");
        var originExpected = request.VideoId;
        Assert.IsNotNull(videoId);
        Assert.AreEqual(originExpected, videoId.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new GetVideoRequest
        {
            Key = null
        };

        var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
        Assert.IsNotNull(exception);
        Assert.AreEqual("'Key' is required", exception.Message);
    }

    [Test]
    public void GetQueryStringParametersWhenKeyIsEmptyTest()
    {
        var request = new GetVideoRequest
        {
            Key = string.Empty
        };

        var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
        Assert.IsNotNull(exception);
        Assert.AreEqual("'Key' is required", exception.Message);
    }

    [Test]
    public void GetQueryStringParametersWhenAddressAndVideoIdIsNullTest()
    {
        var request = new GetVideoRequest
        {
            Key = "key"
        };

        var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
        Assert.IsNotNull(exception);
        Assert.AreEqual("Either an 'Address' or a 'VideoId' is required.", exception.Message);
    }

    [Test]
    public void GetQueryStringParametersWhenAddressAndVideoIdIsNotNullTest()
    {
        var request = new GetVideoRequest
        {
            Key = "key",
            Address = "address",
            VideoId = "videoId"
        };

        var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
        Assert.IsNotNull(exception);
        Assert.AreEqual("Only one of 'Address' or 'VideoId' can be specified.", exception.Message);
    }
}