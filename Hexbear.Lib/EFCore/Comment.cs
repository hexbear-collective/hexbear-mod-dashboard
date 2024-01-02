using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Hexbear.Lib.EFCore;

public partial class Comment
{
    public int Id { get; set; }

    public int CreatorId { get; set; }

    public int PostId { get; set; }

    public string Content { get; set; }

    public bool Removed { get; set; }

    public DateTime Published { get; set; }

    public DateTime? Updated { get; set; }

    public bool Deleted { get; set; }

    public string ApId { get; set; }

    public bool Local { get; set; }

    public bool Distinguished { get; set; }

    public int LanguageId { get; set; }

    public virtual CommentAggregate CommentAggregate { get; set; }

    public virtual ICollection<CommentLike> CommentLikes { get; set; } = new List<CommentLike>();

    public virtual ICollection<CommentReply> CommentReplies { get; set; } = new List<CommentReply>();

    public virtual ICollection<CommentReport> CommentReports { get; set; } = new List<CommentReport>();

    public virtual ICollection<CommentSaved> CommentSaveds { get; set; } = new List<CommentSaved>();

    public virtual Person Creator { get; set; }

    public virtual Language Language { get; set; }

    public virtual ICollection<ModRemoveComment> ModRemoveComments { get; set; } = new List<ModRemoveComment>();

    public virtual ICollection<PersonMention> PersonMentions { get; set; } = new List<PersonMention>();

    public virtual Post Post { get; set; }
}
