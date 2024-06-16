using ProjectManagement.Enum;

namespace ProjectManagement.IServices
{
    public interface ITicketServiceFactory
    {
        public ITicketService GetTicketService(TicketTypeEnum type);
    }
}
