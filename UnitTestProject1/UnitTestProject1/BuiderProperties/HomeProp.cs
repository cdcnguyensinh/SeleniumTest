using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICorp.Test.BuiderProperties
{
    /// <summary>
    /// Home screen properties
    /// </summary>
    public class HomeProp
    {
        /// <summary>
        /// Grid data
        /// </summary>
        public static By TaskTable = By.Id("MainContent_eatHomeControl_homeResultsGridView");

        /// <summary>
        /// Search result label
        /// </summary>
        public static By SearchResultLabel = By.Id("MainContent_eatHomeControl_homeResultsGridView");

    }
}
