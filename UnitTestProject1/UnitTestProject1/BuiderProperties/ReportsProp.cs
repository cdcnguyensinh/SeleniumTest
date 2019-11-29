using OpenQA.Selenium;

namespace SICorp.Test.BuiderProperties
{
    /// <summary>
    /// Reports menu screen
    /// </summary>
    public class ReportsProp
    {
        /// <summary>
        /// Eligibility Assessment Type column
        /// </summary>
        public static By EligibilityAssessmentType = By.CssSelector("#MainContent_ReportGrid_DXMainTable > tbody > tr > td > table > tbody > tr");
    }
}
