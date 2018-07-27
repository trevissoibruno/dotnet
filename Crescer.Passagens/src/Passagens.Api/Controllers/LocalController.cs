using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Passagens.Api.Models.Request;
using Passagens.Dominio.Contratos;
using Passagens.Dominio.Entidades;
using Passagens.Dominio.Servicos;
using Passagens.Infra;

namespace Passagens.Api.Controllers
{
    [Route("api/[controller]")]
    public class LocalController : Controller
    {
        private ILocalRepository localRepository;
        private LocalService localService;

        private PassagensContext contexto;

        public LocalController(ILocalRepository localRepository,LocalService localService,PassagensContext contexto)
        {
            this.localRepository = localRepository;
            this.localService = localService;
            this.contexto = contexto;
        }
        
    
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(localRepository.ListarLocais());
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetLocal")]
        public IActionResult Get(int id)
        {
            var local = localRepository.Obter(id);
            if(local == null)return NotFound();
            return Ok(local);
        }

        // POST api/values
        [Authorize(Roles = "Admin"),HttpPost]
        public IActionResult Post([FromBody]LocalDto localRequest)
        {
            var local = MapearParaDominio(localRequest);
            var mensagens = localService.Validar(local);
            if(mensagens.Count() > 0) return NotFound();
            localRepository.SalvarLocal(local);
            contexto.SaveChanges();
            return CreatedAtRoute("GetLocal" ,new {id = local.Id},local);

        }

        // PUT api/values/5
        [Authorize(Roles = "Admin"),HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]LocalDto localRequest)
        {
            var local = MapearParaDominio(localRequest);
            var mensagens = localService.Validar(local);
            if(mensagens.Count() > 0) return BadRequest(mensagens);
            localRepository.AtualizarLocal(id,local);
            contexto.SaveChanges();
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            localRepository.DeletarLocal(id);
            contexto.SaveChanges();
            return Ok();
        }

        private Local MapearParaDominio(LocalDto local)
        {
            return new Local (local.Nome,local.Longitude,local.Latitude);
        }
    }
}