using Itmo.ObjectOrientedProgramming.Lab1.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab1.ResultInfo;

public abstract record SegmentResult
{
    private SegmentResult() { }

    public sealed record Success(Time SegmentTime, Length SegmentLength) : SegmentResult;

    public sealed record Failed : SegmentResult;
}