using System.ComponentModel;

namespace ProjectManagement.Enum
{
    public enum TicketPriority
    {

        [Description("Low Priority")]
        Low = 0,

        [Description("Meidum Priority")]
        Medium = 1,

        [Description("High Priority")]
        High = 2,

        [Description("Urgent Priority")]
        Urgent = 3

    }
}
