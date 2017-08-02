using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QASeleniumInfrastructure
{
    public interface ISeleniumAutomationSetMethods
    {
        void Click(string element, PropertyType elementType);
        void EnterText(string element, string value, PropertyType elementType);
    }
}
