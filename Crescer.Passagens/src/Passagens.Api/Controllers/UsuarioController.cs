using System.Linq;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Passagens.Api.Models.Request;
using Passagens.Api.Models.Response;
using Passagens.Dominio.Contratos;
using Passagens.Dominio.Entidades;
using Passagens.Dominio.Servicos;
using Passagens.Infra;
using System;

namespace Passagens.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {

        private IUsuarioRepository usuarioRepository;

        private UsuarioService usuarioService;
        private IOptions<SecuritySettings> settings;

        private PassagensContext contexto;

        public UsuarioController(IUsuarioRepository usuarioRepository, UsuarioService usuarioService, PassagensContext contexto, IOptions<SecuritySettings> settings)
        {
            this.usuarioRepository = usuarioRepository;
            this.usuarioService = usuarioService;
            this.contexto = contexto;
            this.settings = settings;
        }


        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(usuarioRepository.ListarUsuario());
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetUsuario")]
        public IActionResult Get(int id)
        {
            var usuario = usuarioRepository.Obter(id);
            if (usuario == null) return NotFound();
            UsuarioResponseDto usuarioResponseDto = new UsuarioResponseDto(usuario);
            return Ok(usuarioResponseDto);
        }

        // POST api/values
        [AllowAnonymous,HttpPost]
        public IActionResult Post([FromBody]UsuarioDto usuarioRequest)
        {
            var usuario = MapearDtoParaDominio(usuarioRequest);
            var mensagens = usuarioService.Validar(usuario);
            if (mensagens.Count > 0)
                return BadRequest(mensagens);

            usuarioRepository.SalvarUsuario(usuario);
            contexto.SaveChanges();
            //UsuarioResponseDto usuarioResponseDto = new UsuarioResponseDto(usuario);
            return CreatedAtRoute("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UsuarioDto usuarioRequest)
        {
            var usuario = MapearDtoParaDominio(usuarioRequest);
            var mensagens = usuarioService.Validar(usuario);
            if (mensagens.Count > 0)
                return BadRequest(mensagens);

            usuarioRepository.AtualizarUsuario(id, usuario);
            contexto.SaveChanges();
            return Ok();
        }

        // DELETE api/values/5
        [Authorize(Roles = "Admin"),HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            usuarioRepository.DeletarUsuario(id);
            contexto.SaveChanges();
            return Ok();

        }

        [AllowAnonymous,HttpPost("login")]
        public IActionResult Login([FromBody]LoginDto dadosLogin)
        {
            var usuario = usuarioRepository.ObterUsuarioPorLoginESenha(dadosLogin.Login, dadosLogin.Senha);

            if (usuario == null) return BadRequest("Usuario ou senha inválidos");

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Value.SigningKey));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var role = "";
            if (usuario.IsAdmin)
            {
                role = "Admin";
            }
            else { role = "User"; }
            var token = new JwtSecurityToken(
                claims: new[] {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Role, role),
                },
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signingCredentials);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

        private Usuario MapearDtoParaDominio(UsuarioDto usuarioDto)
        {
            return new Usuario(usuarioDto.Nome, usuarioDto.UltimoNome, usuarioDto.Email, usuarioDto.Login,
                                usuarioDto.Senha, usuarioDto.CPF, usuarioDto.DataDeNascimento);
        }
    }


}