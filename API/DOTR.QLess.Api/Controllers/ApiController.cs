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

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected IConfiguration Configuration => _configuration ??= HttpContext.RequestServices.GetService<IConfiguration>();

        //protected OkObjectResult OkWithPagingMetadata(IPaginationResult paginationResult)
        //{
        //    Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationResult.PagingMetadata));

        //    return Ok(paginationResult.Data);
        //}
    }
}
