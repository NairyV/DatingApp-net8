namespace API.Entities;

public class AppUser
{
    //? = optional. e.g. public string? UserName {get; set;}
    public int Id { get; set; }
    public required string UserName { get; set; }
}
