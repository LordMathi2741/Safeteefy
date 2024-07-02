using System.ComponentModel.DataAnnotations;
using BasePlatform.API.Operation.Domain.Model.Commands;
using BasePlatform.API.Operation.Domain.Model.Entities;

namespace BasePlatform.API.Operation.Domain.Model.Aggregates;

public partial class Guardian
{
    public int Id { get; }
    [MaxLength(30)]
    public string Username { get; set; }
    [MaxLength(30)]
    public string FirstName { get; set; }
    [MaxLength(60)]
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string Address { get; set; }
    
    public ICollection<Urgency> Urgencies { get; set; }
}

public partial class Guardian
{
    public Guardian()
    {
        Username = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        Gender = string.Empty;
        Address = string.Empty;
        Urgencies = new List<Urgency>();
        
    }
    public Guardian(CreateGuardianCommand command)
    {
        Username = command.Username;
        FirstName = command.FirstName;
        LastName = command.LastName;
        Gender = command.Gender;
        Address = command.Address;
        Urgencies = new List<Urgency>();
        
    }
}