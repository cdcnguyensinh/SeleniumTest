using OpenQA.Selenium;

namespace SICorp.Test.BuiderProperties
{
    /// <summary>
    /// Eligibility Details property
    /// </summary>
    public class EligibilityDetailsProp
    {
        /// <summary>
        /// Copy All button
        /// </summary>
        public static By CopyAllLimits = By.Id("btnCopyValues");

        /// <summary>
        /// Save button
        /// </summary>
        public static By ButtonSaveLimits = By.Id("btnSaveLimits");

        /// <summary>
        /// Begin Assessment button
        /// </summary>
        public static By beginAssessmentButton = By.Id("MainContent_eatFinancialLimits_btnBeginAssessment");

        /// <summary>
        /// NSW Open Job Limit Value
        /// </summary>
        public static By HwJobLimitValueTxt = By.Id("MainContent_eatFinancialLimits_txtHwJobLimitValue");

        /// <summary>
        /// NSW Open Job Limit Number
        /// </summary>
        public static By HwJobLimitNumberTxt = By.Id("MainContent_eatFinancialLimits_txtHwOpenJobLimitNumber");

        /// <summary>
        /// HBCF Insurance in other States
        /// </summary>
        public static By HwInsuranceOtherStatesTxt = By.Id("MainContent_eatFinancialLimits_txtHwInsuranceOtherStates");

        /// <summary>
        /// Non HBCF Insurance Income
        /// </summary>
        public static By NonHomeInsuranceTxt = By.Id("MainContent_eatFinancialLimits_txtNonHomeInsurance");

        /// <summary>
        /// New single dwelling construction
        /// </summary>
        public static By FinancialLimits_txtC01 = By.Id("MainContent_eatFinancialLimits_txtC01");

        /// <summary>
        /// Open Job Values checked? 
        /// </summary>
        public static By ChkOpenJobValue = By.Id("MainContent_EligibilityControl1_chkApprovedTurnoverChecked");

        /// <summary>
        /// Generate PDF certificate of eligibility
        /// </summary>
        public static By GenerateCertificateOfEligibilityButton = By.Id("MainContent_EligibilityControl1_btnGenerateCertificateOfEligibility");
        
    }
}
