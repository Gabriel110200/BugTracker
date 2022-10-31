using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data;
using ProjectManagement.Data.Migrations;
using ProjectManagement.IServices;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProjectManagement.Services
{
    public class ProjectServices : IProjectService
    {

        private readonly ApplicationDbContext _context;


        public ProjectServices(ApplicationDbContext context)
        {

            _context = context;


        }

        public async Task<bool> Create(Project project, Guid CompanyId)
        {
            if (this._context.Projects.Any(x => x.Name == x.Name))
                throw new Exception("Current Project was already registered");


           

            this._context.Projects.Add(project);

            await this._context.SaveChangesAsync();

            return true;
        }

        public bool Delete(Guid projectId)
        {

            var company = this._context.Companies.Where(x => x.Id == projectId)
                                                 .FirstOrDefault();

            if (company is null)
                throw new Exception("Company Not found");

            this._context.Companies.Remove(company);

            this._context.SaveChanges();

            return true;
        }


       public Dictionary<string,double> UrgentPriorityArithmeticMean(Project project)
       {

            var tickets = project.Tickets;

            var ActiveTickets = this._context.Tickets.Where(x => x.ProjectId_FK == project.Id && x.Status == Enum.TicketStatusEnum.Ready);

            var urgentPriorityTicketsNumber = 0.0;
            var highPriorityTicketsNumber = 0.0;
            var mediumPriorityTicketsNumber = 0.0;
            var lowPriorityTicketsNumber = 0.0;

            Dictionary<string, double> dict = new Dictionary<string, double>();


            for (var i=0;i<tickets.Count;i++)
            {

                if (tickets[i].Priority == Enum.TicketPriority.Urgent)
                {
                    urgentPriorityTicketsNumber++;

                }

                if (tickets[i].Priority == Enum.TicketPriority.High)
                {
                    highPriorityTicketsNumber++; 

                }

                if (tickets[i].Priority == Enum.TicketPriority.Medium)
                {
                    mediumPriorityTicketsNumber++; 
                }


                if (tickets[i].Priority == Enum.TicketPriority.Low)
                {
                    lowPriorityTicketsNumber++; 
                }

            }


            var urgentMean = urgentPriorityTicketsNumber / tickets.Count;
            var highMean = highPriorityTicketsNumber / tickets.Count;
            var mediumMean = mediumPriorityTicketsNumber / tickets.Count;
            var lowMean = lowPriorityTicketsNumber / tickets.Count;



            dict.Add("Urgentes", urgentMean);
            dict.Add("Alta prioridade", urgentMean);
            dict.Add("Média prioridade ", urgentMean);
            dict.Add("Baixa prioridade", urgentMean);



            return dict; 

       }




        public Task<List<Project>> ListAllProjects(Guid CompanyId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Project Project)
        {
            throw new NotImplementedException();
        }
    }
}
