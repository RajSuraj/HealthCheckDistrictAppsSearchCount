﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.17929
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace HealthCheck_District_Apps
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("AppSearchCount")]
    public partial class AppSearchCountFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "AppSearchCount.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "AppSearchCount", "       Check app search results and count the # of apps returns and check if the " +
                    "app returned matches", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 4
#line 5
testRunner.Given("the alteryx service is running at \"http://gallery.alteryx.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Search applications uses only the first term while ignoring others")]
        [NUnit.Framework.CategoryAttribute("mytag")]
        [NUnit.Framework.TestCaseAttribute("choosing blending", "1", null)]
        [NUnit.Framework.TestCaseAttribute("blending choosing", "3", null)]
        [NUnit.Framework.TestCaseAttribute("blending choosing", "1", null)]
        public virtual void SearchApplicationsUsesOnlyTheFirstTermWhileIgnoringOthers(string term, string count, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "mytag"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search applications uses only the first term while ignoring others", @__tags);
#line 8
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 9
        testRunner.When(string.Format("I search for application at \"api/apps/gallery/\" with search multiple term \"{0}\"", term), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
        testRunner.Then(string.Format("I see record-count is {0}", count), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("search applications for terms has expected name")]
        public virtual void SearchApplicationsForTermsHasExpectedName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("search applications for terms has expected name", ((string[])(null)));
#line 17
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 18
    testRunner.When("I search for application at \"api/apps/gallery\" with search term \"choosing a locat" +
                    "ion\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
    testRunner.Then("I see primaryapplication.metainfo.name contains \"Site Selection Demo\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("search applications for terms has expected name negative")]
        public virtual void SearchApplicationsForTermsHasExpectedNameNegative()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("search applications for terms has expected name negative", ((string[])(null)));
#line 21
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 22
    testRunner.When("I search for application at \"api/apps/gallery\" with search term \"choosing a locat" +
                    "ion\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
    testRunner.Then("I see primaryapplication.metainfo.name contains \"analyzing data\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("search applications for terms has expected counts")]
        public virtual void SearchApplicationsForTermsHasExpectedCounts()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("search applications for terms has expected counts", ((string[])(null)));
#line 25
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 26
        testRunner.When("I search for application at \"api/apps/gallery/\" with search term \"choosing\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
        testRunner.Then("I see record-count is 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("search applications for terms has expected counts negative")]
        public virtual void SearchApplicationsForTermsHasExpectedCountsNegative()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("search applications for terms has expected counts negative", ((string[])(null)));
#line 29
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 30
        testRunner.When("I search for application at \"api/apps/gallery/\" with search term \"choosing\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
        testRunner.Then("I see record-count is 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion