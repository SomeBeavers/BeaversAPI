namespace BeaversDB.Model;

public class Grade
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public double? TheGrade { get; set; }

    public virtual Club   Club   { get; set; } = null!;
    public virtual Animal Animal { get; set; } = null!;

    public override string ToString()
    {
        return $"Grade : Id = {Id} Grade = {TheGrade}";
    }
}
