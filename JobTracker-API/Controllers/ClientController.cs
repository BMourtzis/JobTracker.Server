﻿using System;
using JobTracker_API.Models.Client;
using JobTrackerDomain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace JobTracker_API.Controllers
{
    [Route("client")]
    [Produces("apllication/json")]
    public class ClientController : BaseController
    {
        public ClientController() : base() { }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody]CreateVM model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var client = facade.CreateClient(model.firstname, model.lastname, model.businessName, model.shortname);
                    return new JsonResult(client);
                }
                catch (BusinessRuleException ex)
                {
                    return StatusCode(400, ex);
                }
            }
            else
            {
                return StatusCode(400, ModelState.IsValid);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var client = facade.GetClient(id);
                return new JsonResult(client);
            }
            catch(BusinessRuleException ex)
            {
                return StatusCode(404, ex);
            }
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            try
            {
                var clients = facade.GetClients();
                return new JsonResult(clients);
            }
            catch (BusinessRuleException ex)
            {
                return StatusCode(400, ex);
            }
        }

        [HttpPut]
        [Route("{id}/enable")]
        public IActionResult Enable(Guid id)
        {
            try
            {
                var client = facade.EnableClient(id);
                return new JsonResult(client);
            }
            catch (BusinessRuleException ex)
            {
                return StatusCode(400, ex);
            }
        }

        [HttpPut]
        [Route("{id}/disable")]
        public IActionResult Disable(Guid id)
        {
            try
            {
                var client = facade.DisableClient(id);
                return new JsonResult(client);
            }
            catch (BusinessRuleException ex)
            {
                return StatusCode(400, ex);
            }
        }
    }
}