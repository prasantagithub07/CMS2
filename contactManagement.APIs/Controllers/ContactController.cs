using contactManagement.DomainModels.Entities;
using contactManagement.DomainModels.Models;
using contactManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace contactManagement.APIs.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<ActionResult<Contact>> GetAll()
        {
            //int a = 0, b = 9;
            //int c = b / a;

            return Ok(await _contactService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<ContactModel> Get(int id)
        {
            Contact entity = _contactService.Find(id);

            if(entity == null) return NotFound();

            ContactModel model = new ContactModel();
            model.Id = entity.Id;
            model.FirstName = entity.FirstName;
            model.LastName = entity.LastName;
            model.Email = entity.Email;

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ContactModel model)
        {
            Contact entity = new Contact();
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Email = model.Email;
            await _contactService.Add(entity);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,ContactModel model)
        {

            if (id != model.Id)
                return BadRequest();

            Contact entity = new Contact();
            entity.Id = model.Id;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Email = model.Email;
            await _contactService.Update(entity);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactService.Delete(id);
            return StatusCode(StatusCodes.Status200OK);
        }

    }

}
