using IronXL;
using System.Linq;
using TourManager.Storage;
using TourManager.Storage.Models;
using System.Collections.Generic;
using TourManager.Domain.Models.Abstract;
using TourManager.Domain.Models.AboutColumn;
using CellDb = TourManager.Storage.Models.Cell;
using ColumnDb = TourManager.Storage.Models.Column;
using System.Threading.Tasks;
using System;
using TourManager.Storage.Enums;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace TourManager.Domain.Logic
{
    public class ImportManager : BaseManager, IImportManager
    {
        public ImportManager(

            TourManagerDbContext dbContext
            ) : base(dbContext)
        {
        }

        public async Task UploadToursFile(IFormFile uploadedFile, string webRootPath)
        {
            if (uploadedFile != null)
            {
                string path = webRootPath + "/excel-tour-files/" + uploadedFile.FileName;

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                await ImportProcess(path);
            }
        }

        public async Task ImportProcess(string path)
        {
            //WorkBook workBook = WorkBook.Load("C:\\Personal space\\Git\\TourManager.Api\\TourManager.Domain\\dagestan.xlsx");
            WorkBook workBook = WorkBook.Load(path);
            using var transaction = await dbContext.Database.BeginTransactionAsync();
            foreach (var workSheet in workBook.WorkSheets)
            {
                var tour = new Tour();
                tour.StartDate = workSheet.Name;
                dbContext.Set<Tour>().Add(tour);
                dbContext.SaveChanges();

                var columnIndexToNameMap = new Dictionary<int, ColumnDb>();
                var columnIndexToItsMaximumColumnIndexMap = new Dictionary<int, int>();
                int? touristNameIndex = null;
                var maxColumnIndex = 0;

                #region construct dictionary map for column
                foreach (var cell in workSheet.FilledCells)
                {
                    if (cell.RowIndex == 0)
                    {
                        switch (cell.StringValue)
                        {
                            case WellKnownColumns.AllVisitDays:
                                {
                                    columnIndexToNameMap.Add(cell.ColumnIndex,
                                        new ColumnDb
                                        {
                                            Code = WellKnownColumns.AllVisitDays,
                                            Name = "Всего дней",
                                            ValueType = ColumnValueType.Int,
                                            TourId = tour.Id,
                                            SortOrder = cell.ColumnIndex
                                        });
                                }
                                break;
                            case WellKnownColumns.TourStartDate:
                                {
                                    maxColumnIndex = maxColumnIndex < cell.ColumnIndex ? cell.ColumnIndex : maxColumnIndex;
                                    columnIndexToNameMap.Add(cell.ColumnIndex,
                                        new ColumnDb
                                        {
                                            Code = WellKnownColumns.TourStartDate,
                                            Name = "Начало тура",
                                            ValueType = ColumnValueType.DateTime,
                                            TourId = tour.Id,
                                            SortOrder = cell.ColumnIndex
                                        });
                                }
                                break;
                            case WellKnownColumns.TourEndDate:
                                {
                                    maxColumnIndex = maxColumnIndex < cell.ColumnIndex ? cell.ColumnIndex : maxColumnIndex;
                                    columnIndexToNameMap.Add(cell.ColumnIndex,
                                        new ColumnDb
                                        {
                                            Code = WellKnownColumns.TourEndDate,
                                            Name = "Конец тура",
                                            ValueType = ColumnValueType.DateTime,
                                            TourId = tour.Id,
                                            SortOrder = cell.ColumnIndex
                                        });
                                }
                                break;
                            case WellKnownColumns.ArrivingDate:
                                {
                                    maxColumnIndex = maxColumnIndex < cell.ColumnIndex ? cell.ColumnIndex : maxColumnIndex;
                                    columnIndexToNameMap.Add(cell.ColumnIndex,
                                        new ColumnDb
                                        {
                                            Code = WellKnownColumns.ArrivingDate,
                                            Name = "Дата и время приезда",
                                            ValueType = ColumnValueType.String,
                                            TourId = tour.Id,
                                            SortOrder = cell.ColumnIndex
                                        });
                                }
                                break;
                            case WellKnownColumns.DepartureDate:
                                {
                                    maxColumnIndex = maxColumnIndex < cell.ColumnIndex ? cell.ColumnIndex : maxColumnIndex;
                                    columnIndexToNameMap.Add(cell.ColumnIndex,
                                        new ColumnDb
                                        {
                                            Code = WellKnownColumns.DepartureDate,
                                            Name = "Дата и время отъезда",
                                            ValueType = ColumnValueType.String,
                                            TourId = tour.Id,
                                            SortOrder = cell.ColumnIndex
                                        });
                                }
                                break;
                            case WellKnownColumns.OrderNumber:
                                {
                                    maxColumnIndex = maxColumnIndex < cell.ColumnIndex ? cell.ColumnIndex : maxColumnIndex;
                                    columnIndexToNameMap.Add(cell.ColumnIndex,
                                        new ColumnDb
                                        {
                                            Code = WellKnownColumns.OrderNumber,
                                            Name = "Номер заказа",
                                            ValueType = ColumnValueType.String,
                                            TourId = tour.Id,
                                            SortOrder = cell.ColumnIndex
                                        });
                                }
                                break;
                            case WellKnownColumns.PhoneNumber:
                                {
                                    maxColumnIndex = maxColumnIndex < cell.ColumnIndex ? cell.ColumnIndex : maxColumnIndex;
                                    columnIndexToNameMap.Add(cell.ColumnIndex,
                                        new ColumnDb
                                        {
                                            Code = WellKnownColumns.PhoneNumber,
                                            Name = "Номер телефона",
                                            ValueType = ColumnValueType.String,
                                            TourId = tour.Id,
                                            SortOrder = cell.ColumnIndex
                                        });
                                }
                                break;
                            case WellKnownColumns.TourDaysNumber:
                                {
                                    maxColumnIndex = maxColumnIndex < cell.ColumnIndex ? cell.ColumnIndex : maxColumnIndex;
                                    columnIndexToNameMap.Add(cell.ColumnIndex,
                                        new ColumnDb
                                        {
                                            Code = WellKnownColumns.TourDaysNumber,
                                            ValueType = ColumnValueType.Int,
                                            TourId = tour.Id,
                                            SortOrder = cell.ColumnIndex
                                        });
                                }
                                break;
                            case WellKnownColumns.Comment:
                                {
                                    maxColumnIndex = maxColumnIndex < cell.ColumnIndex ? cell.ColumnIndex : maxColumnIndex;
                                    columnIndexToNameMap.Add(cell.ColumnIndex,
                                        new ColumnDb
                                        {
                                            Code = WellKnownColumns.Comment,
                                            Name = "Коментарии",
                                            ValueType = ColumnValueType.String,
                                            TourId = tour.Id,
                                            SortOrder = cell.ColumnIndex
                                        });
                                }
                                break;
                            case WellKnownColumns.BirthData:
                                {
                                    maxColumnIndex = maxColumnIndex < cell.ColumnIndex ? cell.ColumnIndex : maxColumnIndex;
                                    columnIndexToNameMap.Add(cell.ColumnIndex,
                                        new ColumnDb
                                        {
                                            Code = WellKnownColumns.BirthData,
                                            Name = "Дата рождения",
                                            ValueType = ColumnValueType.DateTime,
                                            TourId = tour.Id,
                                            SortOrder = cell.ColumnIndex
                                        });
                                }
                                break;
                            case WellKnownColumns.FullName:
                                {
                                    touristNameIndex = cell.ColumnIndex;
                                    maxColumnIndex = maxColumnIndex < cell.ColumnIndex ? cell.ColumnIndex : maxColumnIndex;
                                    columnIndexToNameMap.Add(cell.ColumnIndex,
                                        new ColumnDb
                                        {
                                            Code = WellKnownColumns.FullName,
                                            Name = "Имя",
                                            ValueType = ColumnValueType.String,
                                            TourId = tour.Id,
                                            SortOrder = cell.ColumnIndex
                                        });
                                }
                                break;
                            case WellKnownColumns.TourName:
                                {
                                    maxColumnIndex = maxColumnIndex < cell.ColumnIndex ? cell.ColumnIndex : maxColumnIndex;
                                    columnIndexToNameMap.Add(cell.ColumnIndex,
                                        new ColumnDb
                                        {
                                            Code = WellKnownColumns.TourName,
                                            Name = "Название тура",
                                            ValueType = ColumnValueType.String,
                                            TourId = tour.Id,
                                            SortOrder = cell.ColumnIndex
                                        });
                                }
                                break;
                            case WellKnownColumns.PassportId:
                                {
                                    maxColumnIndex = maxColumnIndex < cell.ColumnIndex ? cell.ColumnIndex : maxColumnIndex;
                                    columnIndexToNameMap.Add(cell.ColumnIndex,
                                        new ColumnDb
                                        {
                                            Code = WellKnownColumns.PassportId,
                                            Name = "Номер паспорта",
                                            ValueType = ColumnValueType.String,
                                            TourId = tour.Id,
                                            SortOrder = cell.ColumnIndex
                                        });
                                }
                                break;
                            default:
                                //ToDo log this place
                                break;
                        }
                    }
                    CalculateMaximumColumnIndexInTheRow(cell);
                }
                #endregion

                dbContext.Set<ColumnDb>().AddRange(columnIndexToNameMap.Values.ToList());
                dbContext.SaveChanges();

                Tourist tourist = null;
                var cells = new List<CellDb>();
                foreach (var cell in workSheet.FilledCells)
                {
                    if (cell.ColumnIndex == 0 && cell.RowIndex > 0)
                    {
                        cells = new List<CellDb>();
                        tourist = new Tourist();
                        tourist.TourId = tour.Id;
                        dbContext.Set<Tourist>().Add(tourist);
                        dbContext.SaveChanges();
                    }
                    if (cell.RowIndex > 0 && cell.StringValue != null)
                    {
                        if (columnIndexToNameMap.TryGetValue(cell.ColumnIndex, out var column))
                        {
                            var newCell = new CellDb { ColumnId = column.Id, };
                            if (tourist != null && cell.ColumnIndex == touristNameIndex && column.ValueType == ColumnValueType.String)
                            {
                                newCell.TouristId = tourist.Id;
                                tourist.Name = cell.StringValue;
                            }

                            switch (column.ValueType)
                            {
                                case ColumnValueType.Int:
                                    newCell.TouristId = tourist.Id;
                                    newCell.IntValue = int.Parse(cell.StringValue);
                                    cells.Add(newCell);
                                    break;
                                case ColumnValueType.String:
                                    newCell.TouristId = tourist.Id;
                                    newCell.StringValue = cell.StringValue;
                                    cells.Add(newCell);
                                    break;
                                case ColumnValueType.Decimal:
                                    newCell.TouristId = tourist.Id;
                                    newCell.DecimalValue = cell.DecimalValue;
                                    cells.Add(newCell);
                                    break;
                                case ColumnValueType.DateTime:
                                    newCell.TouristId = tourist.Id;
                                    newCell.DateTimeValue = DateTime.Parse(cell.StringValue);
                                    cells.Add(newCell);
                                    break;
                                case ColumnValueType.Bool:
                                    newCell.TouristId = tourist.Id;
                                    newCell.BoolValue = bool.Parse(cell.StringValue);
                                    cells.Add(newCell);
                                    break;
                                default:
                                    //todo log or throw exception if cases exist
                                    break;
                            }
                        }
                        if (cell.ColumnIndex == columnIndexToItsMaximumColumnIndexMap[cell.RowIndex])
                        {
                            dbContext.Set<CellDb>().AddRange(cells);
                            dbContext.SaveChanges();
                        }
                    }
                }

                void CalculateMaximumColumnIndexInTheRow(IronXL.Cell cell)
                {
                    maxColumnIndex = maxColumnIndex < cell.ColumnIndex ? cell.ColumnIndex : maxColumnIndex;

                    if (columnIndexToItsMaximumColumnIndexMap.TryGetValue(cell.RowIndex, out var value))
                    {
                        columnIndexToItsMaximumColumnIndexMap[cell.RowIndex] = maxColumnIndex;
                    }
                    else
                    {
                        columnIndexToItsMaximumColumnIndexMap.Add(cell.RowIndex, maxColumnIndex);
                    }
                }
            }
            File.Delete(path);
            await transaction.CommitAsync();
        }
    }
}
