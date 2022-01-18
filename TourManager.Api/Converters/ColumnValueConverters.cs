using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using TourManager.Domain.Models.AboutColumn;
using TourManager.Storage.Enums;

namespace TourManager.Api.Converters
{
    sealed public class ColumnValueConverter : JsonConverter<IValue>
    {
        public override IValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var jsonDoc = JsonDocument.ParseValue(ref reader);
            var typeFromRequest = jsonDoc.RootElement.GetProperty("valueType").GetInt32();
            var enumType = (ColumnValueType)typeFromRequest;
            switch (enumType)
            {
                case ColumnValueType.Int:
                    return JsonSerializer.Deserialize<ColumnValue<int?>>(jsonDoc.RootElement.ToString(), options);
                case ColumnValueType.Bool:
                    return JsonSerializer.Deserialize<ColumnValue<bool?>>(jsonDoc.RootElement.ToString(), options);
                case ColumnValueType.Guid:
                    return JsonSerializer.Deserialize<ColumnValue<Guid?>>(jsonDoc.RootElement.ToString(), options);
                case ColumnValueType.String:
                    return JsonSerializer.Deserialize<ColumnValue<string>>(jsonDoc.RootElement.ToString(), options);
                case ColumnValueType.Decimal:
                    return JsonSerializer.Deserialize<ColumnValue<decimal?>>(jsonDoc.RootElement.ToString(), options);
                case ColumnValueType.DateTime:
                    return JsonSerializer.Deserialize<ColumnValue<DateTime?>>(jsonDoc.RootElement.ToString(), options);
            }
            throw new NotSupportedException($"Type serialization failed with {enumType}. Its is not supported");
        }



        public override void Write(Utf8JsonWriter writer, IValue value, JsonSerializerOptions options)
        {
            switch (value.ValueType)
            {
                case ColumnValueType.Int:
                    JsonSerializer.Serialize(writer, (ColumnValue<int?>)value, options);
                    break;
                case ColumnValueType.Bool:
                    JsonSerializer.Serialize(writer, (ColumnValue<bool?>)value, options);
                    break;
                case ColumnValueType.Guid:
                    JsonSerializer.Serialize(writer, (ColumnValue<Guid>)value, options);
                    break;
                case ColumnValueType.String:
                    JsonSerializer.Serialize(writer, (ColumnValue<string>)value, options);
                    break;
                case ColumnValueType.Decimal:
                    JsonSerializer.Serialize(writer, (ColumnValue<decimal?>)value, options);
                    break;
                case ColumnValueType.DateTime:
                    JsonSerializer.Serialize(writer, (ColumnValue<DateTime?>)value, options);
                    break;
                default: throw new NotSupportedException($"Value of type {value.ValueType} is not supported");
            }
        }
    }
}
