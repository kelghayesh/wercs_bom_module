namespace PG.Gps.LocalDepotClient.Model
{
    public class DepotCompositionPart : DepotPart
    {
        public string CompositionTypeName { get; set; }
        public decimal? AdjLow { get; set; }
        public decimal? AdjTarget { get; set; }
        public decimal? AdjHigh { get; set; }
        public decimal? SrcLow { get; set; }
        public decimal? SrcTarget { get; set; }
        public decimal? SrcHigh { get; set; }
        public string SrcUom { get; set; }
        public bool? IsBom { get; set; }
        public bool? IsSds { get; set; }
        public int Level { get; set; }
        public string Path { get; set; }
    }
}
