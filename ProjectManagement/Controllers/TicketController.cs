using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data;
using ProjectManagement.IServices;
using System.Reflection;
using System.Linq;
using System;
using ProjectManagement.Models;
using System.Net.Sockets;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {

        private IProjectService _project;
        private ITicketService _ticket;
        private readonly ApplicationDbContext _context;

        public TicketController(string nome, ITicketService ticket)
        {
            _ticket = ticket;
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

     

        // POST api/<TicketController>
        [HttpPost]
        public void Create([FromBody] string ticketType, Ticket ticket)
        {
            ITicketService ticketService = (ITicketService)CriaInstancia(ticketType);

            ticketService.Create(ticket);

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
