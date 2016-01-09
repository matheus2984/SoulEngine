using System;
using System.Linq;

namespace Soul.Engine.Extentions
{
    public static partial class Extentions
    {
        public static bool Inherits(this Type type, Type baseType)
        {
            if (type == null)
                return false;

            if (baseType == null)
                return type.IsInterface;

            if (baseType.IsInterface)
                return type.GetInterfaces().Contains(baseType);

            Type currentType = type;
            while (currentType != null)
            {
                if (currentType.BaseType == baseType)
                    return true;
                currentType = currentType.BaseType;
            }

            return false;
        }
    }
}