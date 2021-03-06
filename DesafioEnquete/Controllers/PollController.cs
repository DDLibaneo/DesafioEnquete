﻿using System;
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
using DesafioEnquete.Dtos.DtoIn;

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
            var polls = await _context.Polls
                .Include(p => p.Options)
                .ToListAsync();

            var pollsDtos = polls.Select(_mapper.Map<Poll, PollDtoOut>);

            return Ok(pollsDtos);
        }

        // GET: api/Poll/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PollDtoOut>> GetPoll(int id)
        {
            var poll = await _context.Polls
                .Include(p => p.Options)
                .SingleOrDefaultAsync(p => p.Id == id);

            if (poll == null)
                return NotFound();

            RegisterVisualisation(poll);

            var pollDto = _mapper.Map<Poll, PollDtoOut>(poll);

            return pollDto;
        }

        // POST: api/Poll
        [HttpPost]
        public async Task<ActionResult<PollDtoOut>> CreatePoll(PollDtoIn pollDtoIn)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var poll = _mapper.Map<PollDtoIn, Poll>(pollDtoIn);

            _context.Polls.Add(poll);
            await _context.SaveChangesAsync();

            var pollDtoOut = _mapper.Map<Poll, PollDtoOut>(poll);

            return CreatedAtAction("GetPoll", new { id = pollDtoOut.Id }, pollDtoOut);
        }

        // DELETE: api/Poll/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoll(int id)
        {
            var poll = await _context.Polls.SingleOrDefaultAsync(p => p.Id == id);

            if (poll == null)
                return NotFound();

            _context.Polls.Remove(poll);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // POST: api/Poll/Vote       
        [HttpPost("{id}/Vote")]
        public async Task<IActionResult> Vote(int id)
        {
            var option = await _context.Options
                .SingleOrDefaultAsync(o => o.Id == id);

            if (option == null)
                return NotFound();

            option.Votes++;
            await _context.SaveChangesAsync();

            var optionVoteDtoOut = _mapper.Map<Option, OptionDtoOut>(option);

            return Ok(optionVoteDtoOut);
        }

        // GET: api/Poll/5/Stats
        [HttpGet("{id}/Stats")]
        public async Task<IActionResult> Stats(int id)
        {
            var poll = await _context.Polls
                .Include(p => p.Options)
                .SingleOrDefaultAsync(p => p.Id == id);

            if (poll == null)
                return NotFound();

            var statsDtoOut = _mapper.Map<Poll, StatsDtoOut>(poll);

            return Ok(statsDtoOut);
        }

        public async void RegisterVisualisation(Poll poll)
        {
            poll.Views++;
            await _context.SaveChangesAsync();
        }
    }
}
