// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CalculatorUITestFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Drawing;

namespace CalculatorUITests
{
    [TestClass]
    public class StandardModeFunctionalTests
    {
        private static StandardCalculatorPage page = new StandardCalculatorPage();

        /// <summary>
        /// Initializes the WinAppDriver web driver session.
        /// </summary>
        /// <param name="context"></param>
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            // Create session to launch a Calculator window
            WinAppDriver.Instance.SetupCalculatorSession(context);

            // Ensure that calculator is in standard mode
            page.NavigateToStandardCalculator();

            // Ensure that calculator window is large enough to display the memory/history panel; a good size for most tests
            page.MemoryPanel.ResizeWindowToDiplayMemoryLabel();
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
            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.EnsureCalculatorIsInStandardMode();
            page.EnsureCalculatorResultTextIsZero();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            page.EnsureCalculatorIsInStandardMode();
            page.ClearAll();
        }

        #region Basic UI Functionality via Mouse Input Tests

        /// <summary>
        /// These automated tests verify clicking each of the buttons in the Calculator UI and getting an expected result
        /// Via mouse input, all basic UI functionality is checked 
        /// </summary>

        [TestMethod]
        [Priority(0)]
        public void MouseInput_AddSubtractClearClearEntryTwoThree()
        {
            //Verifies the +, -, CE, C, 2, and 3 button
            page.StandardOperators.NumberPad.Num2Button.Click();
            Assert.AreEqual("2", page.CalculatorResults.GetCalculatorResultText()); //verifies 2 button
            page.StandardOperators.PlusButton.Click();
            Assert.AreEqual("2 +", page.CalculatorResults.GetCalculatorExpressionText()); //verifies + button
            page.StandardOperators.NumberPad.Num2Button.Click();
            page.StandardOperators.MinusButton.Click();
            Assert.AreEqual("4", page.CalculatorResults.GetCalculatorResultText()); //verifies addition
            Assert.AreEqual("2 + 2 Minus (", page.CalculatorResults.GetCalculatorExpressionText()); //verifies - button
            page.StandardOperators.NumberPad.Num3Button.Click();
            Assert.AreEqual("3", page.CalculatorResults.GetCalculatorResultText()); //verifies 3 button
            page.StandardOperators.EqualButton.Click();
            Assert.AreEqual("1", page.CalculatorResults.GetCalculatorResultText()); //verifies subtraction
            page.StandardOperators.ClearEntryButton.Click();
            Assert.AreEqual("0", page.CalculatorResults.GetCalculatorResultText()); //verifies the CE button
            page.StandardOperators.ClearButton.Click();
            page.CalculatorResults.IsResultsExpressionClear(); //verifies the C button
        }

        [TestMethod]
        [Priority(0)]
        public void MouseInput_MultiplyDivideEqualFourFiveSix()
        {
            //Verifies the multiplication, and division, and the x, ÷, equal, 4, 5, and 6 button
            page.StandardOperators.NumberPad.Num4Button.Click();
            Assert.AreEqual("4", page.CalculatorResults.GetCalculatorResultText()); //verifies 4 button
            page.StandardOperators.MultiplyButton.Click();
            Assert.AreEqual("4 ×", page.CalculatorResults.GetCalculatorExpressionText()); //verifies x button
            page.StandardOperators.NumberPad.Num5Button.Click();
            Assert.AreEqual("5", page.CalculatorResults.GetCalculatorResultText()); //verifies 5 button
            page.StandardOperators.DivideButton.Click();
            Assert.AreEqual("20", page.CalculatorResults.GetCalculatorResultText()); //verifies multiplication
            Assert.AreEqual("4 × 5 ÷", page.CalculatorResults.GetCalculatorExpressionText()); //verifies ÷ button
            page.StandardOperators.NumberPad.Num6Button.Click();
            Assert.AreEqual("6", page.CalculatorResults.GetCalculatorResultText()); //verifies 6 button
            page.StandardOperators.EqualButton.Click();
            Assert.AreEqual("3.333333333333333", page.CalculatorResults.GetCalculatorResultText()); //verifies division
            Assert.AreEqual("4 × 5 ÷ 6=", page.CalculatorResults.GetCalculatorExpressionText()); //verifies = button
        }

        [TestMethod]
        [Priority(0)]
        public void MouseInput_InvertSquaredSevenEightNine()
        {
            //Verifies the invert, squared, 7, 8, and 9 button
            page.StandardOperators.NumberPad.Num7Button.Click();
            Assert.AreEqual("7", page.CalculatorResults.GetCalculatorResultText()); //verifies 7 button
            page.StandardOperators.InvertButton.Click();
            Assert.AreEqual("0.1428571428571429", page.CalculatorResults.GetCalculatorResultText()); //verifies inversion
            Assert.AreEqual("1/(7)", page.CalculatorResults.GetCalculatorExpressionText()); //verifies the invert button
            page.StandardOperators.ClearButton.Click();
            page.StandardOperators.NumberPad.Num8Button.Click();
            Assert.AreEqual("8", page.CalculatorResults.GetCalculatorResultText()); //verifies 8 button
            page.StandardOperators.ClearButton.Click();
            page.StandardOperators.NumberPad.Num9Button.Click();
            Assert.AreEqual("9", page.CalculatorResults.GetCalculatorResultText()); //verifies 9 button
            page.StandardOperators.XPower2Button.Click();
            Assert.AreEqual("81", page.CalculatorResults.GetCalculatorResultText()); //verifies squaring
            Assert.AreEqual("square (9)", page.CalculatorResults.GetCalculatorExpressionText()); //verifies squared button
        }

        [TestMethod]
        [Priority(0)]
        public void MouseInput_PercentSquareRootBackspaceDecimalNegateOneZero()
        {
            //Verifies the %, square root, backspace, decimal, negate, 1, and 0 button
            page.StandardOperators.NumberPad.Num1Button.Click();
            page.StandardOperators.NumberPad.Num0Button.Click();
            page.StandardOperators.NumberPad.Num0Button.Click();
            page.StandardOperators.BackSpaceButton.Click();
            Assert.AreEqual("10", page.CalculatorResults.GetCalculatorResultText()); // verifies the 1 button, the 0 button, and the backspace button
            page.StandardOperators.PlusButton.Click();
            page.StandardOperators.PercentButton.Click();
            Assert.AreEqual("1", page.CalculatorResults.GetCalculatorResultText()); //verifies percent calculation
            Assert.AreEqual("10 + 1", page.CalculatorResults.GetCalculatorExpressionText()); //verifies percent button
            page.StandardOperators.PercentButton.Click();
            page.StandardOperators.SquareRootButton.Click();
            Assert.AreEqual("0.3162277660168379", page.CalculatorResults.GetCalculatorResultText()); //verifies square root calculation
            Assert.AreEqual("10 + √(0.1)", page.CalculatorResults.GetCalculatorExpressionText()); //verifies 2√x button
            page.StandardOperators.NumberPad.DecimalButton.Click();
            Assert.AreEqual("0 point", page.CalculatorResults.GetCalculatorResultText()); //verifies decimal button
            page.StandardOperators.NumberPad.NegateButton.Click();
            page.StandardOperators.NumberPad.Num1Button.Click();
            Assert.AreEqual("-0.1", page.CalculatorResults.GetCalculatorResultText()); //verifies negate button
            page.StandardOperators.EqualButton.Click();
            Assert.AreEqual("9.9", page.CalculatorResults.GetCalculatorResultText()); //verifies calculation with decimal point and negative number
        }

        [TestMethod]
        [Priority(0)]
        public void MouseInput_HistoryButtons()
        {
            //Verifies history buttons
            page.StandardOperators.NumberPad.Num4Button.Click();
            page.StandardOperators.MultiplyButton.Click();
            page.StandardOperators.NumberPad.Num5Button.Click();
            page.StandardOperators.DivideButton.Click();
            page.StandardOperators.NumberPad.Num6Button.Click();
            page.StandardOperators.EqualButton.Click();
            page.HistoryPanel.ResizeWindowToDisplayHistoryButton();
            page.HistoryPanel.HistoryButton.Click();
            var historyFlyoutItems = page.HistoryPanel.GetAllHistoryFlyoutListViewItems();
            Assert.IsTrue(historyFlyoutItems[0].Text.Equals("4 × 5 ÷ 6= 3.333333333333333", StringComparison.InvariantCultureIgnoreCase)); //verifies History button
            page.HistoryPanel.ResizeWindowToDisplayHistoryLabel();
            var historyItems = page.HistoryPanel.GetAllHistoryListViewItems();
            Assert.IsTrue(historyItems[0].Text.Equals("4 × 5 ÷ 6= 3.333333333333333", StringComparison.InvariantCultureIgnoreCase));
            page.HistoryPanel.ClearHistoryButton.Click();
            Assert.IsNotNull(WinAppDriver.Instance.CalculatorSession.FindElementByAccessibilityId("HistoryEmpty")); //verifies the History panel's clear history button
        }

        [TestMethod]
        [Priority(0)]
        public void MouseInput_MemoryButtons()
        {
            //Verifies memory buttons
            page.StandardOperators.NumberPad.Num1Button.Click();
            page.MemoryPanel.MemButton.Click();
            var memoryItems = page.MemoryPanel.GetAllMemoryListViewItems();
            Assert.IsTrue(memoryItems[0].Text.Equals("1", StringComparison.InvariantCultureIgnoreCase)); //verifies memory button
            page.MemoryPanel.MemPlus.Click();
            Assert.IsTrue(memoryItems[0].Text.Equals("2", StringComparison.InvariantCultureIgnoreCase)); //verifies memory plus button
            page.MemoryPanel.MemRecall.Click();
            Assert.AreEqual("2", page.CalculatorResults.GetCalculatorResultText()); //verifies memory recall button
            page.StandardOperators.MinusButton.Click();
            page.StandardOperators.NumberPad.Num1Button.Click();
            page.StandardOperators.EqualButton.Click();
            page.MemoryPanel.MemMinus.Click();
            Assert.IsTrue(memoryItems[0].Text.Equals("1", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual("1", page.CalculatorResults.GetCalculatorResultText()); //verifies MemMinus button
            page.MemoryPanel.MemoryClear.Click();
            Assert.IsNotNull(WinAppDriver.Instance.CalculatorSession.FindElementByAccessibilityId("MemoryPaneEmpty")); //verifies the Memory panel's memory clear button
        }
        #endregion

        #region Basic Calculator Functionality via Keyboard Input Tests

        /// <summary>
        /// These automated tests verify the functionality of all hotkeys, that are common for all calculator modes, as well as the all keyboard input used in standard mode on the Standard Calculator.
        /// Via keyboard input, all basic UI functionality is checked.
        /// To-do:
        /// - Active issue "Bug 23811901: Clicking on the History Label causes the [Shift] + [Ctrl] + [D] hotkeys to break" causes KeyboardInput_HistoryHotkeys() to fail.
        /// It is currently commented out until the active bug is fixed.
        /// </summary>

        [TestMethod]
        [Priority(1)]
        public void KeyboardInput_HotkeysToChangeToBasicModes()
        {
            // Verify Hotkeys for changing modes
            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.CalculatorApp.Header.SendKeys(Keys.Alt + "2" + Keys.Alt);
            Assert.AreEqual("Scientific", page.CalculatorApp.GetCalculatorHeaderText()); //verifies Scientific navigation hotkey

            //To-do: Waiting for hotkey difinitions to become settled once graphing calculator is full add into the build process 
            //page.CalculatorApp.EnsureCalculatorHasFocus();
            //page.CalculatorApp.Header.SendKeys(Keys.Alt + "4" + Keys.Alt);
            //Assert.AreEqual("Programmer", page.CalculatorApp.GetCalculatorHeaderText()); //verifies Programmer navigation hotkey
            //page.CalculatorApp.EnsureCalculatorHasFocus();
            //page.CalculatorApp.Header.SendKeys(Keys.Alt + "5" + Keys.Alt);
            //Assert.AreEqual("Date Calculation", page.CalculatorApp.GetCalculatorHeaderText()); //verifies Date Calculation navigation hotkey

            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.CalculatorApp.Header.SendKeys(Keys.Alt + "1" + Keys.Alt);
            Assert.AreEqual("Standard", page.CalculatorApp.GetCalculatorHeaderText()); //verifies Standard navigation hotkey
        }

        [TestMethod]
        [Priority(1)]
        public void KeyboardInput_AddSubtractClearClearEntryTwoThree()
        {
            //Verifies the +, -, CE, C, 2, and 3 button
            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.CalculatorApp.Header.SendKeys("2");
            Assert.AreEqual("2", page.CalculatorResults.GetCalculatorResultText()); //verifies using 2 key
            page.CalculatorApp.Header.SendKeys(Keys.Add);
            Assert.AreEqual("2 +", page.CalculatorResults.GetCalculatorExpressionText()); //verifies using add key
            page.CalculatorApp.Header.SendKeys("2");
            page.CalculatorApp.Header.SendKeys(Keys.Subtract);
            Assert.AreEqual("4", page.CalculatorResults.GetCalculatorResultText()); //verifies addition
            Assert.AreEqual("2 + 2 Minus (", page.CalculatorResults.GetCalculatorExpressionText()); //verifies using subtraction key
            page.CalculatorApp.Header.SendKeys("3");
            Assert.AreEqual("3", page.CalculatorResults.GetCalculatorResultText()); //verifies using 3 key
            page.StandardOperators.EqualButton.Click();
            Assert.AreEqual("1", page.CalculatorResults.GetCalculatorResultText()); //verifies subtraction
            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.CalculatorApp.Header.SendKeys(Keys.Delete);
            Assert.AreEqual("0", page.CalculatorResults.GetCalculatorResultText()); //verifies the CE hotkey
            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.CalculatorApp.Header.SendKeys(Keys.Escape);
            page.CalculatorResults.IsResultsExpressionClear(); //verifies the C hotkey
        }

        [TestMethod]
        [Priority(1)]
        public void KeyboardInput_MultiplyDivideEqualFourFiveSix()
        {
            //Verifies the multiplication, division, and equal, 4, 5, and 6 key input
            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.CalculatorApp.Header.SendKeys("4");
            Assert.AreEqual("4", page.CalculatorResults.GetCalculatorResultText()); //verifies using 4 key
            page.CalculatorApp.Header.SendKeys(Keys.Multiply);
            Assert.AreEqual("4 ×", page.CalculatorResults.GetCalculatorExpressionText()); //verifies using multiplication key
            page.CalculatorApp.Header.SendKeys("5");
            Assert.AreEqual("5", page.CalculatorResults.GetCalculatorResultText()); //verifies using 5 key
            page.CalculatorApp.Header.SendKeys(Keys.Divide);
            Assert.AreEqual("20", page.CalculatorResults.GetCalculatorResultText()); //verifies multiplication
            Assert.AreEqual("4 × 5 ÷", page.CalculatorResults.GetCalculatorExpressionText()); //verifies using divide key
            page.CalculatorApp.Header.SendKeys("6");
            Assert.AreEqual("6", page.CalculatorResults.GetCalculatorResultText()); //verifies using 6 key
            page.CalculatorApp.Header.SendKeys(Keys.Equal);
            Assert.AreEqual("3.333333333333333", page.CalculatorResults.GetCalculatorResultText()); //verifies division
            Assert.AreEqual("4 × 5 ÷ 6=", page.CalculatorResults.GetCalculatorExpressionText()); //verifies equal key
        }

        [TestMethod]
        [Priority(1)]
        public void KeyboardInput_InvertSquaredSevenEightNine()
        {
            //Verifies the invert, squared, 7, 8, and 9 key input
            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.CalculatorApp.Header.SendKeys("7");
            Assert.AreEqual("7", page.CalculatorResults.GetCalculatorResultText()); //verifies using 7 key
            page.CalculatorApp.Header.SendKeys("r");
            Assert.AreEqual("0.1428571428571429", page.CalculatorResults.GetCalculatorResultText()); //verifies inversion
            Assert.AreEqual("1/(7)", page.CalculatorResults.GetCalculatorExpressionText()); //verifies the invert hotkey
            page.CalculatorApp.Header.SendKeys(Keys.Escape);
            page.CalculatorApp.Header.SendKeys("8");
            Assert.AreEqual("8", page.CalculatorResults.GetCalculatorResultText()); //verifies using 8 key
            page.CalculatorApp.Header.SendKeys(Keys.Escape);
            page.CalculatorApp.Header.SendKeys("9");
            Assert.AreEqual("9", page.CalculatorResults.GetCalculatorResultText()); //verifies using 9 key
            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.CalculatorApp.Header.SendKeys("q");
            Assert.AreEqual("81", page.CalculatorResults.GetCalculatorResultText()); //verifies squaring
            Assert.AreEqual("square (9)", page.CalculatorResults.GetCalculatorExpressionText()); //verifies squared hotkey
        }

        [TestMethod]
        [Priority(1)]
        public void KeyboardInput_PercentSquareRootBackspaceDecimalNegateOneZero()
        {
            //Verifies the %, square root, backspace, decimal, negate, 1, and 0 button
            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.CalculatorApp.Header.SendKeys("100");
            page.CalculatorApp.Header.SendKeys(Keys.Backspace);
            Assert.AreEqual("10", page.CalculatorResults.GetCalculatorResultText()); // verifies using the 1 key, the 0 key, and the backspace key
            page.CalculatorApp.Header.SendKeys(Keys.Add);
            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.CalculatorApp.Header.SendKeys(Keys.Shift + "5" + Keys.Shift);
            Assert.AreEqual("1", page.CalculatorResults.GetCalculatorResultText()); //verifies percent calculation
            Assert.AreEqual("10 + 1", page.CalculatorResults.GetCalculatorExpressionText()); //verifies percent hotkey
            page.CalculatorApp.Header.SendKeys(Keys.Shift);
            page.CalculatorApp.Header.SendKeys(Keys.Shift + "5" + Keys.Shift);
            page.CalculatorApp.Header.SendKeys(Keys.Shift);
            page.CalculatorApp.Header.SendKeys(Keys.Shift + "2" + Keys.Shift);
            Assert.AreEqual("0.3162277660168379", page.CalculatorResults.GetCalculatorResultText()); //verifies square root calculation
            Assert.AreEqual("10 + √(0.1)", page.CalculatorResults.GetCalculatorExpressionText()); //verifies 2√x hotkey
            page.CalculatorApp.Header.SendKeys(".");
            Assert.AreEqual("0 point", page.CalculatorResults.GetCalculatorResultText()); //verifies using decimal key
            page.CalculatorApp.Header.SendKeys(Keys.F9);
            page.CalculatorApp.Header.SendKeys("1");
            Assert.AreEqual("-0.1", page.CalculatorResults.GetCalculatorResultText()); //verifies negate hotkey
            page.StandardOperators.EqualButton.Click();
            Assert.AreEqual("9.9", page.CalculatorResults.GetCalculatorResultText()); //verifies calculation with decimal point and negative number
        }

        [TestMethod]
        [Priority(1)]
        public void KeyboardInput_HistoryHotkeys()
        {
            ////Verifies history hotkeys
            /// To-do: Commenting this section out until following active issue in calculator is fixed
            /// - Active issue "Bug 23811901: Clicking on the History Label causes the [Shift] + [Ctrl] + [D] hotkeys to break" causes this case to fail

            ////Verifies history buttons
            //page.CalculatorApp.EnsureCalculatorHasFocus();
            //page.CalculatorApp.Header.SendKeys("4");
            //page.CalculatorApp.Header.SendKeys(Keys.Multiply);
            //page.CalculatorApp.Header.SendKeys("5");
            //page.CalculatorApp.Header.SendKeys(Keys.Divide);
            //page.CalculatorApp.Header.SendKeys("6");
            //page.CalculatorApp.Header.SendKeys(Keys.Equal);
            //page.HistoryPanel.ResizeWindowToDisplayHistoryButton();
            //page.CalculatorApp.Header.SendKeys(Keys.Control + "h" + Keys.Control);
            //var historyFlyoutItems = page.HistoryPanel.GetAllHistoryFlyoutListViewItems();
            //Assert.IsTrue(historyFlyoutItems[0].Text.Equals("4 × 5 ÷ 6= 3.333333333333333", StringComparison.InvariantCultureIgnoreCase)); //verifies History button hotkeys
            //page.HistoryPanel.ResizeWindowToDisplayHistoryLabel();
            //var historyItems = page.HistoryPanel.GetAllHistoryListViewItems();
            //Assert.IsTrue(historyItems[0].Text.Equals("4 × 5 ÷ 6= 3.333333333333333", StringComparison.InvariantCultureIgnoreCase));
            //page.CalculatorApp.Header.SendKeys(Keys.Shift + Keys.Control + "h" + Keys.Control + Keys.Shift);
            //Assert.IsNotNull(WinAppDriver.Instance.CalculatorSession.FindElementByAccessibilityId("HistoryEmpty")); //verifies the History panel's clear history button hotkeys
        }

        [TestMethod]
        [Priority(1)]
        public void KeyboardInput_MemoryHotkeys()
        {
            //Verifies memory buttons
            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.CalculatorApp.Header.SendKeys("1");
            page.CalculatorApp.Header.SendKeys(Keys.Control + "m" + Keys.Control);
            var memoryItems = page.MemoryPanel.GetAllMemoryListViewItems();
            Assert.IsTrue(memoryItems[0].Text.Equals("1", StringComparison.InvariantCultureIgnoreCase)); //verifies memory hotkey
            page.CalculatorApp.Header.SendKeys(Keys.Control + "p" + Keys.Control);
            Assert.IsTrue(memoryItems[0].Text.Equals("2", StringComparison.InvariantCultureIgnoreCase)); //verifies memory plus hotkey
            page.CalculatorApp.Header.SendKeys(Keys.Control + "r" + Keys.Control);
            Assert.AreEqual("2", page.CalculatorResults.GetCalculatorResultText()); //verifies memory recall hotkey
            page.CalculatorApp.Header.SendKeys(Keys.Subtract);
            page.CalculatorApp.Header.SendKeys("1");
            page.CalculatorApp.Header.SendKeys(Keys.Equal);
            page.CalculatorApp.Header.SendKeys(Keys.Subtract);
            page.CalculatorApp.Header.SendKeys(Keys.Control + "q" + Keys.Control);
            Assert.IsTrue(memoryItems[0].Text.Equals("1", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual("1", page.CalculatorResults.GetCalculatorResultText()); //verifies MemMinus hotkey
            page.CalculatorApp.Header.SendKeys(Keys.Control + "l" + Keys.Control);
            Assert.IsNotNull(WinAppDriver.Instance.CalculatorSession.FindElementByAccessibilityId("MemoryPaneEmpty")); //verifies the Memory panel's memory clear button hotkey
        }

        #endregion

        #region Arithmetic Operators Functionality via Mixed Input

        /// <summary>
        /// These automated test not only verify each opperator individually, but they also simultaneously verify mixed user input.
        /// Arithmetic Operators for standard calculator are also automated in: 
        /// - Region: Basic UI Functionality via Mouse input
        /// - Region: Basic Calculator Functionality via Keyboard input
        /// </summary>

        [TestMethod]
        [Priority(2)]
        public void MixedInput_Operators_Addition()
        {

            //Verify Addition
            page.StandardOperators.NumberPad.Input(2);
            page.StandardOperators.PlusButton.Click();
            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.CalculatorApp.Header.SendKeys("2");
            page.CalculatorApp.Header.SendKeys(Keys.Equal);
            Assert.AreEqual("4", page.CalculatorResults.GetCalculatorResultText());
            page.CalculatorApp.Header.SendKeys(Keys.Escape);
        }

        [TestMethod]
        [Priority(2)]
        public void MixedInput_Operators_Subtraction()
        {
            //Verify Subtraction
            page.StandardOperators.NumberPad.Input(3);
            page.StandardOperators.MinusButton.Click();
            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.CalculatorApp.Header.SendKeys("2");
            page.CalculatorApp.Header.SendKeys(Keys.Equal);
            Assert.AreEqual("1", page.CalculatorResults.GetCalculatorResultText());
            page.CalculatorApp.Header.SendKeys(Keys.Escape);
        }

        [TestMethod]
        [Priority(2)]
        public void MixedInput_Operators_Multiplication()
        {
            //Verify Multiplication
            page.StandardOperators.NumberPad.Input(3);
            page.StandardOperators.MultiplyButton.Click();
            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.CalculatorApp.Header.SendKeys("2");
            page.CalculatorApp.Header.SendKeys(Keys.Equal);
            Assert.AreEqual("6", page.CalculatorResults.GetCalculatorResultText());
            page.CalculatorApp.Header.SendKeys(Keys.Escape);
        }

        [TestMethod]
        [Priority(2)]
        public void MixedInput_Operators_Division()
        {
            //Verify Division
            page.StandardOperators.NumberPad.Input(6);
            page.StandardOperators.MultiplyButton.Click();
            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.CalculatorApp.Header.SendKeys("2");
            page.CalculatorApp.Header.SendKeys(Keys.Equal);
            Assert.AreEqual("12", page.CalculatorResults.GetCalculatorResultText());
            page.CalculatorApp.Header.SendKeys(Keys.Escape);
        }

        [TestMethod]
        [Priority(2)]
        public void MixedInput_Operators_Reciprocal()
        {
            //Verify Reciprocal
            page.StandardOperators.NumberPad.Input(2);
            page.StandardOperators.InvertButton.Click();
            Assert.AreEqual("0.5", page.CalculatorResults.GetCalculatorResultText());
            page.CalculatorApp.Header.SendKeys(Keys.Escape);

        }

        [TestMethod]
        [Priority(2)]
        public void MixedInput_Operators_Square()
        {
            //Verify Square
            page.StandardOperators.NumberPad.Input(3);
            page.StandardOperators.XPower2Button.Click();
            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.CalculatorApp.Header.SendKeys(Keys.Equal);
            Assert.AreEqual("9", page.CalculatorResults.GetCalculatorResultText());
            page.CalculatorApp.Header.SendKeys(Keys.Escape);
        }

        [TestMethod]
        [Priority(2)]
        public void MixedInput_Operators_SquareRoot()
        {
            //Verify Square root
            page.StandardOperators.NumberPad.Input(9);
            page.StandardOperators.XPower2Button.Click();
            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.CalculatorApp.Header.SendKeys(Keys.Equal);
            Assert.AreEqual("81", page.CalculatorResults.GetCalculatorResultText());
            page.CalculatorApp.Header.SendKeys(Keys.Escape);
        }

        [TestMethod]
        [Priority(2)]
        public void MixedInput_Operators_PercentAdditionSubtraction()
        {
            //Verify Percent addition/subtraction
            page.StandardOperators.NumberPad.Input(10);
            page.StandardOperators.MinusButton.Click();
            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.CalculatorApp.Header.SendKeys("10");
            page.StandardOperators.PercentButton.Click();
            page.CalculatorApp.Header.SendKeys(Keys.Equal);
            Assert.AreEqual("9", page.CalculatorResults.GetCalculatorResultText());
            page.CalculatorApp.Header.SendKeys(Keys.Escape);
        }

        [TestMethod]
        [Priority(2)]
        public void MixedInput_Operators_PercentMultiplicationDivision()
        {
            //Verify Percent multiplication/division
            page.StandardOperators.NumberPad.Input(10);
            page.StandardOperators.MultiplyButton.Click();
            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.CalculatorApp.Header.SendKeys("10");
            page.StandardOperators.PercentButton.Click();
            page.CalculatorApp.Header.SendKeys(Keys.Equal);
            Assert.AreEqual("1", page.CalculatorResults.GetCalculatorResultText());
            page.CalculatorApp.Header.SendKeys(Keys.Escape);
        }

        [TestMethod]
        [Priority(2)]
        public void MixedInput_Operators_PositiveNegative()
        {
            //Verify Positive/Negative (plus/minus)
            page.StandardOperators.NumberPad.Input(3);
            page.StandardOperators.MinusButton.Click();
            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.CalculatorApp.Header.SendKeys("2");
            page.StandardOperators.NegateButton.Click();
            page.CalculatorApp.Header.SendKeys(Keys.Equal);
            Assert.AreEqual("5", page.CalculatorResults.GetCalculatorResultText());
            page.CalculatorApp.Header.SendKeys(Keys.Escape);
        }

        [TestMethod]
        [Priority(2)]
        public void MixedInput_Operators_Decimal()
        {
            //Verify Decimal
            page.StandardOperators.NumberPad.Input(3);
            page.StandardOperators.NumberPad.DecimalButton.Click();
            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.CalculatorApp.Header.SendKeys("2");
            page.CalculatorApp.Header.SendKeys(Keys.Equal);
            Assert.AreEqual("3.2", page.CalculatorResults.GetCalculatorResultText());
            page.CalculatorApp.Header.SendKeys(Keys.Escape);
        }

        [TestMethod]
        [Priority(2)]
        public void MixedInput_Operators_Equal()
        {
            //Verify Equal
            page.HistoryPanel.ClearHistory();
            page.StandardOperators.EqualButton.Click();
            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.CalculatorApp.Header.SendKeys(Keys.Equal);
            Assert.AreEqual("0", page.CalculatorResults.GetCalculatorResultText());
            var historyItems = page.HistoryPanel.GetAllHistoryListViewItems();
            Assert.IsTrue(historyItems[0].Text.Equals("0= 0", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(historyItems[1].Text.Equals("0= 0", StringComparison.InvariantCultureIgnoreCase));
            page.CalculatorApp.Header.SendKeys(Keys.Escape);
        }

        [TestMethod]
        [Priority(2)]
        public void MixedInput_Operators_Delete()
        {
            //Verify Delete
            page.StandardOperators.NumberPad.Input(3);
            page.CalculatorApp.Header.SendKeys("3");
            Assert.AreEqual("33", page.CalculatorResults.GetCalculatorResultText());
            page.StandardOperators.BackSpaceButton.Click();
            Assert.AreEqual("3", page.CalculatorResults.GetCalculatorResultText());
            page.CalculatorApp.Header.SendKeys(Keys.Backspace);
            Assert.AreEqual("0", page.CalculatorResults.GetCalculatorResultText());
        }

        [TestMethod]
        [Priority(0)]
        public void MixedInput_Operators_ClearEntryClear()
        {
            //Verify Clear Entery
            page.StandardOperators.NumberPad.Input(3);
            page.CalculatorApp.Header.SendKeys(Keys.Add);
            page.CalculatorApp.Header.SendKeys("3");
            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.CalculatorApp.Header.SendKeys(Keys.Delete);
            Assert.AreEqual("0", page.CalculatorResults.GetCalculatorResultText());
            Assert.AreEqual("3 +", page.CalculatorResults.GetCalculatorExpressionText());

            page.StandardOperators.NumberPad.Input(9);
            page.CalculatorApp.Header.SendKeys(Keys.Subtract);
            page.CalculatorApp.Header.SendKeys("6");
            page.StandardOperators.ClearEntryButton.Click();
            Assert.AreEqual("0", page.CalculatorResults.GetCalculatorResultText());
            Assert.AreEqual("3 + 9 Minus (", page.CalculatorResults.GetCalculatorExpressionText());

            //Verify Clear
            page.StandardOperators.NumberPad.Input(6);
            page.CalculatorApp.Header.SendKeys(Keys.Subtract);
            page.CalculatorApp.Header.SendKeys("9");
            page.StandardOperators.ClearButton.Click();
            page.CalculatorResults.IsResultsExpressionClear();
        }

        // Issue #817: Prefixed multiple zeros
        [TestMethod]
        [Priority(2)]
        public void MixedInput_Operators_DeletingDecimalDoesNotPrefixZeros()
        {
            page.StandardOperators.NumberPad.DecimalButton.Click(); // To enter decimal point
            page.CalculatorApp.Header.SendKeys("1");
            page.StandardOperators.BackSpaceButton.Click();
            page.StandardOperators.BackSpaceButton.Click();
            page.StandardOperators.NumberPad.Input(0);
            page.StandardOperators.NumberPad.Num0Button.Click();
            page.StandardOperators.NumberPad.Input(0);
            Assert.AreEqual("0", page.CalculatorResults.GetCalculatorResultText());
        }

        #endregion

        #region AoT (Always on top) Tests
        /// <summary>
        /// These automated tests verify:
        /// - Calculator can enter AoT mode, the AoT window is within a range of size, and it verifies exiting AoT mode
        /// - AoT button tooltips (in English)
        /// - Memory function cannot be triggered in AoT calculator
        /// - The history flyout cannot be opened in AoT mode and that history is tracked while in AoT mode and available upon exit of AoT mode
        /// - That Standard calculator has AoT button, but other major calculator modes do not
        /// - That the app can scale to smallest size, largest size, and to a medium size without crashing.  It does not test the visual appears of the UI while scaling. 
        /// - The window scale retention is maintained when switching between AoT and Non-AoT 
        ///     - To-do: Verify scale retention across calculator session
        /// - Error messaging while AoT mode
        ///     -  To-do: Need to verify "All operator buttons (except for "CE", "C", "Delete" and "="), and memory buttons are disabled" when in AoT mode
        /// - Verify app positioning after entering and exiting KOT mode
        /// </summary>
        ///

        [TestMethod]
        [Priority(0)]
        public void AoT_EnterExitKeepOnTop()
        {
            page.StandardAoTCalculatorPage.NavigateToStandardAoTMode();
            page.StandardAoTCalculatorPage.AoTWindowSizeWithinRange();
            page.StandardAoTCalculatorPage.AoTWindowPositionWithinRange();
            page.StandardAoTCalculatorPage.NavigateToStandardMode();

        }

        [TestMethod]
        [Priority(0)]
        public void AoT_Tootip()
        {
            Assert.AreEqual("Keep on top", page.StandardAoTCalculatorPage.GetAoTToolTipText());
            page.StandardAoTCalculatorPage.NavigateToStandardAoTMode();
            Assert.AreEqual("Back to full view", page.StandardAoTCalculatorPage.GetAoTToolTipText());
        }

        [TestMethod]
        [Priority(1)]
        public void AoT_NoMemoryFunction()
        {
            page.StandardOperators.NumberPad.Num9Button.Click();
            page.StandardOperators.MinusButton.Click();
            page.StandardOperators.NumberPad.Num3Button.Click();
            page.StandardAoTCalculatorPage.NavigateToStandardAoTMode();
            page.CalculatorApp.Window.SendKeys(Keys.Enter);
            page.CalculatorApp.Window.SendKeys(Keys.Control + "P" + Keys.Control);
            page.CalculatorApp.Window.SendKeys(Keys.Shift); //Hotkeys such as "Delete" will break without this line
            page.StandardAoTCalculatorPage.NavigateToStandardMode();
            page.MemoryPanel.OpenMemoryPanel();
            Assert.IsNotNull(WinAppDriver.Instance.CalculatorSession.FindElementByAccessibilityId("MemoryPaneEmpty"));
        }

        [TestMethod]
        [Priority(1)]
        public void AoT_HistoryFunction()
        {
            page.StandardOperators.NumberPad.Num3Button.Click();
            page.StandardOperators.PlusButton.Click();
            page.StandardOperators.NumberPad.Num3Button.Click();
            page.StandardAoTCalculatorPage.NavigateToStandardAoTMode();
            page.StandardOperators.EqualButton.Click();
            page.CalculatorApp.Window.SendKeys(Keys.Control + "H" + Keys.Control);
            string source = WinAppDriver.Instance.CalculatorSession.PageSource;
            if (source.Contains("HistoryFlyout"))
            {
                throw new NotFoundException("This test fails; history flyout is present");
            }
            else
            {
                page.StandardAoTCalculatorPage.NavigateToStandardMode();
                var historyItems = page.HistoryPanel.GetAllHistoryListViewItems();
                Assert.IsTrue(historyItems[0].Text.Equals("3 + 3= 6", StringComparison.InvariantCultureIgnoreCase));
            }
        }

        [TestMethod]
        [Priority(2)]
        public void AoT_ButtonOnlyInStandard()
        {
            page.NavigationMenu.ChangeCalculatorMode(CalculatorMode.ScientificCalculator);
            Assert.AreEqual("Scientific", page.CalculatorApp.GetCalculatorHeaderText());
            page.StandardAoTCalculatorPage.GetAoTPresence();
            Assert.AreEqual("False", page.StandardAoTCalculatorPage.GetAoTPresence());

            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.NavigationMenu.ChangeCalculatorMode(CalculatorMode.ProgrammerCalculator);
            Assert.AreEqual("Programmer", page.CalculatorApp.GetCalculatorHeaderText());
            page.StandardAoTCalculatorPage.GetAoTPresence();
            Assert.AreEqual("False", page.StandardAoTCalculatorPage.GetAoTPresence());

            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.NavigationMenu.ChangeCalculatorMode(CalculatorMode.DateCalculator);
            Assert.AreEqual("Date Calculation", page.CalculatorApp.GetCalculatorHeaderText());
            page.StandardAoTCalculatorPage.GetAoTPresence();
            Assert.AreEqual("False", page.StandardAoTCalculatorPage.GetAoTPresence());

            page.CalculatorApp.EnsureCalculatorHasFocus();
            page.NavigationMenu.ChangeCalculatorMode(CalculatorMode.StandardCalculator);
            Assert.AreEqual("Standard", page.CalculatorApp.GetCalculatorHeaderText());
            page.StandardAoTCalculatorPage.GetAoTPresence();
            Assert.AreEqual("True", page.StandardAoTCalculatorPage.GetAoTPresence());
        }

        [TestMethod]
        [Priority(2)]
        public void AoT_Scaling()
        {
            page.StandardAoTCalculatorPage.NavigateToStandardAoTMode();
            page.StandardAoTCalculatorPage.AoTWindowSizeWithinRange();
            Size smallAoTWindowSize = new Size(161, 168);
            Size largeAoTWindowSize = new Size(502, 502);
            Size mediumAoTWindowSize = new Size(396, 322);
            WinAppDriver.Instance.CalculatorSession.Manage().Window.Size = smallAoTWindowSize;
            var getSmallWindowSize = page.CalculatorApp.GetCalculatorWindowSize();
            Assert.AreEqual(getSmallWindowSize, page.CalculatorApp.GetCalculatorWindowSize());
            WinAppDriver.Instance.CalculatorSession.Manage().Window.Size = largeAoTWindowSize;
            var getLargeWindowSize = page.CalculatorApp.GetCalculatorWindowSize();
            Assert.AreEqual(getLargeWindowSize, page.CalculatorApp.GetCalculatorWindowSize());
            WinAppDriver.Instance.CalculatorSession.Manage().Window.Size = mediumAoTWindowSize;
            var getMediumAoTWindowSize = page.CalculatorApp.GetCalculatorWindowSize();
            Assert.AreEqual(getMediumAoTWindowSize, page.CalculatorApp.GetCalculatorWindowSize());
            page.StandardAoTCalculatorPage.ResizeAoTWindowToDiplayInvertButton(); //Resets AoT size
        }

        [TestMethod]
        [Priority(2)]
        public void AoT_ScaleRetention()
        {
            Size smallWindowSize = new Size(464, 502);
            //Size largeAoTWindowSize = new Size(502, 502);

            WinAppDriver.Instance.CalculatorSession.Manage().Window.Size = smallWindowSize;
            var getSmallWindowSize = page.CalculatorApp.GetCalculatorWindowSize();
            Assert.AreEqual(getSmallWindowSize, page.CalculatorApp.GetCalculatorWindowSize());

            page.StandardAoTCalculatorPage.NavigateToStandardAoTMode();
            //WinAppDriver.Instance.CalculatorSession.Manage().Window.Size = largeAoTWindowSize;
            var getLargeWindowSize = page.CalculatorApp.GetCalculatorWindowSize();
            Assert.AreEqual(getLargeWindowSize, page.CalculatorApp.GetCalculatorWindowSize());

            page.StandardAoTCalculatorPage.NavigateToStandardMode();
            Assert.AreEqual(getSmallWindowSize, page.CalculatorApp.GetCalculatorWindowSize());

            page.StandardAoTCalculatorPage.NavigateToStandardAoTMode();
            Assert.AreEqual(getLargeWindowSize, page.CalculatorApp.GetCalculatorWindowSize());
            page.StandardAoTCalculatorPage.ResizeAoTWindowToDiplayInvertButton(); //Resets AoT size

        }

        [TestMethod]
        [Priority(2)]
        public void AoT_ErrorMessage_ResultUndefined()
        {
            page.StandardAoTCalculatorPage.NavigateToStandardAoTMode();
            page.StandardAoTCalculatorPage.ResizeAoTWindowToDiplayInvertButton();
            page.StandardOperators.DivideButton.Click();
            page.StandardOperators.NumberPad.Num0Button.Click();
            page.StandardOperators.EqualButton.Click();
            page.StandardAoTCalculatorPage.AoTModeCheck();
            Assert.AreEqual("True", page.StandardAoTCalculatorPage.AoTModeCheck());
            Assert.AreEqual("Result is undefined", page.CalculatorResults.GetAoTCalculatorResultText());
        }

        [TestMethod]
        [Priority(2)]
        public void AoT_ErrorMessage_CannotDivideByZero()
        {
            page.StandardAoTCalculatorPage.NavigateToStandardAoTMode();
            page.StandardAoTCalculatorPage.ResizeAoTWindowToDiplayInvertButton();
            page.StandardOperators.ClearButton.Click();
            page.StandardOperators.InvertButton.Click();
            page.StandardAoTCalculatorPage.AoTModeCheck();
            Assert.AreEqual("True", page.StandardAoTCalculatorPage.AoTModeCheck());
            Assert.AreEqual("Cannot divide by zero", page.CalculatorResults.GetAoTCalculatorResultText());
        }

        [TestMethod]
        [Priority(2)]
        public void AoT_ErrorMessage_MessageRetentionUponExitingAoT()
        {
            page.StandardAoTCalculatorPage.NavigateToStandardAoTMode();
            page.StandardAoTCalculatorPage.ResizeAoTWindowToDiplayInvertButton();
            page.StandardOperators.ClearButton.Click();
            page.StandardOperators.InvertButton.Click();
            page.StandardAoTCalculatorPage.AoTModeCheck();
            Assert.AreEqual("True", page.StandardAoTCalculatorPage.AoTModeCheck());
            Assert.AreEqual("Cannot divide by zero", page.CalculatorResults.GetAoTCalculatorResultText());
            page.StandardAoTCalculatorPage.NavigateToStandardMode();
            page.StandardAoTCalculatorPage.AoTModeCheck();
            Assert.AreEqual("False", page.StandardAoTCalculatorPage.AoTModeCheck());
            Assert.AreEqual("Cannot divide by zero", page.CalculatorResults.GetCalculatorResultText());
        }

        #endregion
    }
}
