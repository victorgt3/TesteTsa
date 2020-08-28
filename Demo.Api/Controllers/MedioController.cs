using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Demo.AutoMapper.ViewModels;
using Demo.Domain.Core.Notifications;
using Demo.Domain.Entitie.Medico.Commands.Medico;
using Demo.Domain.Entitie.Medico.Repository;
using Demo.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [Route("/v1")]
    [ApiController]
    public class MedicoController : BaseController
    {
        private readonly IMedicoRepository _MedicoRepository;
        private readonly IMediatorHandler _mediator;
        private readonly IMapper _mapper;


        public MedicoController(INotificationHandler<DomainNotification> notifications,
            IMedicoRepository MedicoRepository,
            IMediatorHandler mediator,
            IMapper mapper) : base(notifications, mediator)
        {
            _MedicoRepository = MedicoRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Metodo retorna todos os medicos
        /// </summary>
        [HttpGet]
        [Route("medico")]
        public IEnumerable<PostMedicoViewModel> Get()
        {
            try
            {
               var model = new List<PostMedicoViewModel>();

                var medico = _MedicoRepository.GetAll();

                foreach(var item in medico.Result.Medico)
                {
                    var lista = new List<string>();

                    foreach (var esp in medico.Result.Especialidade
                        .Where(e => e.MedicoId == item.Id))
                    {
                        lista.Add(esp.Descricao);
                    }
                    model.Add(new PostMedicoViewModel
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        CPF = item.CPF,
                        Crm = item.Crm,
                        Especialidades = lista
                    });
                }

                return model;
            }
            catch (Exception e)
            {
                StatusCode(500, e.Message);
                throw e;
            }

        }
        /// <summary>
        /// Metodo retorna um medico por id
        /// </summary>
        [HttpGet]
        [Route("medico/{id:guid}")]
        public IEnumerable<PostMedicoViewModel> Get(Guid id)
        {
            try
            {
                var model = new List<PostMedicoViewModel>();

                var medico = _MedicoRepository.GetById(id);

                foreach (var item in medico.Result.Medico)
                {
                    var lista = new List<string>();

                    foreach (var esp in medico.Result.Especialidade
                        .Where(e => e.MedicoId == item.Id))
                    {
                        lista.Add(esp.Descricao);
                    }
                    model.Add(new PostMedicoViewModel
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        CPF = item.CPF,
                        Crm = item.Crm,
                        Especialidades = lista
                    });
                }

                return model;
            }
            catch (Exception e)
            {
                StatusCode(500, e.Message);
                throw e;
            }

        }
        /// <summary>
        /// Metodo retorna medicos por especialidade
        /// </summary>
        [HttpGet]
        [Route("especialidade/{especialidade}")]
        public async Task<IEnumerable<PostMedicoViewModel>> GetEspecialidade(string especialidade)
        {
            try
            {
                var model = new List<PostMedicoViewModel>();

                var medico = await _MedicoRepository.GetByEspecialidade(especialidade);

                foreach(var item in medico)
                {
                    var lista = new List<string>
                    {
                        item.Descricao
                    };
                    model.Add(new PostMedicoViewModel
                    {
                        Id = item.Medico.Id,
                        Nome = item.Medico.Nome,
                        CPF = item.Medico.CPF,
                        Crm = item.Medico.Crm,
                        Especialidades = lista
                    });
                }
                return model;
            }
            catch (Exception e)
            {
                StatusCode(500, e.Message);
                throw e;
            }

        }


        /// <summary>
        /// Metodo cadastra um medico e suas especialidades não e necessario o id.
        /// </summary>
        [HttpPost]
        [Route("medico")]
        public IActionResult Post(PostMedicoViewModel MedicoViewModel)
        {
            try
            {
                var MedicoCommand = _mapper.Map<RegistraMedicoCommand>(MedicoViewModel);
                _mediator.EnviarComando(MedicoCommand);
                return Response(MedicoCommand);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        /// <summary>
        /// Metodo deleta um medico e suas especialidade
        /// </summary>
        [HttpDelete]
        [Route("medico/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var MedicoViewModel = new MedicoViewModel { Id = id };
                var MedicoCommand = _mapper.Map<ExcluirMedicoCommand>(MedicoViewModel);
                _mediator.EnviarComando(MedicoCommand);

                return Ok(MedicoCommand);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
