using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICorp.Test.BuiderProperties
{
    /// <summary>
    /// Task Administration screen properties
    /// </summary>
    public class TaskAdministrationProp
    {
        /// <summary>
        /// Menu collapse sidebar assessments
        /// </summary>
        public static By CollapseSideBar = By.CssSelector("#collapseSideBarAssessments > ul > li > a");

        /// <summary>
        /// Link of Eligibility Assessment Id in grid
        /// </summary>
        public static By AssessmentIdLink = By.CssSelector("#MainContent_gvMyTask_DXDataRow0 > td > a");
    }
}
