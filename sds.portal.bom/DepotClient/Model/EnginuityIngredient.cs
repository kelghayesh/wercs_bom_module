namespace PG.Gps.LocalDepotClient.Model
{
    public class EnginuityIngredient {
        public int? Sequence { get; set; }
        public string GcasCode { get; set; }
        public decimal? SrcLow { get; set; }
        public decimal? SrcTarget { get; set; }
        public decimal? SrcHigh { get; set; }
        public decimal? AdjLow { get; set; }
        public decimal? AdjTarget { get; set; }
        public decimal? AdjHigh { get; set; }
        public int? PhaseNumber { get; set; }

    }
}