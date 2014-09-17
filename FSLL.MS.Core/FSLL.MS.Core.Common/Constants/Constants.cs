

using System.ComponentModel;
namespace FSLL.MS.Core.Common
{
    public enum ChurchGroupTypeEnum
    {
        [Description("Church")]
        Church = 1,
        [Description("CellGroup")]
        CellGroup = 2,
        [Description("ServiceGroup")]
        ServiceGroup = 3,
    }
}
