using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data;
using ProjectManagement.IServices;
using System.Reflection;
using System.Linq;
using System;
using ProjectManagement.Models;
using System.Net.Sockets;
using System.Threading.Tasks;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private ITicketService _ticket;
        //private TicketRepository ticketRepository;
        private IUnitOfWork UnitOfWork;

        public TicketController(ITicketService ticket, IUnitOfWork unitOfWork)
        {
            _ticket = ticket;
            UnitOfWork = unitOfWork;
        }

        public static object CriaInstancia(string nome)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetTypes().FirstOrDefault(t => t.Name == nome);

            if (type == null)
            {
                throw new Exception("Tipo de ticket não encontrado");
            }
            return Activator.CreateInstance(type);
        }


        [HttpPost]
        public void Create([FromQuery] string ticketType, Ticket ticket)
        {
            ITicketService ticketService = (ITicketService)CriaInstancia(ticketType);

            ticketService.Create(ticket);

        }


        [HttpGet("GetTickets/{projectId}")]

        public async Task<IActionResult> GetTickets()
        {

            return Ok();
        }


        [HttpGet]
        public double teste(Project project,string ticketType)
        {
            ITicketService ticketService = (ITicketService)CriaInstancia(ticketType);

            var mean = ticketService.UrgentPriorityArithmeticMean(project);

            return mean;

        }

    }
}
