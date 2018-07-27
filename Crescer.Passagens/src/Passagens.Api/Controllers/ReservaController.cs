using System.Collections.Generic;
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
    public class ReservaController : Controller
    {
        private IReservaRepository reservaRepository;

        private ReservaService reservaService;

        private IOpcionalRepository opcionalRepository;
        
        private ITrechoRepository trechoRepository;

        private IClasseDeVooRepository classeDeVooRepository;

        private IUsuarioRepository usuarioRepository;

        private PassagensContext contexto;

        public ReservaController(IReservaRepository reservaRepository, ReservaService reservaService,
                                    IOpcionalRepository opcionalRepository,ITrechoRepository trechoRepository,
                                    IClasseDeVooRepository classeDeVooRepository, PassagensContext contexto,
                                    IUsuarioRepository usuarioRepository)
        {
            this.reservaRepository = reservaRepository;
            this.reservaService =reservaService;
            this.opcionalRepository = opcionalRepository;
            this.trechoRepository = trechoRepository;
            this.classeDeVooRepository = classeDeVooRepository;
            this.usuarioRepository = usuarioRepository;
            this.contexto = contexto;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(reservaRepository.ListarReservas());
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetReserva")]
        public IActionResult Get(int id)
        {
            var reserva = reservaRepository.Obter(id);
            if (reserva == null) return BadRequest();
            return Ok(reserva);

        }

        // POST api/values
        [Authorize(Roles = "User"),HttpPost]
        public IActionResult Post([FromBody]ReservaDto reservaDto)
        {
            var trecho = trechoRepository.Obter(reservaDto.IdTrecho);
            if(trecho == null) return BadRequest();
            var classeDeVoo = classeDeVooRepository.Obter(reservaDto.IdClasseDeVoo);
            if(classeDeVoo == null) return BadRequest();
            List<Opcional> opcionais = new List<Opcional>();
            var usuario = usuarioRepository.Obter(reservaDto.IdUsuario);
            foreach (var item in reservaDto.IdOpcionais)
            {
                var opcionalCadastrado = opcionalRepository.Obter(item);
                if(opcionalCadastrado == null) return BadRequest();
                opcionais.Add(opcionalCadastrado);

            }

            var reserva = new Reserva (trecho,classeDeVoo,opcionais,usuario);
            reserva.ValorTotalDoVoo = reserva.ValorTotal();
            reservaRepository.SalvarReserva(reserva);
            contexto.SaveChanges();
            return  CreatedAtRoute("GetReserva" ,new {id = reserva.Id},reserva);
        }


        // DELETE api/values/5
        [Authorize(Roles = "User"),HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            reservaRepository.DeletarReserva(id);
            contexto.SaveChanges();
            return Ok();
        }



        
    }
}