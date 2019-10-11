using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // Arrange
            TacoParser tacoParserTesting = new TacoParser();
            var str = "35.073638,-83.677017,Taco Bell Manhattan";
            var str2 = "30.053638,-85.827017,Taco Bell Brooklyn";
            var str3 = "32.073638,-78.677017,Taco Bell Queens";
            var str4 = "31.073638,-80.921017,Taco Bell Manhattan";
            var str5 = "33.073638,-82.777017,Taco Bell Bronx";

            // Act
            var expected = "Taco Bell Manhattan";
            var expected2 = "Taco Bell Brooklyn";
            var expected3 = "Taco Bell Queens";
            var expected4 = "Taco Bell Manhattan";
            var expected5 = "Taco Bell Bronx";

            var actual = tacoParserTesting.Parse(str);
            var actual2 = tacoParserTesting.Parse(str2);
            var actual3 = tacoParserTesting.Parse(str3);
            var actual4 = tacoParserTesting.Parse(str4);
            var actual5 = tacoParserTesting.Parse(str5);

            // Assert
            Assert.Equal(actual.Name, expected);
            Assert.Equal(actual2.Name, expected2);
            Assert.Equal(actual3.Name, expected3);
            Assert.Equal(actual4.Name, expected4);
            Assert.Equal(actual5.Name, expected5);
        }

        [Theory]
        [InlineData("35.073638,-83.677017,Taco Bell Manhattan", "Taco Bell Manhattan")]
        [InlineData("30.053638,-85.827017,Taco Bell Brooklyn", "Taco Bell Brooklyn")]
        [InlineData("32.073638,-78.677017,Taco Bell Queens", "Taco Bell Queens")]
        [InlineData("31.073638,-80.921017,Taco Bell Manhattan", "Taco Bell Manhattan")]
        [InlineData("33.073638,-82.777017,Taco Bell Bronx", "Taco Bell Bronx")]
        public void ShouldParse(string str, string expected)
        {
            TacoParser shouldParse = new TacoParser();
            var actual = shouldParse.Parse(str);

            Assert.Equal(expected, actual.Name);
        }

        [Fact]
        public void ShouldFailParse()
        {
            // Arrange
            TacoParser shouldFailParse = new TacoParser();
            var sfp = "35.073638,-83.677017";
            var sfp2 = "null, -83.677017";
            var sfp3 = "";
            var sfp4 = "Taco Bell Midtown";
            var sfp5 = "null, null, null";
            var sfp6 = "31.073638,-80.921017,Taco Bell Manhattan, null, null";
            var sfp7 = " ,-80.921017,Taco Bell Manhattan";

            // Act
            var actual = shouldFailParse.Parse(sfp);
            var actual2 = shouldFailParse.Parse(sfp2);
            var actual3 = shouldFailParse.Parse(sfp3);
            var actual4 = shouldFailParse.Parse(sfp4);
            var actual5 = shouldFailParse.Parse(sfp5);
            var actual6 = shouldFailParse.Parse(sfp6);
            var actual7 = shouldFailParse.Parse(sfp7);

            // Assert
            Assert.Equal(actual, null);
            Assert.Equal(actual2, null);
            Assert.Equal(actual3, null);
            Assert.Equal(actual4, null);
            Assert.Equal(actual5, null);
            Assert.Equal(actual6, null);
            Assert.Equal(actual7, null);
        }
    }
}
