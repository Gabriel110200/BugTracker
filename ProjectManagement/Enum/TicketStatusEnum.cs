using System.ComponentModel;

namespace ProjectManagement.Enum
{
    public enum TicketStatusEnum
    {
        [Description("Ready to start")]
        Ready = 0,

        [Description("In Progress")]
        InProgress = 1,

        [Description("Code Review")]
        CodeReview = 2,

        [Description("QA")]
        QA = 3,

        [Description("Ready To Production")]
        ReadyToProduction = 4,

        [Description("Done")]
        Done = 5


    }
}
