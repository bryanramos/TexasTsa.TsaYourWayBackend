using System;
using System.Collections.Generic;
using Algolia.Search.Clients;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TexasTsa.Services.TsaYourWay.Core;
using TexasTsa.Services.TsaYourWay.Core.Models;
using TexasTsa.Services.TsaYourWay.Core.Storage;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatalogManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitiveEventController : ControllerBase
    {
        // GET: api/<CompetitiveEvent>
        [HttpGet]
        public IActionResult Get()
        {
            SqlClient sqlClient = new SqlClient();

            List<CompetitiveEvent> competitiveEvents = sqlClient.GetCompetitiveEvents(
                SqlCommands.GetCompetitiveEvents);

            return Ok(competitiveEvents);
        }

        // GET api/<CompetitiveEvent>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            SqlClient sqlClient = new SqlClient();

            CompetitiveEvent competitiveEvent = sqlClient.GetCompetitiveEvent(
                SqlCommands.GetCompetitiveEvent,
                id);

            if (competitiveEvent == null)
            {
                return NotFound();
            }

            return Ok(JsonConvert.SerializeObject(competitiveEvent));
        }

        // POST api/<CompetitiveEvent>
        [HttpPost]
        public IActionResult Post([FromBody] object content)
        {
            SqlClient sqlClient = new SqlClient();
            SearchClient searchClient = new SearchClient(
                Environment.GetEnvironmentVariable(ServiceConfiguration.AlgoliaAppId),
                Environment.GetEnvironmentVariable(ServiceConfiguration.AdminKey));
            SearchIndex index = searchClient.InitIndex(ServiceConfiguration.SearchIndex);

            CompetitiveEvent competitiveEvent = JsonConvert.DeserializeObject<CompetitiveEvent>(content.ToString());

            competitiveEvent.CreatedTimestamp = competitiveEvent.ModifiedTimestamp = DateTime.Now;
            competitiveEvent.Id = competitiveEvent.ObjectID = Guid.NewGuid().ToString();

            if (Get(competitiveEvent.Id) != null)
            {
                competitiveEvent.Id = competitiveEvent.ObjectID = Guid.NewGuid().ToString();
            }
            competitiveEvent.Version = 1;

            sqlClient.CreateOrInsert(
                SqlCommands.InsertCompetitiveEvent,
                CompetitiveEvent.ToDictionary(competitiveEvent));
            index.SaveObject(
                competitiveEvent,
                autoGenerateObjectId: false);

            return Ok();
        }

        // PUT api/<CompetitiveEvent>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] object content)
        {
            SqlClient sqlClient = new SqlClient();
            SearchClient searchClient = new SearchClient(
                Environment.GetEnvironmentVariable(ServiceConfiguration.AlgoliaAppId),
                Environment.GetEnvironmentVariable(ServiceConfiguration.AdminKey));
            SearchIndex index = searchClient.InitIndex(ServiceConfiguration.SearchIndex);

            if (Get(id) == null)
            {
                return NotFound();
            }

            CompetitiveEvent updatedEvent = JsonConvert.DeserializeObject<CompetitiveEvent>(content.ToString());
            CompetitiveEvent currentEvent = sqlClient.GetCompetitiveEvent(
                SqlCommands.GetCompetitiveEvent,
                id);

            currentEvent = SqlOperations.UpdateCompetitiveEvent(currentEvent, updatedEvent);

            sqlClient.CreateOrInsert(
                SqlCommands.UpdateCompetitiveEvent,
                CompetitiveEvent.ToDictionary(currentEvent));
            index.PartialUpdateObject(
                currentEvent,
                createIfNotExists: false);

            return Ok();
        }

        // DELETE api/<CompetitiveEvent>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            SqlClient sqlClient = new SqlClient();
            SearchClient searchClient = new SearchClient(
                Environment.GetEnvironmentVariable(ServiceConfiguration.AlgoliaAppId),
                Environment.GetEnvironmentVariable(ServiceConfiguration.AdminKey));
            SearchIndex index = searchClient.InitIndex(ServiceConfiguration.SearchIndex);

            if (Get(id) == null)
            {
                return NotFound();
            }

            sqlClient.DeleteCompetitiveEvent(
                SqlCommands.DeleteCompetitiveEvent,
                id);
            index.DeleteObject(
                id);

            return Ok();
        }
    }
}
