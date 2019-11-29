using OpenQA.Selenium;

namespace SICorp.Test.BuiderProperties
{
    /// <summary>
    /// Track Record screen property
    /// </summary>
    public class TrackRecordProp
    {
        /// <summary>
        /// Tranding Structure dropdown
        /// </summary>
        public static By TradingStructureInput = By.Id("TS");

        /// <summary>
        /// Entity's residential building licence held dropdown
        /// </summary>
        public static By EntityResidentialBuildingLicenceHeldInput = By.Id("YT");

        /// <summary>
        /// Principal's residential building licence held dropdown
        /// </summary>
        public static By PrincipalResidentialBuildingLicenceHeldInput = By.Id("BEX");

        /// <summary>
        /// Signs of Adverse History (consider builder size and trading history)
        /// </summary>
        public static By SignsOfAdverseHistoryInput = By.Id("AH");

        /// <summary>
        /// Current Trade Credit Position
        /// </summary>
        public static By CurrentTradeCreditPositionInput = By.Id("TCH");

        /// <summary>
        /// Director's / Principals Licence History
        /// </summary>
        public static By DirectorPrincipalsLicenceHistoryInput = By.Id("DP");

        /// <summary>
        /// Past business closures
        /// </summary>
        public static By PastBusinessClosuresInput = By.Id("PI");

        /// <summary>
        /// Weighted Track Record Score
        /// </summary>
        public static By WeightedTrackRecordScoreLabel = By.Id("lblTotalWeightedScore");
    }
}
