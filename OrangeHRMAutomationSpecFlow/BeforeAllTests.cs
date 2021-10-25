using BoDi;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace OrangeHRMAutomationSpecFlow
{
    [Binding]
    public class BeforeAllTests
    {
        private static IObjectContainer _objContainer;
        private static SeleniumContext _seleniumContext;
        public BeforeAllTests(IObjectContainer container)
        {
            _objContainer = container;
        }


        [BeforeScenario(Order = 0)]
        public void Setup()
        {
            _seleniumContext = new SeleniumContext();
            _objContainer.RegisterInstanceAs(_seleniumContext);
        }

        //[AfterScenario(Order = 9999)]
        //public static void TearDown()
        //{
        //    _seleniumContext.Driver.Dispose();
        //}
    }
}

