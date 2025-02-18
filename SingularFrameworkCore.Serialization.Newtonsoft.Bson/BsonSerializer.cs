using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using SingularFrameworkCore.Serialization;

namespace SingularFrameworkCore.Serialization.Newtonsoft.Bson;

public class BsonSerializer<T> : IEntitySerializer<T, byte[]>
{
    public byte[] Serialize(T entity)
    {
        MemoryStream ms = new MemoryStream();
        BsonDataWriter writer = new BsonDataWriter(ms);
        new JsonSerializer().Serialize(writer, entity);
        return ms.ToArray();
    }

    public T Deserialize(byte[] bson)
    {
        if (bson == null || bson.Length == 0)
            throw new JsonSerializationException("Cannot deserializer an empty byte array");
        MemoryStream ms = new MemoryStream(bson);
        BsonDataReader reader = new BsonDataReader(ms);
        var result = new JsonSerializer().Deserialize<T>(reader)!;
        if (result == null)
            throw new JsonSerializationException("Couldn't deserialize the data.");
        return result;
    }
}
