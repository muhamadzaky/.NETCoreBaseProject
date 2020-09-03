using System.Net;
using AutoMapper;
using Emveep.TalentHunter.API.Controllers.Model;
using Emveep.TalentHunter.API.Data.Interface;
using Emveep.TalentHunter.API.Dtos;
using Emveep.TalentHunter.API.Models.auth;
using Microsoft.AspNetCore.Mvc;

namespace Emveep.TalentHunter.API.Controllers
{
    [Route("/api/TalentHunter")]
    [ApiController]
    public class DefaultTalentHunterRouteController : ControllerBase
    {
        #region Properties
        public TalentHunterResponse talentHunterResp { get; private set; }
        public TalentHunterCreateDtos talentHunterCreateDtos { get; private set; }
        #endregion

        #region Operator        

        private readonly ITalentHunterRepo THRepo;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public DefaultTalentHunterRouteController(ITalentHunterRepo repository, IMapper mapper)
        {
            THRepo = repository;
            _mapper = mapper;
        }

        #endregion

        #region Implementations
            
        [HttpGet]
        public ContentResult Get()
        {
            return new ContentResult {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = "<html><header><title>Welcome! - Emveep Talent Hunter API</title></header><body><h1>Congratulations! You connected to this API.</h1></body></html>"
            };
        }

        [HttpGet("{id}")]
        public ActionResult <TalentHunterDtos> GetProfilebyId(int id) 
        {
            TalentHunterRequest requestDomain;
            requestDomain = MappingRequest(id);
            
            var resultStatus = THRepo.GetProfilebyId(requestDomain);

            if (resultStatus != null)
            {
                return Ok(_mapper.Map<TalentHunterDtos>(resultStatus));
            }
            return NotFound();
        }    

        #endregion

        private TalentHunterRequest MappingRequest(int id)
        {
            TalentHunterRequest requestDomain = new TalentHunterRequest();
            requestDomain.id = id;

            return requestDomain;
        }
    }
}