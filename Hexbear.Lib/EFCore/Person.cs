using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class Person
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string DisplayName { get; set; }

    public string Avatar { get; set; }

    public bool Banned { get; set; }

    public DateTime Published { get; set; }

    public DateTime? Updated { get; set; }

    public string ActorId { get; set; }

    public string Bio { get; set; }

    public bool? Local { get; set; }

    public string PrivateKey { get; set; }

    public string PublicKey { get; set; }

    public DateTime LastRefreshedAt { get; set; }

    public string Banner { get; set; }

    public bool Deleted { get; set; }

    public string InboxUrl { get; set; }

    public string SharedInboxUrl { get; set; }

    public string MatrixUserId { get; set; }

    public bool Admin { get; set; }

    public bool BotAccount { get; set; }

    public DateTime? BanExpires { get; set; }

    public int InstanceId { get; set; }

    public virtual ICollection<AdminPurgeComment> AdminPurgeComments { get; set; } = new List<AdminPurgeComment>();

    public virtual ICollection<AdminPurgeCommunity> AdminPurgeCommunities { get; set; } = new List<AdminPurgeCommunity>();

    public virtual ICollection<AdminPurgePerson> AdminPurgePeople { get; set; } = new List<AdminPurgePerson>();

    public virtual ICollection<AdminPurgePost> AdminPurgePosts { get; set; } = new List<AdminPurgePost>();

    public virtual ICollection<CommentLike> CommentLikes { get; set; } = new List<CommentLike>();

    public virtual ICollection<CommentReply> CommentReplies { get; set; } = new List<CommentReply>();

    public virtual ICollection<CommentReport> CommentReportCreators { get; set; } = new List<CommentReport>();

    public virtual ICollection<CommentReport> CommentReportResolvers { get; set; } = new List<CommentReport>();

    public virtual ICollection<CommentSaved> CommentSaveds { get; set; } = new List<CommentSaved>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<CommunityBlock> CommunityBlocks { get; set; } = new List<CommunityBlock>();

    public virtual ICollection<CommunityFollower> CommunityFollowers { get; set; } = new List<CommunityFollower>();

    public virtual ICollection<CommunityModerator> CommunityModerators { get; set; } = new List<CommunityModerator>();

    public virtual ICollection<CommunityPersonBan> CommunityPersonBans { get; set; } = new List<CommunityPersonBan>();

    public virtual Instance Instance { get; set; }

    public virtual LocalUser LocalUser { get; set; }

    public virtual ICollection<ModAddCommunity> ModAddCommunityModPeople { get; set; } = new List<ModAddCommunity>();

    public virtual ICollection<ModAddCommunity> ModAddCommunityOtherPeople { get; set; } = new List<ModAddCommunity>();

    public virtual ICollection<ModAdd> ModAddModPeople { get; set; } = new List<ModAdd>();

    public virtual ICollection<ModAdd> ModAddOtherPeople { get; set; } = new List<ModAdd>();

    public virtual ICollection<ModBanFromCommunity> ModBanFromCommunityModPeople { get; set; } = new List<ModBanFromCommunity>();

    public virtual ICollection<ModBanFromCommunity> ModBanFromCommunityOtherPeople { get; set; } = new List<ModBanFromCommunity>();

    public virtual ICollection<ModBan> ModBanModPeople { get; set; } = new List<ModBan>();

    public virtual ICollection<ModBan> ModBanOtherPeople { get; set; } = new List<ModBan>();

    public virtual ICollection<ModFeaturePost> ModFeaturePosts { get; set; } = new List<ModFeaturePost>();

    public virtual ICollection<ModHideCommunity> ModHideCommunities { get; set; } = new List<ModHideCommunity>();

    public virtual ICollection<ModLockPost> ModLockPosts { get; set; } = new List<ModLockPost>();

    public virtual ICollection<ModRemoveComment> ModRemoveComments { get; set; } = new List<ModRemoveComment>();

    public virtual ICollection<ModRemoveCommunity> ModRemoveCommunities { get; set; } = new List<ModRemoveCommunity>();

    public virtual ICollection<ModRemovePost> ModRemovePosts { get; set; } = new List<ModRemovePost>();

    public virtual ICollection<ModTransferCommunity> ModTransferCommunityModPeople { get; set; } = new List<ModTransferCommunity>();

    public virtual ICollection<ModTransferCommunity> ModTransferCommunityOtherPeople { get; set; } = new List<ModTransferCommunity>();

    public virtual PersonAggregate PersonAggregate { get; set; }

    public virtual PersonBan PersonBan { get; set; }

    public virtual ICollection<PersonBlock> PersonBlockPeople { get; set; } = new List<PersonBlock>();

    public virtual ICollection<PersonBlock> PersonBlockTargets { get; set; } = new List<PersonBlock>();

    public virtual ICollection<PersonFollower> PersonFollowerFollowers { get; set; } = new List<PersonFollower>();

    public virtual ICollection<PersonFollower> PersonFollowerPeople { get; set; } = new List<PersonFollower>();

    public virtual ICollection<PersonMention> PersonMentions { get; set; } = new List<PersonMention>();

    public virtual ICollection<PersonPostAggregate> PersonPostAggregates { get; set; } = new List<PersonPostAggregate>();

    public virtual ICollection<PostLike> PostLikes { get; set; } = new List<PostLike>();

    public virtual ICollection<PostRead> PostReads { get; set; } = new List<PostRead>();

    public virtual ICollection<PostReport> PostReportCreators { get; set; } = new List<PostReport>();

    public virtual ICollection<PostReport> PostReportResolvers { get; set; } = new List<PostReport>();

    public virtual ICollection<PostSaved> PostSaveds { get; set; } = new List<PostSaved>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<PrivateMessage> PrivateMessageCreators { get; set; } = new List<PrivateMessage>();

    public virtual ICollection<PrivateMessage> PrivateMessageRecipients { get; set; } = new List<PrivateMessage>();

    public virtual ICollection<PrivateMessageReport> PrivateMessageReportCreators { get; set; } = new List<PrivateMessageReport>();

    public virtual ICollection<PrivateMessageReport> PrivateMessageReportResolvers { get; set; } = new List<PrivateMessageReport>();

    public virtual ICollection<RegistrationApplication> RegistrationApplications { get; set; } = new List<RegistrationApplication>();

    public virtual ICollection<BanId> Bids { get; set; } = new List<BanId>();
}
