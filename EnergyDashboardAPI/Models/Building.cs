using System;
using System.Collections.Generic;

namespace EnergyDashboardAPI.Models;

public partial class Building
{
    public long Bbl { get; set; }

    public int? BoroughNumber { get; set; }

    public string? BuildingName { get; set; }

    public string? BuildingAddress { get; set; }

    public string? Borough { get; set; }

    public string? State { get; set; }

    public int? Postcode { get; set; }

    public int? Block { get; set; }

    public int? Lot { get; set; }

    public long? EnergyUsage { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public int? CommunityBoard { get; set; }

    public int? CouncilDistrict { get; set; }

    public int? CensusTract { get; set; }

    public long? Bin { get; set; }

    public string? Nta { get; set; }
}
