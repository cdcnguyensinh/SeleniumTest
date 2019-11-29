using OpenQA.Selenium;

namespace SICorp.Test.BuiderProperties
{
    /// <summary>
    /// Builder Detail screen property
    /// </summary>
    public class BuilderDetailProp
    {
        /// <summary>
        /// Year End Month dropdown
        /// </summary>
        public static By YearEndMonthDll = By.Id("MainContent_eatBuilderInformationControl_ddlYearEndMonth");

        /// <summary>
        /// Buider Detail button
        /// </summary>
        public static By SaveBuilderDetailButton = By.Id("btnSaveBuilderDetails");

        /// <summary>
        /// Key Event Log table
        /// </summary>
        public static By KeyEventLogTable = By.Id("MainContent_eatBuilderInformationControl_KeyEventLogGridView");

        /// <summary>
        /// Licensed Builder Entity Name
        /// </summary>
        public static By BuilderNameTxt = By.Id("txtEaBuilderEntityName");

        /// <summary>
        /// Table Assessment section
        /// </summary>
        public static By AssessmentsTableBuilderDetail = By.Id("MainContent_eatBuilderInformationControl_searchResultsGridViewAssessment");

    }
}
