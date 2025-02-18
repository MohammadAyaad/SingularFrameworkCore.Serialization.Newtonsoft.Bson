using Newtonsoft.Json;
using SingularFrameworkCore.Serialization.Newtonsoft.Bson;
using Xunit;

namespace SingularFrameworkCore.Serialization.Newtonsoft.Bson.Tests
{
    public class BsonSerializerTests
    {
        public record Person(string Name, int Age);

        [Fact]
        public void Serialize_ValidObject_ReturnsNonNullByteArray()
        {
            var serializer = new BsonSerializer<Person>();
            var person = new Person("Alice", 30);

            byte[] result = serializer.Serialize(person);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void RoundTrip_SerializeAndDeserialize_ReturnsEquivalentObject()
        {
            var serializer = new BsonSerializer<Person>();
            var originalPerson = new Person("Bob", 25);

            byte[] serializedData = serializer.Serialize(originalPerson);
            Person deserializedPerson = serializer.Deserialize(serializedData);

            Assert.Equal(originalPerson, deserializedPerson);
        }

        [Fact]
        public void Deserialize_InvalidData_ThrowsJsonException()
        {
            var serializer = new BsonSerializer<Person>();
            byte[] invalidBson = { 0x00, 0x01, 0x02, 0x00 }; // Invalid but sufficient length to attempt parsing

            Assert.ThrowsAny<JsonException>(() => serializer.Deserialize(invalidBson));
        }

        [Fact]
        public void Serialize_NullObject_ThrowsJsonWriterException()
        {
            var serializer = new BsonSerializer<Person>();
            Person nullPerson = null!;

            Assert.Throws<JsonWriterException>(() => serializer.Serialize(nullPerson));
        }
    }
}
