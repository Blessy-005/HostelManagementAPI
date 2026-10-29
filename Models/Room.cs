namespace HostelManagementAPI.Models;

public class Room
{
    public int Id { get; set; }
    public string RoomNumber { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public int HostelId { get; set; }
    public Hostel Hostel { get; set; } = null!;
    public ICollection<Allocation> Allocations { get; set; } = new List<Allocation>();
}
