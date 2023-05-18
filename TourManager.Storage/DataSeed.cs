using Microsoft.EntityFrameworkCore;
using System;
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
                    Id = Guid.NewGuid(),
                    Name = "Начало тура",
                    Code = "TourStartDate",
                    ValueType = Enums.ColumnValueType.DateTime,
                    DefaultAccess = Enums.DefaultAccess.None,
                    SortOrder = 0,
                    Options = Enums.ColumnOptions.DisplayInGrid
                },
                new StandardColumn
                {
                    Id = Guid.NewGuid(),
                    Name = "Конец тура",
                    Code = "TourEndDate",
                    ValueType = Enums.ColumnValueType.DateTime,
                    DefaultAccess = Enums.DefaultAccess.None,
                    SortOrder = 1,
                    Options = Enums.ColumnOptions.DisplayInGrid
                },
                new StandardColumn
                {
                    Id = Guid.NewGuid(),
                    Name = "OrderNumber",
                    Code = "Номер заказа",
                    ValueType = Enums.ColumnValueType.String,
                    DefaultAccess = Enums.DefaultAccess.None,
                    SortOrder = 2,
                    Options = Enums.ColumnOptions.DisplayInGrid
                },
                new StandardColumn
                {
                    Id = Guid.NewGuid(),
                    Name = "Название тура",
                    Code = "TourName",
                    ValueType = Enums.ColumnValueType.String,
                    DefaultAccess = Enums.DefaultAccess.None,
                    SortOrder = 3,
                    Options = Enums.ColumnOptions.DisplayInGrid
                },
                new StandardColumn
                {
                    Id = Guid.NewGuid(),
                    Name = "Имя",
                    Code = "FullName",
                    ValueType = Enums.ColumnValueType.String,
                    DefaultAccess = Enums.DefaultAccess.None,
                    SortOrder = 4,
                    Options = Enums.ColumnOptions.DisplayInGrid
                },
                new StandardColumn
                {
                    Id = Guid.NewGuid(),
                    Name = "Дата и время приезда",
                    Code = "ArrivingDate",
                    ValueType = Enums.ColumnValueType.String,
                    DefaultAccess = Enums.DefaultAccess.None,
                    SortOrder = 5,
                    Options = Enums.ColumnOptions.DisplayInGrid
                },
                new StandardColumn
                {
                    Id = Guid.NewGuid(),
                    Name = "Дата и время отъезда",
                    Code = "DepartureDate",
                    ValueType = Enums.ColumnValueType.String,
                    DefaultAccess = Enums.DefaultAccess.None,
                    SortOrder = 6,
                    Options = Enums.ColumnOptions.DisplayInGrid
                },
                new StandardColumn
                {
                    Id = Guid.NewGuid(),
                    Name = "Дата рождения",
                    Code = "BirthData",
                    ValueType = Enums.ColumnValueType.DateTime,
                    DefaultAccess = Enums.DefaultAccess.None,
                    SortOrder = 7,
                    Options = Enums.ColumnOptions.DisplayInGrid
                },
                new StandardColumn
                {
                    Id = Guid.NewGuid(),
                    Name = "Номер телефона",
                    Code = "PhoneNumber",
                    ValueType = Enums.ColumnValueType.String,
                    DefaultAccess = Enums.DefaultAccess.None,
                    SortOrder = 8,
                    Options = Enums.ColumnOptions.DisplayInGrid
                },
                new StandardColumn
                {
                    Id = Guid.NewGuid(),
                    Name = "Номер паспорта",
                    Code = "PassportId",
                    ValueType = Enums.ColumnValueType.String,
                    DefaultAccess = Enums.DefaultAccess.None,
                    SortOrder = 9,
                    Options = Enums.ColumnOptions.DisplayInGrid
                },
                new StandardColumn
                {
                    Id = Guid.NewGuid(),
                    Name = "Коментарии",
                    Code = "Comment",
                    ValueType = Enums.ColumnValueType.String,
                    DefaultAccess = Enums.DefaultAccess.None,
                    SortOrder = 10,
                    Options = Enums.ColumnOptions.DisplayInGrid
                },
                new StandardColumn
                {
                    Id = Guid.NewGuid(),
                    Name = "Отель",
                    Code = "Accommodation",
                    ValueType = Enums.ColumnValueType.String,
                    DefaultAccess = Enums.DefaultAccess.None,
                    SortOrder = 11,
                    Options = Enums.ColumnOptions.DisplayInGrid
                }

                //new StandardColumn
                //{
                //    Id = Guid.NewGuid(),
                //    Name = "Всего дней",
                //    Code = "AllVisitDays",
                //    ValueType = Enums.ColumnValueType.Int,
                //    DefaultAccess = Enums.DefaultAccess.None,
                //    SortOrder = 5,
                //    Options = Enums.ColumnOptions.DisplayInGrid
                //},
                );
        }
    }
}
