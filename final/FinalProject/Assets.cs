class Assets
{
    public string FarmingSpecialization { get; set; }
    public decimal Cash { get; set; }
    public decimal Land { get; set; }
    public decimal Goodwill { get; set; }

    public Assets(string farmingSpecialization, decimal cash, decimal land, decimal goodwill)
    {
        FarmingSpecialization = farmingSpecialization;
        Cash = cash;
        Land = land;
        Goodwill = goodwill;
    }

    public decimal TotalCash => Cash;
    public decimal TotalLand => Land;
    public decimal TotalGoodwill => Goodwill;
}
