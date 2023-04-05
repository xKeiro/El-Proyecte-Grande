using System.Text.Json;

namespace BackendTests.Utils;
public static class Util
{
    public static void AreEqualByJson(object? expected, object? actual)
    {
        var expectedJson = JsonSerializer.Serialize(expected);
        var actualJson = JsonSerializer.Serialize(actual);
        Assert.That(actualJson, Is.EqualTo(expectedJson));
    }
}
