using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rebtel.Core.Infrastructure
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Will get the description for a given enums value, this will
        /// only work if you assign the Description attribute to
        /// the items in your enum.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            if (value == null)
            {
                return null;
            }

            var valueString = value.ToString();
            var fi = value.GetType().GetField(valueString);
            // Invalid Value for Enum e.g. 0
            if (fi == null)
            {
                return null;
            }

            var attributes = (DescriptionAttribute[])
                fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return valueString;
        }
    }
}
