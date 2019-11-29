using OpenQA.Selenium;
using SICorp.Test.BuiderProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SICorp.Test.BuilderServices
{
    /// <summary>
    /// Financial Inputs screen service
    /// </summary>
    public class FinancialInputsService
    {
        //public void SetValueSalesRow(string value)
        //{
        //    var lstTrTableRow = GetTableRows();
        //    foreach (var row in lstTrTableRow)
        //    {
        //        var lstTdElem = GetTdElement(row);
        //        var inputCol1 = lstTdElem[1].FindElement(By.TagName("input"));
        //        var inputCol1Id = inputCol1.GetAttribute("id");
        //        if (inputCol1Id.Contains("BaseSales"))
        //        {
        //            inputCol1.Clear();
        //            inputCol1.SendKeys(value);

        //            var inputCol2 = lstTdElem[3].FindElement(By.TagName("input"));
        //            inputCol2.Clear();
        //            inputCol2.SendKeys(value);

        //            var inputCol3 = lstTdElem[5].FindElement(By.TagName("input"));
        //            inputCol3.Clear();
        //            inputCol3.SendKeys(value);

        //            var inputCol4 = lstTdElem[7].FindElement(By.TagName("input"));
        //            inputCol4.Clear();
        //            inputCol4.SendKeys(value);

        //            break;
        //        }
        //    }
        //}

        ///// <summary>
        ///// Se value for first Base Sales textbox
        ///// </summary>
        ///// <param name="value"></param>
        //public void SetValueForFirstBaseSales(string value)
        //{
        //    var lstTrTableRow = GetTableRows();
        //    foreach (var row in lstTrTableRow)
        //    {
        //        var lstTdElem = GetTdElement(row);
        //        var inputCol1 = lstTdElem[1].FindElement(By.TagName("input"));
        //        var inputCol1Id = inputCol1.GetAttribute("id");
        //        if (inputCol1Id.Contains("BaseSales"))
        //        {
        //            inputCol1.Clear();
        //            inputCol1.SendKeys(value);
        //            break;
        //        }
        //    }
        //}

        /// <summary>
        /// Set value for first textbox by section name
        /// </summary>
        /// <param name="sectionName">Ex: Sales, Opening Stock, Cash ...</param>
        /// <param name="value">Value</param>
        public static void SetValueForFirstTextBoxBySectionName(string sectionName, string value
            , bool isSetValueForSecond = false, string value2 = "")
        {
            // Get list of rows
            var lstTrTableRow = Util.GetElementsByProperty(FinancialInputsProp.FinancialsTableTrTableRow);
            if (lstTrTableRow != null)
            {
                foreach (var row in lstTrTableRow)
                {
                    // Get list of Td by row
                    var lstTdElem = Util.GetTdsOfRow(row);
                    if (lstTdElem != null && lstTdElem.Count > 1)
                    {
                        if (lstTdElem[0].Text.ToUpper().Contains(sectionName.ToUpper()))
                        {
                            // Get first textbox
                            var inputCol1 = lstTdElem[1].FindElement(By.TagName(Common.TagNameInput));
                            if (inputCol1 != null)
                            {
                                inputCol1.Clear();
                                inputCol1.SendKeys(value);
                                Thread.Sleep(2000);

                                if(isSetValueForSecond)
                                {
                                    // Get second textbox
                                    var inputCol2 = lstTdElem[3].FindElement(By.TagName(Common.TagNameInput));
                                    if (inputCol2 != null)
                                    {
                                        inputCol2.Clear();
                                        inputCol2.SendKeys(value2);
                                        Thread.Sleep(2000);
                                    }
                                }
                                
                                return;
                            }
                        }
                    }
                }
            }
        }

        //public void SetValueOpeningStock(string value)
        //{
        //    var lstTrTableRow = GetTableRows();
        //    foreach (var row in lstTrTableRow)
        //    {
        //        var lstTdElem = GetTdElement(row);
        //        var inputCol1 = lstTdElem[1].FindElement(By.TagName("input"));
        //        var inputCol1Id = inputCol1.GetAttribute("id");
        //        if (inputCol1Id.Contains("OpeningStock"))
        //        {
        //            inputCol1.Clear();
        //            inputCol1.SendKeys(value);

        //            var inputCol2 = lstTdElem[3].FindElement(By.TagName("input"));
        //            inputCol2.Clear();
        //            inputCol2.SendKeys(value);

        //            var inputCol3 = lstTdElem[5].FindElement(By.TagName("input"));
        //            inputCol3.Clear();
        //            inputCol3.SendKeys(value);

        //            var inputCol4 = lstTdElem[7].FindElement(By.TagName("input"));
        //            inputCol4.Clear();
        //            inputCol4.SendKeys(value);

        //            break;
        //        }
        //    }
        //}

        ///// <summary>
        ///// Get button in row with SubHeaderRow class
        ///// </summary>
        ///// <param name="subHeaderRow">Default = Sales and = Other Income, Expenses, Tax Dividends, ...</param>
        ///// <returns></returns>
        //public IWebElement GetSaveButtonWithSubHeaderRow(string subHeaderRow = "Sales")
        //{
        //    var lstTrSubHeaderRow = GetSubHeaderRow();
        //    IWebElement salesSave = null;

        //    foreach (var trHeaderRow in lstTrSubHeaderRow)
        //    {
        //        var lstTdElem = GetTdElement(trHeaderRow);
        //        if (lstTdElem[0].Text == subHeaderRow)
        //        {
        //            salesSave = lstTdElem[1].FindElement(By.TagName("input"));
        //            break;
        //        }
        //    }

        //    return salesSave;
        //}

        //public void ClickSaleSaveButton()
        //{
        //    var button = GetSaveButtonWithSubHeaderRow();
        //    button.Click();
        //}

        ///// <summary>
        ///// Click Save button in Current Assets section
        ///// </summary>
        //public void ClickCurentAssetsSaveButton()
        //{
        //    var button = GetSaveButtonWithSubHeaderRow(Common.LblCurrentAssets);
        //    Actions action = new Actions(chromeDriver);
        //    action.MoveToElement(button).Click().Perform();
        //}

        /// <summary>
        /// Check exists value in block
        /// </summary>
        /// <param name="value">Value(Jun-2019 Jun-2018 Jun-2017 Jun-2016, ...)</param>
        /// <returns></returns>
        public static bool CheckExistsValueYearEndMonth(string value)
        {
            // Get list of row with ModuleHeader class
            var elementsTr = Util.GetElementsByProperty(FinancialInputsProp.FinancialsTableTrModuleHeader);
            foreach (var elem in elementsTr)
            {
                if (elem.Text.ToUpper().Contains(value.ToUpper()))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Click Save button by section name
        /// </summary>
        /// <param name="sectionName">Ex: Sales, Other Income, Current Assets ...</param>
        public static void ClickSaveButtonBySectionName(string sectionName)
        {
            // Get list of rows
            var lstTrTableRow = Util.GetElementsByProperty(FinancialInputsProp.FinancialsTableTrSubHeaderRow);
            if (lstTrTableRow != null)
            {
                foreach (var row in lstTrTableRow)
                {
                    // Get list of Td by row
                    var lstTdElem = Util.GetTdsOfRow(row);
                    if (lstTdElem != null && lstTdElem.Count > 1)
                    {
                        if (lstTdElem[0].Text.ToUpper().Contains(sectionName.ToUpper()))
                        {
                            // Get Save button
                            var inputCol1 = lstTdElem[1].FindElement(By.TagName(Common.TagNameInput));
                            if (inputCol1 != null)
                            {
                                inputCol1.Click();
                                return;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Check is load page
        /// </summary>
        /// <returns></returns>
        public static bool IsLoadPage()
        {
            try
            {
                // Get list of rows
                var lstTrTableRow = Util.GetElementsByProperty(FinancialInputsProp.FinancialsTableTrSubHeaderRow);
                if (lstTrTableRow != null)
                {
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Is exists Non Builder Financial
        /// </summary>
        /// <returns></returns>
        public static bool IsExistsNonBuilderFinancial()
        {
            var lstUlLi = Util.GetElementsByProperty(FinancialInputsProp.CollapseNonBuildersUlLi);
            if (lstUlLi != null && lstUlLi.Count > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Click Add New Non Builder Financial button
        /// </summary>
        public static void ClickAddNewNonBuilderFinancial()
        {
            Util.Click(FinancialInputsProp.AddNewNonBuilderButton);
        }

        /// <summary>
        /// Set value for Entity Name control in Create Non Builder Entity dialog
        /// </summary>
        /// <param name="value">Value</param>
        public static void SetValueForEntityNameInDialog(string value)
        {
            Util.SetValue(FinancialInputsProp.EntityNameInDialogTxt, value);
        }

        /// <summary>
        /// Set value for ABN control in Create Non Builder Entity dialog
        /// </summary>
        /// <param name="value">Value</param>
        public static void SetValueForABNInDialog(string value)
        {
            Util.SetValue(FinancialInputsProp.ABNInDialogTxt, value);
        }

        /// <summary>
        /// Click Save button in Create Non Builder Entity dialog
        /// </summary>
        public static void ClickSaveButtonCreateNonBuilderEntityDialog()
        {
            var lstButton = Util.GetElementsByProperty(FinancialInputsProp.CreateNonBuilderEntityDialogButtons);
            foreach (var iBtn in lstButton)
            {
                if (iBtn.Text.ToUpper().Contains(Common.LblSave.ToUpper()))
                {
                    iBtn.Click();
                    return;
                }
            }
        }

        /// <summary>
        /// Delete non builders by ABN Number
        /// </summary>
        /// <param name="abnNumber"></param>
        public static void DeleteNonBuildersByABNNumber(string abnNumber)
        {
            var lstUlLi = Util.GetElementsByProperty(FinancialInputsProp.CollapseNonBuildersUlLi);
            if (lstUlLi != null)
            {
                foreach (var iLi in lstUlLi)
                {
                    var isExistsABNNumber = false;
                    var lstSpan = iLi.FindElements(By.CssSelector("div > span"));
                    if (lstSpan != null)
                    {
                        foreach (var iSpan in lstSpan)
                        {
                            if (iSpan.Text.Trim().Equals(abnNumber))
                            {
                                isExistsABNNumber = true;
                                break;
                            }
                        }
                    }

                    // Delete
                    if (isExistsABNNumber)
                    {
                        var lstDiv = iLi.FindElements(By.CssSelector("div > a"));
                        if (lstDiv != null)
                        {
                            foreach (var iDiv in lstDiv)
                            {
                                if (iDiv.Text.ToUpper().Contains(Common.LblClear.ToUpper()))
                                {
                                    iDiv.Click();
                                    Thread.Sleep(1000);

                                    // Click Ok button in Confirmation dialog
                                    var okBtn = Util.GetElement(FinancialInputsProp.OkButtonInConfirmationDialogNonBuilders);
                                    okBtn.Click();
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
