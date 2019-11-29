using SICorp.Test.BuiderProperties;

namespace SICorp.Test.BuilderServices
{
    /// <summary>
    /// Eligibility Details screen service
    /// </summary>
    public class EligibilityDetailsService
    {
        /// <summary>
        /// Click Copy All button
        /// </summary>
        public static void ClickCopyAllLimitsLink()
        {
            Util.Click(EligibilityDetailsProp.CopyAllLimits);
        }

        /// <summary>
        /// Click Save button
        /// </summary>
        public static void ClickButtonSaveEligibilityReview()
        {
            Util.Click(EligibilityDetailsProp.ButtonSaveLimits);
        }

        /// <summary>
        /// Is enabled Begin Assessment button
        /// </summary>
        /// <returns></returns>
        public static bool VerifyBeginAssessmentIsEnabled()
        {
            return Util.IsEnable(EligibilityDetailsProp.beginAssessmentButton);
        }

        /// <summary>
        /// Click Begin Assessment button
        /// </summary>
        public static void ClickBeginAssessment()
        {
            Util.Click(EligibilityDetailsProp.beginAssessmentButton);
        }

        /// <summary>
        /// Get NSW Open Job Limit Value
        /// </summary>
        /// <param name="value">Value</param>
        public static string GetValueHwJobLimitValueTxt()
        {
            var hwJobLimitValue = Util.GetElement(EligibilityDetailsProp.HwJobLimitValueTxt);
            if (hwJobLimitValue != null)
            {
                return hwJobLimitValue.Text;
            }
            return string.Empty;
        }

        /// <summary>
        /// NSW Open Job Limit Value
        /// </summary>
        /// <param name="value">Value</param>
        public static void SetValueHwJobLimitValueTxt(string value)
        {
            Util.SetValue(EligibilityDetailsProp.HwJobLimitValueTxt, value);
        }

        /// <summary>
        /// NSW Open Job Limit Number
        /// </summary>
        /// <param name="value">Value</param>
        public static void SetValueHwJobLimitNumberTxt(string value)
        {
            Util.SetValue(EligibilityDetailsProp.HwJobLimitNumberTxt, value);
        }

        /// <summary>
        /// HBCF Insurance in other States
        /// </summary>
        /// <param name="value">Value</param>
        public static void SetValueHwInsuranceOtherStatesTxt(string value)
        {
            Util.SetValue(EligibilityDetailsProp.HwInsuranceOtherStatesTxt, value);
        }

        /// <summary>
        /// Non HBCF Insurance Income
        /// </summary>
        /// <param name="value">Value</param>
        public static void SetValueNonHomeInsuranceTxt(string value)
        {
            Util.SetValue(EligibilityDetailsProp.NonHomeInsuranceTxt, value);
        }

        /// <summary>
        /// New single dwelling construction
        /// </summary>
        /// <param name="value">Value</param>
        public static void SetValueFinancialLimits_txtC01(string value)
        {
            Util.SetValue(EligibilityDetailsProp.FinancialLimits_txtC01, value);
        }

        /// <summary>
        /// Get New single dwelling construction
        /// </summary>
        /// <param name="value">Value</param>
        public static string GetValueFinancialLimits_txtC01()
        {
            try
            {
                var element = Util.GetElement(EligibilityDetailsProp.FinancialLimits_txtC01);
                if (element != null)
                {
                    return element.GetProperty("value");
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Set checked checkbox Open Job Values checked? 
        /// <param name="isActive">True is check, false is uncheck</param>
        public static void SetCheckBoxOpenJobValueCheck(bool isActive)
        {
            Util.ClickingCheckBox(EligibilityDetailsProp.ChkOpenJobValue, isActive);
        }

        public static void ClickGenerateCertificateOfEligibilityButton()
        {
            Util.Click(EligibilityDetailsProp.GenerateCertificateOfEligibilityButton);
        }
    }
}
