using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QASeleniumInfrastructure
{
    public interface ISeleniumAutomationProcess
    {
        void Navigate(string url);
        void CloseDriver();
        void Click(string element, PropertyType elementType);
        void EnterText(string element, string value, PropertyType elementType);
        dynamic GetElement(string element, PropertyType elementType);
        string GetText(string element, PropertyType elementType);

    }
}
