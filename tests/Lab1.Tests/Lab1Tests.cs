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
        var pathList = new List<PathBase>
        {
            new ForceMagneticPath(new Length(1000), new Force(2000)),
            new MagneticPath(new Length(10)),
        };

        TrainSimulator simulator = CreateSimulator(pathList, 1000000000);

        // act
        SimulationResult result = simulator.Simulate();

        // assert
        Assert.IsType<SimulationResult.Success>(result);
    }

    [Fact]
    public void Run_Should_ReturnFailure_When_TrainAccelerates_AboveAllowedSpeed()
    {
        // arrange
        var pathList = new List<PathBase>
        {
            new ForceMagneticPath(new Length(1000), new Force(2000)),
            new MagneticPath(new Length(10)),
        };

        TrainSimulator simulator = CreateSimulator(pathList, 100);

        // act
        SimulationResult result = simulator.Simulate();

        // assert
        Assert.IsType<SimulationResult.Failed>(result);
    }

    [Fact]
    public void Run_Should_ReturnSuccess_When_IncludesStation()
    {
        // arrange
        var pathList = new List<PathBase>
        {
            new ForceMagneticPath(new Length(1000), new Force(2000)),
            new MagneticPath(new Length(10)),
            new Station(new Length(100), new TimeDuration(10), new MaxAllowedSpeed(1000000)),
            new MagneticPath(new Length(10)),
        };

        TrainSimulator simulator = CreateSimulator(pathList, 10000000000);

        // act
        SimulationResult result = simulator.Simulate();

        // assert
        Assert.IsType<SimulationResult.Success>(result);
    }

    [Fact]
    public void Run_Should_ReturnFailure_When_ExceedsStationMaxSpeed()
    {
        // arrange
        var pathList = new List<PathBase>
        {
            new ForceMagneticPath(new Length(100), new Force(2000)),
            new Station(new Length(100), new TimeDuration(10), new MaxAllowedSpeed(100)),
            new MagneticPath(new Length(1)),
        };

        TrainSimulator simulator = CreateSimulator(pathList, 10000000000);

        // act
        SimulationResult result = simulator.Simulate();

        // assert
        Assert.IsType<SimulationResult.Failed>(result);
    }

    [Fact]
    public void Run_Should_ReturnFailure_When_ExceedsRouteMaxSpeed()
    {
        // arrange
        var pathList = new List<PathBase>
        {
            new ForceMagneticPath(new Length(100), new Force(2000)),
            new MagneticPath(new Length(10)),
            new Station(new Length(1000), new TimeDuration(100), new MaxAllowedSpeed(1000)),
            new MagneticPath(new Length(10)),
        };

        TrainSimulator simulator = CreateSimulator(pathList, 100);

        // act
        SimulationResult result = simulator.Simulate();

        // assert
        Assert.IsType<SimulationResult.Failed>(result);
    }

    [Fact]
    public void Run_Should_ReturnSuccess_When_ContainsDifferentPaths()
    {
        // arrange
        var pathList = new List<PathBase>
        {
            new ForceMagneticPath(new Length(10), new Force(2000)),
            new MagneticPath(new Length(10)),
            new ForceMagneticPath(new Length(10), new Force(-895)),
            new Station(new Length(100), new TimeDuration(1703), new MaxAllowedSpeed(340)),
            new MagneticPath(new Length(10)),
            new ForceMagneticPath(new Length(10), new Force(2000)),
            new MagneticPath(new Length(10)),
            new ForceMagneticPath(new Length(10), new Force(-1000)),
        };

        TrainSimulator simulator = CreateSimulator(pathList, 600);

        // act
        SimulationResult result = simulator.Simulate();

        // assert
        Assert.IsType<SimulationResult.Success>(result);
    }

    [Fact]
    public void Run_Should_ReturnFailure_When_Only_NormalPath()
    {
        // arrange
        var pathList = new List<PathBase>
        {
            new MagneticPath(new Length(100000)),
        };

        TrainSimulator simulator = CreateSimulator(pathList, 10000000000);

        // act
        SimulationResult result = simulator.Simulate();

        // assert
        Assert.IsType<SimulationResult.Failed>(result);
    }

    [Fact]
    public void Run_Should_ReturnFail_When_NegativeSpeed()
    {
        // arrange
        var pathList = new List<PathBase>
        {
            new ForceMagneticPath(new Length(100000), new Force(1000)),
            new ForceMagneticPath(new Length(100000), new Force(-2000)),
        };

        TrainSimulator simulator = CreateSimulator(pathList, 10000000000);

        // act
        SimulationResult result = simulator.Simulate();

        // assert
        Assert.IsType<SimulationResult.Failed>(result);
    }

    // function to reduce the number of lines in tests
    private TrainSimulator CreateSimulator(IReadOnlyList<PathBase> pathList, double maxSpeed)
    {
        var train = new Train(_accuracy, _mass, _maxForce);
        return new TrainSimulator(train, pathList, new MaxAllowedSpeed(maxSpeed));
    }
}