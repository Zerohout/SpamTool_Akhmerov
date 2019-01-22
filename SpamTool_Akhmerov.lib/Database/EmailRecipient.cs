using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamTool_Akhmerov.lib.Database
{
    public partial class EmailRecipient : IDataErrorInfo//, INotifyDataErrorInfo
    {
        string IDataErrorInfo.Error => "";

        string IDataErrorInfo.this[string PropertyName]
        {
            get
            {
                switch (PropertyName)
                {
                    case "Name":
                        if (Name.Length < 3)
                            return $"Имя {Name} имеет длину меньше 3 символов";
                        break;
                }

                return "";
            }
        }

        partial void OnEmailAddressChanging(string value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value), "Передана пустая ссылка на строку почтового адреса");
            if (value.Length < 5)
                throw new ArgumentException("Длина адреса должна быть больше 5 символов", nameof(value));
        }
    }
}
