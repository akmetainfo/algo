<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>

// 1603. Design Parking System
// https://leetcode.com/problems/design-parking-system/

public class ParkingSystem
{
    private int[] _data;

    public ParkingSystem(int big, int medium, int small)
    {
        _data = new int[4] {0, big, medium, small};
    }

    public bool AddCar(int carType)
    {
        if(_data[carType] == 0)
            return false;
            
        _data[carType]--;
        return true;
    }
}

public class ParkingSystem1
{
    private int _big;
    private int _medium;
    private int _small;

    public ParkingSystem1(int big, int medium, int small)
    {
        _big = big;
        _medium = medium;
        _small = small;
    }

    public bool AddCar(int carType)
    {
        switch (carType)
        {
            case 1:
                return _big-- > 0;
            case 2:
                return _medium-- > 0;
            case 3:
                return _small-- > 0;
            default:
                throw new ArgumentOutOfRangeException(nameof(carType));
        }
    }
}

[Test]
[TestCase(
   new string[] { "ParkingSystem", "addCar", "addCar", "addCar", "addCar" },
   new object[] { new int[] { 1, 1, 0 }, new[] { 1 }, new[] { 2 }, new[] { 3 }, new[] { 1 } },
   new object[] { null, true, true, false, false }
)]
public void SolutionTests(string[] actionsNames, object[] actionsParams, object[] expectedOutput)
{
    AssertInputIsCorrect(actionsNames, actionsParams, expectedOutput);
    var expectedResult = ConvertResult(expectedOutput);
    bool?[] actualResult = new bool?[actionsNames.Length];
    ParkingSystem testedObj = null;

    for (var i = 0; i < actionsNames.Length; i++)
    {
        switch (actionsNames[i].ToLower())
        {
            case "parkingsystem":
                var data = (int[])actionsParams[i];
                testedObj = new ParkingSystem(data[0], data[1], data[2]);
                actualResult[i] = null;
                break;

            case "addcar":
                if (testedObj == null)
                    throw new Exception("where is init?");

                var dataAdd = (int[])actionsParams[i];
                actualResult[i] = testedObj.AddCar(dataAdd[0]);
                break;

            default:
                throw new ArgumentOutOfRangeException($"unknown command: {actionsNames[i]}");
        }
    }

    Assert.That(expectedResult, Is.EqualTo(actualResult));
}

#region unit-tests helpers

private void AssertInputIsCorrect(string[] actionsNames, object[] actionsParams, object[] expectedOutput)
{
    if (actionsNames.Length != actionsParams.Length || actionsNames.Length != expectedOutput.Length)
        throw new ArgumentException($"actionsNames.Length={actionsNames.Length}, actionsParams.Length={actionsParams.Length}, expectedOutput.Length={expectedOutput.Length}.");
}

private bool?[] ConvertResult(object[] expectedOutput)
{
    var result = new bool?[expectedOutput.Length];

    for (var i = 0; i < expectedOutput.Length; i++)
    {
        if (expectedOutput[i] == null)
        {
            result[i] = null;
        }
        else
        {
            result[i] = (bool)expectedOutput[i];
        }
    }

    return result;
}

#endregion

#region unit tests runner

void Main()
{
    var workDir = Path.Combine(Util.MyQueriesFolder, "nunit-work");

    var args = new string[]
    {
         "-noheader",
         $"--work={workDir}",
    };

    RunUnitTests(args);
}

void RunUnitTests(string[] args, Assembly assembly = null)
{
    Console.SetOut(new NoDisposeTextWriter(Console.Out));
    Console.SetError(new NoDisposeTextWriter(Console.Error));
    new AutoRun(assembly ?? Assembly.GetExecutingAssembly()).Execute(args);
}

// https://stackoverflow.com/q/52883672/5752652
class NoDisposeTextWriter : TextWriter
{
    private readonly TextWriter writer;
    public NoDisposeTextWriter(TextWriter writer) => this.writer = writer;

    public override Encoding Encoding => writer.Encoding;
    public override IFormatProvider FormatProvider => writer.FormatProvider;
    public override void Write(char value) => writer.Write(value);
    public override void Flush() => writer.Flush();
    // forward all other overrides as necessary

    protected override void Dispose(bool disposing)
    {
        // no nothing
    }
}

#endregion