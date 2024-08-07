using NPOI.SS.Formula.Functions;
using Task7._1;

namespace DynamicArrayTest
{
    public class MyDynamicArrayTest
    {
        [Fact]
        public void Add_To_End_When_Array_Is_Empty()
        {
            //Arrange
            var dynamicArray = new DynamicArray<int>();

            //Act
            dynamicArray.AddToEnd(1);

            //Assert
            Assert.Equal(1, dynamicArray[0]);
            Assert.Equal(1, dynamicArray.Length);
        }

        [Fact]
        public void Add_To_End_When_Array_Is_Not_Empty() 
        {
            //Arrange
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.AddToEnd(1);
            dynamicArray.AddToEnd(543);
            dynamicArray.AddToEnd(12);

            //Act
            dynamicArray.AddToEnd(4);

            //Assert
            Assert.Equal(4, dynamicArray[3]);
            Assert.Equal(4, dynamicArray.Length);
        }

        [Fact]
        public void Add_To_End_When_Array_Is_Full() 
        {
            //Arrange
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Length = 3;
            dynamicArray.AddToEnd(1);
            dynamicArray.AddToEnd(543);
            dynamicArray.AddToEnd(12);

            //Act
            dynamicArray.AddToEnd(45);

            //Assert
            Assert.Equal(7, dynamicArray.Length);
        }       

        [Fact]
        public void Add_Element_RemoveElement_Check_Array_Lenght() 
        {
            //Arrange
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.AddToEnd(5);
            dynamicArray.AddToEnd(3);

            //Act            
            dynamicArray.RemoveElement(0);

            //Assert
            Assert.Equal(1, dynamicArray.Length);
            Assert.Equal(3, dynamicArray[0]);
        }

        [Fact]
        public void Remove_Element_Check_Array_Lenght()
        {
            //Arrange
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.AddToEnd(5);
            dynamicArray.AddToEnd(3);
            dynamicArray.AddToEnd(7);

            //Act
            dynamicArray.RemoveElement(1);

            //Assert
            Assert.Equal(2, dynamicArray.Length);
            Assert.Equal(5, dynamicArray[0]);
            Assert.Equal(7, dynamicArray[1]);
        }

        [Fact]
        public void Remove_Element_When_Index_Is_Negative()
        {
            // Arrange
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.AddToEnd(5);
            dynamicArray.AddToEnd(3);
            dynamicArray.AddToEnd(7);
            int index = -1;

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => dynamicArray.RemoveElement(index));
        }

        [Fact]
        public void Get_By_Index_When_Array_is_Empty()
        {
            //Arrange
            var dynamicArray = new DynamicArray<int>();
            int index = 0;
                       
            //Assert
            Assert.Throws<IndexOutOfRangeException>(() => dynamicArray[index]);
        }

        [Fact]
        public void Get_By_Index_When_Index_Is_More_Than_Array_Length()
        {
            //Arrange
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.AddToEnd(5);
            dynamicArray.AddToEnd(3);
            dynamicArray.AddToEnd(6);
            int index = 3;

            //Assert
            Assert.Throws<IndexOutOfRangeException>(() => dynamicArray[index]);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(34, 4, 5)]
        [InlineData(423, 456, 6)]       
        public void Adds_Numbers_To_End_Of_Array(int value1, int value2, int value3)
        {
            // Arrange
            var dynamicArray = new DynamicArray<int>();

            // Act
            dynamicArray.AddToEnd(value1);
            dynamicArray.AddToEnd(value2);
            dynamicArray.AddToEnd(value3);

            // Assert
            Assert.Equal(value1, dynamicArray[0]);
            Assert.Equal(value2, dynamicArray[1]);
            Assert.Equal(value3, dynamicArray[2]);
            Assert.Equal(3, dynamicArray.Length);
        }

        [Theory]
        [InlineData(1, 2, 3, 63, 5642)]
        [InlineData(34, 4, 5, 654, 976)]
        [InlineData(423, 456, 6, 123, 6534)]
        [InlineData(312, 5643, 12, 6754, 90867)]
        [InlineData(653, 6256, 756, 2134, 1235)]
        public void Adds_And_Remove_Numbers_In_Array(int value1, int value2, int value3, int value4, int value5)
        {
            // Arrange
            var dynamicArray = new DynamicArray<int>();

            // Act
            dynamicArray.AddToEnd(value1);
            dynamicArray.AddToEnd(value2);
            dynamicArray.AddToEnd(value3);
            dynamicArray.AddToEnd(value4);
            dynamicArray.AddToEnd(value5);
            dynamicArray.RemoveElement(1);
            dynamicArray.RemoveElement(3);

            // Assert
            Assert.Equal(value1, dynamicArray[0]);
            Assert.Equal(value3, dynamicArray[1]);   
            Assert.Equal(value4, dynamicArray[2]);
            Assert.Equal(3, dynamicArray.Length);
        }

        [Theory]
        [InlineData("Dimas", "Vlados", "Makson")]
        [InlineData("Lavka", "Samokat", "Eda")]
        [InlineData("Artorius", "Nadya", "Gloomhaven")]
        public void Adds_Words_To_End_Of_Array(string value1, string value2, string value3)
        {
            // Arrange
            var dynamicArray = new DynamicArray<string>();

            // Act
            dynamicArray.AddToEnd(value1);
            dynamicArray.AddToEnd(value2);
            dynamicArray.AddToEnd(value3);

            // Assert
            Assert.Equal(value1, dynamicArray[0]);
            Assert.Equal(value2, dynamicArray[1]);
            Assert.Equal(value3, dynamicArray[2]);
            Assert.Equal(3, dynamicArray.Length);
        }

        [Fact]
        public void Enumerate_Items_Success() 
        {
            //Arrange
            var dynamicArray = new int[] { 2, 4, 5, 7 };
            var target = new DynamicArray<int>();
            target.AddToEnd(dynamicArray[0]);
            target.AddToEnd(dynamicArray[1]);
            target.AddToEnd(dynamicArray[2]);
            target.AddToEnd(dynamicArray[3]);

            var index = 0;
            //Act


            //Assert
            foreach (var item in target) 
            {
                Assert.Equal(dynamicArray[index], item);
                index++;
            }
            Assert.Equal(4, dynamicArray.Length);
        }
    }
}