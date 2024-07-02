using BasePlatform.API.Operation.Domain.Model.Aggregates;
using BasePlatform.API.Operation.Domain.Model.Commands;
using BasePlatform.API.Operation.Domain.Model.Entities;
using BasePlatform.API.Operation.Domain.Model.Exceptions;
using BasePlatform.API.Operation.Domain.Repositories;
using BasePlatform.API.Operation.Domain.Services;
using BasePlatform.API.Shared.Domain.Repositories;

namespace BasePlatform.API.Operation.Application.Internal.CommandServices;

public class GuardianCommandService(IUnitOfWork unitOfWork, IGuardianRepository guardianRepository, IUrgencyRepository urgencyRepository) : IGuardianCommandService
{
    public async Task<Guardian?> Handle(CreateGuardianCommand command)
    {
        var guardian = new Guardian(command);
        var urgency = await urgencyRepository.FindByIdAsync(command.UrgencyId);
        guardian.Urgencies.Add(urgency);
        if (command.FirstName.Length <= 0 || command.LastName.Length <= 0)
        {
            throw new FirstNameAndLastNameMustBeRequiredException();
        }

        await guardianRepository.AddAsync(guardian);
        await unitOfWork.CompleteAsync();
        return guardian;
    }

    public async Task<Urgency?> Handle(AddUrgencyToGuardianCommand command)
    {
        var guardian = await guardianRepository.FindByIdAsync(command.GuardianId);
        if (guardian == null) throw new GuardianNotFoundException();
        var urgency = new Urgency(command.Title, command.Summary, command.Latitude, command.Longitude);
        if (urgencyRepository.ExistsByTtleAndGeolocationAtTheSameTime(command.Title, command.Latitude, command.Longitude,urgency.ReportedAt))
        {
            throw new UrgencyWithThisTitleAlreadyExistsInThisGeolocationAtTheSameTimeException();
        }
        guardian.Urgencies.Add(urgency);
        await unitOfWork.CompleteAsync();
        return urgency;
    }

    public async Task<Guardian?> Handle(UpdateGuardianCommand command)
    {
        var guardian = await guardianRepository.FindByIdAsync(command.Id);
        if (guardian == null) throw new GuardianNotFoundException();
        guardian.FirstName = command.FirstName;
        guardian.LastName = command.LastName;
        guardian.Address = command.Address;
        guardian.Gender = command.Gender;
        guardian.Username = command.Username;
        guardianRepository.Update(guardian);
        await unitOfWork.CompleteAsync();
        return guardian;
    }

    public async Task<Guardian?> Handle(DeleteGuardianCommand command)
    {
       var guardian = await guardianRepository.FindByIdAsync(command.Id);
       var urgencies = await urgencyRepository.FindUrgenciesByGuardianId(command.Id);
       foreach (var urgency in urgencies)
       {
           urgencyRepository.Remove(urgency);
       }

       if (guardian == null) throw new GuardianNotFoundException();
       guardianRepository.Remove(guardian);
       await unitOfWork.CompleteAsync();
       return guardian;
    }

    public async Task<Urgency?> Handle(DeleteUrgencyFromGuardianCommand command)
    {
        var urgency = await urgencyRepository.FindByIdAsync(command.Id);
        if (urgency != null)
        {
            var guardian = await guardianRepository.FindByIdAsync(urgency.GuardianId);
            guardian?.Urgencies.Remove(urgency);
        }

        if (urgency == null) throw new UrgencyNotFoundException();
        urgencyRepository.Remove(urgency);
        await unitOfWork.CompleteAsync();
        return urgency;
    }

    public async Task<Urgency?> Handle(UpdateUrgencyFromGuardianCommand command)
    {
        var urgency = await urgencyRepository.FindByIdAsync(command.Id);
        var guardian = await guardianRepository.FindByIdAsync(urgency.GuardianId);
        if (urgency == null) throw new UrgencyNotFoundException();
        guardian?.Urgencies.Remove(urgency);
        urgency.Title = command.Title;
        urgency.Summary = command.Summary;
        urgency.Latitude = command.Latitude;
        urgency.Longitude = command.Longitude;
        urgencyRepository.Update(urgency);
        guardian?.Urgencies.Add(urgency);
        await unitOfWork.CompleteAsync();
        return urgency;
    }
}