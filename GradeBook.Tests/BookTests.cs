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
            //book.AddGrade(89.1);
            //book.AddGrade(90.5);
            //book.AddGrade(77.3);
            book.AddGrade(85);
            book.AddGrade(95);
            book.AddGrade(75);
           // book.AddLetterGrade('B');

            //act
            var result = book.GetStatistics();

            //assert
            Assert.Equal(85, result.Average, 1);  //3rd parameter means "1 decimal"
            Assert.Equal(95, result.High, 1);     //3rd parameter means "1 decimal"
            Assert.Equal(75, result.Low, 1);      //3rd parameter means "1 decimal"
           // Assert.Equal('B', result.Letter);
        }
    }
}
