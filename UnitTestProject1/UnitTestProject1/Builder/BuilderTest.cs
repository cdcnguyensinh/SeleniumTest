using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using SICorp.Test.BuilderServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;

namespace SICorp.Test.Builder
{
    [TestClass]
    public class BuilderTest
    {

        ChromeDriver driver;
        BuilderPage builderPage;
        private readonly string filePath = Common.FilePath;
        private string FileDownloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
        //TaskService _taskService = null;
        //string _cxnStr = null;

        public BuilderTest()
        {
            //var wc = new WindsorContainer();
            //Container.Instance = wc;
            //var ioc = new SICorp.IoC.ModuleInstaller();
            //var nh = new SICorp.NHibernate.Eat.ModuleInstaller(RegistrationLifestyle.Application);
            //var ss = new SICorp.Services.ModuleInstaller();
            //var es = new Eat.Services.ModuleInstaller();

            //wc.Install(
            //    new SICorp.IoC.ModuleInstaller(),
            //    new SICorp.NHibernate.Eat.ModuleInstaller(RegistrationLifestyle.Application),
            //    new SICorp.Services.ModuleInstaller(),
            //    new Eat.Services.ModuleInstaller()
            //);
            //_taskService = new TaskService();
        }

        [TestInitialize]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-web-security");
            ////options.AddArgument("--user-data-dir=~/.e2e-chrome-profile");

            driver = new ChromeDriver(options);
            builderPage = new BuilderPage(driver);
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://portal-uat.hbcf.nsw.gov.au/portal/server.pt?open=space&name=Login&control=Login&login=&in_hi_userid=953&cached=true");
            //driver.Navigate().GoToUrl("http://localhost:52232/");
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }

        [TestMethod]
        public void SearchAndViewBuilder()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("nguyenv", "Abc123456@");

            //var mainMenu = new MainMenu(driver);
            //mainMenu.GoBeatPage();
            //mainMenu.LaunchBeat();

            GoToSearchBeat();

            var textSearch = "Masterton";

            builderPage.SetBuilderEntityName(textSearch);
            builderPage.ClickSearchBuilder();

            //Check result
            var checkSearchBuilder = builderPage.CheckSearchResult(textSearch);
            //Assert.IsTrue(resultCheck);

            if (checkSearchBuilder)
            {
                var checkViewBuilder = builderPage.ViewBuilder();
                Assert.IsTrue(checkViewBuilder);
            }
            else
                Assert.IsTrue(checkSearchBuilder);
        }

        [TestMethod]
        public void AddCommentBuilderSingle()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("nguyenv", "Abc123456@");

            GoToSearchBeat();

            var textSearch = "Champion homes";

            builderPage.SetBuilderTradingName(textSearch);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                var commentBuilderText = "I am a new comment";
                builderPage.ClickViewBuilder();
                builderPage.ClickAddNewComment();
                builderPage.SetCommentBuilder(commentBuilderText);
                builderPage.ClickSaveCommentBuilder();

                //Check result add comment
                var resultCheckAddComment = builderPage.CheckResultAddcommentBuilder(commentBuilderText);
                Assert.IsTrue(resultCheckAddComment);
            }
            else
                Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void AddCommentBuilderGTA()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("nguyenv", "Abc123456@");

            GoToSearchBeat();

            var textSearch = "QUINN HOMES";

            builderPage.SetBuilderEntityName(textSearch);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                var commentBuilderText = "I am a new comment";
                builderPage.ClickViewBuilder();
                builderPage.ClickAddNewComment();
                builderPage.SetCommentBuilder(commentBuilderText);
                builderPage.ClickSaveCommentBuilder();

                //Check result add comment
                var resultCheckAddComment = builderPage.CheckResultAddcommentBuilder(commentBuilderText);
                Assert.IsTrue(resultCheckAddComment);
            }
            else
                Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void AddMultipleCommentBuilderSingle()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("nguyenv", "Abc123456@");

            GoToSearchBeat();

            var textSearch = "Champion homes";

            builderPage.SetBuilderTradingName(textSearch);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                var commentBuilderText1 = "I am comment 1";
                builderPage.ClickViewBuilder();
                builderPage.ClickAddNewComment();
                builderPage.SetCommentBuilder(commentBuilderText1);
                builderPage.ClickSaveCommentBuilder();

                //Check result add comment 1
                var resultCheckAddComment1 = builderPage.CheckResultAddcommentBuilder(commentBuilderText1);
                //If add success then add the second comment 
                if (resultCheckAddComment1)
                {
                    var commentBuilderText2 = "I am comment 2";
                    builderPage.ClickAddNewComment();
                    builderPage.SetCommentBuilder(commentBuilderText2);
                    builderPage.ClickVisibleToAI();
                    builderPage.ClickSaveCommentBuilder();

                    //Check result add comment 1
                    var resultCheckAddComment2 = builderPage.CheckResultAddcommentBuilder(commentBuilderText2);
                    if (resultCheckAddComment2)
                    {
                        //Verify the Visible to IA is ticked 
                        var resultCheckVisibleAITicked = builderPage.CheckVisibleAITicked();
                        Assert.IsTrue(resultCheckVisibleAITicked);
                    }
                    else
                        Assert.IsTrue(resultCheckAddComment2);
                }
                else
                    Assert.IsTrue(resultCheckAddComment1);
            }
            else
                Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void AddFileToBuilder()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("nguyenv", "Abc123456@");
                      
            GoToSearchBeat();

            var textSearch = "QUINN HOMES";

            builderPage.SetBuilderEntityName(textSearch);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                //var fileName = "D:\\Nois_Project\\SICorp\\SiCorp\\SICorp\\trunk\\Current\\SICorp.Test\\bin\\Debug\\test2.txt";
                var filePath = Common.FilePath;
                var fileName = CreateTextFile();
                builderPage.ClickViewBuilder();
                //builderPage.ClearBuilderFiles();
                builderPage.ClickBuilderUploadFileButton();
                Thread.Sleep(1000);
                // ??? builderPage.SelectFileUpload(filePath + fileName);
                Thread.Sleep(1000);
                builderPage.ClickContinueCategoryDialog();
                Thread.Sleep(1000);
                builderPage.WaitTillUploadDialogClose();
                //verify file uploaded
                var checkDuplicateUploadFile = builderPage.CheckFileDuplicate();
                Thread.Sleep(1000);
                if (!checkDuplicateUploadFile)
                {
                    var checkFileUploadShow = builderPage.CheckFileUploadShow(fileName);
                    Assert.IsTrue(checkFileUploadShow);
                }
                else
                    Assert.IsTrue(!checkDuplicateUploadFile);
            }
            else
                Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void AddNewPrincipalBuilder()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("nguyenv", "Abc123456@");

            GoToSearchBeat();

            var textSearch = "Champion homes";

            builderPage.SetBuilderTradingName(textSearch);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {

                var principalName = "Jimmy Chonga";
                var principalDOB = "1977";
                var principalSuburb = "MAROUBRA";
                var principalRole = "Director";
                var principalNSW = "99999C";
                var principalYearLincenseHeld = "18";

                builderPage.ClickViewBuilder();
                builderPage.ClickAddNewPrincipal();
                builderPage.SetPrincipalName(principalName);
                builderPage.SetPrincipalDOB(principalDOB);
                builderPage.SetPrincipalSuburb(principalSuburb);
                builderPage.SetPrincipalRole(principalRole);
                builderPage.SetPrincipalNSW(principalNSW);
                builderPage.SetPrincipalYearLicenseHeld(principalYearLincenseHeld);
                builderPage.SetPrincipalActive();
                builderPage.ClickSavePrincipal();

                //Verify info principal save
                var checkInfoNewPrincipal = builderPage.VerifyInfoAddNewPrincipal(principalName, principalDOB, principalSuburb, principalRole, principalNSW, principalYearLincenseHeld);
                Assert.IsTrue(checkInfoNewPrincipal);
            }
            else
                Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void DeletePrincipalBuilder()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("nguyenv", "Abc123456@");

            GoToSearchBeat();

            var textSearch = "Champion homes";

            builderPage.SetBuilderTradingName(textSearch);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                var principalName = "Jimmy Chonga";
                var principalDOB = "1977";
                var principalSuburb = "MAROUBRA";
                var principalRole = "Director";
                var principalNSW = "99999C";
                var principalYearLincenseHeld = "18";

                builderPage.ClickViewBuilder();

                var dataPrincipalBefore = builderPage.CountDataPrincipalTable();

                builderPage.ClickAddNewPrincipal();
                builderPage.SetPrincipalName(principalName);
                builderPage.SetPrincipalDOB(principalDOB);
                builderPage.SetPrincipalSuburb(principalSuburb);
                builderPage.SetPrincipalRole(principalRole);
                builderPage.SetPrincipalNSW(principalNSW);
                builderPage.SetPrincipalYearLicenseHeld(principalYearLincenseHeld);
                builderPage.SetPrincipalActive();
                builderPage.ClickSavePrincipal();

                //Verify info principal save
                var checkInfoNewPrincipal = builderPage.VerifyInfoAddNewPrincipal(principalName, principalDOB, principalSuburb, principalRole, principalNSW, principalYearLincenseHeld);

                if (checkInfoNewPrincipal)
                {
                    //Delete principal
                    builderPage.DeletePrincipal();
                    //Verify delete principal
                    var dataPrincipalAfter = builderPage.CountDataPrincipalTable();
                    if (dataPrincipalAfter == dataPrincipalBefore)
                        Assert.IsTrue(true);
                    else
                        Assert.IsTrue(false);
                }
                else
                    Assert.IsTrue(checkInfoNewPrincipal);
            }
            else
                Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void AddNewInterstateLicence()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("nguyenv", "Abc123456@");

            GoToSearchBeat();

            var textSearch = "Champion homes";

            builderPage.SetBuilderTradingName(textSearch);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {

                var licenseNo = "12345";
                var licenseState = "QLD";
                var licenseName = "Test Licence QLD";
                var licenseCategory = "L07";
                var licenseIssueDate = "2017-01-01";
                var licenseExpiryDate = "2019-01-01";
                var licenseStatus = "Current";

                builderPage.ClickViewBuilder();
                builderPage.ClickAddInterstateLicence();
                builderPage.SetLicenseNo(licenseNo);
                builderPage.SetLicenseState(licenseState);
                builderPage.SetLicenseName(licenseName);
                builderPage.SetLicenseCategory(licenseCategory);
                builderPage.SetLicenseIssueDate(licenseIssueDate);
                builderPage.SetLicenseExpiryDate(licenseExpiryDate);
                builderPage.SetLicenseStatus(licenseStatus);
                builderPage.ClickSaveLicense();

                //Verify license save
                var checkInfoNewLicense = builderPage.VerifyAddNewLicense(licenseNo, licenseState, licenseName, licenseCategory, licenseIssueDate, licenseExpiryDate, licenseStatus);
                Assert.IsTrue(checkInfoNewLicense);
            }
            else
                Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void DeleteLicense()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("nguyenv", "Abc123456@");

            GoToSearchBeat();

            var textSearch = "Champion homes";

            builderPage.SetBuilderTradingName(textSearch);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                var licenseNo = "12345";
                var licenseState = "QLD";
                var licenseName = "Test Licence QLD";
                var licenseCategory = "L07";
                var licenseIssueDate = "2017-01-01";
                var licenseExpiryDate = "2019-01-01";
                var licenseStatus = "Current";

                builderPage.ClickViewBuilder();
                var dataLicenseBefore = builderPage.CountDataLicenseTable();

                builderPage.ClickAddInterstateLicence();
                builderPage.SetLicenseNo(licenseNo);
                builderPage.SetLicenseState(licenseState);
                builderPage.SetLicenseName(licenseName);
                builderPage.SetLicenseCategory(licenseCategory);
                builderPage.SetLicenseIssueDate(licenseIssueDate);
                builderPage.SetLicenseExpiryDate(licenseExpiryDate);
                builderPage.SetLicenseStatus(licenseStatus);
                builderPage.ClickSaveLicense();

                //Verify license save
                var checkInfoNewLicense = builderPage.VerifyAddNewLicense(licenseNo, licenseState, licenseName, licenseCategory, licenseIssueDate, licenseExpiryDate, licenseStatus);

                if (checkInfoNewLicense)
                {
                    //Delete license
                    builderPage.DeleteLicense();
                    //Verify delete license
                    var dataLicenseAfter = builderPage.CountDataLicenseTable();
                    if (dataLicenseAfter == dataLicenseBefore)
                        Assert.IsTrue(true);
                    else
                        Assert.IsTrue(false);
                }
                else
                    Assert.IsTrue(checkInfoNewLicense);
            }
            else
                Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void ViewPricingHistory()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("nguyenv", "Abc123456@");

            GoToSearchBeat();

            var textSearch = "Champion homes";

            builderPage.SetBuilderTradingName(textSearch);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewBuilder();
                builderPage.ClickPricingHistoryButton();
                Thread.Sleep(1000);

                var checkColumnTablePricingHistory = builderPage.CheckColumnPricingTableHistory();
                Assert.IsTrue(checkColumnTablePricingHistory);
            }
            else
                Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void ChangeEADetails()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("nguyenv", "Abc123456@");

            GoToSearchBeat();
            var licenceNumber = "94116C";

            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                var scheduledAssessmentDate = "10-Sep-2019";
                var assessmentComment = "Comment";
                builderPage.ClickViewAssessments();
                var resultClickEdit = builderPage.ClickEditLinkAssessment();
                if (resultClickEdit)
                {
                    builderPage.SetScheduledAssessmentDate(scheduledAssessmentDate);
                    builderPage.SetAssessmentComment(assessmentComment);
                    builderPage.ClickSaveAssessment();

                    //Verify detail assessment
                    var result = builderPage.VerifyAssessmentDetail(scheduledAssessmentDate, assessmentComment);
                    Assert.IsTrue(result);
                }
                else
                    Assert.IsTrue(resultClickEdit);
            }
            else
                Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void TickOngoingAuditorAppointment()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("nguyenv", "Abc123456@");

            GoToSearchBeat();
            var licenceNumber = "94116C";

            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {

                builderPage.ClickViewAssessments();
                var resultClickEdit = builderPage.ClickEditLinkAssessment();
                if (resultClickEdit)
                {
                    //tick
                    builderPage.ClickOngoingAuditorAppointmentCheckbox();
                    //Verify tick
                    var resultCheckTick = builderPage.VerifyOngoingAuditorAppointment(true);
                    if (resultCheckTick)
                    {
                        //remove tick
                        builderPage.ClickOngoingAuditorAppointmentCheckbox();
                        //Verify
                        var resultCheckRemoveTick = builderPage.VerifyOngoingAuditorAppointment(false);
                        Assert.IsTrue(resultCheckRemoveTick);
                    }
                    else
                        Assert.IsTrue(resultCheckTick);
                }
                else
                    Assert.IsTrue(resultClickEdit);
            }
            else
                Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void UploadFileFinancialStatement()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("nguyenv", "Abc123456@");

            GoToSearchBeat();
            var licenceNumber = "94116C";

            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewAssessments();
                var resultClickEdit = builderPage.ClickEditLinkAssessment();
                if (resultClickEdit)
                {
                    var filePath = Common.FilePath;
                    var fileName = "doc1.txt";
                    var description = "fsb-text";
                    builderPage.ClickUploadFinancialStatementsOfTheBuilder(filePath + fileName);
                    Thread.Sleep(2000);
                    // ??? builderPage.SelectFileUpload(filePath + fileName);
                    Thread.Sleep(2000);
                    builderPage.SetDescriptionInput(description);
                    Thread.Sleep(2000);
                    builderPage.ClickContinue();
                    builderPage.WaitForUploadFinancialStatement();
                    Thread.Sleep(2000);
                    //verify file upload
                    var resultUploadFile = builderPage.VerifyFileUploadStatement(fileName, description);
                    Assert.IsTrue(resultUploadFile);
                }
                else
                    Assert.IsTrue(resultClickEdit);
            }
            else
                Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void UploadFileSensitive()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("nguyenv", "Abc123456@");

            GoToSearchBeat();
            var licenceNumber = "94116C";

            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {

                builderPage.ClickViewAssessments();
                var resultClickEdit = builderPage.ClickEditLinkAssessment();
                if (resultClickEdit)
                {
                    var filePath = Common.FilePath;
                    var description = "sensitive-text";
                    builderPage.ClickUploadSensitive(filePath + Common.FileName1);
                    // ??? builderPage.SelectFileUpload(filePath + Common.FileName1);
                    builderPage.SetDescriptionInput(description);
                    builderPage.ClickContinue();
                    builderPage.WaitForUploadFinancialStatement();

                    //verify file upload
                    var resultUploadFile = builderPage.VerifyFileUploadSensitive(Common.FileName1, description);
                    Assert.IsTrue(resultUploadFile);

                }
                else
                    Assert.IsTrue(resultClickEdit);
            }
            else
                Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void AddCommentToTheAssessmentInitiateReviewScreen()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("nguyenv", "Abc123456@");

            GoToSearchBeat();
            var licenceNumber = "94116C";

            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {

                builderPage.ClickViewAssessments();
                var resultClickEdit = builderPage.ClickEditLinkAssessment();
                if (resultClickEdit)
                {
                    builderPage.ClickButtonAddNewCommentInitiateReview();
                    Thread.Sleep(1000);
                    var comment = "Some text Comment";
                    builderPage.SetCommentAssessment(comment);
                    Thread.Sleep(1000);
                    builderPage.ClickSaveCommentAssessment();
                    Thread.Sleep(1000);

                    //Verify comment
                    var resultVerifyAddComment = builderPage.VerifySaveCommentAssessment(comment);
                    Assert.IsTrue(resultVerifyAddComment);
                }
                else
                    Assert.IsTrue(resultClickEdit);
            }
            else
                Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void SubmitTheAssessmentToTheBroker()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("nguyenv", "Abc123456@");

            GoToSearchBeat();
            var licenceNumber = "94116C";

            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {

                builderPage.ClickViewAssessments();
                var resultClickEdit = builderPage.ClickEditLinkAssessment();
                if (resultClickEdit)
                {
                    var checkSubmitToBrokerButtonEnable = builderPage.CheckSubmitToBrokerButton();
                    if (checkSubmitToBrokerButtonEnable)
                    {
                        builderPage.ClickSubmitToBrokerButton();
                        //Verify Distributor label at the top of the screen is highlighted yellow
                        var checkDistributorLabel = builderPage.VerifyColorDistributorLabel();
                        Assert.IsTrue(checkDistributorLabel);
                    }
                }
                else
                    Assert.IsTrue(resultClickEdit);
            }
            else
                Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void SubmitTheAssessmentToTheInsuranceAgent()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("nguyenv", "Abc123456@");

            GoToSearchBeat();
            var licenceNumber = "94116C";

            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {

                builderPage.ClickViewAssessments();
                var resultClickEdit = builderPage.ClickEditLinkAssessment();
                if (resultClickEdit)
                {
                    var checkSubmitTheAssessmentToTheInsuranceAgentEnable = builderPage.CheckSubmitTheAssessmentToTheInsuranceAgent();
                    if (checkSubmitTheAssessmentToTheInsuranceAgentEnable)
                    {
                        builderPage.ClickSubmitTheAssessmentToTheInsuranceAgentButton();
                        //Verify Insurance Agent label at the top of the screen is highlighted green
                        var checkInsuranceAgentLabel = builderPage.VerifyColorInsuranceAgentLabel();
                        Assert.IsTrue(checkInsuranceAgentLabel);
                    }
                }
                else
                    Assert.IsTrue(resultClickEdit);
            }
            else
                Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void EnterEligibilityLimitsIntoAnAssessment()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("nguyenv", "Abc123456@");

            GoToSearchBeat();
            var licenceNumber = "94116C";

            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {

                builderPage.ClickViewAssessments();
                var resultClickEdit = builderPage.ClickEditLinkAssessment();
                if (resultClickEdit)
                {
                    builderPage.ClickEligibilityDetails();
                    builderPage.ClickCopyAllLimitsLink();
                    builderPage.ClickButtonSaveEligibilityReview();
                    builderPage.WaitTillBusyDialogClose();

                    builderPage.ClickBeginAssessment();
                    builderPage.WaitTillBusyDialogClose();
                }
                else
                    Assert.IsTrue(resultClickEdit);
            }
            else
                Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void AlterAnEligibilityProfileLimit()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("nguyenv", "Abc123456@");

            GoToSearchBeat();
            var licenceNumber = "94116C";

            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {

                builderPage.ClickViewAssessments();
                var resultClickEdit = builderPage.ClickEditLinkAssessment();
                if (resultClickEdit)
                {
                    builderPage.ClickEligibilityDetails();
                    builderPage.ChangeValueSwimmingPools();
                    builderPage.ClickButtonSaveEligibilityReview();

                    //Verify Value Swimming Pools
                    var checkValueSwimmingPools = builderPage.VerifyValueSwimmingPools();
                    Assert.IsTrue(checkValueSwimmingPools);
                }
                else
                    Assert.IsTrue(resultClickEdit);
            }
            else
                Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void AlterOpenJobLimitValue()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("nguyenv", "Abc123456@");

            GoToSearchBeat();
            var licenceNumber = "94116C";

            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {

                builderPage.ClickViewAssessments();
                var resultClickEdit = builderPage.ClickEditLinkAssessment();
                if (resultClickEdit)
                {
                    builderPage.ClickEligibilityDetails();
                    builderPage.ChangeAlterOpenJobLimitValue();
                    builderPage.ClickButtonSaveEligibilityReview();

                    //Verify NSW Open Job Limit Value
                    Thread.Sleep(2000);
                    var checkAlterOpenJobLimitValue = builderPage.VerifyAlterOpenJobLimitValue();
                    Assert.IsTrue(checkAlterOpenJobLimitValue);
                }
                else
                    Assert.IsTrue(resultClickEdit);
            }
            else
                Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void ResetAssumedTurnoverForAnAssessment()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("nguyenv", "Abc123456@");

            GoToSearchBeat();
            var licenceNumber = "94116C";

            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {

                builderPage.ClickViewAssessments();
                var resultClickEdit = builderPage.ClickEditLinkAssessment();
                if (resultClickEdit)
                {
                    builderPage.ClickEligibilityDetails();
                    builderPage.ChangeAlterOpenJobLimitValue();
                    builderPage.DeleteValueAssumedNSWHBCFTurnover();
                    builderPage.ClickButtonSaveEligibilityReview();

                    //Verify Assumed NSW HBCF Turnover
                    builderPage.WaitTillBusyDialogClose();
                    var checkAlterOpenJobLimitValue = builderPage.VerifyValueChangeAssumedNSWHBCFTurnover();
                    Assert.IsTrue(checkAlterOpenJobLimitValue);
                }
                else
                    Assert.IsTrue(resultClickEdit);
            }
            else
                Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void BeginAnAssessment()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("nguyenv", "Abc123456@");

            GoToSearchBeat();
            var licenceNumber = "94116C";

            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewAssessments();
                var resultClickEdit = builderPage.ClickEditLinkAssessment();
                FinaliseAssessment();
                if (resultClickEdit)
                {
                    builderPage.ClickEligibilityDetails();
                    builderPage.ClickCopyAllLimitsLink();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(1000);
                    builderPage.ClickButtonSaveEligibilityReview();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(1000);
                    Assert.IsTrue(builderPage.VerifyBeginAssessmentIsEnabled());
                }
            }
        }

        [TestMethod]
        public void UpdateTrackRecord()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("nguyenv", "Abc123456@");

            GoToSearchBeat();
            var licenceNumber = "220292C";

            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewAssessments();
                var resultClickEdit = builderPage.ClickEditLinkAssessment();
                if (resultClickEdit)
                {
                    builderPage.ClickMenuTrackRecord();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(1000);
                    SetValueForTrackRecordScreen(TradingStructure.SoleTrader, YearsTrading.NilTo1Year, YearsTrading.Greater3To5Year
                        , AdverseHistory.CleanHistory, TradeCreditHistory.CleanHistory, DirectorsProfile.Marginal, PastBusinessClosures.NoPrevious);
                    
                    var resultCheckWeightedTrackRecordScoreLabel = TrackRecordService.CheckWeightedTrackRecordScoreLabel("4");
                    Assert.IsTrue(resultCheckWeightedTrackRecordScoreLabel);
                }
                else
                    Assert.IsTrue(resultClickEdit);
            }
            else
                Assert.IsTrue(searchResult);
        }

        [TestMethod]
        public void EnterFinancials()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("nguyenv", "Abc123456@");

            GoToSearchBeat();
            var licenceNumber = "220292C";

            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewAssessments();
                var resultClickEdit = builderPage.ClickEditLinkAssessment();
                if (resultClickEdit)
                {
                    builderPage.ClickButtonFinancialInputsMenu();
                    var result = builderPage.SetFinancialInformation();
                    builderPage.WaitTillBusyDialogClose();
                    Assert.IsTrue(result);
                }
                else
                    Assert.IsTrue(resultClickEdit);
            }
            else
                Assert.IsTrue(searchResult);
        }

        //HWIT-4379
        [TestMethod]
        public void LastUserAndBeatLastEditedFieldForAssessmentShouldBeUpdated()
        {
            var currentUser = "nguyenv";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "Abc123456@");

            GoToSearchBeat();
            var licenceNumber = "94116C";

            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewAssessments();
                var rowEdit = builderPage.CheckEditLinkAssessment();
                if (rowEdit > 0)
                {
                    var lastEdited = builderPage.GetColTextOfAssessmentTable(rowEdit, 6);
                    var lastUser = builderPage.GetColTextOfAssessmentTable(rowEdit, 7);
                    if (currentUser != lastUser)
                    {
                        var resultClickEdit = builderPage.ClickEditLinkAssessment();
                        if (resultClickEdit)
                        {
                            builderPage.ClickButtonFinancialInputsMenu();
                            builderPage.SetValueSalesRow("99000");
                            var saleSave = builderPage.GetSaveButtonWithSubHeaderRow();
                            saleSave.Click();
                            builderPage.WaitTillBusyDialogClose();
                            builderPage.NavigateToSearchAndSearch(licenceNumber);
                            builderPage.ClickViewAssessments();

                            var newLastEdited = builderPage.GetColTextOfAssessmentTable(rowEdit, 6);
                            var newLastUser = builderPage.GetColTextOfAssessmentTable(rowEdit, 7);

                            Assert.IsTrue(newLastEdited != lastEdited && newLastUser != lastUser);
                        }
                        else
                        {
                            Assert.IsTrue(resultClickEdit);
                        }
                    }
                    else
                    {
                        Assert.IsTrue(lastUser == currentUser);
                    }

                }
                else
                {
                    Assert.IsTrue(rowEdit > 0);
                }
            }
            else
            {
                Assert.IsTrue(searchResult);
            }
        }

        //HWIT-4380
        [TestMethod]
        public void LastUserShouldntBeUpdated()
        {
            var currentUser = "nguyenv";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "Abc123456@");

            GoToSearchBeat();
            var licenceNumber = "94116C";

            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewAssessments();

                var rowEdit = builderPage.CheckEditLinkAssessment();
                if (rowEdit > 0)
                {
                    var lastUserOfEditAssessment = builderPage.GetColTextOfAssessmentTable(rowEdit, 7);
                    if (lastUserOfEditAssessment != currentUser)
                    {
                        var rowView = builderPage.CheckViewAssessment();
                        if (rowView > 0)
                        {
                            var lastUserOfViewAssessment = builderPage.GetColTextOfAssessmentTable(rowView, 7);
                            builderPage.ClickViewLinkAssessment();
                            builderPage.ClickButtonFinancialInputsMenu();
                            builderPage.WaitTillBusyDialogClose();

                            builderPage.ClickButtonOverallOutcomeMenu();
                            builderPage.WaitTillBusyDialogClose();


                            builderPage.NavigateToSearchAndSearch(licenceNumber);

                            builderPage.ClickViewAssessments();
                            var newLastUserOfViewAssessment = builderPage.GetColTextOfAssessmentTable(rowView, 7);
                            if (newLastUserOfViewAssessment == lastUserOfViewAssessment)
                            {
                                builderPage.ClickEditLinkAssessment();
                                builderPage.ClickButtonFinancialInputsMenu();
                                builderPage.WaitTillBusyDialogClose();

                                builderPage.ClickButtonOverallOutcomeMenu();
                                builderPage.WaitTillBusyDialogClose();

                                builderPage.NavigateToSearchAndSearch(licenceNumber);
                                builderPage.ClickViewAssessments();

                                var newLastUserOfEditAssessment = builderPage.GetColTextOfAssessmentTable(rowEdit, 7);
                                Assert.IsTrue(lastUserOfEditAssessment == newLastUserOfEditAssessment);
                            }
                            else
                            {
                                Assert.IsTrue(newLastUserOfViewAssessment == lastUserOfViewAssessment);
                            }
                        }
                        else
                        {
                            Assert.IsTrue(rowView > 0);
                        }
                    }
                    else
                    {
                        Assert.IsTrue(currentUser == lastUserOfEditAssessment);
                    }

                }
                else
                {
                    Assert.IsTrue(rowEdit > 0);
                }
            }
            else
            {
                Assert.Fail();
            }
        }

        //HWIT-4389
        [TestMethod]
        public void SubmitToHBCFFunctionality()
        {
            //DateTime currentTime;
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            GoToSearchBeat();
            var licenceNumber = "94116C";

            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewAssessments();
                var assessmentId = builderPage.GetEditAssessmentId();
                var resultClickEdit = builderPage.ClickEditLinkAssessment();
                if (resultClickEdit)
                {
                    FinaliseAssessment();
                    builderPage.ClickEligibilityDetails();
                    builderPage.ClickCopyAllLimitsLink();

                    builderPage.ClickButtonSaveEligibilityReview();
                    builderPage.WaitTillBusyDialogClose();
                    
                    builderPage.ClickBeginAssessment();
                    builderPage.WaitTillBusyDialogClose();

                    Assert.IsTrue(builderPage.CheckTrackRecordMenuEnable());

                    builderPage.ClickButtonFinancialInputsMenu();
                    builderPage.SetValueSalesRow("5000000");

                    var saleSaveButton = builderPage.GetSaveButtonWithSubHeaderRow();
                    saleSaveButton.Click();

                    builderPage.WaitTillBusyDialogClose();

                    builderPage.ClickButtonOverallOutcomeMenu();
                    builderPage.SetValueForHBCFOpenJobLimit("55000000", "65");
                    builderPage.ClickSaveOutcomeDetailsButton();
                    builderPage.WaitTillBusyDialogClose();
                    Assert.IsTrue(OverallOutcomeService.CheckDelegationApprovalText(Common.LblDelegationApproval));
                    builderPage.SetValueForUnderWriterAssessmentOutcomeDropDown("Referred (see below)");
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(2000);
                    builderPage.SetValueForReferredToDropDown("Level A - HBCF");
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(2000);
                    Assert.IsTrue(builderPage.IsRequestDelegationApprovalButtonEnabled() && builderPage.IsSubmitToHBCFButtonEnabled());

                    builderPage.ClickSubmitToHBCFButton();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(2000);
                    builderPage.ClickInitiateMenuButton();
                    Thread.Sleep(2000);
                    Assert.IsTrue(builderPage.VerifyAssignedToSuttont());
                    Assert.IsTrue(builderPage.VerifyHBCFLabel());
                    builderPage.ClickKeyEventsLogButtonMenu();
                    Thread.Sleep(2000);
                    builderPage.SetLicenseNumberSearchEventLogs(licenceNumber);
                    Thread.Sleep(2000);
                    builderPage.ClickButtonSearchKeyEventLogs();
                    Thread.Sleep(2000);
                    if (builderPage.GetSearchResultKeyEventLog())
                    {
                        var actionRequired = builderPage.CheckActionRequiredByKeyEventLogs(currentUser);
                        var emailVerify = builderPage.CheckEmailSentKeyEventLogs(currentUser);
                        Assert.IsTrue(actionRequired && emailVerify);
                    }
                    else
                    {
                        Assert.IsTrue(builderPage.GetSearchResultKeyEventLog());
                    }
                }
            }
        }

        //HWIT-4390
        [TestMethod]
        public void RequestDelegationApprovalFromHBCF()
        {
            DateTime currentTime;
            var currentUser = MemberInfo.Username;
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, MemberInfo.Password);

            GoToSearchBeat();
            var licenceNumber = "94116C";

            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewAssessments();
                var assessmentId = builderPage.GetEditAssessmentId();
                Assert.IsTrue(assessmentId > 0);
                var resultClickEdit = builderPage.ClickEditLinkAssessment();
                Thread.Sleep(2000);
                if (resultClickEdit)
                {
                    FinaliseAssessment();
                    builderPage.ClickEligibilityDetails();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(2000);
                    builderPage.ClickCopyAllLimitsLink();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(2000);
                    builderPage.ClickButtonSaveEligibilityReview();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(2000);
                    builderPage.ClickBeginAssessment();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(2000);
                    Assert.IsTrue(builderPage.CheckTrackRecordMenuEnable());
                    builderPage.ClickButtonFinancialInputsMenu();
                    Thread.Sleep(2000);
                    builderPage.SetValueSalesRow("5000000");
                    Thread.Sleep(2000);
                    var saleSaveButton = builderPage.GetSaveButtonWithSubHeaderRow();
                    saleSaveButton.Click();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(2000);
                    builderPage.ClickButtonOverallOutcomeMenu();
                    Thread.Sleep(2000);
                    builderPage.SetValueForHBCFOpenJobLimit("55000000", "65");
                    Thread.Sleep(2000);
                    builderPage.ClickSaveOutcomeDetailsButton();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(2000);
                    Assert.IsTrue(OverallOutcomeService.CheckDelegationApprovalText(Common.LblDelegationApproval));
                    builderPage.SetValueForUnderWriterAssessmentOutcomeDropDown("Referred (see below)");
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(2000);
                    builderPage.SetValueForReferredToDropDown("Level A - HBCF");
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(2000);
                    Assert.IsTrue(builderPage.IsRequestDelegationApprovalButtonEnabled() && builderPage.IsSubmitToHBCFButtonEnabled());

                    currentTime = DateTime.Now;
                    builderPage.ClickRequestDelegationApprovalButton();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(2000);
                    builderPage.ClickInitiateMenuButton();
                    Thread.Sleep(2000);
                    Assert.IsTrue(builderPage.VerifyAssignedToSuttont());
                    Assert.IsTrue(builderPage.VerifyHBCFLabel());
                    builderPage.ClickKeyEventsLogButtonMenu();
                    Thread.Sleep(2000);
                    builderPage.SetLicenseNumberSearchEventLogs(licenceNumber);
                    Thread.Sleep(2000);
                    builderPage.ClickButtonSearchKeyEventLogs();
                    Thread.Sleep(2000);
                    if (builderPage.GetSearchResultKeyEventLog())
                    {
                        var actionRequired = builderPage.CheckActionRequiredByKeyEventLogs(currentUser);
                        var emailVerify = builderPage.CheckEmailSentKeyEventLogs(currentUser);
                        Assert.IsTrue(actionRequired && emailVerify);
                    }
                    else
                    {
                        Assert.IsTrue(builderPage.GetSearchResultKeyEventLog());
                    }
                }
            }
        }


        [TestMethod]
        public void RequestNewBuilder()
        {
            var currentUser = "nguyenv";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "Abc123456@");

            GoToSearchBeat();


            builderPage.ClickButtonRequestNewBuilderMenu();

            var header = new string[] { "Broker Name", "Builder Name", "Builder ABN/ACN", "Licence Number", "Request Date", "Status" };

            Assert.IsTrue(builderPage.IsRequestNewBuilderHeaderContainsColumns(header));

            var builderName = DateTime.Now.ToShortDateString();
            var abnacn = "85285285288";
            builderPage.SetTextEntityNameRequestNewBuilder(builderName);
            builderPage.SetTextABNACNRequestNewBuilder(abnacn);
            builderPage.ClickAddFileRequestNewBuilder();

            var filePath = Common.FilePath;
            var fileName = "test.txt";
            // ??? builderPage.SelectFileUpload(filePath + fileName);
            builderPage.ClickButtonRequestNewBuilder();

            var isExistBuilderInTable = builderPage.CheckBuilderExistInRequestNewBuilderTable(builderName, abnacn);
            if (isExistBuilderInTable)
            {
                driver.Navigate().GoToUrl("https://portal-uat.hbcf.nsw.gov.au/portal/server.pt?open=space&name=Login&control=Login&login=&in_hi_userid=953&cached=true");
                currentUser = "CSCTestC";
                loginPage = new LoginPage(driver);
                loginPage.Login(currentUser, "xBA7SHg$5acY");
                GoToSearchBeat();


                builderPage.ClickButtonRequestNewBuilderMenu();
                Assert.IsTrue(builderPage.IsRequestNewBuilderHeaderContainsColumns(header));
                builderPage.CheckBuilderExistInRequestNewBuilderTable(builderName, abnacn);
            }
            else
            {
                Assert.Fail();
            }
        }

        //HWIT-4404
        [TestMethod]
        public void CreateNewBuilderValidation()
        {
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            GoToSearchBeat();
            
            builderPage.ClickCreateNewBuilderButtonMenu();
            builderPage.ClickCloseLicenseLookUp();
            Thread.Sleep(1000);
            builderPage.ClickImageLookUpButton();
            Thread.Sleep(1000);
            builderPage.SetValueInputLookUpAbn("33082497247");
            Thread.Sleep(1000);
            builderPage.ClickSearchButtonAbnLookUp();
            builderPage.WaitTillAbnLookUpDialogClose();
            Thread.Sleep(1000);
            builderPage.SetValueBuilderEntityType("Company");
            Thread.Sleep(1000);
            builderPage.SetValuePrimaryBuilderSegmentOnApplication("New Single Dwellings (Detached)");
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(1000);
            builderPage.SetValueDistributorSelect("84076460967 : HIA INSURANCE SERVICES (NSW)");
            if (builderPage.IsConfirmDistributorChangeDialogOpen())
            {
                builderPage.ClickConfirmDistributorChangeDialog();
            }

            builderPage.ClickSaveBuilderDetailButton();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(1000);
            var result = OverallOutcomeService.CheckValidationErrorDialogOpen();
            Assert.IsTrue(result);
        }

        //HWIT-4407
        [TestMethod]
        public void AddNewDeedBuilderSummaryScreen()
        {
            var currentUser = "nguyenv";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "Abc123456@");

            GoToSearchBeat();
            
            var licenceNumber = "131951C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewBuilder();
                var rows = builderPage.CountDoiTBodyRow();

                builderPage.ClickButtonAddNewDOI();

                builderPage.SetValueDoiType("Job Specific Deed");
                Thread.Sleep(1000);
                builderPage.SetValueMaxAmoutInput("65000");
                Thread.Sleep(1000);
                builderPage.SetValuePolicyNumberInput("HBCF102030");
                Thread.Sleep(1000);
                builderPage.SetValueLotStreetNoInput("321 Kent");
                Thread.Sleep(1000);
                builderPage.SetStreetNameInput("Street");
                Thread.Sleep(1000);
                builderPage.SetValueSuburbInput("Sydney");
                Thread.Sleep(1000);
                builderPage.SetValuePostCodeInput("2000");
                Thread.Sleep(1000);

                builderPage.ClickAddIndemnifierButton();
                Thread.Sleep(3000);
                builderPage.ClickCompanyRadioButton();
                Thread.Sleep(3000);
                builderPage.SetValueNameInput("Lodestone Solutions");
                Thread.Sleep(1000);
                builderPage.SetValueABNInput("12345678912");
                Thread.Sleep(1000);
                builderPage.SetValueAddressInput("17 Alberta Street");
                Thread.Sleep(1000);
                builderPage.SetValueStateSelect("New South Wales");
                Thread.Sleep(1000);
                builderPage.SetValuePostCodeInputIndemnifier("2000");
                Thread.Sleep(1000);

                builderPage.ClickButtonOkAddIndemnifier();
                Thread.Sleep(1000);
                builderPage.ClickButtonOkNewDeedOfIndemninty();
                builderPage.WaitTillSaveDeedOfIndemnityDialogClose();
                Thread.Sleep(1000);
                Assert.IsTrue(builderPage.CountDoiTBodyRow() > rows);
            }
            else
            {
                Assert.Fail();
            }
        }

        //HWIT-4408
        [TestMethod]
        public void EditAndEmailBuilderSummaryScreen()
        {
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            GoToSearchBeat();


            var licenceNumber = "131951C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                var builderName = builderPage.GetBuilderName();
                var builderAbn = builderPage.GetBuilderABN();

                builderPage.ClickViewBuilder();
                var rows = builderPage.CountDoiTBodyRow();

                builderPage.ClickButtonAddNewDOI();

                builderPage.SetValueDoiType("Job Specific Deed");
                builderPage.SetValueMaxAmoutInput("65000");
                builderPage.SetValuePolicyNumberInput("HBCF102030");
                builderPage.SetValueLotStreetNoInput("321 Kent");
                builderPage.SetStreetNameInput("Street");
                builderPage.SetValueSuburbInput("Sydney");
                builderPage.SetValuePostCodeInput("2000");

                builderPage.ClickAddIndemnifierButton();
                builderPage.ClickCompanyRadioButton();
                builderPage.SetValueNameInput("Lodestone Solutions");
                builderPage.SetValueABNInput("12345678912");
                builderPage.SetValueAddressInput("17 Alberta Street");
                builderPage.SetValueStateSelect("New South Wales");
                builderPage.SetValuePostCodeInputIndemnifier("2000");

                builderPage.ClickButtonOkAddIndemnifier();
                builderPage.ClickButtonOkNewDeedOfIndemninty();
                builderPage.WaitTillSaveDeedOfIndemnityDialogClose();
                var newTotalRow = builderPage.CountDoiTBodyRow();
                Assert.IsTrue(newTotalRow > rows);

                builderPage.ClickEditLastDoi();
                var newValue = "69000";
                builderPage.SetValueMaxAmoutInput(newValue);
                builderPage.ClickButtonOkNewDeedOfIndemninty();
                builderPage.WaitTillSaveDeedOfIndemnityDialogClose();
                builderPage.ClickOkConfirmABNChange();
                builderPage.WaitTillSaveDeedOfIndemnityDialogClose();
                Assert.IsTrue(builderPage.ValidateMaxAmoutUpdated(newValue));
                Thread.Sleep(2000);
                builderPage.ClickEmailButtonLastRowDoi();
                builderPage.WaitTillRenderingEmailTemplateDialogClose();

                Assert.IsTrue(builderPage.CheckEmailContentContainsNameAndAnbAndLicense(builderName, builderAbn, licenceNumber));

                builderPage.ClickSendButton();
                builderPage.WaitTillQueueingEmailDialogClose();
                Assert.IsTrue(builderPage.CheckEmailSucessDialog("The email has been successfully queued"));
            }
            else
            {
                Assert.Fail();
            }
        }

        //HWIT-4409
        [TestMethod]
        public void ViewDraftUploadDoiBuilderSummary()
        {
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            GoToSearchBeat();


            var licenceNumber = "131951C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                var builderName = builderPage.GetBuilderName();
                var builderAbn = builderPage.GetBuilderABN();

                builderPage.ClickViewBuilder();
                var rows = builderPage.CountDoiTBodyRow();

                builderPage.ClickButtonAddNewDOI();

                builderPage.SetValueDoiType("Job Specific Deed");
                builderPage.SetValueMaxAmoutInput("65000");
                builderPage.SetValuePolicyNumberInput("HBCF102030");
                builderPage.SetValueLotStreetNoInput("321 Kent");
                builderPage.SetStreetNameInput("Street");
                builderPage.SetValueSuburbInput("Sydney");
                builderPage.SetValuePostCodeInput("2000");

                builderPage.ClickAddIndemnifierButton();
                builderPage.ClickCompanyRadioButton();
                builderPage.SetValueNameInput("Lodestone Solutions");
                builderPage.SetValueABNInput("12345678912");
                builderPage.SetValueAddressInput("17 Alberta Street");
                builderPage.SetValueStateSelect("New South Wales");
                builderPage.SetValuePostCodeInputIndemnifier("2000");

                builderPage.ClickButtonOkAddIndemnifier();
                builderPage.ClickButtonOkNewDeedOfIndemninty();
                builderPage.WaitTillSaveDeedOfIndemnityDialogClose();
                var newTotalRow = builderPage.CountDoiTBodyRow();
                Assert.IsTrue(newTotalRow > rows);

                var lastDoiId = builderPage.GetIdLastDoi();
                builderPage.ClickViewDrafLastDoi();
                Thread.Sleep(10000);
                var files = Directory.GetFiles(FileDownloadPath, "DOI-" + lastDoiId + "*.*");
                if (files.Length > 0)
                {
                    var fileName = files[0];
                    builderPage.ClickUploadLastDoi();
                    // ??? builderPage.SelectFileUpload(fileName);
                    builderPage.WaitTillUploadDialogClose();
                    Assert.IsTrue(builderPage.CheckStatusActiveLastDoi());
                    builderPage.ClickDownloadLastDoi();
                    Thread.Sleep(5000);
                    files = Directory.GetFiles(FileDownloadPath, "DOI-" + lastDoiId + "*.*");
                    Assert.IsTrue(files.Length > 1);
                }
                else
                {
                    Assert.Fail(string.Format(MessageCommon.MsgNotFound, FileDownloadPath));
                }
            }
            else
            {
                Assert.Fail();
            }
        }

        //HWIT-4419
        [TestMethod]
        public void AddBusinessTradingName()
        {
            var currentUser = "nguyenv";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "Abc123456@");

            GoToSearchBeat();


            var licenceNumber = "131951C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewBuilder();
                var row = builderPage.GetRowsTbodyTradingName();
                builderPage.ClickAddBusinessTradingName();
                var value = "Test Builder";
                builderPage.SetValueBusinessTradingNameInput(value);
                builderPage.ClickButtonInsertTradingName();
                Assert.IsTrue(row < builderPage.GetRowsTbodyTradingName());
                Assert.IsTrue(builderPage.CheckTextBusinessTradingName(value));
                builderPage.ClickDeleteBusinessTradingName();
                Assert.IsTrue(row == builderPage.GetRowsTbodyTradingName());

            }
            else
            {
                Assert.Fail();
            }
        }

        //HWIT-4420
        [TestMethod]
        public void AddAttachmentForAssessment()
        {
            var currentUser = "nguyenv";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "Abc123456@");

            GoToSearchBeat();
            
            var licenceNumber = "94116C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewAssessments();
                var resultClickEdit = builderPage.ClickEditLinkAssessment();
                if (resultClickEdit)
                {
                    var filePath = Common.FilePath;
                    var fileName1 = "doc1.txt";
                    var fileName2 = "doc2.txt";
                    var fileName3 = "doc3.txt";
                    var description = "text";
                    builderPage.ClickUploadFinancialStatementsOfTheBuilder(filePath + fileName1);
                    builderPage.ClickUploadFinancialStatementsOfTheBuilder(filePath + fileName2);
                    builderPage.ClickUploadFinancialStatementsOfTheBuilder(filePath + fileName3);
                    //builderPage.SelectFileUpload("\"" + filePath + fileName1 + "\"" + " " + "\"" + filePath + fileName2 + "\"" + " " + "\"" + filePath + fileName3 + "\"");
                    builderPage.SetDescriptionInput(description);
                    builderPage.ClickContinue();
                    Thread.Sleep(5000);

                    //verify file upload
                    var resultUploadFile = builderPage.VerifyFileUploadStatement(fileName1, description);
                    Assert.IsTrue(resultUploadFile);
                    var resultUploadFile2 = builderPage.VerifyFileUploadStatement(fileName2, description);
                    Assert.IsTrue(resultUploadFile2);
                    var resultUploadFile3 = builderPage.VerifyFileUploadStatement(fileName3, description);
                    Assert.IsTrue(resultUploadFile3);

                    builderPage.ClickEligibilityDetails();
                    builderPage.ClickCopyAllLimitsLink();
                    builderPage.ClickButtonSaveEligibilityReview();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickBeginAssessment();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickButtonFinancialInputsMenu();
                    Thread.Sleep(3000);
                    builderPage.SetValueSalesRow("5000000");
                    var saleSaveButton = builderPage.GetSaveButtonWithSubHeaderRow();
                    saleSaveButton.Click();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickButtonOverallOutcomeMenu();

                    //builderPage.SetValueAssessmentStatus("Pending");
                    //builderPage.WaitTillBusyDialogClose();
                    //if (builderPage.IsDelegationApprovalCheckboxChecked())
                    //{
                    //    builderPage.ClickDelegationApprovalCheckbox();
                    //    builderPage.WaitTillBusyDialogClose();
                    //}
                    //builderPage.SetValueForHBCFOpenJobLimit("9000000", "15");
                    //Thread.Sleep(2000);
                    //builderPage.ClickSaveOutcomeDetailsButton();
                    OverallOutcomeService.SetHBCApprovedOpenJobLimitValueForGTA("9000000");
                    OverallOutcomeService.SetHBCApprovedOpenJobLimitNumberForGTA("15");

                    OverallOutcomeService.ClickSaveOutcomeDetailsButton();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(3000);

                    //// Navigate to group overall outcome screen
                    //builderPage.NavigateGroupOverallOutcomeScreen();
                    
                    // 18. Select the DUA checkbox for Delegation Approval (Underwriter E delegation or higher required to finalise). 
                    OverallOutcomeService.ClickDelegationApprovalCheckbox();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(3000);

                    //Assert.IsTrue(builderPage.CheckDelegationApprovalText("Underwriter C") || builderPage.CheckDelegationApprovalText("Underwriter D") || builderPage.CheckDelegationApprovalText("Underwriter E"));
                    //builderPage.ClickDelegationApprovalCheckbox();
                    //builderPage.WaitTillBusyDialogClose();
                    //Thread.Sleep(2000);

                    var date = DateTime.Now.AddHours(3).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    OverallOutcomeService.SetValueDateTermsOffered(date);
                    //builderPage.SetValueAssessmentStatus(EligibilityAssessmentStatus.TermsAccepted);
                    OverallOutcomeService.SetValueEligibilityAssessmentStatusDll(EligibilityAssessmentStatus.TermsAccepted);
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(2000);
                    //builderPage.ClickFinaliseAssessmentButton();
                    OverallOutcomeService.UpdateToMetIfIsNotMet();
                    OverallOutcomeService.ClickFinaliseAssessmentButton();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(2000);
                    builderPage.ClickInitiateMenuButton();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(2000);

                    resultUploadFile = builderPage.VerifyFileUploadStatement(fileName1, description);
                    Assert.IsTrue(resultUploadFile);
                    resultUploadFile2 = builderPage.VerifyFileUploadStatement(fileName2, description);
                    Assert.IsTrue(resultUploadFile2);
                    resultUploadFile3 = builderPage.VerifyFileUploadStatement(fileName3, description);
                    Assert.IsTrue(resultUploadFile3);
                }
            }
        }

        //HWIT-4422
        [TestMethod]
        public void VerifyLandingPage()
        {
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            driver.Navigate().GoToUrl("https://portal-uat.hbcf.nsw.gov.au/portal/server.pt/gateway/PTARGS_0_0_352_0_0_43/http%3B/portal-app/Beat/Home.aspx");


            builderPage.SetValueEntityName("Champion Homes");
            builderPage.ClickSearchHome();
            var searchResult = builderPage.ResultSearch();
            Assert.IsTrue(searchResult);
            Assert.IsTrue(driver.Url.Contains("SearchBeat.aspx"));
        }

        //HWIT-4423
        [TestMethod]
        public void DistributorAccessVerification()
        {
            var currentUser = "brktst109";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "Ry6VehK3#Qjw");

            driver.Navigate().GoToUrl("https://portal-uat.hbcf.nsw.gov.au/portal/server.pt/gateway/PTARGS_0_23722_352_0_0_43/http%3B/portal-app/BEAT/Home.aspx");

            builderPage.ClickHomeMenuButton();
            builderPage.ClickTaskAdministratorMenu();
            builderPage.ClickBuilderAndEligibilitiesMenu();
            builderPage.ClickChartMenu();
            builderPage.ClickKeyEventsLogButtonMenu();
            builderPage.ClickReportMenu();
            CheckExistsReport();
        }

        /// <summary>
        /// Upload file in 'Financial statements of the builder - for the last 2 years:' section of Initiate Review screen
        /// </summary>
        /// <param name="file"></param>
        private void UploadFileAttDivFinancialStatements(string file)
        {
            builderPage.ClickUploadFinancialStatementsOfTheBuilder(file);
            // ??? builderPage.SelectFileUpload(file);
            builderPage.SetDescriptionInput(Common.Description);
            builderPage.ClickContinue();
            Thread.Sleep(5000);
        }

        //HWIT-4421
        [TestMethod]
        public void VerifyDeleteAttachmentFunctionality()
        {
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            GoToSearchBeat();
            
            var licenceNumber = "94116C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewAssessments();
                var assessmentId = builderPage.GetEditAssessmentId();
                var resultClickEdit = builderPage.ClickEditLinkAssessment();
                if (resultClickEdit)
                {
                    //FinaliseAssessment();
                    string description = Common.Description;
                    UploadFileAttDivFinancialStatements(Common.FilePath + Common.FileName1);
                    UploadFileAttDivFinancialStatements(Common.FilePath + Common.FileName2);
                    UploadFileAttDivFinancialStatements(Common.FilePath + Common.FileName3);

                    //verify file upload
                    var resultUploadFile = builderPage.VerifyFileUploadStatement(Common.FileName1, description);
                    Assert.IsTrue(resultUploadFile);
                    var resultUploadFile2 = builderPage.VerifyFileUploadStatement(Common.FileName2, description);
                    Assert.IsTrue(resultUploadFile2);
                    var resultUploadFile3 = builderPage.VerifyFileUploadStatement(Common.FileName3, description);
                    Assert.IsTrue(resultUploadFile3);

                    builderPage.ClickEligibilityDetails();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(5000);
                    builderPage.ClickCopyAllLimitsLink();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickButtonSaveEligibilityReview();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickBeginAssessment();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickButtonFinancialInputsMenu();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(3000);
                    builderPage.SetValueSalesRow("5000000");
                    var saleSaveButton = builderPage.GetSaveButtonWithSubHeaderRow();
                    saleSaveButton.Click();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickButtonOverallOutcomeMenu();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(5000);
                    builderPage.SetValueForHBCFOpenJobLimit("9000000", "15");
                    builderPage.ClickSaveOutcomeDetailsButton();
                    builderPage.WaitTillBusyDialogClose();
                    //Assert.IsTrue(builderPage.CheckDelegationApprovalText("Underwriter C") || builderPage.CheckDelegationApprovalText("Underwriter D") || builderPage.CheckDelegationApprovalText("Underwriter E"));
                    if (!builderPage.IsDelegationApprovalCheckboxChecked())
                    {
                        builderPage.ClickDelegationApprovalCheckbox();
                        builderPage.WaitTillBusyDialogClose();
                        Thread.Sleep(3000);
                    }
                    var date = DateTime.Now.AddHours(3).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    builderPage.SetValueDateTermsOffered(date);
                    builderPage.SetValueAssessmentStatus("Terms Accepted");
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(3000);
                    builderPage.ClickFinaliseAssessmentButton();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickInitiateMenuButton();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(5000);

                    resultUploadFile = builderPage.VerifyFileUploadStatement(Common.FileName1, description);
                    Assert.IsTrue(resultUploadFile);
                    resultUploadFile2 = builderPage.VerifyFileUploadStatement(Common.FileName2, description);
                    Assert.IsTrue(resultUploadFile2);
                    resultUploadFile3 = builderPage.VerifyFileUploadStatement(Common.FileName3, description);
                    Assert.IsTrue(resultUploadFile3);

                    GoToSearchBeat();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.SetBuilderLicenceNumber(licenceNumber);
                    builderPage.ClickSearchBuilder();

                    searchResult = builderPage.ResultSearch();
                    if (searchResult)
                    {
                        builderPage.ClickViewAssessments();
                        Thread.Sleep(3000);
                        var assessment1Id = builderPage.GetEditAssessmentId();
                        resultClickEdit = builderPage.ClickEditLinkAssessment();
                        Thread.Sleep(3000);
                        if (resultClickEdit)
                        {
                            builderPage.ClickCopyPreviousAttachmentTermsAccepted();
                            Thread.Sleep(4000);
                            builderPage.ClickCopyPreviousAttachmentTermsAccepted();
                            Thread.Sleep(4000);

                            resultUploadFile = builderPage.VerifyFileUploadStatement(Common.FileName1, description);
                            Assert.IsTrue(resultUploadFile);
                            resultUploadFile2 = builderPage.VerifyFileUploadStatement(Common.FileName2, description);
                            Assert.IsTrue(resultUploadFile2);
                            resultUploadFile3 = builderPage.VerifyFileUploadStatement(Common.FileName3, description);
                            Assert.IsTrue(resultUploadFile3);

                            builderPage.DeleteStatementAttachment(Common.FileName1, description);

                            builderPage.ClickEligibilityDetails();
                            builderPage.WaitTillBusyDialogClose();
                            Thread.Sleep(5000);
                            builderPage.ClickCopyAllLimitsLink();
                            builderPage.WaitTillBusyDialogClose();
                            builderPage.ClickButtonSaveEligibilityReview();
                            builderPage.WaitTillBusyDialogClose();
                            Thread.Sleep(3000);
                            builderPage.ClickBeginAssessment();
                            builderPage.WaitTillBusyDialogClose();
                            Thread.Sleep(3000);
                            builderPage.ClickButtonFinancialInputsMenu();
                            builderPage.WaitTillBusyDialogClose();
                            Thread.Sleep(5000);
                            builderPage.SetValueSalesRow("5000000");
                            saleSaveButton = builderPage.GetSaveButtonWithSubHeaderRow();
                            saleSaveButton.Click();
                            builderPage.WaitTillBusyDialogClose();
                            builderPage.ClickButtonOverallOutcomeMenu();
                            builderPage.WaitTillBusyDialogClose();
                            Thread.Sleep(5000);
                            builderPage.SetValueForHBCFOpenJobLimit("9000000", "15");
                            builderPage.ClickSaveOutcomeDetailsButton();
                            builderPage.WaitTillBusyDialogClose();
                            //Assert.IsTrue(builderPage.CheckDelegationApprovalText("Underwriter C") || builderPage.CheckDelegationApprovalText("Underwriter D") || builderPage.CheckDelegationApprovalText("Underwriter E"));
                            if (!builderPage.IsDelegationApprovalCheckboxChecked())
                            {
                                builderPage.ClickDelegationApprovalCheckbox();
                                builderPage.WaitTillBusyDialogClose();
                            }
                            date = DateTime.Now.AddHours(3).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                            builderPage.SetValueDateTermsOffered(date);
                            builderPage.SetValueAssessmentStatus("Terms Accepted");
                            builderPage.WaitTillBusyDialogClose();
                            builderPage.ClickFinaliseAssessmentButton();
                            builderPage.WaitTillBusyDialogClose();
                            builderPage.ClickInitiateMenuButton();
                            builderPage.WaitTillBusyDialogClose();
                            Thread.Sleep(5000);

                            resultUploadFile = builderPage.VerifyFileUploadStatement(Common.FileName1, description);
                            Assert.IsFalse(resultUploadFile);
                            resultUploadFile2 = builderPage.VerifyFileUploadStatement(Common.FileName2, description);
                            Assert.IsTrue(resultUploadFile2);
                            resultUploadFile3 = builderPage.VerifyFileUploadStatement(Common.FileName3, description);
                            Assert.IsTrue(resultUploadFile3);

                            GoToSearchBeat();
                            builderPage.WaitTillBusyDialogClose();
                            Thread.Sleep(3000);
                            builderPage.SetBuilderLicenceNumber(licenceNumber);
                            builderPage.ClickSearchBuilder();
                            Thread.Sleep(3000);

                            builderPage.ResultSearch();
                            builderPage.ClickViewAssessments();
                            Thread.Sleep(3000);
                            builderPage.ClickViewAssessmentById(assessmentId.ToString());
                            resultUploadFile = builderPage.VerifyFileUploadStatement(Common.FileName1, description);
                            Assert.IsTrue(resultUploadFile);
                            Thread.Sleep(1000);
                            resultUploadFile2 = builderPage.VerifyFileUploadStatement(Common.FileName2, description);
                            Assert.IsTrue(resultUploadFile2);
                            Thread.Sleep(1000);
                            resultUploadFile3 = builderPage.VerifyFileUploadStatement(Common.FileName3, description);
                            Assert.IsTrue(resultUploadFile3);
                            Thread.Sleep(1000);

                            GoToSearchBeat();
                            builderPage.WaitTillBusyDialogClose();
                            Thread.Sleep(3000);
                            builderPage.SetBuilderLicenceNumber(licenceNumber);
                            builderPage.ClickSearchBuilder();
                            Thread.Sleep(3000);

                            builderPage.ResultSearch();
                            builderPage.ClickViewAssessments();
                            Thread.Sleep(3000);
                            builderPage.ClickEditLinkAssessment();
                            Thread.Sleep(5000);
                            builderPage.ClickCopyPreviousAttachmentTermsAccepted();
                            Thread.Sleep(5000);
                            builderPage.ClickCopyPreviousAttachmentTermsAccepted();
                            Thread.Sleep(3000);
                            resultUploadFile = builderPage.VerifyFileUploadStatement(Common.FileName1, description);
                            Thread.Sleep(3000);
                            Assert.IsFalse(resultUploadFile);
                            resultUploadFile2 = builderPage.VerifyFileUploadStatement(Common.FileName2, description);
                            Assert.IsTrue(resultUploadFile2);
                            Thread.Sleep(1000);
                            resultUploadFile3 = builderPage.VerifyFileUploadStatement(Common.FileName3, description);
                            Assert.IsTrue(resultUploadFile3);
                        }
                    }
                }
            }
        }

        //HWIT-4424
        [TestMethod]
        public void BEARValidateValuesPopulated()
        {
            var currentUser = "nguyenv";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "Abc123456@");

            GoToSearchBeat();


            var licenceNumber = "94116C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewAssessments();
                var resultClickEdit = builderPage.ClickEditLinkAssessment();
                if (resultClickEdit)
                {
                    builderPage.ClickEligibilityDetails();
                    builderPage.ClickCopyAllLimitsLink();
                    builderPage.ClickButtonSaveEligibilityReview();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickBeginAssessment();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickButtonFinancialInputsMenu();
                    builderPage.SetValueSalesRow("5000000");
                    builderPage.SetValueOpeningStock("250000");
                    builderPage.GetSaveButtonWithSubHeaderRow().Click();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickButtonOverallOutcomeMenu();
                    if (builderPage.IsDelegationApprovalCheckboxChecked())
                    {
                        builderPage.ClickDelegationApprovalCheckbox();
                        builderPage.WaitTillBusyDialogClose();
                    }
                    builderPage.ClearRecuringConditionForAssessment();
                    builderPage.CheckAndClickAreThereConditionCheckBox();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickAddConditionButton();
                    builderPage.SelectConditionDropDown("BCRP to apply to all projects over $750K");
                    builderPage.ClickButtonSaveConditionDialog();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickAddConditionButton();
                    builderPage.SelectConditionDropDown("Deed of Indemnity Required for Eligibility");
                    builderPage.SelectValueConditionStatus("Met");
                    builderPage.ClickButtonSaveConditionDialog();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickAddConditionButton();
                    builderPage.SelectConditionDropDown("Intensive Monitoring - Biannual Reporting (6 monthly)");
                    builderPage.ClickButtonSaveConditionDialog();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickAddConditionButton();
                    builderPage.SelectConditionDropDown("Working Capital Mitigation");
                    builderPage.SetValueInputCondition("67000");
                    builderPage.SelectValueConditionStatus("Met");
                    builderPage.ClickButtonSaveConditionDialog();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.SetValueKeyIssuesOrOtherConditions(" This is test builder");
                    builderPage.ClickSaveBuilderCommunicationButton();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.SetValueForHBCFOpenJobLimit("25000000", "35");
                    builderPage.ClickSaveOutcomeDetailsButton();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickPrintReport();
                }
                else
                {
                    Assert.Fail();
                }
            }
            else
            {
                Assert.Fail();
            }
        }

        //HWIT-4425
        [TestMethod]
        public void CSCUnderwriterAccessVerification()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login(MemberInfo.Username, MemberInfo.Password);

            GoToSearchBeat();

            builderPage.ClickHomeMenuButton();
            builderPage.ClickTaskAdministratorMenu();
            builderPage.ClickBuilderAndEligibilitiesMenu();
            builderPage.ClickButtonManageGroup();
            builderPage.ClickCreateNewBuilderButtonMenu();
            builderPage.ClickCloseLicenseLookUp();
            builderPage.ClickChartMenu();
            builderPage.ClickWorkflowManagementMenu();
            builderPage.ClickButtonRequestNewBuilderMenu();
            Thread.Sleep(2000);
            builderPage.ClickKeyEventsLogButtonMenu();
            Thread.Sleep(2000);
            builderPage.ClickReportMenu();
            Thread.Sleep(2000);
            CheckExistsReport();
        }

        /// <summary>
        /// Check report name in Report screen
        /// </summary>
        private void CheckExistsReport()
        {
            //var isTrue = builderPage.CheckEligibilitiesReportTableContainsValue("Activity Dashboard");
            //Assert.IsTrue(isTrue);
            var isTrue = builderPage.CheckEligibilitiesReportTableContainsValue("Aging Reviews");
            Assert.IsTrue(isTrue);
            isTrue = builderPage.CheckEligibilitiesReportTableContainsValue("Builder Audited Accounts");
            Assert.IsTrue(isTrue);
            isTrue = builderPage.CheckEligibilitiesReportTableContainsValue("Builder Condition Report");
            Assert.IsTrue(isTrue);
            isTrue = builderPage.CheckEligibilitiesReportTableContainsValue("Builder GTA Report");
            Assert.IsTrue(isTrue);
            isTrue = builderPage.CheckEligibilitiesReportTableContainsValue("Builder Portfolio Report");
            Assert.IsTrue(isTrue);
            isTrue = builderPage.CheckEligibilitiesReportTableContainsValue("Builder Risk Based Premium");
            Assert.IsTrue(isTrue);
            isTrue = builderPage.CheckEligibilitiesReportTableContainsValue("Builder utilisation from other insurers");
            Assert.IsTrue(isTrue);
            isTrue = builderPage.CheckEligibilitiesReportTableContainsValue("Builders Registered on the Builder Self Service Portal");
            Assert.IsTrue(isTrue);
            isTrue = builderPage.CheckEligibilitiesReportTableContainsValue("Changes to builder pricing in the last 30 days");
            Assert.IsTrue(isTrue);
            isTrue = builderPage.CheckEligibilitiesReportTableContainsValue("Eligibility assessments service level measurement");
            Assert.IsTrue(isTrue);
            isTrue = builderPage.CheckEligibilitiesReportTableContainsValue("Eligibility Assessments Terms Accepted Not Finalised");
            Assert.IsTrue(isTrue);
            isTrue = builderPage.CheckEligibilitiesReportTableContainsValue("Eligibility Assessments Terms Offered Not Accepted");
            Assert.IsTrue(isTrue);
            isTrue = builderPage.CheckEligibilitiesReportTableContainsValue("Eligibility Ten Days Notices");
            Assert.IsTrue(isTrue);
            isTrue = builderPage.CheckEligibilitiesReportTableContainsValue("Inactive Eligibility Utilised Jobs");
            Assert.IsTrue(isTrue);
            isTrue = builderPage.CheckEligibilitiesReportTableContainsValue("Referred to IA U/C and not Finalised");
            Assert.IsTrue(isTrue);
            isTrue = builderPage.CheckEligibilitiesReportTableContainsValue("Restricted Builders");
            Assert.IsTrue(isTrue);
            isTrue = builderPage.CheckEligibilitiesReportTableContainsValue("Review Completions");
            Assert.IsTrue(isTrue);
            isTrue = builderPage.CheckEligibilitiesReportTableContainsValue("Review Completions Size");
            Assert.IsTrue(isTrue);
            isTrue = builderPage.CheckEligibilitiesReportTableContainsValue("Scheduled Assigned Reviews");
            Assert.IsTrue(isTrue);
            isTrue = builderPage.CheckEligibilitiesReportTableContainsValue("Scheduled Reviews");
            Assert.IsTrue(isTrue);
            isTrue = builderPage.CheckEligibilitiesReportTableContainsValue("Scheduled Reviews Change");
            Assert.IsTrue(isTrue);
            isTrue = builderPage.CheckFinancialReportContainsValue("Distributor Invoice");
            Assert.IsTrue(isTrue);
        }

        //HWIT-4434
        [TestMethod]
        public void CheckStatementOfPersonalAssesstAndLiabilities()
        {
            var currentUser = "nguyenv";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "Abc123456@");

            GoToSearchBeat();


            var licenceNumber = "123259C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewBuilder();
                builderPage.ClickAddNewPrincipal();
                Thread.Sleep(5000);
                builderPage.SetPrincipalName("Chandan Kumar");
                builderPage.SetPrincipalDOB("1970");
                builderPage.SetPrincipalSuburb("Maroubra");
                builderPage.SetPrincipalRole("Director");
                builderPage.SetPrincipalNSW("12345");
                builderPage.SetPrincipalYearLicenseHeld("17");
                builderPage.SetPrincipalActive();
                Thread.Sleep(2000);
                builderPage.ClickSavePrincipal();
                Thread.Sleep(5000);

                builderPage.ClickAddNewPrincipal();
                Thread.Sleep(5000);
                builderPage.SetPrincipalName("Vinh Nguyen");
                builderPage.SetPrincipalDOB("1988");
                builderPage.SetPrincipalSuburb("Parramatta");
                builderPage.SetPrincipalRole("Director/Nominated Supervisor");
                builderPage.SetPrincipalNSW("4444");
                builderPage.SetPrincipalYearLicenseHeld("15");
                builderPage.UnSetPrincipalActive();
                Thread.Sleep(2000);
                builderPage.ClickSavePrincipal();
                Thread.Sleep(5000);

                Assert.IsTrue(builderPage.VerifyInfoAddNewPrincipal("Chandan Kumar", "1970", "Maroubra".ToUpper(), "Director", "12345", "17", true));
                Assert.IsTrue(builderPage.VerifyInfoAddNewPrincipal("Vinh Nguyen", "1988", "Parramatta".ToUpper(), "Director/Nominated Supervisor", "4444", "15", false));

                //GoToSearchBeat();
                //builderPage.SetBuilderLicenceNumber(licenceNumber);
                //builderPage.ClickSearchBuilder();
                //builderPage.ClickViewAssessments();
                //builderPage.ClickEditLinkAssessment();
                BuilderDetailsService.ClickEditLinkAssessmentBuilderDetail();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(5000);
                builderPage.ClickButtonPersonalStatement();
                Thread.Sleep(3000);

                Assert.IsTrue(builderPage.CheckValueExistInStatementPersonalTable("Chandan Kumar", "1970"));
                //Assert.IsFalse(builderPage.CheckValueExistInStatementPersonalTable("Vinh Nguyen", "1988"));
            }
            else
            {
                Assert.Fail();
            }
        }

        //HWIT-4437
        [TestMethod]
        public void RestrictionOnAssessmentsForBuilder()
        {
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            GoToSearchBeat();


            var entityName = "QUINN HOMES";
            builderPage.SetBuilderEntityName(entityName);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewBuilder();
                Thread.Sleep(3000);
                var row = builderPage.ClickViewActiveEligibility();
                Thread.Sleep(2000);
                builderPage.ClickRestrictionToggle();
                builderPage.SetValueRestrictedJobNumber("2");
                Thread.Sleep(1000);
                builderPage.SetValueRestrictedJobValue("50000");
                Thread.Sleep(1000);
                builderPage.ClickbuttonSavechangeseligibilityDetail();
                builderPage.WaitTillBusyDialogClose();
                Util.GoBack();
                Thread.Sleep(3000);
                Util.RefreshPage();
                Thread.Sleep(3000);
                Assert.IsTrue(builderPage.CheckRestrictedStatusEligibility(row, "Yes"));
                builderPage.ClickKeyEventsLogButtonMenu();
                Thread.Sleep(3000);
                builderPage.SetValueEventDropDown("COE Updated");
                Thread.Sleep(1000);
                builderPage.ClickButtonSearchKeyEventLogs();
                Thread.Sleep(5000);
                Assert.IsTrue(builderPage.CheckCOEUpdated(entityName, currentUser));
            }
        }

        //HWIT-4464
        [TestMethod]
        public void OldAssessmentsAreAccessibleInReportTermsAcceptedNotFinalised()
        {
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            GoToSearchBeat();
            
            builderPage.ClickReportMenu();
            Thread.Sleep(5000);
            builderPage.ClickReport("Eligibility Assessments Terms Accepted Not Finalised");
            Thread.Sleep(5000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Thread.Sleep(5000);
            // Sort
            ReportsService.SortRows("Distributor");
            builderPage.ClickTermsAcceptedDateEaTermsAcceptedNotFinalised();
            Thread.Sleep(5000);
            builderPage.ClickButtonFinancialInputsMenu();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);
            builderPage.ClickButtonPersonalStatement();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);
            builderPage.ClickButtonFinancialInputsMenu();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);
            builderPage.ClickMenuTrackRecord();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);
            builderPage.ClickEligibilityDetails();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);
            builderPage.ClickInitiateMenuButton();
            builderPage.WaitTillBusyDialogClose();
        }

        //HWIT-4465
        [TestMethod]
        public void OldAssessmentAreAccessibleInReportTermsOfferredNotAccepted()
        {
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            GoToSearchBeat();
            
            builderPage.ClickReportMenu();
            Thread.Sleep(5000);
            Assert.IsTrue(builderPage.ClickReport("Eligibility Assessments Terms Offered Not Accepted"));
            Thread.Sleep(5000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            // Sort
            ReportsService.SortRows("Eligibility Assessment Type");

            // Click first row
            builderPage.ClickTermsAcceptedDateEaTermsAcceptedNotFinalised();
            Thread.Sleep(5000);
            builderPage.ClickButtonFinancialInputsMenu();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);
            builderPage.ClickButtonPersonalStatement();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);
            builderPage.ClickButtonFinancialInputsMenu();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);
            builderPage.ClickMenuTrackRecord();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);
            builderPage.ClickEligibilityDetails();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);
            builderPage.ClickInitiateMenuButton();
            builderPage.WaitTillBusyDialogClose();
        }

        //HWIT-4469
        [TestMethod]
        public void VerifyChangesToBuilderPricingInTheLast30Days()
        {
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            GoToSearchBeat();


            builderPage.ClickReportMenu();
            builderPage.ClickReport("Changes to builder pricing in the last 30 days");

            Thread.Sleep(5000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            var licence = builderPage.GetBuilderLicenceReport();
            Assert.IsTrue(licence.Length > 0);
            var overallImpact = builderPage.GetCurrentOverallImpactFirstRowReport(licence).Replace(" ", "");

            builderPage.ClickHomeMenuButton();

            builderPage.SetBuilderLicenceHome(licence);
            builderPage.ClickSearchHome();

            builderPage.ClickViewBuilder();
            var builderPremiumPricing = builderPage.GetBuilderPremiumPricing();
            Assert.IsTrue(builderPremiumPricing.Contains(overallImpact.Replace("-", "")));
            if (overallImpact.Contains("-"))
            {
                Assert.IsTrue(builderPremiumPricing.Contains("DISCOUNT"));
            }
            else
            {
                Assert.IsTrue(builderPremiumPricing.Contains("LOADING"));
            }

        }

        //HWIT-4470
        [TestMethod]
        public void VerifyReportBuilderUtilisationFromOtherInsurers()
        {
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            GoToSearchBeat();


            builderPage.ClickReportMenu();
            builderPage.ClickReport("Builder utilisation from other insurers");

            Thread.Sleep(5000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Assert.IsTrue(builderPage.IsReportEmpty());
        }

        //HWIT-4473
        [TestMethod]
        public void VerifyReportShowAllReviewsScheduledButNotCompletedOnDayRunTheReport()
        {
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            GoToSearchBeat();
            
            builderPage.ClickReportMenu();
            builderPage.ClickReport("Aging Reviews");

            Thread.Sleep(5000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            builderPage.WaitForTableToAccessible();
            Thread.Sleep(5000);
            builderPage.ClickSchedDate();
            builderPage.WaitTillLoadingReportClose();
            builderPage.ClickFirstRowReport();
            var isTrue = builderPage.IsInitialReviewEnable();
            Assert.IsFalse(isTrue);
            //Assert.IsTrue(builderPage.IsEligibilityDetailsEnable());
            isTrue = builderPage.IsTrackRecordEnable();
            Thread.Sleep(2000);
            Assert.IsFalse(isTrue);
            isTrue = builderPage.IsFinalcialInputEnable();
            Thread.Sleep(2000);
            Assert.IsFalse(isTrue);
            isTrue = builderPage.IsPersonalStatementEnable();
            Thread.Sleep(2000);
            Assert.IsFalse(isTrue);
            isTrue = builderPage.IsFinancialOutputEnable();
            Thread.Sleep(2000);
            Assert.IsFalse(isTrue);
            isTrue = builderPage.IsOverallOutcomeEnable();
            Thread.Sleep(2000);
            Assert.IsFalse(isTrue);
            // 9. If the tabs are available, Navigate to the overall outcome screen and confirm 
            // the Button -"Print Builder Eligibility Assessment Report" is available(can be clicked) 
            // at the bottom of the screen for the non -GTA Builders. 
            // In case of GTA Builders validate the button is available(Clickable) on the Group Overall outcome screen. 
            if (builderPage.IsOverallOutcomeEnable())
            {
                builderPage.ClickButtonOverallOutcomeMenu();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(2000);
                if (builderPage.IsMainContentPanelExist())
                {
                    builderPage.ClickGroupBuilder();
                    builderPage.WaitTillBusyDialogClose();
                }
                isTrue = builderPage.IsPrintEaReportEnable();
                Assert.IsTrue(isTrue);
            }
        }

        //HWIT-4480
        [TestMethod]
        public void AddCommentsDisabledForFinalisedAssessments()
        {
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            GoToSearchBeat();


            var licenceNumber = "94116C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewAssessments();
                builderPage.ClickViewLinkAssessment();

                Assert.IsFalse(builderPage.IsAddNewCommentButtonEnabled());

                currentUser = "Brktst109";
                driver.Navigate().GoToUrl("https://portal-uat.hbcf.nsw.gov.au/portal/server.pt?open=space&name=Login&control=Login&login=&in_hi_userid=953&cached=true");
                loginPage.Login(currentUser, "Ry6VehK3#Qjw");

                GoToSearchBeat();

                licenceNumber = "148605C";
                builderPage.SetBuilderLicenceNumber(licenceNumber);
                builderPage.ClickSearchBuilder();

                searchResult = builderPage.ResultSearch();
                if (searchResult)
                {
                    builderPage.ClickViewAssessments();
                    builderPage.ClickViewLinkAssessment();

                    Assert.IsFalse(builderPage.IsAddNewCommentButtonEnabled());
                }
            }
        }

        //HWIT-4481
        [TestMethod]
        public void ConditionDeedOfIndemnityRequiredForEligibilityMetDoNotDisplay()
        {
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            GoToSearchBeat();

            var licenceNumber = "94116C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewAssessments();
                builderPage.ClickEditLinkAssessment();

                builderPage.ClickEligibilityDetails();

                builderPage.ClickCopyAllLimitsLink();
                builderPage.ClickButtonSaveEligibilityReview();
                builderPage.WaitTillBusyDialogClose();

                builderPage.ClickBeginAssessment();
                builderPage.WaitTillBusyDialogClose();

                Assert.IsTrue(builderPage.IsTrackRecordEnable());

                builderPage.ClickButtonFinancialInputsMenu();
                builderPage.SetValueSalesRow("5000000");
                builderPage.SetValueOpeningStock("250000");

                builderPage.ClickSaleSaveButton();
                builderPage.WaitTillBusyDialogClose();

                builderPage.ClickButtonOverallOutcomeMenu();
                builderPage.ClearRecuringConditionForAssessment();


                // select the check box for the question, "Are there any conditions required as part of the terms to be offered?"
                if (builderPage.IsEnabledCheckBoxAnyConditionRequired())
                {
                    builderPage.SetCheckBoxAnyConditionsRequired(true);
                    builderPage.WaitTillBusyDialogClose();

                    // This should have enabled the "Add conditions" button.
                    if (!builderPage.IsEnabelAddConditionButton())
                    {
                        Assert.Fail(string.Format(MessageCommon.MsgDisabled, Common.AddConditionButton));
                        return;
                    }
                }

                // Click on "Add condition" button
                builderPage.ClickAddConditionButton2();
                builderPage.WaitTillBusyDialogClose();

                //builderPage.CheckAndClickAreThereConditionCheckBox();
                //builderPage.WaitTillBusyDialogClose();

                //builderPage.ClickAddConditionButton();
                builderPage.SelectConditionDropDown("Deed of Indemnity Required for Eligibility");
                builderPage.SelectValueConditionStatus("Not Met");
                builderPage.ClickButtonSaveConditionDialog();
                builderPage.WaitTillBusyDialogClose();

                builderPage.ClickButtonAddNewDOI();
                builderPage.CheckValueMaxAmout("50000");
                builderPage.ClickAddIndemnifierButton();
                builderPage.SetValueNameInputOverall("Lodestone Solutions");
                builderPage.SetValueABNOverall("12345678912");
                builderPage.SetValueAddress("17 Alberta Street");
                builderPage.SetValuePostCode("2000");
                builderPage.ClickOkAddIndemnifier();
                builderPage.ClickOkNewDeed();
                builderPage.WaitTillSaveDeedOfIndemnityDialogClose();

                builderPage.SetValueForHBCFOpenJobLimit("9000000", "25");

                builderPage.ClickSaveOutcomeDetailsButton();
                builderPage.WaitTillBusyDialogClose();

                builderPage.ClickPrintReport();
                Thread.Sleep(15000);
                //var url = driver.Url;
                //var assessmentId = url.Split(new string[] { "assessmentId=" }, StringSplitOptions.None)[1];
                //var filename = "BEAT-EligibilityAssessment-Report-" + assessmentId + ".pdf";

                //builderPage.WaitForBEATReportToDownload(filename);
                builderPage.ClickEditOrDeleteCondition(Common.LblEdit);
                builderPage.SelectValueConditionStatus("Met");
                builderPage.ClickButtonSaveConditionDialog();
                builderPage.WaitTillBusyDialogClose();

                builderPage.ClickPrintReport();
                Thread.Sleep(15000);

                //filename = "BEAT-EligibilityAssessment-Report-" + assessmentId + " (1).pdf";

                //builderPage.WaitForBEATReportToDownload(filename);
            }
        }

        //HWIT-4482
        [TestMethod]
        public void ConditionDeedOfIndemnityInResepectOfFormerBusinessRequiredForEligibilityMetDoNotDisplay()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login(MemberInfo.Username, MemberInfo.Password);

            GoToSearchBeat();
            
            var licenceNumber = "94116C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewAssessments();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                builderPage.ClickEditLinkAssessment();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                builderPage.ClickEligibilityDetails();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                builderPage.ClickCopyAllLimitsLink();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                builderPage.ClickButtonSaveEligibilityReview();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);

                builderPage.ClickBeginAssessment();
                builderPage.WaitTillBusyDialogClose();

                Assert.IsTrue(builderPage.IsTrackRecordEnable());

                builderPage.ClickButtonFinancialInputsMenu();
                builderPage.SetValueSalesRow("5000000");
                Thread.Sleep(1000);
                builderPage.SetValueOpeningStock("250000");
                Thread.Sleep(1000);

                builderPage.ClickSaleSaveButton();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);

                builderPage.ClickButtonOverallOutcomeMenu();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                builderPage.ClearRecuringConditionForAssessment();
                
                builderPage.CheckAndClickAreThereConditionCheckBox();
                builderPage.WaitTillBusyDialogClose();

                builderPage.ClickAddConditionButton();
                builderPage.SelectConditionDropDown("Deed of Indemnity in Respect of Former Business Required for Eligibility");
                Thread.Sleep(1000);
                builderPage.SelectValueConditionStatus("Not Met");
                Thread.Sleep(1000);
                builderPage.ClickButtonSaveConditionDialog();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);

                builderPage.ClickButtonAddNewDOI();
                builderPage.SetValueDoiTypeId("DOI in respect of former business");
                Thread.Sleep(1000);
                builderPage.ClickAddIndemnifierButton();
                Thread.Sleep(1000);
                builderPage.SetValueNameInputOverall("Lodestone Solutions");
                Thread.Sleep(1000);
                builderPage.SetValueABNOverall("12345678912");
                Thread.Sleep(1000);
                builderPage.SetValueAddress("17 Alberta Street");
                Thread.Sleep(1000);
                builderPage.SetValuePostCode("2000");
                Thread.Sleep(1000);
                builderPage.ClickOkAddIndemnifier();
                Thread.Sleep(1000);
                builderPage.ClickOkNewDeed();
                builderPage.WaitTillSaveDeedOfIndemnityDialogClose();
                Thread.Sleep(1000);

                builderPage.SetValueForHBCFOpenJobLimit("9000000", "25");
                Thread.Sleep(1000);

                builderPage.ClickSaveOutcomeDetailsButton();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);

                builderPage.ClickPrintReport();
                Thread.Sleep(15000);

                //var url = driver.Url;
                //var assessmentId = url.Split(new string[] { "assessmentId=" }, StringSplitOptions.None)[1];
                //var filename = "BEAT-EligibilityAssessment-Report-" + assessmentId + ".pdf";

                //builderPage.WaitForBEATReportToDownload(filename);
                //builderPage.ClickEditRecurringCondition();
                builderPage.ClickEditOrDeleteCondition(Common.LblEdit);
                Thread.Sleep(1000);
                builderPage.SelectValueConditionStatus("Met");
                Thread.Sleep(1000);
                builderPage.ClickButtonSaveConditionDialog();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                builderPage.ClickSaveOutcomeDetailsButton();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                builderPage.ClickPrintReport();
                Thread.Sleep(15000);

                //filename = "BEAT-EligibilityAssessment-Report-" + assessmentId + " (1).pdf";

                //builderPage.WaitForBEATReportToDownload(filename);
            }
        }

        //HWIT-4483
        [TestMethod]
        public void GroupTradingAgreementRequiredForEligibilityIsAlreadyMetDoNotDisplay()
        {
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            GoToSearchBeat();


            var licenceNumber = "94116C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewAssessments();
                builderPage.ClickEditLinkAssessment();

                builderPage.ClickEligibilityDetails();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(3000);

                builderPage.ClickCopyAllLimitsLink();
                builderPage.ClickButtonSaveEligibilityReview();
                builderPage.WaitTillBusyDialogClose();

                builderPage.ClickBeginAssessment();
                builderPage.WaitTillBusyDialogClose();

                Assert.IsTrue(builderPage.IsTrackRecordEnable());

                builderPage.ClickButtonFinancialInputsMenu();
                builderPage.SetValueSalesRow("5000000");
                builderPage.SetValueOpeningStock("250000");
                Thread.Sleep(2000);

                builderPage.ClickSaleSaveButton();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(2000);

                builderPage.ClickButtonOverallOutcomeMenu();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(3000);
                if (builderPage.IsDelegationApprovalCheckboxChecked())
                {
                    builderPage.ClickDelegationApprovalCheckbox();
                    builderPage.WaitTillBusyDialogClose();
                }
                builderPage.ClearRecuringConditionForAssessment();
                Thread.Sleep(2000);

                builderPage.CheckAndClickAreThereConditionCheckBox();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(2000);

                builderPage.ClickAddConditionButton();
                builderPage.SelectConditionDropDown("Group Trading Agreement Required for Eligibility");
                builderPage.SelectValueConditionStatus("Not Met");
                Thread.Sleep(1000);
                builderPage.ClickButtonSaveConditionDialog();
                builderPage.WaitTillBusyDialogClose();

                builderPage.ClickButtonAddNewDOI();
                builderPage.SetValueDoiTypeId("Group Trading Agreement");
                builderPage.ClickAddIndemnifierButton();
                builderPage.SetValueNameInputOverall("Lodestone Solutions");
                builderPage.SetValueABNOverall("12345678912");
                builderPage.SetValueAddress("17 Alberta Street");
                builderPage.SetValuePostCode("2000");
                builderPage.ClickOkAddIndemnifier();
                builderPage.ClickOkNewDeed();
                builderPage.WaitTillSaveDeedOfIndemnityDialogClose();

                builderPage.SetValueForHBCFOpenJobLimit("9000000", "25");

                builderPage.ClickSaveOutcomeDetailsButton();
                builderPage.WaitTillBusyDialogClose();

                builderPage.ClickPrintReport();
                Thread.Sleep(15000);

                //var url = driver.Url;
                //var assessmentId = url.Split(new string[] { "assessmentId=" }, StringSplitOptions.None)[1];
                //var filename = "BEAT-EligibilityAssessment-Report-" + assessmentId + ".pdf";

                //builderPage.WaitForBEATReportToDownload(filename);
                //builderPage.ClickEditRecurringCondition();
                builderPage.ClickEditOrDeleteCondition(Common.LblEdit);
                builderPage.SelectValueConditionStatus("Met");
                builderPage.ClickButtonSaveConditionDialog();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(3000);

                builderPage.ClickSaveOutcomeDetailsButton();
                builderPage.WaitTillBusyDialogClose();

                builderPage.ClickPrintReport();
                Thread.Sleep(15000);

                //filename = "BEAT-EligibilityAssessment-Report-" + assessmentId + " (1).pdf";

                //builderPage.WaitForBEATReportToDownload(filename);
            }
        }

        //HWIT-4488
        [TestMethod]
        public void TestRedistributeGroupLimitsForGTABuilders()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login(MemberInfo.Username, MemberInfo.Password);

            GoToSearchBeat();
            
            var licenceNumber = "131951";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewBuilder();
                var url = driver.Url;
                builderPage.ClickRedistributeGroupLimitsButton();
                Thread.Sleep(2000);
                builderPage.SetJobAndtotalValueRow("11", "600000", 0);
                Thread.Sleep(2000);
                builderPage.SetJobAndtotalValueRow("2", "500000", 1);
                builderPage.ClickOkButtonOkRedis();
                builderPage.WaitTillSavingJobLimitsDialogClose();
                Thread.Sleep(2000);
                Assert.IsTrue(builderPage.ConfirmNewRowInEligibilities("11", "600000"));
                builderPage.ClickKeyEventsLogButtonMenu();
                Thread.Sleep(2000);
                builderPage.SetLicenseNumberSearchEventLogs(licenceNumber);
                Thread.Sleep(2000);
                builderPage.ClickButtonSearchKeyEventLogs();
                Thread.Sleep(2000);
                Assert.IsTrue(builderPage.CheckKeyEventLogForBuilder("GTA Job Limits Redistributed", DateTime.Now.AddHours(3)));
                Assert.IsTrue(builderPage.CheckKeyEventLogForBuilder("COE had been generated", DateTime.Now.AddHours(3)));
                Assert.IsTrue(builderPage.CheckKeyEventLogForBuilder("New eligibility created", DateTime.Now.AddHours(3)));
                Assert.IsTrue(builderPage.CheckKeyEventLogForBuilder("Eligibility has been superseded", DateTime.Now.AddHours(3)));
                driver.Navigate().GoToUrl(url);
                builderPage.ClickRedistributeGroupLimitsButton();
                Thread.Sleep(2000);
                builderPage.SetJobAndtotalValueRow("10", "500000", 0);
                Thread.Sleep(2000);
                builderPage.SetJobAndtotalValueRow("3", "600000", 1);
                builderPage.WaitTillSavingJobLimitsDialogClose();
            }
        }

        //HWIT-4507
        [TestMethod]
        public void VerifyANewEligibilityIsCreatedForBuilderWhenTransferFromDistributorToAnother()
        {
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            GoToSearchBeat();
            
            var builderName = "Champion Homes";
            builderPage.SetBuilderEntityName(builderName);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewBuilder();

                if (!builderPage.VerifyAssessmentsTableHasNoPendingAssessmentBuilderDetail())
                {
                    //Builder Detail
                    builderPage.ClickEditLinkAssessmentBuilderDetail();

                    //Initiate Review
                    builderPage.ClickEligibilityDetails();

                    //Financial Input
                    builderPage.ClickCopyAllLimitsLink();
                    builderPage.ClickButtonSaveEligibilityReview();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickBeginAssessment();
                    builderPage.WaitTillBusyDialogClose();
                    Assert.IsTrue(builderPage.CheckTrackRecordMenuEnable());

                    builderPage.ClickButtonFinancialInputsMenu();
                    Thread.Sleep(2000);
                    builderPage.SetValueSalesRow("5000000");
                    Thread.Sleep(1000);
                    builderPage.SetValueOpeningStock("250000");
                    Thread.Sleep(1000);
                    builderPage.ClickSaleSaveButton();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(1000);
                    builderPage.ClickButtonOverallOutcomeMenu();
                    Thread.Sleep(1000);

                    //overall outcome
                    //clear conditions
                    builderPage.ClearRecuringConditionForAssessment();
                    Thread.Sleep(1000);
                    builderPage.SetValueForHBCFOpenJobLimit("7000000", "25");
                    Thread.Sleep(1000);
                    builderPage.ClickSaveOutcomeDetailsButton();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(1000);
                    builderPage.ClickDelegationApprovalCheckbox();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(1000);
                    builderPage.SetValueDateTermsOffered(DateTime.Now.AddHours(3).Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
                    Thread.Sleep(1000);
                    builderPage.SetValueAssessmentStatus("Terms Accepted");
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(1000);
                    builderPage.ClickFinaliseAssessmentButton();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(1000);
                    builderPage.ClickBuilderDetailMenuButton();
                    Thread.Sleep(1000);

                    //builder details
                    var status = builderPage.GetStatusFirstRowEligibilitiesTable();
                    var id = builderPage.GetIdFirstRoweligibilitiesTable();
                    var hasCOE = builderPage.VerifyFirstRowEligibilityTableHasCOE();
                    builderPage.SetValueDistributorSelect(new Random().Next(1, 10));
                    Thread.Sleep(1000);
                    builderPage.ClickSaveBuilderDetailButton();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(1000);

                    Assert.IsTrue(builderPage.GetStatusFirstRowEligibilitiesTable().Contains("Active"));
                    Assert.IsTrue(!builderPage.GetIdFirstRoweligibilitiesTable().Contains(id));
                    Assert.IsTrue(builderPage.VerifyFirstRowEligibilityTableHasCOE());
                }
                else if (builderPage.VerifyAssessmentTableHasScheduledNotScheduledNoFinalised())
                {
                    var status = builderPage.GetStatusFirstRowEligibilitiesTable();
                    var id = builderPage.GetIdFirstRoweligibilitiesTable();
                    var hasCOE = builderPage.VerifyFirstRowEligibilityTableHasCOE();

                    builderPage.SetValueDistributorSelect(new Random().Next(1, 10));
                    Thread.Sleep(1000);
                    builderPage.ClickConfirmDistributorChangeDialog();
                    Thread.Sleep(1000);
                    builderPage.ClickSaveBuilderDetailButton();
                    builderPage.WaitTillBusyDialogClose();

                    Assert.IsTrue(builderPage.GetStatusFirstRowEligibilitiesTable().Contains("Active"));
                    Assert.IsTrue(builderPage.GetIdFirstRoweligibilitiesTable().Equals(id));
                    Assert.IsTrue(builderPage.VerifyFirstRowEligibilityTableHasCOE());
                }
            }
        }

        //HWIT-4514
        [TestMethod]
        public void AssessmentIsSignedBackToTheInsuranceAgentWhenDUACheckBoxIsCreated()
        {
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            GoToSearchBeat();
            
            var licenceNumber = "94116C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewAssessments();
                builderPage.ClickEditLinkAssessment();

                FinaliseAssessment();

                builderPage.ClickSubmitToBrokerButton();
                builderPage.VerifyColorDistributorLabel();

                builderPage.ClickEligibilityDetails();

                builderPage.ClickCopyAllLimitsLink();
                builderPage.ClickButtonSaveEligibilityReview();
                builderPage.WaitTillBusyDialogClose();

                builderPage.ClickBeginAssessment();
                builderPage.WaitTillBusyDialogClose();

                Assert.IsTrue(builderPage.CheckTrackRecordMenuEnable());

                builderPage.ClickInitiateMenuButton();
                Assert.IsTrue(builderPage.VerifyColorInsuranceAgentLabel());
                builderPage.ClickSubmitToBrokerButton();
                Assert.IsTrue(builderPage.VerifyColorDistributorLabel());

                builderPage.ClickButtonFinancialInputsMenu();
                builderPage.SetValueSalesRow("5000000");
                builderPage.SetValueOpeningStock("250000");
                builderPage.ClickSaleSaveButton();
                builderPage.WaitTillBusyDialogClose();

                builderPage.ClickButtonOverallOutcomeMenu();
                builderPage.ClearRecuringConditionForAssessment();
                builderPage.CheckAndClickAreThereConditionCheckBox();
                builderPage.WaitTillBusyDialogClose();
                var keyIssues = "This is test builder communication";
                builderPage.SetValueKeyIssuesOrOtherConditions(keyIssues);
                builderPage.ClickSaveBuilderCommunicationButton();
                builderPage.WaitTillBusyDialogClose();
                var note = "this is a test note";
                builderPage.SetValueNote(note);
                builderPage.ClickSaveNotButtonOverallOutcome();
                builderPage.WaitTillBusyDialogClose();
                builderPage.ClickInitiateMenuButton();

                Assert.IsTrue(builderPage.VerifyColorDistributorLabel());
                builderPage.ClickButtonOverallOutcomeMenu();

                builderPage.SetValueForHBCFOpenJobLimit("9000000", "25");
                builderPage.ClickSaveOutcomeDetailsButton();
                builderPage.WaitTillBusyDialogClose();
                builderPage.ClickInitiateMenuButton();

                Assert.IsTrue(builderPage.VerifyColorDistributorLabel());
                builderPage.ClickButtonOverallOutcomeMenu();

                builderPage.ClickDelegationApprovalCheckbox();
                builderPage.WaitTillBusyDialogClose();
                builderPage.ClickInitiateMenuButton();

                Assert.IsTrue(builderPage.VerifyColorInsuranceAgentLabel());
            }
        }

        //HWIT-4515
        [TestMethod]
        public void TestTheAssessmentIsAssignedBackToTheDistributorWhenTheOfferTermIsClick()
        {
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            GoToSearchBeat();


            var licenceNumber = "94116C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewAssessments();
                builderPage.ClickEditLinkAssessment();

                FinaliseAssessment();

                builderPage.ClickButtonSubmitToInsurerInitiateReview();
                builderPage.VerifyColorInsuranceAgentLabel();

                builderPage.ClickEligibilityDetails();
                builderPage.WaitTillBusyDialogClose();

                builderPage.ClickCopyAllLimitsLink();
                builderPage.ClickButtonSaveEligibilityReview();
                builderPage.WaitTillBusyDialogClose();

                builderPage.ClickBeginAssessment();
                builderPage.WaitTillBusyDialogClose();

                Assert.IsTrue(builderPage.CheckTrackRecordMenuEnable());

                builderPage.ClickButtonFinancialInputsMenu();
                builderPage.SetValueSalesRow("5000000");
                builderPage.SetValueOpeningStock("250000");
                builderPage.ClickSaleSaveButton();
                builderPage.WaitTillBusyDialogClose();

                builderPage.ClickButtonOverallOutcomeMenu();
                builderPage.SetValueAssessmentStatus("Pending");
                builderPage.WaitTillBusyDialogClose();
                builderPage.ClearRecuringConditionForAssessment();
                builderPage.CheckAndClickAreThereConditionCheckBox();
                builderPage.WaitTillBusyDialogClose();
                var keyIssues = "This is test builder communication";
                builderPage.SetValueKeyIssuesOrOtherConditions(keyIssues);
                builderPage.ClickSaveBuilderCommunicationButton();
                builderPage.WaitTillBusyDialogClose();
                var note = "this is a test note";
                builderPage.SetValueNote(note);
                builderPage.ClickSaveNotButtonOverallOutcome();
                builderPage.WaitTillBusyDialogClose();
                builderPage.ClickInitiateMenuButton();

                Assert.IsTrue(builderPage.VerifyColorInsuranceAgentLabel());
                builderPage.ClickButtonOverallOutcomeMenu();
                builderPage.WaitTillBusyDialogClose();
                builderPage.UnClickConditionCheckbox();
                builderPage.WaitTillBusyDialogClose();
                if (builderPage.IsDelegationApprovalCheckboxChecked())
                {
                    builderPage.ClickDelegationApprovalCheckbox();
                    builderPage.WaitTillBusyDialogClose();
                }
                builderPage.SetValueForHBCFOpenJobLimit("9000000", "25");
                builderPage.ClickSaveOutcomeDetailsButton();
                builderPage.WaitTillBusyDialogClose();
                builderPage.ClickInitiateMenuButton();
                builderPage.WaitTillBusyDialogClose();

                Assert.IsTrue(builderPage.VerifyColorInsuranceAgentLabel());
                builderPage.ClickButtonOverallOutcomeMenu();
                builderPage.WaitTillBusyDialogClose();

                builderPage.ClickDelegationApprovalCheckbox();
                builderPage.WaitTillBusyDialogClose();
                builderPage.ClickInitiateMenuButton();
                builderPage.WaitTillBusyDialogClose();

                Assert.IsTrue(builderPage.VerifyColorInsuranceAgentLabel());

                builderPage.ClickButtonOverallOutcomeMenu();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(300);
                ClickOfferTermsButtonAndSendMail();
                builderPage.WaitTillBusyDialogClose();
                //builderPage.ClickButtonOfferTerms();
                //builderPage.WaitTillRenderingTemplateDialogClose();
                //builderPage.ClickSendOfferTermsButton();
                //builderPage.WaitTillBusyDialogClose();
                //Thread.Sleep(10000);
                //builderPage.ClickOkOfferTermsEmailDialog();
                builderPage.ClickInitiateMenuButton();
                builderPage.WaitTillBusyDialogClose();
                Assert.IsTrue(builderPage.VerifyColorDistributorLabel());
            }
        }

        //HWIT-4519
        [TestMethod]
        public void ManageGroupSearch()
        {
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            GoToSearchBeat();


            builderPage.ClickButtonManageGroup();

            builderPage.SetValueEntityNameManageGroup("Australia");
            builderPage.ClickSearchButtonManageGroup();
            builderPage.WaitTillLoadingSquareClose();
            if (builderPage.VerifyErrorDialogShowManageGroup())
            {
                Assert.Fail();
            }
        }

        //HWIT-4533
        [TestMethod]
        public void VerifyNewAssessmentIsNotScheduledIfLastAssessmentIsFinalisedAsNotProceeding()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login(MemberInfo.Username, MemberInfo.Password);

            GoToSearchBeat();
            
            var licenceNumber = "92732C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewBuilder();
                var isTrue = !builderPage.GetStatusFirstRowEligibilitiesTable().Equals("Active");
                Assert.IsTrue(isTrue);
                builderPage.ClickEditLinkAssessmentBuilderDetail();
                Thread.Sleep(3000);
                SaveInitiateReview(string.Empty, AssessmentTypeDLL.New, DateTime.Now.ToString());
                Thread.Sleep(3000);
                builderPage.ClickEligibilityDetails();
                Thread.Sleep(7000);
                builderPage.ClickCopyAllLimitsLink();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                builderPage.ClickButtonSaveEligibilityReview();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                builderPage.ClickBeginAssessment();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                builderPage.ClickButtonFinancialInputsMenu();
                Thread.Sleep(3000);
                builderPage.SetValueSalesRow("5000000");
                Thread.Sleep(1000);
                builderPage.SetValueOpeningStock("250000");
                Thread.Sleep(1000);
                builderPage.ClickSaleSaveButton();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                builderPage.ClickButtonOverallOutcomeMenu();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(3000);
                builderPage.ClearRecuringConditionForAssessment();
                Thread.Sleep(2000);
                builderPage.SetValueForHBCFOpenJobLimit("7000000", "25");
                Thread.Sleep(1000);
                builderPage.ClickSaveOutcomeDetailsButton();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(2000);
                OverallOutcomeService.ClickDelegationApprovalCheckbox();
                //builderPage.ClickDelegationApprovalCheckbox();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(2000);
                builderPage.SetValueAssessmentStatus("Not Proceeding");
                Thread.Sleep(1000);
                builderPage.SetTextNotProceedingComment("Not Proceeding");
                Thread.Sleep(1000);
                builderPage.SetValueDateTermsOffered(DateTime.Now.AddHours(3).ToString("dd/MM/yyyyy"));
                Thread.Sleep(1000);
                builderPage.ClickFinaliseAssessmentButton();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(3000);
                builderPage.ClickBuilderDetailMenuButton();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(3000);
                Util.RefreshPage();
                Thread.Sleep(3000);
                isTrue = builderPage.GetStatusFirstRowAssessmentTable().Contains("NotScheduled");
                Assert.IsTrue(isTrue);
            }
        }

        //HWIT-4538
        [TestMethod]
        public void VerifyAConfirmationMessagePopUpWhenTransferringTheExistingBuilderInBEAT()
        {
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            GoToSearchBeat();


            var licenceNumber = "94116C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewBuilder();
                if (!builderPage.VerifyAssessmentsTableHasNoPendingAssessmentBuilderDetail())
                {
                    builderPage.ClickEditLinkAssessmentBuilderDetail();
                    builderPage.ClickEligibilityDetails();
                    builderPage.ClickCopyAllLimitsLink();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickButtonSaveEligibilityReview();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickBeginAssessment();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickButtonFinancialInputsMenu();
                    Thread.Sleep(3000);
                    builderPage.SetValueSalesRow("5000000");
                    builderPage.SetValueOpeningStock("250000");
                    builderPage.ClickSaleSaveButton();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickButtonOverallOutcomeMenu();
                    Thread.Sleep(3000);
                    builderPage.SetValueAssessmentStatus("Pending");
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClearRecuringConditionForAssessment();
                    if (builderPage.IsCheckedAreThereAnyConditionCheckbox())
                    {
                        builderPage.ClickAreThereConditionCheckbox();
                        builderPage.WaitTillBusyDialogClose();
                    }
                    if (builderPage.IsDelegationApprovalCheckboxChecked())
                    {
                        builderPage.ClickDelegationApprovalCheckbox();
                        builderPage.WaitTillBusyDialogClose();
                    }
                    Thread.Sleep(3000);
                    builderPage.SetValueForHBCFOpenJobLimit("7000000", "25");
                    builderPage.ClickSaveOutcomeDetailsButton();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickDelegationApprovalCheckbox();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(3000);
                    builderPage.SetValueDateTermsOffered(DateTime.Now.AddHours(3).ToString("dd/MM/yyyy"));
                    builderPage.SetValueAssessmentStatus("Terms Accepted");
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickFinaliseAssessmentButton();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickBuilderDetailMenuButton();
                    Thread.Sleep(3000);
                    builderPage.SetValueDistributorSelect(new Random().Next(20));
                    Assert.IsTrue(builderPage.IsConfirmDistributorChangeDialogOpen());
                    builderPage.ClickConfirmDistributorChangeDialog();
                    builderPage.ClickSaveBuilderDetailButton();
                    builderPage.ClickKeyEventsLogButtonMenu();
                    //TO DO currently the key event log service is unable, comeback when it's enable 

                }
                else if (builderPage.VerifyAssessmentTableHasScheduledNotScheduledNoFinalised())
                {
                    builderPage.SetValueDistributorSelect(new Random().Next(20));
                    Assert.IsTrue(builderPage.IsConfirmDistributorChangeDialogOpen());
                    builderPage.ClickConfirmDistributorChangeDialog();
                    builderPage.ClickSaveBuilderDetailButton();
                    builderPage.ClickKeyEventsLogButtonMenu();
                    //TO DO currently the key event log service is unable, comeback when it's enable 
                }
            }
        }

        //HWIT-4539
        [TestMethod]
        public void VerifyAnErrorMessagePopUpWhenTransferringTheBuilderWithPendingAssessment()
        {
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            GoToSearchBeat();


            var licenceNumber = "94116C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewBuilder();
                if (!builderPage.VerifyAssessmentsTableHasNoPendingAssessmentBuilderDetail())
                {
                    builderPage.SetValueDistributorSelect(new Random().Next(20));
                    Assert.IsTrue(builderPage.IsConfirmDistributorChangeDialogOpen());
                    builderPage.ClickConfirmDistributorChangeDialog();
                    builderPage.ClickSaveBuilderDetailButton();
                    builderPage.VerifyDistributorCantBeUpdated();
                }
                else
                {
                    builderPage.ClickEditLinkAssessmentBuilderDetail();
                    builderPage.ClickEligibilityDetails();
                    builderPage.ClickCopyAllLimitsLink();
                    builderPage.ClickButtonSaveEligibilityReview();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickBeginAssessment();
                    builderPage.WaitTillBusyDialogClose();
                    builderPage.ClickBuilderDetailMenuButton();
                    builderPage.SetValueDistributorSelect(new Random().Next(20));
                    Assert.IsTrue(builderPage.IsConfirmDistributorChangeDialogOpen());
                    builderPage.ClickConfirmDistributorChangeDialog();
                    builderPage.ClickSaveBuilderDetailButton();
                    builderPage.VerifyDistributorCantBeUpdated();
                }
            }
        }

        //HWIT-4540
        [TestMethod]
        public void VerifyAConfirmationMessageDoesntPopupWhenTransferringTheNewBuildersBeingCretedInBEAT()
        {
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            GoToSearchBeat();


            builderPage.ClickCreateNewBuilderButtonMenu();
            builderPage.SetValueInputLicenseNewBuilder("92732C");
            builderPage.ClickSearchButtonLicenseDialogNewBuilder();
            builderPage.WaitTillLookUpLicenseDialogClose();
            Assert.IsTrue(builderPage.GetValueDistributorBuilderDetails().Equals(string.Empty));
            builderPage.SetValueDistributorSelect(new Random().Next(20));
            Assert.IsFalse(builderPage.IsConfirmDistributorChangeDialogOpen());
        }

        //HWIT-4471
        [TestMethod]
        public void VerifyReportInactiveEligibilityUtilisedJobs()
        {
            var currentUser = "nguyenv";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "Abc123456@");

            GoToSearchBeat();
            
            builderPage.ClickReportMenu();
            builderPage.ClickReport("Inactive Eligibility Utilised Jobs");
            Thread.Sleep(5000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            var utilisedJobNumberAndLicence = builderPage.GetUtilisedJobNumberAndBuilderLicenceFirstRowHasUtilisedJobValueGreaterThan50000();
            var utilsedJobNumber = utilisedJobNumberAndLicence[0];
            var licence = utilisedJobNumberAndLicence[1];
            var value = utilisedJobNumberAndLicence[2];
            GoToSearchBeat();
            builderPage.SetBuilderLicenceNumber(licence);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewBuilder();
                var isTrue = builderPage.GetValueApprovedJobNumberBuilderUtilisation().Equals("0");
                Assert.IsTrue(isTrue);
                isTrue = builderPage.GetValueApprovedJobValueBuilderUtilisation().Equals("0");
                Assert.IsTrue(isTrue);
                isTrue = builderPage.GetValueUsedJobValueBuilderUtilisation().Equals(value);
                Assert.IsTrue(isTrue);
                isTrue = builderPage.GetValueOpenJobValueBuilderUtilisation().Equals("-" + value);
                Assert.IsTrue(isTrue);
                isTrue = builderPage.GetValueUsedJobNumberBuilderUtilisation().Equals(utilsedJobNumber);
                Assert.IsTrue(isTrue);
                isTrue = builderPage.GetValueOpenJobNumberBuilderUtilisation().Equals("-" + utilsedJobNumber);
                Assert.IsTrue(isTrue);
                isTrue = builderPage.GetStatusFirstRowEligibilitiesTable().Equals("Not Active");
                Assert.IsTrue(isTrue);
            }
        }

        //HWIT-4551
        [TestMethod]
        public void VerifyTheAnalystEscalatedToFieldIsCorrectlyPopulated()
        {
            var currentUser = MemberInfo.Username3;
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, MemberInfo.Password);

            GoToSearchBeat();

            var licenceNumber = "262307C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewAssessments();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                builderPage.ClickEditLinkAssessment();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                builderPage.ClickEligibilityDetails();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                builderPage.ClickCopyAllLimitsLink();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                builderPage.ClickButtonSaveEligibilityReview();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                builderPage.ClickBeginAssessment();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                var isTrue = builderPage.CheckTrackRecordMenuEnable();
                Thread.Sleep(1000);
                Assert.IsTrue(isTrue);
                builderPage.ClickButtonFinancialInputsMenu();
                Thread.Sleep(1000);
                builderPage.SetValueSalesRow("5000000");
                Thread.Sleep(1000);
                builderPage.SetValueOpeningStock("250000");
                Thread.Sleep(1000);
                builderPage.ClickSaleSaveButton();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                builderPage.ClickButtonOverallOutcomeMenu();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                if (builderPage.IsDelegationApprovalCheckboxChecked())
                {
                    builderPage.ClickDelegationApprovalCheckbox();
                    builderPage.WaitTillBusyDialogClose();
                }
                Thread.Sleep(1000);
                builderPage.ClearRecuringConditionForAssessment();
                Thread.Sleep(1000);
                OverallOutcomeService.ClickAreThereConditionCheckbox();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(3000);
                OverallOutcomeService.ClickAddConditionButton();
                Thread.Sleep(1000);
                builderPage.SelectConditionDropDown(SelectConditionDialog.BCRPToApply750k);
                Thread.Sleep(1000);
                builderPage.ClickButtonSaveConditionDialog();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(3000);
                OverallOutcomeService.ClickAddConditionButton();
                builderPage.SelectConditionDropDown(SelectConditionDialog.DOIRequiredForEligibility);
                Thread.Sleep(1000);
                builderPage.SelectValueConditionStatus(SelectStatusConditionDialog.Met);
                Thread.Sleep(1000);
                builderPage.ClickButtonSaveConditionDialog();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(3000);
                OverallOutcomeService.ClickAddConditionButton();
                builderPage.SelectConditionDropDown(SelectConditionDialog.IntensiveMonitoring);
                Thread.Sleep(1000);
                builderPage.ClickButtonSaveConditionDialog();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(3000);
                OverallOutcomeService.ClickAddConditionButton();
                Thread.Sleep(1000);
                builderPage.SelectConditionDropDown(SelectConditionDialog.WorkingCapitalMitigation);
                Thread.Sleep(1000);
                builderPage.SelectValueConditionStatus(SelectStatusConditionDialog.Met);
                Thread.Sleep(1000);
                builderPage.SetValueInputCondition("67000");
                Thread.Sleep(1000);
                builderPage.ClickButtonSaveConditionDialog();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                builderPage.SetValueKeyIssuesOrOtherConditions("This is a test builder");
                Thread.Sleep(1000);
                builderPage.ClickSaveBuilderCommunicationButton();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                builderPage.SetValueForHBCFOpenJobLimit("15000000", "35");
                Thread.Sleep(1000);
                builderPage.ClickSaveOutcomeDetailsButton();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                builderPage.SetValueReferToUser("CSCTestC HW_ROL_UND_C");
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                GoToLoginPage();
                loginPage.Login(MemberInfo.Username, MemberInfo.Password);
                GoToSearchBeat();
                builderPage.ClickHomeMenuButton();
                Thread.Sleep(3000);
                HomeService.ClickTaskWithLicence(licenceNumber);
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(3000);
                builderPage.ClickButtonOverallOutcomeMenu();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                builderPage.ClickDelegationApprovalCheckbox();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                isTrue = OverallOutcomeService.GetNameOfAnalyst().Contains(MemberInfo.Username3);
                Thread.Sleep(1000);
                Assert.IsTrue(isTrue);
                isTrue = OverallOutcomeService.GetNameOfAnalystEscalatedTo().Contains(MemberInfo.Username);
                Thread.Sleep(1000);
                Assert.IsTrue(isTrue);
                GoToLoginPage();
                loginPage.Login(currentUser, MemberInfo.Password);
                GoToSearchBeat();
                builderPage.ClickHomeMenuButton();
                Thread.Sleep(3000);
                // 17. Now the initial user - CSCTestE logs back in and checks his HOME screen. If the assessment is not displayed here, the user goes to task administration screen --> Being Assessed filter and select the assessment and assign it to themselves. 
                if (HomeService.IsHasData())
                {
                    HomeService.ClickTaskWithLicence(licenceNumber);
                    builderPage.WaitTillBusyDialogClose();
                }
                else
                {
                    builderPage.ClickTaskAdministratorMenu();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(3000);

                    // Click menu filter Being Assessd
                    TaskAdministrationService.ClickMenuFilter(CollapseSidebarAssessments.BeingAssessed);

                    // Navigate to Initial Review screen
                    TaskAdministrationService.ClickEligibilityAssessmentIdFirst();
                }
                Thread.Sleep(3000);
                builderPage.ClickButtonOverallOutcomeMenu();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                if (!OverallOutcomeService.IsEnabledDateTermsOffered())
                {
                    OverallOutcomeService.ClickDelegationApprovalCheckbox();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(1000);
                    // Check show dialog
                    OverallOutcomeService.CheckValidationErrorDialogOpen(true);
                }
                OverallOutcomeService.SetValueDateTermsOffered(DateTime.Now.AddHours(3).ToString(Common.FormatDate2));
                Thread.Sleep(1000);
                OverallOutcomeService.SetValueEligibilityAssessmentStatusDll(EligibilityAssessmentStatus.TermsAccepted);
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                builderPage.ClickSaveOutcomeDetailsButton();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                OverallOutcomeService.UpdateToMetIfIsNotMet();
                OverallOutcomeService.ClickFinaliseAssessmentButton();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                isTrue =!string.IsNullOrEmpty(OverallOutcomeService.GetNameOfAnalyst());
                Assert.IsTrue(isTrue);
                isTrue = !string.IsNullOrEmpty(OverallOutcomeService.GetNameOfAnalystEscalatedTo());
                Assert.IsTrue(isTrue);
            }
        }

        //HWIT-4525
        [TestMethod]
        public void ManageGroupCreateGroup()
        {
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            GoToSearchBeat();


            builderPage.ClickButtonManageGroup();
            builderPage.ClickCreateNewGroup();
            builderPage.SetTextGroupNameInput("aus");//type in to show all the names that are taken
            Thread.Sleep(2000); // wait for info to show up
            Assert.IsTrue(builderPage.VerifyAutoCompleteDivShowUp());
        }

        //HWIT-4562
        [TestMethod]
        public void OJNCantExeedOJVDevidedBy20K()
        {
            var currentUser = "nguyenv";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "Abc123456@");

            GoToSearchBeat();

            var licenceNumber = "94116C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewAssessments();
                builderPage.ClickEditLinkAssessment();
                builderPage.ClickEligibilityDetails();
                builderPage.ClickCopyAllLimitsLink();
                builderPage.ClickButtonSaveEligibilityReview();
                builderPage.WaitTillBusyDialogClose();
                builderPage.ClickButtonSaveEligibilityReview();
                builderPage.WaitTillBusyDialogClose();
                builderPage.ClickButtonFinancialInputsMenu();
                builderPage.SetValueSalesRow("5000000");
                builderPage.SetValueOpeningStock("250000");
                builderPage.ClickSaleSaveButton();
                builderPage.WaitTillBusyDialogClose();
                builderPage.ClickButtonOverallOutcomeMenu();
                builderPage.SetValueAssessmentStatus("Pending");
                builderPage.WaitTillBusyDialogClose();
                if (builderPage.IsDelegationApprovalCheckboxChecked())
                {
                    builderPage.ClickDelegationApprovalCheckbox();
                    builderPage.WaitTillBusyDialogClose();
                }
                builderPage.SetValueForHBCFOpenJobLimit("199999", "10");
                builderPage.ClickSaveOutcomeDetailsButton();
                builderPage.WaitTillBusyDialogClose();
                Assert.IsTrue(builderPage.VerifyValidationDialogOpen());
                builderPage.ClickCloseButtonValidationDialog();
                builderPage.SetValueForHBCFOpenJobLimit("200000", "10");
                builderPage.ClickSaveOutcomeDetailsButton();
                builderPage.WaitTillBusyDialogClose();
                Assert.IsFalse(builderPage.VerifyValidationDialogOpen());
            }
        }

        //HWIT-4563
        [TestMethod]
        public void TestTheNewDeedIrregularContractingDeedBehavior()
        {
            var currentUser = "nguyenv";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "Abc123456@");

            GoToSearchBeat();

            var licenceNumber = "94116C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewAssessments();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(2000);
                builderPage.ClickEditLinkAssessment();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(2000);
                builderPage.ClickEligibilityDetails();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(2000);
                builderPage.ClickCopyAllLimitsLink();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(2000);
                builderPage.ClickButtonSaveEligibilityReview();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(2000);
                builderPage.ClickBeginAssessment();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(2000);
                builderPage.ClickButtonFinancialInputsMenu();
                Thread.Sleep(2000);
                builderPage.SetValueSalesRow("5000000");
                Thread.Sleep(1000);
                builderPage.SetValueOpeningStock("250000");
                Thread.Sleep(1000);
                builderPage.ClickSaleSaveButton();
                builderPage.WaitTillBusyDialogClose();
                builderPage.ClickButtonOverallOutcomeMenu();
                Thread.Sleep(3000);
                builderPage.SetValueAssessmentStatus("Pending");
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                if (builderPage.IsDelegationApprovalCheckboxChecked())
                {
                    builderPage.ClickDelegationApprovalCheckbox();
                    builderPage.WaitTillBusyDialogClose();
                }
                builderPage.ClearRecuringConditionForAssessment();
                if (!builderPage.IsConditionCheckboxChecked())
                {
                    builderPage.ClickAreThereConditionCheckbox();
                }
                builderPage.WaitTillBusyDialogClose();
                builderPage.ClickAddConditionButton();
                Thread.Sleep(1000);
                builderPage.SelectConditionDropDown("Deed of Indemnity Required for Eligibility");
                Thread.Sleep(1000);
                builderPage.SelectValueConditionStatus("Not Met");
                Thread.Sleep(1000);
                builderPage.ClickButtonSaveConditionDialog();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
                builderPage.ClickButtonAddNewDOI();
                Thread.Sleep(1000);
                builderPage.SetValueDoiTypeId("Irregular Contracting Deed");
                Thread.Sleep(1000);
                builderPage.SetValueLotStreetNoInputOverallOutcome("1C Homebush Bay");
                Thread.Sleep(1000);
                builderPage.SetValueInputSurburbOverallOutcome("Rhodes");
                Thread.Sleep(1000);
                builderPage.SetValueSiteStreetName("Drive");
                Thread.Sleep(1000);
                builderPage.SetValueEditPostCode("2138");
                Thread.Sleep(1000);
                builderPage.SetValuePolicyNumberOverallOutcome("123456");
                Thread.Sleep(1000);
                builderPage.ClickAddIndemnifierButton();
                Thread.Sleep(1000);
                builderPage.SetValueNameInputOverall("Lodestone Solutions");
                Thread.Sleep(1000);
                builderPage.SetValueABNOverall("12345678912");
                Thread.Sleep(1000);
                builderPage.SetValueAddress("17 Alberta Street");
                Thread.Sleep(1000);
                builderPage.SetValuePostCode("2000");
                Thread.Sleep(1000);
                builderPage.ClickOkAddIndemnifier();
                Thread.Sleep(1000);
                builderPage.ClickOkNewDeed();
                builderPage.WaitTillSaveDeedOfIndemnityDialogClose();
                Thread.Sleep(1000);
                Assert.IsTrue(builderPage.VerifyFirstRowDoiTableOverallOutcome());
                builderPage.ClickEditFirstDoi();
                Thread.Sleep(1000);
                builderPage.SetValueEditPostCode("2094");
                Thread.Sleep(1000);
                builderPage.ClickButtonOkNewDeedOfIndemninty();
                builderPage.WaitTillSaveDeedOfIndemnityDialogClose();
                Thread.Sleep(1000);
                builderPage.ClickOkConfirmABNChange();
                builderPage.WaitTillSaveDeedOfIndemnityDialogClose();
                Thread.Sleep(1000);

                var lastDoiId = builderPage.GetFirstDoiId();
                builderPage.ClickViewFirstDoi();
                Thread.Sleep(5000);
                var defaultDownloadPath = Common.FilePath;
                var files = Directory.GetFiles(defaultDownloadPath, "DOI-" + lastDoiId + "*.*");
                if (files.Length > 0)
                {
                    var fileName = files[0];
                    builderPage.ClickUploadFirstDoi();
                    // ??? builderPage.SelectFileUpload(fileName);
                    builderPage.WaitTillUploadDialogClose();
                    Assert.IsTrue(builderPage.CheckStatusActiveLastDoi());
                    builderPage.ClickDownloadLastDoi();
                    Thread.Sleep(5000);
                    files = Directory.GetFiles(defaultDownloadPath, "DOI-" + lastDoiId + "*.*");
                    Assert.IsTrue(files.Length > 1);
                }

                builderPage.ClickEmailButtonFirstRowDoiOverallOutcome();
                builderPage.WaitTillRenderingEmailTemplateDialogClose();
                builderPage.ClickSendButton();
                //builderPage.WaitTillQueueingEmailDialogClose();
                Thread.Sleep(5000);
                Assert.IsTrue(builderPage.CheckEmailSucessDialogOverallOutcome("The email has been successfully queued"));
            }
        }

        //HWIT-4552
        [TestMethod]
        public void VerifyTheEmailSendForNoticeTheUpcomingReview()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login(MemberInfo.Username2, MemberInfo.Password2);

            GoToSearchBeat();

            var licenceNumber = "262307C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewAssessments();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(2000);
                builderPage.ClickEditLinkAssessment();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(2000);
                builderPage.ClickEligibilityDetails();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(2000);
                builderPage.ClickCopyAllLimitsLink();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(2000);
                builderPage.ClickButtonSaveEligibilityReview();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(2000);
                builderPage.ClickBeginAssessment();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(2000);
                builderPage.ClickButtonFinancialInputsMenu();
                Thread.Sleep(2000);
                builderPage.SetValueSalesRow("5000000");
                Thread.Sleep(2000);
                builderPage.SetValueOpeningStock("250000");
                Thread.Sleep(2000);
                builderPage.ClickSaleSaveButton();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(2000);
                builderPage.ClickButtonOverallOutcomeMenu();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(2000);
                builderPage.ClearRecuringConditionForAssessment();
                Thread.Sleep(2000);
                builderPage.CheckAndClickAreThereConditionCheckBox();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(2000);
                builderPage.ClickAddConditionButton();
                Thread.Sleep(2000);
                builderPage.SelectConditionDropDown("Deed of Indemnity Required for Eligibility");
                Thread.Sleep(2000);
                builderPage.SelectValueConditionStatus("Not Met");
                Thread.Sleep(2000);
                builderPage.ClickButtonSaveConditionDialog();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(2000);
                builderPage.ClickButtonAddNewDOI();
                Thread.Sleep(2000);
                builderPage.SetValueDoiTypeId("Irregular Contracting Deed");
                Thread.Sleep(2000);
                builderPage.SetValueLotStreetNoInputOverallOutcome("1C Homebush Bay");
                Thread.Sleep(2000);
                builderPage.SetValueInputSurburbOverallOutcome("Rhodes");
                Thread.Sleep(2000);
                builderPage.SetValueSiteStreetName("Drive");
                Thread.Sleep(2000);
                builderPage.SetValueEditPostCode("2138");
                Thread.Sleep(2000);
                builderPage.SetValuePolicyNumberOverallOutcome("123456");
                Thread.Sleep(2000);
                builderPage.ClickAddIndemnifierButton();
                Thread.Sleep(2000);
                builderPage.SetValueNameInputOverall("Lodestone Solutions");
                Thread.Sleep(2000);
                builderPage.SetValueABNOverall("12345678912");
                Thread.Sleep(2000);
                builderPage.SetValueAddress("17 Alberta Street");
                Thread.Sleep(2000);
                builderPage.SetValuePostCode("2000");
                Thread.Sleep(2000);
                builderPage.ClickOkAddIndemnifier();
                Thread.Sleep(2000);
                builderPage.ClickOkNewDeed();
                Thread.Sleep(2000);
                builderPage.WaitTillSaveDeedOfIndemnityDialogClose();
                Thread.Sleep(2000);
                var isTrue = builderPage.VerifyFirstRowDoiTableOverallOutcome();
                Assert.IsTrue(isTrue);
                builderPage.ClickEditFirstDoi();
                Thread.Sleep(2000);
                builderPage.SetValueEditPostCode("2094");
                Thread.Sleep(2000);
                builderPage.ClickButtonOkNewDeedOfIndemninty();
                builderPage.WaitTillSaveDeedOfIndemnityDialogClose();
                Thread.Sleep(2000);
                builderPage.ClickOkConfirmABNChange();
                builderPage.WaitTillSaveDeedOfIndemnityDialogClose();

                Thread.Sleep(5000);
                var lastDoiId = builderPage.GetFirstDoiId();
                builderPage.ClickViewFirstDoi();
                Thread.Sleep(5000);
                var defaultDownloadPath = Common.FilePath;
                var files = Directory.GetFiles(defaultDownloadPath, "DOI-" + lastDoiId + "*.*");
                if (files.Length > 0)
                {
                    var fileName = files[0];
                    builderPage.ClickUploadFirstDoi();
                    // ??? builderPage.SelectFileUpload(fileName);
                    builderPage.WaitTillUploadDialogClose();
                    Assert.IsTrue(builderPage.CheckStatusActiveLastDoi());
                    builderPage.ClickDownloadLastDoi();
                    Thread.Sleep(5000);
                    files = Directory.GetFiles(defaultDownloadPath, "DOI-" + lastDoiId + "*.*");
                    Assert.IsTrue(files.Length > 1);
                }

                builderPage.ClickEmailButtonFirstRowDoiOverallOutcome();
                builderPage.WaitTillRenderingEmailTemplateDialogClose();
                Thread.Sleep(3000);
                builderPage.ClickSendButton();
                //builderPage.WaitTillQueueingEmailDialogClose();
                Thread.Sleep(5000);
                isTrue = builderPage.CheckEmailSucessDialogOverallOutcome("The email has been successfully queued");
                Assert.IsTrue(isTrue);
            }
        }

        //HWIT-4587
        [TestMethod]
        public void VerifyTheOldAssessmentOverallOutcomeScreenIsAccessible()
        {
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            AccessOldFinalisedAssessment("255203");
            AccessOldFinalisedAssessment("250252");
            AccessOldFinalisedAssessment("94058");
            AccessOldFinalisedAssessment("107637");
        }

        private void AccessOldFinalisedAssessment(string assessmentId)
        {
            var url = "https://portal-uat.hbcf.nsw.gov.au/portal/server.pt/gateway/PTARGS_0_25335_352_0_0_43/http%3B/portal-app/BEAT/InitiateReview.aspx?assessmentId=";
            driver.Navigate().GoToUrl(url + assessmentId);
            Assert.IsTrue(builderPage.VerifyClosedStatusOnPanel());
            builderPage.ClickEligibilityDetails();
            builderPage.WaitTillBusyDialogClose();
            builderPage.ClickMenuTrackRecord();
            builderPage.WaitTillBusyDialogClose();
            builderPage.ClickButtonFinancialInputsMenu();
            builderPage.WaitTillBusyDialogClose();
            builderPage.ClickButtonOverallOutcomeMenu();
            builderPage.WaitTillBusyDialogClose();
        }

        //HWIT-4595
        [TestMethod]
        public void VerifyTheGenerateBuilderPolicyReportButtonWhenClickOnBuilderSummaryScreenGenderateReportDoesntHaveDuplicate()
        {
            var currentUser = "CSCTestC";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "xBA7SHg$5acY");

            GoToSearchBeat();

            var licenceNumber = "262307C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewBuilder();
                builderPage.ToggleIncludeClosedJobs();
                builderPage.ClickExportExcel();
            }
        }

        //HWIT-4603
        [TestMethod]
        public void VerifyTheActiveBuildersAreDisplayForTheBuilderOnSiraRefresh()
        {
            var currentUser = "nguyenv";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "Abc123456@");

            GoToSearchBeat();

            var licenceNumber = "174699C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewBuilder();

                // Check not exists then add new principal
                if (!builderPage.IsHasDeleteButtonInPricipalTable())
                {
                    AddNewPrincipal("Jimmy Chonga", "1977", "MAROUBRA", "Director", "99999C", "18");
                }

                Assert.IsTrue(builderPage.BuidlerPrincipalDetailsHasActiveRow());
                var activeRowsCount = builderPage.CountActivePrincipal();
                builderPage.ClickSiraBuilderDetailMenuButton();
                Thread.Sleep(5000);
                builderPage.ClickRefreshLicenceDetailsFromSira();
                Thread.Sleep(5000);
                builderPage.WaitTillBusyDialogClose();
                builderPage.ClickRefreshLicenceDetailsFromSira();
                Thread.Sleep(5000);
                builderPage.WaitTillBusyDialogClose();
                builderPage.ClickBuilderDetailMenuButton();
                Thread.Sleep(5000);
                builderPage.RemoveActiveBuilderPrincipal();

                // Check not exists then add new principal
                if (!builderPage.IsHasDeleteButtonInPricipalTable())
                {
                    AddNewPrincipal("Jimmy Chonga", "1977", "MAROUBRA", "Director", "99999C", "18");
                }
                builderPage.ClickSiraBuilderDetailMenuButton();
                builderPage.ClickRefreshLicenceDetailsFromSira();
                Thread.Sleep(5000);
                builderPage.WaitTillBusyDialogClose();
                builderPage.ClickRefreshLicenceDetailsFromSira();
                Thread.Sleep(5000);
                builderPage.WaitTillBusyDialogClose();
                //Assert.IsTrue(builderPage.CountActivePrincipal() >= activeRowsCount);

                // 8.1. Now go back to the Builder summary screen
                builderPage.ClickBuilderDetailMenuButton();
                Thread.Sleep(5000);

                // 8.2. Verify the deleted principal is available and active under "Builder Principal Details" scetion
                if (!builderPage.IsHasDeleteButtonInPricipalTable())
                {
                    Assert.Fail(string.Format(MessageCommon.MsgNotExist, Common.LblDelete + " " + Common.TagNameButton));
                }

                // 8.3. The principal has the Active checkbox selected
                if (builderPage.CountActivePrincipal() <= 0)
                {
                    Assert.Fail(string.Format(MessageCommon.MsgNotChecked, Common.ActiveColumn));
                }
            }
        }

        //HWIT-4604
        [TestMethod]
        public void VerifyTheActiveBuildersDOBIsNotOverwrittenOnSiraRefresh()
        {
            var currentUser = "nguyenv";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "Abc123456@");

            GoToSearchBeat();

            // 1.Search for a GTA Builder - Wisdom Properties , BLN- 92732C/174699C/36654C/ 
            var licenceNumber = "174699C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                var dob = "13-Sep-2019";
                var suburb = "MELBOURNE";

                // 2. Select Builder (orange i) before the builder name in the search result. 
                // 3.This will take the user to the Builder summary screen.
                builderPage.ClickViewBuilder();
                Thread.Sleep(5000);

                // Check not exists then add new principal
                if (!builderPage.IsHasDeleteButtonInPricipalTable())
                {
                    AddNewPrincipal("Jimmy Chonga", "1977", "MAROUBRA", "Director", "99999C", "18");
                }

                // 4. Verify the builder has principal details under "Builder Principal Details" which has the Active checkbox selected. 
                Assert.IsTrue(builderPage.BuidlerPrincipalDetailsHasActiveRow());
                var activeRowsCount = builderPage.CountActivePrincipal();

                // 5. Now go to the SIRA Builder Details screen and click the "Refresh licence details from SIRA" twice 
                builderPage.ClickSiraBuilderDetailMenuButton();
                Thread.Sleep(5000);
                builderPage.ClickRefreshLicenceDetailsFromSira();
                Thread.Sleep(5000);
                builderPage.WaitTillBusyDialogClose();
                builderPage.ClickRefreshLicenceDetailsFromSira();
                Thread.Sleep(5000);
                builderPage.WaitTillBusyDialogClose();
                // 6. Now go back to the Builder summary screen
                builderPage.ClickBuilderDetailMenuButton();
                Thread.Sleep(5000);

                // 6.1 Edit row that it was active
                var rowIndex = builderPage.ClickEditFirstActiveBuilderPrincipal();
                if (rowIndex > 0)
                {
                    builderPage.SetValueDobPrincipalDetail(rowIndex, dob);
                    builderPage.SetValueSuburbPrincipalDetail(rowIndex, suburb);
                    builderPage.ClickSavePrincipalDetail(rowIndex);
                    builderPage.WaitTillBusyDialogClose();
                }

                // 6.2 Edit row that it was inactive
                var rowIndexInactive = builderPage.ClickEditFirstInActiveBuilderPrincipal();
                if (rowIndexInactive > 0)
                {
                    builderPage.SetValueDobPrincipalDetail(rowIndexInactive, dob);
                    builderPage.SetValueSuburbPrincipalDetail(rowIndexInactive, suburb);
                    builderPage.ClickSavePrincipalDetail(rowIndexInactive);
                    builderPage.WaitTillBusyDialogClose();
                }

                builderPage.ClickSiraBuilderDetailMenuButton();
                Thread.Sleep(5000);
                builderPage.ClickRefreshLicenceDetailsFromSira();
                Thread.Sleep(5000);
                builderPage.WaitTillBusyDialogClose();
                builderPage.ClickRefreshLicenceDetailsFromSira();
                Thread.Sleep(5000);
                builderPage.WaitTillBusyDialogClose();
                builderPage.ClickBuilderDetailMenuButton();
                Thread.Sleep(5000);
                if (rowIndex > 0)
                {
                    Assert.IsTrue(builderPage.VerifyDobPrincipalDetail(rowIndex, dob));
                }
                if (rowIndexInactive > 0)
                {
                    Assert.IsTrue(builderPage.VerifyDobPrincipalDetail(rowIndexInactive, dob));
                }
            }
        }

        //HWIT-4610
        [TestMethod]
        public void VerifyTheKeyEventsAreUpdatedWhenCommentIsAddedOnTheInitiateReviewScreen()
        {
            var currentUser = "nguyenv";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "Abc123456@");

            GoToSearchBeat();

            var licenceNumber = "92732C";
            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();

            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                builderPage.ClickViewAssessments();
                builderPage.ClickEditLinkAssessment();
                builderPage.ClickButtonAddNewCommentInitiateReview();
                builderPage.SetCommentAssessment("test HWIT-4610");
                builderPage.ClickSaveCommentAssessment();
                builderPage.WaitTillBusyDialogClose();
                builderPage.ClickBuilderDetailMenuButton();
                Assert.IsTrue(builderPage.VerifyEventDataKeyEventLogs("test HWIT-4610"));
            }
        }

        //HWIT-4613
        [TestMethod]
        public void VerifyTheCSCUsersHaveAccessToScheduledAssignedReviewsReport()
        {
            var currentUser = "nguyenv";
            var loginPage = new LoginPage(driver);
            loginPage.Login(currentUser, "Abc123456@");

            GoToSearchBeat();

            builderPage.ClickReportMenu();
            builderPage.ClickAssessmentReports("Scheduled Assigned Reviews");
            Thread.Sleep(5000);
            Assert.IsTrue(driver.WindowHandles.Count > 1);
        }

        //HWIT-4652
        [TestMethod]
        public void TestTheAddNewDeedOnTheAssessmentOverallOutcome()
        {
            // 1. Login
            InitLogin();

            // 2. Search with licence number
            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                // 3. Click orange button to navigate to builder summary screen
                builderPage.ClickViewBuilder();

                if (builderPage.VerifyAssessmentTableHasNoFinalised())
                {
                    // 4. Select an assessment where EA Finalised is NO. This will take the user to 'Initiate Review screen' 
                    builderPage.ClickEditLinkAssessmentBuilderDetail();

                    // 5.1. Naviage to the 'Eligibility Details' screen
                    builderPage.ClickEligibilityDetails();
                    builderPage.WaitTillBusyDialogClose();

                    // 5.2 Copy all
                    builderPage.ClickCopyAllLimitsLink();
                    builderPage.WaitTillBusyDialogClose();

                    // 6.1. Click 'Save' button
                    builderPage.ClickButtonSaveEligibilityReview();
                    builderPage.WaitTillBusyDialogClose();
                    if (builderPage.VerifyBeginAssessmentIsEnabled())
                    {
                        builderPage.ClickBeginAssessment();
                        builderPage.WaitTillBusyDialogClose();
                    }

                    // 7. Verify 'Track Record' menu enabled
                    if (builderPage.IsTrackRecordEnable())
                    {
                        builderPage.ClickMenuTrackRecord();
                        builderPage.WaitTillBusyDialogClose();

                        // 8.1. Navigate 'Financial Inputs' screen 
                        builderPage.ClickButtonFinancialInputsMenu();
                        builderPage.WaitTillBusyDialogClose();

                        // 8.2. Enter value 'Sales' and 'Opening Stock'
                        builderPage.SetValueSalesRow(Common.SalesRow);
                        builderPage.SetValueOpeningStock(Common.OpeningStock);

                        // 8.3. Click 'Save' button
                        builderPage.ClickSaleSaveButton();
                        builderPage.WaitTillBusyDialogClose();

                        // 9.1. Navigate 'Overall Outcome' screen
                        builderPage.ClickButtonOverallOutcomeMenu();
                        builderPage.WaitTillBusyDialogClose();

                        // 10. Add new DOI with type "Job Specific Deed"
                        AddNewDOIWithType(DeedIndemnityType.JobSpecificDeed);

                        // 14. Add new DOI with type "Deed of Indemnity"
                        AddNewDOIWithType(DeedIndemnityType.DeedOfIndemnity);

                        // 15. Add new DOI with type "DOI in respect of former business"
                        AddNewDOIWithType(DeedIndemnityType.DOIRespectFormerBusiness);

                        // 16. Add new DOI with type "Group Trading Agreement"
                        AddNewDOIWithType(DeedIndemnityType.GroupTradingAgreement);

                        // 17.Add new DOI with type "Irregular Contracting Deed"
                        AddNewDOIWithType(DeedIndemnityType.IrregularContractingDeed);

                        // Testing success
                        return;
                    }
                }
            }

            // Testing faild
            Assert.Fail();
        }

        //HWIT-4686
        /// <summary>
        /// Verify the email is sent to Broker when the IA assigns them the assessment and vice versa
        /// </summary>
        [TestMethod]
        public void VerifyEmailSentToBroker()
        {
            // 1. Login
            InitLogin();

            // Search with licence number
            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                // 2. Click on the blue tick to the left of the builder name 
                builderPage.ClickViewAssessments();

                if (builderPage.GetColTextOfAssessmentTable(1, 11).Contains(Common.NO))
                {
                    // 3. In the assessments table - click the edit link for the assessment where EA finalised = No 
                    builderPage.ClickEditLinkAssessment();
                    builderPage.WaitTillBusyDialogClose();
                    
                    // 4.1. Check "Submit to Broker" button enable
                    if (builderPage.CheckSubmitToBrokerButton())
                    {
                        // 5.1. Click "Submit to Broker" button
                        builderPage.ClickSubmitToBrokerButton();
                        builderPage.WaitTillBusyDialogClose();

                        // 5.2. Check Distributor label was highlighted and is yellow color
                        if (!builderPage.VerifyColorDistributorLabel())
                        {
                            Assert.Fail(Common.MsgTestFail);
                            return;
                        }

                        // 6.1. Navigate "Builder Detail" screen
                        builderPage.ClickBuilderDetailMenuButton();
                        builderPage.WaitTillBusyDialogClose();

                        // 6.2. Now Verify the key event on builder summary screen
                        // Description : PER informtion screen submitted to Distributor 
                        // Event Data : Action required by : Broker
                        // 7. Verify email has gone through, check the logs:email reminder has been sent..... 
                        CheckResultVerifyEmailSentToBroker(Common.AssignedToDistributor, Common.ActionRequiredByBorker);
                    }
                    else
                    {
                        // 4.2. Check "Submit to Insurer" button enable
                        if (builderPage.CheckSubmitTheAssessmentToTheInsuranceAgent())
                        {
                            // 8. Click "Submit to Insurer" button
                            builderPage.ClickSubmitTheAssessmentToTheInsuranceAgentButton();
                            builderPage.WaitTillBusyDialogClose();

                            // 9.1. Navigate "Builder Detail" screen
                            // Description : PER informtion screen submitted to Distributor 
                            // Event Data : Action required by : Broker
                            // 10. Verify email has gone through, check the logs:email reminder has been sent..... 
                            CheckResultVerifyEmailSentToBroker(Common.AssignedToInsurer, Common.ActionRequiredByInSurer);
                        }
                    }

                    return;
                }
            }

            // Testing faild
            Assert.Fail();
        }

        //HWIT-4687
        /// <summary>
        /// Verify the ABN Lookup functionality on Create New Builder screen
        /// </summary>
        [TestMethod]
        public void VerifyABNLookupCreateNewBuilderScreen()
        {
            // 1. Login
            InitLogin();

            // Search with licence number
            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                // 2.1. Click on "Create New Builder" tab .
                builderPage.ClickCreateNewBuilderButtonMenu();
                Thread.Sleep(1000);

                // 2.2. This will  open a pop up window - "Licence Lookup" requesting "Contractor Licence No.". Click cancel.
                builderPage.ClickCloseLicenseLookUp();

                // 3.1. Now click the magnifying glass in front of the field "Builder ABN (no spaces)".
                builderPage.ClickImageLookUpButton();
                Thread.Sleep(2000);

                // 3.2. This will open Abn Lookup" , enter the ABN - 76951897360 and click search
                builderPage.SetValueInputLookUpAbn(BuilderDetailLabels.BuilderABN);
                builderPage.ClickSearchButtonAbnLookUp();
                builderPage.WaitTillAbnLookUpDialogClose();

                // 4. Immediately, this should populate the below details on the create new builder screen: Verify the following field details are populated:
                // 4.1. Licensed Builder Entity Name: Daljit Singh Sehra
                if (!builderPage.LicensedBuilderEntityNameContains(BuilderDetailLabels.LicensedBuilderEntityName))
                {
                    Assert.Fail(string.Format(MessageCommon.MsgNotMatch, Common.LicensedBuilderEntityName));
                }

                // 4.2. Builder ABN(no spaces) : 76951897360
                if (!builderPage.EABuilderABNContains(BuilderDetailLabels.BuilderABN))
                {
                    Assert.Fail(string.Format(MessageCommon.MsgNotMatch, Common.BuilderABNNoSpaces));
                }

                // 4.3. ASIC Entity Name: SEHRA, DALJIT S
                if (!builderPage.ASICEntityNameContain(BuilderDetailLabels.ASICEntityName))
                {
                    Assert.Fail(string.Format(MessageCommon.MsgNotMatch, Common.ASICEntityName));
                }

                // 4.4. Builder Postcode: 3083
                if (!builderPage.BuilderPostcodeContain(BuilderDetailLabels.BuilderPostcode))
                {
                    Assert.Fail(string.Format(MessageCommon.MsgNotMatch, Common.BuilderPostcode));
                }

                // 4.5. Builder State: VIC
                if (!builderPage.BuilderStateContain(BuilderDetailLabels.BuilderState))
                {
                    Assert.Fail(string.Format(MessageCommon.MsgNotMatch, Common.BuilderState));
                }

                // 4.6. Insurer: CSC
                if (!builderPage.InsurerContain(BuilderDetailLabels.Insurer))
                {
                    Assert.Fail(string.Format(MessageCommon.MsgNotMatch, Common.Insurer));
                }

                return;
            }

            // Testing faild
            Assert.Fail();
        }

        //HWIT-4707
        /// <summary>
        /// Verify the ABN number if changed for the Deed doesn't revert back to the Builders original ABN
        /// </summary>
        [TestMethod]
        public void VerifyABNNumberIfChangedDeedDoesNotRevertBackBuilderOriginal()
        {
            // 1. Login
            InitLogin();

            // Search with licence number
            var searchResult = builderPage.ResultSearch();
            if (searchResult)
            {
                // 2. Click on the blue tick to the left of the builder name 
                builderPage.ClickViewAssessments();
                Thread.Sleep(5000);

                if (builderPage.GetColTextOfAssessmentTable(1, 11).Contains(Common.NO))
                {
                    // 3. In the assessments table - click the edit link for the assessment where EA finalised = No 
                    builderPage.ClickEditLinkAssessment();
                    builderPage.WaitTillBusyDialogClose();

                    // 4.1. Click the Eligibility Details menu item to navigate to the 'Eligibility Details' screen
                    builderPage.ClickEligibilityDetails();
                    builderPage.WaitTillBusyDialogClose();
                    
                    // 4.2. Click "copy all" below "Requested/Projected $"
                    builderPage.ClickCopyAllLimitsLink();
                    builderPage.WaitTillBusyDialogClose();

                    // 5. Click the 'save' button first and then click 'begin assessment button'
                    builderPage.ClickButtonSaveEligibilityReview();
                    builderPage.WaitTillBusyDialogClose();
                    if (builderPage.VerifyBeginAssessmentIsEnabled())
                    {
                        builderPage.ClickBeginAssessment();
                        builderPage.WaitTillBusyDialogClose();
                    }

                    // 6. Verify the 'track record' menu item is enabled.
                    if (!builderPage.IsTrackRecordEnable())
                    {
                        Assert.Fail(string.Format(MessageCommon.MsgDisabled, Common.TrackRecordMenu));
                        return;
                    }

                    // 7.1. Navigate to the 'Financial Inputs' screen
                    builderPage.ClickButtonFinancialInputsMenu();
                    builderPage.WaitTillBusyDialogClose();

                    // 7.2. Enter value 'Sales' and 'Opening Stock'
                    builderPage.SetValueSalesRow(Common.SalesRow);
                    builderPage.SetValueOpeningStock(Common.OpeningStock);

                    // 7.3. Click 'Save' button
                    builderPage.ClickSaleSaveButton();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(3000);

                    // 8.1. Navigate 'Overall Outcome' screen
                    builderPage.ClickButtonOverallOutcomeMenu();
                    builderPage.WaitTillBusyDialogClose();

                    // 11. Remove any other pre existing conditions by clicking the red x button against condition.
                    // There should not be any other condition available apart from the one added by the user.
                    //OverallOutcomeService.DeleteConditions();
                    builderPage.ClearRecuringConditionForAssessment();

                    // 8.2 select the check box for the question, "Are there any conditions required as part of the terms to be offered?"
                    if (builderPage.IsEnabledCheckBoxAnyConditionRequired())
                    {
                        builderPage.SetCheckBoxAnyConditionsRequired(true);
                        builderPage.WaitTillBusyDialogClose();

                        // 9. This should have enabled the "Add conditions" button.
                        if (!builderPage.IsEnabelAddConditionButton())
                        {
                            Assert.Fail(string.Format(MessageCommon.MsgDisabled, Common.AddConditionButton));
                            return;
                        }

                        // 10.1. Click on "Add condition" button
                        builderPage.ClickAddConditionButton2();
                        builderPage.WaitTillBusyDialogClose();

                        // 10.2. Set condition value is "Deed of Indemnity Required for eligibility"
                        builderPage.SetConditionDll(SelectConditionDialog.DOIRequiredForEligibility);
                        Thread.Sleep(3000);

                        // 10.3. Set condition status is "Not Met"
                        builderPage.SetValueConditionStatus(SelectStatusConditionDialog.NotMet);

                        // 10.4. Click save button in condition dialog
                        builderPage.ClickConditionDialogSaveButton();
                        builderPage.WaitTillBusyDialogClose();
                    }

                    // 12, 13. Add new DOI with type "Group Trading Agreement"
                    AddNewDoi(DeedIndemnityType.GroupTradingAgreement);

                    // 14. Change the last 2 digits of the pre-existing ABN number
                    // Get ABN number existing
                    string abnNumber = builderPage.GetValueABNInputNewDOI();
                    ChangeLastTwoDigits(ref abnNumber);

                    // Set ABN number
                    builderPage.SetValueABNInputNewDOI(abnNumber);

                    // 15. Verfy there is option to add indemnifiers/Contracting Party
                    AddNewIndemnifier();

                    // 16.1. Once clicked OK button on New Deep of Indemnity dialog
                    builderPage.ClickButtonOkNewDeedOfIndemninty();
                    // builderPage.WaitTillSaveDeedOfIndemnityDialogClose();
                    Thread.Sleep(2000);

                    // 16.2. this should open a confirmation dialogue box -Confirm ABN change with the below message: 
                    // "The ABN for the deed will be different to the builder ABN 
                    // Click OK to proceed or Cancel to revert the ABN" 
                    if (!builderPage.CheckExistTextInConfirmABNChangDialog(ConfirmABNChangeDialog.MsgText))
                    {
                        Assert.Fail(string.Format(MessageCommon.MsgNotMatch, Common.CaptionConfirmABNChangeDialog));
                    }

                    // 16.3. Click OK
                    builderPage.ClickOkButtonConfirmABNChange();
                    builderPage.WaitTillSaveDeedOfIndemnityDialogClose();
                    Thread.Sleep(10000);

                    // 17. Verify the below details for the added deed is : 
                    // 17.1. Option Hardcopy is disabled.
                    if (builderPage.FindElementsByTagName(Common.TagNameInput, 7).First().Enabled)
                    {
                        Assert.Fail(string.Format(MessageCommon.MsgEnabled, Common.HardCopyColumn));
                    }

                    // 17.2. Status - Draft
                    if (!builderPage.GetContentColumnOfDOITable(6).Text.Contains(Common.Draft))
                    {
                        Assert.Fail(string.Format(MessageCommon.MsgNotMatch, Common.StatusColumn));
                    }

                    // 17.3. There is option to 'Delete'
                    if (!builderPage.FindElementsByTagName(Common.TagNameButton, 8)[3].Text.Contains(Common.LblDelete))
                    {
                        Assert.Fail(string.Format(MessageCommon.MsgNotExist, Common.LblDelete + " " + Common.TagNameButton));
                    }

                    // 17.4. Amount - 'N/A'
                    if (!builderPage.GetContentColumnOfDOITable(5).Text.Contains(Common.N_A))
                    {
                        Assert.Fail(string.Format(MessageCommon.MsgNotMatch, Common.AmountColumn));
                        return;
                    }

                    // 17.5. Date - 'current date'
                    if (builderPage.GetContentColumnOfDOITable(2).Text != DateTime.Now.ToString(Common.FormatDate))
                    {
                        Assert.Fail(string.Format(MessageCommon.MsgNotMatch, Common.DateColumn));
                    }

                    // 18. Now click the option - edit draft and verify the ABN is the new ABN updated in Step 14 and NOT the original builder ABN . click Cancel.
                    Thread.Sleep(5000);
                    builderPage.ClickEditDraffButtonDOI(8);

                    // 18.1. Get ABN from Edit Deed of Indemnity dialog
                    string newABNNumber = builderPage.GetValueABNInputNewDOI();
                    if (abnNumber != newABNNumber)
                    {
                        Assert.Fail(string.Format(MessageCommon.MsgNotMatch, Common.ABNNumber));
                    }

                    // 18.2. Click Cancel button
                    Thread.Sleep(5000);
                    builderPage.ClickCancelButtonInDOI();

                    // 19. Now click - view draft. This should download the document in pdf format. Verify the ABN number of the Builder shows the updated/changed ABN.
                    Thread.Sleep(5000);
                    builderPage.ClickViewDraffButtonDOI(8);
                    Thread.Sleep(10000);

                    // 20. Now click the option - email. This should open a popup showing the BUilder name, abn and licence number. 
                    builderPage.ClickEmailButtonFirstRowDoiOverallOutcome();
                    builderPage.WaitTillRenderingEmailTemplateDialogClose();

                    // 21. Click send. This should show another popup with header - Email success and message "The email has been successfully queued". Click Ok. 
                    builderPage.ClickSendButton();
                    Thread.Sleep(5000);
                    if (builderPage.CheckEmailSucessDialogDOI(MessageCommon.MsgSendMailSuccess))
                    {
                        builderPage.ClickOkButtonInEmailSuccessDialog();
                        return;
                    }
                }
            }

            // Testing faild
            Assert.Fail();
        }

        // HWIT-4725
        /// <summary>
        /// Verify the 'Offer Terms' button is available for NEW Assessments (UW-Declined, Broker-Declined, OJV/OJN-0/0)
        /// </summary>
        [TestMethod]
        public void VerifyOfferTermsButtonIsAvaiableForNewAssessmentByDeclined()
        {
            VerifyOfferTermsUW_DeclinedByEligibilityAssessment(EligibilityAssessmentStatus.Declined);
        }

        // HWIT-4726
        /// <summary>
        /// Verify the 'Offer Terms' button is available for NEW Assessments(UW-Declined, Broker-Terms Accepted, OJV/OJN-0/0)
        /// </summary>
        [TestMethod]
        public void VerifyOfferTermsButtonIsAvaiableForNewAssessmentByTermsAccepted()
        {
            VerifyOfferTermsUW_DeclinedByEligibilityAssessment(EligibilityAssessmentStatus.TermsAccepted);
        }

        // HWIT-4727
        /// <summary>
        /// Verify the 'Offer Terms' button is available for NEW Assessments (UW-Declined, Broker-Terms Accepted, OJV/OJN > 0/0)
        /// </summary>
        [TestMethod]
        public void VerifyOfferTermsButtonByUW_Declined_Broker_TermsAccepted_OJV_OJN_GreaterZero()
        {
            VerifyOfferTermsButton_UW_Declined_By_OpenJobAndEAStatus(Common.Value5, Common.Value2, EligibilityAssessmentStatus.TermsAccepted);
        }

        // HWIT-4728
        /// <summary>
        /// Verify the 'Offer Terms' button is available for NEW Assessments (UW-Declined, Broker-Declined, OJV/OJN > 0/0
        /// </summary>
        [TestMethod]
        public void VerifyOfferTermsButtonByUW_Declined_Broker_Declined_OJV_OJN_GreaterZero()
        {
            VerifyOfferTermsButton_UW_Declined_By_OpenJobAndEAStatus(Common.Value6, Common.Value2, EligibilityAssessmentStatus.Declined);
        }

        // HWIT-4729
        /// <summary>
        /// Verify the 'Offer Terms' button is available for NEW Assessments(UW-Approved, Broker-Accepted, OJV/OJN-0/0
        /// </summary>
        [TestMethod]
        public void VerifyOfferTermsButtonByUW_Approved_Broker_Accepted_OJV_OJN_Zero()
        {
            VerifyOfferTermsUW_Approved_Zero_ByEligibilityAssessment(EligibilityAssessmentStatus.TermsAccepted);
        }

        // HWIT-4730
        /// <summary>
        /// Verify the 'Offer Terms' button is available for NEW Assessments (UW-Approved, Broker-Declined, OJV/OJN-0/0
        /// </summary>
        [TestMethod]
        public void VerifyOfferTermsButtonByUW_Approved_Broker_Declined_OJV_OJN_Zero()
        {
            VerifyOfferTermsUW_Approved_Zero_ByEligibilityAssessment(EligibilityAssessmentStatus.Declined);
        }

        // HWIT-4731
        /// <summary>
        /// Verify the 'Offer Terms' button is available for NEW Assessments (UW-Approved, Broker-Accepted, OJV/OJN > 0/0
        /// </summary>
        [TestMethod]
        public void VerifyOfferTermsButtonByUW_Approved_Broker_Accepted_OJV_OJN_GreaterZero()
        {
            InitLoginToOverallOutcomeScreen();

            // 9.2 HBCF Approved Open Job Limit Value: 2000000
            // 9.3 HBCF Approved Open Job Limit Number: 5
            builderPage.SetValueForHBCFOpenJobLimit(Common.Value5, Common.Value2);

            // 10. Select the option under Accept or adjust outcome: Underwriter Assessment Outcome (provide notes below) - Approved Rating Z with no conditions
            builderPage.SetValueForUnderWriterAssessmentOutcomeDropDown(UnderwriterAssessmentOutcome.ApprovedRatingZNoConditions);
            builderPage.WaitTillBusyDialogClose();

            // 11. Select the DUA checkbox for Delegation Approval (Underwriter E delegation or higher required to finalise). 
            if (!builderPage.IsDelegationApprovalCheckboxChecked())
            {
                builderPage.ClickDelegationApprovalCheckbox();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(3000);
            }

            // 12. Verify the button - "Generate Eligibility" button is still disabled. 
            if (builderPage.IsEnabledGenerateEligibilityButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgEnabled, Common.GenerateEligibilityButton));
            }

            // 13.1. Select 'Terms Accepted' from 'Eligibility Assessment Status' field drop-down available in 'Outcome Details' subsection on Overall outcome screen 
            builderPage.SetValueEligibilityAssessmentStatusDll(EligibilityAssessmentStatus.TermsAccepted);

            // 13.2. Click "Save outcome details" 
            builderPage.ClickSaveOutcomeDetailsButton();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 13.3. Immediately the "Finalise Assessment" button is enabled.
            if (!builderPage.IsEnabledFinaliseAssessmentButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgDisabled, Common.FinaliseAssessmentButton));
            }

            // 14.1. Verify the "Offer Terms" button is enabled under 'Outcome Details' screen. 
            if (!builderPage.IsEnabledOfferTermsButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgDisabled, Common.OfferTermsButton));
            }

            // 14.2 & 15. Click 'send'. On the screen, below message pops up - The email has been queued for sending by the email service. 
            ClickOfferTermsButtonAndSendMail();
            
            // 16.Verify the " Next Planned Eligibility Review Date" is blank.
            if (!builderPage.IsBlankNextPlanedReviewDate())
            {
                Assert.Fail(string.Format(MessageCommon.MsgBlank, Common.NextPlanedReviewDate));
            }

            // 17.1. Verify the "Finalise Assessment " button is AVAILABLE. 
            if (!builderPage.IsEnabledFinaliseAssessmentButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgEnabled, Common.FinaliseAssessmentButton));
            }

            // 17.2. Click the finalise button
            builderPage.ClickFinaliseAssessmentButton();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(2000);

            // 17.3. Immediately "Generate Eligibility" button is ENABLED.
            if (!builderPage.IsEnabledGenerateEligibilityButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgDisabled, Common.GenerateEligibilityButton));
            }

            // 18.1. Click Generate Eligibility 
            builderPage.ClickGenerateEligibilityButton();

            // 18.2. this will take the user to the "Eligibility Details screen. Select the checkbox for 'Open Job Values checked?
            builderPage.SetCheckBoxOpenJobValueCheck(true);

            // 18.3. Then click -"Generate PDF Certificate of Eligibility"
            builderPage.ClickGenerateCertificateOfEligibilityButton();
        }

        // HWIT-4732
        /// <summary>
        /// Verify the 'Offer Terms' button is available for NEW Assessments (UW-Approved, Broker-Declined, OJV/OJN > 0/0)
        /// </summary>
        [TestMethod]
        public void VerifyOfferTermsButtonByUW_Approved_Broker_Declined_OJV_OJN_GreaterZero()
        {
            InitLoginToOverallOutcomeScreen();

            // 9.2 HBCF Approved Open Job Limit Value: 2000000
            // 9.3 HBCF Approved Open Job Limit Number: 5
            builderPage.SetValueForHBCFOpenJobLimit(Common.Value5, Common.Value2);

            // 10. Select the option under Accept or adjust outcome: Underwriter Assessment Outcome (provide notes below) - Approved Rating Z with no conditions
            builderPage.SetValueForUnderWriterAssessmentOutcomeDropDown(UnderwriterAssessmentOutcome.ApprovedRatingZNoConditions);
            builderPage.WaitTillBusyDialogClose();

            // 11. Select the DUA checkbox for Delegation Approval (Underwriter E delegation or higher required to finalise). 
            if (!builderPage.IsDelegationApprovalCheckboxChecked())
            {
                builderPage.ClickDelegationApprovalCheckbox();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(3000);
            }

            // 12.1. Verify the "Offer Terms" button is enabled under 'Outcome Details' screen. Click the button - a popup will come up displaying "Offer Terms". 
            if (!builderPage.IsEnabledOfferTermsButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgDisabled, Common.OfferTermsButton));
            }

            // 12.2 & 13. Click 'send'. On the screen, below message pops up - The email has been queued for sending by the email service. 
            ClickOfferTermsButtonAndSendMail();

            // 14. verify the - "Generate Eligibility" button is still disabled. 
            if (builderPage.IsEnabledGenerateEligibilityButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgEnabled, Common.GenerateEligibilityButton));
            }

            // 15.1. Select 'DECLINED' from 'Eligibility Assessment Status' field drop-down available in 'Outcome Details' subsection on Overall outcome screen
            builderPage.SetValueEligibilityAssessmentStatusDll(EligibilityAssessmentStatus.TermsAccepted);

            // 15.2. Click "Save outcome details".
            builderPage.ClickSaveOutcomeDetailsButton();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 15.3. Immediately the "Finalise Assessment" button is enabled.
            if (!builderPage.IsEnabledFinaliseAssessmentButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgDisabled, Common.FinaliseAssessmentButton));
            }

            // 16. Verify the " Next Planned Eligibility Review Date" is blank. 
            if (!builderPage.IsBlankNextPlanedReviewDate())
            {
                Assert.Fail(string.Format(MessageCommon.MsgBlank, Common.NextPlanedReviewDate));
            }

            // 17. Verify the "Finalise Assessment " button is AVAILABLE. Click the finalise button, Immediately "Generate Eligibility" button is ENABLED. 
            if (!builderPage.IsEnabledFinaliseAssessmentButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgEnabled, Common.FinaliseAssessmentButton));
            }

            // 17.2. Click the finalise button
            builderPage.ClickFinaliseAssessmentButton();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(2000);

            // 17.3. Immediately "Generate Eligibility" button is ENABLED.
            if (!builderPage.IsEnabledGenerateEligibilityButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgDisabled, Common.GenerateEligibilityButton));
            }
            
            // 18.1. Click Generate Eligibility 
            builderPage.ClickGenerateEligibilityButton();

            // 18.2. this will take the user to the "Eligibility Details screen. Select the checkbox for 'Open Job Values checked?
            builderPage.SetCheckBoxOpenJobValueCheck(true);

            // 18.3. Then click -"Generate PDF Certificate of Eligibility"
            builderPage.ClickGenerateCertificateOfEligibilityButton();
        }

        // HWIT-4740
        /// <summary>
        /// Verify the financial inputs screen on changing the year end month to 'December' on builder details screen and annual review on Initiate review screen
        /// </summary>
        [TestMethod]
        public void VerifyFinancialInputsScreenChangingTheYearEndMonthToDecember()
        {
            VerifyFinancialInputsScreenChangingTheYearEndMonth((int)TicketEnum.T4740);
        }

        // HWIT-4741
        /// <summary>
        /// Verify the financial inputs screen on changing the year end month to 'March' on builder details screen and annual review on Initiate review screen
        /// </summary>
        [TestMethod]
        public void VerifyFinancialInputsScreenChangingTheYearEndMonthToMarch()
        {
            VerifyFinancialInputsScreenChangingTheYearEndMonth((int)TicketEnum.T4741);
        }

        // HWIT-4743
        /// <summary>
        /// Verify the financial inputs screen on changing the year end month to 'June' on builder details screen and annual review on Initiate review screen
        /// </summary>
        [TestMethod]
        public void VerifyFinancialInputsScreenChangingTheYearEndMonthToJune()
        {
            VerifyFinancialInputsScreenChangingTheYearEndMonth((int)TicketEnum.T4743);
        }

        // HWIT-4757
        /// <summary>
        /// Verify the financial inputs screen on changing the year end month to 'June' on builder details screen and quarterly review (September) on Initiate review screen
        /// </summary>
        [TestMethod]
        public void VerifyFinancialInputsScreenChangingTheYearEndMonthToJune_Sept()
        {
            VerifyFinancialInputsScreenChangingTheYearEndMonth((int)TicketEnum.T4757);
        }

        // HWIT-4758
        /// <summary>
        /// Verify the financial inputs screen on changing the year end month to 'June' on builder details screen and Financial year being assessed =2017 on Initiate review screen
        /// </summary>
        [TestMethod]
        public void VerifyFinancialInputsScreenChangingTheYearEndMonthToJune_2017()
        {
            VerifyFinancialInputsScreenChangingTheYearEndMonth((int)TicketEnum.T4758);
        }

        // HWIT-4759
        /// <summary>
        /// Verify the financial inputs screen on changing the year end month to 'December' on builder details screen and Financial year being assessed =2017 on Initiate review screen
        /// </summary>
        [TestMethod]
        public void VerifyFinancialInputsScreenChangingTheYearEndMonthToDecember_2017()
        {
            VerifyFinancialInputsScreenChangingTheYearEndMonth((int)TicketEnum.T4759);
        }

        // HWIT-4760
        /// <summary>
        /// Verify the financial inputs screen on changing the year end month to 'December' on builder details screen and quarterly review (September) on Initiate review screen
        /// </summary>
        [TestMethod]
        public void VerifyFinancialInputsScreenChangingTheYearEndMonthToDecember_Sept()
        {
            VerifyFinancialInputsScreenChangingTheYearEndMonth((int)TicketEnum.T4760);
        }

        // HWIT-4761
        /// <summary>
        /// Verify the financial inputs screen on changing the year end month to 'March' on builder details screen and and Financial year being assessed =2017
        /// </summary>
        [TestMethod]
        public void VerifyFinancialInputsScreenChangingTheYearEndMonthToMarch_2017()
        {
            VerifyFinancialInputsScreenChangingTheYearEndMonth((int)TicketEnum.T4761);
        }

        // HWIT-4762
        /// <summary>
        /// Verify the financial inputs screen on changing the year end month to 'March' on builder details screen and quarterly review (September) on Initiate review screen
        /// </summary>
        [TestMethod]
        public void VerifyFinancialInputsScreenChangingTheYearEndMonthToMarch_Sept()
        {
            VerifyFinancialInputsScreenChangingTheYearEndMonth((int)TicketEnum.T4762);
        }

        /// <summary>
        /// Verify Financial Inputs screen on changing the year end month by ticket
        /// </summary>
        /// <param name="yemByTicket">#4740, #4741, #4743, #4757, #4758, #4759, #4760, #4761, #4762</param>
        private void VerifyFinancialInputsScreenChangingTheYearEndMonth(int yemByTicket)
        {
            var licenceNumber = "275960C";

            // 1. Login
            InitLogin(licenceNumber);

            // Search with licence number
            if (!builderPage.ResultSearch())
            {
                Assert.Fail(MessageCommon.MsgNotRecord);
            }

            // 2. Click the orange button to navigate to the builder details screen
            builderPage.ClickViewBuilder();

            // Get value selected Year End Month old
            var yearEndMonthOld = BuilderDetailsService.GetValueSelectedYearEndMonth();
            var yearEndMonth = string.Empty; // December, September, June, March
            var eventData = string.Empty; // 
            List<string> lstValue = null;
            string financialYearDDL = string.Empty; // 2019, 2018, 2017, ...
            string lstYearMonthLabel = string.Empty; // DEC 2019 DEC 2018 DEC 2017, ...
            var cashFirst = string.Empty;
            var cashSecond = string.Empty;
            switch (yemByTicket)
            {
                case (int)TicketEnum.T4740:
                case (int)TicketEnum.T4759:
                case (int)TicketEnum.T4760:
                    yearEndMonth = YearEndMonth.December;
                    eventData = string.Format(Common.LblEventData2, BuilderDetailsService.GetBuilderName(), MemberInfo.Username2, yearEndMonthOld, yearEndMonth);

                    // Jun-2019-YTD, Sep-2019-YTD, 2019, 2018, 2017, 2016
                    lstValue = new List<string>() { FinancialYearDDL.Jun_2019_YTD, FinancialYearDDL.Sep_2019_YTD, FinancialYearDDL.Year2019
                        , FinancialYearDDL.Year2018, FinancialYearDDL.Year2017, FinancialYearDDL.Year2016 };

                    if (yemByTicket == (int)TicketEnum.T4740)
                    {
                        // Financial year being assessed = '2019'
                        financialYearDDL = FinancialYearDDL.Year2019;

                        // DEC - 19 DEC - 18   DEC - 17 DEC - 16
                        lstYearMonthLabel = Common.ListYearMonthDec;

                        // Cash
                        cashFirst = "370000";
                    }
                    else if (yemByTicket == (int)TicketEnum.T4759)
                    {
                        // Financial year being assessed = '2017'
                        financialYearDDL = FinancialYearDDL.Year2017;

                        // DEC 2017	DEC 2016	DEC 2015	DEC 2014 
                        lstYearMonthLabel = Common.ListYearMonthDec_2017;

                        // Cash first
                        cashFirst = "666000";

                        // Cash second
                        cashSecond = "45000";
                    }
                    else
                    {
                        // Financial year being assessed = 'SEP-2019-YTD'
                        financialYearDDL = FinancialYearDDL.Sep_2019_YTD;

                        // SEP 2019	DEC 2018	DEC 2017	DEC 2016 
                        lstYearMonthLabel = Common.ListYearMonthDec_Sep;

                        // Cash first
                        cashFirst = "45000";

                        // Cash second
                        cashSecond = "555000";
                    }
                    break;
                case (int)TicketEnum.T4743:
                    yearEndMonth = YearEndMonth.June;
                    eventData = string.Format(Common.LblEventData2, BuilderDetailsService.GetBuilderName(), MemberInfo.Username2, yearEndMonthOld, yearEndMonth);

                    // Sep-2019-YTD, 2019, 2018, 2017, 2016
                    lstValue = new List<string>() { FinancialYearDDL.Sep_2019_YTD, FinancialYearDDL.Year2019
                        , FinancialYearDDL.Year2018, FinancialYearDDL.Year2017, FinancialYearDDL.Year2016 };

                    // Jun-19 Jun-18	Jun-17 Jun-16 
                    lstYearMonthLabel = Common.ListYearMonthJune;

                    // Financial year being assessed = '2019'
                    financialYearDDL = FinancialYearDDL.Year2019;

                    // Cash first
                    cashFirst = "400000";

                    break;
                case (int)TicketEnum.T4757:
                    yearEndMonth = YearEndMonth.June;
                    eventData = string.Format(Common.LblEventData2, BuilderDetailsService.GetBuilderName(), MemberInfo.Username2, yearEndMonthOld, yearEndMonth);

                    // Sep-2019-YTD, 2019, 2018, 2017, 2016
                    lstValue = new List<string>() { FinancialYearDDL.Sep_2019_YTD, FinancialYearDDL.Year2019
                        , FinancialYearDDL.Year2018, FinancialYearDDL.Year2017, FinancialYearDDL.Year2016 };

                    // Sep-19	Jun-18	Jun-17	Jun-16 
                    lstYearMonthLabel = Common.ListYearMonthJune_Sep;

                    // Financial year being assessed = 'Sep-2019-YTD'
                    financialYearDDL = FinancialYearDDL.Sep_2019_YTD;

                    // Cash first
                    cashFirst = "45000";

                    // Cash second
                    cashSecond = "400000";

                    break;
                case (int)TicketEnum.T4758:
                    yearEndMonth = YearEndMonth.June;
                    eventData = string.Format(Common.LblEventData2, BuilderDetailsService.GetBuilderName(), MemberInfo.Username2, yearEndMonthOld, yearEndMonth);

                    // Sep-2019-YTD, 2019, 2018, 2017, 2016
                    lstValue = new List<string>() { FinancialYearDDL.Sep_2019_YTD, FinancialYearDDL.Year2019
                        , FinancialYearDDL.Year2018, FinancialYearDDL.Year2017, FinancialYearDDL.Year2016 };

                    // Jun-17	Jun-16	Jun-15	Jun-14
                    lstYearMonthLabel = Common.ListYearMonthJune_2017;

                    // Financial year being assessed = '2017'
                    financialYearDDL = FinancialYearDDL.Year2017;

                    // Cash first
                    cashFirst = "255000";

                    // Cash second
                    cashSecond = "45000";

                    break;
                case (int)TicketEnum.T4741:
                    yearEndMonth = YearEndMonth.March;
                    eventData = string.Format(Common.LblEventData2, BuilderDetailsService.GetBuilderName(), MemberInfo.Username2, yearEndMonthOld, yearEndMonth);

                    // Jun-2019-YTD, Sep-2019-YTD, 2019, 2018, 2017, 2016
                    lstValue = new List<string>() { FinancialYearDDL.Jun_2019_YTD, FinancialYearDDL.Sep_2019_YTD, FinancialYearDDL.Year2019
                        , FinancialYearDDL.Year2018, FinancialYearDDL.Year2017, FinancialYearDDL.Year2016 };

                    // Financial year being assessed = '2019'
                    financialYearDDL = FinancialYearDDL.Year2019;

                    // MAR - 19 MAR - 18   MAR - 17 MAR - 16
                    lstYearMonthLabel = Common.ListYearMonthMarch;

                    // Cash
                    cashFirst = "593000";
                    cashSecond = "45000";
                    break;
                case (int)TicketEnum.T4761:
                    yearEndMonth = YearEndMonth.March;
                    eventData = string.Format(Common.LblEventData2, BuilderDetailsService.GetBuilderName(), MemberInfo.Username2, yearEndMonthOld, yearEndMonth);

                    // Jun-2019-YTD, Sep-2019-YTD, 2019, 2018, 2017, 2016
                    lstValue = new List<string>() { FinancialYearDDL.Jun_2019_YTD, FinancialYearDDL.Sep_2019_YTD, FinancialYearDDL.Year2019
                        , FinancialYearDDL.Year2018, FinancialYearDDL.Year2017, FinancialYearDDL.Year2016 };

                    // Financial year being assessed = '2019'
                    financialYearDDL = FinancialYearDDL.Year2017;

                    // MAR - 19 MAR - 18   MAR - 17 MAR - 16
                    lstYearMonthLabel = Common.ListYearMonthMarch_2017;

                    // Cash
                    cashFirst = "593000";
                    break;
                case (int)TicketEnum.T4762:
                    yearEndMonth = YearEndMonth.March;
                    eventData = string.Format(Common.LblEventData2, BuilderDetailsService.GetBuilderName(), MemberInfo.Username2, yearEndMonthOld, yearEndMonth);

                    // Sep-2019-YTD, 2019, 2018, 2017, 2016
                    lstValue = new List<string>() { FinancialYearDDL.Sep_2019_YTD, FinancialYearDDL.Year2019
                        , FinancialYearDDL.Year2018, FinancialYearDDL.Year2017, FinancialYearDDL.Year2016 };

                    // Financial year being assessed = 'Sep-2019-YTD'
                    financialYearDDL = FinancialYearDDL.Sep_2019_YTD;

                    // MAR - 19 MAR - 18   MAR - 17 MAR - 16
                    lstYearMonthLabel = Common.ListYearMonthMarch_Sep;

                    // Cash
                    cashFirst = "593000";
                    break;
            }
            if (!BuilderDetailsService.GetValueSelectedYearEndMonth().ToUpper().Contains(yearEndMonth.ToUpper()))
            {
                // Redirect to Login page
                GoToLoginPage();
                Thread.Sleep(3000);

                // 2.2. If it is not "December", login as hbcf user and update the dropdown value to December and click 'save builder details'. If the year end is already set to December, skip to step 4.
                var loginPage = new LoginPage(driver);
                loginPage.Login(MemberInfo.Username2, MemberInfo.Password2);

                // Search
                GoToSearchBeat();
                Thread.Sleep(1000);

                builderPage.SetBuilderLicenceNumber(licenceNumber);
                builderPage.ClickSearchBuilder();
                Thread.Sleep(1000);

                // Search with licence number
                if (!builderPage.ResultSearch())
                {
                    Assert.Fail(MessageCommon.MsgNotRecord);
                }

                // Click the orange button to navigate to the builder details screen
                builderPage.ClickViewBuilder();

                // 2.3. Update the dropdown value to December
                BuilderDetailsService.SetValueForYearEndMonthDll(yearEndMonth);
                Thread.Sleep(1000);

                // 2.4. Click 'save builder details'
                BuilderDetailsService.ClickBuiderDetailSaveButton();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(5000);

                //3.If the "Year Month End" is updated , verify the key event has logged the change: 
                //Description : Builder was updated with new Year End.
                //Created By : CSCTestC
                //Event Data : Year End for ****Builder Name *** was changed by*** CSCTestC**** from* prior month name* to December

                if (!BuilderDetailsService.IsExistsDataInKeyEventLog(Common.LblDescriptionKeyEventLog, MemberInfo.Username2, eventData))
                {
                    Assert.Fail(string.Format(MessageCommon.MsgNotMatch, Common.LblKeyEventLog));
                }
            }

            // 4. Now scroll down the screen and in the assessments table - click the "edit" link for the assessment where EA finalised = No. 
            if (!BuilderDetailsService.VerifyAssessmentTableHasNoFinalised())
            {
                Assert.Fail(string.Format(MessageCommon.MsgNotExist, Common.EAFinalisedColumn));
            }

            // 4.1. Click the "edit" link for the assessment where EA finalised = No.
            BuilderDetailsService.ClickEditLinkAssessmentBuilderDetail();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(5000);

            // 5.This will take the user to 'Initiate Review screen'.On the Initiate Review Screen, Verify the options available under the field "Financial year being assessed " are:
            // Check Financial Year is not contains '2019' then update to 2018-2015
            if (!InitiateReviewService.CheckExists2019InFinancialYearDll())
            {
                lstValue = new List<string>() { FinancialYearDDL.Jun_2019_YTD, FinancialYearDDL.Sep_2019_YTD, FinancialYearDDL.Year2015
                        , FinancialYearDDL.Year2018, FinancialYearDDL.Year2017, FinancialYearDDL.Year2016 };
                financialYearDDL = FinancialYearDDL.Year2018;
                lstYearMonthLabel = Common.ListYearMonthDec_2018;
            }
            if (!InitiateReviewService.CheckExistsValueInSelectOption(lstValue))
            {
                Assert.Fail(string.Format(MessageCommon.MsgNotMatch, Common.FinancialYearBeingAssessed));
            }

            // 6.Enter the below details on the 'Initiate Review screen'and click 'save' 
            //-- > Assessment Type = leave the prefilled value
            // -- > Comment = current date is ****current date * **
            SaveInitiateReview(financialYearDDL, string.Empty, DateTime.Now.ToString());

            // 7.Click the Eligibility Details menu item to navigate to the 'Eligibility Details' screen and click "copy all" below "Requested/Projected $". 
            // 8. Click the 'save' button first and then click 'begin assessment button' 
            SaveEligibilityDetails();

            // 9. Verify the 'track record' menu item is enabled.
            SaveTrackRecord();

            // Check if don't navigate to Financial Input screen
            if (!FinancialInputsService.IsLoadPage())
            {
                builderPage.ClickButtonFinancialInputsMenu();
            }
            // 10. On the financial Inputs screen , validate the year ends available on the screen are: Jun-17	Jun-16	Jun-15	Jun-14
            if (!FinancialInputsService.CheckExistsValueYearEndMonth(lstYearMonthLabel))
            {
                Assert.Fail(string.Format(MessageCommon.MsgNotMatch, Common.P_L));
            }
            var financialInputUrl = builderPage.GetUrlCurrent();

            // 11. Enter below values for june 17 and click save: --> sales: 5,000,000, -- > Opening Stock: 250,000
            FinancialInputsService.SetValueForFirstTextBoxBySectionName(SectionNameFinancialInputs.Sales, Common.SalesRow);
            FinancialInputsService.SetValueForFirstTextBoxBySectionName(SectionNameFinancialInputs.OpeningStock, Common.OpeningStock);

            // 11.2. Click Save button in Sales section
            FinancialInputsService.ClickSaveButtonBySectionName(SectionNameFinancialInputs.Sales);
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 12. If there is already a 'Non-Builder' for the group, skip to step 13, else Click on "Add New Non-Builder Financial", this will open a new popup. Enter the below details and click save.
            if (!FinancialInputsService.IsExistsNonBuilderFinancial())
            {
                AddNewNonBuilderFinancial(Common.LblComment, "888666444333", false);
                Thread.Sleep(5000);
            }

            // 13. For the non builder, enter the value for 'Cash' = $255,000 for June-17 and $45,000 for June-116 under 'Balance Sheet >>Current Assets' and click save 
            FinancialInputsService.SetValueForFirstTextBoxBySectionName(SectionNameFinancialInputs.Cash, cashFirst, true, cashSecond);
            Thread.Sleep(2000);

            // 13.1. Click Save button
            FinancialInputsService.ClickSaveButtonBySectionName(SectionNameFinancialInputs.CurrentAssets);
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 14.Navigate to the financial output screen and click the group name at left side(TOP).verify at the group level, under BEAT adjusted calculations
            // --->the details are for the years: Sep 2019    Jun 2019    Jun 2018    Jun 2017
            // --->the field "Non-Builders ANTA" is displaying the value as $400, 000(will always take the year end value)
            var financialOutputUrl = GetFinancialOutputsUrl(cashFirst, string.Empty, lstYearMonthLabel);

            // 15. Navigate to the overall outcome screen and enter the details in Outcome Details for builder and click 'save' 
            builderPage.ClickButtonOverallOutcomeMenu();

            // If not navigate to Overall Outcome screen
            if (OverallOutcomeService.IsEnabledSaveOutcomeDetails())
            {
                builderPage.ClickButtonOverallOutcomeMenu();
            }
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 15.2. --> HBCF Approved Open Job Limit Value: 5,000,000, HBCF Approved Open Job Limit Number: 8
            OverallOutcomeService.SetHBCApprovedOpenJobLimitValueForGTA(Common.Value4);
            OverallOutcomeService.SetHBCApprovedOpenJobLimitNumberForGTA("8");

            // 15.3. Save
            OverallOutcomeService.ClickSaveOutcomeDetailsButton();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 16. Mark any existing conditions if available as "met"
            OverallOutcomeService.UpdateToMetIfIsNotMet();

            // 17. Navigate to group overall outcome screen
            builderPage.NavigateGroupOverallOutcomeScreen();

            // 17.1. Select the option under Accept or adjust outcome: Underwriter Assessment Outcome (provide notes below) - Approved Rating Z with no conditions.
            OverallOutcomeService.SetValueForUnderWriterAssessmentOutcomeDropDown(UnderwriterAssessmentOutcome.ApprovedRatingZNoConditions);
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 18. Select the DUA checkbox for Delegation Approval (Underwriter E delegation or higher required to finalise). 
            OverallOutcomeService.ClickDelegationApprovalCheckbox();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 19. Verify the "Offer Terms" button is enabled under 'Outcome Details' screen. Click the button - a popup will come up displaying "Offer Terms".
            if (!OverallOutcomeService.IsEnabledOfferTermsButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgDisabled, Common.OfferTermsButton));
            }

            // 19.2. Click the OfferTerms button
            OverallOutcomeService.ClickButtonOfferTermsForGTA();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 20. Click 'send'. On the screen, below message pops up - The email has been queued for sending by the email service. 
            ClickSendMailAndOkOfferTermsDialog();
            Thread.Sleep(3000);

            // Check still not click 'OK' button then click again
            if (!OverallOutcomeService.IsEnabledGroupOverallOutcomeScreen())
            {
                OverallOutcomeService.ClickOkOfferTermsEmailDialog();
            }

            // Navigate to group overall outcome screen
            builderPage.NavigateGroupOverallOutcomeScreen();

            // Check if navigate group Overall Outcome screen?
            if (!OverallOutcomeService.IsEnabledEligibilityAssessmentStatusDll())
            {
                builderPage.NavigateGroupOverallOutcomeScreen();
            }

            // 21. Select 'Terms Accepted' from 'Eligibility Assessment Status' and click "Save outcome details". Immediately the "Finalise Assessment" button is enabled. 
            OverallOutcomeService.SetValueEligibilityAssessmentStatusDll(EligibilityAssessmentStatus.TermsAccepted);
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 21.2. Click "Save outcome details".
            OverallOutcomeService.ClickSaveGroupOutcomeDetailsButtonForGTA();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 22. Verify the "Finalise Assessment " button is AVAILABLE. 
            if (!OverallOutcomeService.IsEnabledFinaliseAssessmentButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgDisabled, Common.FinaliseAssessmentButton));
            }

            // 22.2. Click the finalise button, Immediately "Generate Eligibility" button is ENABLED. 
            OverallOutcomeService.ClickFinaliseAssessmentButton();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 23. Click Generate Eligibility, this will take the user to the "Eligibility Details screen. 
            if (!OverallOutcomeService.IsEnabledGenerateEligibilityButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgEnabled, Common.GenerateEligibilityButton));
            }

            // 23.2. Click Generate Eligibility
            OverallOutcomeService.ClickGenerateEligibilityButton();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 23.3. Select the checkbox for 'Open Job Values checked? ' and then click -"Generate PDF Certificate of Eligibility" 
            EligibilityDetailsService.SetCheckBoxOpenJobValueCheck(true);

            // 23.4. Then click -"Generate PDF Certificate of Eligibility"
            EligibilityDetailsService.ClickGenerateCertificateOfEligibilityButton();
            Thread.Sleep(3000);

            // 24.Once the assessment is finalised , navigate back to the assessment and verify step 10 and step 14
            // 10. On the financial Inputs screen , validate the year ends available on the screen are: Sep 2019	Jun 2019	Jun 2018	Jun 2017
            builderPage.NavigateToUrl(financialInputUrl);
            if (!FinancialInputsService.CheckExistsValueYearEndMonth(lstYearMonthLabel))
            {
                Assert.Fail(string.Format(MessageCommon.MsgNotMatch, Common.P_L));
            }

            // Reverify step 14
            GetFinancialOutputsUrl(cashFirst, financialOutputUrl);
        }

        /// <summary>
        /// Get url and validate in Financial Outputs screen
        /// </summary>
        /// <param name="cash">Cash</param>
        /// <param name="financialOutputUrl">Url of Financial Outputs screen</param>
        /// <param name="valYearEndMonthLabel">Year end month label: 'DEC 2019 DEC 2018 ...'</param>
        /// <returns></returns>
        private string GetFinancialOutputsUrl(string cash, string financialOutputUrl = "", string valYearEndMonthLabel = "")
        {
            // 14.Navigate to the financial output screen and click the group name at left side(TOP).verify at the group level, under BEAT adjusted calculations
            // --->the details are for the years: Sep 2019    Jun 2019    Jun 2018    Jun 2017
            // --->the field "Non-Builders ANTA" is displaying the value as $400, 000(will always take the year end value)
            if (string.IsNullOrEmpty(financialOutputUrl))
            {
                builderPage.ClickButtonFinancialOutputsMenu();
            }
            else
            {
                builderPage.NavigateToUrl(financialOutputUrl);
            }
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // Get Financial Output url
            var urlCurrent = builderPage.GetUrlCurrent();

            // 14.1. Navigate to group overall outcome screen
            builderPage.NavigateGroupOverallOutcomeScreen();

            // 14.2. Check the details are for the years label
            if (!FinancialOutputsService.CheckExistsValueYearEndMonth(valYearEndMonthLabel))
            {
                Assert.Fail(string.Format(MessageCommon.MsgNotMatch, Common.BEATAdjustedCalculatioins));
            }

            //// 14.3. ??? The field "Non-Builders ANTA" is displaying the value as $400, 000(will always take the year end value)
            //var valNonBuilderANTA = FinancialOutputsService.GetValueOfNonBuildersANTALabel().Replace("$", "");
            //if (valNonBuilderANTA.Replace(",", "") != cash)
            //{
            //    Assert.Fail(string.Format(MessageCommon.MsgNotMatch, Common.LblNonBuildersANTA));
            //}

            return urlCurrent;
        }

        /// <summary>
        /// Update Year End Month dropdown
        /// </summary>
        /// <param name="licenceNumber">Licence Number</param>
        /// <param name="yearEndMonth">Value of Year End Month dropdown</param>
        private void UpdateYearEndMonthDropdown(string licenceNumber, string yearEndMonth, int yemByTicket)
        {
            // Get value selected Year End Month old
            var yearEndMonthOld = BuilderDetailsService.GetValueSelectedYearEndMonth();

            // Redirect to Login page
            GoToLoginPage();
            Thread.Sleep(3000);

            // 2.2. If it is not "December", login as hbcf user and update the dropdown value to December and click 'save builder details'. If the year end is already set to December, skip to step 4.
            var loginPage = new LoginPage(driver);
            loginPage.Login(MemberInfo.Username2, MemberInfo.Password2);

            // Search
            GoToSearchBeat();
            Thread.Sleep(1000);

            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();
            Thread.Sleep(1000);

            // Search with licence number
            if (!builderPage.ResultSearch())
            {
                Assert.Fail(MessageCommon.MsgNotRecord);
            }

            // Click the orange button to navigate to the builder details screen
            builderPage.ClickViewBuilder();

            // 2.3. Update the dropdown value to December
            BuilderDetailsService.SetValueForYearEndMonthDll(yearEndMonth);
            Thread.Sleep(1000);

            // 2.4. Click 'save builder details'
            BuilderDetailsService.ClickBuiderDetailSaveButton();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(5000);

            //3.If the "Year Month End" is updated , verify the key event has logged the change: 
            //Description : Builder was updated with new Year End.
            //Created By : CSCTestC
            //Event Data : Year End for ****Builder Name *** was changed by*** CSCTestC**** from* prior month name* to December
            var eventData = string.Format(Common.LblEventData, BuilderDetailsService.GetBuilderName(), MemberInfo.Username2, yearEndMonthOld, yearEndMonth);

            if (!BuilderDetailsService.IsExistsDataInKeyEventLog(Common.LblDescriptionKeyEventLog, MemberInfo.Username2, eventData))
            {
                Assert.Fail(string.Format(MessageCommon.MsgNotMatch, Common.LblKeyEventLog));
            }
        }

        /// <summary>
        /// Proccessing from step 15 to step 24
        /// Apply for: #4740, 4743
        /// </summary>
        /// <param name="financialInputUrl"></param>
        private void ProccessingOverallOutcome(string financialInputUrl, string yearEndMonth)
        {
            // 15. Navigate to the overall screen and enter the details in Outcome Details for builder and click 'save'
            builderPage.ClickButtonOverallOutcomeMenu();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 15.2. --> HBCF Approved Open Job Limit Value: 5,000,000, HBCF Approved Open Job Limit Number: 8
            //builderPage.SetValueForHBCFOpenJobLimit(Common.Value4, "800");
            OverallOutcomeService.SetHBCApprovedOpenJobLimitValueForGTA(Common.Value4);
            OverallOutcomeService.SetHBCApprovedOpenJobLimitNumberForGTA("8");

            // 15.3. Save
            OverallOutcomeService.ClickSaveOutcomeDetailsButton();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 16. Mark any existing conditions if available as "met"
            OverallOutcomeService.UpdateToMetIfIsNotMet();

            // 17. Navigate to group overall outcome screen
            builderPage.NavigateGroupOverallOutcomeScreen();

            // 17.1. Select the option under Accept or adjust outcome: Underwriter Assessment Outcome (provide notes below) - Approved Rating Z with no conditions.
            OverallOutcomeService.SetValueForUnderWriterAssessmentOutcomeDropDown(UnderwriterAssessmentOutcome.ApprovedRatingZNoConditions);
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 18. Select the DUA checkbox for Delegation Approval (Underwriter E delegation or higher required to finalise). 
            OverallOutcomeService.ClickDelegationApprovalCheckbox();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 19. Verify the "Offer Terms" button is enabled under 'Outcome Details' screen. Click the button - a popup will come up displaying "Offer Terms".
            if (!OverallOutcomeService.IsEnabledOfferTermsButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgDisabled, Common.OfferTermsButton));
            }

            // 19.2. Click the OfferTerms button
            OverallOutcomeService.ClickButtonOfferTermsForGTA();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 20. Click 'send'. On the screen, below message pops up - The email has been queued for sending by the email service. 
            ClickSendMailAndOkOfferTermsDialog();
            Thread.Sleep(5000);

            // Navigate to group overall outcome screen
            builderPage.NavigateGroupOverallOutcomeScreen();

            // 21. Select 'Terms Accepted' from 'Eligibility Assessment Status' and click "Save outcome details". Immediately the "Finalise Assessment" button is enabled. 
            OverallOutcomeService.SetValueEligibilityAssessmentStatusDll(EligibilityAssessmentStatus.TermsAccepted);
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 21.2. Click "Save outcome details".
            OverallOutcomeService.ClickSaveGroupOutcomeDetailsButtonForGTA();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 22. Verify the "Finalise Assessment " button is AVAILABLE. 
            if (!OverallOutcomeService.IsEnabledFinaliseAssessmentButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgDisabled, Common.FinaliseAssessmentButton));
            }

            // 22.2. Click the finalise button, Immediately "Generate Eligibility" button is ENABLED. 
            OverallOutcomeService.ClickFinaliseAssessmentButton();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 23. Click Generate Eligibility, this will take the user to the "Eligibility Details screen. 
            if (!OverallOutcomeService.IsEnabledGenerateEligibilityButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgEnabled, Common.GenerateEligibilityButton));
            }

            // 23.2. Click Generate Eligibility
            OverallOutcomeService.ClickGenerateEligibilityButton();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 23.3. Select the checkbox for 'Open Job Values checked? ' and then click -"Generate PDF Certificate of Eligibility" 
            EligibilityDetailsService.SetCheckBoxOpenJobValueCheck(true);

            // 23.4. Then click -"Generate PDF Certificate of Eligibility"
            EligibilityDetailsService.ClickGenerateCertificateOfEligibilityButton();
            Thread.Sleep(3000);

            // 24.Once the assessment is finalised , navigate back to the assessment and verify step 10 and step
            // 10. On the financial Inputs screen , validate the year ends available on the screen are: Jun - 19 Jun - 18   Jun - 17 Jun - 16
            builderPage.NavigateToUrl(financialInputUrl);
            var lstYearEndMonth = string.Empty;
            switch (yearEndMonth)
            {
                case YearEndMonth.June:
                    lstYearEndMonth = Common.ListYearMonthJune;
                    break;
                case YearEndMonth.December:
                    lstYearEndMonth = Common.ListYearMonthDec;
                    break;
            }
            if (!FinancialInputsService.CheckExistsValueYearEndMonth(lstYearEndMonth))
            {
                Assert.Fail(string.Format(MessageCommon.MsgNotMatch, Common.P_L));
            }
        }

        /// <summary>
        /// Add New Non Builder Financial and save
        /// </summary>
        /// <param name="entityName">Entity Name</param>
        /// <param name="abnNumber">ABN Number</param>
        /// <param name="isDelete">True if exists ABN Number, otherwise False</param>
        private void AddNewNonBuilderFinancial(string entityName, string abnNumber, bool isDelete = true)
        {
            if (isDelete)
            {
                // Check exists ABN number then delete this and then add its
                FinancialInputsService.DeleteNonBuildersByABNNumber(abnNumber);
            }

            // Click Add New Non Builder Financial button
            FinancialInputsService.ClickAddNewNonBuilderFinancial();

            // Set value for Entity Name
            FinancialInputsService.SetValueForEntityNameInDialog(entityName);
            Thread.Sleep(1000);

            // Set value for ABN
            FinancialInputsService.SetValueForABNInDialog(abnNumber);
            Thread.Sleep(1000);

            // Save
            FinancialInputsService.ClickSaveButtonCreateNonBuilderEntityDialog();
        }

        /// <summary>
        /// Save in Initiate Review screen
        /// </summary>
        private void SaveInitiateReview(string financialYear, string assessmentType, string comment)
        {
            if (!string.IsNullOrEmpty(financialYear))
            {
                // Financial year being assessed = '2019' 
                InitiateReviewService.SetValueForFinancialYearDDL(financialYear);
                Thread.Sleep(1000);
            }

            if (!string.IsNullOrEmpty(assessmentType))
            {
                // Assessment Type 
                InitiateReviewService.SetValueForAssessmentTypeDLL(assessmentType);
                Thread.Sleep(1000);
            }

            if (!string.IsNullOrEmpty(comment))
            {
                // Comment
                InitiateReviewService.SetValueCommentTxt(comment);
                Thread.Sleep(1000);
            }

            // Click 'Save' button
            InitiateReviewService.ClickSaveButtonInitiateReview();
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Save Eligibility Details screen
        /// </summary>
        private void SaveEligibilityDetails()
        {
            // Click the Eligibility Details menu item to navigate to the 'Eligibility Details' screen
            builderPage.ClickEligibilityDetails();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // Click "copy all" below "Requested/Projected $".
            EligibilityDetailsService.ClickCopyAllLimitsLink();
            builderPage.WaitTillBusyDialogClose();

            if (!string.IsNullOrEmpty(builderPage.GetValueHwJobLimitValueTxt()))
            {
                // NSW Open Job Limit Value = 500,000 
                EligibilityDetailsService.SetValueHwJobLimitValueTxt(Common.Value1);

                // NSW Open Job Limit Number = 5 
                EligibilityDetailsService.SetValueHwJobLimitNumberTxt(Common.Value2);

                // HBCF Insurance in other States = 0
                EligibilityDetailsService.SetValueHwInsuranceOtherStatesTxt(Common.Value3);

                // Non HBCF Insurance Income = 0
                EligibilityDetailsService.SetValueNonHomeInsuranceTxt(Common.Value3);

                // New single dwelling construction =200,000
                EligibilityDetailsService.SetValueFinancialLimits_txtC01(Common.Value4);
                Thread.Sleep(3000);
            }
            else if (string.IsNullOrEmpty(EligibilityDetailsService.GetValueFinancialLimits_txtC01()))
            {
                builderPage.ClickButtonFinancialInputsMenu();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(3000);
            }

            // Click the 'save' button first and then click 'begin assessment button' 
            EligibilityDetailsService.ClickButtonSaveEligibilityReview();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(5000);
        }

        /// <summary>
        /// Check and input value in Track Record screen
        /// </summary>
        private void SaveTrackRecord()
        {
            var isTrackRecordScreen = false;
            if (EligibilityDetailsService.VerifyBeginAssessmentIsEnabled())
            {
                EligibilityDetailsService.ClickBeginAssessment();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(3000);

                isTrackRecordScreen = true;
            }

            // 7. Verify the 'track record' menu item is enabled.
            if (!builderPage.IsTrackRecordEnable())
            {
                Assert.Fail(string.Format(MessageCommon.MsgDisabled, Common.TrackRecordMenu));
                return;
            }

            if (!isTrackRecordScreen)
            {
                // Navigate to Track Record screen
                builderPage.ClickMenuTrackRecord();
                builderPage.WaitTillBusyDialogClose();
            }

            // Check has not value then input
            if (!TrackRecordService.CheckExistsValueInTradingStructureInput(TradingStructure.Company))
            {
                // Enter the below values here
                SetValueForTrackRecordScreen(TradingStructure.Company, YearsTrading.Greater10Years, YearsTrading.Greater10Years
                , AdverseHistory.CleanHistory, TradeCreditHistory.CleanHistory, DirectorsProfile.CleanHistory, PastBusinessClosures.NoPrevious);
            }
            else
            {
                // Navigate to Financial Inputs screen
                builderPage.ClickButtonFinancialInputsMenu();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(3000);
            }
        }

        /// <summary>
        /// 4730-Verify the 'Offer Terms' button is available for NEW Assessments (UW-Approved, Broker-Declined, OJV/OJN-0/0
        /// 4729-Verify the 'Offer Terms' button is available for NEW Assessments(UW-Approved, Broker-Accepted, OJV/OJN-0/0
        /// </summary>
        /// <param name="eligibilityAssessmentStatus">Eligibility Assessment status</param>
        public void VerifyOfferTermsUW_Approved_Zero_ByEligibilityAssessment(string eligibilityAssessmentStatus)
        {
            InitLoginToOverallOutcomeScreen();

            // 9.2 HBCF Approved Open Job Limit Value: 0
            // 9.3 HBCF Approved Open Job Limit Number: 0 
            builderPage.SetValueForHBCFOpenJobLimit(Common.Value3, Common.Value3);

            // 10. Select the option under Accept or adjust outcome: Underwriter Assessment Outcome (provide notes below) - Approved Rating Z with no conditions 
            builderPage.SetValueForUnderWriterAssessmentOutcomeDropDown(UnderwriterAssessmentOutcome.ApprovedRatingZNoConditions);
            builderPage.WaitTillBusyDialogClose();

            // 11. Select the DUA checkbox for Delegation Approval (Underwriter E delegation or higher required to finalise). 
            if (!builderPage.IsDelegationApprovalCheckboxChecked())
            {
                builderPage.ClickDelegationApprovalCheckbox();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(3000);
            }

            // 12. Verify the button - "Generate Eligibility" button is still disabled. 
            if (builderPage.IsEnabledGenerateEligibilityButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgEnabled, Common.GenerateEligibilityButton));
            }

            // 13.1. Select 'Terms Accepted' from 'Eligibility Assessment Status' field drop-down available in 'Outcome Details' subsection on Overall outcome screen 
            OverallOutcomeService.SetValueEligibilityAssessmentStatusDll(eligibilityAssessmentStatus);
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 13.2. Click "Save outcome details" 
            builderPage.ClickSaveOutcomeDetailsButton();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 14.1. Verify the "Offer Terms" button is enabled under 'Outcome Details' screen. 
            if (!builderPage.IsEnabledOfferTermsButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgDisabled, Common.OfferTermsButton));
            }

            // 14.2 & 15. Click 'send'. On the screen, below message pops up - The email has been queued for sending by the email service. 
            ClickOfferTermsButtonAndSendMail();

            // 16.Verify the " Next Planned Eligibility Review Date" is blank.
            if (!builderPage.IsBlankNextPlanedReviewDate())
            {
                Assert.Fail(string.Format(MessageCommon.MsgBlank, Common.NextPlanedReviewDate));
            }

            // 17.1. Verify the "Finalise Assessment " button is NOT available. 
            if (OverallOutcomeService.IsEnabledFinaliseAssessmentButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgDisabled, Common.FinaliseAssessmentButton));
            }

            // 17.2. Since the user cannot click the finalise button, "Generate Eligibility" button also remains DISABLED. 
            if (OverallOutcomeService.IsEnabledGenerateEligibilityButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgEnabled, Common.GenerateEligibilityButton));
            } 
        }

        /// <summary>
        /// 4727 Verify the 'Offer Terms' button is available for NEW Assessments (UW-Declined, Broker-Terms Accepted, OJV/OJN > 0/0)
        /// 4728 Verify the 'Offer Terms' button is available for NEW Assessments (UW-Declined, Broker-Declined, OJV/OJN > 0/0
        /// </summary>
        /// <param name="ojv"></param>
        /// <param name="ojn"></param>
        /// <param name="eligibilityAssessmentStatus"></param>
        private void VerifyOfferTermsButton_UW_Declined_By_OpenJobAndEAStatus(string ojv, string ojn, string eligibilityAssessmentStatus)
        {
            InitLoginToOverallOutcomeScreen();

            // 9.2 HBCF Approved Open Job Limit Value: 2000000
            // 9.3 HBCF Approved Open Job Limit Number: 5
            builderPage.SetValueForHBCFOpenJobLimit(ojv, ojn);

            // 10. Select the option under Accept or adjust outcome: Underwriter Assessment Outcome (provide notes below) - Declined 
            builderPage.SetValueForUnderWriterAssessmentOutcomeDropDown(UnderwriterAssessmentOutcome.Declined);
            builderPage.WaitTillBusyDialogClose();

            // 11. Select the DUA checkbox for Delegation Approval (Underwriter E delegation or higher required to finalise). 
            if (!builderPage.IsDelegationApprovalCheckboxChecked())
            {
                builderPage.ClickDelegationApprovalCheckbox();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(3000);
            }

            // 12. Verify the button - "Generate Eligibility" button is still disabled.
            if (builderPage.IsEnabledGenerateEligibilityButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgEnabled, Common.GenerateEligibilityButton));
            }

            // 13. Select 'Terms Accepted' from 'Eligibility Assessment Status' field drop-down 
            builderPage.SetValueEligibilityAssessmentStatusDll(eligibilityAssessmentStatus);

            // 13.2. Click "Save outcome details" on the 'Outcome Details' subsection.
            builderPage.ClickSaveOutcomeDetailsButton();
            Thread.Sleep(3000);
            builderPage.WaitTillBusyDialogClose();

            // 14. Verify the "Offer Terms" button is enabled under 'Outcome Details' screen.
            if (!builderPage.IsEnabledOfferTermsButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgDisabled, Common.OfferTermsButton));
            }

            // 14.2 & 15. Click 'send'. On the screen, below message pops up - The email has been queued for sending by the email service. 
            ClickOfferTermsButtonAndSendMail();

            // 16. Verify the " Next Planned Eligibility Review Date" is blank. 
            if (!builderPage.IsBlankNextPlanedReviewDate())
            {
                Assert.Fail(string.Format(MessageCommon.MsgBlank, Common.NextPlanedReviewDate));
            }

            // 17.1. Verify the 'Finalise assessment' button is NOT available.
            if (builderPage.IsEnabledFinaliseAssessmentButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgDisabled, Common.FinaliseAssessmentButton));
            }

            // 17.2. Since the user cannot click the finalise button, "Generate Eligibility" button also remains DISABLED.
            if (builderPage.IsEnabledGenerateEligibilityButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgEnabled, Common.GenerateEligibilityButton));
            }
        }

        /// <summary>
        /// 4726-Verify the 'Offer Terms' button is available for NEW Assessments (UW-Declined, Broker-Terms Accepted, OJV/OJN-0/0
        /// 4725-Verify the 'Offer Terms' button is available for NEW Assessments(UW-Declined, Broker-Declined, OJV/OJN-0/0
        /// </summary>
        /// <param name="eligibilityAssessmentStatus"></param>
        public void VerifyOfferTermsUW_DeclinedByEligibilityAssessment(string eligibilityAssessmentStatus)
        {
            InitLoginToOverallOutcomeScreen();

            // 9.2 HBCF Approved Open Job Limit Value: 0
            // 9.3 HBCF Approved Open Job Limit Number: 0 
            builderPage.SetValueForHBCFOpenJobLimit(Common.Value3, Common.Value3);

            // 10. Select the option under Accept or adjust outcome: Underwriter Assessment Outcome (provide notes below) - Declined 
            builderPage.SetValueForUnderWriterAssessmentOutcomeDropDown(UnderwriterAssessmentOutcome.Declined);
            builderPage.WaitTillBusyDialogClose();

            // 11. Select the DUA checkbox for Delegation Approval (Underwriter E delegation or higher required to finalise). 
            if (!builderPage.IsDelegationApprovalCheckboxChecked())
            {
                builderPage.ClickDelegationApprovalCheckbox();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(3000);
            }

            // 12. Verify the "Offer Terms" button is enabled under 'Outcome Details' screen.
            if (!builderPage.IsEnabledOfferTermsButton())
            {
                Assert.Fail(string.Format(MessageCommon.MsgDisabled, Common.OfferTermsButton));
            }
            else
            {
                // 12.2 & 13. Click 'send'. On the screen, below message pops up - The email has been queued for sending by the email service. 
                ClickOfferTermsButtonAndSendMail();

                // 14. verify the buttion - "Generate Eligibility" button is still disabled.
                if (OverallOutcomeService.IsEnabledGenerateEligibilityButton())
                {
                    Assert.Fail(string.Format(MessageCommon.MsgEnabled, Common.GenerateEligibilityButton));
                }
                else
                {
                    // 15.1. Select 'DECLINED' from 'Eligibility Assessment Status' field drop-down available in 'Outcome Details' subsection on Overall outcome screen
                    OverallOutcomeService.SetValueEligibilityAssessmentStatusDll(eligibilityAssessmentStatus);

                    // 15.2. Click "Save outcome details"
                    OverallOutcomeService.ClickSaveOutcomeDetailsButton();
                    Thread.Sleep(3000);
                    builderPage.WaitTillBusyDialogClose();

                    // 16. Verify the " Next Planned Eligibility Review Date" is blank.
                    if (!builderPage.IsBlankNextPlanedReviewDate())
                    {
                        Assert.Fail(string.Format(MessageCommon.MsgBlank, Common.NextPlanedReviewDate));
                    }

                    // 17.1. Verify the "FINALISE ASSESSMENT" button is available.
                    if (!OverallOutcomeService.IsEnabledFinaliseAssessmentButton())
                    {
                        Assert.Fail(string.Format(MessageCommon.MsgDisabled, Common.FinaliseAssessmentButton));
                    }

                    // 17.2. Now click on the 'Finalise assessment' button.
                    OverallOutcomeService.ClickFinaliseAssessmentButton();
                    builderPage.WaitTillBusyDialogClose();
                    Thread.Sleep(3000);

                    // 17.3. Once clicked verify the button - "Generate Eligibility" button is still DISABLED.
                    if (OverallOutcomeService.IsEnabledGenerateEligibilityButton())
                    {
                        Assert.Fail(string.Format(MessageCommon.MsgEnabled, Common.GenerateEligibilityButton));
                    }

                    return;
                }
            }

            // Testing faild
            Assert.Fail();
        }

        /// <summary>
        /// Click Offer Terms button and send mail
        /// </summary>
        private void ClickOfferTermsButtonAndSendMail()
        {
            // Click the button - a popup will come up displaying "Offer Terms". 
            OverallOutcomeService.ClickButtonOfferTerms();
            builderPage.WaitTillRenderingTemplateDialogClose();
            Thread.Sleep(3000);

            // Send mail and then click OK button
            ClickSendMailAndOkOfferTermsDialog();
        }

        /// <summary>
        /// Click Send button and OK in Offer Terms dialog
        /// </summary>
        private void ClickSendMailAndOkOfferTermsDialog()
        {
            // Click 'send'. 
            OverallOutcomeService.ClickSendOfferTermsButton();
            //builderPage.WaitTillQueueingEmailDialogClose();
            Thread.Sleep(10000);

            // On the screen, below message pops up - The email has been queued for sending by the email service. 
            OverallOutcomeService.ClickOkOfferTermsEmailDialog();
        }
        
        /// <summary>
        /// Init from login to Overall Outcome sreen
        /// Apply for: #4725, #4726, #4727, #4728, #4729, #4730, #4731, #4732
        /// </summary>
        private void InitLoginToOverallOutcomeScreen()
        {
            // 1. Login
            InitLogin();

            // Search with licence number
            if (!builderPage.ResultSearch())
            {
                Assert.Fail(MessageCommon.MsgNotRecord);
            }

            // 2. Click on the blue tick to the left of the builder name 
            builderPage.ClickViewAssessments();

            // 3. In the assessments table - click the "Begin New Assessment" OR click "edit" link for the assessment where EA finalised = No.
            // Check exists row with EA Finalised = No then edit that row else add new Assessement
            if (builderPage.GetColTextOfAssessmentTable(1, 11).Contains(Common.NO))
            {
                // 3. In the assessments table - click the edit link for the assessment where EA finalised = No 
                builderPage.ClickEditLinkAssessment();
                builderPage.WaitTillBusyDialogClose();
            }
            else
            {
                // 3.1. Click 'Add New Assessment' button
                if (builderPage.IsEnabledAddNewAssessmentButton())
                {
                    builderPage.ClickAddNewAssessmentButton();
                }
                else
                {
                    Assert.Fail(string.Format(MessageCommon.MsgNotExist, Common.AddNewAssessmentButton));
                }
            }

            // 4.1. Financial year being assessed = '2019' 
            builderPage.SetValueForFinancialYearDDL(FinancialYearDDL.Year2019);

            // 4.2. Assessment Type = NEW 
            builderPage.SetValueForAssessmentTypeDLL(AssessmentTypeDLL.New);

            // 4.3. Comment = current date is 28 October,2019 
            builderPage.SetValueCommentTxt(DateTime.Now.ToString());

            // 4.4. Click 'Save' button
            builderPage.ClickSaveButtonInitiateReview();

            // 5. Click the Eligibility Details menu item to navigate to the 'Eligibility Details' screen
            builderPage.ClickEligibilityDetails();
            builderPage.WaitTillBusyDialogClose();

            // 5.1. Click "copy all" below "Requested/Projected $".
            builderPage.ClickCopyAllLimitsLink();
            builderPage.WaitTillBusyDialogClose();

            // 5.2. NSW Open Job Limit Value = 500,000 
            builderPage.SetValueHwJobLimitValueTxt(Common.Value1);

            // 5.3. NSW Open Job Limit Number = 5 
            builderPage.SetValueHwJobLimitNumberTxt(Common.Value2);

            // 5.4. HBCF Insurance in other States = 0
            builderPage.SetValueHwInsuranceOtherStatesTxt(Common.Value3);

            // 5.5. Non HBCF Insurance Income = 0
            builderPage.SetValueNonHomeInsuranceTxt(Common.Value3);

            // 5.6. New single dwelling construction =200,000
            builderPage.SetValueFinancialLimits_txtC01(Common.Value4);
            Thread.Sleep(3000);

            // 6. Click the 'save' button first and then click 'begin assessment button' 
            builderPage.ClickButtonSaveEligibilityReview();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(13000);
            var isTrackRecordScreen = false;
            if (builderPage.VerifyBeginAssessmentIsEnabled())
            {
                builderPage.ClickBeginAssessment();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(3000);

                isTrackRecordScreen = true;
            }

            // 7. Verify the 'track record' menu item is enabled.
            if (!builderPage.IsTrackRecordEnable())
            {
                Assert.Fail(string.Format(MessageCommon.MsgDisabled, Common.TrackRecordMenu));
                return;
            }

            if (!isTrackRecordScreen)
            {
                // Navigate to Track Record screen
                builderPage.ClickMenuTrackRecord();
                builderPage.WaitTillBusyDialogClose();
            }

            // Enter the below values here
            SetValueForTrackRecordScreen(TradingStructure.Company, YearsTrading.Greater10Years, YearsTrading.Greater10Years
                , AdverseHistory.CleanHistory, TradeCreditHistory.CleanHistory, DirectorsProfile.CleanHistory, PastBusinessClosures.NoPrevious);

            // 8. On the financial Inputs screen , enter below values and click save: 
            builderPage.ClickButtonFinancialInputsMenu();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);

            // 8.2. Enter value 'Sales' and 'Opening Stock'
            builderPage.SetValueSalesRow(Common.SalesRow);
            builderPage.SetValueOpeningStock(Common.OpeningStock);

            // 8.3. Click 'Save' button
            builderPage.ClickSaleSaveButton();
            builderPage.WaitTillBusyDialogClose();

            // 9. Navigate to the overall screen and enter the below details in Outcome Details and click 'save' 
            builderPage.ClickButtonOverallOutcomeMenu();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Set value for controls of Track Record screen
        /// </summary>
        /// <param name="tradingStructure">Trading Structure</param>
        /// <param name="entityResidential">Entity's residential building licence held</param>
        /// <param name="principal">Principal's residential building licence held</param>
        /// <param name="signs">Signs of Adverse History (consider builder size and trading history)</param>
        /// <param name="currentTrade">Current Trade Credit Position</param>
        /// <param name="director">Director's / Principals Licence History</param>
        /// <param name="pastBusiness">Past business closures</param>
        private void SetValueForTrackRecordScreen(string tradingStructure, string entityResidential, string principal, string signs
            , string currentTrade, string director, string pastBusiness)
        {
            // 7.1. Trading Structure
            TrackRecordService.SetTradingStructureInput(tradingStructure);
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(2000);

            // 7.2. Entity's residential building licence held
            TrackRecordService.SetEntityResidentialBuildingLicenceHeld(entityResidential);
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(2000);

            // 7.3. Principal's residential building licence held
            TrackRecordService.SetPrincipalResidentialBuildingLicenceHeldInput(principal);
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(2000);

            // 7.4. Signs of Adverse History(consider builder size and trading history) 
            TrackRecordService.SetSignsOfAdverseHistoryInput(signs);
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(2000);

            // 7.5. Current Trade Credit Position
            TrackRecordService.SetCurrentTradeCreditPositionInput(currentTrade);
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(2000);

            // 7.6. Director's / Principals Licence History
            TrackRecordService.SetDirectorPrincipalsLicenceHistoryInput(director);
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(2000);

            // 7.7. Past business closures
            TrackRecordService.SetPastBusinessClosuresInput(pastBusiness);
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Change last 2 digits
        /// </summary>
        /// <param name="number"></param>
        private void ChangeLastTwoDigits(ref string number)
        {
            if (string.IsNullOrEmpty(number)) return;
            string lastTwoDigit = number.Substring(number.Length - 2);
            number = number.Remove(number.Length - 2, 2) + (lastTwoDigit != "99" ? "99" : "88");
        }

        /// <summary>
        /// Add new DOI
        /// </summary>
        /// <param name="typeDOI"></param>
        private void AddNewDoi(string typeDOI)
        {
            // Click Add button
            builderPage.ClickButtonAddNewDOI();

            // Select option value by type of DOI
            builderPage.SetValueDoiTypeId(typeDOI);
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Add new Indemnitifier
        /// </summary>
        private void AddNewIndemnifier()
        {
            builderPage.ClickAddIndemnifierButton();
            builderPage.ClickCompanyRadioButton(); // Type - Company 
            builderPage.SetValueNameInput(DeedIndemnityValue.Name); // Name - Lodestone Solutions
            builderPage.SetValueABNInput(DeedIndemnityValue.ABNNumber); // ABN - 12345678912
            builderPage.SetValueAddressInput(DeedIndemnityValue.Address); // Address : 17 Alberta Street
            builderPage.SetValueStateSelect(IndemnityState.NewSouthWales); // State - New South wales
            builderPage.SetValuePostCodeInputIndemnifier(DeedIndemnityValue.PostCode); // Postcode -2000
            Thread.Sleep(2000);
            builderPage.ClickButtonOkAddIndemnifier();
            builderPage.WaitTillBusyDialogClose();
        }

        /// <summary>
        /// Checking result when email sent to Broker
        /// </summary>
        /// <param name="assignedTo">Assigned to Broker or Insurer</param>
        /// <param name="actionRequiredBy">Action requered by Broker or Insurer</param>
        private void CheckResultVerifyEmailSentToBroker(string assignedTo, string actionRequiredBy)
        {
            // Navigate "Builder Detail" screen
            builderPage.ClickBuilderDetailMenuButton();
            builderPage.WaitTillBusyDialogClose();

            // Now Verify the key event on builder summary screen
            // Description : PER informtion screen submitted to ... 
            var isTrue = builderPage.VerifyValueOfColumnInKeyEventLogs(1, 0, assignedTo);
            Assert.IsTrue(isTrue);

            // Event Data : Action required by: ...
            isTrue = builderPage.VerifyValueOfColumnInKeyEventLogs(1, 2, actionRequiredBy);
            Assert.IsTrue(isTrue);

            // Verify email has gone through, check the logs:email reminder has been sent..... 
            isTrue = builderPage.VerifyValueOfColumnInKeyEventLogs(2, 0, Common.EmailSent);
            Assert.IsTrue(isTrue);
        }

        /// <summary>
        /// Initialize login and search builder
        /// </summary>
        /// <param name="licenceNumber">Licence number</param>
        private void InitLogin(string licenceNumber = Common.LicenceNumber)
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login(MemberInfo.Username, MemberInfo.Password);

            GoToSearchBeat();

            builderPage.SetBuilderLicenceNumber(licenceNumber);
            builderPage.ClickSearchBuilder();
        }

        /// <summary>
        /// Add new Deeds of indemnity with some types
        /// </summary>
        /// <param name="typeDOI">Type of DOI</param>
        private void AddNewDOIWithType(string typeDOI)
        {
            // 9.2. Click 'Add new DOI' button
            // 10. Select the dropdown type 'Job Specific Deed'
            AddNewDoi(typeDOI);
            
            // 11. Enter all relevent details
            switch (typeDOI)
            {
                // Job Specific Deed and Irregular Contracting Deed
                case DeedIndemnityType.JobSpecificDeed:
                case DeedIndemnityType.IrregularContractingDeed:
                    builderPage.CheckValueMaxAmout(DeedIndemnityValue.MaxValue); // Max Amount - 65000
                    builderPage.SetValuePolicyNumberInput(DeedIndemnityValue.PolicyNumber); // PolicyNumber - HBCF102030
                    builderPage.SetValueLotStreetNoInput(DeedIndemnityValue.LotStreetNo); // Lot/Street No- 321 Kent
                    builderPage.SetStreetNameInput(DeedIndemnityValue.StreetName); // Street Name - Street
                    builderPage.SetValueSuburbInput(DeedIndemnityValue.Suburb); // Suburb - Sydney
                    builderPage.SetValuePostCodeInput(DeedIndemnityValue.PostCode); // Post Code -2000
                    break;
                // Deed of Indemnity
                case DeedIndemnityType.DeedOfIndemnity:
                    builderPage.CheckValueMaxAmout(DeedIndemnityValue.MaxValue); // Max Amount - 65000
                    break;
            }

            // 12. Click 'Add' button below indemnity
            AddNewIndemnifier();

            // 13. Click 'OK' button
            builderPage.ClickButtonOkNewDeedOfIndemninty();
            builderPage.WaitTillSaveDeedOfIndemnityDialogClose();
            Thread.Sleep(2000);
        }

        private string CreateTextFile()
        {
            var guid = Guid.NewGuid().ToString();
            var path = filePath + guid + ".txt";
            if (!File.Exists(path))
            {
                //File.Create(path);
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine("The next line!");
                }
            }

            return guid + ".txt";
        }

        private void GoToSearchBeat()
        {
            driver.Navigate().GoToUrl("http://portal-uat.hbcf.nsw.gov.au/portal/server.pt/gateway/PTARGS_0_0_352_0_0_43/http%3B/portal-app/Beat/SearchBeat.aspx");
        }

        private void GoToLoginPage()
        {
            driver.Navigate().GoToUrl("https://portal-uat.hbcf.nsw.gov.au/portal/server.pt?open=space&name=Login&control=Login&login=&in_hi_userid=953&cached=true");
        }

        private void FinaliseAssessment()
        {
            builderPage.ClickEligibilityDetails();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(5000);
            builderPage.ClickCopyAllLimitsLink();
            Thread.Sleep(1000);
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(2000);
            builderPage.ClickButtonSaveEligibilityReview();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(1000);
            builderPage.ClickBeginAssessment();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(1000);
            builderPage.ClickButtonFinancialInputsMenu();
            builderPage.SetValueSalesRow("5000000");
            Thread.Sleep(1000);
            builderPage.SetValueOpeningStock("250000");
            Thread.Sleep(1000);
            builderPage.ClickSaleSaveButton();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(1000);
            builderPage.ClickButtonOverallOutcomeMenu();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(2000);
            builderPage.SetValueAssessmentStatus("Pending");
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(1000);
            if (builderPage.IsDelegationApprovalCheckboxChecked())
            {
                builderPage.ClickDelegationApprovalCheckbox();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
            }
            builderPage.ClearRecuringConditionForAssessment();
            Thread.Sleep(1000);
            if (builderPage.IsCheckedAreThereAnyConditionCheckbox())
            {
                builderPage.ClickAreThereConditionCheckbox();
                builderPage.WaitTillBusyDialogClose();
                Thread.Sleep(1000);
            }
            builderPage.SetValueForHBCFOpenJobLimit("5000000", "35");
            Thread.Sleep(1000);
            builderPage.ClickSaveOutcomeDetailsButton();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(1000);
            builderPage.ClickOkValidationDialog();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(1000);
            builderPage.ClickDelegationApprovalCheckbox();
            if (builderPage.VerifyValidationDialogOpen())
            {
                builderPage.ClickCloseButtonValidationDialog();
            }
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(1000);
            builderPage.ClickOkValidationDialog();
            Thread.Sleep(1000);
            builderPage.SetValueDateTermsOffered(DateTime.Now.AddHours(3).ToString("dd/MM/yyyy"));
            Thread.Sleep(1000);
            builderPage.SetValueAssessmentStatus(EligibilityAssessmentStatus.TermsAccepted);
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(1000);
            builderPage.ClickFinaliseAssessmentButton();
            builderPage.WaitTillBusyDialogClose();
            Thread.Sleep(1000);
            builderPage.ClickBuilderDetailMenuButton();
            Thread.Sleep(1000);
            builderPage.ClickEditLinkAssessmentBuilderDetail();
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Add new principal
        /// </summary>
        /// <param name="principalName">Principal name</param>
        /// <param name="principalDOB">Principal DOB</param>
        /// <param name="principalSuburb">Principal surburb</param>
        /// <param name="principalRole">Principal role</param>
        /// <param name="principalNSW">Principal NSW</param>
        /// <param name="principalYearLincenseHeld">Principal year licence held</param>
        public void AddNewPrincipal(string principalName, string principalDOB, string principalSuburb, string principalRole, string principalNSW, string principalYearLincenseHeld)
        {
            builderPage.ClickAddNewPrincipal();
            Thread.Sleep(3000);
            builderPage.SetPrincipalName(principalName);
            builderPage.SetPrincipalDOB(principalDOB);
            builderPage.SetPrincipalSuburb(principalSuburb);
            builderPage.SetPrincipalRole(principalRole);
            builderPage.SetPrincipalNSW(principalNSW);
            builderPage.SetPrincipalYearLicenseHeld(principalYearLincenseHeld);
            builderPage.SetPrincipalActive();
            Thread.Sleep(2000);
            builderPage.ClickSavePrincipal();
        }

    }
}