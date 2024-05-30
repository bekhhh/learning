using System.ComponentModel.Design;
using Example_2.Dictionary;
namespace Example_2.Tests;

public class MyDictionaryTest
{
    [Fact]
    public void Init_Dictionary_Count_Is_Zero()
    {
        //Arrange
        var map = new MyDictionary<int, int>();

        //Act

        //Assert
        Assert.Equal(0, map.Count);
    }

    [Fact]
    public void Add_Item_Count_Should_Increase()
    {
        //Arrange
        var map = new MyDictionary<int, int>();

        //Act
        map.Add(1, 54);

        //Assert
        Assert.Equal(1, map.Count);
    }

    [Fact]
    public void Add_Item_Count_Should_Increase_2()
    {
        //Arrange
        var map = new MyDictionary<int, int>();

        //Act
        map.Add(1, 54);
        map.Add(4, 6);

        //Assert
        Assert.Equal(2, map.Count);
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 4)]
    [InlineData(6, 67)]
    [InlineData(1, 54)]
    [InlineData(4, 6)]
    public void Add_Item_Count_Should_Increase_3(int key, int value)
    {
        //Arrange
        var map = new MyDictionary<int, int>();

        //Act
        map.Add(key, value);

        //Assert
        Assert.Equal(1, map.Count);
    }

    [Theory]
    [InlineData("1", '3')]
    [InlineData("34", '6')]
    [InlineData("asd", 's')]
    public void Get_Item_Success(string key, char value)
    {
        //Arrange
        var map = new MyDictionary<string, char>();
        map.Add(key, value);
        var expectedData = value;

        //Act
        var actualData = map.Get(key);

        //Assert
        Assert.Equal(expectedData, actualData);
    }

    [Theory]
    [InlineData("sad", 12)]
    [InlineData("asd4", 3)]
    [InlineData("aAsdsd", 56)]
    public void Get_Item_Success_2(string key, int value)
    {
        //Arrange
        var map = new MyDictionary<string, int>();
        map.Add(key, value);
        map.Add("asdaasdas", value + 1);
        map.Add("asdasd", value + 2);
        var expectedData = value;

        //Act
        var actualData = map.Get(key);

        //Assert
        Assert.Equal(expectedData, actualData);
    }

    [Fact]
    public void Get_Item_Fail()
    {
        //Arrange
        var map = new MyDictionary<int, int>();
        map.Add(1, 1);

        //Act

        //Assert
        Assert.Throws<ArgumentException>(() => map.Get(2));
    }
    
    [Fact]
    public void Add_Item_And_Resize_Success()
    {
        //Arrange
        var map = new MyDictionary<int, int>();
        map.Add(1, 1);
        map.Add(2, 2);
        map.Add(3, 3);
        map.Add(4, 4);
        map.Add(5, 5);
        map.Add(6, 6);
        map.Add(7, 7);
        map.Add(8, 8);

        //Act
        var item1 = map.Get(1);
        var item2 = map.Get(2);
        var item3 = map.Get(3);
        var item4 = map.Get(4);
        var item5 = map.Get(5);
        var item6 = map.Get(6);
        var item7 = map.Get(7);
        var item8 = map.Get(8);

        //Assert
        Assert.Equal(8, map.Count);
        Assert.Equal(1, item1);
        Assert.Equal(2, item2);
        Assert.Equal(3, item3);
        Assert.Equal(4, item4);
        Assert.Equal(5, item5);
        Assert.Equal(6, item6);
        Assert.Equal(7, item7);
        Assert.Equal(8, item8);
    }
    
    [Theory]
    [InlineData("sad", 12)]
    [InlineData("asd4", 3)]
    [InlineData("aAsdsd", 56)]
    public void Remove_Item_Success(string key, int value)
    {
        //Arrange
        var map = new MyDictionary<string, int>();
        map.Add(key, value);
        map.Add("asdaasdas", value + 1);
        map.Add("asdasd", value + 2);

        //Act
        map.Remove(key, value);

        //Assert
        Assert.Equal(map.Count, 2);
        Assert.Throws<ArgumentException>(() => map.Get(key));
    }
    
    [Fact]
    public void Remove_Item_Fail()
    {
        //Arrange
        var map = new MyDictionary<int, int>();
        map.Add(1, 1);

        //Act

        //Assert
        Assert.Throws<ArgumentException>(() => map.Remove(2, 5));
    }
    
    [Fact]
    public void Enumerate_Items_Success()
    {
        //Arrange
        var array = new int[]
        {
            1, 4, 5, 6
        };
        var list = new MyLinkedList<int>(array);
        var index = 0;

        //Act
        //Assert
        foreach (var item in list)
        {
            Assert.Equal(array[index], item);
            index++;
        }
    }

    private void Learing()
    {
        //ОБУЧЕНИЕ
        //1. Action -- тип данных представляющих функцию(метод) без параметров и без возвращаемого значения (void)
        Action act1 = () => Console.WriteLine();
        //Одно и то же, что и выше
        act1 = Console.WriteLine;
        act1();

        //2. Action<T1, T2, T3, ...> -- тип данных представляющих функцию(метод) c параметрами типа T1, T2, T3, ... и без возвращаемого значения (void)
        Action<int> act2 = (a) => Console.WriteLine(a);
        act2(3);

        Action<int, string> act2_v2 = (int a, string b) => Console.WriteLine($"{a}{b}");
        act2_v2(24, "asdas");

        Action<int, int, int, int, int> act2_v3 = (x1, x2, x3, x4, x5) => Console.WriteLine($"{x1}{x2}{x3}{x4}{x5}");
        act2_v3(24, 2, 5, 6, 3);

        //3. Func -- тип данных представляющих функцию(метод) без параметров и без возвращаемого значения (void)
        Func<int> func1 = () =>
        {
            return 2;
        };
        //Одно и то же, что и выше
        func1 = () => 2;
        var result = func1();

        //3. Action<T1, T2, T3, ...> -- тип данных представляющих функцию(метод) c параметрами типа T1, T2, T3, ... и без возвращаемого значения (void)
        Func<int, int> func2 = (a) =>
        {
            return a;
        };
        var res = func2(3); // res = 3

        Func<int, int, string> func2_v2 = (int a, int b) => $"{a}{b}";
        func2_v2 = TestFunc;
        string res2 = func2_v2(24, 2);

        Func<int, int, int, int, int, int> func2_v3 = (x1, x2, x3, x4, x5) => x1 + x2 + x3 + x4 + x5;
        func2_v3(24, 2, 5, 6, 3);
    }
    
    public string TestFunc(int a, int b)
    {
        return $"{a},{b}";
    }
}