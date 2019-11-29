using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SICorp.Test
{
    public class Util
    {
        public static ChromeDriver Driver { set; get; }
        const string MainMenulId = "menu-main";

        public static IWebElement WaitUntilElementExists(ChromeDriver driver, By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementExists(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }

        internal static object WaitUntilElementExists(object hBCFApprovedOpenJobLimitValueGTA, int v)
        {
            throw new NotImplementedException();
        }

        public static IWebElement WaitForMainMenu(ChromeDriver driver)
        {
            return WaitUntilElementExists(driver, By.Id(MainMenulId), 10);
        }

        public static void Click(By elementLocator, int timeout = 10)
        {
            var element = Util.WaitUntilElementExists(Driver, elementLocator, timeout);
            element.Click();
        }

        public static void SetValue(By elementLocator, string value)
        {
            var element = Util.WaitUntilElementExists(Driver, elementLocator, 10);
            element.Clear();
            element.SendKeys(value);
        }

        public static void SetValue(IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
        }

        public static void Select(By elementLocator, string value)
        {
            var element = Util.WaitUntilElementExists(Driver, elementLocator, 10);
            var dropDownElement = new SelectElement(element);
            dropDownElement.SelectByText(value);
        }

        /// <summary>
        /// Get value selected of dropdown
        /// </summary>
        /// <param name="elementLocator"></param>
        public static string GetValueSelected(By elementLocator)
        {
            // Get list option element
            List<IWebElement> lstOption = GetOptionDDL(elementLocator);
            if (lstOption != null)
            {
                foreach (var iOpt in lstOption)
                {
                    // Get value selected
                    if (iOpt.Selected)
                    {
                        return iOpt.Text;
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Get list of option in select
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static List<IWebElement> GetOptionDDL(By element)
        {
            var ddl = GetElement(element);
            List<IWebElement> lstOption = new List<IWebElement>(ddl.FindElements(By.TagName("option")));
            return lstOption;
        }

        public static bool IsChecked(By elementLocator)
        {
            var element = Util.WaitUntilElementExists(Driver, elementLocator, 10);
            return element.Selected;
        }

        public static bool DoesRowContainsValues(IWebElement tr, string[] values, bool row = true)
        {
            ICollection<IWebElement> tds = null;
            if (row)
            {
                tds = tr.FindElements(By.TagName("td"));
            }
            else
            {
                tds = tr.FindElements(By.TagName("th"));
            }
            if (tds.Count > 0)
            {
                //texts.any(x=>x.Contains(value)) instead of texts.Contains(value) in this case
                var texts = tds.Select(x => x.Text);
                foreach (var value in values)
                {
                    if (!texts.Any(x => x.Contains(value)))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public static void GoBack()
        {
            Driver.Navigate().Back();
        }

        public static void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }

        public static bool CheckColumnValueOfRow(IWebElement row, int columnIndex, string value)
        {
            var tds = row.FindElements(By.TagName("td"));
            if (columnIndex < tds.Count)
            {
                return tds[columnIndex].Text.Contains(value);
            }
            return false;
        }

        public static void ClickCoOrdinates(By elementLocator)
        {
            var element = Util.WaitUntilElementExists(Driver, elementLocator, 10);
            var x = element.Location.X;
            var y = element.Location.Y;

            var action = new Actions(Driver);
            //action.MoveByOffset(x, y).Click().Build().Perform();
            action.MoveToElement(element).MoveByOffset(1, 0).Click().Perform();
        }

        /// <summary>
        /// Get element by property
        /// </summary>
        /// <param name="elementLocator"></param>
        /// <returns></returns>
        public static IWebElement GetElement(By elementLocator)
        {
            return WaitUntilElementExists(Driver, elementLocator);
        }

        public static List<IWebElement> GetRowsOfTable(IWebElement table)
        {
            var rows = table.FindElements(By.TagName("tr"));
            if (rows.Count > 0)
            {
                return rows.ToList();
            }
            return new List<IWebElement>();
        }

        public static List<IWebElement> GetTdsOfRow(IWebElement row)
        {
            var tds = row.FindElements(By.TagName("td"));
            if (tds.Count > 0)
            {
                return tds.ToList();
            }
            return null;
        }

        public static void ClickIndexOfRow(IWebElement row, int index)
        {
            var tds = GetTdsOfRow(row);
            if (tds.Count > 0)
            {
                tds[index].Click();
            }
        }

        public static string GetTextIndexOfRow(IWebElement row, int index)
        {
            var tds = GetTdsOfRow(row);
            if (tds.Count > 0)
            {
                return tds[index].Text;
            }
            return string.Empty;
        }

        public static void SubmitElement(By elementLocator, int timeout = 10)
        {
            var element = Util.WaitUntilElementExists(Driver, elementLocator, timeout);
            element.Submit();
        }

        public static bool IsEnable(By elementLocator)
        {
            try
            {
                var element = Util.WaitUntilElementExists(Driver, elementLocator, 10);
                return element.Enabled;
            }
            catch
            {
                // Not found element and then set isnabled = false
                return false;
            }
        }

        public static bool IsExist(By elementLocator)
        {
            try
            {
                var element = Util.WaitUntilElementExists(Driver, elementLocator);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool CheckValueInput(By elementLocator, string value)
        {
            var input = Util.WaitUntilElementExists(Driver, elementLocator);
            return input.GetAttribute("value").Equals(value);
        }

        public static void WaitForDownloadToComplete(string filename)
        {
            while (true)
            {
                var defaultDownloadPath = Common.FilePath;
                var files = Directory.GetFiles(defaultDownloadPath, filename);

                if (files.Length > 0)
                    break;
            }

        }

        public static void WaitTillDialogClose(IWebElement element)
        {
            try
            {
                while (element.GetCssValue("display").Equals("block"))
                {

                }
            }
            catch
            {

            }

        }

        /// <summary>
        /// 
        /// </summary>
        public static void WaitTillBusyDialogClose()
        {
            while (CheckBusyDialogOpen())
            {

            }
        }

        public static bool CheckBusyDialogOpen()
        {
            try
            {
                var dialog = Util.WaitUntilElementExists(Driver, By.CssSelector("div[aria-describedby='masterBusyDialog']"), 10);
                var dialogZIndex = dialog.GetAttribute("z-index");
                var dialogDisplay = dialog.GetCssValue("display");
                if (dialogZIndex == "101" || dialogDisplay.Equals("block"))
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static List<IWebElement> GetRowOfTableWithFilter(IWebElement table, Func<IWebElement, bool> filter)
        {
            var rows = table.FindElements(By.TagName("tr")).Where(filter).ToList();
            return rows;
        }

        public static bool VerifyDialogOpen(By elementLocator)
        {
            var dialog = Util.WaitUntilElementExists(Driver, elementLocator);
            var displayValue = dialog.GetCssValue("display");
            var result = displayValue.Contains("block");
            return (dialog.GetCssValue("display").Contains("block"));
        }

        /// <summary>
        /// Set active or unactive checkbox
        /// </summary>
        /// <param name="element">Check box</param>
        /// <param name="isActive">Is active</param>
        public static void ClickingCheckBox(By element, bool isActive)
        {
            var principalActive = WaitUntilElementExists(Driver, element, 10);
            if (principalActive.Selected == !isActive)
                principalActive.Click();
        }

        /// <summary>
        /// Get list of elements by any properties: Id,  CssSelector, TagName, ...
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static List<IWebElement> GetElementsByProperty(By property)
        {
            var document = Util.WaitUntilElementExists(Driver, By.CssSelector("body"));
            return new List<IWebElement>(document.FindElements(property));
        }

    }

    /// <summary>
    /// Common class
    /// </summary>
    public class Common
    {
        public const string FilePath = @"C:\Users\sinh\Desktop\";
        public const string LicenceNumber = "262307C";
        public const string SalesRow = "5000000";
        public const string OpeningStock = "250000";
        public const string MsgTestFail = "PER information screen submitted to Distributor";
        public const string AssignedToDistributor = "PER information screen submitted to Distributor";
        public const string ActionRequiredByBorker = "ActionRequiredBy: Broker";
        public const string AssignedToInsurer = "PER information screen submitted to Insurer";
        public const string ActionRequiredByInSurer = "ActionRequiredBy: Insurer";
        public const string EmailSent = "Email reminder has been sent";
        public const string NO = "No";
        public const string Draft = "draft";
        public const string EditDraft = "edit draft";
        public const string ViewDraft = "view draft";
        public const string Email = "email";
        public const string TagNameButton = "button";
        public const string TagNamelink = "a";
        public const string TagNameInput = "input";
        public const string LblDelete = "Delete";
        public const string LblEdit = "Edit";
        public const string LblTitle = "title";
        public const string LblSend = "Send";
        public const string LblSave = "Save";
        public const string LblCancel = "Cancel";
        public const string LblClear = "Clear";
        public const string LblComment = "Testing automation";
        public const string LblNonBuildersANTA = "Non-Builders ANTA";
        public const string LblKeyEventLog = "Key Event Log";
        public const string LblDescriptionKeyEventLog = "Builder was updated with new Year End";
        public const string LblEventData = "Year End for {0} was changed by {1} from {2} to {3}";
        public const string LblEventData2 = "Year End for builder {0} was changed by {1} from {2} to {3}";
        public const string LblDelegationApproval = "Underwriter A delegation or higher required to finalise";
        public const string N_A = "N/A";
        public const string FormatDate = "dd-MMM-yyyy";
        public const string FormatDate2 = "dd/MM/yyyy";
        public const string CaptionConfirmABNChangeDialog = "Text in Confirm ABN Change Dialog";
        public const string TrackRecordMenu = "Track Record Menu";
        public const string AddConditionButton = "Add Condition Button";
        public const string AddNewAssessmentButton = "Add New Assessment Button";
        public const string GenerateEligibilityButton = "Generate Eligibility";
        public const string FinaliseAssessmentButton = "FinaliseAssessment";
        public const string OfferTermsButton = "Offer Terms";
        public const string HardCopyColumn = "Column Hardcopy";
        public const string StatusColumn = "Column Status";
        public const string AmountColumn = "Column Amount";
        public const string DateColumn = "Column Date";
        public const string ActiveColumn = "Column Active";
        public const string EAFinalisedColumn = "EA Finalised";
        public const string ABNNumber = "ABN Number";
        public const string NextPlanedReviewDate = "Next Planed Review Date";
        public const string Value1 = "500000";
        public const string Value2 = "5";
        public const string Value3 = "0";
        public const string Value4 = "200000";
        public const string Value5 = "2000000";
        public const string Value6 = "3000000";
        public const string LicensedBuilderEntityName = "Licensed Builder Entity Name";
        public const string BuilderABNNoSpaces = "Builder ABN (no spaces)";
        public const string ASICEntityName = "ASIC Entity Name";
        public const string BuilderPostcode = "Builder Postcode";
        public const string BuilderState = "Builder State";
        public const string Insurer = "Insurer";
        public const string FinancialYearBeingAssessed = "Financial year being assessed";
        public const string ListYearMonthJune = "JUN 2019 JUN 2018 JUN 2017 JUN 2016";
        public const string ListYearMonthJune_Sep = "SEP 2019 JUN 2019 JUN 2018 JUN 2017";
        public const string ListYearMonthJune_2017 = "JUN 2017 JUN 2016 JUN 2015 JUN 2014";
        public const string ListYearMonthDec = "DEC 2019 DEC 2018 DEC 2017 DEC 2016";
        public const string ListYearMonthDec_Sep = "SEP 2019 DEC 2018 DEC 2017 DEC 2016";
        public const string ListYearMonthDec_2017 = "DEC 2017 DEC 2016 DEC 2015 DEC 2014";
        public const string ListYearMonthDec_2018 = "DEC 2018 DEC 2017 DEC 2016 DEC 2015";
        public const string ListYearMonthMarch = "MAR 2019 MAR 2018 MAR 2017 MAR 2016";
        public const string ListYearMonthMarch_Sep = "SEP 2019 MAR 2019 MAR 2018 MAR 2017";
        public const string ListYearMonthMarch_2017 = "MAR 2017 MAR 2016 MAR 2015 MAR 2014";
        public const string ListYearMonthMarch_2018 = "MAR 2018 MAR 2017 MAR 2016 MAR 2015";
        public const string P_L = "P&L";
        public const string FileName1 = "doc1.txt";
        public const string FileName2 = "doc2.txt";
        public const string FileName3 = "doc3.txt";
        public const string Description = "Test upload file";
        public const string Cash = "Cash";
        public const string BEATAdjustedCalculatioins = "BEAT ADJUSTED CALCULATIONS";
        public const string EnterSearchCriteria = "Enter search criteria";
    }

    /// <summary>
    /// Member information
    /// </summary>
    public class MemberInfo
    {
        public const string Username = "CSCTestC";
        public const string Username3 = "CSCTestE";
        public const string Password = "xBA7SHg$5acY";
        public const string Username2 = "nguyenv";
        public const string Password2 = "Abc123456@";
    }

    /// <summary>
    /// Deeds of Indemnity type
    /// </summary>
    public class DeedIndemnityType
    {
        public const string JobSpecificDeed = "Job Specific Deed";
        public const string DeedOfIndemnity = "Deed of Indemnity";
        public const string DOIRespectFormerBusiness = "DOI in respect of former business";
        public const string GroupTradingAgreement = "Group Trading Agreement";
        public const string IrregularContractingDeed = "Irregular Contracting Deed";
    }

    /// <summary>
    /// Deeds of Indemnity value of control in form
    /// </summary>
    public class DeedIndemnityValue
    {
        public const string MaxValue = "65000";
        public const string PolicyNumber = "HBCF102030";
        public const string LotStreetNo = "321 Kent";
        public const string StreetName = "Street";
        public const string Suburb = "Sydney";
        public const string PostCode = "2000";
        public const string Name = "Lodestone Solutions";
        public const string ABNNumber = "12345678912";
        public const string Address = "17 Alberta Street";
    }

    /// <summary>
    /// Deeds of Indemnity state
    /// </summary>
    public class IndemnityState
    {
        public const string NewSouthWales = "New South Wales";
    }

    /// <summary>
    /// Select option value in condition dialog
    /// </summary>
    public class SelectConditionDialog
    {
        public const string DOIRequiredForEligibility = "Deed of Indemnity Required for Eligibility";
        public const string BCRPToApply750k = "BCRP to apply to all projects over $750K";
        public const string IntensiveMonitoring = "Intensive Monitoring - Biannual Reporting (6 monthly)";
        public const string WorkingCapitalMitigation = "Working Capital Mitigation";
    }

    /// <summary>
    /// Select option status in condition dialog
    /// </summary>
    public class SelectStatusConditionDialog
    {
        public const string NotMet = "Not Met";
        public const string Met = "Met";
    }

    /// <summary>
    /// Confirm ABN change dialog
    /// </summary>
    public class ConfirmABNChangeDialog
    {
        public const string MsgText = "The ABN for the deed will be different to the builder ABN";
    }

    /// <summary>
    /// Common message
    /// </summary>
    public class MessageCommon
    {
        public const string MsgSendMailSuccess = "The email has been successfully queued";
        public const string MsgDisabled = "{0} was disabled";
        public const string MsgEnabled = "{0} was enabled";
        public const string MsgNotMatch = "{0} was not matched";
        public const string MsgNotExist = "{0} is not exists";
        public const string MsgNotChecked = "{0} is not checked";
        public const string MsgNotFound = "File is not found in '{0}'";
        public const string MsgBlank = "{0} must be blank";
        public const string MsgNotRecord = "There is no data.";
    }

    /// <summary>
    /// Financial year being assessed
    /// </summary>
    public class FinancialYearDDL
    {
        public const string Jun_2019_YTD = "Jun-2019-YTD";
        public const string Sep_2019_YTD = "Sep-2019-YTD";
        public const string Year2019 = "2019";
        public const string Year2018 = "2018";
        public const string Year2017 = "2017";
        public const string Year2016 = "2016";
        public const string Year2015 = "2015";
    }

    public class AssessmentTypeDLL
    {
        /// <summary>
        /// New Eligibility Application (NEW)
        /// </summary>
        public const string New = "New Eligibility Application (NEW)";
    }

    /// <summary>
    /// Trading Structure in Track Record screen
    /// </summary>
    public class TradingStructure
    {
        /// <summary>
        /// Company
        /// </summary>
        public const string Company = "Company";

        /// <summary>
        /// Sole Trader
        /// </summary>
        public const string SoleTrader = "Sole Trader";
    }

    /// <summary>
    /// Entity's residential building licence held
    /// </summary>
    public class YearsTrading
    {
        /// <summary>
        /// > 10 years
        /// </summary>
        public const string Greater10Years = "> 10 years";

        /// <summary>
        /// Nil to 1 year
        /// </summary>
        public const string NilTo1Year = "Nil to 1 year";

        /// <summary>
        /// > 3 to 5 years
        /// </summary>
        public const string Greater3To5Year = "> 3 to 5 years";
    }

    /// <summary>
    /// Signs of Adverse History (consider builder size and trading history)
    /// </summary>
    public class AdverseHistory
    {
        /// <summary>
        /// Company
        /// </summary>
        public const string CleanHistory = "Clean history";
    }

    /// <summary>
    /// Current Trade Credit Position
    /// </summary>
    public class TradeCreditHistory
    {
        /// <summary>
        /// Clean history
        /// </summary>
        public const string CleanHistory = "Clean history";
    }

    /// <summary>
    /// Current Trade Credit Position
    /// </summary>
    public class DirectorsProfile
    {
        /// <summary>
        /// Clean history
        /// </summary>
        public const string CleanHistory = "Clean history";

        /// <summary>
        /// Marginal
        /// </summary>
        public const string Marginal = "Marginal";
    }

    /// <summary>
    /// Past business closures
    /// </summary>
    public class PastBusinessClosures
    {
        /// <summary>
        /// No previous business closures
        /// </summary>
        public const string NoPrevious = "No previous business closures";
    }

    /// <summary>
    /// Underwriter Assessment Outcome (provide notes below)
    /// </summary>
    public class UnderwriterAssessmentOutcome
    {
        /// <summary>
        /// Declined
        /// </summary>
        public const string Declined = "Declined";

        /// <summary>
        /// Approved Rating Z with no conditions
        /// </summary>
        public const string ApprovedRatingZNoConditions = "Approved Rating Z with no conditions";
    }

    /// <summary>
    /// Eligibility Assessment status in Overall Outcome screen
    /// </summary>
    public class EligibilityAssessmentStatus
    {
        /// <summary>
        /// Declined
        /// </summary>
        public const string Declined = "Declined";

        /// <summary>
        /// Terms Accepted
        /// </summary>
        public const string TermsAccepted = "Terms Accepted";

        /// <summary>
        /// Rolled Over
        /// </summary>
        public const string RolledOver = "Rolled Over";
    }

    /// <summary>
    /// Builder Detail screen
    /// </summary>
    public class BuilderDetailLabels
    {
        public const string LicensedBuilderEntityName = "Daljit Singh Sehra";
        public const string BuilderABN = "76951897360";
        public const string ASICEntityName = "SEHRA, DALJIT S";
        public const string BuilderPostcode = "3083";
        public const string BuilderState = "VIC";
        public const string Insurer = "CSC";
    }

    /// <summary>
    /// Year End Month dropdow in Buider Details screen
    /// </summary>
    public class YearEndMonth
    {
        public const string March = "March";
        public const string June = "June";
        public const string December = "December";
    }

    /// <summary>
    /// Section name in Financial Inputs screen
    /// </summary>
    public class SectionNameFinancialInputs
    {
        public const string Sales = "Sales";
        public const string OpeningStock = "Opening Stock";
        public const string Cash = "Cash";
        public const string CurrentAssets = "Current Assets";
    }

    /// <summary>
    /// Menu collapse sidebar assessments
    /// </summary>
    public class CollapseSidebarAssessments
    {
        public const string BeingAssessed = "Being Assessed";
    }

    /// <summary>
    /// List of ticket
    /// </summary>
    public enum TicketEnum
    {
        /// <summary>
        /// Ticket HWIT-4740
        /// </summary>
        T4740 = 1,
        /// <summary>
        /// Ticket HWIT-4741
        /// </summary>
        T4741 = 2,
        /// <summary>
        /// Ticket HWIT-4743
        /// </summary>
        T4743 = 3,
        /// <summary>
        /// Ticket HWIT-4757
        /// </summary>
        T4757 = 4,
        /// <summary>
        /// Ticket HWIT-4758
        /// </summary>
        T4758 = 5,
        /// <summary>
        /// Ticket HWIT-4759
        /// </summary>
        T4759 = 6,
        /// <summary>
        /// Ticket HWIT-4760
        /// </summary>
        T4760 = 7,
        /// <summary>
        /// Ticket HWIT-4761
        /// </summary>
        T4761 = 8,
        /// <summary>
        /// Ticket HWIT-4762
        /// </summary>
        T4762 = 9
    }
}
