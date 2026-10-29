namespace HostelManagementAPI.Models;

// Join entity: Student <-> Room (many-to-many with extra data)
public class Allocation
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
    public int RoomId { get; set; }
    public Room Room { get; set; } = null!;
    public DateTime CheckIn { get; set; }
    public DateTime? CheckOut { get; set; }
}
