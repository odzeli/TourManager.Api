using System;

namespace TourManager.Storage.Enums
{
    [Flags]
    public enum DefaultAccess
    {
        None = 0,
        User = 1,
        Admin = 2
    }
}
