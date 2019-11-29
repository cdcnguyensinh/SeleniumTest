using SICorp.Test.BuiderProperties;

namespace SICorp.Test.BuilderServices
{
    /// <summary>
    /// Financial Outputs screen
    /// </summary>
    public class FinancialOutputsService
    {
        /// <summary>
        /// Get value of Non Builders ANTA
        /// </summary>
        public static string GetValueOfNonBuildersANTALabel()
        {
            // Get all rows with 'AssesmentOutcome' class name
            var trElements = Util.GetElementsByProperty(FinancialOutputsProp.TableBEATAdjustedCalculations);
            if (trElements != null)
            {
                foreach (var iTr in trElements)
                {
                    var lstTd = Util.GetTdsOfRow(iTr);
                    if (lstTd != null && lstTd.Count > 1)
                    {
                        for (int i = 0; i < lstTd.Count; i++)
                        {
                            if (lstTd[1].Text.ToUpper().Contains(Common.LblNonBuildersANTA.ToUpper()))
                            {
                                return lstTd[2].Text;
                            }
                        }
                    }

                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Check exists value in block
        /// </summary>
        /// <param name="value">Value(Jun-2019 Jun-2018 Jun-2017 Jun-2016, ...)</param>
        /// <returns></returns>
        public static bool CheckExistsValueYearEndMonth(string value)
        {
            // Get list of row with ModuleHeader class
            var elementsTr = Util.GetElementsByProperty(FinancialOutputsProp.TableRowModuleHeader);
            foreach (var elem in elementsTr)
            {
                if (elem.Text.ToUpper().Contains(value.ToUpper()))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
