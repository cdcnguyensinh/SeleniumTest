//using AutoIt;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace SICorp.Test.Builder
{
    public class BuilderPage : BasePage
    {
        By Body = By.CssSelector("body");
        By UiDialog = By.CssSelector("#Form1 > div.ui-dialog");
        By step1Title = By.Id("MainContent_eatSearchControlNew_divStep1");
        By entityNameInput = By.Id("MainContent_eatSearchControlNew_txtBuilderEntityName");
        By searchButton = By.Id("MainContent_eatSearchControlNew_searchByBuilders");
        By builderTable = By.CssSelector("#MainContent_eatSearchControlNew_searchResultsGridView > tbody");
        By licensedBuilderEntityNameInput = By.Id("txtEaBuilderEntityName");

        By BuilderCommentTable = By.CssSelector("#MainContent_eatBuilderInformationControl_gvBuilderComment > tbody");
        By tradingNameInput = By.Id("MainContent_eatSearchControlNew_txtBuilderTradingName");
        //By EntityNameInput = By.Id("MainContent_eatSearchControlNew_txtBuilderEntityName");
        By visibleToIANewCheckbox = By.Id("MainContent_eatBuilderInformationControl_cbCommentIASecurityNew");
        By visibleToIAEditCheckbox = By.Id("MainContent_eatBuilderInformationControl_cbCommentIASecurityEdit");
        By builderUploadFileButton = By.XPath("//*[@id=\"MainContent_eatBuilderInformationControl_EligibilityWrapper\"]/input[2]");
        By popupDuplicateUploadFile = By.XPath("/html/body/div[3]");
        By fileUploadTable = By.XPath("//*[@id=\"builderfiles-table-body\"]");
        By AddNewPricipalButton = By.Id("MainContent_eatBuilderInformationControl_btnNewPrincipal");
        By InitiateReviewMenuButton = By.Id("ButtonDetails");
        By SiraBuilderDetailMenuButton = By.Id("ButtonGlsDetails");


        By addNewInterstateLicenceButton = By.Id("MainContent_eatBuilderInformationControl_btnNewOtherLicence");
        By licenseNoInput = By.Id("MainContent_eatBuilderInformationControl_txtAddNewOtherLicence");
        By licenseStateDDL = By.Id("MainContent_eatBuilderInformationControl_ddlAddNewOtherState");
        By licenseNameInput = By.Id("MainContent_eatBuilderInformationControl_txtAddNewNameOnOtherLicence");
        By licenseCategoryInput = By.Id("MainContent_eatBuilderInformationControl_txtAddNewOtherLicenceCategory");
        By licenseIssueDateInput = By.Id("MainContent_eatBuilderInformationControl_bdpLiteAddOtherNewIssueDate_TextBox");
        By licenseExpiryDateInput = By.Id("MainContent_eatBuilderInformationControl_bdpLiteAddOtherNewExpiryDate_TextBox");
        By licenseStatusDDL = By.Id("MainContent_eatBuilderInformationControl_ddlAddNewOtherStatus");
        By licenseSaveButton = By.Id("MainContent_eatBuilderInformationControl_imgBtnUpdateOtherLicence");
        By licenseListTable = By.XPath("//*[@id=\"MainContent_eatBuilderInformationControl_gvBuilderEntityOtherLicenceDetails\"]/tbody");

        By pricingHistoryButton = By.XPath("//*[@id=\"collapsBuilderPremiumPricingDetails\"]/div/table/tbody/tr/td[2]/button");
        By pricingPopupHistory = By.XPath("/html/body/div[7]");
        By pricingThreadTableHistory = By.Id("historyTable");

        By builderLincenceName = By.Id("MainContent_eatSearchControlNew_txtBuilderLicence");
        By assessmentTable = By.CssSelector("#MainContent_eatSearchControlNew_searchResultsGridViewAssessment > tbody");
        By scheduledAssessmentDate = By.Id("MainContent_eatInitiateReviewControl_dtpkScheduledAssessmentDate_TextBox");
        By commentAssessment = By.Id("MainContent_eatInitiateReviewControl_txtInitialComment");
        By saveAssessmentButton = By.Id("MainContent_eatInitiateReviewControl_btnSave");

        By tickOngoingAuditorAppointmentCheckbox = By.Id("MainContent_eatInitiateReviewControl_OngoingAuditorAppointment");
        By financialStatementsOfTheBuilderUploadButton = By.XPath("//*[@id=\"collapseAttachments\"]/div[1]/div[3]/div/form/input");
        By popupDescriptionInput = By.Id("popupdescription");
        By continueButton = By.CssSelector("body > div:nth-child(24) > div.ui-dialog-buttonpane.ui-widget-content.ui-helper-clearfix > div > button:nth-child(1)");
        By gridFinStatements = By.XPath("//*[@id=\"MainContent_eatInitiateReviewControl_GridFinStatements\"]/tbody");
        /// <summary>
        /// 
        /// </summary>
        By GridFinStatements = By.Id("MainContent_eatInitiateReviewControl_GridFinStatements");
        //By sensitiveButton = By.XPath("//*[@id=\"MainContent_eatInitiateReviewControl_reviewattachmentSensitiveDiv\"]/div[2]/div/form/input");
        By SensitiveUploadButton = By.CssSelector("#MainContent_eatInitiateReviewControl_reviewattachmentSensitiveDiv > div.ajax-upload-dragdrop > div.ajax-file-upload > form > input");
        //By sensitiveTable = By.XPath("//*[@id=\"MainContent_eatInitiateReviewControl_GridSensitive\"]/tbody");

        /// <summary>
        /// Table name after upload file successfull in Initiate Review screen
        /// </summary>
        By SensitiveTable = By.Id("MainContent_eatInitiateReviewControl_GridSensitive");

        By commentAssessmentTextArea = By.Id("MainContent_eatInitiateReviewControl_txtNewComments");
        By commentAssessmentButton = By.XPath("/html/body/div[1]/div[11]/div/button[1]");
        By commentAssessmentTable = By.CssSelector("#MainContent_eatInitiateReviewControl_GridComments > tbody");

        By distributorLabel = By.Id("MainContent_eatInitiateReviewControl_divActionRequiredByBroker");
        By hbcfLabel = By.Id("MainContent_eatInitiateReviewControl_divActionRequiredByhbcf");

        By submitTheAssessmentToTheInsuranceAgentButton = By.Id("MainContent_eatInitiateReviewControl_btnSubmitToInsurer");
        By insuranceAgentLabel = By.Id("MainContent_eatInitiateReviewControl_divActionRequiredByIA");
        
        By swimmingPoolsInput = By.Id("MainContent_eatFinancialLimits_txtC05");

        By alterOpenJobLimitValueInput = By.Id("MainContent_eatFinancialLimits_txtHwJobLimitValue");

        By assumedNSWHBCFTurnoverInput = By.Id("MainContent_eatFinancialLimits_txtHwInsuranceTurnoverLimit");
        
        By ButtonFinancialInputsMenu = By.Id("ButtonFinancialInputs");

        /// <summary>
        /// Financial Outputs menu button
        /// </summary>
        By ButtonFinancialOutputsMenu = By.Id("ButtonFinancialOutputs");
        By FinancialsTable = By.CssSelector("#MainContent_eatFinancialInputsControl_financialsTable > tbody");

        /// <summary>
        /// Control ID use to get text JUN 2019		JUN 2018		JUN 2017		JUN 2016
        /// </summary>
        By FinancialsTableTrModuleHeader = By.CssSelector("#MainContent_eatFinancialInputsControl_financialsTable > tbody >tr.moduleHeader");

        By UnderwriterAssessmentOutcomeDropDown = By.CssSelector("#MainContent_eatOverallOutcomeControl_tblManualOverride > tbody > tr:nth-child(1) > td:nth-child(2) >select");

        /// <summary>
        /// Underwriter Assessment Outcome (provide notes below) dropdown for GTA
        /// </summary>
        By UnderwriterAssessmentOutcomeDropDownGTA = By.Id("MainContent_eatGroupOverallOutcomeControl_mo_r1c2_ddl");

        By ReferredToDropDown = By.CssSelector("#MainContent_eatOverallOutcomeControl_tblManualOverride > tbody > tr:nth-child(2) > td:nth-child(2) >select:nth-child(2)");

        By SubmitToHBCFButton = By.CssSelector("#MainContent_eatOverallOutcomeControl_tblManualOverride >tbody >tr:nth-child(3) > td:nth-child(1) >input");
        By RequestDelegationApprovalButton = By.CssSelector("#MainContent_eatOverallOutcomeControl_tblManualOverride >tbody >tr:nth-child(3) > td:nth-child(2) >input");
        By KeyEventLogMenuButton = By.Id("btnKeyEventLogs");
        By BuilderLicenseKeyEventsLog = By.Id("MainContent_txtBuilderLicence");
        By KeyEventLogsTable = By.Id("MainContent_xgridViewSearchResultsGridView_DXMainTable");
        By SearchButtonKeyEventLogs = By.Id("MainContent_btnSearchByLogs");
        By DelegationApprovalText = By.CssSelector("#MainContent_eatOverallOutcomeControl_tblManualOverride > tbody > tr:nth-child(5) > td:nth-child(1)");
        By RequestNewBuilderMenu = By.Id("btnRequestNewBuilder");
        By EntityNameInputRequestNewBuilder = By.Id("MainContent_eatRequestBuilderControl_txtBuilderEntityName");
        By BuilderABNACNInputRequestNewBuilder = By.Id("MainContent_eatRequestBuilderControl_txtAbnAcn");
        By AddFileButtonRequestNewBuilder = By.CssSelector("#MainContent_eatRequestBuilderControl_TableCell26 > input.buttons");
        By ButtonRequestNewBuilder = By.Id("MainContent_eatRequestBuilderControl_searchByBuilders");
        By TableRequestNewBuilder = By.CssSelector("#MainContent_eatRequestBuilderControl_gvRequestNewFilter > tbody");

        By CreateNewBuilderButtonMenu = By.Id("btnCreateNewBuilder");
        By InputLicenseDialogNewBuilder = By.Id("txtLicenseNumber");
        By SearchButtonLicenseDialogNewBuilder = By.CssSelector("body > div:nth-child(21) > div.ui-dialog-buttonpane.ui-widget-content.ui-helper-clearfix > div > button:nth-child(1)");
        By LookUpLicenseDialog = By.CssSelector("div[aria-describedby='divLookupLicenseNumberDialog']");
        By ImageLookUpButton = By.Id("imgLookupAbn");
        By InputLookUpAbn = By.Id("txtLookupAbn");
        By SearchButtonAbnLookUp = By.CssSelector("body > div:nth-child(33) > div.ui-dialog-buttonpane.ui-widget-content.ui-helper-clearfix > div > button:nth-child(1)");
        By AbnLookUpDialog = By.CssSelector("body > div:nth-child(33)");
        By BuilderEntityTypeSelect = By.Id("MainContent_eatBuilderInformationControl_ddlEaBuilderEntityType");
        By PrimaryBuilderSegmentOnApplicationSelect = By.Id("MainContent_eatBuilderInformationControl_ddlPrimaryBuilderSegment");

        By SaveBuilderDetailButton = By.Id("btnSaveBuilderDetails");
        By ValidationErrorLisenceLookUp = By.Id("divErrorLookupLicenseNumber");

        By ButtonAddNewDoiBuilderDetail = By.CssSelector("#doiTableContainer > div:nth-child(1) > button");
        By DoiTypeSelect = By.CssSelector("select[name='DoiTypeID']");
        By MaxAmoutInput = By.CssSelector("input[name='MaxAmount']");
        By PolicyNumberInput = By.CssSelector("input[name='PolicyNumber']");
        By NewDeedOfIndemnity = By.CssSelector("#doiTableContainer > div:nth-child(3)");
        By LotStreetNo = By.CssSelector("input[name='SiteLotStreetNo']");
        By StreetName = By.CssSelector("input[name='SiteStreetName']");
        By Suburb = By.CssSelector("input[name='SiteSuburb']");
        By PostCode = By.CssSelector("input[name='SitePostCode']");
        By AddIndemnifierButton = By.CssSelector("button[class='buttons small']");
        By CompanyRadioButton = By.CssSelector("input[value='Company']");
        By NameInput = By.CssSelector("input[name='Name']");
        By AbnInput = By.CssSelector("input[name='ABN']");
        By AddressInput = By.CssSelector("input[name='Address']");
        By StateSelect = By.CssSelector("select[name='State']");
        By PostCodeInput = By.CssSelector("input[name='PostCode']");
        By ButtonOkAddIndemnifier = By.CssSelector("#doiTableContainer > div:nth-child(2) > div.ui-dialog-buttonpane.ui-widget-content.ui-helper-clearfix > div > button:nth-child(1)");
        By SaveDeedOfIndemnityDialog = By.CssSelector("#Form1 > div.ui-dialog.ui-widget.ui-widget-content.ui-corner-all.ui-front.ui-draggable");
        By ButtonOkNewDeedOfIndemnity = By.CssSelector("#doiTableContainer > div:nth-child(3) > div.ui-dialog-buttonpane.ui-widget-content.ui-helper-clearfix > div > button:nth-child(1)");
        By DoiTBody = By.CssSelector("#doiTableContainer > div:nth-child(1) > table > tbody");
        By RenderingEmailTemplateDialog = By.CssSelector("#Form1 > div.ui-dialog.ui-widget.ui-widget-content.ui-corner-all.ui-front.ui-draggable");
        By EmailContent = By.CssSelector("body");
        By QueueingEmailDialog = By.CssSelector("#Form1 > div:nth-child(27)");
        By SendButton = By.CssSelector("#Form1 > div.ui-dialog.ui-widget.ui-widget-content.ui-corner-all.ui-front.ui-dialog-buttons.ui-draggable.ui-resizable > div.ui-dialog-buttonpane.ui-widget-content.ui-helper-clearfix > div > button:nth-child(1) > span");
        By EmailSuccessDialog = By.CssSelector("#Form1 > div:nth-child(29)");
        By EmailSuccessDialog2 = By.CssSelector("#Form1 > div:nth-child(28)");
        By EmailSuccessDialogOverallOutcome = By.CssSelector("#Form1 > div:nth-child(32)");
        By UploadSignedPdfDialog = By.CssSelector("#Form1 > div.ui-dialog.ui-widget.ui-widget-content.ui-corner-all.ui-front.ui-draggable");
        By AddBusinessTradingNameButton = By.Id("MainContent_eatBuilderInformationControl_btnAddNewTradingName");
        By BusinessTradingNameInput = By.Id("MainContent_eatBuilderInformationControl_txtTradingNameNew");
        By ButtonInsertTradingName = By.Id("MainContent_eatBuilderInformationControl_btnUpdateTradingNameNew");
        By TextBusinessTradingName = By.Id("MainContent_eatBuilderInformationControl_gvTradingNames_lblTradingName_0");
        By TextNoTradingName = By.Id("MainContent_eatBuilderInformationControl_TableCell52");
        By DeleteBusinessTradingNameButton = By.Id("MainContent_eatBuilderInformationControl_gvTradingNames_btnGridBuilderLicenceDelete_0");
        By TbodyTradingNameTable = By.CssSelector("#MainContent_eatBuilderInformationControl_gvTradingNames > tbody");
        By ConditionDropDown = By.CssSelector("#conditionModalDialog > div:nth-child(2) > div:nth-child(2) > select");

        By UploadFinancialStatementButton = By.CssSelector("#MainContent_eatInitiateReviewControl_AttDivFinancialStatements > div.ajax-upload-dragdrop > div > form");

        By EntityNameInput = By.Id("MainContent_eatHomeControl_txtBuilderEntityName");
        By ManagementGroupMenu = By.Id("btnManageGroups");

        By HomeButtonMenu = By.Id("ButtonHome");
        By TaskAdministratorMenu = By.Id("btnMyTask");
        By BuilderAndEligibilitiesMenu = By.Id("btnBNE");
        By ChartMenu = By.Id("btnGraphs");
        By ReportMenu = By.Id("btnReports");

        By EligibilitiesReportTable = By.CssSelector("#MainContent_gvEligibilityRelatedReports > tbody");
        By FinancialReportTbody = By.CssSelector("#MainContent_gvFinancialRelatedReport > tbody");
        By AddConditionButton = By.CssSelector("#collapseAcceptorAdjustOutcome > table > tbody > tr:nth-child(12) > td:nth-child(1) > input");
        By AddConditionButton2 = By.CssSelector("#collapseAcceptorAdjustOutcome > table > tbody > tr:nth-child(10) > td:nth-child(1) > input");
        By AddConditionButton3 = By.CssSelector("#collapseAcceptorAdjustOutcome > table > tbody > tr:nth-child(11) > td:nth-child(1) > input");

        By ValidationErrorDialogOverallOutcome = By.CssSelector("body > div:nth-child(48)");
        By CopyPreviousAttachmentTermsAccepted = By.Id("MainContent_eatInitiateReviewControl_btnCopyPreviousAttachements");
        By ConditionDialogSaveButton = By.Id("conditionDialogSaveButton");
        By ConditionStatusSelect = By.CssSelector("#conditionModalDialog > div:nth-child(2) > div:nth-child(2) > div > select");
        By ValueConditionStatus = By.Id("MainContent_eatOverallOutcomeControl_txtValueCondition");

        By SaveBuilderCommunication = By.Id("MainContent_eatOverallOutcomeControl_btnSaveReviewNotes");
        By PrintEaReport = By.Id("MainContent_eatOverallOutcomeControl_btnPrintAssessmentBuilderOfferingTerms");
        By WorkflowManagementMenu = By.Id("btnWorkFlowManagement");
        By CloseDialogLicenceLookUp = By.CssSelector("body > div:nth-child(21) > div.ui-dialog-titlebar.ui-widget-header.ui-corner-all.ui-helper-clearfix.ui-draggable-handle > button");
        By ButtonPersonalStatementMenu = By.Id("ButtonPersonalStats");
        By StatementOfPersonalAssesstsAndLiabilitiesTable = By.Id("MainContent_eatPersonalStatsControl_gridviewPrincipals");

        By RestrictionToggle = By.Id("restrictionsToggle");
        By RestrictionToggleButton = By.CssSelector("#MainContent_EligibilityControl1_restrictionsTr > td:nth-child(2) > div > label");
        By RestrictedJobValue = By.Id("MainContent_EligibilityControl1_txtRestrictedJobValue");
        By RestrictedJobNumer = By.Id("MainContent_EligibilityControl1_txtRestrictedJobNumber");
        By EligibilitySaveChanges = By.Id("MainContent_EligibilityControl1_btnSaveChanges");

        By EventDropDown = By.Id("MainContent_ddlKeyLogEvent");

        By EaTermsAcceptedNotFinalisedTable = By.Id("MainContent_ReportGrid_DXMainTable");
        By InactiveEligibilityUtilisedJobsReportTable = By.Id("MainContent_ReportGrid_DXMainTable");

        By LicenceNumber = By.Id("MainContent_eatHomeControl_txtBuilderLicence");
        By ButtonSearchHome = By.Id("MainContent_eatHomeControl_searchByBuilders");

        By BuilderPremiumPricing = By.CssSelector("#divBuilderPremiumPricingDetails > span:nth-child(3) > div > div");

        By SchedDateColumn = By.Id("MainContent_ReportGrid_col7");
        By FirstRowReport = By.Id("MainContent_ReportGrid_DXDataRow0");

        By FinancialOutputMenu = By.Id("ButtonFinancialOutputs");
        By MaincontentPanelOverallOutcome = By.Id("MainContent_pnlGroupAssessment");
        By GroupBuilder = By.CssSelector("#group-panel > div > div:nth-child(1) > div > div:nth-child(1) > ul > li");

        By AddNewComment = By.Id("MainContent_eatInitiateReviewControl_btnAddNewComment");
        By DoiTypeId = By.CssSelector("select[name='DoiTypeID']");
        By MaxAmount = By.CssSelector("input[name='MaxAmount']");
        By AddIndemnifierButtonOverallOutcome = By.CssSelector("button[class='buttons small']");
        By CompanyRadio = By.CssSelector("input[value='Company']");
        By NameInputOverall = By.CssSelector("input[name='Name']");
        By ABN = By.CssSelector("input[name='ABN']");
        By Address = By.CssSelector("input[name='Address']");
        By PostCodeOverall = By.CssSelector("input[name='PostCode']");
        By OkAddIndemnifier = By.CssSelector("#doiTableContainer > div:nth-child(2) > div.ui-dialog-buttonpane.ui-widget-content.ui-helper-clearfix > div > button:nth-child(1) > span");
        By OkNewDeed = By.CssSelector("#doiTableContainer > div:nth-child(3) > div.ui-dialog-buttonpane.ui-widget-content.ui-helper-clearfix > div > button:nth-child(1) > span");
        By AssessmentReportTable = By.Id("MainContent_gvWorkflowReport");

        /// <summary>
        /// Panel group assessment
        /// If assessment is belong to GTA then show else not show
        /// </summary>
        By PanelGroup = By.Id("MainContent_pnlGroupAssessment");
        
        #region Properties of Builder Details screen

        /// <summary>
        /// Year end month select option control
        /// </summary>
        By YearEndMonth = By.Id("MainContent_eatBuilderInformationControl_ddlYearEndMonth");

        #endregion

        #region Properties of Assessment section in Search screen

        /// <summary>
        /// Add New Assessment button
        /// </summary>
        By AddNewAssessmentButton = By.Id("MainContent_eatSearchControlNew_btnNewAssessment");

        #endregion

        #region Properties in Initiate Review screen

        /// <summary>
        /// Financial year being assessed
        /// </summary>
        By FinancialYearDDL = By.Id("MainContent_eatInitiateReviewControl_ddlFinancialYear");

        /// <summary>
        /// Assessment Type
        /// </summary>
        By AssessmentTypeDLL = By.Id("MainContent_eatInitiateReviewControl_ddlAssessmentType");

        /// <summary>
        /// Comment
        /// </summary>
        By InitialCommentTxt = By.Id("MainContent_eatInitiateReviewControl_txtInitialComment");

        /// <summary>
        /// Save button
        /// </summary>
        By SaveButtonInitiateReview = By.Id("MainContent_eatInitiateReviewControl_btnSave");

        #endregion

        #region Properties of Eligibility Details screen

        /// <summary>
        /// NSW Open Job Limit Value
        /// </summary>
        By HwJobLimitValueTxt = By.Id("MainContent_eatFinancialLimits_txtHwJobLimitValue");

        /// <summary>
        /// NSW Open Job Limit Number
        /// </summary>
        By HwJobLimitNumberTxt = By.Id("MainContent_eatFinancialLimits_txtHwOpenJobLimitNumber");

        /// <summary>
        /// HBCF Insurance in other States
        /// </summary>
        By HwInsuranceOtherStatesTxt = By.Id("MainContent_eatFinancialLimits_txtHwInsuranceOtherStates");

        /// <summary>
        /// Non HBCF Insurance Income
        /// </summary>
        By NonHomeInsuranceTxt = By.Id("MainContent_eatFinancialLimits_txtNonHomeInsurance");

        /// <summary>
        /// New single dwelling construction
        /// </summary>
        By FinancialLimits_txtC01 = By.Id("MainContent_eatFinancialLimits_txtC01");

        /// <summary>
        /// Open Job Values checked? 
        /// </summary>
        By ChkOpenJobValue = By.Id("MainContent_EligibilityControl1_chkApprovedTurnoverChecked");

        /// <summary>
        /// Generate PDF certificate of eligibility
        /// </summary>
        By GenerateCertificateOfEligibilityButton = By.Id("MainContent_EligibilityControl1_btnGenerateCertificateOfEligibility");

        #endregion

        #region Properties dialog confirm ABN change

        /// <summary>
        /// Confirm ABN change dialog
        /// </summary>
        By DialogConfirmABNChange = By.CssSelector("#Form1 > div.ui-dialog.ui-widget.ui-widget-content.ui-corner-all.ui-front.ui-draggable.ui-dialog-buttons");

        /// <summary>
        /// Ok button of confirm ABN change dialog
        /// </summary>
        By OkButtonConfirmABNChange = By.XPath("//*[@id=\"Form1\"]/div[7]/div[3]/div/button[1]");

        #endregion

        #region Properties Deed of indemnity

        /// <summary>
        /// The first row of table deed of indemnity
        /// </summary>
        By TableDOI = By.CssSelector("#doiTableContainer > div:nth-child(1) > table > tbody > tr:nth-child(1)");

        /// <summary>
        /// Cancel button in Deed of Indemnity dialog
        /// </summary>
        By ButtonCancelDOIDialog = By.CssSelector("#doiTableContainer > div:nth-child(3) > div.ui-dialog-buttonpane.ui-widget-content.ui-helper-clearfix > div > button:nth-child(2) > span");

        /// <summary>
        /// Email Success dialog ??? TODO can delete
        /// </summary>
        By EmailSuccessDialogDOI = By.XPath("//*[@id=\"Form1\"]/div[8]");

        /// <summary>
        /// OK button in Email Success dialog
        /// </summary>
        By ButtonOKInEmailSuccessDialog = By.CssSelector("#Form1 > div:nth-child(33) > div.ui-dialog-buttonpane.ui-widget-content.ui-helper-clearfix > div > button");

        #endregion

        #region Properties of Accept or adjust outcome
        /// <summary>
        /// Check box 'Are there any conditions required as part of the terms to be offered?' for non GTA
        /// </summary>
        By ChkAnyConditionsRequiredPartOfTheTerms = By.Id("MainContent_eatOverallOutcomeControl_mo_r23c1_chk");

        /// <summary>
        /// Check box 'Are there any conditions required as part of the terms to be offered?' for GTA
        /// </summary>
        By ChkGroupAnyConditionsRequiredPartOfTheTerms = By.Id("MainContent_eatGroupOverallOutcomeControl_mo_r23c1_chk");

        /// <summary>
        /// Add condition button for non GTA
        /// </summary>
        By BtnAddConditions = By.Id("MainContent_eatOverallOutcomeControl_btnNewCondition");

        /// <summary>
        /// Add condition button for GTA
        /// </summary>
        By BtnGroupAddConditions = By.Id("MainContent_eatGroupOverallOutcomeControl_btnNewCondition");

        /// <summary>
        /// Select option in Condition dialog non GTA
        /// </summary>
        By SetValueConditionInConditionDialog = By.Id("MainContent_eatOverallOutcomeControl_ddlConditionsDialog");

        /// <summary>
        /// Select option in Condition dialog GTA
        /// </summary>
        By SetGroupValueConditionInConditionDialog = By.Id("MainContent_eatGroupOverallOutcomeControl_ddlConditionsDialog");

        /// <summary>
        /// Select option in Condition dialog non GTA
        /// </summary>
        By SelectStatusConditionDialogDdl = By.Id("MainContent_eatOverallOutcomeControl_ddlConditionsStatusDialog");

        /// <summary>
        /// Select option in Condition dialog GTA
        /// </summary>
        By SelectGroupStatusConditionDialog = By.Id("MainContent_eatGroupOverallOutcomeControl_ddlConditionsStatusDialog");

        /// <summary>
        /// Save button in Condition dialog 
        /// </summary>
        By SaveButtonConditionDialog = By.Id("conditionDialogSaveButton");

        /// <summary>
        /// Delete condition button for non GTA
        /// </summary>
        By TableGroupListDeleteConditionsButton = By.Id("MainContent_eatGroupOverallOutcomeControl_gridviewRecurringConditions");

        /// <summary>
        /// Delete condition button
        /// </summary>
        By TableListDeleteConditionsButton = By.Id("MainContent_eatOverallOutcomeControl_gridviewRecurringConditions");

        /// <summary>
        /// Navigate to Group Overal Outcome screen
        /// </summary>
        By GroupOverallOutcomeButton = By.CssSelector("div.gta-group-panel > div > ul > li");

        #endregion

        #region Properties of Financial Inputs creen

        /// <summary>
        /// Add New Non-Builder Financial button
        /// </summary>
        By AddNewNonBuilderButton = By.CssSelector("#group-panel > div > div > button");

        /// <summary>
        /// Entity Name control in Create Non Builder Entity dialog
        /// </summary>
        By EntityNameInDialogTxt = By.CssSelector("#validationSummaryContent > div:nth-child(1) > div > input[type='text']");

        /// <summary>
        /// ABN control in Create Non Builder Entity dialog
        /// </summary>
        By ABNInDialogTxt = By.CssSelector("#validationSummaryContent > div:nth-child(2) > div > input[type='text']");

        /// <summary>
        /// 2 button Save and Cancel in Create Non Builder Entity dialog
        /// </summary>
        By CreateNonBuilderEntityDialogButtons = By.CssSelector("div.ui-dialog-default > div > div > button");

        /// <summary>
        /// Get all rows with TableRow class
        /// </summary>
        By FinancialiInputsTableRow = By.CssSelector("#MainContent_eatFinancialInputsControl_financialsTable > tbody > tr.TableRow");

        /// <summary>
        /// Collapse Non Builders Ul control
        /// </summary>
        By CollapseNonBuildersUlLi = By.CssSelector("ul#collapseNonBuilders > li");

        #endregion

        #region Task Administration
        By BeingAssessed = By.CssSelector("#collapseSideBarAssessments > ul > li:nth-child(3) > a");
        By TaskTableTaskAdministrator = By.Id("MainContent_gvMyTask_DXMainTable");

        #endregion

        #region CreateNewBuilder
        By DistriButorSelect = By.Id("MainContent_eatBuilderInformationControl_ddlBroker");
        #endregion

        #region BuilderDetails
        By KeyEventLogs = By.Id("MainContent_eatBuilderInformationControl_KeyEventLogGridView");
        By IncludeClosedJobs = By.Id("ClosedJobsToggle");
        By RedistributeGroupLimitsButton = By.CssSelector("#divBuilderJobDetails > div > button");
        By JobLimitRedisTable = By.Id("jobLimitRedistTableBody");
        By SavingJobLimitsDialog = By.CssSelector("div[aria-labelledby='ui-id-16']");
        By SavingJobLimitsDialog2 = By.CssSelector("div[aria-labelledby='ui-id-18']");
        By ButtonOKGtaRedis = By.CssSelector("#Form1 > div.ui-dialog.ui-widget.ui-widget-content.ui-corner-all.ui-front.ui-dialog-buttons.ui-draggable > div.ui-dialog-buttonpane.ui-widget-content.ui-helper-clearfix > div > button:nth-child(1)");
        By AssessmentsTableBuilderDetail = By.Id("MainContent_eatBuilderInformationControl_searchResultsGridViewAssessment");
        By EligibilitiesTable = By.Id("MainContent_eatBuilderInformationControl_EligibilitiesGridView");
        By AddNewCommentButton = By.Id("MainContent_eatBuilderInformationControl_btnNewBuilderComment");
        By BuilderCommentTextbox = By.Id("MainContent_eatBuilderInformationControl_txtBuilderComment");
        By SaveCommentBuilderButton = By.XPath("//*[@id=\"Form1\"]/div[7]/div[3]/div/button[1]");
        By ContinueButtonCategoryDialog = By.CssSelector("body > div:nth-child(26) > div.ui-dialog-buttonpane.ui-widget-content.ui-helper-clearfix > div > button:nth-child(1)");
        By PrincipalNameInput = By.Id("MainContent_eatBuilderInformationControl_txtPrincipalNameI");
        By PrincipalDOBInput = By.Id("MainContent_eatBuilderInformationControl_bdpAddPrincipalDOB_TextBox");
        By PrincipalSuburbInput = By.Id("MainContent_eatBuilderInformationControl_txtPostSuburbI");
        By PrincipalRoleDDL = By.Id("ddlRoleI");
        By PrincipalNSWInput = By.Id("MainContent_eatBuilderInformationControl_txtBuilderLicenceNumberI");
        By PrincipalYearLicenseHeldInput = By.Id("MainContent_eatBuilderInformationControl_txtYearsLicenceHeldI");
        By PrincipalActiveCheckbox = By.Id("MainContent_eatBuilderInformationControl_chkBuilderPrincipalActiveI");
        By PrincipalSaveButton = By.Id("MainContent_eatBuilderInformationControl_btnSaveNewPrincipal");
        By PrincipalListTable = By.XPath("//*[@id=\"MainContent_eatBuilderInformationControl_gridviewPrincipalDetails\"]/tbody");
        By ConfirmButtonChangeDistributorDialog = By.CssSelector("#Form1 > div.ui-dialog.ui-widget.ui-widget-content.ui-corner-all.ui-front.ui-dialog-buttons.ui-draggable.ui-resizable > div.ui-dialog-buttonpane.ui-widget-content.ui-helper-clearfix > div > button:nth-child(1)");
        By BuilderUtilisationTable = By.Id("tblBuilderJobDetails");
        By FilesTable = By.CssSelector("#collapseFiles > table > tbody");
        By ExcelExport = By.Id("MainContent_eatBuilderInformationControl_btnGenerateBuilderCertificateReportExcel");
        By EaBuilderAbnTxt = By.Id("txtEaBuilderAbn");
        By ASICEntityNameTxt = By.Id("txtASICEntityName");
        By BuilderPostcodeTxt = By.Id("txtEaBuilderPostcode");
        By BuilderStateDdl = By.Id("ddlEaBuilderState");
        By InsurerDdl = By.Id("MainContent_eatBuilderInformationControl_ddlInsurer");
        #endregion

        By OKAbnChangeOverallOutcome = By.CssSelector("body> form > div.ui-dialog.ui-widget.ui-widget-content.ui-corner-all.ui-front.ui-draggable.ui-dialog-buttons > div.ui-dialog-buttonpane.ui-widget-content.ui-helper-clearfix > div > button:nth-child(1)");

        #region Properties BUILDER PRINCIPAL DETAILS
        /// <summary>
        /// ID of table
        /// </summary>
        By BuilderPrincipalDetailsTable = By.Id("MainContent_eatBuilderInformationControl_gridviewPrincipalDetails");

        /// <summary>
        /// ID of Add New Principal button
        /// </summary>
        By NoPrincipalInThisBuilder = By.Id("MainContent_eatBuilderInformationControl_gridviewPrincipalDetails_principalDetailsLabel");
        #endregion

        #region Initiate Review
        By submitToBrokerButton = By.Id("MainContent_eatInitiateReviewControl_btnSubmitToBroker");
        By UploadStatusBar = By.CssSelector(".ajax-file-upload-statusbar");
        By SubmitToInsurerButton = By.Id("MainContent_eatInitiateReviewControl_btnSubmitToInsurer");
        By panelMessageInitiateScreen = By.Id("pnlMessage");
        By SaveButtonAssessmentComment = By.CssSelector("div[aria-describedby='divAddNewCommentDialog'] >div:nth-child(11)>div>button");
        #endregion

        #region Eligibility Details
        By CopyAllLimits = By.Id("btnCopyValues");
        By ButtonSaveLimits = By.Id("btnSaveLimits");
        By beginAssessmentButton = By.Id("MainContent_eatFinancialLimits_btnBeginAssessment");
        #endregion

        #region Overall Outcome
        /// <summary>
        /// Offer terms button
        /// </summary>
        //By OfferTermsButton = By.Id("MainContent_eatOverallOutcomeControl_btnOfferTerms");

        By OfferTermsButton = By.CssSelector("#collapseOutcomeDetails > table > tbody> tr > td:nth-child(2) > input:nth-child(2)");
        By DateTermOfferred = By.CssSelector("#collapseOutcomeDetails > table > tbody > tr:nth-child(1) > td:nth-child(2) > input");
        
        By DelegationApprovalCheckbox = By.Id("MainContent_eatOverallOutcomeControl_CheckBoxDelegation");
        //By DelegationApprovalCheckbox = By.CssSelector("#collapseAcceptorAdjustOutcome > table > tbody > tr:nth-child(5) > td:nth-child(2) > input");
        By DelegationApprovalCheckbox2 = By.CssSelector("#collapseAcceptorAdjustOutcome > table > tbody > tr:nth-child(3) > td:nth-child(2) > input");
        By EditPostCodeInput = By.CssSelector("input[name='SitePostCode']");
        By AreThereConditionsCheckbox = By.CssSelector("#collapseAcceptorAdjustOutcome > table > tbody > tr:nth-child(11) > td:nth-child(2) > input");
        By AreThereConditionsCheckbox2 = By.CssSelector("#collapseAcceptorAdjustOutcome > table > tbody > tr:nth-child(9) > td:nth-child(2) > input");
        By AreThereConditionsCheckbox3 = By.CssSelector("#collapseAcceptorAdjustOutcome > table > tbody > tr:nth-child(10) > td:nth-child(2) > input");
        By ConditionTable = By.CssSelector("#collapseAcceptorAdjustOutcome > table > tbody > tr:nth-child(14) > td:nth-child(2)");
        By ConditionTable2 = By.CssSelector("#collapseAcceptorAdjustOutcome > table > tbody > tr:nth-child(12) > td:nth-child(2)");
        By ConditionTable3 = By.CssSelector("#collapseAcceptorAdjustOutcome > table > tbody > tr:nth-child(13) > td:nth-child(2)");
        By KeyIssuesOrOtherconditions = By.CssSelector("#collapseAcceptorAdjustOutcome > table > tbody > tr:nth-child(8) > td:nth-child(2) > textarea");
        By KeyIssueOrOtherCondition = By.CssSelector("#collapseAcceptorAdjustOutcome > table > tbody > tr:nth-child(10) > td:nth-child(2) > textarea");
        By KeyIssueOrOtherCondition2 = By.CssSelector("#collapseAcceptorAdjustOutcome > table > tbody > tr:nth-child(9) > td:nth-child(2) > textarea");
        By SaveBuilderCommunicationButton = By.CssSelector("#collapseAcceptorAdjustOutcome > table > tbody > tr:nth-child(8) > td > input");
        By SaveBuilderCommunicationButton2 = By.CssSelector("#collapseAcceptorAdjustOutcome > table > tbody > tr:nth-child(10) > td > input");
        By SaveBuilderCommunicationButton3 = By.CssSelector("#collapseAcceptorAdjustOutcome > table > tbody > tr:nth-child(9) > td > input");
        By NoteTextarea = By.CssSelector("#collapseAcceptorAdjustOutcome > table > tbody > tr:nth-child(6) > td:nth-child(2) > textarea");
        By NoteTextarea2 = By.CssSelector("#collapseAcceptorAdjustOutcome > table > tbody > tr:nth-child(8) > td:nth-child(2) > textarea");
        By SaveNoteOverallOutcome = By.CssSelector("#collapseAcceptorAdjustOutcome > table > tbody > tr:nth-child(6) > td > input");
        By SaveNoteOverallOutcome2 = By.CssSelector("#collapseAcceptorAdjustOutcome > table > tbody > tr:nth-child(8) > td > input");
        By HBCFApprovedOpenJobLimitValue = By.CssSelector("#collapseOutcomeDetails > table > tbody > tr:nth-child(2) > td:nth-child(2) > input");
        By HBCFApprovedOpenJobLimitNumber = By.CssSelector("#collapseOutcomeDetails > table > tbody > tr:nth-child(3) > td:nth-child(2) > input");

        /// <summary>
        /// Save Outcome details button
        /// </summary>
        By SaveOutcomeDetailsButton = By.Id("MainContent_eatOverallOutcomeControl_btnSaveOutcomeDetails");

        // By SaveOutcomeDetailsButton = By.CssSelector("#collapseOutcomeDetails > table > tbody > tr:nth-child(9) > td > input");
        By SaveOutcomeDetailsButtonHasPleaseNote = By.CssSelector("#collapseOutcomeDetails > table > tbody > tr:nth-child(10) > td > input");
        By PleaseNoteRow = By.CssSelector("#collapseOutcomeDetails > table > tbody > tr:nth-child(6)");
        By AssessmentStatus = By.CssSelector("#collapseOutcomeDetails > table > tbody > tr:nth-child(6) > td:nth-child(2) > select");
        By AssessmentStatus2 = By.CssSelector("#collapseOutcomeDetails > table > tbody > tr:nth-child(7) > td:nth-child(2) > select");
        /// <summary>
        /// 
        /// </summary>
        //By FinaliseAssessmentButton = By.Id("MainContent_eatOverallOutcomeControl_btnFinaliseAssessment");

        By FinaliseAssessmentButton = By.CssSelector("#collapseOutcomeDetails > table > tbody > tr:nth-child(10) > td > input");
        By DateTermsOffered = By.CssSelector("#collapseOutcomeDetails > table > tbody >tr:nth-child(1) > td:nth-child(2) > input");
        By DeleteConditon = By.CssSelector("#collapseAcceptorAdjustOutcome > table > tbody > tr:nth-child(14) > td:nth-child(2) > div > table > tbody > tr > td:nth-child(2) > input:nth-child(2)");
        By DeleteConditon2 = By.CssSelector("#collapseAcceptorAdjustOutcome > table > tbody > tr:nth-child(12) > td:nth-child(2) > div > table > tbody > tr > td:nth-child(2) > input:nth-child(2)");
        By DeleteConditon3 = By.CssSelector("#collapseAcceptorAdjustOutcome > table > tbody > tr:nth-child(13) > td:nth-child(2) > div > table > tbody > tr > td:nth-child(2) > input:nth-child(2)");
        By NotProceedingComment = By.CssSelector("#collapseOutcomeDetails > table > tbody > tr:nth-child(7) > td:nth-child(2) > textarea");
        By ReferToUser = By.CssSelector("#MainContent_eatOverallOutcomeControl_tblManualOverride > tbody > tr:nth-child(4) > td:nth-child(2) > select");
        By DoiTableOverallOutcome = By.CssSelector("#doiTableContainer > div > table > tbody");
        By LotStreetNoInput = By.CssSelector("input[name='SiteLotStreetNo']");
        By SuburbInput = By.CssSelector("input[name='SiteSuburb']");
        By SiteStreetName = By.CssSelector("input[name='SiteStreetName']");
        By PolicyNumber = By.CssSelector("input[name='PolicyNumber']");
        By GenerateEligibilityButton = By.Id("MainContent_eatOverallOutcomeControl_btnGenerateElgibility");

        /// <summary>
        /// Generate Eligibility button for GTA
        /// </summary>
        By GenerateEligibilityButtonGTA = By.Id("MainContent_eatGroupOverallOutcomeControl_btnGenerateElgibility");

        /// <summary>
        /// Eligibility Assessment status dropdownlist in Overall Outcome screen
        /// </summary>
        By EligibilityAssessmentStatusDLL = By.Id("MainContent_eatOverallOutcomeControl_mo_r7c2_ddl");

        /// <summary>
        /// Next planed review date
        /// </summary>
        By NextPlanedReviewDateTxt = By.Id("MainContent_eatOverallOutcomeControl_dtNextPlannedReviewDate");

        #endregion

        #region ManageGroup
        By EntityNameManageGroup = By.CssSelector("input[name='entityName']");
        By SearchButtonManageGroup = By.CssSelector("#gtaManagementContainer > div > div:nth-child(2) > table > tbody > tr:nth-child(5) > td:nth-child(1) > button");
        By CreateNewGroup = By.CssSelector("#gtaManagementContainer > div > div:nth-child(2) > table > tbody > tr:nth-child(5) > td:nth-child(2) > button");
        By GroupNameInput = By.CssSelector("#validationSummaryContent > div.modal-form-group > div > input[type=text]");
        By DivAutoComplete = By.CssSelector("div[class='information autocomplete']");
        #endregion

        #region SiraBuilderDetail
        By RefreshLicenceDetailFromSira = By.Id("btnRefreshGlsDetails");
        #endregion

        #region Menu
        By EligibilityReviewMenu = By.Id("ButtonEligibilityReview");
        By BuilderDetailMenuButton = By.Id("ButtonBuilderDetails");
        By trackRecordMenu = By.Id("ButtonTrackRecord");
        By ButtonOverallInputMenu = By.Id("ButtonOverallOutcome");
        #endregion

        #region DIALOG
        By BusyDialog = By.CssSelector("div[aria-describedby='masterBusyDialog']");
        By ConfirmDistributorChangeDialog = By.CssSelector("div[aria-describedby='confirmDistributorChangeDialog']");
        By DeedOfIndemnityErrorDialog = By.CssSelector("div[aria-describedby='ui-id-7']");
        By RenderingTemplateDialog = By.CssSelector("div[aria-describedBy='masterBusyDialog']");
        By OfferTermsEmailSendDialog = By.CssSelector("div[aria-describedby='masterOkDialog']");
        By LoadingSquare = By.CssSelector("#gtaManagementContainer > div > div:nth-child(4) > div.invisible");
        By ErrorManageGroupDialog = By.CssSelector("#beatDialogContainer > div > div.modal-container.modal-container-active.ui-dialog-default.ui-widget.ui-widget-content.ui-corner-all.ui-dialog-buttons.ui-draggable.center-align-view-port");
        By DeleteFileDialog = By.CssSelector("div[aria-describedby='portalBusyDialog']");
        By ValidationDialog = By.CssSelector("div[aria-describedby='validation_dialog']");
        By CloseButtonValidationDialog = By.CssSelector("body > div:nth-child(42) > div.ui-dialog-buttonpane.ui-widget-content.ui-helper-clearfix > div > button > span");
        #endregion

        const string LICENSE_BUILDER_ENTITY_NAME = "MASTERTON HOMES PTY";

        public BuilderPage(ChromeDriver driver) : base(driver)
        {
            Util.Driver = driver;
        }
        public void LoadTitle()
        {
            Util.WaitUntilElementExists(chromeDriver, step1Title, 20);
        }

        public void SetBuilderEntityName(string name)
        {
            var entityName = Util.WaitUntilElementExists(chromeDriver, entityNameInput, 10);
            entityName.SendKeys(name);
        }

        public void SetBuilderTradingName(string name)
        {
            var tradingName = Util.WaitUntilElementExists(chromeDriver, tradingNameInput, 10);
            tradingName.SendKeys(name);
        }

        //public void SetBuilderEntityName(By nameinput, string name)
        //{
        //    Util.SetValue(entityNameInput, name);
        //}

        public void SetBuilderLicenceNumber(string name)
        {
            var licenceNumber = Util.WaitUntilElementExists(chromeDriver, builderLincenceName, 10);
            licenceNumber.SendKeys(name);
        }

        public void ClickSearchBuilder()
        {
            var btnSearch = Util.WaitUntilElementExists(chromeDriver, searchButton, 10);
            btnSearch.Click();
        }

        public IWebElement GetBuilderTable()
        {
            return Util.WaitUntilElementExists(chromeDriver, builderTable, 10);
        }

        public List<IWebElement> GetTrElement(IWebElement element)
        {
            return new List<IWebElement>(element.FindElements(By.TagName("tr")));
        }

        public List<IWebElement> GetTdElement(IWebElement element)
        {
            return new List<IWebElement>(element.FindElements(By.TagName("td")));
        }

        public List<IWebElement> GetThElement(IWebElement element)
        {
            return new List<IWebElement>(element.FindElements(By.TagName("th")));
        }

        /// <summary>
        /// Get list of elements by any properties: Id,  CssSelector, TagName, ...
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public List<IWebElement> GetElementsByProperty(By property)
        {
            var document = Util.WaitUntilElementExists(chromeDriver, By.CssSelector("body"));
            return new List<IWebElement>(document.FindElements(property));
        }

        public bool CheckSearchResult(string builderName)
        {
            var builders = GetBuilderTable();
            var lstTrElem = GetTrElement(builders);
            var lstTdElem = GetTdElement(lstTrElem[1]);

            if (lstTdElem.Count > 1)// == 1 no data
            {
                for (int i = 1; i < lstTrElem.Count; i++)
                {
                    var lstTdElemByRow = GetTdElement(lstTrElem[i]);
                    var name = lstTdElemByRow[2].Text;
                    if (!name.ToLower().Contains(builderName.ToLower()))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GoPreviouslyPage()
        {
            chromeDriver.Navigate().Back();
        }

        public bool ViewBuilder()
        {
            var builders = GetBuilderTable();
            var lstTrElem = GetTrElement(builders);
            for (int i = 1; i < lstTrElem.Count; i++)
            {
                var lstTdElemByRow = GetTdElement(lstTrElem[i]);
                var name = lstTdElemByRow[2].Text;
                if (name.ToUpper().Contains(LICENSE_BUILDER_ENTITY_NAME))
                {
                    lstTdElemByRow[1].Click();

                    var licensedBuilderEntityName = Util.WaitUntilElementExists(chromeDriver, licensedBuilderEntityNameInput, 10);
                    var licensedBuilderEntityNameValue = licensedBuilderEntityName.GetAttribute("value");
                    if (licensedBuilderEntityNameValue.ToUpper().Contains(LICENSE_BUILDER_ENTITY_NAME))
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        public bool ResultSearch()
        {
            var builders = GetBuilderTable();
            var lstTrElem = GetTrElement(builders);
            var lstTdElem = GetTdElement(lstTrElem[1]);

            if (lstTdElem.Count > 1)
                return true;
            else
                return false;
        }

        public void ClickViewBuilder()
        {
            //var builders = GetBuilderTable();
            //var lstTrElem = GetTrElement(builders);
            //var lstTdElemByRow = GetTdElement(lstTrElem[1]);
            //lstTdElemByRow[1].Click();
            var input = Util.WaitUntilElementExists(chromeDriver, By.Id("MainContent_eatSearchControlNew_searchResultsGridView_btnViewBuilder_0"), 10);
            input.Click();
        }

        public void ClickViewAssessments()
        {
            //var builders = GetBuilderTable();
            //var lstTrElem = GetTrElement(builders);
            //var lstTdElemByRow = GetTdElement(lstTrElem[1]);
            var input = Util.WaitUntilElementExists(chromeDriver, By.Id("MainContent_eatSearchControlNew_searchResultsGridView_btnViewAssessments_0"), 10);
            input.Click();
        }

        public IWebElement GetCommentTable()
        {
            return Util.WaitUntilElementExists(chromeDriver, BuilderCommentTable, 20);
        }

        public bool CheckResultAddcommentBuilder(string textComment)
        {
            var comments = GetCommentTable();
            var lstTrElem = GetTrElement(comments);
            var lstTdElem = GetTdElement(lstTrElem[1]);

            if (lstTdElem.Count > 1)// == 1 no data
            {
                if (lstTdElem[3].Text != textComment)
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ClickVisibleToAI()
        {
            var visibleToAI = Util.WaitUntilElementExists(chromeDriver, visibleToIANewCheckbox, 10);
            visibleToAI.Click();
        }

        public bool CheckVisibleAITicked()
        {
            var comments = GetCommentTable();
            var lstTrElem = GetTrElement(comments);
            var lstTdElem = GetTdElement(lstTrElem[1]);
            lstTdElem[0].FindElement(By.TagName("a")).Click();
            var visibleToAI = Util.WaitUntilElementExists(chromeDriver, visibleToIAEditCheckbox, 10);
            if (!visibleToAI.Selected)
            {
                return false;
            }
            return true;
        }

        public IWebElement GetFileUploadTable()
        {
            return Util.WaitUntilElementExists(chromeDriver, fileUploadTable, 20);
        }

        public int CountDataPrincipalTable()
        {
            var principals = GetPrincipalTable();
            var lstTrElem = GetTrElement(principals);
            return lstTrElem.Count();
        }

        public void DeletePrincipal()
        {
            var principals = GetPrincipalTable();
            var lstTrElem = GetTrElement(principals);
            var newPrincipal = lstTrElem[lstTrElem.Count - 1];
            var lstTdElem = GetTdElement(newPrincipal);
            var deleteButton = lstTdElem[7].FindElements(By.TagName("input"))[1];
            deleteButton.Click();
        }

        public void ClickAddInterstateLicence()
        {
            var addNewInterstateLicence = Util.WaitUntilElementExists(chromeDriver, addNewInterstateLicenceButton, 10);
            addNewInterstateLicence.Click();
        }

        public void SetLicenseNo(string no)
        {
            var licenseNo = Util.WaitUntilElementExists(chromeDriver, licenseNoInput, 10);
            licenseNo.SendKeys(no);
        }

        public void SetLicenseState(string state)
        {
            var lstOptionState = GetOptionDDL(licenseStateDDL);
            for (int i = 0; i <= lstOptionState.Count - 1; i++)
            {
                if (lstOptionState[i].Text == state)
                {
                    lstOptionState[i].Click();
                    break;
                }
            }
        }

        public void SetLicenseName(string name)
        {
            var licenseName = Util.WaitUntilElementExists(chromeDriver, licenseNameInput, 10);
            licenseName.SendKeys(name);
        }

        public void SetLicenseCategory(string category)
        {
            var licenseCategory = Util.WaitUntilElementExists(chromeDriver, licenseCategoryInput, 10);
            licenseCategory.SendKeys(category);
        }

        public void SetLicenseIssueDate(string issueDate)
        {
            var licenseIssueDate = Util.WaitUntilElementExists(chromeDriver, licenseIssueDateInput, 10);
            licenseIssueDate.SendKeys(issueDate);
        }

        public void SetLicenseExpiryDate(string expiryDate)
        {
            var licenseExpiryDate = Util.WaitUntilElementExists(chromeDriver, licenseExpiryDateInput, 10);
            licenseExpiryDate.SendKeys(expiryDate);
        }

        public void SetLicenseStatus(string status)
        {
            var lstOptionStatus = GetOptionDDL(licenseStatusDDL);
            for (int i = 0; i <= lstOptionStatus.Count - 1; i++)
            {
                if (lstOptionStatus[i].Text == status)
                {
                    lstOptionStatus[i].Click();
                    break;
                }
            }
        }

        public void ClickSaveLicense()
        {
            var saveLicense = Util.WaitUntilElementExists(chromeDriver, licenseSaveButton, 10);
            saveLicense.Click();
        }

        public IWebElement GetLicenseTable()
        {
            return Util.WaitUntilElementExists(chromeDriver, licenseListTable, 20);
        }

        public bool VerifyAddNewLicense(string no,
                                                string state,
                                                string name,
                                                string category,
                                                string issueDate,
                                                string expiryDate,
                                                string status)
        {
            var licenses = GetLicenseTable();
            var lstTrElem = GetTrElement(licenses);
            var lstTdElem = GetTdElement(lstTrElem[1]);

            if (lstTdElem.Count <= 1)
            {
                return false;
            }
            else
            {
                var newLicense = lstTrElem[lstTrElem.Count - 1];
                var tdNewLicense = GetTdElement(newLicense);

                if (tdNewLicense[0].Text == no &&
                    tdNewLicense[1].Text == state &&
                    tdNewLicense[2].Text == name &&
                    tdNewLicense[3].Text == category &&
                    Convert.ToDateTime(tdNewLicense[4].Text).ToString("yyyy-MM-dd") == issueDate &&
                    Convert.ToDateTime(tdNewLicense[5].Text).ToString("yyyy-MM-dd") == expiryDate &&
                    tdNewLicense[6].Text == status)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public int CountDataLicenseTable()
        {
            var licenses = GetLicenseTable();
            var lstTrElem = GetTrElement(licenses);
            return lstTrElem.Count();
        }

        public void DeleteLicense()
        {
            var licenses = GetLicenseTable();
            var lstTrElem = GetTrElement(licenses);
            var newLicense = lstTrElem[lstTrElem.Count - 1];
            var lstTdElem = GetTdElement(newLicense);
            var deleteButton = lstTdElem[7].FindElements(By.TagName("input"))[1];
            deleteButton.Click();
        }

        public void ClickPricingHistoryButton()
        {
            var pricingHistory = Util.WaitUntilElementExists(chromeDriver, pricingHistoryButton, 10);
            pricingHistory.Click();
        }
        public bool CheckPopupPricingHistoryShow()
        {
            var pricingHistoryPopup = Util.WaitUntilElementExists(chromeDriver, pricingPopupHistory, 10);
            var displayPopupPricingHistory = pricingHistoryPopup.GetCssValue("display");
            if (displayPopupPricingHistory == "none")
                CheckPopupPricingHistoryShow();
            return true;
        }

        public bool ClickEditLinkAssessment()
        {
            var assessments = GetAssessmentTable();
            var lstTrElem = GetTrElement(assessments);
            var temp = 0;
            var totalCount = 0;
            var lstTdElemLast = GetTdElement(lstTrElem[lstTrElem.Count - 1]);
            if (lstTdElemLast.Count <= 1)
                totalCount = lstTrElem.Count - 2;
            else
                totalCount = lstTrElem.Count - 1;

            //click edit link for assessment has EA Finalised
            for (int i = 1; i <= totalCount; i++)
            {
                var lstTdElem = GetTdElement(lstTrElem[i]);
                if (lstTdElem[11].Text == "No")
                {
                    lstTdElem[0].Click();
                    Thread.Sleep(2000);
                    break;
                }
                temp++;
            }
            if (temp == totalCount)
            {
                return false;
            }
            return true;
        }

        public IWebElement GetAssessmentTable()
        {
            return Util.WaitUntilElementExists(chromeDriver, assessmentTable, 10);
        }

        public void SetScheduledAssessmentDate(string date)
        {
            var scheduledAssessment = Util.WaitUntilElementExists(chromeDriver, scheduledAssessmentDate, 10);
            scheduledAssessment.Clear();
            scheduledAssessment.SendKeys(date);
        }

        public void SetAssessmentComment(string comment)
        {
            var commentTxt = Util.WaitUntilElementExists(chromeDriver, commentAssessment, 10);
            commentTxt.Clear();
            commentTxt.SendKeys(comment);
        }

        public void ClickSaveAssessment()
        {
            var btnSave = Util.WaitUntilElementExists(chromeDriver, saveAssessmentButton, 10);
            btnSave.Click();
        }

        public bool VerifyAssessmentDetail(string date, string comment)
        {
            var txtScheduledAssessment = Util.WaitUntilElementExists(chromeDriver, scheduledAssessmentDate, 10);
            var commentTxt = Util.WaitUntilElementExists(chromeDriver, commentAssessment, 10);

            if (date == txtScheduledAssessment.GetAttribute("value") && comment == commentTxt.GetAttribute("value"))
                return true;
            return false;
        }

        public void ClickOngoingAuditorAppointmentCheckbox()
        {
            var ongoingAuditorAppointment = Util.WaitUntilElementExists(chromeDriver, tickOngoingAuditorAppointmentCheckbox, 10);
            ongoingAuditorAppointment.Click();
        }

        public bool VerifyOngoingAuditorAppointment(bool isTick)
        {
            var ongoingAuditorAppointment = Util.WaitUntilElementExists(chromeDriver, tickOngoingAuditorAppointmentCheckbox, 10);
            if (ongoingAuditorAppointment.Selected == isTick)
                return true;
            return false;
        }

        public void ClickUploadFinancialStatementsOfTheBuilder(string filePath = "")
        {
            var upload = Util.WaitUntilElementExists(chromeDriver, UploadFinancialStatementButton);
            if (upload != null)
            {
                var inputUploads = upload.FindElements(By.TagName(Common.TagNameInput));
                foreach (var itemInput in inputUploads)
                {
                    if (itemInput.GetAttribute("type") == "file")
                    {
                        itemInput.SendKeys(filePath);
                        Thread.Sleep(5000);
                        break;
                    }
                }
            }
        }

        public void SetDescriptionInput(string descriptionAttachment)
        {
            var description = Util.WaitUntilElementExists(chromeDriver, popupDescriptionInput, 10);
            description.SendKeys(descriptionAttachment);
        }

        public void ClickContinue()
        {
            var continueDscription = Util.WaitUntilElementExists(chromeDriver, continueButton, 10);
            continueDscription.Click();
        }

        public IWebElement GetStatementsTable()
        {
            return Util.WaitUntilElementExists(chromeDriver, gridFinStatements, 10);
        }

        /// <summary>
        /// Upload file
        /// </summary>
        /// <param name="fileUpload">File include path of file (C:\\doc1.txt)</param>
        public void ClickUploadSensitive(string fileUpload)
        {
            var lstInput = GetElementsByProperty(SensitiveUploadButton);
            if (lstInput != null)
            {
                foreach (var iInput in lstInput)
                {
                    if (iInput.GetProperty("type") == "file")
                    {
                        iInput.SendKeys(fileUpload);
                        Thread.Sleep(2000);
                        break;
                    }
                }
            }
            //var sensitive = Util.WaitUntilElementExists(chromeDriver, sensitiveButton, 10);
            //sensitive.Click();
        }

        public IWebElement GetSensitiveTable()
        {
            return Util.WaitUntilElementExists(chromeDriver, SensitiveTable, 10);
        }

        public bool VerifyFileUploadSensitive(string fileName, string description)
        {
            var Sensitive = GetSensitiveTable();
            if (Sensitive != null)
            {
                var lstTrElem = GetTrElement(Sensitive);
                if (lstTrElem != null && lstTrElem.Count > 1)
                {
                    var lstTdElem = GetTdElement(lstTrElem[1]);
                    if (lstTdElem[0].Text == description && lstTdElem[1].FindElement(By.TagName("a")).Text == fileName)
                        return true;
                }
            }

            return false;
        }

        public void SetCommentAssessment(string comments)
        {
            var comment = Util.WaitUntilElementExists(chromeDriver, commentAssessmentTextArea, 10);
            comment.SendKeys(comments);
        }

        public void ClickSaveCommentAssessment()
        {
            var buttonSave = Util.WaitUntilElementExists(chromeDriver, commentAssessmentButton, 10);
            buttonSave.Click();
        }

        public IWebElement GetCommentAssessmentTable()
        {
            return Util.WaitUntilElementExists(chromeDriver, commentAssessmentTable, 10);
        }

        public bool VerifySaveCommentAssessment(string comment)
        {
            var commentTable = GetCommentAssessmentTable();
            var lstTrElem = GetTrElement(commentTable);
            if (lstTrElem.Count > 1)
            {
                var newComment = lstTrElem[1];
                var lstTdElem = GetTdElement(newComment);

                if (lstTdElem[2].Text == comment)
                    return true;
                return false;
            }
            else
                return false;
        }

        public string ConvertRgbaToHex(string rgba)
        {
            if (!Regex.IsMatch(rgba, @"rgba\((\d{1,3},\s*){3}(0(\.\d+)?|1)\)"))
                throw new FormatException("rgba string was in a wrong format");

            var matches = Regex.Matches(rgba, @"\d+");
            StringBuilder hexaString = new StringBuilder("#");

            for (int i = 0; i < matches.Count - 1; i++)
            {
                int value = Int32.Parse(matches[i].Value);

                hexaString.Append(value.ToString("X"));
            }

            return hexaString.ToString() + "0";
        }

        public bool CheckSubmitTheAssessmentToTheInsuranceAgent()
        {
            var submitTheAssessmentToTheInsuranceAgent = Util.WaitUntilElementExists(chromeDriver, submitTheAssessmentToTheInsuranceAgentButton, 10);
            return submitTheAssessmentToTheInsuranceAgent.Enabled;
        }

        public void ClickSubmitTheAssessmentToTheInsuranceAgentButton()
        {
            var submitTheAssessmentToTheInsuranceAgent = Util.WaitUntilElementExists(chromeDriver, submitTheAssessmentToTheInsuranceAgentButton, 10);
            submitTheAssessmentToTheInsuranceAgent.Click();
        }

        public void ChangeValueSwimmingPools()
        {
            var swimmingPools = Util.WaitUntilElementExists(chromeDriver, swimmingPoolsInput, 10);
            swimmingPools.Clear();
            swimmingPools.SendKeys("600000");
        }

        public bool VerifyValueSwimmingPools()
        {
            var swimmingPools = Util.WaitUntilElementExists(chromeDriver, swimmingPoolsInput, 10);
            if (swimmingPools.GetAttribute("value").Replace(",", "") == "600000")
                return true;
            return false;
        }

        public void ChangeAlterOpenJobLimitValue()
        {
            var alterOpenJobLimitValue = Util.WaitUntilElementExists(chromeDriver, alterOpenJobLimitValueInput, 10);
            alterOpenJobLimitValue.Clear();
            alterOpenJobLimitValue.SendKeys("9000000");
        }

        public bool VerifyAlterOpenJobLimitValue()
        {
            var alterOpenJobLimitValue = Util.WaitUntilElementExists(chromeDriver, alterOpenJobLimitValueInput, 10);
            if (alterOpenJobLimitValue.GetAttribute("value").Replace(",", "") == "9000000")
                return true;
            return false;
        }

        public void DeleteValueAssumedNSWHBCFTurnover()
        {
            var assumedNSWHBCFTurnover = Util.WaitUntilElementExists(chromeDriver, assumedNSWHBCFTurnoverInput, 10);
            assumedNSWHBCFTurnover.Clear();
        }

        public bool VerifyValueChangeAssumedNSWHBCFTurnover()
        {
            var assumedNSWHBCFTurnover = Util.WaitUntilElementExists(chromeDriver, assumedNSWHBCFTurnoverInput, 10);
            if (assumedNSWHBCFTurnover.GetAttribute("value").Replace(",", "") == "10008536")
                return true;
            return false;
        }
        
        public List<IWebElement> GetTableRows()
        {
            var financials = GetFinancialTable();
            var lstTrElem = GetTrElement(financials);
            var lstTrTableRow = new List<IWebElement>();

            foreach (var tr in lstTrElem)
            {
                var classValue = tr.GetAttribute("class");
                if (classValue == "TableRow")
                {
                    lstTrTableRow.Add(tr);
                }
            }

            return lstTrTableRow;
        }

        public List<IWebElement> GetSubHeaderRow()
        {
            var financials = GetFinancialTable();
            var lstTrElem = GetTrElement(financials);
            var lstTrSubHeaderRow = new List<IWebElement>();

            foreach (var tr in lstTrElem)
            {
                var classValue = tr.GetAttribute("class");
                if (classValue == "SubHeaderRow")
                {
                    lstTrSubHeaderRow.Add(tr);
                }
            }

            return lstTrSubHeaderRow;
        }

        public IWebElement GetOtherIncomeSaveButton()
        {
            var lstTrSubHeaderRow = GetSubHeaderRow();
            IWebElement otherIncomeSave = null;

            foreach (var trHeaderRow in lstTrSubHeaderRow)
            {
                var lstTdElem = GetTdElement(trHeaderRow);
                if (lstTdElem[0].Text == "Other Income")
                {
                    otherIncomeSave = lstTdElem[1].FindElement(By.TagName("input"));
                }
            }

            return otherIncomeSave;
        }

        public IWebElement GetExpensesSaveButton()
        {
            var lstTrSubHeaderRow = GetSubHeaderRow();
            IWebElement expensesSave = null;

            foreach (var trHeaderRow in lstTrSubHeaderRow)
            {
                var lstTdElem = GetTdElement(trHeaderRow);
                if (lstTdElem[0].Text == "Expenses")
                {
                    expensesSave = lstTdElem[1].FindElement(By.TagName("input"));
                }
            }

            return expensesSave;
        }

        public IWebElement GetTaxDividendsSaveButton()
        {
            var lstTrSubHeaderRow = GetSubHeaderRow();
            IWebElement taxDividendsSave = null;

            foreach (var trHeaderRow in lstTrSubHeaderRow)
            {
                var lstTdElem = GetTdElement(trHeaderRow);
                if (lstTdElem[0].Text == "Tax Dividends")
                {
                    taxDividendsSave = lstTdElem[1].FindElement(By.TagName("input"));
                }
            }

            return taxDividendsSave;
        }

        public bool SetFinancialInformation()
        {
            var lstTrTableRow = GetTableRows();

            IWebElement salesSave = null;
            IWebElement otherIncomeSave = null;
            IWebElement expensesSave = null;
            IWebElement taxDividendsSave = null;
            var grossProfit = "";
            var totalOtherIncome = "";
            var operatingOtherExpenses = "";
            var netProfitBeforeTax = "";
            var netProfitAfterTax = "";
            var retainedProfits = "";

            foreach (var trRow in lstTrTableRow)
            {
                var lstTdElem = GetTdElement(trRow);
                var inputCol1 = lstTdElem[1].FindElement(By.TagName("input"));
                var inputCol1Id = inputCol1.GetAttribute("id");

                if (inputCol1Id.Contains("BaseSales"))
                {
                    inputCol1.Clear();
                    inputCol1.SendKeys("100000");
                }
                else if (inputCol1Id.Contains("OpeningStock"))
                {
                    inputCol1.Clear();
                    inputCol1.SendKeys("70000");
                }
                else if (inputCol1Id.Contains("PurchasesMaterials"))
                {
                    inputCol1.Clear();
                    inputCol1.SendKeys("5000");
                }
                else if (inputCol1Id.Contains("LessClosingStock"))
                {
                    inputCol1.Clear();
                    inputCol1.SendKeys("2000");
                }
            }
            salesSave = GetSaveButtonWithSubHeaderRow();
            salesSave.Click();
            WaitTillBusyDialogClose();

            lstTrTableRow = GetTableRows();
            foreach (var trRow in lstTrTableRow)
            {
                var lstTdElem = GetTdElement(trRow);
                var inputCol1 = lstTdElem[1].FindElement(By.TagName("input"));
                var inputCol1Id = inputCol1.GetAttribute("id");

                if (inputCol1Id.Contains("ManagementFees"))
                {
                    inputCol1.Clear();
                    inputCol1.SendKeys("890");
                }
                else if (inputCol1Id.Contains("ExtraordinaryIncome"))
                {
                    inputCol1.Clear();
                    inputCol1.SendKeys("6754");
                }
                else if (inputCol1Id.Contains("prop_OtherIncome"))
                {
                    inputCol1.Clear();
                    inputCol1.SendKeys("6427");
                }
            }
            otherIncomeSave = GetOtherIncomeSaveButton();
            otherIncomeSave.Click();
            WaitTillBusyDialogClose();

            lstTrTableRow = GetTableRows();
            foreach (var trRow in lstTrTableRow)
            {
                var lstTdElem = GetTdElement(trRow);
                var inputCol1 = lstTdElem[1].FindElement(By.TagName("input"));
                var inputCol1Id = inputCol1.GetAttribute("id");

                if (inputCol1Id.Contains("ExtraordinaryLosses"))
                {
                    inputCol1.Clear();
                    inputCol1.SendKeys("2626");
                }
                else if (inputCol1Id.Contains("PartnersDirectorsWages"))
                {
                    inputCol1.Clear();
                    inputCol1.SendKeys("8000");
                }
                else if (inputCol1Id.Contains("Interest"))
                {
                    inputCol1.Clear();
                    inputCol1.SendKeys("456");
                }
                else if (inputCol1Id.Contains("HirePurchaseLeaseInterest"))
                {
                    inputCol1.Clear();
                    inputCol1.SendKeys("400");
                }
                else if (inputCol1Id.Contains("DepreciationAmortisation"))
                {
                    inputCol1.Clear();
                    inputCol1.SendKeys("900");
                }
            }
            expensesSave = GetExpensesSaveButton();
            expensesSave.Click();
            WaitTillBusyDialogClose();

            lstTrTableRow = GetTableRows();
            foreach (var trRow in lstTrTableRow)
            {
                var lstTdElem = GetTdElement(trRow);
                var inputCol1 = lstTdElem[1].FindElement(By.TagName("input"));
                var inputCol1Id = inputCol1.GetAttribute("id");

                if (inputCol1Id.Contains("prop_Tax"))
                {
                    inputCol1.Clear();
                    inputCol1.SendKeys("10000");
                }
                else if (inputCol1Id.Contains("prop_Dividends"))
                {
                    inputCol1.Clear();
                    inputCol1.SendKeys("123");
                }
            }
            taxDividendsSave = GetTaxDividendsSaveButton();
            taxDividendsSave.Click();
            WaitTillBusyDialogClose();

            lstTrTableRow = GetTableRows();
            foreach (var trRow in lstTrTableRow)
            {
                var lstTdElem = GetTdElement(trRow);
                var inputCol1 = lstTdElem[1].FindElement(By.TagName("input"));
                var inputCol1Id = inputCol1.GetAttribute("id");

                if (inputCol1Id.Contains("GrossProfit"))
                {
                    grossProfit = inputCol1.GetAttribute("value").Replace(",", "");
                }
                else if (inputCol1Id.Contains("TotalOtherIncome"))
                {
                    totalOtherIncome = inputCol1.GetAttribute("value").Replace(",", "");
                }
                else if (inputCol1Id.Contains("OperatingOtherExpenses"))
                {
                    operatingOtherExpenses = inputCol1.GetAttribute("value").Replace(",", "");
                }
                else if (inputCol1Id.Contains("NetProfitBeforeTax"))
                {
                    netProfitBeforeTax = inputCol1.GetAttribute("value").Replace(",", "");
                }
                else if (inputCol1Id.Contains("NetProfitAfterTax"))
                {
                    netProfitAfterTax = inputCol1.GetAttribute("value").Replace(",", "");
                }
                else if (inputCol1Id.Contains("RetainedProfits"))
                {
                    retainedProfits = inputCol1.GetAttribute("value").Replace(",", "");
                }
            }

            //Check value total
            if (grossProfit == "27000" &&
            totalOtherIncome == "14071" &&
            operatingOtherExpenses == "-12438" &&
            netProfitBeforeTax == "41071" &&
            netProfitAfterTax == "31071" &&
            retainedProfits == "30948")
                return true;
            return false;
        }

        public IWebElement GetFinancialTable()
        {
            return Util.WaitUntilElementExists(chromeDriver, FinancialsTable, 10);
        }

        public void SetValuePlusPurchasesMaterialsSubcontractorsRow(string value)
        {
            var lstTrTableRow = GetTableRows();
            foreach (var row in lstTrTableRow)
            {
                var lstTdElem = GetTdElement(row);
                var inputCol1 = lstTdElem[1].FindElement(By.TagName("input"));
                var inputCol1Id = inputCol1.GetAttribute("id");
                if (inputCol1Id.Contains("PurchasesMaterials"))
                {
                    inputCol1.Clear();
                    inputCol1.SendKeys(value);

                    var inputCol2 = lstTdElem[3].FindElement(By.TagName("input"));
                    inputCol2.Clear();
                    inputCol2.SendKeys(value);

                    var inputCol3 = lstTdElem[5].FindElement(By.TagName("input"));
                    inputCol3.Clear();
                    inputCol3.SendKeys(value);

                    break;
                }
            }
        }

        public string GetColTextOfAssessmentTable(int rowIndex, int colIndex)
        {
            var assessments = GetAssessmentTable();
            var lstTrElem = GetTrElement(assessments);

            var lstTdElem = GetTdElement(lstTrElem[rowIndex]);
            return lstTdElem[colIndex].Text;

        }

        public int CheckEditLinkAssessment()
        {
            var assessments = GetAssessmentTable();
            var lstTrElem = GetTrElement(assessments);
            var temp = 0;
            var totalCount = 0;
            var lstTdElemLast = GetTdElement(lstTrElem[lstTrElem.Count - 1]);
            if (lstTdElemLast.Count <= 1)
                totalCount = lstTrElem.Count - 2;
            else
                totalCount = lstTrElem.Count - 1;

            //click edit link for assessment has EA Finalised
            for (int i = 1; i <= totalCount; i++)
            {
                var lstTdElem = GetTdElement(lstTrElem[i]);
                if (lstTdElem[11].Text == "No")
                {
                    return i;
                }
                temp++;
            }
            return -1;
        }

        public void NavigateToSearchAndSearch(string licenceNumber)
        {
            chromeDriver.Navigate().GoToUrl("http://portal-uat.hbcf.nsw.gov.au/portal/server.pt/gateway/PTARGS_0_0_352_0_0_43/http%3B/portal-app/Beat/SearchBeat.aspx");
            SetBuilderLicenceNumber(licenceNumber);
            ClickSearchBuilder();
        }

        public int CheckViewAssessment()
        {
            var assessments = GetAssessmentTable();
            var lstTrElem = GetTrElement(assessments);
            var temp = 0;
            var totalCount = 0;
            var lstTdElemLast = GetTdElement(lstTrElem[lstTrElem.Count - 1]);
            if (lstTdElemLast.Count <= 1)
                totalCount = lstTrElem.Count - 2;
            else
                totalCount = lstTrElem.Count - 1;

            //click edit link for assessment has EA Finalised
            for (int i = 1; i <= totalCount; i++)
            {
                var lstTdElem = GetTdElement(lstTrElem[i]);
                if (lstTdElem[11].Text == "Yes")
                {
                    return i;
                }
            }
            return -1;


        }

        public bool ClickViewLinkAssessment()
        {
            var assessments = GetAssessmentTable();
            var lstTrElem = GetTrElement(assessments);
            var temp = 0;
            var totalCount = 0;
            var lstTdElemLast = GetTdElement(lstTrElem[lstTrElem.Count - 1]);
            if (lstTdElemLast.Count <= 1)
                totalCount = lstTrElem.Count - 2;
            else
                totalCount = lstTrElem.Count - 1;

            //click edit link for assessment has EA Finalised
            for (int i = 1; i <= totalCount; i++)
            {
                var lstTdElem = GetTdElement(lstTrElem[i]);
                if (lstTdElem[11].Text == "Yes")
                {
                    lstTdElem[0].Click();
                    break;
                }
                temp++;
            }
            if (temp == totalCount)
            {
                return false;
            }
            return true;
        }

        public bool CheckHiddenDialogExist()
        {
            try
            {
                var hiddenDialog = chromeDriver.FindElementByCssSelector("div[class='ui-widget-overlay ui-front']");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //public void WaitTillFinancialInputsIsEnable()
        //{
        //    var buttonFinancialInputsMenu = Util.WaitUntilElementExists(chromeDriver, ButtonFinancialInputsMenu, 10);
        //    while (buttonFinancialInputsMenu.GetAttribute("disabled") == "disabled")
        //    {

        //    }
        //}

        public void SetValueForUnderWriterAssessmentOutcomeDropDown(string value)
        {
            var underWriterAssessmentOutcomeDropDownElement = Util.WaitUntilElementExists(chromeDriver, UnderwriterAssessmentOutcomeDropDown, 10);
            var underWriterAssessmentOutcomeDropDown = new SelectElement(underWriterAssessmentOutcomeDropDownElement);
            underWriterAssessmentOutcomeDropDown.SelectByText(value);
        }
        
        public void SetValueForReferredToDropDown(string value)
        {
            var referredToDropDownElement = Util.WaitUntilElementExists(chromeDriver, ReferredToDropDown, 10);
            var referredToDropDownDropDown = new SelectElement(referredToDropDownElement);
            referredToDropDownDropDown.SelectByText(value);
        }

        public bool IsSubmitToHBCFButtonEnabled()
        {
            var submitToHBCFButtonElement = Util.WaitUntilElementExists(chromeDriver, SubmitToHBCFButton, 10);
            return submitToHBCFButtonElement.Enabled;
        }

        public bool IsRequestDelegationApprovalButtonEnabled()
        {
            var requestDelegationApprovalButtonElement = Util.WaitUntilElementExists(chromeDriver, RequestDelegationApprovalButton, 10);
            return requestDelegationApprovalButtonElement.Enabled;
        }

        public void ClickSubmitToHBCFButton()
        {
            var submitToHBCFButtonElement = Util.WaitUntilElementExists(chromeDriver, SubmitToHBCFButton, 10);
            submitToHBCFButtonElement.Click();
        }

        public void ClickRequestDelegationApprovalButton()
        {
            var requestDelegationApprovalButtonElement = Util.WaitUntilElementExists(chromeDriver, RequestDelegationApprovalButton, 10);
            requestDelegationApprovalButtonElement.Click();
        }

        public void ClickKeyEventsLogButtonMenu()
        {
            var keyEventsLogButtonElement = Util.WaitUntilElementExists(chromeDriver, KeyEventLogMenuButton, 10);
            keyEventsLogButtonElement.Click();
        }

        public void SetLicenseNumberSearchEventLogs(string value)
        {
            var builderLicenseKeyEventLogElement = Util.WaitUntilElementExists(chromeDriver, BuilderLicenseKeyEventsLog, 10);
            builderLicenseKeyEventLogElement.Clear();
            builderLicenseKeyEventLogElement.SendKeys(value);
        }

        public void ClickButtonSearchKeyEventLogs()
        {
            var buttonSearchEventLogsElement = Util.WaitUntilElementExists(chromeDriver, SearchButtonKeyEventLogs, 10);
            buttonSearchEventLogsElement.Click();
        }

        public IWebElement GetEventLogtable()
        {
            var eventLogTable = Util.WaitUntilElementExists(chromeDriver, KeyEventLogsTable, 10);
            return eventLogTable;
        }

        //public bool CheckDelegationApprovalText(string delegationApproval)
        //{
        //    var delegationApprovalTextElement = Util.WaitUntilElementExists(chromeDriver, DelegationApprovalText, 10);
        //    var delegationApprovalText = delegationApprovalTextElement.Text;
        //    return delegationApprovalText.Contains(delegationApproval);
        //}

        public bool GetSearchResultKeyEventLog()
        {
            var eventlogs = GetEventLogtable();
            var lstTrElem = GetTrElement(eventlogs);
            var lstTdElem = GetTdElement(lstTrElem[1]);

            if (lstTdElem.Count > 1)
                return true;
            else
                return false;
        }

        private DateTime ConvertCreatedDateToDateTime(string createdDate)
        {
            var splitDateMonthYear = createdDate.Split(new char[] { ' ', '/', ':' }, StringSplitOptions.RemoveEmptyEntries);
            var day = int.Parse(splitDateMonthYear[0]);
            var month = int.Parse(splitDateMonthYear[1]);
            var year = int.Parse(splitDateMonthYear[2]);
            var hour = int.Parse(splitDateMonthYear[3]);
            var min = int.Parse(splitDateMonthYear[4]);
            var sec = int.Parse(splitDateMonthYear[5]);

            DateTime result = new DateTime(year, month, day, hour, min, sec);
            return result;

        }

        public void ClickButtonRequestNewBuilderMenu()
        {
            var btnRequestNewBuilder = Util.WaitUntilElementExists(chromeDriver, RequestNewBuilderMenu, 10);
            btnRequestNewBuilder.Click();
        }

        public void SetTextEntityNameRequestNewBuilder(string value)
        {
            var entityNameInput = Util.WaitUntilElementExists(chromeDriver, EntityNameInputRequestNewBuilder, 10);
            entityNameInput.Clear();
            entityNameInput.SendKeys(value);
        }

        public void SetTextABNACNRequestNewBuilder(string value)
        {
            var abnACNInput = Util.WaitUntilElementExists(chromeDriver, BuilderABNACNInputRequestNewBuilder, 10);
            abnACNInput.Clear();
            abnACNInput.SendKeys(value);
        }

        public void ClickAddFileRequestNewBuilder()
        {
            var addFileButton = Util.WaitUntilElementExists(chromeDriver, AddFileButtonRequestNewBuilder, 10);
            addFileButton.Click();
        }

        public void ClickButtonRequestNewBuilder()
        {
            var buttonRequestNewBuilder = Util.WaitUntilElementExists(chromeDriver, ButtonRequestNewBuilder, 10);
            buttonRequestNewBuilder.Click();
        }

        public bool CheckBuilderExistInRequestNewBuilderTable(string builderName, string abnacn)
        {
            var tbody = Util.WaitUntilElementExists(chromeDriver, TableRequestNewBuilder, 10);
            var trs = GetTrElement(tbody);
            for (int i = 1; i < trs.Count; i++)
            {
                var tds = GetTdElement(trs[i]);
                if (tds[1].Text == builderName && tds[2].Text == abnacn)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsRequestNewBuilderHeaderContainsColumns(string[] columns)
        {
            var tbody = Util.WaitUntilElementExists(chromeDriver, TableRequestNewBuilder, 10);
            var header = GetTrElement(tbody)[0];
            return Util.DoesRowContainsValues(header, columns, false);
        }

        public long GetEditAssessmentId()
        {
            var assessments = GetAssessmentTable();
            var lstTrElem = GetTrElement(assessments);
            var temp = 0;
            var totalCount = 0;
            var lstTdElemLast = GetTdElement(lstTrElem[lstTrElem.Count - 1]);
            if (lstTdElemLast.Count <= 1)
                totalCount = lstTrElem.Count - 2;
            else
                totalCount = lstTrElem.Count - 1;

            //click edit link for assessment has EA Finalised
            for (int i = 1; i <= totalCount; i++)
            {
                var lstTdElem = GetTdElement(lstTrElem[i]);
                if (lstTdElem[11].Text == "No")
                {
                    var assessmentIdString = lstTdElem[1].Text;
                    var assessmentId = long.Parse(assessmentIdString);
                    return assessmentId;
                }
                temp++;
            }
            if (temp == totalCount)
            {
                return 0;
            }
            return 0;
        }

        public void ClickCreateNewBuilderButtonMenu()
        {
            var createNewBuilder = Util.WaitUntilElementExists(chromeDriver, CreateNewBuilderButtonMenu, 10);
            createNewBuilder.Click();
        }

        public void SetValueInputLicenseNewBuilder(string value)
        {
            var inputLicense = Util.WaitUntilElementExists(chromeDriver, InputLicenseDialogNewBuilder, 10);
            inputLicense.SendKeys(value);
        }

        public void ClickSearchButtonLicenseDialogNewBuilder()
        {
            var searchButton = Util.WaitUntilElementExists(chromeDriver, SearchButtonLicenseDialogNewBuilder, 10);
            searchButton.Click();
        }

        public void WaitTillLookUpLicenseDialogClose()
        {
            try
            {
                var lookUpDialog = Util.WaitUntilElementExists(chromeDriver, LookUpLicenseDialog, 10);

                while (lookUpDialog.GetCssValue("display").Equals("block"))
                {
                    var element = chromeDriver.FindElement(By.Id("divLookupLicenseNumberDialog"));
                    if (element.Text.Contains("Failed"))
                        return;
                }
            }
            catch
            {
                return;
            }

        }

        public void ClickImageLookUpButton()
        {
            var imageLookUpButton = Util.WaitUntilElementExists(chromeDriver, ImageLookUpButton, 10);
            Actions action = new Actions(chromeDriver);
            action.MoveToElement(imageLookUpButton).Click().Perform();
            //imageLookUpButton.Click();
        }

        public void SetValueInputLookUpAbn(string value)
        {
            var input = Util.WaitUntilElementExists(chromeDriver, InputLookUpAbn, 10);
            if (input != null && input.Displayed && input.Enabled)
            {
                input.Clear();
                input.SendKeys(value);
            }
        }

        public void ClickSearchButtonAbnLookUp()
        {
            var button = Util.WaitUntilElementExists(chromeDriver, SearchButtonAbnLookUp, 10);
            button.Click();
        }

        public void WaitTillAbnLookUpDialogClose()
        {
            var dialog = Util.WaitUntilElementExists(chromeDriver, AbnLookUpDialog, 10);
            while (dialog.GetCssValue("display").Equals("block"))
            {

            }
        }

        public void SetValueBuilderEntityType(string value)
        {
            var builderEntityType = Util.WaitUntilElementExists(chromeDriver, BuilderEntityTypeSelect, 10);
            var builderEntityTypeSelect = new SelectElement(builderEntityType);
            builderEntityTypeSelect.SelectByText(value);
        }

        public void SetValuePrimaryBuilderSegmentOnApplication(string value)
        {
            var dropdown = Util.WaitUntilElementExists(chromeDriver, PrimaryBuilderSegmentOnApplicationSelect, 10);
            var dropdownElement = new SelectElement(dropdown);
            dropdownElement.SelectByText(value);
        }

        public bool CheckValidationLicenseLookUp()
        {
            var validation = Util.WaitUntilElementExists(chromeDriver, ValidationErrorLisenceLookUp, 10);
            if (validation.Text.Length > 0)
            {
                return true;
            }
            return false;
        }

        public void ClickButtonAddNewDOI()
        {
            var button = Util.WaitUntilElementExists(chromeDriver, ButtonAddNewDoiBuilderDetail, 10);
            button.Click();
        }

        public void SetValueDoiType(string value)
        {
            var doiTypeSelect = Util.WaitUntilElementExists(chromeDriver, DoiTypeSelect, 10);
            var doiTypeSelectElement = new SelectElement(doiTypeSelect);
            doiTypeSelectElement.SelectByText(value);
        }

        public void SetValueMaxAmoutInput(string value)
        {
            var input = Util.WaitUntilElementExists(chromeDriver, MaxAmoutInput, 10);
            input.Clear();
            input.SendKeys(value);
        }

        public void SetValuePolicyNumberInput(string value)
        {
            var input = Util.WaitUntilElementExists(chromeDriver, PolicyNumberInput, 10);
            input.Clear();
            input.SendKeys(value);
        }

        public void WaitTillNewDeedOfIndemnityDialogShowUp()
        {
            var dialog = Util.WaitUntilElementExists(chromeDriver, NewDeedOfIndemnity, 10);
            while (dialog.GetCssValue("display").Equals("none"))
            {

            }
        }

        public void SetValueLotStreetNoInput(string value)
        {
            var input = Util.WaitUntilElementExists(chromeDriver, LotStreetNo, 10);
            input.Clear();
            input.SendKeys(value);
        }

        public void SetStreetNameInput(string value)
        {
            var input = Util.WaitUntilElementExists(chromeDriver, StreetName, 10);
            input.Clear();
            input.SendKeys(value);
        }

        public void SetValueSuburbInput(string value)
        {
            var input = Util.WaitUntilElementExists(chromeDriver, Suburb, 10);
            input.Clear();
            input.SendKeys(value);
        }

        public void SetValuePostCodeInput(string value)
        {
            var input = Util.WaitUntilElementExists(chromeDriver, PostCode, 10);
            input.Clear();
            input.SendKeys(value);
        }

        public void ClickAddIndemnifierButton()
        {
            var button = Util.WaitUntilElementExists(chromeDriver, AddIndemnifierButton, 10);
            button.Click();
        }

        public void ClickCompanyRadioButton()
        {
            var button = Util.WaitUntilElementExists(chromeDriver, CompanyRadioButton, 10);
            button.Click();
        }

        public void SetValueNameInput(string value)
        {
            var input = Util.WaitUntilElementExists(chromeDriver, NameInput, 10);
            input.Clear();
            input.SendKeys(value);
        }

        public void SetValueABNInput(string value)
        {
            var input = Util.WaitUntilElementExists(chromeDriver, AbnInput, 10);
            input.Clear();
            input.SendKeys(value);
        }

        /// <summary>
        /// Get value of ABN input type is textbox in New DOI dialog
        /// </summary>
        public string GetValueABNInputNewDOI()
        {
            var document = Util.WaitUntilElementExists(chromeDriver, By.CssSelector("body"));
            var inputs = document.FindElements(AbnInput);
            return inputs.Last().GetProperty("value");
        }

        /// <summary>
        /// set value of ABN input type is textbox in New DOI dialog
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public void SetValueABNInputNewDOI(string value)
        {
            var document = Util.WaitUntilElementExists(chromeDriver, By.CssSelector("body"));
            var inputs = document.FindElements(AbnInput);
            var inputABN = inputs.Last();
            inputABN.Clear();
            inputABN.SendKeys(value);
        }

        public void SetValueAddressInput(string value)
        {
            var input = Util.WaitUntilElementExists(chromeDriver, AddressInput, 10);
            input.Clear();
            input.SendKeys(value);
        }

        public void SetValueStateSelect(string value)
        {
            var input = Util.WaitUntilElementExists(chromeDriver, StateSelect, 10);
            var selectElement = new SelectElement(input);
            selectElement.SelectByText(value);
        }

        public void SetValuePostCodeInputIndemnifier(string value)
        {
            var input = Util.WaitUntilElementExists(chromeDriver, PostCodeInput, 10);
            input.Clear();
            input.SendKeys(value);
        }

        public void ClickButtonOkAddIndemnifier()
        {
            var button = Util.WaitUntilElementExists(chromeDriver, ButtonOkAddIndemnifier, 10);
            button.Click();
        }

        public void ClickButtonOkNewDeedOfIndemninty()
        {
            var button = Util.WaitUntilElementExists(chromeDriver, ButtonOkNewDeedOfIndemnity, 10);
            button.Click();
        }

        public void WaitTillSaveDeedOfIndemnityDialogClose()
        {
            var dialog = Util.WaitUntilElementExists(chromeDriver, SaveDeedOfIndemnityDialog, 10);
            while (dialog.GetCssValue("display").Equals("block"))
            {

            }
        }

        public int CountDoiTBodyRow()
        {
            var tbody = Util.WaitUntilElementExists(chromeDriver, DoiTBody, 10);
            var trs = tbody.FindElements(By.TagName("tr")).Count;
            return trs;
        }

        public void ClickEditLastDoi()
        {
            var tbody = Util.WaitUntilElementExists(chromeDriver, DoiTBody, 10);
            var trs = tbody.FindElements(By.TagName("tr"));
            var lastDoi = trs[0];
            var buttonEdit = lastDoi.FindElement(By.CssSelector("div > button:nth-child(1)"));
            buttonEdit.Click();
        }

        public void ClickEditFirstDoi()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, DoiTableOverallOutcome);
            var rows = Util.GetRowsOfTable(table);
            var lastRow = rows[0];
            var buttonEdit = lastRow.FindElement(By.CssSelector("div > button:nth-child(1)"));
            buttonEdit.Click();
        }

        public bool ValidateMaxAmoutUpdated(string value)
        {
            var tbody = Util.WaitUntilElementExists(chromeDriver, DoiTBody, 10);
            var trs = tbody.FindElements(By.TagName("tr"));
            var lastDoi = trs[0];
            var columnsOfLastDoi = lastDoi.FindElements(By.TagName("td"));
            var amoutColumn = columnsOfLastDoi[5];
            return ConvertMoneyToNumber(amoutColumn.Text).Equals(value);
        }

        public string ConvertMoneyToNumber(string money)
        {
            string number = Regex.Replace(money, @"[\,\$]", "");
            return number;
        }

        public void ClickEmailButtonLastRowDoi()
        {
            var tbody = Util.WaitUntilElementExists(chromeDriver, DoiTBody, 10);
            var trs = tbody.FindElements(By.TagName("tr"));
            var lastDoi = trs[0];
            var buttonEdit = lastDoi.FindElement(By.CssSelector("div > button:nth-child(3)"));
            buttonEdit.Click();
        }

        public void ClickEmailButtonFirstRowDoiOverallOutcome()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, DoiTableOverallOutcome);
            var rows = Util.GetRowsOfTable(table);
            var lastRow = rows[0];
            var buttonEdit = lastRow.FindElement(By.CssSelector("div > button:nth-child(3)"));
            buttonEdit.Click();
        }

        public void WaitTillRenderingEmailTemplateDialogClose()
        {
            var dialog = Util.WaitUntilElementExists(chromeDriver, RenderingEmailTemplateDialog, 10);
            while (dialog.GetCssValue("display").Equals("block"))
            {

            }
        }

        public string GetBuilderName()
        {
            var builders = GetBuilderTable();
            var lstTrElem = GetTrElement(builders);
            var lstTdElemByRow = GetTdElement(lstTrElem[1]);
            return lstTdElemByRow[2].Text;
        }

        public string GetBuilderABN()
        {
            var builders = GetBuilderTable();
            var lstTrElem = GetTrElement(builders);
            var lstTdElemByRow = GetTdElement(lstTrElem[1]);
            return lstTdElemByRow[4].Text;
        }

        public string GetEmailContent()
        {
            var email = Util.WaitUntilElementExists(chromeDriver, EmailContent, 10);
            return email.Text;
        }

        public bool CheckEmailContentContainsNameAndAnbAndLicense(string name, string abn, string license)
        {
            var email = GetEmailContent();
            return (email.Contains(name) && email.Contains(abn) && email.Contains(license));
        }

        public void WaitTillQueueingEmailDialogClose()
        {
            var dialog = Util.WaitUntilElementExists(chromeDriver, QueueingEmailDialog, 10);
            while (dialog.GetCssValue("display").Equals("block"))
            {

            }
        }

        public void ClickSendButton()
        {
            var button = Util.WaitUntilElementExists(chromeDriver, SendButton, 10);
            button.Click();
        }

        public bool CheckEmailSucessDialog(string value)
        {
            try
            {
                var dialog = Util.WaitUntilElementExists(chromeDriver, EmailSuccessDialog, 10);
                return dialog.Text.Contains(value);
            }
            catch
            {
                var dialog = Util.WaitUntilElementExists(chromeDriver, EmailSuccessDialog2, 10);
                return dialog.Text.Contains(value);
            }
        }

        public bool CheckEmailSucessDialogOverallOutcome(string value)
        {
            var dialog = Util.WaitUntilElementExists(chromeDriver, EmailSuccessDialogOverallOutcome, 10);
            return dialog.Text.Contains(value);
        }

        public void ClickViewDrafLastDoi()
        {
            var tbody = Util.WaitUntilElementExists(chromeDriver, DoiTBody, 10);
            var trs = tbody.FindElements(By.TagName("tr"));
            var lastDoi = trs[0];
            var buttonEdit = lastDoi.FindElement(By.CssSelector("div > a:nth-child(2)"));
            buttonEdit.Click();
        }

        public void ClickViewFirstDoi()
        {
            var tbody = Util.WaitUntilElementExists(chromeDriver, DoiTableOverallOutcome, 10);
            var trs = tbody.FindElements(By.TagName("tr"));
            var lastDoi = trs[0];
            var buttonEdit = lastDoi.FindElement(By.CssSelector("div > a:nth-child(2)"));
            buttonEdit.Click();
        }

        public string GetIdLastDoi()
        {
            var tbody = Util.WaitUntilElementExists(chromeDriver, DoiTBody, 10);
            var trs = tbody.FindElements(By.TagName("tr"));
            var lastDoi = trs[0];
            var tds = lastDoi.FindElements(By.TagName("td"));
            var doiTd = tds[1];
            var doiId = doiTd.Text;
            return doiId;
        }

        public string GetFirstDoiId()
        {
            var tbody = Util.WaitUntilElementExists(chromeDriver, DoiTableOverallOutcome, 10);
            var trs = tbody.FindElements(By.TagName("tr"));
            var lastDoi = trs[0];
            var tds = lastDoi.FindElements(By.TagName("td"));
            var doiTd = tds[1];
            var doiId = doiTd.Text;
            return doiId;
        }

        public void ClickUploadLastDoi()
        {
            var tbody = Util.WaitUntilElementExists(chromeDriver, DoiTBody, 10);
            var trs = tbody.FindElements(By.TagName("tr"));
            var lastDoi = trs[0];
            var buttonUpload = lastDoi.FindElement(By.CssSelector("div > button:nth-child(5)"));
            buttonUpload.Click();
        }

        public void ClickUploadFirstDoi()
        {
            var tbody = Util.WaitUntilElementExists(chromeDriver, DoiTBody, 10);
            var trs = tbody.FindElements(By.TagName("tr"));
            var lastDoi = trs[0];
            var buttonUpload = lastDoi.FindElement(By.CssSelector("div > button:nth-child(5)"));
            buttonUpload.Click();
        }

        public bool CheckStatusActiveLastDoi()
        {
            var tbody = Util.WaitUntilElementExists(chromeDriver, DoiTBody, 10);
            var trs = tbody.FindElements(By.TagName("tr"));
            var lastDoi = trs[0];
            var tds = lastDoi.FindElements(By.TagName("td"));
            var statusTd = tds[6];
            var status = statusTd.Text;
            return status.Equals("active");
        }

        public void ClickDownloadLastDoi()
        {
            var tbody = Util.WaitUntilElementExists(chromeDriver, DoiTBody, 10);
            var trs = tbody.FindElements(By.TagName("tr"));
            var lastDoi = trs[0];
            var buttonDownload = lastDoi.FindElement(By.CssSelector("div > a:nth-child(6)"));
            buttonDownload.Click();
        }

        public void ClickAddBusinessTradingName()
        {
            var button = Util.WaitUntilElementExists(chromeDriver, AddBusinessTradingNameButton, 10);
            button.Click();
        }

        public void SetValueBusinessTradingNameInput(string value)
        {
            var input = Util.WaitUntilElementExists(chromeDriver, BusinessTradingNameInput, 10);
            input.Clear();
            input.SendKeys(value);
        }

        public void ClickButtonInsertTradingName()
        {
            var button = Util.WaitUntilElementExists(chromeDriver, ButtonInsertTradingName, 10);
            button.Click();
        }

        public bool CheckTextBusinessTradingName(string value)
        {
            var tbody = Util.WaitUntilElementExists(chromeDriver, TbodyTradingNameTable, 10);
            var trs = tbody.FindElements(By.TagName("tr"));

            if (trs.Count > 0)
            {
                var lbl = Util.WaitUntilElementExists(chromeDriver, By.Id("MainContent_eatBuilderInformationControl_gvTradingNames_lblTradingName_" + (trs.Count - 1)), 10);
                return lbl.Text.Equals(value);
            }
            return false;
        }

        public void ClickDeleteBusinessTradingName()
        {
            var tbody = Util.WaitUntilElementExists(chromeDriver, TbodyTradingNameTable, 10);
            var trs = tbody.FindElements(By.TagName("tr"));

            if (trs.Count > 0)
            {
                var btn = Util.WaitUntilElementExists(chromeDriver, By.Id("MainContent_eatBuilderInformationControl_gvTradingNames_btnGridBuilderLicenceDelete_" + (trs.Count - 1)), 10);
                btn.Click();
            }
        }

        public int GetRowsTbodyTradingName()
        {
            try
            {
                var tbody = Util.WaitUntilElementExists(chromeDriver, TbodyTradingNameTable, 10);
                var trs = tbody.FindElements(By.TagName("tr"));
                return trs.Count;
            }
            catch
            {
                return 0;
            }
        }

        public void SetValueEntityName(string value)
        {
            var input = Util.WaitUntilElementExists(chromeDriver, EntityNameInput, 10);
            input.Clear();
            input.SendKeys(value);
        }

        public void ClickHomeMenuButton()
        {
            var home = Util.WaitUntilElementExists(chromeDriver, HomeButtonMenu, 10);
            home.Click();
        }

        public void ClickTaskAdministratorMenu()
        {
            var button = Util.WaitUntilElementExists(chromeDriver, TaskAdministratorMenu, 10);
            button.Click();
        }

        public void ClickBuilderAndEligibilitiesMenu()
        {
            var button = Util.WaitUntilElementExists(chromeDriver, BuilderAndEligibilitiesMenu, 10);
            button.Click();
        }

        public void ClickChartMenu()
        {
            var button = Util.WaitUntilElementExists(chromeDriver, ChartMenu, 10);
            button.Click();
        }

        public bool CheckEligibilitiesReportTableContainsValue(string value)
        {
            var eligibilitiesReportTbody = Util.WaitUntilElementExists(chromeDriver, By.Id("MainContent_ReportDescriptionTb"), 10);
            var trs = eligibilitiesReportTbody.FindElements(By.CssSelector("tr"));

            for (int i = 1; i < trs.Count; i++)
            {
                try
                {
                    var tds = trs[i].FindElements(By.TagName("td"));
                    if (tds[1].Text.Equals(value))
                    {
                        return true;
                    }
                }
                catch
                {
                    continue;
                }

            }
            return false;
        }

        public bool CheckFinancialReportContainsValue(string value)
        {
            var financialReportTbody = Util.WaitUntilElementExists(chromeDriver, FinancialReportTbody, 10);
            var trs = financialReportTbody.FindElements(By.TagName("tr"));
            for (int i = 1; i < trs.Count; i++)
            {
                var tds = trs[i].FindElements(By.TagName("td"));
                if (tds[1].Text.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckErrorWhenFinalise()
        {
            var dialog = Util.WaitUntilElementExists(chromeDriver, ValidationErrorDialogOverallOutcome, 10);
            if (dialog.GetCssValue("display").Equals("block"))
            {
                return false;
            }
            return true;
        }

        public void ClickCopyPreviousAttachmentTermsAccepted()
        {
            Util.ClickCoOrdinates(CopyPreviousAttachmentTermsAccepted);
        }

        public void DeleteStatementAttachment(string fileName, string description)
        {
            var statements = GetStatementsTable();
            var lstTrElem = GetTrElement(statements);
            if (lstTrElem.Count > 1)
            {

                for (int i = 1; i < lstTrElem.Count; i++)
                {
                    var lstTdElem = GetTdElement(lstTrElem[i]);
                    if (lstTdElem[0].Text.Contains(description) && lstTdElem[1].Text.Contains(fileName))
                    {
                        lstTdElem[4].FindElement(By.TagName("input")).Click();
                        Thread.Sleep(3000);
                        break;
                    }
                }
            }
        }

        public void ClickViewAssessmentById(string id)
        {
            var assessments = GetAssessmentTable();
            var lstTrElem = GetTrElement(assessments);

            for (int i = 1; i < lstTrElem.Count; i++)
            {
                var tds = Util.GetTdsOfRow(lstTrElem[i]);
                if (tds[1].Text.Contains(id))
                {
                    tds[0].FindElement(By.TagName("a")).Click();
                    break;
                }
            }
        }

        public void ClickAddConditionButton()
        {
            try
            {
                var button = Util.WaitUntilElementExists(chromeDriver, AddConditionButton, 10);
                button.Click();
            }
            catch
            {
                try
                {
                    var button = Util.WaitUntilElementExists(chromeDriver, AddConditionButton2, 10);
                    button.Click();
                }
                catch
                {
                    var button = Util.WaitUntilElementExists(chromeDriver, AddConditionButton3, 10);
                    button.Click();
                }
            }

        }

        public void SelectConditionDropDown(string value)
        {
            var dd = Util.WaitUntilElementExists(chromeDriver, ConditionDropDown, 10);
            var ddElement = new SelectElement(dd);
            ddElement.SelectByText(value);
        }

        public void ClickButtonSaveConditionDialog()
        {
            var button = Util.WaitUntilElementExists(chromeDriver, ConditionDialogSaveButton, 10);
            button.Click();
        }

        public void SelectValueConditionStatus(string value)
        {
            var dd = Util.WaitUntilElementExists(chromeDriver, ConditionStatusSelect, 10);
            var ddElement = new SelectElement(dd);
            ddElement.SelectByText(value);
        }

        public void SetValueInputCondition(string value)
        {
            var input = Util.WaitUntilElementExists(chromeDriver, ValueConditionStatus, 10);
            input.Clear();
            input.SendKeys(value);
        }

        public void ClickButtonSaveBuilderCommunication()
        {
            var button = Util.WaitUntilElementExists(chromeDriver, SaveBuilderCommunication, 10);
            button.Click();
        }

        public void ClickPrintReport()
        {
            var button = Util.WaitUntilElementExists(chromeDriver, PrintEaReport, 10);
            button.Click();
        }

        public void ClickButtonManageGroup()
        {
            Util.Click(ManagementGroupMenu);
        }

        public void ClickWorkflowManagementMenu()
        {
            Util.Click(WorkflowManagementMenu);
        }

        public void ClickCloseLicenseLookUp()
        {
            Util.Click(CloseDialogLicenceLookUp);
        }

        public void ClickButtonPersonalStatement()
        {
            Util.Click(ButtonPersonalStatementMenu);
        }

        public bool CheckValueExistInStatementPersonalTable(string name, string dob)
        {
            var table = Util.WaitUntilElementExists(chromeDriver, StatementOfPersonalAssesstsAndLiabilitiesTable, 10);
            var tbody = table.FindElement(By.TagName("tbody"));
            var trs = tbody.FindElements(By.TagName("tr"));
            if (trs.Count > 0)
            {
                for (int i = 1; i < trs.Count; i++)
                {
                    var tds = trs[i].FindElements(By.TagName("td"));
                    if (tds[1].Text.Contains(name) && tds[2].Text.Contains(dob))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void ClickRestrictionToggle()
        {
            var isChecked = Util.IsChecked(RestrictionToggle);
            if (!isChecked)
            {
                Util.ClickCoOrdinates(RestrictionToggleButton);
            }
        }

        public void SetValueRestrictedJobValue(string value)
        {
            Util.SetValue(RestrictedJobValue, value);
        }

        public void SetValueRestrictedJobNumber(string value)
        {
            Util.SetValue(RestrictedJobNumer, value);
        }

        public void ClickbuttonSavechangeseligibilityDetail()
        {
            Util.Click(EligibilitySaveChanges);
        }

        public void SetValueEventDropDown(string value)
        {
            Util.Select(EventDropDown, value);
        }

        public bool CheckCOEUpdated(string builderName, string createdBy)
        {
            var table = GetEventLogtable();
            var body = table.FindElement(By.TagName("tbody"));
            var rows = body.FindElements(By.TagName("tr"));
            if (rows.Count > 0)
            {
                for (int i = 1; i < rows.Count; i++)
                {
                    var tds = GetTdElement(rows[i]);
                    if (tds[1].Text.ToLower().Contains(builderName.ToLower()) && tds[10].Text.Contains(createdBy))
                        return true;
                }
            }
            return false;
        }

        public bool ClickReport(string reportName)
        {
            var eligibilitiesReportTbody = Util.WaitUntilElementExists(chromeDriver, By.Id("MainContent_ReportDescriptionTb"), 10);
            var trs = eligibilitiesReportTbody.FindElements(By.CssSelector("tr"));

            for (int i = 1; i < trs.Count; i++)
            {
                try
                {
                    var tds = trs[i].FindElements(By.TagName("td"));
                    if (tds[1].Text.Equals(reportName))
                    {
                        tds[3].FindElement(By.CssSelector("input")).Click();
                        return true;
                    }
                }
                catch
                {
                    try
                    {
                        var tds = trs[i].FindElements(By.TagName("td"));
                        if (tds[1].Text.Equals(reportName))
                        {
                            tds[4].FindElement(By.CssSelector("input")).Click();
                            return true;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }

            }
            return false;
        }

        public void ClickTermsAcceptedDateEaTermsAcceptedNotFinalised()
        {
            //var table = Util.WaitUntilElementExists(chromeDriver, EaTermsAcceptedNotFinalisedTable, 100);
            var row = Util.WaitUntilElementExists(chromeDriver, By.CssSelector("#MainContent_ReportGrid_DXMainTable >tbody> tr:nth-child(3)"));
            row.Click();
        }

        public string GetBuilderLicenceReport()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, EaTermsAcceptedNotFinalisedTable, 100);
            for (int i = 3; i < 24; i++)
            {
                var row = Util.WaitUntilElementExists(chromeDriver, By.CssSelector("#MainContent_ReportGrid_DXMainTable >tbody> tr:nth-child(" + i + ")"));

                var licence = Util.GetTextIndexOfRow(row, 4);
                if (licence.Replace(" ", "").Length > 0 && !licence.Replace(" ", "").Equals("nbsp;"))
                {
                    return licence;
                }
            }
            return string.Empty;
        }

        public string GetCurrentOverallImpactFirstRowReport(string licence)
        {
            var table = Util.WaitUntilElementExists(chromeDriver, EaTermsAcceptedNotFinalisedTable, 100);
            for (int i = 3; i < 24; i++)
            {
                var row = Util.WaitUntilElementExists(chromeDriver, By.CssSelector("#MainContent_ReportGrid_DXMainTable >tbody> tr:nth-child(" + i + ")"));

                if (row.Text.Contains(licence))
                {
                    var builder = Util.GetTextIndexOfRow(row, 8);
                    return builder;
                }
            }
            return string.Empty;

        }

        public void SetBuilderLicenceHome(string value)
        {
            Util.SetValue(LicenceNumber, value);
        }

        public void ClickSearchHome()
        {
            Util.Click(ButtonSearchHome);
        }

        public string GetBuilderPremiumPricing()
        {
            var builderPremiumPricing = Util.WaitUntilElementExists(chromeDriver, BuilderPremiumPricing, 10);
            return builderPremiumPricing.Text;
        }

        public bool IsReportEmpty()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, EaTermsAcceptedNotFinalisedTable, 100);
            return table.Text.Contains("No data to display");
        }

        public void ClickSchedDate()
        {
            Util.Click(SchedDateColumn, 100);
        }

        public void ClickFirstRowReport()
        {
            var row = Util.WaitUntilElementExists(chromeDriver, By.Id("MainContent_ReportGrid_DXDataRow0"), 10);
            row.Click();
        }

        public void WaitForTableToAccessible()
        {
            var row = Util.WaitUntilElementExists(chromeDriver, FirstRowReport, 100);
        }

        public void WaitTillLoadingReportClose()
        {
            while (true)
            {
                try
                {
                    var dialog = Util.WaitUntilElementExists(chromeDriver, By.Id("MainContent_ReportGrid_LPV"), 10);
                }
                catch
                {
                    break;
                }
            }
        }

        public bool IsInitialReviewEnable()
        {
            return Util.IsEnable(InitiateReviewMenuButton);
        }

        public bool IsEligibilityDetailsEnable()
        {
            return Util.IsEnable(EligibilityReviewMenu);
        }

        public bool IsFinalcialInputEnable()
        {
            return Util.IsEnable(ButtonFinancialInputsMenu);
        }

        public bool IsPersonalStatementEnable()
        {
            return Util.IsEnable(ButtonPersonalStatementMenu);
        }

        public bool IsFinancialOutputEnable()
        {
            return Util.IsEnable(FinancialOutputMenu);
        }

        public bool IsOverallOutcomeEnable()
        {
            return Util.IsEnable(ButtonOverallInputMenu);
        }

        public bool IsPrintEaReportEnable()
        {
            return Util.IsEnable(PrintEaReport);
        }

        public bool IsMainContentPanelExist()
        {
            return Util.IsExist(MaincontentPanelOverallOutcome);
        }

        public void ClickGroupBuilder()
        {
            Util.Click(GroupBuilder);
        }

        public bool IsAddNewCommentButtonEnabled()
        {
            return Util.IsEnable(AddNewComment);
        }

        public void SetValueDoiTypeId(string value)
        {
            Util.Select(DoiTypeId, value);
        }

        public bool CheckValueMaxAmout(string value)
        {
            return Util.CheckValueInput(MaxAmount, value);
        }

        public void ClickAddIndemfierButton()
        {
            Util.Click(AddIndemnifierButtonOverallOutcome);
        }

        public void SetValueNameInputOverall(string value)
        {
            Util.SetValue(NameInputOverall, value);
        }

        public void SetValueABNOverall(string value)
        {
            Util.SetValue(ABN, value);
        }

        public void SetValueAddress(string value)
        {
            Util.SetValue(Address, value);
        }

        public void SetValuePostCode(string value)
        {
            Util.SetValue(PostCodeOverall, value);
        }

        public void ClickOkAddIndemnifier()
        {
            Util.Click(OkAddIndemnifier);
        }

        public void ClickOkNewDeed()
        {
            Util.Click(OkNewDeed);
        }

        public void WaitForBEATReportToDownload(string filename)
        {
            Util.WaitForDownloadToComplete(filename);
        }

        public void ClickRedistributeGroupLimitsButton()
        {
            Util.Click(RedistributeGroupLimitsButton);
        }

        public void SetJobAndtotalValueRow(string job, string value, int rowIndex)
        {
            var table = Util.WaitUntilElementExists(chromeDriver, JobLimitRedisTable);
            var jobs = table.FindElements(By.ClassName("jobLimitsApprNum"));
            var values = table.FindElements(By.ClassName("jobLimitsApprVal"));

            jobs[rowIndex].Clear();
            jobs[rowIndex].SendKeys(job);

            values[rowIndex].Clear();
            values[rowIndex].SendKeys(value);
        }

        public void WaitTillSavingJobLimitsDialogClose()
        {
            var dialog = Util.WaitUntilElementExists(chromeDriver, SavingJobLimitsDialog2);
            Util.WaitTillDialogClose(dialog);
            var dialog2 = Util.WaitUntilElementExists(chromeDriver, SavingJobLimitsDialog);
            Util.WaitTillDialogClose(dialog2);
        }

        private List<IWebElement> GetKeyEventLogRows()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, KeyEventLogsTable);
            var rows = Util.GetRowsOfTable(table);
            rows = rows.Where(x => x.GetAttribute("id").Contains("MainContent_xgridViewSearchResultsGridView_DXDataRow")).ToList();
            return rows.ToList();
        }

        public void ClickOkButtonOkRedis()
        {
            Util.Click(ButtonOKGtaRedis);
        }

        public bool VerifyAssessmentTableHasScheduledNotScheduledNoFinalised()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, AssessmentsTableBuilderDetail);
            var row = Util.GetRowsOfTable(table);
            for (int i = 1; i < row.Count; i++)
            {
                //keep parsing till counter footer
                try
                {
                    var tds = Util.GetTdsOfRow(row[i]);
                    if (tds[8].Text.Contains("Scheduled") || tds[8].Text.Contains("NotScheduled") && tds[11].Text.Contains("No"))
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
        /// Verify value of Finalised column is 'NO'
        /// </summary>
        /// <returns></returns>
        public bool VerifyAssessmentTableHasNoFinalised()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, AssessmentsTableBuilderDetail);
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

        public bool IsAssessmentGTA()
        {
            try
            {
                var panelGTA = Util.WaitUntilElementExists(chromeDriver, PanelGroup);
                return panelGTA.Displayed;
            }
            catch
            {
                // Non GTA
                return false;
            }
        }
        
        #region Task Administration Methods
        public void ClickBeingAssessedTaskPane()
        {
            Util.Click(BeingAssessed);
        }
        #endregion

        #region BUILDER DETAIL METHOD

        /// <summary>
        /// Check value selected of Year End Month control
        /// </summary>
        /// <returns></returns>
        public bool CheckValueSelectedYearEndMonth(string value)
        {
            var lstOption = GetOptionDDL(YearEndMonth);
            foreach (var iOpt in lstOption)
            {
                if (iOpt.Selected && iOpt.Text.ToUpper().Contains(value.ToUpper()))
                {
                    return true;
                }
            }
            return false;
        }

        public bool VerifyEventDataKeyEventLogs(string content)
        {
            var table = Util.WaitUntilElementExists(chromeDriver, KeyEventLogs);
            var rows = Util.GetRowsOfTable(table);
            if (rows.Count > 1)
            {
                var tds = Util.GetTdsOfRow(rows[2]);
                return tds[2].Text.Contains(content);
            }
            return false;
        }
        public bool VerifyAssessmentsTableHasNoPendingAssessmentBuilderDetail()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, AssessmentsTableBuilderDetail, 30);
            var row = Util.GetRowsOfTable(table);
            for (int i = 1; i < row.Count; i++)
            {
                //keep parsing till encounter footer
                try
                {
                    var tds = Util.GetTdsOfRow(row[i]);
                    if (tds[8].Text.Contains("Pending"))
                    {
                        return false;
                    }
                }
                catch
                {
                    return true;
                }
            }
            return true;
        }

        public void SetValueDistributorSelect(string value)
        {
            var distributor = Util.WaitUntilElementExists(chromeDriver, DistriButorSelect, 10);
            var distributorSelect = new SelectElement(distributor);
            distributorSelect.SelectByText(value);
        }

        public void ClickEditLinkAssessmentBuilderDetail()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, AssessmentsTableBuilderDetail);
            var row = Util.GetRowsOfTable(table);
            var tds = Util.GetTdsOfRow(row[1]);
            tds[0].Click();
        }

        public void ClickSaveBuilderDetailButton()
        {
            var buttonSave = Util.WaitUntilElementExists(chromeDriver, SaveBuilderDetailButton, 10);
            buttonSave.Click();
        }

        public void SetValueDistributorSelect(int index)
        {
            var distributor = Util.WaitUntilElementExists(chromeDriver, DistriButorSelect, 10);
            var distributorSelect = new SelectElement(distributor);
            distributorSelect.SelectByIndex(index);
        }

        public void ClickAddNewComment()
        {
            var addNewComment = Util.WaitUntilElementExists(chromeDriver, AddNewCommentButton, 10);
            addNewComment.Click();
        }

        public void SetCommentBuilder(string commentBuilder)
        {
            var commentTextbox = Util.WaitUntilElementExists(chromeDriver, BuilderCommentTextbox, 10);
            commentTextbox.SendKeys(commentBuilder);
        }

        public void ClickSaveCommentBuilder()
        {
            var saveButton = Util.WaitUntilElementExists(chromeDriver, SaveCommentBuilderButton, 10);
            saveButton.Click();
        }

        public void ClickContinueCategoryDialog()
        {
            Util.Click(ContinueButtonCategoryDialog);
        }

        public bool CheckFileDuplicate()
        {
            var popupDuplicate = Util.WaitUntilElementExists(chromeDriver, popupDuplicateUploadFile, 10);
            var displayPopupDuplicate = popupDuplicate.GetCssValue("display");
            if (displayPopupDuplicate == "none")
                return false;
            return true;
        }

        public bool CheckFileUploadShow(string fileName)
        {
            var fileUploads = GetFileUploadTable();
            var lstTrElem = GetTrElement(fileUploads);
            if (lstTrElem.Count > 0)
            {
                var lstTdElem = GetTdElement(lstTrElem[0]);
                var fileUploadName = lstTdElem[1].FindElement(By.TagName("a")).Text;
                if (fileName == fileUploadName)
                    return true;
                return false;
            }
            else
                return false;
        }

        public void ClickBuilderUploadFileButton()
        {
            var builderUploadFile = Util.WaitUntilElementExists(chromeDriver, builderUploadFileButton, 10);
            builderUploadFile.Click();
        }

        public bool VerifyInfoAddNewPrincipal(string name,
                                               string dob,
                                               string suburb,
                                               string role,
                                               string nsw,
                                               string yearLincenseHeld)
        {
            var principals = GetPrincipalTable();
            var lstTrElem = GetTrElement(principals);
            var lstTdElem = lstTrElem.Count > 1 ? GetTdElement(lstTrElem[1]) : null;

            if (lstTrElem.Count <= 1 || lstTdElem.Count <= 1)
            {
                return false;
            }
            else
            {
                var newPrincipal = lstTrElem[lstTrElem.Count - 1];
                var tdNewPrincipal = GetTdElement(newPrincipal);
                var checkActive = tdNewPrincipal[6].FindElement(By.TagName("span")).FindElement(By.TagName("input")).Selected;
                if (tdNewPrincipal[0].Text == name &&
                    tdNewPrincipal[2].Text == suburb &&
                    tdNewPrincipal[3].Text == role &&
                    tdNewPrincipal[4].Text == nsw &&
                    tdNewPrincipal[5].Text == yearLincenseHeld &&
                    checkActive)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public void ClickAddNewPrincipal()
        {
            var addNewPricipal = Util.WaitUntilElementExists(chromeDriver, AddNewPricipalButton, 10);
            addNewPricipal.Click();
        }

        public void SetPrincipalName(string name)
        {
            var principalName = Util.WaitUntilElementExists(chromeDriver, PrincipalNameInput, 10);
            principalName.Clear();
            principalName.SendKeys(name);
        }

        public void SetPrincipalDOB(string dob)
        {
            var principalDOB = Util.WaitUntilElementExists(chromeDriver, PrincipalDOBInput, 10);
            principalDOB.Clear();
            principalDOB.SendKeys(dob);
        }

        public void SetPrincipalSuburb(string suburb)
        {
            var principalSuburb = Util.WaitUntilElementExists(chromeDriver, PrincipalSuburbInput, 10);
            principalSuburb.Clear();
            principalSuburb.SendKeys(suburb);
        }

        public void SetPrincipalNSW(string nsw)
        {
            var principalNSW = Util.WaitUntilElementExists(chromeDriver, PrincipalNSWInput, 10);
            principalNSW.Clear();
            principalNSW.SendKeys(nsw);
        }

        public void SetPrincipalYearLicenseHeld(string yearLinceseHeld)
        {
            var principalYearLinceseHeld = Util.WaitUntilElementExists(chromeDriver, PrincipalYearLicenseHeldInput, 10);
            principalYearLinceseHeld.Clear();
            principalYearLinceseHeld.SendKeys(yearLinceseHeld);
        }

        public void SetPrincipalRole(string role)
        {
            var lstOptionRole = GetOptionDDL(PrincipalRoleDDL);
            for (int i = 0; i <= lstOptionRole.Count - 1; i++)
            {
                if (lstOptionRole[i].Text == role)
                {
                    lstOptionRole[i].Click();
                    break;
                }
            }
        }

        public List<IWebElement> GetOptionDDL(By element)
        {
            var ddl = Util.WaitUntilElementExists(chromeDriver, element, 10);
            List<IWebElement> lstOption = new List<IWebElement>(ddl.FindElements(By.TagName("option")));
            return lstOption;
        }
        
        public void SetPrincipalActive()
        {
            var principalActive = Util.WaitUntilElementExists(chromeDriver, PrincipalActiveCheckbox, 10);
            if (!principalActive.Selected)
                principalActive.Click();
        }

        public void UnSetPrincipalActive()
        {
            var principalActive = Util.WaitUntilElementExists(chromeDriver, PrincipalActiveCheckbox, 10);
            if (principalActive.Selected)
                principalActive.Click();
        }

        public void ClickSavePrincipal()
        {
            var principalSave = Util.WaitUntilElementExists(chromeDriver, PrincipalSaveButton, 10);
            principalSave.Click();
        }

        public IWebElement GetPrincipalTable()
        {
            return Util.WaitUntilElementExists(chromeDriver, PrincipalListTable, 20);
        }


        public bool VerifyInfoAddNewPrincipal(string name,
                                                string dob,
                                                string suburb,
                                                string role,
                                                string nsw,
                                                string yearLincenseHeld,
                                                bool activated)
        {
            var principals = GetPrincipalTable();
            var lstTrElem = GetTrElement(principals);
            var lstTdElem = lstTrElem.Count > 1 ? GetTdElement(lstTrElem[1]) : null;

            if (lstTrElem.Count <= 1 || lstTdElem.Count <= 1)
            {
                return false;
            }
            else
            {
                for (int i = 1; i < lstTrElem.Count; i++)
                {
                    var newPrincipal = lstTrElem[i];
                    var tdNewPrincipal = GetTdElement(newPrincipal);
                    var checkActive = tdNewPrincipal[6].FindElement(By.TagName("span")).FindElement(By.TagName("input")).Selected;
                    if (tdNewPrincipal[0].Text.Contains(name) &&
                        tdNewPrincipal[1].Text.Contains(dob) &&
                        tdNewPrincipal[2].Text.Contains(suburb) &&
                        tdNewPrincipal[3].Text.Contains(role) &&
                        tdNewPrincipal[4].Text.Contains(nsw) &&
                        tdNewPrincipal[5].Text.Contains(yearLincenseHeld) &&
                        checkActive == activated)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public IWebElement GetPricingTableHistoryThead()
        {
            return Util.WaitUntilElementExists(chromeDriver, pricingThreadTableHistory, 20);
        }

        public bool CheckColumnPricingTableHistory()
        {
            var tableHistoryThead = GetPricingTableHistoryThead();
            var lstTrElem = GetTrElement(tableHistoryThead);
            var lstThElem = GetThElement(lstTrElem[0]);

            if (lstThElem[0].Text.Contains("Date") &&
                lstThElem[1].Text.Contains("Years&Entity") &&
                lstThElem[2].Text.Contains("Years") &&
                lstThElem[3].Text.Contains("Entity") &&
                lstThElem[4].Text.Contains("ANTA") &&
                lstThElem[5].Text.Contains("NPM") &&
                lstThElem[6].Text.Contains("History") &&
                lstThElem[7].Text.Contains("Reviews") &&
                lstThElem[8].Text.Contains("BCRP") &&
                lstThElem[9].Text.Contains("Audit") &&
                lstThElem[10].Text.Contains("Overall"))
            {
                return true;
            }
            else
                return false;
        }

        public void ClickConfirmDistributorChangeDialog()
        {
            var button = Util.WaitUntilElementExists(chromeDriver, ConfirmButtonChangeDistributorDialog);
            button.Click();
        }

        public int ClickViewActiveEligibility()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, EligibilitiesTable, 10);
            var tbody = table.FindElement(By.TagName("tbody"));
            var trs = GetTrElement(tbody);
            for (int i = 1; i < trs.Count; i++)
            {
                var tds = GetTdElement(trs[i]);
                if (tds[6].Text.Contains("Active"))
                {
                    tds[0].Click();
                    return i;
                }
            }
            return 0;
        }

        public string GetIdFirstRoweligibilitiesTable()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, EligibilitiesTable);
            var rows = Util.GetRowsOfTable(table);
            var tds = Util.GetTdsOfRow(rows[1]);
            return tds[1].Text;
        }

        public bool CheckRestrictedStatusEligibility(int rowIndex, string value)
        {
            var table = Util.WaitUntilElementExists(chromeDriver, EligibilitiesTable, 10);
            var tbody = table.FindElement(By.TagName("tbody"));
            var trs = GetTrElement(tbody);
            return Util.CheckColumnValueOfRow(trs[rowIndex], 7, "Yes");
        }

        public bool ConfirmNewRowInEligibilities(string jobLimitNumber, string openJobLimitValueInput)
        {
            var table = Util.WaitUntilElementExists(chromeDriver, EligibilitiesTable);
            var rows = Util.GetRowsOfTable(table);

            var newRow = rows[1];
            var tds = Util.GetTdsOfRow(newRow);

            var openJobLimitValue = ConvertMoneyToNumber(tds[4].Text);

            return tds[3].Text.Contains(jobLimitNumber) && openJobLimitValue.Contains(openJobLimitValueInput);
        }

        public string GetStatusFirstRowEligibilitiesTable()
        {
            try
            {
                var table = Util.WaitUntilElementExists(chromeDriver, EligibilitiesTable);
                var rows = Util.GetRowsOfTable(table);
                var tds = Util.GetTdsOfRow(rows[1]);
                return tds[6].Text;
            }
            catch
            {
                return string.Empty;
            }
        }

        public bool VerifyFirstRowEligibilityTableHasCOE()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, EligibilitiesTable);
            var rows = Util.GetRowsOfTable(table);
            var tds = Util.GetTdsOfRow(rows[1]);
            return tds[9].Text.Length > 0;
        }

        public string GetStatusFirstRowAssessmentTable()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, AssessmentsTableBuilderDetail);
            var rows = Util.GetRowsOfTable(table);
            var row = rows[1];
            var tds = Util.GetTdsOfRow(row);
            return tds[8].Text;
        }

        public string GetValueApprovedJobValueBuilderUtilisation()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, BuilderUtilisationTable);
            var rows = Util.GetRowsOfTable(table);
            var approveJobRow = rows[0];
            var approvedJobValue = Util.GetTdsOfRow(approveJobRow)[1].Text;
            return approvedJobValue;
        }
        public string GetValueApprovedJobNumberBuilderUtilisation()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, BuilderUtilisationTable);
            var rows = Util.GetRowsOfTable(table);
            var approveJobRow = rows[0];
            var approvedJobValue = Util.GetTdsOfRow(approveJobRow)[3].Text;
            return approvedJobValue;
        }

        public string GetValueUsedJobValueBuilderUtilisation()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, BuilderUtilisationTable);
            var rows = Util.GetRowsOfTable(table);
            var approveJobRow = rows[1];
            var approvedJobValue = Util.GetTdsOfRow(approveJobRow)[1].Text;
            return approvedJobValue;
        }

        public string GetValueUsedJobNumberBuilderUtilisation()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, BuilderUtilisationTable);
            var rows = Util.GetRowsOfTable(table);
            var approveJobRow = rows[1];
            var approvedJobValue = Util.GetTdsOfRow(approveJobRow)[3].Text;
            return approvedJobValue;
        }

        public string GetValueOpenJobValueBuilderUtilisation()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, BuilderUtilisationTable);
            var rows = Util.GetRowsOfTable(table);
            var approveJobRow = rows[2];
            var approvedJobValue = Util.GetTdsOfRow(approveJobRow)[1].Text;
            return approvedJobValue;
        }

        public string GetValueOpenJobNumberBuilderUtilisation()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, BuilderUtilisationTable);
            var rows = Util.GetRowsOfTable(table);
            var approveJobRow = rows[2];
            var approvedJobValue = Util.GetTdsOfRow(approveJobRow)[3].Text;
            return approvedJobValue;
        }

        public void ClearBuilderFiles()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, FilesTable);
            var rows = Util.GetRowsOfTable(table);
            foreach (var row in rows)
            {
                var tds = Util.GetTdsOfRow(row);
                tds[5].Click();
                WaitForDeleteDialogClose();
            }
        }

        public void ToggleIncludeClosedJobs()
        {
            Util.ClickCoOrdinates(IncludeClosedJobs);
        }

        public void ClickExportExcel()
        {
            Util.Click(ExcelExport);
            Thread.Sleep(20000);
        }

        #region Methods of Builder Detail screen

        /// <summary>
        /// Check contain text in LicensedBuilderEntityName control
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public bool LicensedBuilderEntityNameContains(string value)
        {
            var licensedBuilderEntityName = Util.WaitUntilElementExists(chromeDriver, licensedBuilderEntityNameInput, 10);
            return licensedBuilderEntityName.GetProperty("value").ToUpper().Contains(value.ToUpper());
        }

        /// <summary>
        /// Check contain text in EaBuilderAbnTxt control
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public bool EABuilderABNContains(string value)
        {
            var eaBuilder = Util.WaitUntilElementExists(chromeDriver, EaBuilderAbnTxt, 10);
            return eaBuilder.GetProperty("value").ToUpper().Contains(value.ToUpper());
        }

        /// <summary>
        /// Check contain text in ASICEntityNameTxt control
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public bool ASICEntityNameContain(string value)
        {
            var asicEntity = Util.WaitUntilElementExists(chromeDriver, ASICEntityNameTxt, 10);
            return asicEntity.GetProperty("value").ToUpper().Contains(value.ToUpper());
        }

        /// <summary>
        /// Check contain text in BuilderPostcodeTxt control
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public bool BuilderPostcodeContain(string value)
        {
            var postCode = Util.WaitUntilElementExists(chromeDriver, BuilderPostcodeTxt, 10);
            return postCode.GetProperty("value").ToUpper().Contains(value.ToUpper());
        }

        /// <summary>
        /// Check contain text in BuilderStateDdl control
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public bool BuilderStateContain(string value)
        {
            var state = Util.WaitUntilElementExists(chromeDriver, BuilderStateDdl, 10);
            var dropdownElement = new SelectElement(state);
            return dropdownElement.SelectedOption.Text.ToUpper().Contains(value.ToUpper());
        }

        /// <summary>
        /// Check contain text in InsurerDdl control
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public bool InsurerContain(string value)
        {
            var insurer = Util.WaitUntilElementExists(chromeDriver, InsurerDdl, 10);
            var dropdownElement = new SelectElement(insurer);
            return dropdownElement.SelectedOption.Text.ToUpper().Contains(value.ToUpper());
        }

        #endregion

        #region Methods BUILDER PRINCIPAL DETAILS

        public bool BuidlerPrincipalDetailsHasActiveRow()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, BuilderPrincipalDetailsTable);
            var rows = Util.GetRowsOfTable(table);
            for (int i = 1; i < rows.Count; i++)
            {
                var row = rows[i];
                var tds = Util.GetTdsOfRow(row);
                var checkbox = tds[6].FindElement(By.CssSelector("input[type='checkbox']"));
                if (checkbox.Selected) return true;
            }
            return false;
        }

        public int CountActivePrincipal()
        {
            var activeRowCount = 0;
            var table = Util.WaitUntilElementExists(chromeDriver, BuilderPrincipalDetailsTable);
            var rows = Util.GetRowsOfTable(table);
            for (int i = 1; i < rows.Count; i++)
            {
                var row = rows[i];
                var tds = Util.GetTdsOfRow(row);
                var checkbox = tds[6].FindElement(By.CssSelector("input[type='checkbox']"));
                if (checkbox.Selected) activeRowCount++;
            }
            return activeRowCount;
        }

        /// <summary>
        /// Check exists any Delete button in Principal table
        /// </summary>
        /// <returns></returns>
        public bool IsHasDeleteButtonInPricipalTable()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, BuilderPrincipalDetailsTable);
            if (table.Displayed)
            {
                var rows = Util.GetRowsOfTable(table);
                if (rows != null)
                {
                    foreach (var itemRow in rows)
                    {
                        var lstTd = GetTdElement(itemRow);
                        if (lstTd != null && lstTd.Count > 7)
                        {
                            var lstInputImgs = lstTd[7].FindElements(By.TagName(Common.TagNameInput));
                            if (lstInputImgs != null && lstInputImgs.Count > 1)
                            {
                                if (lstInputImgs[1].GetProperty(Common.LblTitle).ToUpper() == Common.LblDelete.ToUpper())
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        public void RemoveActiveBuilderPrincipal()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, BuilderPrincipalDetailsTable);
            var rows = Util.GetRowsOfTable(table);
            for (int i = 1; i < rows.Count; i++)
            {
                var row = rows[i];
                var tds = Util.GetTdsOfRow(row);
                var checkbox = tds[6].FindElement(By.CssSelector("input[type='checkbox']"));
                if (checkbox.Selected)
                {
                    var deleteButton = tds[7].FindElement(By.CssSelector("input:nth-child(2)"));
                    deleteButton.Click();
                    WaitTillBusyDialogClose();
                    return;
                }
            }
        }

        #endregion

        /// <summary>
        /// return row index for next line of the test to use //HWIT-4604
        /// </summary>
        public int ClickEditFirstActiveBuilderPrincipal()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, BuilderPrincipalDetailsTable);
            var rows = Util.GetRowsOfTable(table);
            for (int i = 1; i < rows.Count; i++)
            {
                var row = rows[i];
                var tds = Util.GetTdsOfRow(row);
                var checkbox = tds[6].FindElement(By.CssSelector("input[type='checkbox']"));
                if (checkbox.Selected)
                {
                    var editButton = tds[7].FindElement(By.CssSelector("input:nth-child(1)"));
                    editButton.Click();
                    WaitTillBusyDialogClose();
                    return i;
                }
            }
            return 0;
        }

        public int ClickEditFirstInActiveBuilderPrincipal()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, BuilderPrincipalDetailsTable);
            var rows = Util.GetRowsOfTable(table);
            for (int i = 1; i < rows.Count; i++)
            {
                var row = rows[i];
                var tds = Util.GetTdsOfRow(row);
                var checkbox = tds[6].FindElement(By.CssSelector("input[type='checkbox']"));
                if (!checkbox.Selected)
                {
                    var editButton = tds[7].FindElement(By.CssSelector("input:nth-child(1)"));
                    editButton.Click();
                    WaitTillBusyDialogClose();
                    return i;
                }
            }
            return 0;
        }

        public void SetValueDobPrincipalDetail(int rowIndex, string value)
        {
            var table = Util.WaitUntilElementExists(chromeDriver, BuilderPrincipalDetailsTable);
            var rows = Util.GetRowsOfTable(table);
            var row = rows[rowIndex];
            var tds = Util.GetTdsOfRow(row);
            var input = tds[1].FindElement(By.CssSelector("input:nth-child(1)"));
            Util.SetValue(input, value);
        }

        public void SetValueSuburbPrincipalDetail(int rowIndex, string value)
        {
            var table = Util.WaitUntilElementExists(chromeDriver, BuilderPrincipalDetailsTable);
            var rows = Util.GetRowsOfTable(table);
            var row = rows[rowIndex];
            var tds = Util.GetTdsOfRow(row);
            var input = tds[2].FindElement(By.CssSelector("input:nth-child(1)"));
            Util.SetValue(input, value);
        }

        public void ClickSavePrincipalDetail(int rowIndex)
        {
            var table = Util.WaitUntilElementExists(chromeDriver, BuilderPrincipalDetailsTable);
            var rows = Util.GetRowsOfTable(table);
            var row = rows[rowIndex];
            var tds = Util.GetTdsOfRow(row);
            tds[7].FindElement(By.CssSelector("input:nth-child(1)")).Click();
        }

        public bool VerifyDobPrincipalDetail(int rowIndex, string value)
        {
            var table = Util.WaitUntilElementExists(chromeDriver, BuilderPrincipalDetailsTable);
            var rows = Util.GetRowsOfTable(table);
            var row = rows[rowIndex];
            var tds = Util.GetTdsOfRow(row);
            return tds[1].Text.Contains(value);
        }

        /// <summary>
        /// Compare value of column and a text
        /// </summary>
        /// <param name="rowIndex">Index of row</param>
        /// <param name="colIndex">Index of column</param>
        /// <param name="content">Text need compare</param>
        /// <returns></returns>
        public bool VerifyValueOfColumnInKeyEventLogs(int rowIndex, int colIndex, string content)
        {
            var table = Util.WaitUntilElementExists(chromeDriver, KeyEventLogs);
            var rows = Util.GetRowsOfTable(table);
            if (rows.Count > 1)
            {
                var tds = Util.GetTdsOfRow(rows[rowIndex]);
                return tds[colIndex].Text.Contains(content);
            }
            return false;
        }
        #endregion

        #region INITIATE REVIEW METHOD
        public bool CheckSubmitToBrokerButton()
        {
            var submitToBroker = Util.WaitUntilElementExists(chromeDriver, submitToBrokerButton, 10);
            return submitToBroker.Enabled;
        }

        public void ClickSubmitToBrokerButton()
        {
            var submitToBroker = Util.WaitUntilElementExists(chromeDriver, submitToBrokerButton, 10);
            submitToBroker.Click();
        }

        public bool VerifyColorInsuranceAgentLabel()
        {
            var insuranceAgent = Util.WaitUntilElementExists(chromeDriver, insuranceAgentLabel, 10);
            var backgroundColor = insuranceAgent.GetCssValue("background-color");
            var colorHex = ConvertRgbaToHex(backgroundColor);
            if (colorHex == "#0FF00")
                return true;
            return false;
        }

        public bool VerifyColorDistributorLabel()
        {
            var distributor = Util.WaitUntilElementExists(chromeDriver, distributorLabel, 10);
            var backgroundColor = distributor.GetCssValue("background-color");
            var colorHex = ConvertRgbaToHex(backgroundColor);
            if (colorHex == "#FFFF00")
                return true;
            return false;
        }

        public bool VerifyFileUploadStatement(string fileName, string description)
        {
            var statements = GetStatementsTable();
            var lstTrElem = GetTrElement(statements);
            if (lstTrElem.Count > 1)
            {
                for (int i = 1; i < lstTrElem.Count; i++)
                {
                    var lstTdElem = GetTdElement(lstTrElem[i]);
                    //if (lstTdElem[0].Text == description && lstTdElem[1].FindElement(By.TagName("a")).Text == fileName)
                    if (lstTdElem[1].FindElement(By.TagName("a")).Text == fileName)
                        return true;
                }
                return false;
            }
            else
                return false;
        }

        public void WaitForUploadFinancialStatement()
        {
            while (true)
            {
                try
                {
                    var statusBar = Util.WaitUntilElementExists(chromeDriver, UploadStatusBar);
                    if (statusBar.Text.Contains("ERROR"))
                    {
                        return;
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        public void ClickButtonAddNewCommentInitiateReview()
        {
            Util.Click(AddNewComment);
        }

        public void ClickButtonSubmitToInsurerInitiateReview()
        {
            Util.Click(SubmitToInsurerButton);
        }

        public bool VerifyAssignedToSuttont()
        {
            var messagePanel = Util.WaitUntilElementExists(chromeDriver, panelMessageInitiateScreen);
            return messagePanel.Text.Contains("assigned to suttont");
        }

        public bool VerifyDistributorCantBeUpdated()
        {
            var panel = Util.WaitUntilElementExists(chromeDriver, panelMessageInitiateScreen);
            return panel.Text.Contains("cannot be updated due to existing assessment.");
        }

        public bool VerifyClosedStatusOnPanel()
        {
            var panel = Util.WaitUntilElementExists(chromeDriver, panelMessageInitiateScreen);
            return panel.Text.Contains("Review status is 'closed'");
        }

        public bool VerifyHBCFLabel()
        {
            var distributor = Util.WaitUntilElementExists(chromeDriver, hbcfLabel, 10);
            var backgroundColor = distributor.GetCssValue("background-color");
            //var colorHex = ConvertRgbaToHex(backgroundColor);
            //if (colorHex == "#1E90FF")
            //    return true;
            //return false;
            return backgroundColor.Contains("dodgerblue");
        }
        #endregion

        #region ELIGIBILITY DETAIL METHOD
        public void ClickCopyAllLimitsLink()
        {
            var copyAllLimitsElement = Util.WaitUntilElementExists(chromeDriver, CopyAllLimits, 10);
            copyAllLimitsElement.Click();
            WaitTillBusyDialogClose();
        }

        public void ClickButtonSaveEligibilityReview()
        {
            var buttonSaveLimits = Util.WaitUntilElementExists(chromeDriver, ButtonSaveLimits, 10);
            Actions action = new Actions(chromeDriver);
            action.MoveToElement(buttonSaveLimits).Click().Perform();
        }

        public bool VerifyBeginAssessmentIsEnabled()
        {
            var beginAssessment = Util.WaitUntilElementExists(chromeDriver, beginAssessmentButton, 10);
            return beginAssessment.Enabled;
        }

        public void ClickBeginAssessment()
        {
            var beginAssessment = Util.WaitUntilElementExists(chromeDriver, beginAssessmentButton, 10);
            beginAssessment.Click();
        }
        #endregion

        #region FINANCIAL INPUT METHOD
        public void SetValueSalesRow(string value)
        {
            var lstTrTableRow = GetTableRows();
            foreach (var row in lstTrTableRow)
            {
                var lstTdElem = GetTdElement(row);
                var inputCol1 = lstTdElem[1].FindElement(By.TagName("input"));
                var inputCol1Id = inputCol1.GetAttribute("id");
                if (inputCol1Id.Contains("BaseSales"))
                {
                    inputCol1.Clear();
                    inputCol1.SendKeys(value);

                    var inputCol2 = lstTdElem[3].FindElement(By.TagName("input"));
                    inputCol2.Clear();
                    inputCol2.SendKeys(value);

                    var inputCol3 = lstTdElem[5].FindElement(By.TagName("input"));
                    inputCol3.Clear();
                    inputCol3.SendKeys(value);

                    var inputCol4 = lstTdElem[7].FindElement(By.TagName("input"));
                    inputCol4.Clear();
                    inputCol4.SendKeys(value);

                    break;
                }
            }
        }

        /// <summary>
        /// Se value for first Base Sales textbox
        /// </summary>
        /// <param name="value"></param>
        public void SetValueForFirstBaseSales(string value)
        {
            var lstTrTableRow = GetTableRows();
            foreach (var row in lstTrTableRow)
            {
                var lstTdElem = GetTdElement(row);
                var inputCol1 = lstTdElem[1].FindElement(By.TagName("input"));
                var inputCol1Id = inputCol1.GetAttribute("id");
                if (inputCol1Id.Contains("BaseSales"))
                {
                    inputCol1.Clear();
                    inputCol1.SendKeys(value);
                    break;
                }
            }
        }

        /// <summary>
        /// Set value for first Opening Stock textbox
        /// </summary>
        /// <param name="value"></param>
        public void SetValueForFirstOpeningStock(string value)
        {
            var lstTrTableRow = GetTableRows();
            foreach (var row in lstTrTableRow)
            {
                var lstTdElem = GetTdElement(row);
                var inputCol1 = lstTdElem[1].FindElement(By.TagName("input"));
                var inputCol1Id = inputCol1.GetAttribute("id");
                if (inputCol1Id.Contains("OpeningStock"))
                {
                    inputCol1.Clear();
                    inputCol1.SendKeys(value);
                    break;
                }
            }
        }

        public void SetValueOpeningStock(string value)
        {
            var lstTrTableRow = GetTableRows();
            foreach (var row in lstTrTableRow)
            {
                var lstTdElem = GetTdElement(row);
                var inputCol1 = lstTdElem[1].FindElement(By.TagName("input"));
                var inputCol1Id = inputCol1.GetAttribute("id");
                if (inputCol1Id.Contains("OpeningStock"))
                {
                    inputCol1.Clear();
                    inputCol1.SendKeys(value);

                    var inputCol2 = lstTdElem[3].FindElement(By.TagName("input"));
                    inputCol2.Clear();
                    inputCol2.SendKeys(value);

                    var inputCol3 = lstTdElem[5].FindElement(By.TagName("input"));
                    inputCol3.Clear();
                    inputCol3.SendKeys(value);

                    var inputCol4 = lstTdElem[7].FindElement(By.TagName("input"));
                    inputCol4.Clear();
                    inputCol4.SendKeys(value);

                    break;
                }
            }
        }

        /// <summary>
        /// Get button in row with SubHeaderRow class
        /// </summary>
        /// <param name="subHeaderRow">Default = Sales and = Other Income, Expenses, Tax Dividends, ...</param>
        /// <returns></returns>
        public IWebElement GetSaveButtonWithSubHeaderRow(string subHeaderRow = "Sales")
        {
            var lstTrSubHeaderRow = GetSubHeaderRow();
            IWebElement salesSave = null;

            foreach (var trHeaderRow in lstTrSubHeaderRow)
            {
                var lstTdElem = GetTdElement(trHeaderRow);
                if (lstTdElem[0].Text == subHeaderRow)
                {
                    salesSave = lstTdElem[1].FindElement(By.TagName("input"));
                    break;
                }
            }

            return salesSave;
        }

        public void ClickSaleSaveButton()
        {
            var button = GetSaveButtonWithSubHeaderRow();
            button.Click();
        }

        /// <summary>
        /// Click Save button in Current Assets section
        /// </summary>
        public void ClickCurentAssetsSaveButton()
        {
            var button = GetSaveButtonWithSubHeaderRow(SectionNameFinancialInputs.CurrentAssets);
            Actions action = new Actions(chromeDriver);
            action.MoveToElement(button).Click().Perform();
        }

        /// <summary>
        /// Check exists value in block
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public bool CheckExistsValue(string value)
        {
            var elementsTr = GetElementsByProperty(FinancialsTableTrModuleHeader);
            foreach (var elem in elementsTr)
            {
                if (elem.Text.ToUpper().Contains(value.ToUpper()))
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region OVERALL OUTCOME METHOD
        public bool IsDelegationApprovalCheckboxChecked()
        {
            try
            {
                var delegationApprovalCheckboxElement = Util.WaitUntilElementExists(chromeDriver, DelegationApprovalCheckbox, 10);
                var result = delegationApprovalCheckboxElement.Selected;
                return result;
            }
            catch
            {
                var delegationApprovalCheckboxElement = Util.WaitUntilElementExists(chromeDriver, DelegationApprovalCheckbox2, 10);
                var result = delegationApprovalCheckboxElement.Selected;
                return result;
            }

        }

        public void UncheckDelegationApprovalCheckbox()
        {
            try
            {
                var delegationApprovalCheckboxElement = Util.WaitUntilElementExists(chromeDriver, DelegationApprovalCheckbox, 10);
                var selected = delegationApprovalCheckboxElement.Selected;
                if (selected)
                {
                    delegationApprovalCheckboxElement.Click();
                }
            }
            catch
            {
                var delegationApprovalCheckboxElement = Util.WaitUntilElementExists(chromeDriver, DelegationApprovalCheckbox2, 10);
                var selected = delegationApprovalCheckboxElement.Selected;
                if (selected)
                {
                    delegationApprovalCheckboxElement.Click();
                }
            }
        }

        public void ClickDelegationApprovalCheckbox()
        {
            try
            {
                var checkbox = Util.WaitUntilElementExists(chromeDriver, DelegationApprovalCheckbox, 10);
                checkbox.Click();
            }
            catch
            {
                var checkbox = Util.WaitUntilElementExists(chromeDriver, DelegationApprovalCheckbox2, 10);
                checkbox.Click();
            }
        }
        
        public void CheckAndClickAreThereConditionCheckBox()
        {
            try
            {
                var input = Util.WaitUntilElementExists(chromeDriver, AreThereConditionsCheckbox, 10);
                if (!input.Selected)
                {
                    input.Click();
                }
            }
            catch
            {
                var input = Util.WaitUntilElementExists(chromeDriver, AreThereConditionsCheckbox2, 10);
                if (!input.Selected)
                {
                    input.Click();
                }
            }
        }

        public void UnClickConditionCheckbox()
        {
            try
            {
                var input = Util.WaitUntilElementExists(chromeDriver, AreThereConditionsCheckbox, 10);
                if (input.Selected)
                {
                    input.Click();
                }
            }
            catch
            {
                var input = Util.WaitUntilElementExists(chromeDriver, AreThereConditionsCheckbox2, 10);
                if (input.Selected)
                {
                    input.Click();
                }
            }

        }

        public bool IsConditionCheckboxChecked()
        {
            try
            {
                var input = Util.WaitUntilElementExists(chromeDriver, AreThereConditionsCheckbox, 10);
                if (input.Selected)
                {
                    return true;
                }
            }
            catch
            {
                var input = Util.WaitUntilElementExists(chromeDriver, AreThereConditionsCheckbox2, 10);
                if (input.Selected)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsCheckedAreThereAnyConditionCheckbox()
        {
            try
            {
                return Util.IsChecked(AreThereConditionsCheckbox);
            }
            catch
            {
                return Util.IsChecked(AreThereConditionsCheckbox2);
            }
        }

        public void ClickAreThereConditionCheckbox()
        {
            try
            {
                Util.Click(AreThereConditionsCheckbox);
            }
            catch
            {
                try
                {
                    Util.Click(AreThereConditionsCheckbox2);
                }
                catch
                {
                    Util.Click(AreThereConditionsCheckbox3);
                }

            }
        }

        public void ClearRecuringConditionForAssessment()
        {
            try
            {
                var table = Util.WaitUntilElementExists(chromeDriver, ConditionTable);

                while (true)
                {
                    var button = Util.WaitUntilElementExists(chromeDriver, DeleteConditon);
                    button.Click();
                    WaitTillBusyDialogClose();
                    Thread.Sleep(1000);
                }
            }
            catch
            {
                try
                {
                    var table = Util.WaitUntilElementExists(chromeDriver, ConditionTable2);

                    while (true)
                    {
                        var button = Util.WaitUntilElementExists(chromeDriver, DeleteConditon2);
                        button.Click();
                        WaitTillBusyDialogClose();
                        Thread.Sleep(1000);
                    }
                }
                catch
                {
                    try
                    {
                        var table = Util.WaitUntilElementExists(chromeDriver, ConditionTable3);

                        while (true)
                        {
                            var button = Util.WaitUntilElementExists(chromeDriver, DeleteConditon3);
                            button.Click();
                            WaitTillBusyDialogClose();
                            Thread.Sleep(1000);
                        }
                    }
                    catch
                    {
                        return;
                    }

                }
            }

        }

        public void ClickEditRecurringCondition()
        {
            try
            {
                var table = Util.WaitUntilElementExists(chromeDriver, ConditionTable, 10);
                if (table.Text.Contains("No Recuring Conditions for this Assessment"))
                    return;
                else
                {
                    var trs = Util.GetRowsOfTable(table);
                    foreach (var row in trs)
                    {
                        var tds = Util.GetTdsOfRow(row);
                        var editButton = tds[1].FindElement(By.CssSelector("input[title='Edit']"));
                        editButton.Click();
                    }
                }
            }
            catch
            {
                var table = Util.WaitUntilElementExists(chromeDriver, ConditionTable2, 10);
                if (table.Text.Contains("No Recuring Conditions for this Assessment"))
                    return;
                else
                {
                    var trs = Util.GetRowsOfTable(table);
                    foreach (var row in trs)
                    {
                        var tds = Util.GetTdsOfRow(row);
                        var editButton = tds[1].FindElement(By.CssSelector("input[title='Edit']"));
                        editButton.Click();
                    }
                }
            }

        }

        public void SetValueKeyIssuesOrOtherConditions(string value)
        {
            try
            {
                var textbox = Util.WaitUntilElementExists(chromeDriver, KeyIssuesOrOtherconditions);
                textbox.Clear();
                textbox.SendKeys(value);
            }
            catch
            {
                try
                {
                    var input = Util.WaitUntilElementExists(chromeDriver, KeyIssueOrOtherCondition, 10);
                    input.Clear();
                    input.SendKeys(value);
                }
                catch
                {
                    var input = Util.WaitUntilElementExists(chromeDriver, KeyIssueOrOtherCondition2, 10);
                    input.Clear();
                    input.SendKeys(value);
                }
            }
        }

        public void ClickSaveBuilderCommunicationButton()
        {
            try
            {
                Util.Click(SaveBuilderCommunicationButton);
            }
            catch
            {
                try
                {
                    Util.Click(SaveBuilderCommunicationButton2);
                }
                catch
                {
                    Util.Click(SaveBuilderCommunicationButton3);
                }
            }

        }

        public void SetValueNote(string value)
        {
            try
            {
                Util.SetValue(NoteTextarea, value);
            }
            catch
            {
                Util.SetValue(NoteTextarea2, value);
            }
        }

        public void ClickSaveNotButtonOverallOutcome()
        {
            try
            {
                Util.Click(SaveNoteOverallOutcome);
            }
            catch
            {
                Util.Click(SaveNoteOverallOutcome2);
            }
        }

        public void SetValueForHBCFOpenJobLimit(string limitValue, string limitNumber)
        {
            var openJobLimitValue = Util.WaitUntilElementExists(chromeDriver, HBCFApprovedOpenJobLimitValue, 10);
            var openJobLimitNumber = Util.WaitUntilElementExists(chromeDriver, HBCFApprovedOpenJobLimitNumber, 10);

            if (openJobLimitValue.Enabled)
            {
                openJobLimitValue.Clear();
                openJobLimitValue.SendKeys(limitValue);
                Thread.Sleep(2000);
            }

            if (openJobLimitNumber.Enabled)
            {
                openJobLimitNumber.Clear();
                openJobLimitNumber.SendKeys(limitNumber);
                Thread.Sleep(2000);
            }
        }

        public void ClickSaveOutcomeDetailsButton()
        {
            var pleaseNoteRow = Util.WaitUntilElementExists(chromeDriver, PleaseNoteRow);
            if (pleaseNoteRow.Text.Contains("Please note"))
            {
                Util.Click(SaveOutcomeDetailsButtonHasPleaseNote);
            }
            else
            {
                var saveOutcomeDetailsButtonElement = Util.WaitUntilElementExists(chromeDriver, SaveOutcomeDetailsButton, 10);
                 
                Actions action = new Actions(chromeDriver);
                action.MoveToElement(saveOutcomeDetailsButtonElement).Click().Perform();
                //saveOutcomeDetailsButtonElement.Click();
            }
        }

        public void SetValueAssessmentStatus(string value)
        {
            try
            {
                var select = Util.WaitUntilElementExists(chromeDriver, AssessmentStatus, 10);
                var selectElement = new SelectElement(select);
                selectElement.SelectByText(value);
            }
            catch
            {
                var select = Util.WaitUntilElementExists(chromeDriver, AssessmentStatus2, 10);
                var selectElement = new SelectElement(select);
                selectElement.SelectByText(value);
            }
        }

        public void ClickFinaliseAssessmentButton()
        {
            var button = Util.WaitUntilElementExists(chromeDriver, FinaliseAssessmentButton, 10);
            button.Click();
        }

        public bool IsEnabledFinaliseAssessmentButton()
        {
            try
            {
                return Util.IsEnable(FinaliseAssessmentButton);
            }
            catch
            {
                return false;
            }
        }

        public void SetValueDateTermsOffered(string value)
        {
            var input = Util.WaitUntilElementExists(chromeDriver, DateTermsOffered, 10);
            input.Clear();
            input.SendKeys(value);
        }

        public void SetTextNotProceedingComment(string comment)
        {
            Util.SetValue(NotProceedingComment, comment);
        }

        public void SetValueReferToUser(string value)
        {
            Util.Select(ReferToUser, value);
        }
        
        public bool VerifyFirstRowDoiTableOverallOutcome()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, DoiTableOverallOutcome);
            var rows = Util.GetRowsOfTable(table);
            var tds = Util.GetTdsOfRow(rows[0]);
            return (tds[4].Text.Contains("12345") && tds[5].Text.Contains("50,000") && tds[6].Text.Contains("draft"));
        }
        public void SetValueEditPostCode(string value)
        {
            Util.SetValue(EditPostCodeInput, value);
        }
        public void SetValuePolicyNumberOverallOutcome(string value)
        {
            Util.SetValue(PolicyNumber, value);
        }
        public void SetValueLotStreetNoInputOverallOutcome(string value)
        {
            Util.SetValue(LotStreetNoInput, value);
        }
        public void SetValueInputSurburbOverallOutcome(string value)
        {
            Util.SetValue(SuburbInput, value);
        }
        public void SetValueSiteStreetName(string value)
        {
            Util.SetValue(SiteStreetName, value);
        }

        /// <summary>
        /// Check is enabled Generate Eligibility button
        /// </summary>
        /// <returns></returns>
        public bool IsEnabledGenerateEligibilityButton()
        {
            return Util.IsEnable(GenerateEligibilityButton);
        }

        /// <summary>
        /// Cick Generate Eligibility button
        /// </summary>
        /// <returns></returns>
        public void ClickGenerateEligibilityButton()
        {
            Util.Click(GenerateEligibilityButton);
        }

        /// <summary>
        /// Change value of Eligibility Assessment status
        /// </summary>
        /// <param name="value">Value</param>
        public void SetValueEligibilityAssessmentStatusDll(string value)
        {
            Util.Select(EligibilityAssessmentStatusDLL, value);
        }

        public bool IsBlankNextPlanedReviewDate()
        {
            try
            {
                if (string.IsNullOrEmpty(Util.WaitUntilElementExists(chromeDriver, NextPlanedReviewDateTxt).Text))
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }

        #endregion

        #region MENU METHOD
        public bool CheckTrackRecordMenuEnable()
        {
            var trackRecord = Util.WaitUntilElementExists(chromeDriver, trackRecordMenu, 10);
            return trackRecord.Enabled;
        }

        public void ClickMenuTrackRecord()
        {
            var trackRecordButton = Util.WaitUntilElementExists(chromeDriver, trackRecordMenu, 10);
            trackRecordButton.Click();
        }

        public void ClickButtonOverallOutcomeMenu()
        {
            var buttonOverallOutcomeMenu = Util.WaitUntilElementExists(chromeDriver, ButtonOverallInputMenu, 10);
            buttonOverallOutcomeMenu.Click();
        }

        public void ClickInitiateMenuButton()
        {
            var button = Util.WaitUntilElementExists(chromeDriver, InitiateReviewMenuButton, 10);
            button.Click();
        }

        public void ClickBuilderDetailMenuButton()
        {
            Util.Click(BuilderDetailMenuButton);
        }

        public void ClickEligibilityDetails()
        {
            var eligibilityDetailsMenu = Util.WaitUntilElementExists(chromeDriver, EligibilityReviewMenu, 10);
            eligibilityDetailsMenu.Click();
        }

        public bool IsTrackRecordEnable()
        {
            return Util.IsEnable(trackRecordMenu);
        }

        public void ClickButtonFinancialInputsMenu()
        {
            var buttonFinancialInputsMenu = Util.WaitUntilElementExists(chromeDriver, ButtonFinancialInputsMenu, 10);
            buttonFinancialInputsMenu.Click();
        }

        /// <summary>
        /// Click Financial Output menu button
        /// </summary>
        public void ClickButtonFinancialOutputsMenu()
        {
            var buttonFinancialOutputsMenu = Util.WaitUntilElementExists(chromeDriver, ButtonFinancialOutputsMenu, 10);
            buttonFinancialOutputsMenu.Click();
        }

        public void ClickReportMenu()
        {
            var button = Util.WaitUntilElementExists(chromeDriver, ReportMenu, 10);
            button.Click();
        }

        public void ClickSiraBuilderDetailMenuButton()
        {
            Util.Click(SiraBuilderDetailMenuButton);
        }
        #endregion
        
        #region KeyEventLog
        public bool CheckEmailSentKeyEventLogs(string currentUser)
        {
            var eventlogs = GetEventLogtable();
            var eventlogsTBody = eventlogs.FindElement(By.TagName("tbody"));
            var lstTrElem = eventlogsTBody.FindElements(By.ClassName("dxgvDataRow_Office2010Blue"));
            var lstTdElem = GetTdElement(lstTrElem[0]);
            var currentDate = DateTime.Today.ToString("d/MM/yyyy");
            if (lstTdElem[5].Text.Contains("email has been sent") && lstTdElem[10].Text == currentUser && lstTdElem[11].Text.Contains(currentDate))
            {
                return true;
            }
            return false;
        }

        public bool CheckActionRequiredByKeyEventLogs(string currentUser)
        {
            var eventlogs = GetEventLogtable();
            var eventlogsTBody = eventlogs.FindElement(By.TagName("tbody"));
            var lstTrElem = eventlogsTBody.FindElements(By.ClassName("dxgvDataRow_Office2010Blue"));
            var lstTdElem = GetTdElement(lstTrElem[1]);
            var currentDate = DateTime.Today.ToString("d/MM/yyyy");
            if (lstTdElem[5].Text.Equals("ActionRequiredBy:hbcf") && lstTdElem[10].Text == currentUser && lstTdElem[11].Text.Contains(currentDate))
            {
                return true;
            }
            return false;

        }

        public bool CheckKeyEventLogForBuilder(string description, DateTime dateInput)
        {
            var rows = GetKeyEventLogRows();
            for (int i = 0; i < rows.Count; i++)
            {
                var tds = Util.GetTdsOfRow(rows[i]);
                var datetime = tds[11].Text;
                var date = datetime.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
                if (date.Equals(dateInput.ToString("d/MM/yyyy")) && tds[4].Text.Contains(description))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
        
        # region Manage Groups Method
        public void SetValueEntityNameManageGroup(string value)
        {
            Util.SetValue(EntityNameManageGroup, "Australia");
        }

        public void ClickSearchButtonManageGroup()
        {
            Util.Click(SearchButtonManageGroup);
        }

        public void ClickCreateNewGroup()
        {
            Util.Click(CreateNewGroup);
        }

        public void SetTextGroupNameInput(string value)
        {
            Util.SetValue(GroupNameInput, value);
        }

        public bool VerifyAutoCompleteDivShowUp()
        {
            var div = Util.WaitUntilElementExists(chromeDriver, DivAutoComplete);
            var lis = div.FindElements(By.TagName("li"));
            if (lis.Count > 0)
                return true;
            return false;
        }
        #endregion
        
        #region DIALOG METHOD
        public void WaitTillBusyDialogClose()
        {
            while (CheckBusyDialogOpen())
            {

            }
        }

        public bool CheckBusyDialogOpen()
        {
            try
            {
                var dialog = Util.WaitUntilElementExists(chromeDriver, BusyDialog, 10);
                var dialogZIndex = dialog.GetAttribute("z-index");
                var dialogDisplay = dialog.GetCssValue("display");
                //if (dialogZIndex == "101" || CheckHiddenDialogExist() || dialogDisplay.Equals("block"))
                //    return true;
                if (dialogZIndex == "101" || dialogDisplay.Equals("block"))
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public void WaitTillUploadDialogClose()
        {
            try
            {
                var dialog = Util.WaitUntilElementExists(chromeDriver, UploadSignedPdfDialog, 10);
                while (dialog.GetCssValue("display").Equals("block"))
                {

                }
            }
            catch
            {
                return;
            }

        }

        public bool IsConfirmDistributorChangeDialogOpen()
        {
            try
            {
                var dialog = Util.WaitUntilElementExists(chromeDriver, ConfirmDistributorChangeDialog);
                return dialog.GetCssValue("display").Equals("block");
            }
            catch
            {
                return false;
            }
        }

        public void WaitTillRenderingTemplateDialogClose()
        {
            try
            {
                var dialog = Util.WaitUntilElementExists(chromeDriver, RenderingTemplateDialog, 10);
                while (dialog.GetCssValue("display").Equals("block"))
                {

                }
            }
            catch
            {
                return;
            }
        }

        public void WaitTillLoadingSquareClose()
        {
            while (true)
            {
                var dialog = Util.WaitUntilElementExists(chromeDriver, LoadingSquare);
                if (dialog.GetCssValue("visibility").Equals("hidden"))
                {
                    return;
                }
            }
        }

        public bool VerifyErrorDialogShowManageGroup()
        {
            try
            {
                var dialog = Util.WaitUntilElementExists(chromeDriver, ErrorManageGroupDialog);
                return dialog.GetCssValue("display").Equals("block");
            }
            catch
            {
                return false;
            }
        }

        public void WaitForDeleteDialogClose()
        {
            var dialog = Util.WaitUntilElementExists(chromeDriver, DeleteFileDialog);
            Util.WaitTillDialogClose(dialog);
        }

        public bool VerifyValidationDialogOpen()
        {
            var body = Util.WaitUntilElementExists(chromeDriver, Body);
            var dialog = body.FindElements(ValidationDialog);
            if (dialog.Count > 1)
            {
                return true;
            }
            return false;
        }

        public void ClickCloseButtonValidationDialog()
        {
            Util.Click(CloseButtonValidationDialog);
        }
        #endregion
        
        #region Report
        public List<string> GetUtilisedJobNumberAndBuilderLicenceFirstRowHasUtilisedJobValueGreaterThan50000()
        {
            var table = Util.WaitUntilElementExists(chromeDriver, InactiveEligibilityUtilisedJobsReportTable, 100);
            var rows = Util.GetRowOfTableWithFilter(table, x => x.GetAttribute("id").Contains("MainContent_ReportGrid_DXDataRow"));
            foreach (var row in rows)
            {
                var tds = Util.GetTdsOfRow(row);
                var utilisedJobValueString = ConvertMoneyToNumber(tds[8].Text);
                utilisedJobValueString = utilisedJobValueString.Substring(0, utilisedJobValueString.Length - 3);
                var utilisedJobValue = int.Parse(utilisedJobValueString);
                if (utilisedJobValue > 50000)
                {
                    utilisedJobValueString = utilisedJobValue.ToString("N0");
                    return new List<string>() { tds[9].Text, tds[3].Text, utilisedJobValueString };
                }
            }
            return new List<string>();
        }
        public bool ClickAssessmentReports(string reportType)
        {
            var reportTable = Util.WaitUntilElementExists(chromeDriver, AssessmentReportTable, 10);
            var rows = Util.GetRowsOfTable(reportTable);
            for (int i = 1; i < rows.Count; i++)
            {
                if (Util.CheckColumnValueOfRow(rows[i], 1, reportType))
                {
                    Util.ClickIndexOfRow(rows[i], 3);
                    return true;
                }
            }
            return false;
        }
        #endregion
        public void ClickOkConfirmABNChange()
        {
            try
            {
                Util.Click(OKAbnChangeOverallOutcome);
            }
            catch
            {
            }
            
        }

        public void ClickOkValidationDialog()
        {
            try
            {
                Util.Click(By.CssSelector("body > div:nth-child(42) > div.ui-dialog-buttonpane.ui-widget-content.ui-helper-clearfix > div > button"));
            }
            catch
            {

            }
        }

        #region SiraBuilderDetailsMethods
        public void ClickRefreshLicenceDetailsFromSira()
        {
            Util.Click(RefreshLicenceDetailFromSira);
        }
        #endregion
        
        #region Create Builder Methods
        public string GetValueDistributorBuilderDetails()
        {
            var dropdown = Util.WaitUntilElementExists(chromeDriver, DistriButorSelect);
            var dropdownElement = new SelectElement(dropdown);
            return dropdownElement.SelectedOption.Text;
        }
        #endregion

        #region AUTOITX
        //public void SelectFileUpload(string filePath)
        //{
        //    //Select file to upload            
        //    AutoItX.WinActivate("Open");
        //    Thread.Sleep(1000);
        //    //AutoItX.Send(AppDomain.CurrentDomain.BaseDirectory + "\\" + fileName);
        //    AutoItX.Send(filePath);
        //    Thread.Sleep(2000);
        //    //Click key ENTER for upload file
        //    AutoItX.Send("{ENTER}");
        //    Thread.Sleep(2000);
        //}
        #endregion

        #region Method of Accept or adjust outcome

        public bool IsEnabledCheckBoxAnyConditionRequired()
        {
            if (IsAssessmentGTA())
            {
                return Util.IsEnable(ChkGroupAnyConditionsRequiredPartOfTheTerms);
            }
            else
            {
                return Util.IsEnable(ChkAnyConditionsRequiredPartOfTheTerms);
            }
        }

        /// <summary>
        /// Set active or unactive checkbox
        /// </summary>
        /// <param name="element">Check box</param>
        /// <param name="isActive">Is active</param>
        public void ClickingCheckBox(By element, bool isActive)
        {
            var principalActive = Util.WaitUntilElementExists(chromeDriver, element, 10);
            if (principalActive.Selected == !isActive)
                principalActive.Click();
        }

        /// <summary>
        /// Set checked checkbox Any condition required
        /// </summary>
        /// <param name="isActive">True is check, false is uncheck</param>
        public void SetCheckBoxAnyConditionsRequired(bool isActive)
        {
            if (IsAssessmentGTA())
            {
                ClickingCheckBox(ChkGroupAnyConditionsRequiredPartOfTheTerms, isActive);
            }
            else // Non GTA
            {
                ClickingCheckBox(ChkAnyConditionsRequiredPartOfTheTerms, isActive);
            }
        }
        
        /// <summary>
        /// Is enabled Add condition button
        /// </summary>
        /// <returns></returns>
        public bool IsEnabelAddConditionButton()
        {
            if (IsAssessmentGTA())
            {
                return Util.IsEnable(BtnGroupAddConditions);
            }
            else // Non GTA
            {
                return Util.IsEnable(BtnAddConditions);
            }
        }

        /// <summary>
        /// Click Add condition button in ACCEPT OR ADJUST OUTCOME session
        /// </summary>
        public void ClickAddConditionButton2()
        {
            if (IsAssessmentGTA())
            {
                Util.Click(BtnGroupAddConditions);
            }
            else // Non GTA
            {
                Util.Click(BtnAddConditions);
            }
        }
        
        /// <summary>
        /// Set condition dropdown in condition dialog
        /// </summary>
        /// <param name="value">Value</param>
        public void SetConditionDll(string value)
        {
            if (IsAssessmentGTA())
            {
                Util.SetValue(SetGroupValueConditionInConditionDialog, value);
            }
            else // Non GTA
            {
                Util.SetValue(SetValueConditionInConditionDialog, value);
            }
        }

        /// <summary>
        /// Set value of status condition dialog
        /// </summary>
        /// <param name="value">Value</param>
        public void SetValueConditionStatus(string value)
        {
            if (IsAssessmentGTA())
            {
                Util.Select(SelectGroupStatusConditionDialog, value);
            }
            else // Non GTA
            {
                Util.Select(SelectStatusConditionDialogDdl, value);
            }
        }

        /// <summary>
        /// Click Save button in Condition dialog
        /// </summary>
        public void ClickConditionDialogSaveButton()
        {
            Util.Click(SaveButtonConditionDialog, 10);
        }

        /// <summary>
        /// Clear all conditions
        /// </summary>
        public void ClickEditOrDeleteCondition(string type, bool isDeleteAll = false)
        {
            IWebElement table = null;

            if (IsAssessmentGTA())
            {
                table = Util.WaitUntilElementExists(chromeDriver, TableGroupListDeleteConditionsButton);
            }
            else // Non GTA
            {
                table = Util.WaitUntilElementExists(chromeDriver, TableListDeleteConditionsButton);
            }

            if (table.Displayed)
            {
                var rows = Util.GetRowsOfTable(table);
                if (rows != null)
                {
                    foreach (var itemRow in rows)
                    {
                        var lstTd = GetTdElement(itemRow);
                        if (lstTd != null && lstTd.Count > 1)
                        {
                            var lstInputImgs = lstTd[1].FindElements(By.TagName(Common.TagNameInput));
                            if (lstInputImgs != null)
                            {
                                if (type == Common.LblDelete)
                                {
                                    if (lstInputImgs.Count > 1)
                                    {
                                        lstInputImgs[1].Click();
                                        WaitTillBusyDialogClose();
                                    }
                                }
                                else if (type == Common.LblEdit)
                                {
                                    lstInputImgs[0].Click();
                                    WaitTillBusyDialogClose();
                                    break; // Only edit first row
                                }
                                
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Navigate to Group Overall Outcome screen
        /// </summary>
        public void NavigateGroupOverallOutcomeScreen()
        {
            var groupOver = Util.WaitUntilElementExists(chromeDriver, GroupOverallOutcomeButton);
            if (groupOver != null)
            {
                groupOver.Click();
                WaitTillBusyDialogClose();
            }
            Thread.Sleep(3000);
        }
        #endregion

        #region Method dialog confirm ABN change

        /// <summary>
        /// Check existing text in confirm ABN change dialog
        /// </summary>
        /// <returns></returns>
        public bool CheckExistTextInConfirmABNChangDialog(string text)
        {
            var dialog = Util.WaitUntilElementExists(chromeDriver, DialogConfirmABNChange);
            if (dialog.Text.Contains(text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Click OK button on confirm ABN change dialog
        /// </summary>
        public void ClickOkButtonConfirmABNChange()
        {
            var okButton = Util.WaitUntilElementExists(chromeDriver, OkButtonConfirmABNChange, 10);
            okButton.Click();
        }

        #endregion

        #region Method Deed of indemnity
        
        /// <summary>
        /// Get content of column of DOI table
        /// </summary>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        public IWebElement GetContentColumnOfDOITable(int colIndex)
        {
            var tdElement = GetTdElement(Util.WaitUntilElementExists(chromeDriver, TableDOI, 10));
            return tdElement[colIndex];
        }

        /// <summary>
        /// Find elements by tag name and index of column
        /// </summary>
        /// <param name="nameElement">Name of element</param>
        /// <param name="colIndex">Index of column</param>
        /// <returns></returns>
        public List<IWebElement> FindElementsByTagName(string nameElement, int colIndex)
        {
            return GetContentColumnOfDOITable(colIndex).FindElements(By.TagName(nameElement)).ToList();
        }

        /// <summary>
        /// Get control in DOI by tag name and value of control
        /// </summary>
        /// <param name="colIndex"></param>
        /// <param name="valueOfControl"></param>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public IWebElement GetControlInDOI(int colIndex, string valueOfControl, string tagName)
        {
            var lstElements= GetContentColumnOfDOITable(colIndex).FindElements(By.TagName(tagName)).ToList();
            foreach (var eleme in lstElements)
            {
                if (eleme.Text.ToUpper().Contains(valueOfControl.ToUpper()))
                {
                    return eleme;
                }
            }

            return null;
        }

        /// <summary>
        /// Click Edit Draft button in DOI
        /// </summary>
        /// <param name="colIndex"></param>
        public void ClickEditDraffButtonDOI(int colIndex)
        {
            var editDraff = GetControlInDOI(colIndex, Common.EditDraft, Common.TagNameButton);
            editDraff.Click();
        }

        /// <summary>
        /// Click View Draft button in DOI
        /// </summary>
        /// <param name="colIndex"></param>
        public void ClickViewDraffButtonDOI(int colIndex)
        {
            var editDraff = GetControlInDOI(colIndex, Common.ViewDraft, Common.TagNamelink);
            editDraff.Click();
        }

        /// <summary>
        /// Click Cancel button in Deed of Indemnity dialog
        /// </summary>
        public void ClickCancelButtonInDOI()
        {
            Util.Click(ButtonCancelDOIDialog);
        }

        /// <summary>
        /// Check message in email success dialog
        /// </summary>
        /// <param name="value">Text need check</param>
        /// <returns></returns>
        public bool CheckEmailSucessDialogDOI(string value)
        {
            var lstElement = GetElementsByProperty(UiDialog);
            if (lstElement != null)
            {
                foreach (var item in lstElement)
                {
                    if (item.Displayed && item.Text.Contains(value))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }

        /// <summary>
        /// Click OK button in Email Success dialog
        /// </summary>
        public void ClickOkButtonInEmailSuccessDialog()
        {
            var lstElement = GetElementsByProperty(UiDialog);
            if (lstElement != null)
            {
                foreach (var item in lstElement)
                {
                    if (item.Displayed)
                    {
                        var lstButton = item.FindElements(By.TagName(Common.TagNameButton));
                        if (lstButton != null)
                        {
                            foreach (var iBtn in lstButton)
                            {
                                if (iBtn.Text.ToUpper().Contains("OK"))
                                {
                                    iBtn.Click();
                                    return;
                                }
                            }
                        }

                    }
                }
            }
            //Util.Click(ButtonOKInEmailSuccessDialog);
        }

        #endregion

        #region Methods of Assessment section in Search screen

        /// <summary>
        /// Verify Add New Assessment button is enabled
        /// </summary>
        /// <returns></returns>
        public bool IsEnabledAddNewAssessmentButton()
        {
            return Util.IsEnable(AddNewAssessmentButton);
        }

        /// <summary>
        /// Click Add New Assessment button
        /// </summary>
        public void ClickAddNewAssessmentButton()
        {
            Util.Click(AddNewAssessmentButton);
            WaitTillBusyDialogClose();
        }
        #endregion

        #region Methods in Iniitiate Review screen

        /// <summary>
        /// Change value of Financial year being assessed
        /// </summary>
        /// <param name="value"></param>
        public void SetValueForFinancialYearDDL(string value)
        {
            Util.Select(FinancialYearDDL, value);
        }

        /// <summary>
        /// Change value of Assessment type
        /// </summary>
        /// <param name="value"></param>
        public void SetValueForAssessmentTypeDLL(string value)
        {
            Util.Select(AssessmentTypeDLL, value);
        }

        /// <summary>
        /// Set value for comment textbox
        /// </summary>
        /// <param name="value"></param>
        public void SetValueCommentTxt(string value)
        {
            var comment = Util.WaitUntilElementExists(chromeDriver, InitialCommentTxt);
            comment.Clear();
            comment.SendKeys(value);
        }

        /// <summary>
        /// Click Save button
        /// </summary>
        public void ClickSaveButtonInitiateReview()
        {
            Util.Click(SaveButtonInitiateReview);
        }

        #endregion

        #region Methods of Eligibility Details screen

        /// <summary>
        /// Get NSW Open Job Limit Value
        /// </summary>
        /// <param name="value">Value</param>
        public string GetValueHwJobLimitValueTxt()
        {
            var hwJobLimitValue = Util.WaitUntilElementExists(chromeDriver, HwJobLimitValueTxt);
            if (hwJobLimitValue != null)
            {
                return hwJobLimitValue.Text;
            }
            return string.Empty;
        }

        /// <summary>
        /// NSW Open Job Limit Value
        /// </summary>
        /// <param name="value">Value</param>
        public void SetValueHwJobLimitValueTxt(string value)
        {
            var hwJobLimitValue = Util.WaitUntilElementExists(chromeDriver, HwJobLimitValueTxt);
            hwJobLimitValue.Clear();
            hwJobLimitValue.SendKeys(value);
        }

        /// <summary>
        /// NSW Open Job Limit Number
        /// </summary>
        /// <param name="value">Value</param>
        public void SetValueHwJobLimitNumberTxt(string value)
        {
            var hwJobLimitNumber = Util.WaitUntilElementExists(chromeDriver, HwJobLimitNumberTxt);
            hwJobLimitNumber.Clear();
            hwJobLimitNumber.SendKeys(value);
        }

        /// <summary>
        /// HBCF Insurance in other States
        /// </summary>
        /// <param name="value">Value</param>
        public void SetValueHwInsuranceOtherStatesTxt(string value)
        {
            var hwInsurance = Util.WaitUntilElementExists(chromeDriver, HwInsuranceOtherStatesTxt);
            hwInsurance.Clear();
            hwInsurance.SendKeys(value);
        }

        /// <summary>
        /// Non HBCF Insurance Income
        /// </summary>
        /// <param name="value">Value</param>
        public void SetValueNonHomeInsuranceTxt(string value)
        {
            var nonHome = Util.WaitUntilElementExists(chromeDriver, NonHomeInsuranceTxt);
            nonHome.Clear();
            nonHome.SendKeys(value);
        }

        /// <summary>
        /// New single dwelling construction
        /// </summary>
        /// <param name="value">Value</param>
        public void SetValueFinancialLimits_txtC01(string value)
        {
            var financialLimit = Util.WaitUntilElementExists(chromeDriver, FinancialLimits_txtC01);
            financialLimit.Clear();
            financialLimit.SendKeys(value);
        }

        /// <summary>
        /// Set checked checkbox Open Job Values checked? 
        /// <param name="isActive">True is check, false is uncheck</param>
        public void SetCheckBoxOpenJobValueCheck(bool isActive)
        {
            ClickingCheckBox(ChkOpenJobValue, isActive);
        }

        public void ClickGenerateCertificateOfEligibilityButton()
        {
            Util.Click(GenerateCertificateOfEligibilityButton);
        }

        /// <summary>
        /// Get current url
        /// </summary>
        /// <returns></returns>
        public string GetUrlCurrent()
        {
            return chromeDriver.Url;
        }

        /// <summary>
        /// Navigate to url
        /// </summary>
        /// <param name="url"></param>
        public void NavigateToUrl(string url)
        {
            chromeDriver.Navigate().GoToUrl(url);
        }

        #endregion

        #region Methods of Outcome Details section

        /// <summary>
        /// Offer terms button
        /// </summary>
        public bool IsEnabledOfferTermsButton()
        {
            return Util.IsEnable(OfferTermsButton);
        }

        #endregion

        #region Methods of Financial Inputs screen

        /// <summary>
        /// Set value for 'Cash' under 'Balance Sheet >> Current Assets'
        /// </summary>
        /// <param name="value"></param>
        public void SetValueForCurrentAsstesPropCash(string value)
        {
            var lstRows = GetElementsByProperty(FinancialiInputsTableRow);
            if (lstRows != null)
            {
                foreach (var iRow in lstRows)
                {
                    var lstTd = GetTdElement(iRow);
                    if (lstTd != null && lstTd.Count > 1)
                    {
                        if (lstTd[0].Text.ToUpper().Contains(Common.Cash.ToUpper()))
                        {
                            // Find input textbox
                            var inputTxt = lstTd[1].FindElement(By.TagName(Common.TagNameInput));
                            if (inputTxt != null)
                            {
                                inputTxt.Clear();
                                inputTxt.SendKeys(value);
                                Thread.Sleep(2000);
                                return;
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
