using System;

namespace TourManager.Storage.Enums
{
    [Flags]
    public enum ColumnOptions
    {
        None = 0,
        DisplayInPersonalPanel = 1,
        DisplayInGrid = 2,

    }
}
