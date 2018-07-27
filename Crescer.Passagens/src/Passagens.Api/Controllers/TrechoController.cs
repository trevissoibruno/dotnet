using System.Collections.Generic;
using System.Linq;
using Geolocation;
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
    public class TrechoController : Controller
    { 

        private ITrechoRepository trechoRepository;

        private TrechoService trechoService;
        private ILocalRepository localRepository;

        private PassagensContext contexto;

        public TrechoController(ITrechoRepository trechoRepository,
                                TrechoService trechoService,PassagensContext contexto,
                                ILocalRepository localRepository)
        {
            this.trechoRepository = trechoRepository;
            this.trechoService = trechoService;
            this.localRepository = localRepository;
            this.contexto = contexto;

        }

        
       // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(trechoRepository.ListarTrechos());
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetTrecho")]
        public IActionResult Get(int id)
        {
            var trecho = trechoRepository.Obter(id);
            if(trecho == null)return NotFound();
            return Ok(trecho);
        }

        // POST api/values
        [Authorize(Roles = "Admin"),HttpPost]
        public IActionResult Post([FromBody]TrechoDto trechoRequest)
        {
            var origem = localRepository.Obter(trechoRequest.IdOrigem);
            var destino = localRepository.Obter(trechoRequest.IdDestino);
            var distancia = CalcularDistancia(origem,destino);
            var trecho = new Trecho(origem,destino,distancia);
            var mensagens = trechoService.Validar(trecho);
            if(mensagens.Count() > 0) return NotFound();
            trechoRepository.SalvarTrecho(trecho);
            contexto.SaveChanges();
            return CreatedAtRoute("GetTrecho" ,new {id = trecho.Id},trecho);

        }

        // PUT api/values/5
        [Authorize(Roles = "Admin"),HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TrechoDto trechoRequest)
        {
            var origem = localRepository.Obter(trechoRequest.IdOrigem);
            if(origem == null) return NotFound();
            var destino = localRepository.Obter(trechoRequest.IdDestino);
            if(destino == null) return NotFound();
            var distancia = CalcularDistancia(origem,destino);
            var trecho = new Trecho(origem,destino,distancia);
            var mensagens = trechoService.Validar(trecho);
            if(mensagens.Count() > 0) return BadRequest(mensagens);
            trechoRepository.AtualizarTrecho(id,trecho);
            contexto.SaveChanges();
            return Ok();
        }

        // DELETE api/values/5
        [Authorize(Roles = "Admin"),HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            trechoRepository.DeletarTrecho(id);
            contexto.SaveChanges();
            return Ok();
        }

        private double CalcularDistancia(Local Origem, Local Destino)
        {
            return GeoCalculator.GetDistance(Origem.Latitude, Origem.Longitude, 
            Destino.Latitude, Destino.Longitude, 1);
        }

        

        
    }
}