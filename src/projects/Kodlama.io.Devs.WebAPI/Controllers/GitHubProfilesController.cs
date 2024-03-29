﻿using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.GitHubProfiles.Commands.CreateGitHubProfile;
using Kodlama.io.Devs.Application.Features.GitHubProfiles.Commands.DeleteGitHubProfile;
using Kodlama.io.Devs.Application.Features.GitHubProfiles.Commands.UpdateGitHubProfile;
using Kodlama.io.Devs.Application.Features.GitHubProfiles.Dtos;
using Kodlama.io.Devs.Application.Features.GitHubProfiles.Models;
using Kodlama.io.Devs.Application.Features.GitHubProfiles.Queries.GetListGitHub;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubProfilesController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateGitHubProfileCommand createGitHubProfileCommand)
        {
            CreatedGitHubProfileDto result = await Mediator.Send(createGitHubProfileCommand);
            return Created("", result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteGitHubProfileCommand deleteGitHubProfileCommand)
        {
            DeletedGitHubProfileDto result = await Mediator.Send(deleteGitHubProfileCommand);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateGitHubProfileCommand updateGitHubProfileCommand)
        {
            UpdatedGitHubProfileDto result = await Mediator.Send(updateGitHubProfileCommand);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListGitHubProfileQuery getListGitHubProfileQuery = new() { PageRequest = pageRequest };
            GitHubProfileListModel result = await Mediator.Send(getListGitHubProfileQuery);
            return Ok(result);
        }
    }
}
