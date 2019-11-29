using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SICorp.Test.BuiderProperties;

namespace SICorp.Test.BuilderServices
{
    /// <summary>
    /// Track Record screen service
    /// </summary>
    public class TrackRecordService
    {
        /// <summary>
        /// Check exists value in Tranding Structure select option control
        /// </summary>
        /// <param name="value">Value</param>
        public static bool CheckExistsValueInTradingStructureInput(string value)
        {
            var selectedVal = Util.GetValueSelected(TrackRecordProp.TradingStructureInput);
            return selectedVal.ToUpper().Contains(value.ToUpper());
        }

        /// <summary>
        /// Set value for Trading Structure dropdown
        /// </summary>
        /// <param name="value">Value</param>
        public static void SetTradingStructureInput(string value)
        {
            Util.Select(TrackRecordProp.TradingStructureInput, value);
        }

        /// <summary>
        /// Set value for Entity's residential building licence held dropdown
        /// </summary>
        /// <param name="value">Value</param>
        public static void SetEntityResidentialBuildingLicenceHeld(string value)
        {
            Util.Select(TrackRecordProp.EntityResidentialBuildingLicenceHeldInput, value);
        }

        /// <summary>
        /// Set value for Principal's residential building licence held dropdown
        /// </summary>
        /// <param name="value"></param>
        public static void SetPrincipalResidentialBuildingLicenceHeldInput(string value)
        {
            Util.Select(TrackRecordProp.PrincipalResidentialBuildingLicenceHeldInput, value);
        }

        /// <summary>
        /// Set value for 	Signs of Adverse History (consider builder size and trading history) dropdown
        /// </summary>
        /// <param name="value">Value</param>
        public static void SetSignsOfAdverseHistoryInput(string value)
        {
            Util.Select(TrackRecordProp.SignsOfAdverseHistoryInput, value);
        }

        /// <summary>
        /// Set value for Current Trade Credit Position dropdown
        /// </summary>
        /// <param name="value">Value</param>
        public static void SetCurrentTradeCreditPositionInput(string value)
        {
            Util.Select(TrackRecordProp.CurrentTradeCreditPositionInput, value);
        }

        /// <summary>
        /// Set value for Director's / Principals Licence History dropdown
        /// </summary>
        /// <param name="value">Value</param>
        public static void SetDirectorPrincipalsLicenceHistoryInput(string value)
        {
            Util.Select(TrackRecordProp.DirectorPrincipalsLicenceHistoryInput, value);
        }

        /// <summary>
        /// Set value for Past business closures dropdown
        /// </summary>
        /// <param name="value">Value</param>
        public static void SetPastBusinessClosuresInput(string value)
        {
            Util.Select(TrackRecordProp.PastBusinessClosuresInput, value);
        }

        public static bool CheckWeightedTrackRecordScoreLabel(string value)
        {
            var weightedTrackRecordScore = Util.GetElement(TrackRecordProp.WeightedTrackRecordScoreLabel);
            if (weightedTrackRecordScore.Text == value)
                return true;
            return false;
        }

    }
}
