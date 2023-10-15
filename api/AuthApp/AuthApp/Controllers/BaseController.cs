using AuthApp.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AuthApp.Controllers
{
    public class BaseController : Controller
    {
        public readonly AuthDBContext context;
        public readonly IMapper mapper;
        public BaseController(AuthDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
    }
}
