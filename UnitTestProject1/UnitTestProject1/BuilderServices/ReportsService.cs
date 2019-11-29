using SICorp.Test.BuiderProperties;
using System.Threading;

namespace SICorp.Test.BuilderServices
{
    /// <summary>
    /// Report menu screen service
    /// </summary>
    public class ReportsService
    {
        /// <summary>
        /// Check exists value in Tranding Structure select option control
        /// </summary>
        /// <param name="value">Value</param>
        public static void SortRows(string value)
        {
            var eleme = Util.GetElementsByProperty(ReportsProp.EligibilityAssessmentType);
            if (eleme != null)
            {
                foreach (var itd in eleme)
                {
                    if (itd.Text.ToUpper().Contains(value.ToUpper()))
                    {
                        itd.Click();
                        Thread.Sleep(5000);
                        break;
                    }
                }
            }
        }

    }
}
