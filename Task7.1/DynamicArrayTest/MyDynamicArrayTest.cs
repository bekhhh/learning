using NPOI.SS.Formula.Functions;
using System;
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
            Assert.Equal(1, dynamicArray.GetByIndex(0));
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
            Assert.Equal(4, dynamicArray.GetByIndex(3));
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
        public void AddToEnd_Null() 
        { 
            //Arrange
            var dynamicArray = new DynamicArray<string>();

            //Assert
            Assert.Throws<ArgumentNullException>(() => dynamicArray.AddToEnd(null));
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
            Assert.Equal(5, dynamicArray.GetByIndex(0));
            Assert.Equal(7, dynamicArray.GetByIndex(1));
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
            Assert.Throws<IndexOutOfRangeException>(() => dynamicArray.GetByIndex(index));
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
            Assert.Throws<IndexOutOfRangeException>(() => dynamicArray.GetByIndex(index));
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(34, 4, 5)]
        [InlineData(423, 456, 6)]       
        public void Add_To_End_Adds_Elements_To_End_Of_Array(int value1, int value2, int value3)
        {
            // Arrange
            var dynamicArray = new DynamicArray<int>();

            // Act
            dynamicArray.AddToEnd(value1);
            dynamicArray.AddToEnd(value2);
            dynamicArray.AddToEnd(value3);

            // Assert
            Assert.Equal(value1, dynamicArray.GetByIndex(0));
            Assert.Equal(value2, dynamicArray.GetByIndex(1));
            Assert.Equal(value3, dynamicArray.GetByIndex(2));
            Assert.Equal(3, dynamicArray.Length);
        }      
    }
}