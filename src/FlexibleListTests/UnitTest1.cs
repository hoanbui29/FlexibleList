using FlexibleList.Public;

namespace FlexibleListTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestOnAddEvent()
    {
        var flList = new FlexibleList<string>();
        string? anchor = null;
        List<string> secondList = new();
        using (flList.OnAdd(x =>
               {
                   secondList.Add(x);
                   anchor = x;
               }))
        {
            flList.Add("Hello");
            flList.Add("Cream");
        }

        Assert.That(anchor, Is.Not.EqualTo("Hello"));
        Assert.That(anchor, Is.EqualTo("Cream"));
        Assert.That(secondList, Has.Count.EqualTo(2));
    }

    [Test]
    public void TestIndexEnumerator()
    {
        var flList = new FlexibleList<string>();
        var index = 0;
        var anchor = "";
        flList.Add("Hello");
        flList.Add("Cream");
        //Same as flList.Select((item, idx) => (item, idx))
        foreach (var (item, idx) in flList.GetIndexEnumerator())
        {
            index = idx;
            anchor = item;
        }

        Assert.That(anchor, Is.EqualTo("Cream"));
        Assert.That(index, Is.EqualTo(1));
    }
}