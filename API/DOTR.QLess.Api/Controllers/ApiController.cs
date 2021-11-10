using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DOTR.QLess.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
        private IMediator _mediator;

        private IConfiguration _configuration;

        public ApiController(IMediator mediator,IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        protected IMediator Mediator
        {
            get
            {
                return _mediator;
            }
        }

        protected IConfiguration Configuration
        {
            get
            {
                return _configuration;
            }
        }

        //protected OkObjectResult OkWithPagingMetadata(IPaginationResult paginationResult)
        //{
        //    Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationResult.PagingMetadata));

        //    return Ok(paginationResult.Data);
        //}
    }
}
