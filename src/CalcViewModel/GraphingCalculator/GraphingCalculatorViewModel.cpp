#include "pch.h"
#include "GraphingCalculatorViewModel.h"

using namespace CalculatorApp::ViewModel;
using namespace Platform;
using namespace Platform::Collections;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Xaml::Data;

namespace CalculatorApp::ViewModel
{
    GraphingCalculatorViewModel::GraphingCalculatorViewModel()
        : m_IsDecimalEnabled{ true }
        , m_Equations{ ref new Vector< EquationViewModel^ >() }
        , m_Variables{ ref new Vector< VariableViewModel^ >() }
    {
    }

    void GraphingCalculatorViewModel::OnButtonPressed(Object^ parameter)
    {
    }

    void GraphingCalculatorViewModel::UpdateVariables(IMap<String^, double>^ variables)
    {
        Variables->Clear();
        for (auto var : variables)
        {
            auto variable = ref new VariableViewModel(var->Key, var->Value);
            variable->PropertyChanged += ref new PropertyChangedEventHandler([this, variable](Object^ sender, PropertyChangedEventArgs^ e)
                {
                    if (e->PropertyName == "Value")
                    {
                        VariableUpdated(variable, VariableChangedEventArgs{ variable->Name, variable->Value });
                    }
                });
            Variables->Append(variable);

        }
    }
}
