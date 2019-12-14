//
// MyUserControl.xaml.h
// Declaration of the MyUserControl class
//

#pragma once

#include "CalcViewModel/Common/Utils.h"
#include "CalcViewModel/GraphingCalculator/GraphingSettingsViewModel.h"
#include "Views\GraphingCalculator\GraphingSettings.g.h"
#include <CalcViewModel\GraphingCalculator\GraphingCalculatorViewModel.h>

namespace CalculatorApp
{
    [Windows::Foundation::Metadata::WebHostHidden] public ref class GraphingSettings sealed
    {
    public:
        GraphingSettings();

        PROPERTY_R(CalculatorApp::ViewModel::GraphingSettingsViewModel ^, ViewModel);
        Windows::UI::Xaml::Style ^ SelectTextBoxStyle(bool isError);
        void GraphingSettings::SetGrapher(GraphControl::Grapher ^ grapher);
    private:
        void GridSettingsTextBox_PreviewKeyDown(Platform::Object ^ sender, Windows::UI::Xaml::Input::KeyRoutedEventArgs ^ e);
    };
}
