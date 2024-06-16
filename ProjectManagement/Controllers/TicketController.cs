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
using ProjectManagement.Data.Migrations;
using System.Runtime.CompilerServices;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private IUnitOfWork UnitOfWork;
        public ITicketRepository TicketRepository { get; }
        public ITicketServiceFactory TicketFactory { get; }

        public TicketController(IUnitOfWork unitOfWork, ITicketServiceFactory ticketFactory)
        {
            UnitOfWork = unitOfWork;
            TicketFactory = ticketFactory;
            this.TicketRepository = this.UnitOfWork.GetTicketRepository();
        }



        [HttpPost]
        public async Task<IActionResult> Create(TicketRequest request)
        {

            var ticket = new Ticket()
            {
                Title = request.Title,
                DeadLine = request.DeadLine,
                Description = request.Message,
                Priority = request.Priority,
                Status = request.Status,
                Type = request.Type,
                ProjectId_FK = request.ProjectId_FK,
            };

            var service = this.TicketFactory.GetTicketService(ticket.Type);
            await service.Create(ticket);
            return Ok();

        }


        [HttpGet("GetTickets/{projectId?}")]

        public async Task<IActionResult> GetTickets(int? projectId = null)
        {

            var projects = await this.TicketRepository.GetAsync();
            return Ok(projects);
        }


    }
}
