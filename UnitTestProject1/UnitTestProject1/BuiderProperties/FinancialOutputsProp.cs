using OpenQA.Selenium;

namespace SICorp.Test.BuiderProperties
{
    /// <summary>
    /// Financial Output screen properties
    /// </summary>
    public class FinancialOutputsProp
    {
        /// <summary>
        /// Get all rows by 'AssessmnetOutcome' class name in BEAT ADJUSTED CALCULATIONS section
        /// </summary>
        public static By TableBEATAdjustedCalculations = By.CssSelector("#MainContent_eatFinancialOutputsControl_adjustedAnalysisCompanyOrTrust tbody > tr.AssesmentOutcome");

        /// <summary>
        /// Get all rows by 'moduleHeader' class name in BEAT ADJUSTED CALCULATIONS section 
        /// </summary>
        public static By TableRowModuleHeader = By.CssSelector("#MainContent_eatFinancialOutputsControl_adjustedAnalysisCompanyOrTrust tbody > tr.moduleHeader");
        
    }
}
