using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagement.Data;
using ProjectManagement.Models;
using ProjectManagement.Services;
using System;
using System.Collections.Generic;
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

            var wasTicketDeleted = service.Delete(Guid.Parse("idTest"));

            Assert.IsTrue(wasTicketDeleted);

        }


        public void PrepareDatabase()
        {
            Ticket ticket =  new Ticket()
            {
                Id = Guid.Parse("idTest"),
                Title = "Ticket Teste",

            };


        }




    }
}
