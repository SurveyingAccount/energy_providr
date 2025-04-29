using System.ComponentModel.DataAnnotations.Schema;

public class login_details
{
    public int Id { get; set; }
    public required string Username { get; set; }

    public required string Email { get; set; }
    public required string Password { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}
