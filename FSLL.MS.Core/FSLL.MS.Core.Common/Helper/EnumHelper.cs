using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace FSLL.MS.Core.Common
{
    public static class EnumHelper
    {
        /// <summary>
        /// Retrieve the description on the enum, e.g.
        /// [Description("Bright Pink")]
        /// BrightPink = 2,
        /// Then when you pass in the enum, it will retrieve the description
        /// </summary>
        /// <param name="en">The Enumeration</param>
        /// <returns>A string representing the friendly name</returns>
        public static string GetDescription(Enum en)
        {
            var type = en.GetType();
            var memInfo = type.GetMember(en.ToString());
            if (memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return en.ToString();
        }

        public class EmnuListItem
        {
            public string Value { get; set; }
            public string Text { get; set; }
        }

        public static List<EmnuListItem> ToEmnuListItem<T>()
        {
            List<EmnuListItem> li = new List<EmnuListItem>();

            foreach (int s in Enum.GetValues(typeof(T)))
            {
                var memInfo = typeof(T).GetMember(Enum.GetName(typeof(T),s));

                var desc = "";

                if (memInfo.Length > 0)
                {
                    var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (attrs.Length > 0)
                    {
                        desc = ((DescriptionAttribute)attrs[0]).Description;
                    }
                    else
                    {
                        desc = Enum.GetName(typeof(T), s);
                    }
                }

                li.Add(
                    new EmnuListItem
                    {
                        Value = s.ToString(),
                        Text = desc
                    }
                );
            }
            return li;
        }


    }
}
