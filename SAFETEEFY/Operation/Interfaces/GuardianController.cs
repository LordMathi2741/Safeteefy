
using BasePlatform.API.Operation.Domain.Model.Queries;
using BasePlatform.API.Operation.Domain.Services;
using BasePlatform.API.Operation.Interfaces.Resources;
using BasePlatform.API.Operation.Interfaces.Tranform;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasePlatform.API.Operation.Interfaces;

[ApiController]
[AllowAnonymous]
[Route("api/v1/[controller]")]
[ProducesResponseType(500)]
[ProducesResponseType(400)]
public class GuardianController(
    IGuardianCommandService guardianCommandService,
    IGuardianQueryService guardianQueryService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreateGuardian([FromBody] CreateGuardianResource createGuardianResource)
    {
        var command = CreateGuardianCommandFromResourceAssembler.ToCommandFromResource(createGuardianResource);
        var guardian = await guardianCommandService.Handle(command);
        var guardianResource = GuardianResourceFromEntityAssembler.ToResourceFromEntity(guardian);
        return StatusCode(201, guardianResource);
    }

    [HttpPost("{guardianId:int}/urgencies")]
    public async Task<IActionResult> AddUrgencyToGuardian(int guardianId,
        [FromBody] AddUrgencyToGuardianResource addUrgencyToGuardianResource)
    {
        var command = AddUrgencyToGuardianCommandFromResourceAssembler.ToCommandFromResource(guardianId,
            addUrgencyToGuardianResource);
        var urgency = await guardianCommandService.Handle(command);
        var urgencyResource = UrgencyResourceFromEntityAssembler.ToResourceFromEntity(urgency);
        return StatusCode(201, urgencyResource);
    }

    [HttpGet("{guardianId:int}/urgencies")]
    public async Task<IActionResult> GetAllUrgenciesByGuardianId(int guardianId)
    {
        var query = new GetAllUrgenciesByGuardianIdQuery(guardianId);
        var urgencies = await guardianQueryService.Handle(query);
        var urgencyResource = urgencies.Select(UrgencyResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(urgencyResource);
    }
    
    [HttpGet("/urgencies")]
    public async Task<IActionResult> GetAllUrgencies()
    {
        var query = new GetAllUrgenciesQuery();
        var urgencies = await guardianQueryService.Handle(query);
        var urgencyResource = urgencies.Select(UrgencyResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(urgencyResource);
    }

    [HttpDelete("{urgencyId:int}/urgencies")]
    public async Task<IActionResult> DeleteUrgencyFromGuardian(int urgencyId)
    {
        var deleteUrgencyFromGuardianResource = new DeleteUrgencyFromGuardianResource(urgencyId);
        var command = DeleteUrgencyFromGuardianCommandFromResourceAssembler.ToCommandFromResource(deleteUrgencyFromGuardianResource);
        var urgency = await guardianCommandService.Handle(command);
        var urgencyResource = UrgencyResourceFromEntityAssembler.ToResourceFromEntity(urgency);
        return Ok(urgencyResource);
    }
    
    [HttpPut("{urgencyId:int}/urgencies")]
    public async Task<IActionResult> UpdateUrgencyFromGuardian(int urgencyId, [FromBody] UpdateUrgencyFromGuardianResource updateUrgencyFromGuardianResource)
    {
        var command = UpdateUrgencyFromGuardianCommandFromResourceAssembler.ToCommandFromResource(urgencyId, updateUrgencyFromGuardianResource);
        var urgency = await guardianCommandService.Handle(command);
        var urgencyResource = UrgencyResourceFromEntityAssembler.ToResourceFromEntity(urgency);
        return Ok(urgencyResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllGuardians()
    {
        var query = new GetAllGuardiansQuery();
        var guardians = await guardianQueryService.Handle(query);
        var guardianResource = guardians.Select(GuardianResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(guardianResource);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteGuardian(int id)
    {
        var deleteGuardianResource = new DeleteGuardianResource(id);
        var command = DeleteGuardianCommandFromResourceAssembler.ToCommandFromResource(deleteGuardianResource);
        var guardian = await guardianCommandService.Handle(command);
        var guardianResource = GuardianResourceFromEntityAssembler.ToResourceFromEntity(guardian);
        return Ok(guardianResource);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetGuardianById(int id)
    {
        var query = new GetGuardianByIdQuery(id);
        var guardian = await guardianQueryService.Handle(query);
        var guardianResource = GuardianResourceFromEntityAssembler.ToResourceFromEntity(guardian);
        return Ok(guardianResource);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateGuardian(int id, [FromBody] UpdateGuardianResource updateGuardianResource)
    {
        var command = UpdateGuardianCommandFromResourceAssembler.ToCommandFromResource(id, updateGuardianResource);
        var guardian = await guardianCommandService.Handle(command);
        var guardianResource = GuardianResourceFromEntityAssembler.ToResourceFromEntity(guardian);
        return Ok(guardianResource);
    }

}