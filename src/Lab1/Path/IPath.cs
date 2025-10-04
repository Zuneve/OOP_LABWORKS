using Itmo.ObjectOrientedProgramming.Lab1.ResultInfo;

namespace Itmo.ObjectOrientedProgramming.Lab1.Path;

public interface IPath
{
    PathResult TryPassPath(Train trainInfo);
}
