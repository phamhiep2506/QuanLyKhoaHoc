using System.ComponentModel.DataAnnotations.Schema;
using KhoaHoc.Domain.Common;

namespace KhoaHoc.Domain.Entities;

public class RegisterStudy : BaseEntity
{
    public int UserId { get; set; }
    public int CourseId { get; set; }
    public int CurrentSubjectId { get; set; }
    public bool IsFinished { get; set; }
    public DateTime RegisterTime { get; set; }
    public int PercentComplete { get; set; }
    public DateTime DoneTime { get; set; }
    public bool IsActive { get; set; }

    public User? User { get; set; }
    [ForeignKey(nameof(CurrentSubjectId))]
    public Subject? Subject { get; set; }
    public ICollection<LearningProgress>? LearningProgresses { get; set; }
}
