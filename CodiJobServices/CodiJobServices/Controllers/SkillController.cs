using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

using Microsoft.AspNetCore.Mvc;
using Application.IServices;
using Application.DTOs;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodiJobServices.Controllers
{
    
    [Route("api/[controller]")]
    [Authorize]
    public class SkillController : Controller
    {
        ISkillService service;
        public SkillController(ISkillService service)
        {
            this.service = service;
        }

        // GET: api/<controller>
        [HttpGet]
        public IList<SkillDTO> Get()
        {
            return service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{SkillId}")]
        public SkillDTO Get(Guid SkillId)
        {
            return service.GetAll().Where(p => p.SkillId == SkillId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]SkillDTO skill)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Model is not Valid");
            }
            service.Insert(skill);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{SkillId}")]
        public IActionResult Put(Guid SkillId, [FromBody]SkillDTO skill)
        {
            skill.SkillId = SkillId;
            service.Insert(skill);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{SkillId}")]
        public IActionResult Delete(Guid SkillId)
        {
            service.Delete(SkillId);
            return Ok(true);
        }

       

    }
}
