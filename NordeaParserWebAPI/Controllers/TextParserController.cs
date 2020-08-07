using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NordeaParserWebAPI.Converters;
using NordeaParserWebAPI.Model;

namespace NordeaParserWebAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class TextParserController : ControllerBase
    {

        // GET: api/TextParser/Get/  Mary   had a little  lamb  .  Peter called for the wolf, and Aesop came.
        [Route("[action]/{input}")]
        [HttpGet("{input}", Name = "Get")]
        public IEnumerable<Sentence> Get(string input)
        {
            var sentences = new TextParser().Parse(input);
            return sentences;
        }

        // GET: api/TextParser/GetCSV/  Mary   had a little  lamb  .  Peter called for the wolf, and Aesop came.
        [Route("[action]/{input}")]
        [HttpGet("{input}", Name = "GetCSV")]
        public string GetCSV(string input)
        {
            var sentences = new TextParser().Parse(input); 
            var csvString = new CSVConverter().Convert(sentences);
            return csvString;
        }

        // GET: api/TextParser/GetXML/  Mary   had a little  lamb  .  Peter called for the wolf, and Aesop came.
        [Route("[action]/{input}")]
        [HttpGet("{input}", Name = "GetXML")]
        public string GetXML(string input)
        {
            var sentences = new TextParser().Parse(input);
            var xDocument = new XMLConverter().Convert(sentences);
            var xmlString = $"{xDocument.Declaration}\n{xDocument}";
            return xmlString;
        }
    }
}