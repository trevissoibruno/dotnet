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
    public class OpcionalController : Controller
    {
        private IOpcionalRepository opcionalRepository;

        private OpcionalService opcionalService;

        private PassagensContext contexto;

        public OpcionalController(IOpcionalRepository opcionalRepository,OpcionalService opcionalService,PassagensContext contexto)
        {
            this.opcionalRepository = opcionalRepository;
            this.opcionalService = opcionalService;
            this.contexto = contexto;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(opcionalRepository.ListarOpcionais());     
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetOpcional")]
        public IActionResult Get(int id)
        {
            var opcional = opcionalRepository.Obter(id);
            if(opcional == null) return BadRequest();
            return Ok(opcional);
        }

        // POST api/values
        [Authorize(Roles = "Admin"),HttpPost]
        public IActionResult Post([FromBody]OpcionalDto opcionalRequest)
        {
            var opcional = MapearParaDominio(opcionalRequest);
            var mensagens = opcionalService.Validar(opcional);
            if(mensagens.Count() > 0) BadRequest(mensagens);
            opcionalRepository.SalvarOpcional(opcional);
            contexto.SaveChanges();
            return CreatedAtRoute("GetOpcional", new {id = opcional.Id}, opcional);
        }

        // PUT api/values/5
        [Authorize(Roles = "Admin"),HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]OpcionalDto opcionalRequest)
        {
            var opcional = MapearParaDominio(opcionalRequest);
            var mensagens = opcionalService.Validar(opcional);
            if(mensagens.Count() > 0) return BadRequest(mensagens);
            opcionalRepository.AtualizarOpcional(id,opcional);
            contexto.SaveChanges();
            return Ok();

        }

        // DELETE api/values/5
        [Authorize(Roles = "Admin"),HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            opcionalRepository.DeletarOpcional(id);
            contexto.SaveChanges();
            return Ok();
        }

        private Opcional MapearParaDominio(OpcionalDto opcionalDto)
        {
            return new Opcional(opcionalDto.Nome,opcionalDto.Descricao,opcionalDto.Porcentagem);
        }
    }
}