using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class Post
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Url { get; set; }

    public string Body { get; set; }

    public int CreatorId { get; set; }

    public int CommunityId { get; set; }

    public bool Removed { get; set; }

    public bool Locked { get; set; }

    public DateTime Published { get; set; }

    public DateTime? Updated { get; set; }

    public bool Deleted { get; set; }

    public bool Nsfw { get; set; }

    public string EmbedTitle { get; set; }

    public string EmbedDescription { get; set; }

    public string ThumbnailUrl { get; set; }

    public string ApId { get; set; }

    public bool Local { get; set; }

    public string EmbedVideoUrl { get; set; }

    public int LanguageId { get; set; }

    public bool FeaturedCommunity { get; set; }

    public bool FeaturedLocal { get; set; }

    public virtual ICollection<AdminPurgeComment> AdminPurgeComments { get; set; } = new List<AdminPurgeComment>();

    public virtual ICollection<CommentLike> CommentLikes { get; set; } = new List<CommentLike>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Community Community { get; set; }

    public virtual Person Creator { get; set; }

    public virtual Language Language { get; set; }

    public virtual ICollection<ModFeaturePost> ModFeaturePosts { get; set; } = new List<ModFeaturePost>();

    public virtual ICollection<ModLockPost> ModLockPosts { get; set; } = new List<ModLockPost>();

    public virtual ICollection<ModRemovePost> ModRemovePosts { get; set; } = new List<ModRemovePost>();

    public virtual ICollection<PersonPostAggregate> PersonPostAggregates { get; set; } = new List<PersonPostAggregate>();

    public virtual PostAggregate PostAggregate { get; set; }

    public virtual ICollection<PostLike> PostLikes { get; set; } = new List<PostLike>();

    public virtual ICollection<PostRead> PostReads { get; set; } = new List<PostRead>();

    public virtual ICollection<PostReport> PostReports { get; set; } = new List<PostReport>();

    public virtual ICollection<PostSaved> PostSaveds { get; set; } = new List<PostSaved>();
}
