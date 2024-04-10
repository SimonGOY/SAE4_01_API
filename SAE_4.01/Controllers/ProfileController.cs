using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using BCrypt.Net;

namespace SAE_4._01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IConfiguration _config;

        private readonly IDataRepository<Telephone> dataRepositoryTelephone;

        public ProfileController(IConfiguration config, IDataRepository<Telephone> dataRepoTelephone)
        {
            _config = config;
            this.dataRepositoryTelephone = dataRepoTelephone;
        }

        [HttpGet("{clientID}")]
        [Authorize(Policy = Policies.Type0)]
        public async Task<string> GetProfileInfos(int clientID)
        {
            var telephonesResult = await dataRepositoryTelephone.GetAllAsync();

            var telephones = telephonesResult.Value as IEnumerable<Telephone>;

            foreach (Telephone telephone in telephones)
            {
                if(telephone.IdClient == clientID)
                {
                    return telephone.NumTelephone;
                }
            }

            return null;
        }
    }
}
