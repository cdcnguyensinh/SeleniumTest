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
    /// Task Administration screen service
    /// </summary>
    public class TaskAdministrationService
    {
        /// <summary>
        /// Click menu filter
        /// </summary>
        /// <param name="menuName">Menu name</param>
        public static void ClickMenuFilter(string menuName)
        {
            var lstMenu = Util.GetElementsByProperty(TaskAdministrationProp.CollapseSideBar);
            if (lstMenu != null)
            {
                foreach (var iMenu in lstMenu)
                {
                    if (iMenu.Text.ToUpper().Contains(menuName.ToUpper()))
                    {
                        iMenu.Click();
                        Thread.Sleep(3000);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Click menu filter
        /// </summary>
        /// <param name="menuName">Menu name</param>
        public static void ClickEligibilityAssessmentIdFirst()
        {
            Util.Click(TaskAdministrationProp.AssessmentIdLink);
        }

    }
}
