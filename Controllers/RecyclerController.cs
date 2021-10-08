using Microsoft.AspNetCore.Mvc;
using CSharpRestApi.Services;
using CSharpRestApi.ViewModels;
using System.Threading.Tasks;
using CSharpRestApi.Classes;

namespace CSharpRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecyclerController : ControllerBase
    {
        private readonly DB Context = new();

        [Route("~/api/recycler/status")]
        [HttpGet]
        public ActionResult<RecyclerViewModel> Status()
        {
            Task recyclerTask = RecyclerTaskViewModel.RecyclerTask;

            if(recyclerTask != null && recyclerTask.Status.Equals(TaskStatus.Running))
            {
                return new RecyclerViewModel() { Status = "running" };
            }

            return new RecyclerViewModel() { Status = "not running" };
        }

        [Route("~/api/recycler/process/{days}")]
        [HttpPost]
        public IActionResult Process(int days)
        {
            Task recyclerTask = RecyclerTaskViewModel.RecyclerTask;

            if (recyclerTask == null)
            {
                RecyclerTaskViewModel.RecyclerTask = Task.Run(() => RecyclerService.Process(Context, days));
            }

            return Accepted();
        }
    }
}
