using SICorp.Test.BuiderProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICorp.Test.BuilderServices
{
    /// <summary>
    /// Home screen services
    /// </summary>
    public class HomeService
    {
        /// <summary>
        /// Click 1 row to navigate to Intiate Review screen
        /// </summary>
        /// <param name="licence">Licence number</param>
        public static void ClickTaskWithLicence(string licence)
        {
            var table = Util.GetElement(HomeProp.TaskTable);
            if (table == null) return;
            var rows = Util.GetRowsOfTable(table);
            if (rows == null) return;
            bool isExistsLicence = false;
            for (int i = 1; i < rows.Count; i++)
            {
                var tds = Util.GetTdsOfRow(rows[i]);
                if (tds[2].Text.Contains(licence))
                {
                    rows[i].Click();
                    isExistsLicence = true;
                    return;
                }
            }
            if (!isExistsLicence && rows.Count > 1)
            {
                rows[1].Click();
            }
        }

        /// <summary>
        /// Check is has data in grid
        /// </summary>
        /// <returns></returns>
        public static bool IsHasData()
        {
            try
            {
                var searchResult = Util.GetElement(HomeProp.SearchResultLabel);
                if (searchResult == null) return false;
                if (searchResult.Text.ToUpper().Contains(Common.EnterSearchCriteria.ToUpper()))
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
