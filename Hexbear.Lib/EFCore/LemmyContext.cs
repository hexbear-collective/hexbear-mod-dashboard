using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Hexbear.Lib.EFCore;

public partial class LemmyContext : DbContext
{
    public LemmyContext()
    {
    }

    public LemmyContext(DbContextOptions<LemmyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<AdminPurgeComment> AdminPurgeComments { get; set; }

    public virtual DbSet<AdminPurgeCommunity> AdminPurgeCommunities { get; set; }

    public virtual DbSet<AdminPurgePerson> AdminPurgePeople { get; set; }

    public virtual DbSet<AdminPurgePost> AdminPurgePosts { get; set; }

    public virtual DbSet<BanId> BanIds { get; set; }

    public virtual DbSet<CaptchaAnswer> CaptchaAnswers { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<CommentAggregate> CommentAggregates { get; set; }

    public virtual DbSet<CommentLike> CommentLikes { get; set; }

    public virtual DbSet<CommentReply> CommentReplies { get; set; }

    public virtual DbSet<CommentReport> CommentReports { get; set; }

    public virtual DbSet<CommentSaved> CommentSaveds { get; set; }

    public virtual DbSet<Community> Communities { get; set; }

    public virtual DbSet<CommunityAggregate> CommunityAggregates { get; set; }

    public virtual DbSet<CommunityBlock> CommunityBlocks { get; set; }

    public virtual DbSet<CommunityFollower> CommunityFollowers { get; set; }

    public virtual DbSet<CommunityLanguage> CommunityLanguages { get; set; }

    public virtual DbSet<CommunityModerator> CommunityModerators { get; set; }

    public virtual DbSet<CommunityPersonBan> CommunityPersonBans { get; set; }

    public virtual DbSet<CustomEmoji> CustomEmojis { get; set; }

    public virtual DbSet<CustomEmojiKeyword> CustomEmojiKeywords { get; set; }

    public virtual DbSet<EmailVerification> EmailVerifications { get; set; }

    public virtual DbSet<FederationAllowlist> FederationAllowlists { get; set; }

    public virtual DbSet<FederationBlocklist> FederationBlocklists { get; set; }

    public virtual DbSet<Instance> Instances { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<LocalSite> LocalSites { get; set; }

    public virtual DbSet<LocalSiteRateLimit> LocalSiteRateLimits { get; set; }

    public virtual DbSet<LocalUser> LocalUsers { get; set; }

    public virtual DbSet<LocalUserLanguage> LocalUserLanguages { get; set; }

    public virtual DbSet<ModAdd> ModAdds { get; set; }

    public virtual DbSet<ModAddCommunity> ModAddCommunities { get; set; }

    public virtual DbSet<ModBan> ModBans { get; set; }

    public virtual DbSet<ModBanFromCommunity> ModBanFromCommunities { get; set; }

    public virtual DbSet<ModFeaturePost> ModFeaturePosts { get; set; }

    public virtual DbSet<ModHideCommunity> ModHideCommunities { get; set; }

    public virtual DbSet<ModLockPost> ModLockPosts { get; set; }

    public virtual DbSet<ModRemoveComment> ModRemoveComments { get; set; }

    public virtual DbSet<ModRemoveCommunity> ModRemoveCommunities { get; set; }

    public virtual DbSet<ModRemovePost> ModRemovePosts { get; set; }

    public virtual DbSet<ModTransferCommunity> ModTransferCommunities { get; set; }

    public virtual DbSet<PasswordResetRequest> PasswordResetRequests { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<PersonAggregate> PersonAggregates { get; set; }

    public virtual DbSet<PersonBan> PersonBans { get; set; }

    public virtual DbSet<PersonBlock> PersonBlocks { get; set; }

    public virtual DbSet<PersonFollower> PersonFollowers { get; set; }

    public virtual DbSet<PersonMention> PersonMentions { get; set; }

    public virtual DbSet<PersonPostAggregate> PersonPostAggregates { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<PostAggregate> PostAggregates { get; set; }

    public virtual DbSet<PostLike> PostLikes { get; set; }

    public virtual DbSet<PostRead> PostReads { get; set; }

    public virtual DbSet<PostReport> PostReports { get; set; }

    public virtual DbSet<PostSaved> PostSaveds { get; set; }

    public virtual DbSet<PrivateMessage> PrivateMessages { get; set; }

    public virtual DbSet<PrivateMessageReport> PrivateMessageReports { get; set; }

    public virtual DbSet<RegistrationApplication> RegistrationApplications { get; set; }

    public virtual DbSet<Secret> Secrets { get; set; }

    public virtual DbSet<Site> Sites { get; set; }

    public virtual DbSet<SiteAggregate> SiteAggregates { get; set; }

    public virtual DbSet<SiteLanguage> SiteLanguages { get; set; }

    public virtual DbSet<Tagline> Taglines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("listing_type_enum", new[] { "All", "Local", "Subscribed" })
            .HasPostgresEnum("registration_mode_enum", new[] { "Closed", "RequireApplication", "Open" })
            .HasPostgresEnum("sort_type_enum", new[] { "Active", "Hot", "New", "Old", "TopDay", "TopWeek", "TopMonth", "TopYear", "TopAll", "MostComments", "NewComments", "TopHour", "TopSixHour", "TopTwelveHour", "TopThreeMonths", "TopSixMonths", "TopNineMonths" })
            .HasPostgresExtension("ltree")
            .HasPostgresExtension("pg_stat_statements")
            .HasPostgresExtension("pgcrypto");

        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("activity_pkey");

            entity.ToTable("activity");

            entity.HasIndex(e => e.ApId, "idx_activity_ap_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApId)
                .IsRequired()
                .HasColumnName("ap_id");
            entity.Property(e => e.Data)
                .IsRequired()
                .HasColumnType("jsonb")
                .HasColumnName("data");
            entity.Property(e => e.Local)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("local");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.Sensitive)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("sensitive");
            entity.Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated");
        });

        modelBuilder.Entity<AdminPurgeComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("admin_purge_comment_pkey");

            entity.ToTable("admin_purge_comment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdminPersonId).HasColumnName("admin_person_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("when_");

            entity.HasOne(d => d.AdminPerson).WithMany(p => p.AdminPurgeComments)
                .HasForeignKey(d => d.AdminPersonId)
                .HasConstraintName("admin_purge_comment_admin_person_id_fkey");

            entity.HasOne(d => d.Post).WithMany(p => p.AdminPurgeComments)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("admin_purge_comment_post_id_fkey");
        });

        modelBuilder.Entity<AdminPurgeCommunity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("admin_purge_community_pkey");

            entity.ToTable("admin_purge_community");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdminPersonId).HasColumnName("admin_person_id");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("when_");

            entity.HasOne(d => d.AdminPerson).WithMany(p => p.AdminPurgeCommunities)
                .HasForeignKey(d => d.AdminPersonId)
                .HasConstraintName("admin_purge_community_admin_person_id_fkey");
        });

        modelBuilder.Entity<AdminPurgePerson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("admin_purge_person_pkey");

            entity.ToTable("admin_purge_person");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdminPersonId).HasColumnName("admin_person_id");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("when_");

            entity.HasOne(d => d.AdminPerson).WithMany(p => p.AdminPurgePeople)
                .HasForeignKey(d => d.AdminPersonId)
                .HasConstraintName("admin_purge_person_admin_person_id_fkey");
        });

        modelBuilder.Entity<AdminPurgePost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("admin_purge_post_pkey");

            entity.ToTable("admin_purge_post");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdminPersonId).HasColumnName("admin_person_id");
            entity.Property(e => e.CommunityId).HasColumnName("community_id");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("when_");

            entity.HasOne(d => d.AdminPerson).WithMany(p => p.AdminPurgePosts)
                .HasForeignKey(d => d.AdminPersonId)
                .HasConstraintName("admin_purge_post_admin_person_id_fkey");

            entity.HasOne(d => d.Community).WithMany(p => p.AdminPurgePosts)
                .HasForeignKey(d => d.CommunityId)
                .HasConstraintName("admin_purge_post_community_id_fkey");
        });

        modelBuilder.Entity<BanId>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ban_id_pkey");

            entity.ToTable("ban_id", "hexbear");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.AliasedTo).HasColumnName("aliased_to");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created");

            entity.HasOne(d => d.AliasedToNavigation).WithMany(p => p.InverseAliasedToNavigation)
                .HasForeignKey(d => d.AliasedTo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ban_id_aliased_to_fkey");

            entity.HasMany(d => d.Uids).WithMany(p => p.Bids)
                .UsingEntity<Dictionary<string, object>>(
                    "UserBanId",
                    r => r.HasOne<Person>().WithMany()
                        .HasForeignKey("Uid")
                        .HasConstraintName("user_ban_id_uid_fkey"),
                    l => l.HasOne<BanId>().WithMany()
                        .HasForeignKey("Bid")
                        .HasConstraintName("user_ban_id_bid_fkey"),
                    j =>
                    {
                        j.HasKey("Bid", "Uid").HasName("user_ban_id_pkey");
                        j.ToTable("user_ban_id", "hexbear");
                        j.IndexerProperty<Guid>("Bid").HasColumnName("bid");
                        j.IndexerProperty<int>("Uid").HasColumnName("uid");
                    });
        });

        modelBuilder.Entity<CaptchaAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("captcha_answer_pkey");

            entity.ToTable("captcha_answer");

            entity.HasIndex(e => e.Uuid, "captcha_answer_uuid_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Answer)
                .IsRequired()
                .HasColumnName("answer");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.Uuid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("uuid");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("comment_pkey");

            entity.ToTable("comment");

            entity.HasIndex(e => e.ApId, "idx_comment_ap_id").IsUnique();

            entity.HasIndex(e => e.CreatorId, "idx_comment_creator");

            entity.HasIndex(e => e.LanguageId, "idx_comment_language");

            entity.HasIndex(e => e.PostId, "idx_comment_post");

            entity.HasIndex(e => e.Published, "idx_comment_published").IsDescending();

            //entity.HasIndex(e => e.Path, "idx_path_gist").HasMethod("gist");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApId)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValueSql("generate_unique_changeme()")
                .HasColumnName("ap_id");
            entity.Property(e => e.Content)
                .IsRequired()
                .HasColumnName("content");
            entity.Property(e => e.CreatorId).HasColumnName("creator_id");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.Distinguished).HasColumnName("distinguished");
            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.Local)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("local");
            //entity.Property(e => e.Path)
            //    .HasDefaultValueSql("'0'::ltree")
            //    .HasColumnName("path");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.Removed).HasColumnName("removed");
            entity.Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated");

            entity.HasOne(d => d.Creator).WithMany(p => p.Comments)
                .HasForeignKey(d => d.CreatorId)
                .HasConstraintName("comment_creator_id_fkey");

            entity.HasOne(d => d.Language).WithMany(p => p.Comments)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("comment_language_id_fkey");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("comment_post_id_fkey");
        });

        modelBuilder.Entity<CommentAggregate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("comment_aggregates_pkey");

            entity.ToTable("comment_aggregates");

            entity.HasIndex(e => e.CommentId, "comment_aggregates_comment_id_key").IsUnique();

            entity.HasIndex(e => e.HotRank, "idx_comment_aggregates_hot").IsDescending();

            entity.HasIndex(e => e.Published, "idx_comment_aggregates_published").IsDescending();

            entity.HasIndex(e => e.Score, "idx_comment_aggregates_score").IsDescending();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChildCount).HasColumnName("child_count");
            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.Downvotes).HasColumnName("downvotes");
            entity.Property(e => e.HotRank)
                .HasDefaultValueSql("1728")
                .HasColumnName("hot_rank");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.Upvotes).HasColumnName("upvotes");

            entity.HasOne(d => d.Comment).WithOne(p => p.CommentAggregate)
                .HasForeignKey<CommentAggregate>(d => d.CommentId)
                .HasConstraintName("comment_aggregates_comment_id_fkey");
        });

        modelBuilder.Entity<CommentLike>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("comment_like_pkey");

            entity.ToTable("comment_like");

            entity.HasIndex(e => new { e.CommentId, e.PersonId }, "comment_like_comment_id_person_id_key").IsUnique();

            entity.HasIndex(e => e.CommentId, "idx_comment_like_comment");

            entity.HasIndex(e => e.PersonId, "idx_comment_like_person");

            entity.HasIndex(e => e.PostId, "idx_comment_like_post");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.Score).HasColumnName("score");

            entity.HasOne(d => d.Comment).WithMany(p => p.CommentLikes)
                .HasForeignKey(d => d.CommentId)
                .HasConstraintName("comment_like_comment_id_fkey");

            entity.HasOne(d => d.Person).WithMany(p => p.CommentLikes)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("comment_like_person_id_fkey");

            entity.HasOne(d => d.Post).WithMany(p => p.CommentLikes)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("comment_like_post_id_fkey");
        });

        modelBuilder.Entity<CommentReply>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("comment_reply_pkey");

            entity.ToTable("comment_reply");

            entity.HasIndex(e => new { e.RecipientId, e.CommentId }, "comment_reply_recipient_id_comment_id_key").IsUnique();

            entity.HasIndex(e => e.CommentId, "idx_comment_reply_comment");

            entity.HasIndex(e => e.Published, "idx_comment_reply_published").IsDescending();

            entity.HasIndex(e => e.RecipientId, "idx_comment_reply_recipient");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.Read).HasColumnName("read");
            entity.Property(e => e.RecipientId).HasColumnName("recipient_id");

            entity.HasOne(d => d.Comment).WithMany(p => p.CommentReplies)
                .HasForeignKey(d => d.CommentId)
                .HasConstraintName("comment_reply_comment_id_fkey");

            entity.HasOne(d => d.Recipient).WithMany(p => p.CommentReplies)
                .HasForeignKey(d => d.RecipientId)
                .HasConstraintName("comment_reply_recipient_id_fkey");
        });

        modelBuilder.Entity<CommentReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("comment_report_pkey");

            entity.ToTable("comment_report");

            entity.HasIndex(e => new { e.CommentId, e.CreatorId }, "comment_report_comment_id_creator_id_key").IsUnique();

            entity.HasIndex(e => e.Published, "idx_comment_report_published").IsDescending();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.CreatorId).HasColumnName("creator_id");
            entity.Property(e => e.OriginalCommentText)
                .IsRequired()
                .HasColumnName("original_comment_text");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.Reason)
                .IsRequired()
                .HasColumnName("reason");
            entity.Property(e => e.Resolved).HasColumnName("resolved");
            entity.Property(e => e.ResolverId).HasColumnName("resolver_id");
            entity.Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated");

            entity.HasOne(d => d.Comment).WithMany(p => p.CommentReports)
                .HasForeignKey(d => d.CommentId)
                .HasConstraintName("comment_report_comment_id_fkey");

            entity.HasOne(d => d.Creator).WithMany(p => p.CommentReportCreators)
                .HasForeignKey(d => d.CreatorId)
                .HasConstraintName("comment_report_creator_id_fkey");

            entity.HasOne(d => d.Resolver).WithMany(p => p.CommentReportResolvers)
                .HasForeignKey(d => d.ResolverId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("comment_report_resolver_id_fkey");
        });

        modelBuilder.Entity<CommentSaved>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("comment_saved_pkey");

            entity.ToTable("comment_saved");

            entity.HasIndex(e => new { e.CommentId, e.PersonId }, "comment_saved_comment_id_person_id_key").IsUnique();

            entity.HasIndex(e => e.CommentId, "idx_comment_saved_comment");

            entity.HasIndex(e => e.PersonId, "idx_comment_saved_person");

            entity.HasIndex(e => e.PersonId, "idx_comment_saved_person_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");

            entity.HasOne(d => d.Comment).WithMany(p => p.CommentSaveds)
                .HasForeignKey(d => d.CommentId)
                .HasConstraintName("comment_saved_comment_id_fkey");

            entity.HasOne(d => d.Person).WithMany(p => p.CommentSaveds)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("comment_saved_person_id_fkey");
        });

        modelBuilder.Entity<Community>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("community_pkey");

            entity.ToTable("community");

            entity.HasIndex(e => e.FeaturedUrl, "community_featured_url_key").IsUnique();

            entity.HasIndex(e => e.ModeratorsUrl, "community_moderators_url_key").IsUnique();

            entity.HasIndex(e => e.ActorId, "idx_community_actor_id").IsUnique();

            entity.HasIndex(e => e.FollowersUrl, "idx_community_followers_url").IsUnique();

            entity.HasIndex(e => e.InboxUrl, "idx_community_inbox_url").IsUnique();

            entity.HasIndex(e => e.Published, "idx_community_published").IsDescending();

            entity.HasIndex(e => e.Title, "idx_community_title");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActorId)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValueSql("generate_unique_changeme()")
                .HasColumnName("actor_id");
            entity.Property(e => e.Banner).HasColumnName("banner");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.FeaturedUrl)
                .HasMaxLength(255)
                .HasColumnName("featured_url");
            entity.Property(e => e.FollowersUrl)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValueSql("generate_unique_changeme()")
                .HasColumnName("followers_url");
            entity.Property(e => e.Hidden).HasColumnName("hidden");
            entity.Property(e => e.Icon).HasColumnName("icon");
            entity.Property(e => e.InboxUrl)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValueSql("generate_unique_changeme()")
                .HasColumnName("inbox_url");
            entity.Property(e => e.InstanceId).HasColumnName("instance_id");
            entity.Property(e => e.LastRefreshedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_refreshed_at");
            entity.Property(e => e.Local)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("local");
            entity.Property(e => e.ModeratorsUrl)
                .HasMaxLength(255)
                .HasColumnName("moderators_url");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Nsfw).HasColumnName("nsfw");
            entity.Property(e => e.PostingRestrictedToMods).HasColumnName("posting_restricted_to_mods");
            entity.Property(e => e.PrivateKey).HasColumnName("private_key");
            entity.Property(e => e.PublicKey)
                .IsRequired()
                .HasColumnName("public_key");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.Removed).HasColumnName("removed");
            entity.Property(e => e.SharedInboxUrl)
                .HasMaxLength(255)
                .HasColumnName("shared_inbox_url");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated");

            entity.HasOne(d => d.Instance).WithMany(p => p.Communities)
                .HasForeignKey(d => d.InstanceId)
                .HasConstraintName("community_instance_id_fkey");
        });

        modelBuilder.Entity<CommunityAggregate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("community_aggregates_pkey");

            entity.ToTable("community_aggregates");

            entity.HasIndex(e => e.CommunityId, "community_aggregates_community_id_key").IsUnique();

            entity.HasIndex(e => e.HotRank, "idx_community_aggregates_hot").IsDescending();

            entity.HasIndex(e => e.Published, "idx_community_aggregates_published").IsDescending();

            entity.HasIndex(e => e.Subscribers, "idx_community_aggregates_subscribers").IsDescending();

            entity.HasIndex(e => e.UsersActiveMonth, "idx_community_aggregates_users_active_month").IsDescending();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comments).HasColumnName("comments");
            entity.Property(e => e.CommunityId).HasColumnName("community_id");
            entity.Property(e => e.HotRank)
                .HasDefaultValueSql("1728")
                .HasColumnName("hot_rank");
            entity.Property(e => e.Posts).HasColumnName("posts");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.Subscribers).HasColumnName("subscribers");
            entity.Property(e => e.UsersActiveDay).HasColumnName("users_active_day");
            entity.Property(e => e.UsersActiveHalfYear).HasColumnName("users_active_half_year");
            entity.Property(e => e.UsersActiveMonth).HasColumnName("users_active_month");
            entity.Property(e => e.UsersActiveWeek).HasColumnName("users_active_week");

            entity.HasOne(d => d.Community).WithOne(p => p.CommunityAggregate)
                .HasForeignKey<CommunityAggregate>(d => d.CommunityId)
                .HasConstraintName("community_aggregates_community_id_fkey");
        });

        modelBuilder.Entity<CommunityBlock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("community_block_pkey");

            entity.ToTable("community_block");

            entity.HasIndex(e => new { e.PersonId, e.CommunityId }, "community_block_person_id_community_id_key").IsUnique();

            entity.HasIndex(e => e.CommunityId, "idx_community_block_community");

            entity.HasIndex(e => e.PersonId, "idx_community_block_person");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommunityId).HasColumnName("community_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");

            entity.HasOne(d => d.Community).WithMany(p => p.CommunityBlocks)
                .HasForeignKey(d => d.CommunityId)
                .HasConstraintName("community_block_community_id_fkey");

            entity.HasOne(d => d.Person).WithMany(p => p.CommunityBlocks)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("community_block_person_id_fkey");
        });

        modelBuilder.Entity<CommunityFollower>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("community_follower_pkey");

            entity.ToTable("community_follower");

            entity.HasIndex(e => new { e.CommunityId, e.PersonId }, "community_follower_community_id_person_id_key").IsUnique();

            entity.HasIndex(e => e.CommunityId, "idx_community_follower_community");

            entity.HasIndex(e => e.PersonId, "idx_community_follower_person");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommunityId).HasColumnName("community_id");
            entity.Property(e => e.Pending).HasColumnName("pending");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");

            entity.HasOne(d => d.Community).WithMany(p => p.CommunityFollowers)
                .HasForeignKey(d => d.CommunityId)
                .HasConstraintName("community_follower_community_id_fkey");

            entity.HasOne(d => d.Person).WithMany(p => p.CommunityFollowers)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("community_follower_person_id_fkey");
        });

        modelBuilder.Entity<CommunityLanguage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("community_language_pkey");

            entity.ToTable("community_language");

            entity.HasIndex(e => new { e.CommunityId, e.LanguageId }, "community_language_community_id_language_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommunityId).HasColumnName("community_id");
            entity.Property(e => e.LanguageId).HasColumnName("language_id");

            entity.HasOne(d => d.Community).WithMany(p => p.CommunityLanguages)
                .HasForeignKey(d => d.CommunityId)
                .HasConstraintName("community_language_community_id_fkey");

            entity.HasOne(d => d.Language).WithMany(p => p.CommunityLanguages)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("community_language_language_id_fkey");
        });

        modelBuilder.Entity<CommunityModerator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("community_moderator_pkey");

            entity.ToTable("community_moderator");

            entity.HasIndex(e => new { e.CommunityId, e.PersonId }, "community_moderator_community_id_person_id_key").IsUnique();

            entity.HasIndex(e => e.CommunityId, "idx_community_moderator_community");

            entity.HasIndex(e => e.PersonId, "idx_community_moderator_person");

            entity.HasIndex(e => e.Published, "idx_community_moderator_published");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommunityId).HasColumnName("community_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");

            entity.HasOne(d => d.Community).WithMany(p => p.CommunityModerators)
                .HasForeignKey(d => d.CommunityId)
                .HasConstraintName("community_moderator_community_id_fkey");

            entity.HasOne(d => d.Person).WithMany(p => p.CommunityModerators)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("community_moderator_person_id_fkey");
        });

        modelBuilder.Entity<CommunityPersonBan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("community_person_ban_pkey");

            entity.ToTable("community_person_ban");

            entity.HasIndex(e => new { e.CommunityId, e.PersonId }, "community_person_ban_community_id_person_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommunityId).HasColumnName("community_id");
            entity.Property(e => e.Expires)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("expires");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");

            entity.HasOne(d => d.Community).WithMany(p => p.CommunityPersonBans)
                .HasForeignKey(d => d.CommunityId)
                .HasConstraintName("community_person_ban_community_id_fkey");

            entity.HasOne(d => d.Person).WithMany(p => p.CommunityPersonBans)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("community_person_ban_person_id_fkey");
        });

        modelBuilder.Entity<CustomEmoji>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("custom_emoji_pkey");

            entity.ToTable("custom_emoji");

            entity.HasIndex(e => e.ImageUrl, "custom_emoji_image_url_key").IsUnique();

            entity.HasIndex(e => e.Shortcode, "custom_emoji_shortcode_key").IsUnique();

            entity.HasIndex(e => e.Category, "idx_custom_emoji_category");

            entity.HasIndex(e => new { e.Id, e.Category }, "idx_custom_emoji_category_test");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AltText)
                .IsRequired()
                .HasColumnName("alt_text");
            entity.Property(e => e.Category)
                .IsRequired()
                .HasColumnName("category");
            entity.Property(e => e.ImageUrl)
                .IsRequired()
                .HasColumnName("image_url");
            entity.Property(e => e.LocalSiteId).HasColumnName("local_site_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.Shortcode)
                .IsRequired()
                .HasMaxLength(128)
                .HasColumnName("shortcode");
            entity.Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated");

            entity.HasOne(d => d.LocalSite).WithMany(p => p.CustomEmojis)
                .HasForeignKey(d => d.LocalSiteId)
                .HasConstraintName("custom_emoji_local_site_id_fkey");
        });

        modelBuilder.Entity<CustomEmojiKeyword>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("custom_emoji_keyword_pkey");

            entity.ToTable("custom_emoji_keyword");

            entity.HasIndex(e => new { e.CustomEmojiId, e.Keyword }, "custom_emoji_keyword_custom_emoji_id_keyword_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomEmojiId).HasColumnName("custom_emoji_id");
            entity.Property(e => e.Keyword)
                .IsRequired()
                .HasMaxLength(128)
                .HasColumnName("keyword");

            entity.HasOne(d => d.CustomEmoji).WithMany(p => p.CustomEmojiKeywords)
                .HasForeignKey(d => d.CustomEmojiId)
                .HasConstraintName("custom_emoji_keyword_custom_emoji_id_fkey");
        });

        modelBuilder.Entity<EmailVerification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("email_verification_pkey");

            entity.ToTable("email_verification");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("email");
            entity.Property(e => e.LocalUserId).HasColumnName("local_user_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.VerificationToken)
                .IsRequired()
                .HasColumnName("verification_token");

            entity.HasOne(d => d.LocalUser).WithMany(p => p.EmailVerifications)
                .HasForeignKey(d => d.LocalUserId)
                .HasConstraintName("email_verification_local_user_id_fkey");
        });

        modelBuilder.Entity<FederationAllowlist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("federation_allowlist_pkey");

            entity.ToTable("federation_allowlist");

            entity.HasIndex(e => e.InstanceId, "federation_allowlist_instance_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.InstanceId).HasColumnName("instance_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated");

            entity.HasOne(d => d.Instance).WithOne(p => p.FederationAllowlist)
                .HasForeignKey<FederationAllowlist>(d => d.InstanceId)
                .HasConstraintName("federation_allowlist_instance_id_fkey");
        });

        modelBuilder.Entity<FederationBlocklist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("federation_blocklist_pkey");

            entity.ToTable("federation_blocklist");

            entity.HasIndex(e => e.InstanceId, "federation_blocklist_instance_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.InstanceId).HasColumnName("instance_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated");

            entity.HasOne(d => d.Instance).WithOne(p => p.FederationBlocklist)
                .HasForeignKey<FederationBlocklist>(d => d.InstanceId)
                .HasConstraintName("federation_blocklist_instance_id_fkey");
        });

        modelBuilder.Entity<Instance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("instance_pkey");

            entity.ToTable("instance");

            entity.HasIndex(e => e.Domain, "instance_domain_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Domain)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("domain");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.Software)
                .HasMaxLength(255)
                .HasColumnName("software");
            entity.Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated");
            entity.Property(e => e.Version)
                .HasMaxLength(255)
                .HasColumnName("version");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("language_pkey");

            entity.ToTable("language");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name");
        });

        modelBuilder.Entity<LocalSite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("local_site_pkey");

            entity.ToTable("local_site");

            entity.HasIndex(e => e.SiteId, "local_site_site_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActorNameMaxLength)
                .HasDefaultValueSql("20")
                .HasColumnName("actor_name_max_length");
            entity.Property(e => e.ApplicationEmailAdmins).HasColumnName("application_email_admins");
            entity.Property(e => e.ApplicationQuestion)
                .HasDefaultValueSql("'to verify that you are human, please explain why you want to create an account on this site'::text")
                .HasColumnName("application_question");
            entity.Property(e => e.CaptchaDifficulty)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValueSql("'medium'::character varying")
                .HasColumnName("captcha_difficulty");
            entity.Property(e => e.CaptchaEnabled).HasColumnName("captcha_enabled");
            entity.Property(e => e.CommunityCreationAdminOnly).HasColumnName("community_creation_admin_only");
            entity.Property(e => e.DefaultTheme)
                .IsRequired()
                .HasDefaultValueSql("'browser'::text")
                .HasColumnName("default_theme");
            entity.Property(e => e.EnableDownvotes)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("enable_downvotes");
            entity.Property(e => e.EnableNsfw)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("enable_nsfw");
            entity.Property(e => e.FederationEnabled)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("federation_enabled");
            entity.Property(e => e.HideModlogModNames)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("hide_modlog_mod_names");
            entity.Property(e => e.LegalInformation).HasColumnName("legal_information");
            entity.Property(e => e.PrivateInstance).HasColumnName("private_instance");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.ReportsEmailAdmins).HasColumnName("reports_email_admins");
            entity.Property(e => e.RequireEmailVerification).HasColumnName("require_email_verification");
            entity.Property(e => e.SiteId).HasColumnName("site_id");
            entity.Property(e => e.SiteSetup).HasColumnName("site_setup");
            entity.Property(e => e.SlurFilterRegex).HasColumnName("slur_filter_regex");
            entity.Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated");

            entity.HasOne(d => d.Site).WithOne(p => p.LocalSite)
                .HasForeignKey<LocalSite>(d => d.SiteId)
                .HasConstraintName("local_site_site_id_fkey");
        });

        modelBuilder.Entity<LocalSiteRateLimit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("local_site_rate_limit_pkey");

            entity.ToTable("local_site_rate_limit");

            entity.HasIndex(e => e.LocalSiteId, "local_site_rate_limit_local_site_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasDefaultValueSql("6")
                .HasColumnName("comment");
            entity.Property(e => e.CommentPerSecond)
                .HasDefaultValueSql("600")
                .HasColumnName("comment_per_second");
            entity.Property(e => e.Image)
                .HasDefaultValueSql("6")
                .HasColumnName("image");
            entity.Property(e => e.ImagePerSecond)
                .HasDefaultValueSql("3600")
                .HasColumnName("image_per_second");
            entity.Property(e => e.LocalSiteId).HasColumnName("local_site_id");
            entity.Property(e => e.Message)
                .HasDefaultValueSql("180")
                .HasColumnName("message");
            entity.Property(e => e.MessagePerSecond)
                .HasDefaultValueSql("60")
                .HasColumnName("message_per_second");
            entity.Property(e => e.Post)
                .HasDefaultValueSql("6")
                .HasColumnName("post");
            entity.Property(e => e.PostPerSecond)
                .HasDefaultValueSql("600")
                .HasColumnName("post_per_second");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.Register)
                .HasDefaultValueSql("3")
                .HasColumnName("register");
            entity.Property(e => e.RegisterPerSecond)
                .HasDefaultValueSql("3600")
                .HasColumnName("register_per_second");
            entity.Property(e => e.Search)
                .HasDefaultValueSql("60")
                .HasColumnName("search");
            entity.Property(e => e.SearchPerSecond)
                .HasDefaultValueSql("600")
                .HasColumnName("search_per_second");
            entity.Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated");

            entity.HasOne(d => d.LocalSite).WithOne(p => p.LocalSiteRateLimit)
                .HasForeignKey<LocalSiteRateLimit>(d => d.LocalSiteId)
                .HasConstraintName("local_site_rate_limit_local_site_id_fkey");
        });

        modelBuilder.Entity<LocalUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("local_user_pkey");

            entity.ToTable("local_user");

            entity.HasIndex(e => e.Email, "local_user_email_key").IsUnique();

            entity.HasIndex(e => e.PersonId, "local_user_person_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AcceptedApplication).HasColumnName("accepted_application");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.EmailVerified).HasColumnName("email_verified");
            entity.Property(e => e.InterfaceLanguage)
                .IsRequired()
                .HasMaxLength(20)
                .HasDefaultValueSql("'browser'::character varying")
                .HasColumnName("interface_language");
            entity.Property(e => e.OpenLinksInNewTab).HasColumnName("open_links_in_new_tab");
            entity.Property(e => e.PasswordEncrypted)
                .IsRequired()
                .HasColumnName("password_encrypted");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.SendNotificationsToEmail).HasColumnName("send_notifications_to_email");
            entity.Property(e => e.ShowAvatars)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("show_avatars");
            entity.Property(e => e.ShowBotAccounts)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("show_bot_accounts");
            entity.Property(e => e.ShowNewPostNotifs).HasColumnName("show_new_post_notifs");
            entity.Property(e => e.ShowNsfw).HasColumnName("show_nsfw");
            entity.Property(e => e.ShowReadPosts)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("show_read_posts");
            entity.Property(e => e.ShowScores)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("show_scores");
            entity.Property(e => e.Theme)
                .IsRequired()
                .HasDefaultValueSql("'browser'::text")
                .HasColumnName("theme");
            entity.Property(e => e.Totp2faSecret).HasColumnName("totp_2fa_secret");
            entity.Property(e => e.Totp2faUrl).HasColumnName("totp_2fa_url");
            entity.Property(e => e.ValidatorTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("validator_time");

            entity.HasOne(d => d.Person).WithOne(p => p.LocalUser)
                .HasForeignKey<LocalUser>(d => d.PersonId)
                .HasConstraintName("local_user_person_id_fkey");
        });

        modelBuilder.Entity<LocalUserLanguage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("local_user_language_pkey");

            entity.ToTable("local_user_language");

            entity.HasIndex(e => new { e.LocalUserId, e.LanguageId }, "local_user_language_local_user_id_language_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.LocalUserId).HasColumnName("local_user_id");

            entity.HasOne(d => d.Language).WithMany(p => p.LocalUserLanguages)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("local_user_language_language_id_fkey");

            entity.HasOne(d => d.LocalUser).WithMany(p => p.LocalUserLanguages)
                .HasForeignKey(d => d.LocalUserId)
                .HasConstraintName("local_user_language_local_user_id_fkey");
        });

        modelBuilder.Entity<ModAdd>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mod_add_pkey");

            entity.ToTable("mod_add");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ModPersonId).HasColumnName("mod_person_id");
            entity.Property(e => e.OtherPersonId).HasColumnName("other_person_id");
            entity.Property(e => e.Removed).HasColumnName("removed");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("when_");

            entity.HasOne(d => d.ModPerson).WithMany(p => p.ModAddModPeople)
                .HasForeignKey(d => d.ModPersonId)
                .HasConstraintName("mod_add_mod_person_id_fkey");

            entity.HasOne(d => d.OtherPerson).WithMany(p => p.ModAddOtherPeople)
                .HasForeignKey(d => d.OtherPersonId)
                .HasConstraintName("mod_add_other_person_id_fkey");
        });

        modelBuilder.Entity<ModAddCommunity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mod_add_community_pkey");

            entity.ToTable("mod_add_community");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommunityId).HasColumnName("community_id");
            entity.Property(e => e.ModPersonId).HasColumnName("mod_person_id");
            entity.Property(e => e.OtherPersonId).HasColumnName("other_person_id");
            entity.Property(e => e.Removed).HasColumnName("removed");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("when_");

            entity.HasOne(d => d.Community).WithMany(p => p.ModAddCommunities)
                .HasForeignKey(d => d.CommunityId)
                .HasConstraintName("mod_add_community_community_id_fkey");

            entity.HasOne(d => d.ModPerson).WithMany(p => p.ModAddCommunityModPeople)
                .HasForeignKey(d => d.ModPersonId)
                .HasConstraintName("mod_add_community_mod_person_id_fkey");

            entity.HasOne(d => d.OtherPerson).WithMany(p => p.ModAddCommunityOtherPeople)
                .HasForeignKey(d => d.OtherPersonId)
                .HasConstraintName("mod_add_community_other_person_id_fkey");
        });

        modelBuilder.Entity<ModBan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mod_ban_pkey");

            entity.ToTable("mod_ban");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Banned)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("banned");
            entity.Property(e => e.Expires)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("expires");
            entity.Property(e => e.ModPersonId).HasColumnName("mod_person_id");
            entity.Property(e => e.OtherPersonId).HasColumnName("other_person_id");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("when_");

            entity.HasOne(d => d.ModPerson).WithMany(p => p.ModBanModPeople)
                .HasForeignKey(d => d.ModPersonId)
                .HasConstraintName("mod_ban_mod_person_id_fkey");

            entity.HasOne(d => d.OtherPerson).WithMany(p => p.ModBanOtherPeople)
                .HasForeignKey(d => d.OtherPersonId)
                .HasConstraintName("mod_ban_other_person_id_fkey");
        });

        modelBuilder.Entity<ModBanFromCommunity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mod_ban_from_community_pkey");

            entity.ToTable("mod_ban_from_community");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Banned)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("banned");
            entity.Property(e => e.CommunityId).HasColumnName("community_id");
            entity.Property(e => e.Expires)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("expires");
            entity.Property(e => e.ModPersonId).HasColumnName("mod_person_id");
            entity.Property(e => e.OtherPersonId).HasColumnName("other_person_id");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("when_");

            entity.HasOne(d => d.Community).WithMany(p => p.ModBanFromCommunities)
                .HasForeignKey(d => d.CommunityId)
                .HasConstraintName("mod_ban_from_community_community_id_fkey");

            entity.HasOne(d => d.ModPerson).WithMany(p => p.ModBanFromCommunityModPeople)
                .HasForeignKey(d => d.ModPersonId)
                .HasConstraintName("mod_ban_from_community_mod_person_id_fkey");

            entity.HasOne(d => d.OtherPerson).WithMany(p => p.ModBanFromCommunityOtherPeople)
                .HasForeignKey(d => d.OtherPersonId)
                .HasConstraintName("mod_ban_from_community_other_person_id_fkey");
        });

        modelBuilder.Entity<ModFeaturePost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mod_sticky_post_pkey");

            entity.ToTable("mod_feature_post");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('mod_sticky_post_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Featured)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("featured");
            entity.Property(e => e.IsFeaturedCommunity)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("is_featured_community");
            entity.Property(e => e.ModPersonId).HasColumnName("mod_person_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("when_");

            entity.HasOne(d => d.ModPerson).WithMany(p => p.ModFeaturePosts)
                .HasForeignKey(d => d.ModPersonId)
                .HasConstraintName("mod_sticky_post_mod_person_id_fkey");

            entity.HasOne(d => d.Post).WithMany(p => p.ModFeaturePosts)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("mod_sticky_post_post_id_fkey");
        });

        modelBuilder.Entity<ModHideCommunity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mod_hide_community_pkey");

            entity.ToTable("mod_hide_community");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommunityId).HasColumnName("community_id");
            entity.Property(e => e.Hidden).HasColumnName("hidden");
            entity.Property(e => e.ModPersonId).HasColumnName("mod_person_id");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("when_");

            entity.HasOne(d => d.Community).WithMany(p => p.ModHideCommunities)
                .HasForeignKey(d => d.CommunityId)
                .HasConstraintName("mod_hide_community_community_id_fkey");

            entity.HasOne(d => d.ModPerson).WithMany(p => p.ModHideCommunities)
                .HasForeignKey(d => d.ModPersonId)
                .HasConstraintName("mod_hide_community_mod_person_id_fkey");
        });

        modelBuilder.Entity<ModLockPost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mod_lock_post_pkey");

            entity.ToTable("mod_lock_post");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Locked)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("locked");
            entity.Property(e => e.ModPersonId).HasColumnName("mod_person_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("when_");

            entity.HasOne(d => d.ModPerson).WithMany(p => p.ModLockPosts)
                .HasForeignKey(d => d.ModPersonId)
                .HasConstraintName("mod_lock_post_mod_person_id_fkey");

            entity.HasOne(d => d.Post).WithMany(p => p.ModLockPosts)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("mod_lock_post_post_id_fkey");
        });

        modelBuilder.Entity<ModRemoveComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mod_remove_comment_pkey");

            entity.ToTable("mod_remove_comment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.ModPersonId).HasColumnName("mod_person_id");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.Removed)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("removed");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("when_");

            entity.HasOne(d => d.Comment).WithMany(p => p.ModRemoveComments)
                .HasForeignKey(d => d.CommentId)
                .HasConstraintName("mod_remove_comment_comment_id_fkey");

            entity.HasOne(d => d.ModPerson).WithMany(p => p.ModRemoveComments)
                .HasForeignKey(d => d.ModPersonId)
                .HasConstraintName("mod_remove_comment_mod_person_id_fkey");
        });

        modelBuilder.Entity<ModRemoveCommunity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mod_remove_community_pkey");

            entity.ToTable("mod_remove_community");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommunityId).HasColumnName("community_id");
            entity.Property(e => e.Expires)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("expires");
            entity.Property(e => e.ModPersonId).HasColumnName("mod_person_id");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.Removed)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("removed");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("when_");

            entity.HasOne(d => d.Community).WithMany(p => p.ModRemoveCommunities)
                .HasForeignKey(d => d.CommunityId)
                .HasConstraintName("mod_remove_community_community_id_fkey");

            entity.HasOne(d => d.ModPerson).WithMany(p => p.ModRemoveCommunities)
                .HasForeignKey(d => d.ModPersonId)
                .HasConstraintName("mod_remove_community_mod_person_id_fkey");
        });

        modelBuilder.Entity<ModRemovePost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mod_remove_post_pkey");

            entity.ToTable("mod_remove_post");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ModPersonId).HasColumnName("mod_person_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.Removed)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("removed");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("when_");

            entity.HasOne(d => d.ModPerson).WithMany(p => p.ModRemovePosts)
                .HasForeignKey(d => d.ModPersonId)
                .HasConstraintName("mod_remove_post_mod_person_id_fkey");

            entity.HasOne(d => d.Post).WithMany(p => p.ModRemovePosts)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("mod_remove_post_post_id_fkey");
        });

        modelBuilder.Entity<ModTransferCommunity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mod_transfer_community_pkey");

            entity.ToTable("mod_transfer_community");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommunityId).HasColumnName("community_id");
            entity.Property(e => e.ModPersonId).HasColumnName("mod_person_id");
            entity.Property(e => e.OtherPersonId).HasColumnName("other_person_id");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("when_");

            entity.HasOne(d => d.Community).WithMany(p => p.ModTransferCommunities)
                .HasForeignKey(d => d.CommunityId)
                .HasConstraintName("mod_transfer_community_community_id_fkey");

            entity.HasOne(d => d.ModPerson).WithMany(p => p.ModTransferCommunityModPeople)
                .HasForeignKey(d => d.ModPersonId)
                .HasConstraintName("mod_transfer_community_mod_person_id_fkey");

            entity.HasOne(d => d.OtherPerson).WithMany(p => p.ModTransferCommunityOtherPeople)
                .HasForeignKey(d => d.OtherPersonId)
                .HasConstraintName("mod_transfer_community_other_person_id_fkey");
        });

        modelBuilder.Entity<PasswordResetRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("password_reset_request_pkey");

            entity.ToTable("password_reset_request");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LocalUserId).HasColumnName("local_user_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.TokenEncrypted)
                .IsRequired()
                .HasColumnName("token_encrypted");

            entity.HasOne(d => d.LocalUser).WithMany(p => p.PasswordResetRequests)
                .HasForeignKey(d => d.LocalUserId)
                .HasConstraintName("password_reset_request_local_user_id_fkey");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("person__pkey");

            entity.ToTable("person");

            entity.HasIndex(e => e.ActorId, "idx_person_actor_id").IsUnique();

            entity.HasIndex(e => e.Admin, "idx_person_admin").HasFilter("admin");

            entity.HasIndex(e => e.InboxUrl, "idx_person_inbox_url").IsUnique();

            entity.HasIndex(e => e.Published, "idx_person_published").IsDescending();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActorId)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValueSql("generate_unique_changeme()")
                .HasColumnName("actor_id");
            entity.Property(e => e.Admin).HasColumnName("admin");
            entity.Property(e => e.Avatar).HasColumnName("avatar");
            entity.Property(e => e.BanExpires)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ban_expires");
            entity.Property(e => e.Banned).HasColumnName("banned");
            entity.Property(e => e.Banner).HasColumnName("banner");
            entity.Property(e => e.Bio).HasColumnName("bio");
            entity.Property(e => e.BotAccount).HasColumnName("bot_account");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(255)
                .HasColumnName("display_name");
            entity.Property(e => e.InboxUrl)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValueSql("generate_unique_changeme()")
                .HasColumnName("inbox_url");
            entity.Property(e => e.InstanceId).HasColumnName("instance_id");
            entity.Property(e => e.LastRefreshedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_refreshed_at");
            entity.Property(e => e.Local)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("local");
            entity.Property(e => e.MatrixUserId).HasColumnName("matrix_user_id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PrivateKey).HasColumnName("private_key");
            entity.Property(e => e.PublicKey)
                .IsRequired()
                .HasColumnName("public_key");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.SharedInboxUrl)
                .HasMaxLength(255)
                .HasColumnName("shared_inbox_url");
            entity.Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated");

            entity.HasOne(d => d.Instance).WithMany(p => p.People)
                .HasForeignKey(d => d.InstanceId)
                .HasConstraintName("person_instance_id_fkey");
        });

        modelBuilder.Entity<PersonAggregate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("person_aggregates_pkey");

            entity.ToTable("person_aggregates");

            entity.HasIndex(e => e.CommentScore, "idx_person_aggregates_comment_score").IsDescending();

            entity.HasIndex(e => e.PersonId, "idx_person_aggregates_person");

            entity.HasIndex(e => e.PersonId, "person_aggregates_person_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommentCount).HasColumnName("comment_count");
            entity.Property(e => e.CommentScore).HasColumnName("comment_score");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.PostCount).HasColumnName("post_count");
            entity.Property(e => e.PostScore).HasColumnName("post_score");

            entity.HasOne(d => d.Person).WithOne(p => p.PersonAggregate)
                .HasForeignKey<PersonAggregate>(d => d.PersonId)
                .HasConstraintName("person_aggregates_person_id_fkey");
        });

        modelBuilder.Entity<PersonBan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("person_ban_pkey");

            entity.ToTable("person_ban");

            entity.HasIndex(e => e.PersonId, "person_ban_person_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");

            entity.HasOne(d => d.Person).WithOne(p => p.PersonBan)
                .HasForeignKey<PersonBan>(d => d.PersonId)
                .HasConstraintName("person_ban_person_id_fkey");
        });

        modelBuilder.Entity<PersonBlock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("person_block_pkey");

            entity.ToTable("person_block");

            entity.HasIndex(e => e.PersonId, "idx_person_block_person");

            entity.HasIndex(e => e.TargetId, "idx_person_block_target");

            entity.HasIndex(e => new { e.PersonId, e.TargetId }, "person_block_person_id_target_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.TargetId).HasColumnName("target_id");

            entity.HasOne(d => d.Person).WithMany(p => p.PersonBlockPeople)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("person_block_person_id_fkey");

            entity.HasOne(d => d.Target).WithMany(p => p.PersonBlockTargets)
                .HasForeignKey(d => d.TargetId)
                .HasConstraintName("person_block_target_id_fkey");
        });

        modelBuilder.Entity<PersonFollower>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("person_follower_pkey");

            entity.ToTable("person_follower");

            entity.HasIndex(e => new { e.FollowerId, e.PersonId }, "person_follower_follower_id_person_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FollowerId).HasColumnName("follower_id");
            entity.Property(e => e.Pending).HasColumnName("pending");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");

            entity.HasOne(d => d.Follower).WithMany(p => p.PersonFollowerFollowers)
                .HasForeignKey(d => d.FollowerId)
                .HasConstraintName("person_follower_follower_id_fkey");

            entity.HasOne(d => d.Person).WithMany(p => p.PersonFollowerPeople)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("person_follower_person_id_fkey");
        });

        modelBuilder.Entity<PersonMention>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("person_mention_pkey");

            entity.ToTable("person_mention");

            entity.HasIndex(e => new { e.RecipientId, e.CommentId }, "person_mention_recipient_id_comment_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.Read).HasColumnName("read");
            entity.Property(e => e.RecipientId).HasColumnName("recipient_id");

            entity.HasOne(d => d.Comment).WithMany(p => p.PersonMentions)
                .HasForeignKey(d => d.CommentId)
                .HasConstraintName("person_mention_comment_id_fkey");

            entity.HasOne(d => d.Recipient).WithMany(p => p.PersonMentions)
                .HasForeignKey(d => d.RecipientId)
                .HasConstraintName("person_mention_recipient_id_fkey");
        });

        modelBuilder.Entity<PersonPostAggregate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("person_post_aggregates_pkey");

            entity.ToTable("person_post_aggregates");

            entity.HasIndex(e => e.PersonId, "idx_person_post_aggregates_person");

            entity.HasIndex(e => e.PostId, "idx_person_post_aggregates_post");

            entity.HasIndex(e => new { e.PersonId, e.PostId }, "person_post_aggregates_person_id_post_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.ReadComments).HasColumnName("read_comments");

            entity.HasOne(d => d.Person).WithMany(p => p.PersonPostAggregates)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("person_post_aggregates_person_id_fkey");

            entity.HasOne(d => d.Post).WithMany(p => p.PersonPostAggregates)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("person_post_aggregates_post_id_fkey");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("post_pkey");

            entity.ToTable("post");

            entity.HasIndex(e => e.ApId, "idx_post_ap_id").IsUnique();

            entity.HasIndex(e => e.CommunityId, "idx_post_community");

            entity.HasIndex(e => e.CreatorId, "idx_post_creator");

            entity.HasIndex(e => e.LanguageId, "idx_post_language");

            entity.HasIndex(e => e.Url, "idx_post_url");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApId)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValueSql("generate_unique_changeme()")
                .HasColumnName("ap_id");
            entity.Property(e => e.Body).HasColumnName("body");
            entity.Property(e => e.CommunityId).HasColumnName("community_id");
            entity.Property(e => e.CreatorId).HasColumnName("creator_id");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.EmbedDescription).HasColumnName("embed_description");
            entity.Property(e => e.EmbedTitle).HasColumnName("embed_title");
            entity.Property(e => e.EmbedVideoUrl).HasColumnName("embed_video_url");
            entity.Property(e => e.FeaturedCommunity).HasColumnName("featured_community");
            entity.Property(e => e.FeaturedLocal).HasColumnName("featured_local");
            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.Local)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("local");
            entity.Property(e => e.Locked).HasColumnName("locked");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Nsfw).HasColumnName("nsfw");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.Removed).HasColumnName("removed");
            entity.Property(e => e.ThumbnailUrl).HasColumnName("thumbnail_url");
            entity.Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated");
            entity.Property(e => e.Url)
                .HasMaxLength(512)
                .HasColumnName("url");

            entity.HasOne(d => d.Community).WithMany(p => p.Posts)
                .HasForeignKey(d => d.CommunityId)
                .HasConstraintName("post_community_id_fkey");

            entity.HasOne(d => d.Creator).WithMany(p => p.Posts)
                .HasForeignKey(d => d.CreatorId)
                .HasConstraintName("post_creator_id_fkey");

            entity.HasOne(d => d.Language).WithMany(p => p.Posts)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("post_language_id_fkey");
        });

        modelBuilder.Entity<PostAggregate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("post_aggregates_pkey");

            entity.ToTable("post_aggregates");

            entity.HasIndex(e => new { e.FeaturedCommunity, e.HotRankActive }, "idx_post_aggregates_featured_community_active").IsDescending();

            entity.HasIndex(e => new { e.FeaturedCommunity, e.Comments }, "idx_post_aggregates_featured_community_comments_ccnew").IsDescending();

            entity.HasIndex(e => new { e.FeaturedCommunity, e.HotRank }, "idx_post_aggregates_featured_community_hot").IsDescending();

            entity.HasIndex(e => new { e.FeaturedCommunity, e.NewestCommentTime }, "idx_post_aggregates_featured_community_newest_comment_tim_ccnew").IsDescending();

            entity.HasIndex(e => new { e.FeaturedCommunity, e.NewestCommentTime }, "idx_post_aggregates_featured_community_newest_comment_time").IsDescending();

            entity.HasIndex(e => new { e.FeaturedCommunity, e.NewestCommentTimeNecro }, "idx_post_aggregates_featured_community_newest_comment_time_necr").IsDescending();

            entity.HasIndex(e => new { e.FeaturedCommunity, e.Published }, "idx_post_aggregates_featured_community_published").IsDescending();

            entity.HasIndex(e => new { e.FeaturedCommunity, e.Published }, "idx_post_aggregates_featured_community_published_ccnew").IsDescending();

            entity.HasIndex(e => new { e.FeaturedCommunity, e.Score }, "idx_post_aggregates_featured_community_score").IsDescending();

            entity.HasIndex(e => new { e.FeaturedCommunity, e.Score }, "idx_post_aggregates_featured_community_score_ccnew").IsDescending();

            entity.HasIndex(e => new { e.FeaturedLocal, e.HotRankActive }, "idx_post_aggregates_featured_local_active").IsDescending();

            entity.HasIndex(e => new { e.FeaturedLocal, e.Comments }, "idx_post_aggregates_featured_local_comments_ccnew").IsDescending();

            entity.HasIndex(e => new { e.FeaturedLocal, e.HotRank }, "idx_post_aggregates_featured_local_hot").IsDescending();

            entity.HasIndex(e => new { e.FeaturedLocal, e.NewestCommentTime }, "idx_post_aggregates_featured_local_newest_comment_time").IsDescending();

            entity.HasIndex(e => new { e.FeaturedLocal, e.NewestCommentTime }, "idx_post_aggregates_featured_local_newest_comment_time_ccnew").IsDescending();

            entity.HasIndex(e => new { e.FeaturedLocal, e.NewestCommentTimeNecro }, "idx_post_aggregates_featured_local_newest_comment_time_necro").IsDescending();

            entity.HasIndex(e => new { e.FeaturedLocal, e.Published }, "idx_post_aggregates_featured_local_published").IsDescending();

            entity.HasIndex(e => new { e.FeaturedLocal, e.Published }, "idx_post_aggregates_featured_local_published_ccnew").IsDescending();

            entity.HasIndex(e => new { e.FeaturedLocal, e.Score }, "idx_post_aggregates_featured_local_score").IsDescending();

            entity.HasIndex(e => new { e.FeaturedLocal, e.Score }, "idx_post_aggregates_featured_local_score_ccnew").IsDescending();

            entity.HasIndex(e => e.Published, "idx_post_aggregates_published").IsDescending();

            entity.HasIndex(e => e.Id, "post_aggregates_pkey_ccnew").IsUnique();

            entity.HasIndex(e => e.PostId, "post_aggregates_post_id_key").IsUnique();

            entity.HasIndex(e => e.PostId, "post_aggregates_post_id_key_ccnew").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comments).HasColumnName("comments");
            entity.Property(e => e.Downvotes).HasColumnName("downvotes");
            entity.Property(e => e.FeaturedCommunity).HasColumnName("featured_community");
            entity.Property(e => e.FeaturedLocal).HasColumnName("featured_local");
            entity.Property(e => e.HotRank)
                .HasDefaultValueSql("1728")
                .HasColumnName("hot_rank");
            entity.Property(e => e.HotRankActive)
                .HasDefaultValueSql("1728")
                .HasColumnName("hot_rank_active");
            entity.Property(e => e.NewestCommentTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("newest_comment_time");
            entity.Property(e => e.NewestCommentTimeNecro)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("newest_comment_time_necro");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.Upvotes).HasColumnName("upvotes");

            entity.HasOne(d => d.Post).WithOne(p => p.PostAggregate)
                .HasForeignKey<PostAggregate>(d => d.PostId)
                .HasConstraintName("post_aggregates_post_id_fkey");
        });

        modelBuilder.Entity<PostLike>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("post_like_pkey");

            entity.ToTable("post_like");

            entity.HasIndex(e => e.PersonId, "idx_post_like_person");

            entity.HasIndex(e => e.PostId, "idx_post_like_post");

            entity.HasIndex(e => new { e.PostId, e.PersonId }, "post_like_post_id_person_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.Score).HasColumnName("score");

            entity.HasOne(d => d.Person).WithMany(p => p.PostLikes)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("post_like_person_id_fkey");

            entity.HasOne(d => d.Post).WithMany(p => p.PostLikes)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("post_like_post_id_fkey");
        });

        modelBuilder.Entity<PostRead>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("post_read_pkey");

            entity.ToTable("post_read");

            entity.HasIndex(e => new { e.PostId, e.PersonId }, "post_read_post_id_person_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");

            entity.HasOne(d => d.Person).WithMany(p => p.PostReads)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("post_read_person_id_fkey");

            entity.HasOne(d => d.Post).WithMany(p => p.PostReads)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("post_read_post_id_fkey");
        });

        modelBuilder.Entity<PostReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("post_report_pkey");

            entity.ToTable("post_report");

            entity.HasIndex(e => e.Published, "idx_post_report_published").IsDescending();

            entity.HasIndex(e => new { e.PostId, e.CreatorId }, "post_report_post_id_creator_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatorId).HasColumnName("creator_id");
            entity.Property(e => e.OriginalPostBody).HasColumnName("original_post_body");
            entity.Property(e => e.OriginalPostName)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("original_post_name");
            entity.Property(e => e.OriginalPostUrl).HasColumnName("original_post_url");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.Reason)
                .IsRequired()
                .HasColumnName("reason");
            entity.Property(e => e.Resolved).HasColumnName("resolved");
            entity.Property(e => e.ResolverId).HasColumnName("resolver_id");
            entity.Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated");

            entity.HasOne(d => d.Creator).WithMany(p => p.PostReportCreators)
                .HasForeignKey(d => d.CreatorId)
                .HasConstraintName("post_report_creator_id_fkey");

            entity.HasOne(d => d.Post).WithMany(p => p.PostReports)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("post_report_post_id_fkey");

            entity.HasOne(d => d.Resolver).WithMany(p => p.PostReportResolvers)
                .HasForeignKey(d => d.ResolverId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("post_report_resolver_id_fkey");
        });

        modelBuilder.Entity<PostSaved>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("post_saved_pkey");

            entity.ToTable("post_saved");

            entity.HasIndex(e => e.PersonId, "idx_post_saved_person_id");

            entity.HasIndex(e => new { e.PostId, e.PersonId }, "post_saved_post_id_person_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");

            entity.HasOne(d => d.Person).WithMany(p => p.PostSaveds)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("post_saved_person_id_fkey");

            entity.HasOne(d => d.Post).WithMany(p => p.PostSaveds)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("post_saved_post_id_fkey");
        });

        modelBuilder.Entity<PrivateMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("private_message_pkey");

            entity.ToTable("private_message");

            entity.HasIndex(e => e.ApId, "idx_private_message_ap_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApId)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValueSql("generate_unique_changeme()")
                .HasColumnName("ap_id");
            entity.Property(e => e.Content)
                .IsRequired()
                .HasColumnName("content");
            entity.Property(e => e.CreatorId).HasColumnName("creator_id");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.Local)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("local");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.Read).HasColumnName("read");
            entity.Property(e => e.RecipientId).HasColumnName("recipient_id");
            entity.Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated");

            entity.HasOne(d => d.Creator).WithMany(p => p.PrivateMessageCreators)
                .HasForeignKey(d => d.CreatorId)
                .HasConstraintName("private_message_creator_id_fkey");

            entity.HasOne(d => d.Recipient).WithMany(p => p.PrivateMessageRecipients)
                .HasForeignKey(d => d.RecipientId)
                .HasConstraintName("private_message_recipient_id_fkey");
        });

        modelBuilder.Entity<PrivateMessageReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("private_message_report_pkey");

            entity.ToTable("private_message_report");

            entity.HasIndex(e => new { e.PrivateMessageId, e.CreatorId }, "private_message_report_private_message_id_creator_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatorId).HasColumnName("creator_id");
            entity.Property(e => e.OriginalPmText)
                .IsRequired()
                .HasColumnName("original_pm_text");
            entity.Property(e => e.PrivateMessageId).HasColumnName("private_message_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.Reason)
                .IsRequired()
                .HasColumnName("reason");
            entity.Property(e => e.Resolved).HasColumnName("resolved");
            entity.Property(e => e.ResolverId).HasColumnName("resolver_id");
            entity.Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated");

            entity.HasOne(d => d.Creator).WithMany(p => p.PrivateMessageReportCreators)
                .HasForeignKey(d => d.CreatorId)
                .HasConstraintName("private_message_report_creator_id_fkey");

            entity.HasOne(d => d.PrivateMessage).WithMany(p => p.PrivateMessageReports)
                .HasForeignKey(d => d.PrivateMessageId)
                .HasConstraintName("private_message_report_private_message_id_fkey");

            entity.HasOne(d => d.Resolver).WithMany(p => p.PrivateMessageReportResolvers)
                .HasForeignKey(d => d.ResolverId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("private_message_report_resolver_id_fkey");
        });

        modelBuilder.Entity<RegistrationApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("registration_application_pkey");

            entity.ToTable("registration_application");

            entity.HasIndex(e => e.Published, "idx_registration_application_published").IsDescending();

            entity.HasIndex(e => e.LocalUserId, "registration_application_local_user_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.Answer)
                .IsRequired()
                .HasColumnName("answer");
            entity.Property(e => e.DenyReason).HasColumnName("deny_reason");
            entity.Property(e => e.LocalUserId).HasColumnName("local_user_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");

            entity.HasOne(d => d.Admin).WithMany(p => p.RegistrationApplications)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("registration_application_admin_id_fkey");

            entity.HasOne(d => d.LocalUser).WithOne(p => p.RegistrationApplication)
                .HasForeignKey<RegistrationApplication>(d => d.LocalUserId)
                .HasConstraintName("registration_application_local_user_id_fkey");
        });

        modelBuilder.Entity<Secret>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("secret_pkey");

            entity.ToTable("secret");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.JwtSecret)
                .IsRequired()
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnType("character varying")
                .HasColumnName("jwt_secret");
        });

        modelBuilder.Entity<Site>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("site_pkey");

            entity.ToTable("site");

            entity.HasIndex(e => e.InstanceId, "idx_site_instance_unique").IsUnique();

            entity.HasIndex(e => e.ActorId, "site_actor_id_key").IsUnique();

            entity.HasIndex(e => e.Name, "site_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActorId)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValueSql("generate_unique_changeme()")
                .HasColumnName("actor_id");
            entity.Property(e => e.Banner).HasColumnName("banner");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.Icon).HasColumnName("icon");
            entity.Property(e => e.InboxUrl)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValueSql("generate_unique_changeme()")
                .HasColumnName("inbox_url");
            entity.Property(e => e.InstanceId).HasColumnName("instance_id");
            entity.Property(e => e.LastRefreshedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_refreshed_at");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.PrivateKey).HasColumnName("private_key");
            entity.Property(e => e.PublicKey)
                .IsRequired()
                .HasDefaultValueSql("generate_unique_changeme()")
                .HasColumnName("public_key");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.Sidebar).HasColumnName("sidebar");
            entity.Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated");

            entity.HasOne(d => d.Instance).WithOne(p => p.Site)
                .HasForeignKey<Site>(d => d.InstanceId)
                .HasConstraintName("site_instance_id_fkey");
        });

        modelBuilder.Entity<SiteAggregate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("site_aggregates_pkey");

            entity.ToTable("site_aggregates");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comments).HasColumnName("comments");
            entity.Property(e => e.Communities).HasColumnName("communities");
            entity.Property(e => e.Posts).HasColumnName("posts");
            entity.Property(e => e.SiteId).HasColumnName("site_id");
            entity.Property(e => e.Users)
                .HasDefaultValueSql("1")
                .HasColumnName("users");
            entity.Property(e => e.UsersActiveDay).HasColumnName("users_active_day");
            entity.Property(e => e.UsersActiveHalfYear).HasColumnName("users_active_half_year");
            entity.Property(e => e.UsersActiveMonth).HasColumnName("users_active_month");
            entity.Property(e => e.UsersActiveWeek).HasColumnName("users_active_week");

            entity.HasOne(d => d.Site).WithMany(p => p.SiteAggregates)
                .HasForeignKey(d => d.SiteId)
                .HasConstraintName("site_aggregates_site_id_fkey");
        });

        modelBuilder.Entity<SiteLanguage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("site_language_pkey");

            entity.ToTable("site_language");

            entity.HasIndex(e => new { e.SiteId, e.LanguageId }, "site_language_site_id_language_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.SiteId).HasColumnName("site_id");

            entity.HasOne(d => d.Language).WithMany(p => p.SiteLanguages)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("site_language_language_id_fkey");

            entity.HasOne(d => d.Site).WithMany(p => p.SiteLanguages)
                .HasForeignKey(d => d.SiteId)
                .HasConstraintName("site_language_site_id_fkey");
        });

        modelBuilder.Entity<Tagline>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tagline_pkey");

            entity.ToTable("tagline");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .IsRequired()
                .HasColumnName("content");
            entity.Property(e => e.LocalSiteId).HasColumnName("local_site_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published");
            entity.Property(e => e.Updated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated");

            entity.HasOne(d => d.LocalSite).WithMany(p => p.Taglines)
                .HasForeignKey(d => d.LocalSiteId)
                .HasConstraintName("tagline_local_site_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
