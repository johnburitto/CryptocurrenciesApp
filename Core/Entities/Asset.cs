﻿namespace Core.Entities
{
    public class Asset
    {
        public string? Id { get; set; }
        public string? Rank { get; set; }
        public string? Symbol { get; set; }
        public string? Name { get; set; }
        public string? Supply { get; set; }
        public string? MaxSupply { get; set; }
        public string? MarketCapUsd { get; set; }
        public string? VolumeUsd24Hr { get; set; }
        public string? PriceUsd { get; set; }
        public string? ChangePercent24Hr { get; set; }
        public string? Vwap24Hr { get; set; }
        public string? Explorer { get; set; }

        public string? ImgPath => File.Exists($"{Environment.CurrentDirectory}/Images/{Id}.png") ? $"{Environment.CurrentDirectory}/Images/{Id}.png" 
            : $"{Environment.CurrentDirectory}/Images/no-picture-taking.png";
    }
}
