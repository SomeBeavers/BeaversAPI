namespace BeaversDB.Model;

public class AdditionalInfo
{
    [Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? Comment { get; set; }

    public virtual ICollection<Club>? Clubs { get; set; }
    public virtual ICollection<Grade>? Grades { get; set; }

    public virtual AdditionalInfoDetailed AdditionalInfoDetailed { get; set; }

    public override string ToString()
    {
        return $@"AdditionalInfo: Id = {Id} Comment = {Comment}";
    }
}

public class AdditionalInfoDetailed
{
    [Key]
    public int Id { get; set; }

    public string DetailedSummary { get; set; }

    public override string ToString()
    {
        return $@"AdditionalInfoDetailed: Id = {Id} DetailedSummary = {DetailedSummary}";
    }
}

//public class AdditionalInfoClub
//{
//    public int AdditionalInfoId { get; set; }
//    public int ClubId           { get; set; }

//    public virtual AdditionalInfo AdditionalInfo { get; set; } = null!;
//    public virtual Club           Club           { get; set; } = null!;
//}
