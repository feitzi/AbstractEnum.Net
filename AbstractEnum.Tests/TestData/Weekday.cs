using System;
using AbstractEnum.Net;

namespace AbstractEnum.Tests.TestData {

    [Serializable]
    public class Weekday : AbstractEnum<Weekday> {

        public static readonly Weekday Monday = new Weekday("Monday");
        public static readonly Weekday Tuesday = new Weekday("Tuesday");
        public static readonly Weekday Wednesday = new Weekday("Wednesday");
        public static readonly Weekday Thursday = new Weekday("Thursday");
        public static readonly Weekday Friday = new Weekday("Friday");
        public static readonly Weekday Saturday = new Weekday("Saturday");
        public static readonly Weekday Sunday = new Weekday("Sunday");

        private Weekday(string value) : base(value) {
        }

    }

}