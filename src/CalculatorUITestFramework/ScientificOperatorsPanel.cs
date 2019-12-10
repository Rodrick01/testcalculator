// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices.ComTypes;
using System;

namespace CalculatorUITestFramework
{
    public enum AngleOperatorState
    {
        Degrees,
        Radians,
        Gradians
    };

    /// <summary>
    /// UI elements and helper methods to perform common mathematical standard operations.
    /// </summary>
    public class ScientificOperatorsPanel
    {
        private WindowsDriver<WindowsElement> session => WinAppDriver.Instance.CalculatorSession;
        public NumberPad NumberPad = new NumberPad();

        public WindowsElement XPower2Button => this.session.TryFindElementByAccessibilityId("xpower2Button");
        public WindowsElement XPower3Button => this.session.TryFindElementByAccessibilityId("xpower3Button");
        public WindowsElement XPowerYButton => this.session.TryFindElementByAccessibilityId("powerButton");
        public WindowsElement PowerOf10Button => this.session.TryFindElementByAccessibilityId("powerOf10Button");
        public WindowsElement LogButton => this.session.TryFindElementByAccessibilityId("logBase10Button");
        public WindowsElement LnButton => this.session.TryFindElementByAccessibilityId("logBaseEButton");
        public WindowsElement PiButton => this.session.TryFindElementByAccessibilityId("piButton");
        public WindowsElement InvertButton => this.session.TryFindElementByAccessibilityId("invertButton");
        public WindowsElement EulerButton => this.session.TryFindElementByAccessibilityId("eulerButton");
        public WindowsElement AbsButton => this.session.TryFindElementByAccessibilityId("absButton");
        public WindowsElement ExpButton => this.session.TryFindElementByAccessibilityId("expButton");
        public WindowsElement ModButton => this.session.TryFindElementByAccessibilityId("modButton");
        public WindowsElement ParenthesisLeftButton => this.session.TryFindElementByAccessibilityId("openParenthesisButton");
        public WindowsElement ParenthesisRightButton => this.session.TryFindElementByAccessibilityId("closeParenthesisButton");
        public WindowsElement FactorialButton => this.session.TryFindElementByAccessibilityId("factorialButton");
        public WindowsElement DivideButton => this.session.TryFindElementByAccessibilityId("divideButton");
        public WindowsElement MultiplyButton => this.session.TryFindElementByAccessibilityId("multiplyButton");
        public WindowsElement MinusButton => this.session.TryFindElementByAccessibilityId("minusButton");
        public WindowsElement PlusButton => this.session.TryFindElementByAccessibilityId("plusButton");
        public WindowsElement EqualButton => this.session.TryFindElementByAccessibilityId("equalButton");
        public WindowsElement ClearEntryButton => this.session.TryFindElementByAccessibilityId("clearEntryButton");
        public WindowsElement ClearButton => this.session.TryFindElementByAccessibilityId("clearButton");
        public WindowsElement BackSpaceButton => this.session.TryFindElementByAccessibilityId("backSpaceButton");
        public WindowsElement DegButton => this.session.TryFindElementByAccessibilityId("degButton");
        public WindowsElement RadButton => this.session.TryFindElementByAccessibilityId("radButton");
        public WindowsElement GradButton => this.session.TryFindElementByAccessibilityId("gradButton");
        public WindowsElement AngleOperator => this.session.TryFindElementByAccessibilityId("ScientificAngleOperators");
        public WindowsElement TrigButton => this.session.TryFindElementByAccessibilityId("trigButton");
        public WindowsElement FuncButton => this.session.TryFindElementByAccessibilityId("funcButton");
        public WindowsElement SinButton => this.session.TryFindElementByAccessibilityId("sinButton");
        public WindowsElement CosButton => this.session.TryFindElementByAccessibilityId("cosButton");
        public WindowsElement TanButton => this.session.TryFindElementByAccessibilityId("tanButton");
        public WindowsElement CscButton => this.session.TryFindElementByAccessibilityId("cscButton");
        public WindowsElement SecButton => this.session.TryFindElementByAccessibilityId("secButton");
        public WindowsElement CotButton => this.session.TryFindElementByAccessibilityId("cotButton");
        public WindowsElement TrigShiftButton => this.session.TryFindElementByAccessibilityId("trigShiftButton");
        public WindowsElement HypShiftButton => this.session.TryFindElementByAccessibilityId("hypShiftButton");
        public WindowsElement InvSinButton => this.session.TryFindElementByAccessibilityId("invsinButton");
        public WindowsElement InvCosButton => this.session.TryFindElementByAccessibilityId("invcosButton");
        public WindowsElement InvTanButton => this.session.TryFindElementByAccessibilityId("invtanButton");
        public WindowsElement InvCscButton => this.session.TryFindElementByAccessibilityId("invcscButton");
        public WindowsElement InvSecButton => this.session.TryFindElementByAccessibilityId("invsecButton");
        public WindowsElement InvCotButton => this.session.TryFindElementByAccessibilityId("invcotButton");
        public WindowsElement SinhButton => this.session.TryFindElementByAccessibilityId("sinhButton");
        public WindowsElement CoshButton => this.session.TryFindElementByAccessibilityId("coshButton");
        public WindowsElement TanhButton => this.session.TryFindElementByAccessibilityId("tanhButton");
        public WindowsElement CschButton => this.session.TryFindElementByAccessibilityId("cschButton");
        public WindowsElement SechButton => this.session.TryFindElementByAccessibilityId("sechButton");
        public WindowsElement CothButton => this.session.TryFindElementByAccessibilityId("cothButton");
        public WindowsElement InvSinhButton => this.session.TryFindElementByAccessibilityId("invsinhButton");
        public WindowsElement InvCoshButton => this.session.TryFindElementByAccessibilityId("invcoshButton");
        public WindowsElement InvTanhButton => this.session.TryFindElementByAccessibilityId("invtanhButton");
        public WindowsElement InvCschButton => this.session.TryFindElementByAccessibilityId("invcschButton");
        public WindowsElement InvSechButton => this.session.TryFindElementByAccessibilityId("invsechButton");
        public WindowsElement InvCothButton => this.session.TryFindElementByAccessibilityId("invcothButton");
        public WindowsElement FloorButton => this.session.TryFindElementByAccessibilityId("floorButton");
        public WindowsElement CeilButton => this.session.TryFindElementByAccessibilityId("ceilButton");
        public WindowsElement RandButton => this.session.TryFindElementByAccessibilityId("randButton");
        public WindowsElement DmsButton => this.session.TryFindElementByAccessibilityId("dmsButton");
        public WindowsElement DegreesButton => this.session.TryFindElementByAccessibilityId("degreesButton");
        public WindowsElement FixedToExponentialButton => this.session.TryFindElementByAccessibilityId("ftoeButton");
        public WindowsElement NegateButton => this.session.TryFindElementByAccessibilityId("negateButton");
        public WindowsElement TrigFlyout => this.session.TryFindElementByAccessibilityId("Trigflyout");
        public WindowsElement LightDismiss => this.session.TryFindElementByAccessibilityId("Light Dismiss");
        private WindowsElement DegRadGradButton => GetAngleOperatorButton();
        
        private WindowsElement GetAngleOperatorButton()
        {
            string source = this.session.PageSource;
            if (source.Contains("degButton"))
            {
                return DegButton;
            }
            else if (source.Contains("gradButton"))
            {
                return GradButton;
            }
            else if (source.Contains("radButton"))
            {
                return RadButton;
            }

            throw new NotFoundException("Could not find deg, rad or grad button in page source");
        }

        /// <summary>
        /// Set the state of the degrees, radians and gradians buttons.
        /// </summary>
        public void SetAngleOperator(AngleOperatorState value)
        {
            //set the desired string value for the button
                string desiredId;
                switch (value)
                {
                    case AngleOperatorState.Degrees:
                        desiredId = "degButton";
                        break;
                    case AngleOperatorState.Gradians:
                        desiredId = "gradButton";
                        break;
                    case AngleOperatorState.Radians:
                        desiredId = "radButton";
                        break;
                    default:
                        throw new NotImplementedException();
                }
                while (this.DegRadGradButton.GetAttribute("AutomationId") != desiredId)
                {
                    this.DegRadGradButton.Click();
                }
        }

        public WindowsElement ResetTrigDropdownToggles()
        {
            TrigButton.Click();
            string source = this.session.PageSource;
            if (source.Contains("sinButton"))
            {
                LightDismiss.Click();
            }
            else if (source.Contains("invsinButton"))
            {
                TrigShiftButton.Click();
            }
            else if (source.Contains("sinhButton"))
            {
                HypShiftButton.Click();
            }
            else if (source.Contains("invsinhButton"))
            {
                TrigShiftButton.Click();
                HypShiftButton.Click();
            }
            throw new NotFoundException("Could not find trig drop-down buttons in page source");
        }
    }
}