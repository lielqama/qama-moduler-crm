using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QamaCoreShared.Attributes.Authorization;

using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using modulercrm.Services;

namespace ModulerCrm.Controllers
{
    /// <summary>
    /// ModulerCrm - Priority Sync Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class WebhooksController : ControllerBase
    {
        private readonly IQamaModulerService _modulerService;

        /// <summary>
        /// DI
        /// </summary>
        /// <param name="modulerService"></param>
        public WebhooksController(IQamaModulerService modulerService)
        {
            _modulerService = modulerService;
        }


        /// <summary>
        /// Sync Customers to moduler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("customers")]
        public async Task<IActionResult> GetCustomer()
        {           
            return Ok(await _modulerService.getCustomer());
        }


        /// <summary>
        /// Sync Product to moduler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("product")]
        public async Task<IActionResult> GetProduct()
        {    
            return Ok(await _modulerService.getProduct());
        }

    }
}