using Itmo.ObjectOrientedProgramming.Lab1.Attributes;
using Itmo.ObjectOrientedProgramming.Lab1.Path;
using Itmo.ObjectOrientedProgramming.Lab1.ResultInfo;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Lab1Tests
{
    private readonly Accuracy _accuracy = new Accuracy(1);
    private readonly Mass _mass = new Mass(10);
    private readonly MaxAllowedForce _maxForce = new MaxAllowedForce(2000);

    [Fact]
    public void Run_Should_ReturnSuccess_When_TrainAccelerates_To_AllowedSpeed()
    {
        // arrange
        var pathList = new List<IPath>
        {
            new ForceMagneticPath(new Length(1000), new Force(2000)),
            new MagneticPath(new Length(10)),
        };

        Train simulator = CreateSimulator(pathList, 1000000000);

        // act
        SimulationResult result = simulator.Simulate();

        // assert
        Assert.IsType<SimulationResult.Success>(result);
    }

    [Fact]
    public void Run_Should_ReturnFailure_When_TrainAccelerates_AboveAllowedSpeed()
    {
        // arrange
        var pathList = new List<IPath>
        {
            new ForceMagneticPath(new Length(1000), new Force(2000)),
            new MagneticPath(new Length(10)),
        };

        Train simulator = CreateSimulator(pathList, 100);

        // act
        SimulationResult result = simulator.Simulate();

        // assert
        Assert.IsType<SimulationResult.Failed>(result);
    }

    [Fact]
    public void Run_Should_ReturnSuccess_When_IncludesStation()
    {
        // arrange
        var pathList = new List<IPath>
        {
            new ForceMagneticPath(new Length(1000), new Force(2000)),
            new MagneticPath(new Length(10)),
            new Station(new TimeDuration(10), new MaxAllowedSpeed(1000000)),
            new MagneticPath(new Length(10)),
        };

        Train simulator = CreateSimulator(pathList, 10000000000);

        // act
        SimulationResult result = simulator.Simulate();

        // assert
        Assert.IsType<SimulationResult.Success>(result);
    }

    [Fact]
    public void Run_Should_ReturnFailure_When_ExceedsStationMaxSpeed()
    {
        // arrange
        var pathList = new List<IPath>
        {
            new ForceMagneticPath(new Length(100), new Force(2000)),
            new Station(new TimeDuration(10), new MaxAllowedSpeed(100)),
            new MagneticPath(new Length(1)),
        };

        Train simulator = CreateSimulator(pathList, 10000000000);

        // act
        SimulationResult result = simulator.Simulate();

        // assert
        Assert.IsType<SimulationResult.Failed>(result);
    }

    [Fact]
    public void Run_Should_ReturnFailure_When_ExceedsRouteMaxSpeed()
    {
        // arrange
        var pathList = new List<IPath>
        {
            new ForceMagneticPath(new Length(100), new Force(2000)),
            new MagneticPath(new Length(10)),
            new Station(new TimeDuration(100), new MaxAllowedSpeed(1000)),
            new MagneticPath(new Length(10)),
        };

        Train simulator = CreateSimulator(pathList, 100);

        // act
        SimulationResult result = simulator.Simulate();

        // assert
        Assert.IsType<SimulationResult.Failed>(result);
    }

    [Fact]
    public void Run_Should_ReturnSuccess_When_ContainsDifferentPaths()
    {
        // arrange
        var pathList = new List<IPath>
        {
            new ForceMagneticPath(new Length(10), new Force(2000)),
            new MagneticPath(new Length(10)),
            new ForceMagneticPath(new Length(10), new Force(-1200)),
            new Station(new TimeDuration(1703), new MaxAllowedSpeed(390)),
            new MagneticPath(new Length(10)),
            new ForceMagneticPath(new Length(10), new Force(2000)),
            new MagneticPath(new Length(10)),
            new ForceMagneticPath(new Length(10), new Force(-1200)),
        };

        Train simulator = CreateSimulator(pathList, 601);

        // act
        SimulationResult result = simulator.Simulate();

        // assert
        Assert.IsType<SimulationResult.Success>(result);
    }

    [Fact]
    public void Run_Should_ReturnFailure_When_Only_NormalPath()
    {
        // arrange
        var pathList = new List<IPath>
        {
            new MagneticPath(new Length(100000)),
        };

        Train simulator = CreateSimulator(pathList, 10000000000);

        // act
        SimulationResult result = simulator.Simulate();

        // assert
        Assert.IsType<SimulationResult.Failed>(result);
    }

    [Fact]
    public void Run_Should_ReturnFail_When_NegativeSpeed()
    {
        // arrange
        var pathList = new List<IPath>
        {
            new ForceMagneticPath(new Length(100000), new Force(1000)),
            new ForceMagneticPath(new Length(100000), new Force(-2000)),
        };

        Train simulator = CreateSimulator(pathList, 10000000000);

        // act
        SimulationResult result = simulator.Simulate();

        // assert
        Assert.IsType<SimulationResult.Failed>(result);
    }

    // function to reduce the number of lines in tests
    private Train CreateSimulator(IReadOnlyList<IPath> pathList, double maxSpeed)
    {
        var train = new Train(_accuracy, _mass, _maxForce, new MaxAllowedSpeed(maxSpeed), pathList);
        return train;
    }
}