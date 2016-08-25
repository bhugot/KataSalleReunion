﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Specs.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class GetRoomsFeature : Xunit.IClassFixture<GetRoomsFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GetRooms.feature"
#line hidden
        
        public GetRoomsFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GetRooms", "\tIn order to book a meeting room\r\n\tAs Julien\r\n\tI want to be able to list the room" +
                    "s", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
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
        
        public virtual void SetFixture(GetRoomsFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="List all rooms")]
        [Xunit.TraitAttribute("FeatureTitle", "GetRooms")]
        [Xunit.TraitAttribute("Description", "List all rooms")]
        public virtual void ListAllRooms()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("List all rooms", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table1.AddRow(new string[] {
                        "room0"});
            table1.AddRow(new string[] {
                        "room1"});
            table1.AddRow(new string[] {
                        "room2"});
            table1.AddRow(new string[] {
                        "room3"});
            table1.AddRow(new string[] {
                        "room4"});
            table1.AddRow(new string[] {
                        "room5"});
            table1.AddRow(new string[] {
                        "room6"});
            table1.AddRow(new string[] {
                        "room7"});
            table1.AddRow(new string[] {
                        "room8"});
            table1.AddRow(new string[] {
                        "room9"});
#line 7
 testRunner.Given("I have all the following rooms:", ((string)(null)), table1, "Given ");
#line 20
 testRunner.When("I Ask for rooms", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table2.AddRow(new string[] {
                        "room0"});
            table2.AddRow(new string[] {
                        "room1"});
            table2.AddRow(new string[] {
                        "room2"});
            table2.AddRow(new string[] {
                        "room3"});
            table2.AddRow(new string[] {
                        "room4"});
            table2.AddRow(new string[] {
                        "room5"});
            table2.AddRow(new string[] {
                        "room6"});
            table2.AddRow(new string[] {
                        "room7"});
            table2.AddRow(new string[] {
                        "room8"});
            table2.AddRow(new string[] {
                        "room9"});
#line 21
 testRunner.Then("I would get the following rooms", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                GetRoomsFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                GetRoomsFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
