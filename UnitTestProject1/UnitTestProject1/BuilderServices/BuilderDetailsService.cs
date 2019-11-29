using OpenQA.Selenium.Chrome;
using SICorp.Test.BuiderProperties;

namespace SICorp.Test.BuilderServices
{
    /// <summary>
    /// Builder Details screen services
    /// </summary>
    public class BuilderDetailsService
    {
        /// <summary>
        /// Get value for Year End Month dropdown
        /// </summary>
        /// <param name="value"></param>
        public static void SetValueForYearEndMonthDll(string value)
        {
            Util.Select(BuilderDetailProp.YearEndMonthDll, value);
        }

        /// <summary>
        /// Click Builder Detail Save button
        /// </summary>
        public static void ClickBuiderDetailSaveButton()
        {
            Util.Click(BuilderDetailProp.SaveBuilderDetailButton);
        }

        /// <summary>
        /// Get builder name
        /// </summary>
        /// <returns></returns>
        public static string GetBuilderName()
        {
            var element = Util.GetElement(BuilderDetailProp.BuilderNameTxt);
            if (element != null)
            {
                return element.GetProperty("value");
            }

            return string.Empty;
        }

        /// <summary>
        /// Get value selected of Year End Month dropdown
        /// </summary>
        /// <returns></returns>
        public static string GetValueSelectedYearEndMonth()
        {
            return Util.GetValueSelected(BuilderDetailProp.YearEndMonthDll);
        }

        /// <summary>
        /// Check is match data
        /// </summary>
        /// <param name="description"></param>
        /// <param name="createBy"></param>
        /// <param name="eventData"></param>
        /// <returns></returns>
        public static bool IsExistsDataInKeyEventLog(string description, string createBy, string eventData)
        {
            var table = Util.GetElement(BuilderDetailProp.KeyEventLogTable);
            if (table != null)
            {
                // Get list of rows
                var lstTr = Util.GetRowsOfTable(table);
                if (lstTr != null)
                {
                    foreach (var iTr in lstTr)
                    {
                        // Get list of columns
                        var lstTd = Util.GetTdsOfRow(iTr);
                        if (lstTd != null && lstTd.Count > 2)
                        {
                            if (lstTd[0].Text.ToUpper().Contains(description.ToUpper()) && lstTd[1].Text.ToUpper().Contains(createBy.ToUpper()) && lstTd[2].Text.ToUpper().Contains(eventData.ToUpper()))
                            {
                                return true;
                            }
                        }
                    }
                }
                
            }
            return false;
        }

        /// <summary>
        /// Verify value of Finalised column is 'NO'
        /// </summary>
        /// <returns></returns>
        public static bool VerifyAssessmentTableHasNoFinalised()
        {
            var table = Util.GetElement(BuilderDetailProp.AssessmentsTableBuilderDetail);
            var row = Util.GetRowsOfTable(table);
            for (int i = 1; i < row.Count; i++)
            {
                //keep parsing till counter footer
                try
                {
                    var tds = Util.GetTdsOfRow(row[i]);
                    if (tds[11].Text.Contains("No"))
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Click edit link with finalised column is 'NO'
        /// </summary>
        public static void ClickEditLinkAssessmentBuilderDetail()
        {
            var table = Util.GetElement(BuilderDetailProp.AssessmentsTableBuilderDetail);
            var row = Util.GetRowsOfTable(table);
            var tds = Util.GetTdsOfRow(row[1]);
            tds[0].Click();
        }

    }
}
