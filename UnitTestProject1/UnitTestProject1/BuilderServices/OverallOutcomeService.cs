using OpenQA.Selenium;
using SICorp.Test.BuiderProperties;
using System.Collections.Generic;
using System.Threading;

namespace SICorp.Test.BuilderServices
{
    /// <summary>
    /// Overall Outcome screen service
    /// </summary>
    public class OverallOutcomeService
    {
        /// <summary>
        /// Set value for HBCF Approved Open Job Limit Value
        /// </summary>
        /// <param name="limitValue">Value</param>
        public static void SetHBCApprovedOpenJobLimitValueForGTA(string limitValue)
        {
            IWebElement openJobLimitValue = Util.GetElement(OverallOutcomeProp.HBCFApprovedOpenJobLimitValueGTA);
            if (IsAssessmentGTA())
            {
                openJobLimitValue = Util.GetElement(OverallOutcomeProp.HBCFApprovedOpenJobLimitValueGTA);
            }
            else
            {
                openJobLimitValue = Util.GetElement(OverallOutcomeProp.HBCFApprovedOpenJobLimitValue);
            }

            if (openJobLimitValue.Enabled)
            {
                openJobLimitValue.Clear();
                openJobLimitValue.SendKeys(limitValue);
                Thread.Sleep(2000);
            }
        }

        /// <summary>
        /// Set value for HBCF Approved Open Job Limit Number
        /// </summary>
        /// <param name="limitNumber">Value</param>
        public static void SetHBCApprovedOpenJobLimitNumberForGTA(string limitNumber)
        {
            IWebElement openJobLimitNumber = null;
            if (IsAssessmentGTA())
            {
                openJobLimitNumber = Util.GetElement(OverallOutcomeProp.HBCFApprovedOpenJobLimitNumberGTA);
            }
            else
            {
                openJobLimitNumber = Util.GetElement(OverallOutcomeProp.HBCFApprovedOpenJobLimitNumber);
            }
            if (openJobLimitNumber.Enabled)
            {
                openJobLimitNumber.Clear();
                openJobLimitNumber.SendKeys(limitNumber);
                Thread.Sleep(2000);
            }
        }

        /// <summary>
        /// Click Save Outcome Details button in OutCome Details section
        /// </summary>
        public static void ClickSaveOutcomeDetailsButton()
        {
            if (IsAssessmentGTA())
            {
                Util.Click(OverallOutcomeProp.SaveOutcomeDetailsButtonGTA);
            }
            else
            {
                Util.Click(OverallOutcomeProp.SaveOutcomeDetailsButton);
            }
        }

        /// <summary>
        /// Update all records that is not met to met
        /// </summary>
        public static void UpdateToMetIfIsNotMet()
        {
            IWebElement table = null;
            if (IsAssessmentGTA())
            {
                table = Util.GetElement(OverallOutcomeProp.TableGroupListDeleteConditionsButtonGTA);
            }
            else
            {
                table = Util.GetElement(OverallOutcomeProp.TableGroupListDeleteConditionsButton);
            }
            if (table != null && table.Displayed)
            {
                var rows = Util.GetRowsOfTable(table);
                if (rows != null)
                {
                    foreach (var itemRow in rows)
                    {
                        var isNotMet = false;
                        var lstTd = Util.GetTdsOfRow(itemRow);
                        if (lstTd != null && lstTd.Count > 1)
                        {
                            // Check exists 'Not Met'
                            var lstSpan = lstTd[0].FindElements(By.TagName("span"));
                            if (lstSpan != null)
                            {
                                foreach (var iSpan in lstSpan)
                                {
                                    if (iSpan.Text.ToUpper().Contains(SelectStatusConditionDialog.NotMet.ToUpper()))
                                    {
                                        isNotMet = true;
                                        break;
                                    }
                                }
                            }
                            if (isNotMet)
                            {
                                // Update from 'Not Met' to 'Met' because if Assessement has Not Met then can not Finaclised
                                var lstInputImgs = lstTd[1].FindElements(By.TagName(Common.TagNameInput));
                                if (lstInputImgs != null)
                                {
                                    lstInputImgs[0].Click();
                                    Thread.Sleep(2000);

                                    // Update value in Condition dialog
                                    SetValueCondition(Common.Value2);

                                    // Update condition status in Condition dialog
                                    SetValueConditionStatus(SelectStatusConditionDialog.Met);

                                    // Save
                                    ClickConditionDialogSaveButton();
                                    // Util.WaitTillBusyDialogClose();
                                    Thread.Sleep(10000);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Click Save button in Condition dialog
        /// </summary>
        public static void ClickConditionDialogSaveButton()
        {
            Util.Click(OverallOutcomeProp.SaveButtonConditionDialog, 10);
        }

        /// <summary>
        /// Delete all conditions
        /// </summary>
        public static void DeleteConditions()
        {
            var lstTr = Util.GetElementsByProperty(OverallOutcomeProp.ElementToDeleteCondition);
            if (lstTr != null)
            {
                Builder.BuilderPage builderPage = new Builder.BuilderPage(Util.Driver);
                foreach (var iTr in lstTr)
                {
                    // Get list of td elements
                    var lstTd = Util.GetTdsOfRow(iTr);
                    if (lstTd != null && lstTd.Count > 1)
                    {
                        var lstInputImgs = lstTd[1].FindElements(By.TagName(Common.TagNameInput));
                        if (lstInputImgs != null)
                        {
                            if (lstInputImgs.Count > 1)
                            {
                                lstInputImgs[1].Click();
                                builderPage.WaitTillBusyDialogClose();
                                Thread.Sleep(3000);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Set value condition dialog
        /// </summary>
        /// <param name="value">Value</param>
        public static void SetValueCondition(string value)
        {
            IWebElement valueControl = null;
            if (IsAssessmentGTA())
            {
                valueControl = Util.GetElement(OverallOutcomeProp.SetGroupValueConditionDialog);
                if (valueControl.Displayed && valueControl.Enabled)
                {
                    Util.SetValue(OverallOutcomeProp.SetGroupValueConditionDialog, value);
                }
            }
            else // Non GTA
            {
                valueControl = Util.GetElement(OverallOutcomeProp.SetValueConditionDialog);
                if (valueControl.Displayed && valueControl.Enabled)
                {
                    Util.SetValue(OverallOutcomeProp.SetValueConditionDialog, value);
                }
                
            }
        }

        /// <summary>
        /// Set value of status condition dialog
        /// </summary>
        /// <param name="value">Value</param>
        public static void SetValueConditionStatus(string value)
        {
            if (IsAssessmentGTA())
            {
                Util.Select(OverallOutcomeProp.SelectGroupStatusConditionDialog, value);
            }
            else // Non GTA
            {
                Util.Select(OverallOutcomeProp.SelectStatusConditionDialogDdl, value);
            }
        }

        /// <summary>
        /// Is Assessment GTA?
        /// </summary>
        /// <returns></returns>
        public static bool IsAssessmentGTA()
        {
            try
            {
                var panelGTA = Util.GetElement(OverallOutcomeProp.PanelGroup);
                return panelGTA.Displayed;
            }
            catch
            {
                // Non GTA
                return false;
            }
        }

        /// <summary>
        /// Set value Underwriter Assessment Outcome (provide notes below)
        /// </summary>
        /// <param name="value">Value</param>
        public static void SetValueForUnderWriterAssessmentOutcomeDropDown(string value)
        {
            if (IsAssessmentGTA())
            {
                Util.Select(OverallOutcomeProp.UnderwriterAssessmentOutcomeDropDownGTA, value);
            }
            else
            {
                Util.Select(OverallOutcomeProp.UnderwriterAssessmentOutcomeDropDown, value);
            }
        }

        /// <summary>
        /// Check box Delegation Approval Checkbox
        /// </summary>
        public static void ClickDelegationApprovalCheckbox()
        {
            if (IsAssessmentGTA())
            {
                Util.ClickingCheckBox(OverallOutcomeProp.DelegationApprovalCheckboxGTA, true);
            }
            else
            {
                Util.ClickingCheckBox(OverallOutcomeProp.DelegationApprovalCheckbox, true);
            }
        }

        /// <summary>
        /// Offer terms button
        /// </summary>
        public static bool IsEnabledOfferTermsButton()
        {
            if (IsAssessmentGTA())
            {
                return Util.IsEnable(OverallOutcomeProp.OfferTermsButtonGTA);
            }
            else
            {
                return Util.IsEnable(OverallOutcomeProp.OfferTermsButton);
            }
        }

        /// <summary>
        /// Click Offer Terms button for GTA
        /// </summary>
        public static void ClickButtonOfferTermsForGTA()
        {
            Util.Click(OverallOutcomeProp.OfferTermsButtonGTA);
        }

        /// <summary>
        /// Click Offer Terms button
        /// </summary>
        public static void ClickButtonOfferTerms()
        {
            Util.Click(OverallOutcomeProp.OfferTermsButton);
        }

        /// <summary>
        /// Click Send button in Offer Terms dialog
        /// </summary>
        public static void ClickSendOfferTermsButton()
        {
            var lstDialog = Util.GetElementsByProperty(OverallOutcomeProp.SendOfferTermsButton);
            if (lstDialog != null)
            {
                Builder.BuilderPage builderPage = new Builder.BuilderPage(Util.Driver);
                foreach (var itemDialog in lstDialog)
                {
                    if (itemDialog.Text.ToUpper().Contains(Common.LblSend.ToUpper()))
                    {
                        itemDialog.Click();
                        builderPage.WaitTillBusyDialogClose();
                        Thread.Sleep(3000);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Click OK button after send mail in Ofter Terms dialog
        /// </summary>
        public static void ClickOkOfferTermsEmailDialog()
        {
            var dialog = Util.GetElementsByProperty(OverallOutcomeProp.ValidationErrorDialog);
            if (dialog != null)
            {
                foreach (var iDia in dialog)
                {
                    if (iDia.Displayed && iDia.Enabled)
                    {
                        // Find OK button
                        var lstButton = iDia.FindElements(By.TagName(Common.TagNameButton));
                        if (lstButton != null)
                        {
                            foreach (var iBtn in lstButton)
                            {
                                if (iBtn.Text.ToUpper().Contains("OK"))
                                {
                                    iBtn.Click();
                                    Util.WaitTillBusyDialogClose();
                                    Thread.Sleep(5000);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Change value of Eligibility Assessment status
        /// </summary>
        /// <param name="value">Value</param>
        public static void SetValueEligibilityAssessmentStatusDll(string value)
        {
            if (IsAssessmentGTA())
            {
                Util.Select(OverallOutcomeProp.EligibilityAssessmentStatusDllGTA, value);
            }
            else
            {
                Util.Select(OverallOutcomeProp.EligibilityAssessmentStatusDll, value);
            }
        }

        /// <summary>
        /// Check is enabled Eligibility Assessment status dropdown
        /// </summary>
        /// <returns></returns>
        public static bool IsEnabledEligibilityAssessmentStatusDll()
        {
            try
            {
                if (IsAssessmentGTA())
                {
                    return Util.IsEnable(OverallOutcomeProp.EligibilityAssessmentStatusDllGTA);
                }
                else
                {
                    return Util.IsEnable(OverallOutcomeProp.EligibilityAssessmentStatusDll);
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Check is enabled Save Outcome Details button
        /// </summary>
        /// <returns></returns>
        public static bool IsEnabledSaveOutcomeDetails()
        {
            try
            {
                if (IsAssessmentGTA())
                {
                    return Util.IsEnable(OverallOutcomeProp.SaveOutcomeDetailsButtonGTA);
                }
                else
                {
                    return Util.IsEnable(OverallOutcomeProp.SaveOutcomeDetailsButton);
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Click Save Outcome Details button if Assessment is GTA
        /// </summary>
        public static void ClickSaveGroupOutcomeDetailsButtonForGTA()
        {
            Util.Click(OverallOutcomeProp.SaveGroupOutcomeDetailsButtonGTA);
        }

        /// <summary>
        /// Check is enabled Finalise Assessment button
        /// </summary>
        /// <returns></returns>
        public static bool IsEnabledFinaliseAssessmentButton()
        {
            try
            {
                if (IsAssessmentGTA())
                {
                    return Util.IsEnable(OverallOutcomeProp.FinaliseAssessmentButtonGTA);
                }
                else
                {
                    return Util.IsEnable(OverallOutcomeProp.FinaliseAssessmentButton);
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Click Finalise Assessment button
        /// </summary>
        public static void ClickFinaliseAssessmentButton()
        {
            if (IsAssessmentGTA())
            {
                Util.Click(OverallOutcomeProp.FinaliseAssessmentButtonGTA);
            }
            else
            {
                Util.Click(OverallOutcomeProp.FinaliseAssessmentButton);
            }
        }

        /// <summary>
        /// Check is enabled Generate Eligibility button
        /// </summary>
        /// <returns></returns>
        public static bool IsEnabledGenerateEligibilityButton()
        {
            try
            {
                if (IsAssessmentGTA())
                {
                    return Util.IsEnable(OverallOutcomeProp.GenerateEligibilityButtonGTA);
                }
                else
                {
                    return Util.IsEnable(OverallOutcomeProp.GenerateEligibilityButton);
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Cick Generate Eligibility button
        /// </summary>
        /// <returns></returns>
        public static void ClickGenerateEligibilityButton()
        {
            if (IsAssessmentGTA())
            {
                Util.Click(OverallOutcomeProp.GenerateEligibilityButtonGTA);
            }
            else
            {
                Util.Click(OverallOutcomeProp.GenerateEligibilityButton);
            }
        }

        /// <summary>
        /// Set value Date Terms Offered
        /// </summary>
        /// <param name="value">Value</param>
        public static void SetValueDateTermsOffered(string value)
        {
            List<IWebElement> lstInput = null;
            if (IsAssessmentGTA())
            {
                lstInput = Util.GetElementsByProperty(OverallOutcomeProp.DateTermsOfferedGTA);
            }
            else
            {
                lstInput = Util.GetElementsByProperty(OverallOutcomeProp.DateTermsOffered);
            }
            if (lstInput != null && lstInput.Count > 0)
            {
                var dateTerms = lstInput[0];
                dateTerms.Clear();
                dateTerms.SendKeys(value);
                Thread.Sleep(2000);
            }
        }

        /// <summary>
        /// Is enabled Date Terms Offered
        /// </summary>
        public static bool IsEnabledDateTermsOffered()
        {
            if (IsAssessmentGTA())
            {
                return Util.IsEnable(OverallOutcomeProp.DateTermsOfferedGTA);
            }
            else
            {
                return Util.IsEnable(OverallOutcomeProp.DateTermsOffered);
            }
        }

        /// <summary>
        /// Check exists text
        /// </summary>
        /// <param name="delegationApproval">text need compare</param>
        /// <returns></returns>
        public static bool CheckDelegationApprovalText(string delegationApproval)
        {
            var delegationApprovalTextElement = Util.GetElement(OverallOutcomeProp.DelegationApprovalLabel);
            var delegationApprovalText = delegationApprovalTextElement.Text;
            return delegationApprovalText.Contains(delegationApproval);
        }

        /// <summary>
        /// Verify the " Next Planned Eligibility Review Date" is blank.
        /// </summary>
        /// <returns></returns>
        public static bool IsBlankNextPlanedReviewDate()
        {
            try
            {
                if (string.IsNullOrEmpty(Util.GetElement(OverallOutcomeProp.NextPlanedReviewDateTxt).Text))
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return true;
            }
        }

        /// <summary>
        /// Checked Are there any conditions required as part of the terms to be offered?
        /// </summary>
        public static void ClickAreThereConditionCheckbox()
        {
            Util.ClickingCheckBox(OverallOutcomeProp.AreThereConditionsCheckbox, true);
        }

        /// <summary>
        /// Click 'Add Condition' button
        /// </summary>
        public static void ClickAddConditionButton()
        {
            if (IsAssessmentGTA())
            {
                Util.Click(OverallOutcomeProp.BtnGroupAddConditions);
            }
            else
            {
                Util.Click(OverallOutcomeProp.BtnAddConditions);
            }
        }

        /// <summary>
        /// Check validate error dialog open
        /// </summary>
        /// <param name="isClickClose">Is click Close button</param>
        /// <returns></returns>
        public static bool CheckValidationErrorDialogOpen(bool isClickClose = false)
        {
            var dialog = Util.GetElementsByProperty(OverallOutcomeProp.ValidationErrorDialog);
            if (dialog != null)
            {
                foreach (var iDia in dialog)
                {
                    if (iDia.Displayed && iDia.GetCssValue("display").Equals("block"))
                    {
                        if (isClickClose)
                        {
                            // close dialog
                        }
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Get value: Name of analyst textbox
        /// </summary>
        /// <returns></returns>
        public static string GetNameOfAnalyst()
        {
            var element = Util.GetElement(OverallOutcomeProp.NameOfAnalyst);
            return element.GetProperty("value");
        }

        /// <summary>
        /// Get value: Name of analyst escalated to textbox
        /// </summary>
        /// <returns></returns>
        public static string GetNameOfAnalystEscalatedTo()
        {
            var element = Util.GetElement(OverallOutcomeProp.NameOfAnalystEscalatedTo);
            return element.GetProperty("value");
        }

        /// <summary>
        /// Navigate to Group Overall Outcome screen
        /// </summary>
        public static void NavigateGroupOverallOutcomeScreen()
        {
            var groupOver = Util.GetElement(OverallOutcomeProp.GroupOverallOutcomeButton);
            if (groupOver != null && groupOver.Enabled)
            {
                groupOver.Click();
                Util.WaitTillBusyDialogClose();
            }
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Check enabled Group Overall Outcome screen
        /// </summary>
        public static bool IsEnabledGroupOverallOutcomeScreen()
        {
            return Util.IsEnable(OverallOutcomeProp.GroupOverallOutcomeButton);
        }

    }
}
