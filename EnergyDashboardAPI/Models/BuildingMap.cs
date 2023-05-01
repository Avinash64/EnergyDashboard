using System;
using System.Collections.Generic;

namespace EnergyDashboardAPI.Models;

public partial class BuildingMap
{
    public long Bbl { get; set; }

    public string? BuildingName { get; set; }

    public string? BuildingAddress { get; set; }

    public long? EnergyUsage { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    
}
