# SingularFrameworkCore.Serialization.Newtonsoft.Bson

A C# library that provides a Bson serializer implementation for the SingularFrameworkCore serialization interface. This library leverages the popular Newtonsoft.Json.Bson library to offer robust serialization and deserialization capabilities.

## Features

- **Generic Input Type**: Supports serialization and deserialization of any object type.
- **Newtonsoft.Json.Bson**: Utilizes the widely-used Newtonsoft.Bson library for Bson operations.
- **Bidirectional Support**: Implements both serialization and deserialization.

## Installation

The package is available on NuGet. To install it, use the following command:

```bash
Install-Package SingularFrameworkCore.Serialization.Newtonsoft.Bson
```

Or using the .NET CLI:

```bash
dotnet add package SingularFrameworkCore.Serialization.Newtonsoft.Bson
```

## Usage

### Serialization and Deserialization

```csharp
using SingularFrameworkCore.Serialization.Newtonsoft.Bson;

// Declare our example model
class MyClass {
    public string Name;
    public int Age;
}

// Create an instance of the BsonSerializer for your specific type
var BsonSerializer = new BsonSerializer<MyClass>();

// Create an object to serialize
var myObject = new MyClass { Name = "John", Age = 30 };

// Serialize the object to a Bson string
string BsonString = BsonSerializer.Serialize(myObject);

// Deserialize the Bson string back to an object
MyClass deserializedObject = BsonSerializer.Deserialize(BsonString);
```

## Integration with SingularFrameworkCore

This library implements the `IEntitySerializer<I, O>` interface from SingularFrameworkCore, making it ideal for use within the Singular pipeline:

```csharp
var singular = new Singular<MyClass, byte[]>(
    repository,
    new BsonSerializer<MyClass>(), // Use the Bson serializer
    preProcessors,
    postProcessors
);
```

## Requirements

- .NET Standard 8.0+
- Newtonsoft.Bson

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the Apache License 2.0 - see the [LICENSE](LICENSE) file for details.

## Author

Created by Mohammad Ayaad

## Related Projects

- [SingularFrameworkCore](https://github.com/MohammadAyaad/SingularFrameworkCore) - The core framework this implementation is built for
- [Newtonsoft.Json.Bson](https://www.newtonsoft.com/Bson) - The Bson library used for serialization