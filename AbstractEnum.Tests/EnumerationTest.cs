using AbstractEnum.Tests.TestData;
using Xunit;

namespace AbstractEnum.Tests {
    public class EnumerationTest {
        [Fact]
        public void CheckFromGetValues() {
            Weekday[] weekdays = Weekday.GetAll();

            Assert.Collection(weekdays,
                              day => Assert.Equal("Monday",    day.Value),
                              day => Assert.Equal("Tuesday",   day.Value),
                              day => Assert.Equal("Wednesday", day.Value),
                              day => Assert.Equal("Thursday",  day.Value),
                              day => Assert.Equal("Friday",    day.Value),
                              day => Assert.Equal("Saturday",  day.Value),
                              day => Assert.Equal("Sunday",    day.Value)
                             );
        }

        [Fact]
        public void CheckSimpleValues() {
            Weekday day1 = Weekday.Monday;
            Weekday day2 = Weekday.Tuesday;
            Weekday day3 = Weekday.Wednesday;
            Weekday day4 = Weekday.Thursday;
            Weekday day5 = Weekday.Friday;
            Weekday day6 = Weekday.Saturday;
            Weekday day7 = Weekday.Sunday;

            Assert.Equal("Monday",    day1.Value);
            Assert.Equal("Tuesday",   day2.Value);
            Assert.Equal("Wednesday", day3.Value);
            Assert.Equal("Thursday",  day4.Value);
            Assert.Equal("Friday",    day5.Value);
            Assert.Equal("Saturday",  day6.Value);
            Assert.Equal("Sunday",    day7.Value);
        }

        [Fact]
        public void CheckEqualingValues() {
            Weekday day1 = Weekday.Monday;
            Weekday day2 = Weekday.Tuesday;
            Weekday day3 = Weekday.Wednesday;
            Weekday day4 = Weekday.Thursday;
            Weekday day5 = Weekday.Friday;
            Weekday day6 = Weekday.Saturday;
            Weekday day7 = Weekday.Sunday;
            
            Assert.Equal(day1, Weekday.Monday);
            Assert.Equal(day5, Weekday.Friday);
            
            Assert.NotEqual(day4, Weekday.Wednesday);
            Assert.NotEqual(day6, Weekday.Monday);
        }
        
        [Fact]
        public void CheckOperators() {
            Weekday day1 = Weekday.Monday;
            Weekday day2 = Weekday.Tuesday;
            Weekday day3 = Weekday.Wednesday;
            Weekday day4 = Weekday.Thursday;
            Weekday day5 = Weekday.Friday;
            Weekday day6 = Weekday.Saturday;
            Weekday day7 = Weekday.Sunday;
            
            Assert.True(day1 == Weekday.Monday);
            Assert.True(day4 == Weekday.Thursday);
            Assert.False(day2 == Weekday.Monday);
            
            Assert.True(day2 !=  Weekday.Sunday);
            Assert.True(day4 !=  Weekday.Friday);
            Assert.False(day1 != Weekday.Monday);
  
        }
    }
}