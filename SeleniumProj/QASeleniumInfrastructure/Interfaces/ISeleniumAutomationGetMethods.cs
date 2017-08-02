using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QASeleniumInfrastructure.Interfaces
{
    public interface ISeleniumAutomationGetMethods
    {
        string GetText(string element, PropertyType elementType);
    }
}
