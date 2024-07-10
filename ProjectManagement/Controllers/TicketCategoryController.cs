using Microsoft.AspNetCore.Mvc;
using ProjectManagement.IServices;

namespace ProjectManagement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TicketCategoryController : Controller
    {
        private IUnitOfWork UnitOfWork;
        public TicketCategoryController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

    }
}
