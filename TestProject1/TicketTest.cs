using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectManagement.Controllers;
using ProjectManagement.IServices;
using ProjectManagement.Models;
using System.Threading.Tasks;

[TestClass]
public class TicketControllerTests
{
    [TestMethod]
    public void Create_ValidTicketType_CallsTicketServiceCreate()
    {
        // Arrange
        var ticketServiceMock = new Mock<ITicketService>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var controller = new TicketController(ticketServiceMock.Object, unitOfWorkMock.Object);

        var ticketType = "SomeTicketType";
        var ticket = new Ticket();

        // Act
        controller.Create(ticketType, ticket);

        // Assert
        ticketServiceMock.Verify(ts => ts.Create(ticket), Times.Once);
    }

    [TestMethod]
    public async Task GetTickets_ReturnsOkResult()
    {
        // Arrange
        var ticketServiceMock = new Mock<ITicketService>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var controller = new TicketController(ticketServiceMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await controller.GetTickets();

        // Assert
        Assert.IsInstanceOfType(result, typeof(OkResult));
    }

    [TestMethod]
    public void Teste_ValidTicketType_CallsTicketServiceUrgentPriorityArithmeticMean()
    {
        // Arrange
        var ticketServiceMock = new Mock<ITicketService>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var controller = new TicketController(ticketServiceMock.Object, unitOfWorkMock.Object);

        var project = new Project();
        var ticketType = "SomeTicketType";

        // Act
        var result = controller.teste(project, ticketType);

        // Assert
        ticketServiceMock.Verify(ts => ts.UrgentPriorityArithmeticMean(project), Times.Once);
    }
}
