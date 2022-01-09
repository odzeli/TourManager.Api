using Microsoft.EntityFrameworkCore;
using TourManager.Storage.Models;

namespace TourManager.Storage
{
    internal static class DataSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StandardColumn>()
                .HasData(
                new StandardColumn
                {
                    Id = 1,
                    Name = "Имя",
                    Code = "name",
                    ValueType = Enums.ColumnValueType.String,
                    DefaultAccess = Enums.DefaultAccess.None,
                    SortOrder = 0,
                    Options =  Enums.ColumnOptions.DisplayInGrid
                },
                new StandardColumn
                {
                    Id = 2,
                    Name = "Начало тура",
                    Code = "startDate",
                    ValueType = Enums.ColumnValueType.DateTime,
                    DefaultAccess = Enums.DefaultAccess.None,
                    SortOrder = 1,
                    Options = Enums.ColumnOptions.DisplayInGrid
                },
                new StandardColumn
                {
                    Id = 3,
                    Name = "Конец тура",
                    Code = "endDate",
                    ValueType = Enums.ColumnValueType.DateTime,
                    DefaultAccess = Enums.DefaultAccess.None,
                    SortOrder = 3,
                    Options = Enums.ColumnOptions.DisplayInGrid
                },
                new StandardColumn
                {
                    Id = 4,
                    Name = "Дней в туре",
                    Code = "daysNumber",
                    ValueType = Enums.ColumnValueType.Int,
                    DefaultAccess = Enums.DefaultAccess.None,
                    SortOrder = 4,
                    Options = Enums.ColumnOptions.DisplayInGrid
                },
                new StandardColumn
                {
                    Id = 5,
                    Name = "Ночей в отеле",
                    Code = "nightsInHotel",
                    ValueType = Enums.ColumnValueType.Int,
                    DefaultAccess = Enums.DefaultAccess.None,
                    SortOrder = 5,
                    Options = Enums.ColumnOptions.DisplayInGrid
                },
                new StandardColumn
                {
                    Id = 6,
                    Name = "Категория тура",
                    Code = "tourStars",
                    ValueType = Enums.ColumnValueType.Int,
                    DefaultAccess = Enums.DefaultAccess.None,
                    SortOrder = 6,
                    Options = Enums.ColumnOptions.DisplayInGrid
                },
                new StandardColumn
                {
                    Id = 7,
                    Name = "Тип номера",
                    Code = "roomType",
                    ValueType = Enums.ColumnValueType.String,
                    DefaultAccess = Enums.DefaultAccess.None,
                    SortOrder = 7,
                    Options = Enums.ColumnOptions.DisplayInGrid
                },
                new StandardColumn
                {
                    Id = 8,
                    Name = "Номер телефона",
                    Code = "phone",
                    ValueType = Enums.ColumnValueType.String,
                    DefaultAccess =  Enums.DefaultAccess.None,
                    SortOrder = 8,
                    Options = Enums.ColumnOptions.DisplayInGrid
                },
                new StandardColumn
                {
                    Id = 9,
                    Name = "Отель",
                    Code = "hotel",
                    ValueType = Enums.ColumnValueType.String,
                    DefaultAccess = Enums.DefaultAccess.None,
                    SortOrder = 9,
                    Options = Enums.ColumnOptions.DisplayInGrid
                },
                new StandardColumn
                {
                    Id = 10,
                    Name = "Закрытая цена",
                    Code = "closedPrice",
                    ValueType = Enums.ColumnValueType.Decimal,
                    DefaultAccess = Enums.DefaultAccess.None,
                    SortOrder = 10,
                    Options = Enums.ColumnOptions.DisplayInGrid
                }
                );
        }
    }
}
