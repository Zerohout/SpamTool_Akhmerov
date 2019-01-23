using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOpenXml
{
    public class TestRecipient
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private string _email;

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public TestRecipient(string name, string email)
        {
            _name = name;
            _email = email;
        }
    }
}
