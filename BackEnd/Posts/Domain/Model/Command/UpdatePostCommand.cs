namespace BackEnd.Posts.Domain.Model.Command;

public record UpdatePostCommand(
    int? dishId = null,
    DateTime? publishDate = null,
    int? stock = null)
{
    internal int PostId { get; init; }
};