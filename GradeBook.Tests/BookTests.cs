using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            //arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            book.AddLetterGrade('B');

            //act
            var result = book.GetStatistics();

            //assert
            Assert.Equal(85.6, result.Average, 1);  //3rd parameter means "1 decimal"
            Assert.Equal(90.5, result.High, 1);     //3rd parameter means "1 decimal"
            Assert.Equal(77.3, result.Low, 1);      //3rd parameter means "1 decimal"
            Assert.Equal('B', result.Letter);
        }
    }
}
