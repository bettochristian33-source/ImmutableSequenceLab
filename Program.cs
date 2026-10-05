using ImmutableSequenceLab.DataStructures;
using System.Diagnostics;
var list = ImmutableLinkedList<int>.Empty;

list = list.Push(10);
list = list.Push(20);
list = list.Push(30);



Console.WriteLine(list.Value);
Console.WriteLine(list.Tail!.Value);
Console.WriteLine(list.Tail!.Tail!.Value);
Console.WriteLine($"Count: {list.Count()}");
Console.WriteLine($"Contains 20: {list.Contains(20)}");
Console.WriteLine($"Contains 99: {list.Contains(99)}");
var reversed = list.Reverse();

Console.WriteLine(reversed.Value);
Console.WriteLine(reversed.Tail!.Value);
Console.WriteLine(reversed.Tail!.Tail!.Value);
Console.WriteLine($"Naive: {list.ToNaiveString()}");
Console.WriteLine($"Builder: {list.ToBuilderString()}");

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("=== Benchmark ===");

var sizes = new[] { 100, 1_000, 5_000, 10_000, 20_000 };
const int repetitions = 10;

foreach (var size in sizes)
{
    var testList = ImmutableLinkedList<int>.Empty;

    for (int i = 0; i < size; i++)
    {
        testList = testList.Push(i);
    }

    // Warm-up : on exécute une fois avant de mesurer
    testList.ToNaiveString();
    testList.ToBuilderString();

    double naiveTotal = 0;
    double builderTotal = 0;

    for (int repetition = 0; repetition < repetitions; repetition++)
    {
        var stopwatch = Stopwatch.StartNew();

        var naive = testList.ToNaiveString();

        stopwatch.Stop();
        naiveTotal += stopwatch.Elapsed.TotalMilliseconds;

        stopwatch.Restart();

        var builder = testList.ToBuilderString();

        stopwatch.Stop();
        builderTotal += stopwatch.Elapsed.TotalMilliseconds;
    }

    var naiveAverage = naiveTotal / repetitions;
    var builderAverage = builderTotal / repetitions;
    var ratio = naiveAverage / builderAverage;
    Console.WriteLine(
    $"n = {size,-6} | " +
    $"Naive = {naiveAverage,10:F3} ms | " +
    $"Builder = {builderAverage,10:F3} ms | " +
    $"Ratio = {ratio,8:F1}x"
);
}
