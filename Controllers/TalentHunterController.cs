using System.Collections.Generic;
using AutoMapper;
using Emveep.TalentHunter.API.Controllers.Model;
using Emveep.TalentHunter.API.Data.Implementations;
using Emveep.TalentHunter.API.Data.Interface;
using Emveep.TalentHunter.API.Dtos;
using Emveep.TalentHunter.API.Models.auth;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Emveep.TalentHunter.API.Controllers
{
    [Route("/api/[controller]/GetProfile")]
    [ApiController]
    public class TalentHunterController : ControllerBase
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

        public TalentHunterController(ITalentHunterRepo repository, IMapper mapper)
        {
            THRepo = repository;
            _mapper = mapper;
        }

        #endregion

        #region Implementations
        
        // GET api/TalentHunter/GetProfile
        [HttpGet]
        public ActionResult <IEnumerable<TalentHunterDtos>> GetProfile()
        {
            var resultStatus = THRepo.GetAllProfile();

            if (resultStatus != null)
            {
                return Ok(_mapper.Map<IEnumerable<TalentHunterDtos>>(resultStatus));
            }
            return NotFound();
        }

        // GET api/TalentHunter/GetProfile/{id}
        [HttpGet("{id}", Name="GetProfilebyId")]
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

        // POST api/TalentHunter/GetProfile
        [HttpPost]
        public ActionResult <TalentHunterCreateDtos> CreateTalentHunter(TalentHunterCreateDtos cdtos)
        {
            this.talentHunterResp = new TalentHunterResponse();

            BaseResponse baseResp = new BaseResponse();
            if (THRepo != null)
            {
                // actual code from tutorial
                var thModel = _mapper.Map<TalentHunters>(cdtos);
                THRepo.CreateTalentHunter(thModel);
                THRepo.SaveChanges();
                var talentHunterDtos = _mapper.Map<TalentHunterDtos>(thModel);
                // actual code from tutorial
            
                baseResp.code = 200;
                baseResp.message = "Success!";

                this.talentHunterResp.Meta = baseResp;
                this.talentHunterResp.Data = talentHunterDtos;

                return Ok(this.talentHunterResp);
            } else {
                this.talentHunterCreateDtos = new TalentHunterCreateDtos();
                baseResp.code = 400;
                baseResp.message = "Failed!";

                this.talentHunterResp.Meta = baseResp;
                
                return BadRequest(this.talentHunterResp);
            }
            // actual code from tutorial
            // return CreatedAtRoute(nameof(GetProfilebyId), new {Id = talentHunterDtos.Id}, talentHunterDtos);
            // actual code from tutorial
        }

        // PUT api/TalentHunter/GetProfile
        [HttpPut("{id}")]
        public ActionResult UpdateTalentHunter(int id, TalentHunterUpdateDtos thUpdateDtos)
        {
            BaseResponse baseResp = new BaseResponse();
            TalentHunterRequest requestDomain;
            requestDomain = MappingRequest(id);
            var currentData = THRepo.GetProfilebyId(requestDomain);
            if (currentData == null)
            {
                baseResp.code = 404;
                baseResp.message = "Not Found!";
                return NotFound(baseResp);
            }

            baseResp.code = 200;
            baseResp.message = "Update " + currentData.name + " Success!";

            _mapper.Map(thUpdateDtos, currentData);
            THRepo.UpdateTalentHunter(currentData);
            THRepo.SaveChanges();
            return Ok(baseResp);
        }

        // PATCH api/TalentHunter/GetProfile/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialTalentHunterUpdate(int id, JsonPatchDocument<TalentHunterUpdateDtos> patchDoc)
        {
            BaseResponse baseResp = new BaseResponse();
            TalentHunterRequest requestDomain;
            requestDomain = MappingRequest(id);
            var currentData = THRepo.GetProfilebyId(requestDomain);
            if (currentData == null)
            {
                baseResp.code = 404;
                baseResp.message = "Not Found!";
                return NotFound(baseResp);
            }
            
            var thToPatch = _mapper.Map<TalentHunterUpdateDtos>(currentData);
            patchDoc.ApplyTo(thToPatch, ModelState);
            if (!TryValidateModel(thToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(thToPatch, currentData);

            THRepo.SaveChanges();

            return Ok();
        }

        // DELETE api/TalentHunter/GetProfile
        [HttpDelete("{id}")]
        public ActionResult DeleteTalentHunter(int id)
        {
            BaseResponse baseResp = new BaseResponse();
            TalentHunterRequest requestDomain;
            requestDomain = MappingRequest(id);
            var currentData = THRepo.GetProfilebyId(requestDomain);
            if (currentData == null)
            {
                baseResp.code = 404;
                baseResp.message = "Not Found!";
                return NotFound(baseResp);
            }

            THRepo.DeleteTalentHunter(currentData);
            THRepo.SaveChanges();

            baseResp.code = 200;
            baseResp.message = "Success Delete " + currentData.name + "!";

            return Ok(baseResp);
        }

        #region Utilities

        private TalentHunterRequest MappingRequest(int id)
        {
            TalentHunterRequest requestDomain = new TalentHunterRequest();
            requestDomain.id = id;

            return requestDomain;
        }

        #endregion

        #endregion
    }
}