using SICorp.Test.BuiderProperties;
using System.Collections.Generic;

namespace SICorp.Test.BuilderServices
{
    /// <summary>
    /// Initiate Review screen service
    /// </summary>
    public class InitiateReviewService
    {
        /// <summary>
        /// Change value of Financial year being assessed
        /// </summary>
        /// <param name="value"></param>
        public static void SetValueForFinancialYearDDL(string value)
        {
            Util.Select(InitiateReviewProp.FinancialYearDDL, value);
        }

        /// <summary>
        /// Change value of Assessment type
        /// </summary>
        /// <param name="value"></param>
        public static void SetValueForAssessmentTypeDLL(string value)
        {
            Util.Select(InitiateReviewProp.AssessmentTypeDLL, value);
        }

        /// <summary>
        /// Set value for comment textbox
        /// </summary>
        /// <param name="value"></param>
        public static void SetValueCommentTxt(string value)
        {
            Util.SetValue(InitiateReviewProp.InitialCommentTxt, value);
        }

        /// <summary>
        /// Set value for Scheduled Assessment Date
        /// </summary>
        /// <param name="value"></param>
        public static void SetValueScheduledAssessmentDate(string value)
        {
            Util.SetValue(InitiateReviewProp.ScheduledAssessmentDate, value);
        }

        /// <summary>
        /// Click Save Initiate Review button
        /// </summary>
        public static void ClickSaveButtonInitiateReview()
        {
            Util.Click(InitiateReviewProp.SaveButtonInitiateReview);
        }

        /// <summary>
        /// Check all of value exists in select option control
        /// </summary>
        /// <param name="lstValue"></param>
        /// <returns></returns>
        public static bool CheckExistsValueInSelectOption(List<string> lstValue)
        {
            int countExists = 0;
            var lstOptionRole = Util.GetOptionDDL(InitiateReviewProp.FinancialYearDDL);
            foreach (var iValue in lstValue)
            {
                for (int i = 0; i <= lstOptionRole.Count - 1; i++)
                {
                    if (lstOptionRole[i].Text == iValue)
                    {
                        countExists++;
                        break;
                    }
                }
            }

            if (countExists == lstValue.Count)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check all of value exists in select option control
        /// </summary>
        /// <param name="lstValue"></param>
        /// <returns></returns>
        public static bool CheckExists2019InFinancialYearDll()
        {
            var lstOptionRole = Util.GetOptionDDL(InitiateReviewProp.FinancialYearDDL);
            foreach (var iOpt in lstOptionRole)
            {
                if (iOpt.Text == FinancialYearDDL.Year2019)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
