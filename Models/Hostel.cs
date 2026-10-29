namespace HostelManagementAPI.Models;

public enum HostelType { Boys, Girls }

public class Hostel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public HostelType Type { get; set; }
    public ICollection<Room> Rooms { get; set; } = new List<Room>();
}
