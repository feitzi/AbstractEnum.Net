using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AbstractEnum.Tests.TestData;
using Xunit;

namespace AbstractEnum.Tests {

    public class SerializationTests {

        [Fact]
        public void BinarySerializationTest() {
            Weekday saturday = Weekday.Saturday;

            //serialize weekday
            byte[] serializedData;
            using (MemoryStream memoryStream = new MemoryStream()) {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, saturday);
                serializedData = memoryStream.ToArray();
            }

            //deserialize weekday
            Weekday deserializedDay;
            using (MemoryStream memoryStream = new MemoryStream(serializedData)) {
                memoryStream.Position = 0;
                deserializedDay = new BinaryFormatter().Deserialize(memoryStream) as Weekday;
            }

            Assert.NotSame(saturday, deserializedDay);
            Assert.NotSame(Weekday.Saturday, deserializedDay);
            Assert.Equal(saturday, deserializedDay);
            Assert.Equal(Weekday.Saturday, deserializedDay);
            Assert.NotEqual(Weekday.Sunday, deserializedDay);
        }

    }

}