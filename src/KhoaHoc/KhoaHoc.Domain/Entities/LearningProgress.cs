using System.ComponentModel.DataAnnotations.Schema;
using KhoaHoc.Domain.Common;

namespace KhoaHoc.Domain.Entities;

public class LearningProgress : BaseEntity
{
    public int? UserId { get; set; }
    public int RegisterStudyId { get; set; }
    public int? CurrentSubjectId { get; set; }

    public User? User { get; set; }
    public RegisterStudy? RegisterStudy { get; set; }

    [ForeignKey(nameof(CurrentSubjectId))]
    public Subject? Subject { get; set; }
}
