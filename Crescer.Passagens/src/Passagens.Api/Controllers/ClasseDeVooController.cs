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
    public class ClasseDeVooController : Controller
    {
    private IClasseDeVooRepository classeDeVooRepository;

    private ClasseDeVooService classeDeVooService;
    private PassagensContext contexto;

    public ClasseDeVooController(IClasseDeVooRepository classeDeVooRepository, ClasseDeVooService classeDeVooService, PassagensContext contexto)
    {
        this.classeDeVooRepository = classeDeVooRepository;
        this.classeDeVooService = classeDeVooService;
        this.contexto = contexto;
    }
        
         // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(classeDeVooRepository.ListarClassesDeVoo());
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetClasseDeVoo")]
        public IActionResult Get(int id)
        {
            var classe = classeDeVooRepository.Obter(id);
            if(classe == null) return NotFound();
            return Ok();
        }

        // POST api/values
        [Authorize(Roles = "Admin"),HttpPost]
        public IActionResult Post([FromBody]ClasseDeVooDto classeDeVooRequest)
        {
            var classe  = MapearDtoParaDominio(classeDeVooRequest);
            var mensagens = classeDeVooService.Validar(classe);
            if(mensagens.Count() > 0)return BadRequest(mensagens);
            classeDeVooRepository.SalvarClasseDeVoo(classe);
            contexto.SaveChanges();
            return CreatedAtRoute("GetClasseDeVoo" ,new {id = classe.Id},classe);

        }


        // PUT api/values/5
        [Authorize(Roles = "Admin"),HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ClasseDeVooDto classeResquest)
        {
            var classe = MapearDtoParaDominio(classeResquest);
            var mensagens = classeDeVooService.Validar(classe);
            if(mensagens.Count() > 0) return BadRequest(mensagens);
            classeDeVooRepository.AtualizarClasseDeVoo(id,classe);
            contexto.SaveChanges();
            return Ok();
        }

        // DELETE api/values/5
        [Authorize(Roles = "Admin"),HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            classeDeVooRepository.DeletarClasseDeVoo(id);
            contexto.SaveChanges();
            return Ok();
        }

        private ClasseDeVoo MapearDtoParaDominio(ClasseDeVooDto classe)
        {
            return new ClasseDeVoo (classe.Descricao ,classe.ValorFixo,classe.ValorPorMilha);
        }
    }
}