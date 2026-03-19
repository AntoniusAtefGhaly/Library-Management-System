namespace LMS.Domain.Interfaces;

public interface ISharedColumns
{
    DateTime? InsertedTime { get; set; }
    string? InsertedUserId { get; set; }

    bool IsActive { get; set; }
    DateTime? ActivationTime { get; set; }
    string? ActivationUserId { get; set; }

    DateTime? UpdateTime { get; set; }
    string? UpdateUserId { get; set; }

    bool IsDeleted { get; set; }
    DateTime? DeletedTime { get; set; }
    string? DeletedUserId { get; set; }
}
