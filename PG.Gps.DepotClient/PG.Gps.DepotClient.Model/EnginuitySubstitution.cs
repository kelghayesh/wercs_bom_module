namespace PG.Gps.DepotClient.Model
{
    public class EnginuitySubstitution {
        public string SubstitutionSeq { get; set; }
        public string IngredientToAdd { get; set; }
        public string IngredientToRemove { get; set; }
        public decimal? SrcLow { get; set; }
        public decimal? SrcTarget { get; set; }
        public decimal? SrcHigh { get; set; }

    }
}