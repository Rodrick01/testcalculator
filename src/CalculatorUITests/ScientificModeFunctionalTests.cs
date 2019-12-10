// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CalculatorUITestFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;

namespace CalculatorUITests
{
    [TestClass]
    public class ScientificModeFunctionalTests
    {
        private static ScientificCalculatorPage page = new ScientificCalculatorPage();

        /// <summary>
        /// Initializes the WinAppDriver web driver session.
        /// </summary>
        /// <param name="context"></param>
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            // Create session to launch a Calculator window
            WinAppDriver.Instance.SetupCalculatorSession(context);

            // Ensure that calculator is in scientific mode
            page.NavigateToScientificCalculator();
        }

        /// <summary>
        /// Closes the app and WinAppDriver web driver session.
        /// </summary>
        [ClassCleanup]
        public static void ClassCleanup()
        {
            // Tear down Calculator session.
            WinAppDriver.Instance.TearDownCalculatorSession();
        }

        /// <summary>
        /// Ensures the calculator is in a cleared state
        /// </summary>
        [TestInitialize]
        public void TestInit()
        {
            if ("0" != page.GetCalculatorResultText())
            {
                page.ClearAll();
            }

            page.ScientificOperators.SetAngleOperator(AngleOperatorState.Degrees);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            page.ClearAll();
        }

        #region Smoke Tests
        [TestMethod]
        [Priority(0)]
        public void SmokeTest_Cube()
        {
            page.ScientificOperators.NumberPad.Input(3);
            page.ScientificOperators.XPower3Button.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("27", page.GetCalculatorResultText());
        }

        [TestMethod]
        [Priority(0)]
        public void SmokeTest_Sin()
        {
            page.ScientificOperators.NumberPad.Input(90);
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.SinButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("1", page.GetCalculatorResultText());
        }

        [TestMethod]
        [Priority(0)]
        public void SmokeTest_Tanh()
        {
            page.ScientificOperators.NumberPad.Input(90);
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.HypShiftButton.Click();
            page.ScientificOperators.TanhButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("1", page.GetCalculatorResultText());
        }

        [TestMethod]
        [Priority(0)]
        public void SmokeTest_InvCos()
        {
            page.ScientificOperators.NumberPad.Input(1);
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.TrigShiftButton.Click();
            page.ScientificOperators.InvCosButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("0", page.GetCalculatorResultText());
        }

        [TestMethod]
        [Priority(0)]
        public void SmokeTest_Floor()
        {
            page.ScientificOperators.NumberPad.Input(5.9);
            page.ScientificOperators.FuncButton.Click();
            page.ScientificOperators.FloorButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("5", page.GetCalculatorResultText());
        }

        [TestMethod]
        [Priority(0)]
        public void SmokeTest_Parentheses()
        {
            page.ScientificOperators.NumberPad.Input(3);
            page.ScientificOperators.MultiplyButton.Click();
            page.ScientificOperators.ParenthesisLeftButton.Click();
            page.ScientificOperators.NumberPad.Input(2);
            page.ScientificOperators.PlusButton.Click();
            page.ScientificOperators.NumberPad.Input(2);
            page.ScientificOperators.ParenthesisRightButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("12", page.GetCalculatorResultText());
        }

        [TestMethod]
        [Priority(0)]
        public void SmokeTest_RadianAngleOperator()
        {
            page.ScientificOperators.SetAngleOperator(AngleOperatorState.Radians);

            page.ScientificOperators.PiButton.Click();
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.CosButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("-1", page.GetCalculatorResultText());
        }

        [TestMethod]
        [Priority(0)]
        public void SmokeTest_GradianAngleOperator()
        {
            page.ScientificOperators.SetAngleOperator(AngleOperatorState.Gradians);

            page.ScientificOperators.NumberPad.Input(100);
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.SinButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("1", page.GetCalculatorResultText());
        }

        [TestMethod]
        [Priority(0)]
        public void SmokeTest_FixedToExponential()
        {
            page.ScientificOperators.FixedToExponentialButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("0.e+0", page.GetCalculatorResultText());
        }
        #endregion

        #region Advanced Arithmetic Tests
        [TestMethod]
        [Priority(1)]
        public void Operator_XPowerY()
        {
            page.ScientificOperators.NumberPad.Input(3);
            page.ScientificOperators.XPowerYButton.Click();
            page.ScientificOperators.NumberPad.Input(5);
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("243", page.GetCalculatorResultText());
        }

        [TestMethod]
        [Priority(1)]
        public void Operator_PowerOf10Button()
        {
            page.ScientificOperators.NumberPad.Input(5);
            page.ScientificOperators.PowerOf10Button.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("100,000", page.GetCalculatorResultText());
        }

        [TestMethod]
        [Priority(1)]
        public void Operator_LogButton()
        {
            page.ScientificOperators.NumberPad.Input(10000);
            page.ScientificOperators.LogButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("4", page.GetCalculatorResultText());
        }

        [TestMethod]
        [Priority(1)]
        public void Operator_LnButton()
        {
            page.ScientificOperators.EulerButton.Click();
            page.ScientificOperators.LnButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("1", page.GetCalculatorResultText());
        }

        [TestMethod]
        [Priority(1)]
        public void Operator_AbsButton()
        {
            page.ScientificOperators.NumberPad.Input(25);
            page.ScientificOperators.NegateButton.Click();
            page.ScientificOperators.AbsButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("25", page.GetCalculatorResultText());
        }

        [TestMethod]
        [Priority(1)]
        public void Operator_ExpButton()
        {
            page.ScientificOperators.NumberPad.Input(4);
            page.ScientificOperators.ExpButton.Click();
            page.ScientificOperators.NumberPad.Input(4);
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("40,000", page.GetCalculatorResultText());
        }

        [TestMethod]
        [Priority(1)]
        public void Operator_ModButton()
        {
            page.ScientificOperators.NumberPad.Input(53);
            page.ScientificOperators.ModButton.Click();
            page.ScientificOperators.NumberPad.Input(10);
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("3", page.GetCalculatorResultText());
        }

        [TestMethod]
        [Priority(1)]
        public void Operator_FactorialButton()
        {
            page.ScientificOperators.NumberPad.Input(4);
            page.ScientificOperators.FactorialButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("24", page.GetCalculatorResultText());
        }

        [TestMethod]
        [Priority(1)]
        public void Operator_CeilingButton()
        {
            page.ScientificOperators.NumberPad.Input(4.1);
            page.ScientificOperators.FuncButton.Click();
            page.ScientificOperators.CeilButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("5", page.GetCalculatorResultText());
        }

        [TestMethod]
        [Priority(1)]
        public void Operator_RandomButton()
        {
            page.ScientificOperators.FuncButton.Click();
            page.ScientificOperators.RandButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.IsTrue(page.GetCalculatorResultText().StartsWith("0."));
        }

        [TestMethod]
        [Priority(1)]
        public void Operator_DmsButton()
        {
            page.ScientificOperators.NumberPad.Input(2.999);
            page.ScientificOperators.FuncButton.Click();
            page.ScientificOperators.DmsButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("2.59564", page.GetCalculatorResultText());
        }

        [TestMethod]
        [Priority(1)]
        public void Operator_DegreesButton()
        {
            page.ScientificOperators.NumberPad.Input(2.59564);
            page.ScientificOperators.FuncButton.Click();
            page.ScientificOperators.DegreesButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("2.999", page.GetCalculatorResultText());
        }
        #endregion

        #region Trigonometry Tests
        [TestMethod]
        [Priority(2)]
        public void Trig_CosButton()
        {

            page.ScientificOperators.NumberPad.Input(180);
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.CosButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("-1", page.GetCalculatorResultText());

        }

        [TestMethod]
        [Priority(2)]
        public void Trig_TanButton()
        {
            page.ScientificOperators.SetAngleOperator(AngleOperatorState.Degrees);

            page.ScientificOperators.NumberPad.Input(45);
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.TanButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("1", page.GetCalculatorResultText());

        }

        [TestMethod]
        [Priority(2)]
        public void Trig_SecButton()
        {
            page.ScientificOperators.SetAngleOperator(AngleOperatorState.Degrees);

            page.ScientificOperators.NumberPad.Input(180);
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.SecButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("-1", page.GetCalculatorResultText());

        }

        [TestMethod]
        [Priority(2)]
        public void Trig_CscButton()
        {
            page.ScientificOperators.SetAngleOperator(AngleOperatorState.Degrees);

            page.ScientificOperators.NumberPad.Input(90);
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.CscButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("1", page.GetCalculatorResultText());

        }

        [TestMethod]
        [Priority(2)]
        public void Trig_CotButton()
        {
            page.ScientificOperators.SetAngleOperator(AngleOperatorState.Degrees);

            page.ScientificOperators.NumberPad.Input(45);
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.CotButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("1", page.GetCalculatorResultText());

        }

        [TestMethod]
        [Priority(2)]
        public void Trig_InvSinButton()
        {
            page.ScientificOperators.SetAngleOperator(AngleOperatorState.Degrees);

            page.ScientificOperators.NumberPad.Input(1);
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.TrigShiftButton.Click();
            page.ScientificOperators.InvSinButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("90", page.GetCalculatorResultText());

        }

        [TestMethod]
        [Priority(2)]
        public void Trig_InvTanButton()
        {
            page.ScientificOperators.SetAngleOperator(AngleOperatorState.Degrees);

            page.ScientificOperators.NumberPad.Input(1);
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.TrigShiftButton.Click();
            page.ScientificOperators.InvTanButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("45", page.GetCalculatorResultText());

        }

        [TestMethod]
        [Priority(2)]
        public void Trig_InvSecButton()
        {
            page.ScientificOperators.SetAngleOperator(AngleOperatorState.Degrees);

            page.ScientificOperators.NumberPad.Input(1);
            page.ScientificOperators.NegateButton.Click();
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.TrigShiftButton.Click();
            page.ScientificOperators.InvSecButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("180", page.GetCalculatorResultText());

        }

        [TestMethod]
        [Priority(2)]
        public void Trig_InvCscButton()
        {
            page.ScientificOperators.SetAngleOperator(AngleOperatorState.Degrees);

            page.ScientificOperators.NumberPad.Input(1);
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.TrigShiftButton.Click();
            page.ScientificOperators.InvCscButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("90", page.GetCalculatorResultText());

        }

        [TestMethod]
        [Priority(2)]
        public void Trig_InvCotButton()
        {
            page.ScientificOperators.SetAngleOperator(AngleOperatorState.Degrees);

            page.ScientificOperators.NumberPad.Input(1);
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.TrigShiftButton.Click();
            page.ScientificOperators.InvCotButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("45", page.GetCalculatorResultText());

        }

        [TestMethod]
        [Priority(2)]
        public void Trig_SinhButton()
        {
            page.ScientificOperators.SetAngleOperator(AngleOperatorState.Degrees);

            page.ScientificOperators.NumberPad.Input(1);
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.HypShiftButton.Click();
            page.ScientificOperators.SinhButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.IsTrue(page.GetCalculatorResultText().StartsWith("1.175201"));

        }

        [TestMethod]
        [Priority(2)]
        public void Trig_CoshButton()
        {
            page.ScientificOperators.SetAngleOperator(AngleOperatorState.Degrees);

            page.ScientificOperators.NumberPad.Input(1);
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.HypShiftButton.Click();
            page.ScientificOperators.CoshButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.IsTrue(page.GetCalculatorResultText().StartsWith("1.54308"));

        }

        [TestMethod]
        [Priority(2)]
        public void Trig_SechButton()
        {
            page.ScientificOperators.SetAngleOperator(AngleOperatorState.Degrees);

            page.ScientificOperators.NumberPad.Input(1);
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.HypShiftButton.Click();
            page.ScientificOperators.SechButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.IsTrue(page.GetCalculatorResultText().StartsWith("0.64805"));

        }

        [TestMethod]
        [Priority(2)]
        public void Trig_CschButton()
        {
            page.ScientificOperators.SetAngleOperator(AngleOperatorState.Degrees);

            page.ScientificOperators.NumberPad.Input(1);
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.HypShiftButton.Click();
            page.ScientificOperators.CschButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.IsTrue(page.GetCalculatorResultText().StartsWith("0.850918"));

        }

        [TestMethod]
        [Priority(2)]
        public void Trig_CothButton()
        {
            page.ScientificOperators.SetAngleOperator(AngleOperatorState.Degrees);

            page.ScientificOperators.NumberPad.Input(45);
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.HypShiftButton.Click();
            page.ScientificOperators.CothButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("1", page.GetCalculatorResultText());

        }

        [TestMethod]
        [Priority(2)]
        public void Trig_InvSinhButton()
        {
            page.ScientificOperators.SetAngleOperator(AngleOperatorState.Degrees);

            page.ScientificOperators.NumberPad.Input(1);
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.TrigShiftButton.Click();
            page.ScientificOperators.HypShiftButton.Click();
            page.ScientificOperators.InvSinhButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.IsTrue(page.GetCalculatorResultText().StartsWith("0.881373"));

        }

        [TestMethod]
        [Priority(2)]
        public void Trig_InvCoshButton()
        {
            page.ScientificOperators.SetAngleOperator(AngleOperatorState.Degrees);

            page.ScientificOperators.NumberPad.Input(1);
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.TrigShiftButton.Click();
            page.ScientificOperators.HypShiftButton.Click();
            page.ScientificOperators.InvCoshButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("0", page.GetCalculatorResultText());

        }

        [TestMethod]
        [Priority(2)]
        public void Trig_InvTanhButton()
        {
            page.ScientificOperators.SetAngleOperator(AngleOperatorState.Degrees);

            page.ScientificOperators.NumberPad.Input(0.0);
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.TrigShiftButton.Click();
            page.ScientificOperators.HypShiftButton.Click();
            page.ScientificOperators.InvTanhButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("0", page.GetCalculatorResultText());

        }

        [TestMethod]
        [Priority(2)]
        public void Trig_InvSechButton()
        {
            page.ScientificOperators.SetAngleOperator(AngleOperatorState.Degrees);

            page.ScientificOperators.NumberPad.Input(1);
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.TrigShiftButton.Click();
            page.ScientificOperators.HypShiftButton.Click();
            page.ScientificOperators.InvSechButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.AreEqual("0", page.GetCalculatorResultText());

        }

        [TestMethod]
        [Priority(2)]
        public void Trig_InvCschButton()
        {
            page.ScientificOperators.SetAngleOperator(AngleOperatorState.Degrees);

            page.ScientificOperators.NumberPad.Input(1);
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.TrigShiftButton.Click();
            page.ScientificOperators.HypShiftButton.Click();
            page.ScientificOperators.InvCschButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.IsTrue(page.GetCalculatorResultText().StartsWith("0.881373"));

        }

        [TestMethod]
        [Priority(2)]
        public void Trig_InvCothButton()
        {
            page.ScientificOperators.SetAngleOperator(AngleOperatorState.Degrees);

            page.ScientificOperators.NumberPad.Input(2);
            page.ScientificOperators.TrigButton.Click();
            page.ScientificOperators.TrigShiftButton.Click();
            page.ScientificOperators.HypShiftButton.Click();
            page.ScientificOperators.InvCothButton.Click();
            page.ScientificOperators.EqualButton.Click();
            Assert.IsTrue(page.GetCalculatorResultText().StartsWith("0.549306"));

        }
        #endregion
    }
}