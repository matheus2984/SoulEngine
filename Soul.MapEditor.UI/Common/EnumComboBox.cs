using System;
using System.Windows.Forms;

namespace Soul.MapEditor.UI.Common
{
    public class EnumComboBox : ComboBox
    {
        public Type EnumType
        {
            set
            {
                Items.Clear();
                foreach (object enumValue in Enum.GetValues(value))
                {
                    Items.Add(enumValue);
                }
            }
        }
    }
}