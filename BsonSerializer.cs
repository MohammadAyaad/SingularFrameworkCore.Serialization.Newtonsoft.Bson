using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using SingularFrameworkCore.Serialization;

namespace SingularFrameworkCore.Serialization.Newtonsoft.Bson;

class BsonSerializer<T> : IEntitySerializer<T, byte[]>
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
        MemoryStream ms = new MemoryStream(bson);
        BsonDataReader reader = new BsonDataReader(ms);
        return new JsonSerializer().Deserialize<T>(reader)!;
    }
}
