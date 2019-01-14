using Application.DTOs;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodiJobServices.Controllers
{    
    
        [Route("api/[controller]")]
        [Authorize]
        public class UsuarioperfilController : Controller
        {
            IUsuarioperfilService Service;
            public UsuarioperfilController(IUsuarioperfilService service)
            {
                this.Service = service;
            }

            // GET: api/<controller>
            [HttpGet]
            public IList<UsuarioperfilDTO> Get()
            {
                return Service.GetAll();
            }

            // GET api/<controller>/5
            [HttpGet("{UsuperId}")]
            public UsuarioperfilDTO Get(Guid UsuarioperfilId)
            {
                return Service.GetAll().Where(p => p.UsuperId == UsuarioperfilId).FirstOrDefault();
            }


            // POST api/<controller>
            [HttpPost]
            public IActionResult Post([FromBody]UsuarioperfilDTO usuario)
            {
            if (!ModelState.IsValid)
            {
                throw new Exception("Model is not Valid");
            }
            Service.Insert(usuario);
                return Ok(true);
            }

            // PUT api/<controller>/5
            [HttpPut("{UsuperId}")]
            public IActionResult Put(Guid UsuarioperfilId, [FromBody]UsuarioperfilDTO usuario)
            {
                usuario.UsuperId = UsuarioperfilId;
                Service.Insert(usuario);
                return Ok(true);
            }

            // DELETE api/<controller>/5
            [HttpDelete("{UsuperId}")]
            public IActionResult Delete(Guid UsuarioperfilId)
            {
                Service.Delete(UsuarioperfilId);
                return Ok(true);
            }

        }
    
}