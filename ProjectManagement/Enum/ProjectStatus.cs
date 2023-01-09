using System.ComponentModel;

namespace ProjectManagement.Enum
{
    public enum ProjectStatus
    {
        [Description("Development")]
        Development = 1,

        [Description("Release")]
        Release = 2,

        [Description("Stable")]
        Stable = 3,

        [Description("Obsolete")]
        Obsolete = 0



    }
}
