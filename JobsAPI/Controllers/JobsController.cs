using JobsAPI.Entities;
using JobsAPI.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace JobsAPI.Controllers
{
    [ApiController]
    [Route("api/jobs")]
    public class JobsController : ControllerBase
    {
        private readonly JobsDbcontext _context;
        public JobsController(JobsDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var jobs = _context.Jobs.ToList();

            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var job = _context.Jobs.SingleOrDefault(x => x.Id == id);

            if(job == null)
            {
                 return NotFound();
            }

            return Ok(job);
        }

        [HttpPost]
        public IActionResult Post(Job job)
        {
            _context.Jobs.Add(job);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = job.Id }, job);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Job input)
        {
            var job = _context.Jobs.SingleOrDefault(x => x.Id == id);

            if (job == null)
            {
                return NotFound();
            }

            job.Update(input.Title, input.Description, input.Company, input.Location, input.Salary);

            _context.Jobs.Update(job);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var job = _context.Jobs.SingleOrDefault(x => x.Id == id);

            if (job == null)
            {
                return NotFound();
            }

            _context.Jobs.Remove(job);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
