namespace juultimesedler_be.DTOs;

public class GetProjectDTO
{
    public int ProjectId { get; set; }
    public string? ProjectName{ get; set; }
    public string? ProjectFullName { get; set; }
    //public string? ContactPerson { get; set; }
}