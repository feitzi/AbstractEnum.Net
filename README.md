[![NuGet Badge](https://buildstats.info/nuget/AbstractEnum.Net?includePreReleases=true)](https://www.nuget.org/packages/AbstractEnum.Net)

# AbstractEnum.Net

With AbstractEnum.Net you can easily use Java like enums with own enum properties in your .Net code. As a result of
using AbstractEnum.Net like Enums you get more readable and practical enums types. (Obviously AbstactEnum.Net Enums are
basicly only sinleton classes with static fields, but practicly you can almost use it like default Enums)
This package is based on the code of [HeadSpringLabs/Enumeration](https://github.com/HeadspringLabs/Enumeration).

You are welcome to contribute to this .Net Standard Library with a new pull request or with a
new [issue](https://github.com/feitzi/AbstractEnum.Net/issues/new).

## Install

> [nuget Install](https://www.nuget.org/packages/AbstractEnum.Net/)
> ```Install-Package AbstractEnum.Net```

## Usage of AbstratEnum.Net

Here is a self-explaining code snipped which illustrates the definition of weekdays with a property `isWeekday`

#### Declare a new 'Enum'-Typ

````c#
using AbstractEnumDotNet;

 public class Weekday : AbstractEnum<Weekday> {
        public static readonly Weekday Monday    = new Weekday("Monday",true);
        public static readonly Weekday Tuesday   = new Weekday("Tuesday", true);
        public static readonly Weekday Wednesday = new Weekday("Wednesday",true);
        public static readonly Weekday Thursday  = new Weekday("Thursday",true);
        public static readonly Weekday Friday    = new Weekday("Friday",true);
        public static readonly Weekday Saturday  = new Weekday("Saturday",false);
        public static readonly Weekday Sunday    = new Weekday("Sunday", false);

        public bool IsWeekday { get;  }

        private Weekday(string value, bool isWeekday) : base(value) {
            IsWeekday = isWeekday;
        }
    }
````

#### Usage of Typ Weekday

````c#
 Weekday sunday = Weekday.Sunday;
 var isWeekday = sunday.IsWeekday; // false
 var allDaysDuringTheWeek = Weekday.GetAll().Where(x => x.IsWeekday); //  Monday, Tuesday, Wednesday, Thursday, Friday   

 if (Weekday.Monday == sunday) { // its false
     Console.WriteLine("I wish this line will be printed every monday :D");
 } 
````
