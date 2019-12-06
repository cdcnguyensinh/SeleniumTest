using OpenQA.Selenium;

namespace SICorp.Test.BuiderProperties
{
    /// <summary>
    /// Initiate Review property
    /// </summary>
    public class InitiateReviewProp
    {
        /// <summary>
        /// Financial year being assessed
        /// </summary>
        public static By FinancialYearDDL = By.Id("MainContent_eatInitiateReviewControl_ddlFinancialYear");

        /// <summary>
        /// Assessment Type
        /// </summary>
        public static By AssessmentTypeDLL = By.Id("MainContent_eatInitiateReviewControl_ddlAssessmentType");

        /// <summary>
        /// Comment
        /// </summary>
        public static By InitialCommentTxt = By.Id("MainContent_eatInitiateReviewControl_txtInitialComment");

        /// <summary>
        /// Scheduled Assessment date
        /// </summary>
        public static By ScheduledAssessmentDate = By.Id("MainContent_eatInitiateReviewControl_dtpkScheduledAssessmentDate_TextBox");

        /// <summary>
        /// Save Initiate Review button
        /// </summary>
        public static By SaveButtonInitiateReview = By.Id("MainContent_eatInitiateReviewControl_btnSave");
    }
}
