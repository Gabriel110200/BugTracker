using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.IServices;
using ProjectManagement.Models;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImpedimentController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ImpedimentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(Impediment request)
        {
            try
            {

                var repository = unitOfWork.GetGenericRepository<Impediment>();

                await repository.AddAsync(request);
                await repository.CommitAsync();
                return Ok(new { Message = "Impedimento inserido com sucesso", CreatedObject = request });
            }
            catch
            {
                return BadRequest("Não foi possível inserir impedimento");
            }

        }

    }
}
