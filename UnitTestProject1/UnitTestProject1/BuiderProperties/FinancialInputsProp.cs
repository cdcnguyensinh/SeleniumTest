using OpenQA.Selenium;

namespace SICorp.Test.BuiderProperties
{
    /// <summary>
    /// Financial Inputs screen properties
    /// </summary>
    public class FinancialInputsProp
    {
        /// <summary>
        /// Control ID use to get text JUN 2019		JUN 2018		JUN 2017		JUN 2016
        /// </summary>
        public static By FinancialsTableTrModuleHeader = By.CssSelector("#MainContent_eatFinancialInputsControl_financialsTable > tbody > tr.moduleHeader");

        /// <summary>
        /// Use to get all rows with 'TableRow' class name
        /// </summary>
        public static By FinancialsTableTrTableRow = By.CssSelector("#MainContent_eatFinancialInputsControl_financialsTable > tbody > tr.TableRow");

        /// <summary>
        /// Use to get all rows with 'SubHeaderRow' class name
        /// </summary>
        public static By FinancialsTableTrSubHeaderRow = By.CssSelector("#MainContent_eatFinancialInputsControl_financialsTable > tbody > tr.SubHeaderRow");

        /// <summary>
        /// Collapse Non Builders Ul control
        /// </summary>
        public static By CollapseNonBuildersUlLi = By.CssSelector("ul#collapseNonBuilders > li");

        /// <summary>
        /// Add New Non-Builder Financial button
        /// </summary>
        public static By AddNewNonBuilderButton = By.CssSelector("#group-panel > div > div > button");

        /// <summary>
        /// Entity Name control in Create Non Builder Entity dialog
        /// </summary>
        public static By EntityNameInDialogTxt = By.CssSelector("#validationSummaryContent > div:nth-child(1) > div > input[type='text']");

        /// <summary>
        /// ABN control in Create Non Builder Entity dialog
        /// </summary>
        public static By ABNInDialogTxt = By.CssSelector("#validationSummaryContent > div:nth-child(2) > div > input[type='text']");

        /// <summary>
        /// 2 button Save and Cancel in Create Non Builder Entity dialog
        /// </summary>
        public static By CreateNonBuilderEntityDialogButtons = By.CssSelector("div.ui-dialog-default > div > div > button");

        /// <summary>
        /// OK button in Confirmation dialog when delete Non Builders Financial
        /// </summary>
        public static By OkButtonInConfirmationDialogNonBuilders = By.CssSelector("div.ui-dialog-default.ui-widget.ui-widget-content.ui-corner-all.ui-dialog-buttons.modal-container.center-align-view-port.modal-container-active > div > div > button");
    }
}
