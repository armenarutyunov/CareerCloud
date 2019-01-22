﻿using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CareerCloud.WebAPI.Controllers
{
    [RoutePrefix("api/careercloud/security/v1")]
    public class SecurityRoleController : ApiController
    {
        private SecurityRoleLogic logic;
        public SecurityRoleController()
        {
            var repo = new EFGenericRepository<SecurityRolePoco>(false);
            logic = new SecurityRoleLogic(repo);
        }
        [HttpGet]
        [Route("role/{id}")]
        [ResponseType(typeof(SecurityRolePoco))]
        public IHttpActionResult GetSecurityRole(Guid id)
        {
            SecurityRolePoco poco = logic.Get(id);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpGet]
        [Route("role")]
        [ResponseType(typeof(List<SecurityRolePoco>))]
        public IHttpActionResult GetAllSecurityRole()
        {
            List<SecurityRolePoco> pocos = logic.GetAll();
            if (pocos == null)
            {
                return NotFound();
            }
            return Ok(pocos);
        }
        [HttpPost]
        [Route("role")]
        public IHttpActionResult PostSecurityRole([FromBody] SecurityRolePoco[] pocos)
        {
            logic.Add(pocos);
            return Ok();
        }
        [HttpPut]
        [Route("role")]
        public IHttpActionResult PutSecurityRole([FromBody] SecurityRolePoco[] pocos)
        {
            logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        [Route("role")]
        public IHttpActionResult DeleteSecurityRole([FromBody] SecurityRolePoco[] pocos)
        {
            logic.Delete(pocos);
            return Ok();
        }
    }
}
