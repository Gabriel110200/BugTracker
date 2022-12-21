using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagement.Data;
using ProjectManagement.Models;
using ProjectManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class TicketTest
    {
        private ApplicationDbContext context;
        public TicketTest()
        {
            Connect connect = new Connect();
            this.context = connect.CriarContextInMemory();

        }


        [TestMethod]
        public  void  testTicketDelete()
        {
            PrepareDatabase();
            TicketService service = new TicketService(this.context);

             service.Delete(Guid.Parse("idTest"));

            var wasTicketDeleted = this.context.Tickets.Any(x => x.Id == Guid.Parse("idTest"));

            Assert.IsTrue(wasTicketDeleted);

        }


        public void PrepareDatabase()
        {
            Ticket ticket =  new Ticket()
            {
                Id = Guid.Parse("idTest"),
                Title = "Ticket Teste",

            };

            this.context.Tickets.Add(ticket);
            this.context.SaveChangesAsync();

        }




    }
}
