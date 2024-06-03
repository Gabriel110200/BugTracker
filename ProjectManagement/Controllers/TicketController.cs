using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data;
using ProjectManagement.IServices;
using System.Reflection;
using System.Linq;
using System;
using ProjectManagement.Models;
using System.Net.Sockets;
using System.Threading.Tasks;
using ProjectManagement.Models.Request;
using AutoMapper.Configuration.Annotations;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private ITicketService _ticket;
        private IUnitOfWork UnitOfWork;
        public ITicketRepository TicketRepository { get; }

        public TicketController(ITicketService ticket, IUnitOfWork unitOfWork)
        {
            _ticket = ticket;
            UnitOfWork = unitOfWork;
            this.TicketRepository = this.UnitOfWork.GetTicketRepository();
        }

        public static object CriaInstancia(string nome)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var teste = assembly.GetTypes();

            var type = assembly.GetTypes().FirstOrDefault(t => t.Name == nome);

            if (type == null)
            {
                throw new Exception("Tipo de ticket não encontrado");
            }
            return Activator.CreateInstance(type);
        }


        [HttpPost]
        public void Create([FromQuery] string ticketType, TicketRequest request)
        {

            var ticket = new Ticket()
            {
                Title = request.Title,
                DeadLine = request.DeadLine,
              //  Message = request.Message,
                Priority = request.Priority,
                Status = request.Status,
                Type = request.Type,
                ProjectId_FK = request.ProjectId_FK,
            };

            ITicketService ticketService = (ITicketService)CriaInstancia(ticketType);

            ticketService.Create(ticket);
        }


        [HttpGet("GetTickets/{projectId?}")]

        public async Task<IActionResult> GetTickets(int? projectId = null)
        {

            var projects = await this.TicketRepository.GetAsync();
            return Ok(projects);
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
