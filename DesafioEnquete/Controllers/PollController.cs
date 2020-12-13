using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DesafioEnquete.Models;
using AutoMapper;
using DesafioEnquete.Dtos.DtoOut;
using DesafioEnquete.Dtos;

namespace DesafioEnquete.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        private readonly IMapper _mapper;

        public PollController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Poll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PollDtoOut>>> GetPolls()
        {
            var polls = await _context.Polls.ToListAsync();

            var pollsDtos = polls.Select(_mapper.Map<Poll, PollDtoOut>);

            return Ok(pollsDtos);
        }

        // GET: api/Poll/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PollDtoOut>> GetPoll(int id)
        {
            //var poll = await _context.Polls.FindAsync(id);
            var poll = await _context.Polls.SingleOrDefaultAsync(p => p.Id == id);

            if (poll == null)
                return NotFound();

            var pollDto = _mapper.Map<Poll, PollDtoOut>(poll);

            return pollDto;
        }

        // PUT: api/Poll/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoll(int id, PollDtoIn pollDtoIn)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var poll = await _context.Polls.SingleOrDefaultAsync(p => p.Id == id);

            if (poll == null)
                return NotFound();

            _mapper.Map(pollDtoIn, poll);

            await _context.SaveChangesAsync();

            var pollDtoOut = _mapper.Map<Poll, PollDtoOut>(poll);

            return Ok(pollDtoOut);
        }

        // POST: api/Poll
        [HttpPost]
        public async Task<ActionResult<PollDtoOut>> PostPoll(PollDtoIn pollDtoIn)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var poll = _mapper.Map<PollDtoIn, Poll>(pollDtoIn);            

            _context.Polls.Add(poll);
            await _context.SaveChangesAsync();

            var pollDtoOut = _mapper.Map<Poll, PollDtoOut>(poll);

            return CreatedAtAction("GetPoll", new { id = poll.Id }, poll);
        }

        // DELETE: api/Poll/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Poll>> DeletePoll(int id)
        {
            var poll = await _context.Polls.FindAsync(id);
            if (poll == null)
            {
                return NotFound();
            }

            _context.Polls.Remove(poll);
            await _context.SaveChangesAsync();

            return poll;
        }

        private bool PollExists(int id)
        {
            return _context.Polls.Any(e => e.Id == id);
        }
    }
}
