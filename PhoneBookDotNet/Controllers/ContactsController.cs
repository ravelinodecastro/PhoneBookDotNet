using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBookDotNet.Service;
using PhoneBookDotNet.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookDotNet.Controllers
{
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IContactService _service;

        public ContactsController(ILogger<ContactsController> logger, IContactService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("pinguito")]
        public IActionResult Ping()
        {
            return Ok("Pinguei");
        }

        [HttpGet("contacts")]
        public IActionResult Get(string search = null)
        {
            var result = _service.Index(search);
            return Ok(result);
        }
        [HttpGet("contact/{id}")]
        public IActionResult Show(int id)
        {
            var result = _service.Show(id);
            return Ok(result);
        }

        [HttpPost ("contact")]
        public IActionResult Create(ContactDTO dto)
        {
            var result = _service.Create(dto);
            return Ok(result);
        }

        [HttpPut("contact")]
        public IActionResult Update(ContactDTO dto)
        {
            var result = _service.Update(dto);
            return Ok(result);
        }

        [HttpDelete("contact/{id}")]
        public IActionResult Destroy(int id)
        {
            var result = _service.Destroy(id);
            return Ok(result);
        }

    }
}
