using SICorp.Test.BuiderProperties;
using OpenQA.Selenium;
using System.Threading;

namespace SICorp.Test.BuilderServices
{
    /// <summary>
    /// Search screen service
    /// </summary>
    public class SearchService
    {
        public static void ClickEditLinkAssessment()
        {
            var table = Util.GetElement(SearchProp.assessmentTable);
            if (table != null)
            {
                // Get first row
                var row = Util.GetRowsOfTable(table);
                if (row != null && row.Count > 1)
                {
                    var lstTd = Util.GetTdsOfRow(row[1]);
                    if (lstTd != null && lstTd.Count > 0)
                    {
                        // Get a element
                        var link = lstTd[0].FindElement(By.CssSelector(Common.TagNamelink));
                        if (link != null)
                        {
                            link.Click();
                            Thread.Sleep(5000);
                        }
                    }
                }
            }
        }
    }
}
