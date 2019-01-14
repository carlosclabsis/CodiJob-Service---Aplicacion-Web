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
    public class GrupoController : Controller
    {
        IGrupoService service;
        public GrupoController(IGrupoService service)
        {
            this.service = service;
        }

        // GET: api/<controller>
        [HttpGet]
        public IList<GrupoDTO> Get()
        {
            return service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{GrupoId}")]
        public GrupoDTO Get(Guid GrupoId)
        {
            return service.GetAll().Where(p => p.Id == GrupoId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]GrupoDTO grupo)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Model is not Valid");
            }
            service.Insert(grupo);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{GrupoId}")]
        public IActionResult Put(Guid GrupoId, [FromBody]GrupoDTO grupo)
        {
            grupo.Id = GrupoId;
            service.Insert(grupo);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{GrupoId}")]
        public IActionResult Delete(Guid GrupoId)
        {
            service.Delete(GrupoId);
            return Ok(true);
        }

       

    }
}
