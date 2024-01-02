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

    public virtual DbSet<CommunityModerator> CommunityModerators { get; set; }

    public virtual DbSet<CommunityPersonBan> CommunityPersonBans { get; set; }

    public virtual DbSet<CustomEmoji> CustomEmojis { get; set; }

    public virtual DbSet<CustomEmojiKeyword> CustomEmojiKeywords { get; set; }

    public virtual DbSet<DepsSavedDdl> DepsSavedDdls { get; set; }

    public virtual DbSet<DieselSchemaMigration> DieselSchemaMigrations { get; set; }

    public virtual DbSet<EmailVerification> EmailVerifications { get; set; }

    public virtual DbSet<FederationAllowlist> FederationAllowlists { get; set; }

    public virtual DbSet<FederationBlocklist> FederationBlocklists { get; set; }

    public virtual DbSet<FederationQueueState> FederationQueueStates { get; set; }

    public virtual DbSet<ImageUpload> ImageUploads { get; set; }

    public virtual DbSet<Instance> Instances { get; set; }

    public virtual DbSet<InstanceBlock> InstanceBlocks { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<LocalSite> LocalSites { get; set; }

    public virtual DbSet<LocalSiteRateLimit> LocalSiteRateLimits { get; set; }

    public virtual DbSet<LocalUser> LocalUsers { get; set; }

    public virtual DbSet<LoginToken> LoginTokens { get; set; }

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

    public virtual DbSet<ReceivedActivity> ReceivedActivities { get; set; }

    public virtual DbSet<RegistrationApplication> RegistrationApplications { get; set; }

    public virtual DbSet<Secret> Secrets { get; set; }

    public virtual DbSet<SentActivity> SentActivities { get; set; }

    public virtual DbSet<Site> Sites { get; set; }

    public virtual DbSet<SiteAggregate> SiteAggregates { get; set; }

    public virtual DbSet<Tagline> Taglines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("actor_type_enum", new[] { "site", "community", "person" })
            .HasPostgresEnum("listing_type_enum", new[] { "All", "Local", "Subscribed", "ModeratorView" })
            .HasPostgresEnum("post_listing_mode_enum", new[] { "List", "Card", "SmallCard" })
            .HasPostgresEnum("registration_mode_enum", new[] { "Closed", "RequireApplication", "Open" })
            .HasPostgresEnum("sort_type_enum", new[] { "Active", "Hot", "New", "Old", "TopDay", "TopWeek", "TopMonth", "TopYear", "TopAll", "MostComments", "NewComments", "TopHour", "TopSixHour", "TopTwelveHour", "TopThreeMonths", "TopSixMonths", "TopNineMonths", "Controversial", "Scaled" })
            .HasPostgresExtension("ltree")
            .HasPostgresExtension("pg_stat_statements")
            .HasPostgresExtension("pg_trgm")
            .HasPostgresExtension("pgcrypto");

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
            entity.HasKey(e => e.Uuid).HasName("captcha_answer_pkey");

            entity.ToTable("captcha_answer");

            entity.Property(e => e.Uuid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("uuid");
            entity.Property(e => e.Answer)
                .IsRequired()
                .HasColumnName("answer");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnName("published");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("comment_pkey");

            entity
                .ToTable("comment")
                .HasAnnotation("Npgsql:StorageParameter:autovacuum_analyze_scale_factor", "0")
                .HasAnnotation("Npgsql:StorageParameter:autovacuum_analyze_threshold", "300")
                .HasAnnotation("Npgsql:StorageParameter:autovacuum_vacuum_scale_factor", "0.05")
                .HasAnnotation("Npgsql:StorageParameter:autovacuum_vacuum_threshold", "100");

            entity.HasIndex(e => e.ApId, "idx_comment_ap_id").IsUnique();

            entity.HasIndex(e => e.Content, "idx_comment_content_trigram")
                .HasMethod("gin")
                .HasOperators(new[] { "gin_trgm_ops" });

            entity.HasIndex(e => e.CreatorId, "idx_comment_creator");

            entity.HasIndex(e => e.LanguageId, "idx_comment_language");

            entity.HasIndex(e => e.PostId, "idx_comment_post");

            entity.HasIndex(e => e.Published, "idx_comment_published").IsDescending();

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
            entity.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .HasColumnName("deleted");
            entity.Property(e => e.Distinguished)
                .HasDefaultValue(false)
                .HasColumnName("distinguished");
            entity.Property(e => e.LanguageId)
                .HasDefaultValue(0)
                .HasColumnName("language_id");
            entity.Property(e => e.Local)
                .HasDefaultValue(true)
                .HasColumnName("local");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnName("published");
            entity.Property(e => e.Removed)
                .HasDefaultValue(false)
                .HasColumnName("removed");
            entity.Property(e => e.Updated).HasColumnName("updated");

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
            entity.HasKey(e => e.CommentId).HasName("comment_aggregates_pkey");

            entity.ToTable("comment_aggregates");

            entity.HasIndex(e => e.ControversyRank, "idx_comment_aggregates_controversy").IsDescending();

            entity.HasIndex(e => new { e.HotRank, e.Score }, "idx_comment_aggregates_hot").IsDescending();

            entity.HasIndex(e => e.Published, "idx_comment_aggregates_nonzero_hotrank").HasFilter("(hot_rank <> (0)::double precision)");

            entity.HasIndex(e => e.Published, "idx_comment_aggregates_published").IsDescending();

            entity.HasIndex(e => e.Score, "idx_comment_aggregates_score").IsDescending();

            entity.Property(e => e.CommentId)
                .ValueGeneratedNever()
                .HasColumnName("comment_id");
            entity.Property(e => e.ChildCount)
                .HasDefaultValue(0)
                .HasColumnName("child_count");
            entity.Property(e => e.ControversyRank).HasColumnName("controversy_rank");
            entity.Property(e => e.Downvotes)
                .HasDefaultValue(0L)
                .HasColumnName("downvotes");
            entity.Property(e => e.HotRank)
                .HasDefaultValueSql("0.0001")
                .HasColumnName("hot_rank");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnName("published");
            entity.Property(e => e.Score)
                .HasDefaultValue(0L)
                .HasColumnName("score");
            entity.Property(e => e.Upvotes)
                .HasDefaultValue(0L)
                .HasColumnName("upvotes");

            entity.HasOne(d => d.Comment).WithOne(p => p.CommentAggregate)
                .HasForeignKey<CommentAggregate>(d => d.CommentId)
                .HasConstraintName("comment_aggregates_comment_id_fkey");
        });

        modelBuilder.Entity<CommentLike>(entity =>
        {
            entity.HasKey(e => new { e.PersonId, e.CommentId }).HasName("comment_like_pkey");

            entity
                .ToTable("comment_like")
                .HasAnnotation("Npgsql:StorageParameter:autovacuum_analyze_scale_factor", "0.05")
                .HasAnnotation("Npgsql:StorageParameter:autovacuum_analyze_threshold", "100")
                .HasAnnotation("Npgsql:StorageParameter:autovacuum_vacuum_scale_factor", "0.05")
                .HasAnnotation("Npgsql:StorageParameter:autovacuum_vacuum_threshold", "100");

            entity.HasIndex(e => e.CommentId, "idx_comment_like_comment");

            entity.HasIndex(e => e.PostId, "idx_comment_like_post");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
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
                .HasColumnName("published");
            entity.Property(e => e.Read)
                .HasDefaultValue(false)
                .HasColumnName("read");
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
                .HasColumnName("published");
            entity.Property(e => e.Reason)
                .IsRequired()
                .HasColumnName("reason");
            entity.Property(e => e.Resolved)
                .HasDefaultValue(false)
                .HasColumnName("resolved");
            entity.Property(e => e.ResolverId).HasColumnName("resolver_id");
            entity.Property(e => e.Updated).HasColumnName("updated");

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
            entity.HasKey(e => new { e.PersonId, e.CommentId }).HasName("comment_saved_pkey");

            entity.ToTable("comment_saved");

            entity.HasIndex(e => e.CommentId, "idx_comment_saved_comment");

            entity.HasIndex(e => e.PersonId, "idx_comment_saved_person");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
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

            entity.HasIndex(e => e.Published, "idx_community_published").IsDescending();

            entity.HasIndex(e => e.Title, "idx_community_title");

            entity.HasIndex(e => new { e.Name, e.Title }, "idx_community_trigram")
                .HasMethod("gin")
                .HasOperators(new[] { "gin_trgm_ops", "gin_trgm_ops" });

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActorId)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValueSql("generate_unique_changeme()")
                .HasColumnName("actor_id");
            entity.Property(e => e.Banner).HasColumnName("banner");
            entity.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .HasColumnName("deleted");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.FeaturedUrl)
                .HasMaxLength(255)
                .HasColumnName("featured_url");
            entity.Property(e => e.FollowersUrl)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValueSql("generate_unique_changeme()")
                .HasColumnName("followers_url");
            entity.Property(e => e.Hidden)
                .HasDefaultValue(false)
                .HasColumnName("hidden");
            entity.Property(e => e.Icon).HasColumnName("icon");
            entity.Property(e => e.InboxUrl)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValueSql("generate_unique_changeme()")
                .HasColumnName("inbox_url");
            entity.Property(e => e.InstanceId).HasColumnName("instance_id");
            entity.Property(e => e.LastRefreshedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("last_refreshed_at");
            entity.Property(e => e.Local)
                .HasDefaultValue(true)
                .HasColumnName("local");
            entity.Property(e => e.ModeratorsUrl)
                .HasMaxLength(255)
                .HasColumnName("moderators_url");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Nsfw)
                .HasDefaultValue(false)
                .HasColumnName("nsfw");
            entity.Property(e => e.PostingRestrictedToMods)
                .HasDefaultValue(false)
                .HasColumnName("posting_restricted_to_mods");
            entity.Property(e => e.PrivateKey).HasColumnName("private_key");
            entity.Property(e => e.PublicKey)
                .IsRequired()
                .HasColumnName("public_key");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnName("published");
            entity.Property(e => e.Removed)
                .HasDefaultValue(false)
                .HasColumnName("removed");
            entity.Property(e => e.SharedInboxUrl)
                .HasMaxLength(255)
                .HasColumnName("shared_inbox_url");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.Updated).HasColumnName("updated");

            entity.HasOne(d => d.Instance).WithMany(p => p.Communities)
                .HasForeignKey(d => d.InstanceId)
                .HasConstraintName("community_instance_id_fkey");

            entity.HasMany(d => d.Languages).WithMany(p => p.Communities)
                .UsingEntity<Dictionary<string, object>>(
                    "CommunityLanguage",
                    r => r.HasOne<Language>().WithMany()
                        .HasForeignKey("LanguageId")
                        .HasConstraintName("community_language_language_id_fkey"),
                    l => l.HasOne<Community>().WithMany()
                        .HasForeignKey("CommunityId")
                        .HasConstraintName("community_language_community_id_fkey"),
                    j =>
                    {
                        j.HasKey("CommunityId", "LanguageId").HasName("community_language_pkey");
                        j.ToTable("community_language");
                        j.IndexerProperty<int>("CommunityId").HasColumnName("community_id");
                        j.IndexerProperty<int>("LanguageId").HasColumnName("language_id");
                    });
        });

        modelBuilder.Entity<CommunityAggregate>(entity =>
        {
            entity.HasKey(e => e.CommunityId).HasName("community_aggregates_pkey");

            entity.ToTable("community_aggregates");

            entity.HasIndex(e => e.HotRank, "idx_community_aggregates_hot").IsDescending();

            entity.HasIndex(e => e.Published, "idx_community_aggregates_nonzero_hotrank").HasFilter("(hot_rank <> (0)::double precision)");

            entity.HasIndex(e => e.Published, "idx_community_aggregates_published").IsDescending();

            entity.HasIndex(e => e.Subscribers, "idx_community_aggregates_subscribers").IsDescending();

            entity.HasIndex(e => e.UsersActiveMonth, "idx_community_aggregates_users_active_month").IsDescending();

            entity.Property(e => e.CommunityId)
                .ValueGeneratedNever()
                .HasColumnName("community_id");
            entity.Property(e => e.Comments)
                .HasDefaultValue(0L)
                .HasColumnName("comments");
            entity.Property(e => e.HotRank)
                .HasDefaultValueSql("0.0001")
                .HasColumnName("hot_rank");
            entity.Property(e => e.Posts)
                .HasDefaultValue(0L)
                .HasColumnName("posts");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnName("published");
            entity.Property(e => e.Subscribers)
                .HasDefaultValue(0L)
                .HasColumnName("subscribers");
            entity.Property(e => e.UsersActiveDay)
                .HasDefaultValue(0L)
                .HasColumnName("users_active_day");
            entity.Property(e => e.UsersActiveHalfYear)
                .HasDefaultValue(0L)
                .HasColumnName("users_active_half_year");
            entity.Property(e => e.UsersActiveMonth)
                .HasDefaultValue(0L)
                .HasColumnName("users_active_month");
            entity.Property(e => e.UsersActiveWeek)
                .HasDefaultValue(0L)
                .HasColumnName("users_active_week");

            entity.HasOne(d => d.Community).WithOne(p => p.CommunityAggregate)
                .HasForeignKey<CommunityAggregate>(d => d.CommunityId)
                .HasConstraintName("community_aggregates_community_id_fkey");
        });

        modelBuilder.Entity<CommunityBlock>(entity =>
        {
            entity.HasKey(e => new { e.PersonId, e.CommunityId }).HasName("community_block_pkey");

            entity.ToTable("community_block");

            entity.HasIndex(e => e.CommunityId, "idx_community_block_community");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.CommunityId).HasColumnName("community_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
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
            entity.HasKey(e => new { e.PersonId, e.CommunityId }).HasName("community_follower_pkey");

            entity.ToTable("community_follower");

            entity.HasIndex(e => e.CommunityId, "idx_community_follower_community");

            entity.HasIndex(e => e.Published, "idx_community_follower_published");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.CommunityId).HasColumnName("community_id");
            entity.Property(e => e.Pending)
                .HasDefaultValue(false)
                .HasColumnName("pending");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnName("published");

            entity.HasOne(d => d.Community).WithMany(p => p.CommunityFollowers)
                .HasForeignKey(d => d.CommunityId)
                .HasConstraintName("community_follower_community_id_fkey");

            entity.HasOne(d => d.Person).WithMany(p => p.CommunityFollowers)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("community_follower_person_id_fkey");
        });

        modelBuilder.Entity<CommunityModerator>(entity =>
        {
            entity.HasKey(e => new { e.PersonId, e.CommunityId }).HasName("community_moderator_pkey");

            entity.ToTable("community_moderator");

            entity.HasIndex(e => e.CommunityId, "idx_community_moderator_community");

            entity.HasIndex(e => e.Published, "idx_community_moderator_published");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.CommunityId).HasColumnName("community_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
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
            entity.HasKey(e => new { e.PersonId, e.CommunityId }).HasName("community_person_ban_pkey");

            entity.ToTable("community_person_ban");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.CommunityId).HasColumnName("community_id");
            entity.Property(e => e.Expires).HasColumnName("expires");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
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
                .HasColumnName("published");
            entity.Property(e => e.Shortcode)
                .IsRequired()
                .HasMaxLength(128)
                .HasColumnName("shortcode");
            entity.Property(e => e.Updated).HasColumnName("updated");

            entity.HasOne(d => d.LocalSite).WithMany(p => p.CustomEmojis)
                .HasForeignKey(d => d.LocalSiteId)
                .HasConstraintName("custom_emoji_local_site_id_fkey");
        });

        modelBuilder.Entity<CustomEmojiKeyword>(entity =>
        {
            entity.HasKey(e => new { e.CustomEmojiId, e.Keyword }).HasName("custom_emoji_keyword_pkey");

            entity.ToTable("custom_emoji_keyword");

            entity.Property(e => e.CustomEmojiId).HasColumnName("custom_emoji_id");
            entity.Property(e => e.Keyword)
                .HasMaxLength(128)
                .HasColumnName("keyword");

            entity.HasOne(d => d.CustomEmoji).WithMany(p => p.CustomEmojiKeywords)
                .HasForeignKey(d => d.CustomEmojiId)
                .HasConstraintName("custom_emoji_keyword_custom_emoji_id_fkey");
        });

        modelBuilder.Entity<DepsSavedDdl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("deps_saved_ddl_pkey");

            entity.ToTable("deps_saved_ddl", "utils");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DdlToRun).HasColumnName("ddl_to_run");
            entity.Property(e => e.ViewName)
                .HasMaxLength(255)
                .HasColumnName("view_name");
            entity.Property(e => e.ViewSchema)
                .HasMaxLength(255)
                .HasColumnName("view_schema");
        });

        modelBuilder.Entity<DieselSchemaMigration>(entity =>
        {
            entity.HasKey(e => e.Version).HasName("__diesel_schema_migrations_pkey");

            entity.ToTable("__diesel_schema_migrations");

            entity.Property(e => e.Version)
                .HasMaxLength(50)
                .HasColumnName("version");
            entity.Property(e => e.RunOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("run_on");
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
            entity.HasKey(e => e.InstanceId).HasName("federation_allowlist_pkey");

            entity.ToTable("federation_allowlist");

            entity.Property(e => e.InstanceId)
                .ValueGeneratedNever()
                .HasColumnName("instance_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnName("published");
            entity.Property(e => e.Updated).HasColumnName("updated");

            entity.HasOne(d => d.Instance).WithOne(p => p.FederationAllowlist)
                .HasForeignKey<FederationAllowlist>(d => d.InstanceId)
                .HasConstraintName("federation_allowlist_instance_id_fkey");
        });

        modelBuilder.Entity<FederationBlocklist>(entity =>
        {
            entity.HasKey(e => e.InstanceId).HasName("federation_blocklist_pkey");

            entity.ToTable("federation_blocklist");

            entity.Property(e => e.InstanceId)
                .ValueGeneratedNever()
                .HasColumnName("instance_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnName("published");
            entity.Property(e => e.Updated).HasColumnName("updated");

            entity.HasOne(d => d.Instance).WithOne(p => p.FederationBlocklist)
                .HasForeignKey<FederationBlocklist>(d => d.InstanceId)
                .HasConstraintName("federation_blocklist_instance_id_fkey");
        });

        modelBuilder.Entity<FederationQueueState>(entity =>
        {
            entity.HasKey(e => e.InstanceId).HasName("federation_queue_state_pkey");

            entity.ToTable("federation_queue_state");

            entity.Property(e => e.InstanceId)
                .ValueGeneratedNever()
                .HasColumnName("instance_id");
            entity.Property(e => e.FailCount).HasColumnName("fail_count");
            entity.Property(e => e.LastRetry).HasColumnName("last_retry");
            entity.Property(e => e.LastSuccessfulId).HasColumnName("last_successful_id");
            entity.Property(e => e.LastSuccessfulPublishedTime).HasColumnName("last_successful_published_time");

            entity.HasOne(d => d.Instance).WithOne(p => p.FederationQueueState)
                .HasForeignKey<FederationQueueState>(d => d.InstanceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("federation_queue_state_instance_id_fkey");
        });

        modelBuilder.Entity<ImageUpload>(entity =>
        {
            entity.HasKey(e => e.PictrsAlias).HasName("image_upload_pkey");

            entity.ToTable("image_upload");

            entity.HasIndex(e => e.PictrsAlias, "idx_image_upload_alias");

            entity.HasIndex(e => e.LocalUserId, "idx_image_upload_local_user_id");

            entity.Property(e => e.PictrsAlias).HasColumnName("pictrs_alias");
            entity.Property(e => e.LocalUserId).HasColumnName("local_user_id");
            entity.Property(e => e.PictrsDeleteToken)
                .IsRequired()
                .HasColumnName("pictrs_delete_token");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnName("published");

            entity.HasOne(d => d.LocalUser).WithMany(p => p.ImageUploads)
                .HasForeignKey(d => d.LocalUserId)
                .HasConstraintName("image_upload_local_user_id_fkey");
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
                .HasColumnName("published");
            entity.Property(e => e.Software)
                .HasMaxLength(255)
                .HasColumnName("software");
            entity.Property(e => e.Updated).HasColumnName("updated");
            entity.Property(e => e.Version)
                .HasMaxLength(255)
                .HasColumnName("version");
        });

        modelBuilder.Entity<InstanceBlock>(entity =>
        {
            entity.HasKey(e => new { e.PersonId, e.InstanceId }).HasName("instance_block_pkey");

            entity.ToTable("instance_block");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.InstanceId).HasColumnName("instance_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnName("published");

            entity.HasOne(d => d.Instance).WithMany(p => p.InstanceBlocks)
                .HasForeignKey(d => d.InstanceId)
                .HasConstraintName("instance_block_instance_id_fkey");

            entity.HasOne(d => d.Person).WithMany(p => p.InstanceBlocks)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("instance_block_person_id_fkey");
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
                .HasDefaultValue(20)
                .HasColumnName("actor_name_max_length");
            entity.Property(e => e.ApplicationEmailAdmins)
                .HasDefaultValue(false)
                .HasColumnName("application_email_admins");
            entity.Property(e => e.ApplicationQuestion)
                .HasDefaultValueSql("'to verify that you are human, please explain why you want to create an account on this site'::text")
                .HasColumnName("application_question");
            entity.Property(e => e.CaptchaDifficulty)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValueSql("'medium'::character varying")
                .HasColumnName("captcha_difficulty");
            entity.Property(e => e.CaptchaEnabled)
                .HasDefaultValue(false)
                .HasColumnName("captcha_enabled");
            entity.Property(e => e.CommunityCreationAdminOnly)
                .HasDefaultValue(false)
                .HasColumnName("community_creation_admin_only");
            entity.Property(e => e.DefaultTheme)
                .IsRequired()
                .HasDefaultValueSql("'browser'::text")
                .HasColumnName("default_theme");
            entity.Property(e => e.EnableDownvotes)
                .HasDefaultValue(true)
                .HasColumnName("enable_downvotes");
            entity.Property(e => e.EnableNsfw)
                .HasDefaultValue(true)
                .HasColumnName("enable_nsfw");
            entity.Property(e => e.FederationEnabled)
                .HasDefaultValue(true)
                .HasColumnName("federation_enabled");
            entity.Property(e => e.FederationSignedFetch)
                .HasDefaultValue(false)
                .HasColumnName("federation_signed_fetch");
            entity.Property(e => e.HideModlogModNames)
                .HasDefaultValue(true)
                .HasColumnName("hide_modlog_mod_names");
            entity.Property(e => e.LegalInformation).HasColumnName("legal_information");
            entity.Property(e => e.PrivateInstance)
                .HasDefaultValue(false)
                .HasColumnName("private_instance");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnName("published");
            entity.Property(e => e.ReportsEmailAdmins)
                .HasDefaultValue(false)
                .HasColumnName("reports_email_admins");
            entity.Property(e => e.RequireEmailVerification)
                .HasDefaultValue(false)
                .HasColumnName("require_email_verification");
            entity.Property(e => e.SiteId).HasColumnName("site_id");
            entity.Property(e => e.SiteSetup)
                .HasDefaultValue(false)
                .HasColumnName("site_setup");
            entity.Property(e => e.SlurFilterRegex).HasColumnName("slur_filter_regex");
            entity.Property(e => e.Updated).HasColumnName("updated");

            entity.HasOne(d => d.Site).WithOne(p => p.LocalSite)
                .HasForeignKey<LocalSite>(d => d.SiteId)
                .HasConstraintName("local_site_site_id_fkey");
        });

        modelBuilder.Entity<LocalSiteRateLimit>(entity =>
        {
            entity.HasKey(e => e.LocalSiteId).HasName("local_site_rate_limit_pkey");

            entity.ToTable("local_site_rate_limit");

            entity.Property(e => e.LocalSiteId)
                .ValueGeneratedNever()
                .HasColumnName("local_site_id");
            entity.Property(e => e.Comment)
                .HasDefaultValue(6)
                .HasColumnName("comment");
            entity.Property(e => e.CommentPerSecond)
                .HasDefaultValue(600)
                .HasColumnName("comment_per_second");
            entity.Property(e => e.Image)
                .HasDefaultValue(6)
                .HasColumnName("image");
            entity.Property(e => e.ImagePerSecond)
                .HasDefaultValue(3600)
                .HasColumnName("image_per_second");
            entity.Property(e => e.ImportUserSettings)
                .HasDefaultValue(1)
                .HasColumnName("import_user_settings");
            entity.Property(e => e.ImportUserSettingsPerSecond)
                .HasDefaultValue(86400)
                .HasColumnName("import_user_settings_per_second");
            entity.Property(e => e.Message)
                .HasDefaultValue(180)
                .HasColumnName("message");
            entity.Property(e => e.MessagePerSecond)
                .HasDefaultValue(60)
                .HasColumnName("message_per_second");
            entity.Property(e => e.Post)
                .HasDefaultValue(6)
                .HasColumnName("post");
            entity.Property(e => e.PostPerSecond)
                .HasDefaultValue(600)
                .HasColumnName("post_per_second");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnName("published");
            entity.Property(e => e.Register)
                .HasDefaultValue(3)
                .HasColumnName("register");
            entity.Property(e => e.RegisterPerSecond)
                .HasDefaultValue(3600)
                .HasColumnName("register_per_second");
            entity.Property(e => e.Search)
                .HasDefaultValue(60)
                .HasColumnName("search");
            entity.Property(e => e.SearchPerSecond)
                .HasDefaultValue(600)
                .HasColumnName("search_per_second");
            entity.Property(e => e.Updated).HasColumnName("updated");

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
            entity.Property(e => e.AcceptedApplication)
                .HasDefaultValue(false)
                .HasColumnName("accepted_application");
            entity.Property(e => e.Admin)
                .HasDefaultValue(false)
                .HasColumnName("admin");
            entity.Property(e => e.AutoExpand)
                .HasDefaultValue(false)
                .HasColumnName("auto_expand");
            entity.Property(e => e.BlurNsfw)
                .HasDefaultValue(true)
                .HasColumnName("blur_nsfw");
            entity.Property(e => e.CollapseBotComments)
                .HasDefaultValue(false)
                .HasColumnName("collapse_bot_comments");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.EmailVerified)
                .HasDefaultValue(false)
                .HasColumnName("email_verified");
            entity.Property(e => e.EnableAnimatedImages)
                .HasDefaultValue(true)
                .HasColumnName("enable_animated_images");
            entity.Property(e => e.EnableKeyboardNavigation)
                .HasDefaultValue(false)
                .HasColumnName("enable_keyboard_navigation");
            entity.Property(e => e.InfiniteScrollEnabled)
                .HasDefaultValue(false)
                .HasColumnName("infinite_scroll_enabled");
            entity.Property(e => e.InterfaceLanguage)
                .IsRequired()
                .HasMaxLength(20)
                .HasDefaultValueSql("'browser'::character varying")
                .HasColumnName("interface_language");
            entity.Property(e => e.OpenLinksInNewTab)
                .HasDefaultValue(false)
                .HasColumnName("open_links_in_new_tab");
            entity.Property(e => e.PasswordEncrypted)
                .IsRequired()
                .HasColumnName("password_encrypted");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.SendNotificationsToEmail)
                .HasDefaultValue(false)
                .HasColumnName("send_notifications_to_email");
            entity.Property(e => e.ShowAvatars)
                .HasDefaultValue(true)
                .HasColumnName("show_avatars");
            entity.Property(e => e.ShowBotAccounts)
                .HasDefaultValue(true)
                .HasColumnName("show_bot_accounts");
            entity.Property(e => e.ShowNsfw)
                .HasDefaultValue(false)
                .HasColumnName("show_nsfw");
            entity.Property(e => e.ShowReadPosts)
                .HasDefaultValue(true)
                .HasColumnName("show_read_posts");
            entity.Property(e => e.ShowScores)
                .HasDefaultValue(true)
                .HasColumnName("show_scores");
            entity.Property(e => e.Theme)
                .IsRequired()
                .HasDefaultValueSql("'browser'::text")
                .HasColumnName("theme");
            entity.Property(e => e.Totp2faEnabled)
                .HasDefaultValue(false)
                .HasColumnName("totp_2fa_enabled");
            entity.Property(e => e.Totp2faSecret).HasColumnName("totp_2fa_secret");

            entity.HasOne(d => d.Person).WithOne(p => p.LocalUser)
                .HasForeignKey<LocalUser>(d => d.PersonId)
                .HasConstraintName("local_user_person_id_fkey");

            entity.HasMany(d => d.Languages).WithMany(p => p.LocalUsers)
                .UsingEntity<Dictionary<string, object>>(
                    "LocalUserLanguage",
                    r => r.HasOne<Language>().WithMany()
                        .HasForeignKey("LanguageId")
                        .HasConstraintName("local_user_language_language_id_fkey"),
                    l => l.HasOne<LocalUser>().WithMany()
                        .HasForeignKey("LocalUserId")
                        .HasConstraintName("local_user_language_local_user_id_fkey"),
                    j =>
                    {
                        j.HasKey("LocalUserId", "LanguageId").HasName("local_user_language_pkey");
                        j.ToTable("local_user_language");
                        j.IndexerProperty<int>("LocalUserId").HasColumnName("local_user_id");
                        j.IndexerProperty<int>("LanguageId").HasColumnName("language_id");
                    });
        });

        modelBuilder.Entity<LoginToken>(entity =>
        {
            entity.HasKey(e => e.Token).HasName("login_token_pkey");

            entity.ToTable("login_token");

            entity.HasIndex(e => new { e.UserId, e.Token }, "idx_login_token_user_token");

            entity.Property(e => e.Token).HasColumnName("token");
            entity.Property(e => e.Ip).HasColumnName("ip");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnName("published");
            entity.Property(e => e.UserAgent).HasColumnName("user_agent");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.LoginTokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("login_token_user_id_fkey");
        });

        modelBuilder.Entity<ModAdd>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mod_add_pkey");

            entity.ToTable("mod_add");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ModPersonId).HasColumnName("mod_person_id");
            entity.Property(e => e.OtherPersonId).HasColumnName("other_person_id");
            entity.Property(e => e.Removed)
                .HasDefaultValue(false)
                .HasColumnName("removed");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
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
            entity.Property(e => e.Removed)
                .HasDefaultValue(false)
                .HasColumnName("removed");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
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
                .HasDefaultValue(true)
                .HasColumnName("banned");
            entity.Property(e => e.Expires).HasColumnName("expires");
            entity.Property(e => e.ModPersonId).HasColumnName("mod_person_id");
            entity.Property(e => e.OtherPersonId).HasColumnName("other_person_id");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
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
                .HasDefaultValue(true)
                .HasColumnName("banned");
            entity.Property(e => e.CommunityId).HasColumnName("community_id");
            entity.Property(e => e.Expires).HasColumnName("expires");
            entity.Property(e => e.ModPersonId).HasColumnName("mod_person_id");
            entity.Property(e => e.OtherPersonId).HasColumnName("other_person_id");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
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
                .HasDefaultValue(true)
                .HasColumnName("featured");
            entity.Property(e => e.IsFeaturedCommunity)
                .HasDefaultValue(true)
                .HasColumnName("is_featured_community");
            entity.Property(e => e.ModPersonId).HasColumnName("mod_person_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
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
            entity.Property(e => e.Hidden)
                .HasDefaultValue(false)
                .HasColumnName("hidden");
            entity.Property(e => e.ModPersonId).HasColumnName("mod_person_id");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
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
                .HasDefaultValue(true)
                .HasColumnName("locked");
            entity.Property(e => e.ModPersonId).HasColumnName("mod_person_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
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
                .HasDefaultValue(true)
                .HasColumnName("removed");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
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
            entity.Property(e => e.ModPersonId).HasColumnName("mod_person_id");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.Removed)
                .HasDefaultValue(true)
                .HasColumnName("removed");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
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
                .HasDefaultValue(true)
                .HasColumnName("removed");
            entity.Property(e => e.When)
                .HasDefaultValueSql("now()")
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
                .HasColumnName("published");
            entity.Property(e => e.Token)
                .IsRequired()
                .HasColumnName("token");

            entity.HasOne(d => d.LocalUser).WithMany(p => p.PasswordResetRequests)
                .HasForeignKey(d => d.LocalUserId)
                .HasConstraintName("password_reset_request_local_user_id_fkey");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("person__pkey");

            entity
                .ToTable("person")
                .HasAnnotation("Npgsql:StorageParameter:autovacuum_analyze_scale_factor", "0")
                .HasAnnotation("Npgsql:StorageParameter:autovacuum_analyze_threshold", "5")
                .HasAnnotation("Npgsql:StorageParameter:autovacuum_vacuum_scale_factor", "0.01")
                .HasAnnotation("Npgsql:StorageParameter:autovacuum_vacuum_threshold", "10");

            entity.HasIndex(e => e.ActorId, "idx_person_actor_id").IsUnique();

            entity.HasIndex(e => new { e.Local, e.InstanceId }, "idx_person_local_instance").IsDescending(true, false);

            entity.HasIndex(e => e.Published, "idx_person_published").IsDescending();

            entity.HasIndex(e => new { e.Name, e.DisplayName }, "idx_person_trigram")
                .HasMethod("gin")
                .HasOperators(new[] { "gin_trgm_ops", "gin_trgm_ops" });

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActorId)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValueSql("generate_unique_changeme()")
                .HasColumnName("actor_id");
            entity.Property(e => e.Avatar).HasColumnName("avatar");
            entity.Property(e => e.BanExpires).HasColumnName("ban_expires");
            entity.Property(e => e.Banned)
                .HasDefaultValue(false)
                .HasColumnName("banned");
            entity.Property(e => e.Banner).HasColumnName("banner");
            entity.Property(e => e.Bio).HasColumnName("bio");
            entity.Property(e => e.BotAccount)
                .HasDefaultValue(false)
                .HasColumnName("bot_account");
            entity.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .HasColumnName("deleted");
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
                .HasColumnName("last_refreshed_at");
            entity.Property(e => e.Local)
                .HasDefaultValue(true)
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
                .HasColumnName("published");
            entity.Property(e => e.SharedInboxUrl)
                .HasMaxLength(255)
                .HasColumnName("shared_inbox_url");
            entity.Property(e => e.Updated).HasColumnName("updated");

            entity.HasOne(d => d.Instance).WithMany(p => p.People)
                .HasForeignKey(d => d.InstanceId)
                .HasConstraintName("person_instance_id_fkey");
        });

        modelBuilder.Entity<PersonAggregate>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("person_aggregates_pkey");

            entity.ToTable("person_aggregates");

            entity.HasIndex(e => e.CommentScore, "idx_person_aggregates_comment_score").IsDescending();

            entity.HasIndex(e => e.PersonId, "idx_person_aggregates_person");

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnName("person_id");
            entity.Property(e => e.CommentCount)
                .HasDefaultValue(0L)
                .HasColumnName("comment_count");
            entity.Property(e => e.CommentScore)
                .HasDefaultValue(0L)
                .HasColumnName("comment_score");
            entity.Property(e => e.PostCount)
                .HasDefaultValue(0L)
                .HasColumnName("post_count");
            entity.Property(e => e.PostScore)
                .HasDefaultValue(0L)
                .HasColumnName("post_score");

            entity.HasOne(d => d.Person).WithOne(p => p.PersonAggregate)
                .HasForeignKey<PersonAggregate>(d => d.PersonId)
                .HasConstraintName("person_aggregates_person_id_fkey");
        });

        modelBuilder.Entity<PersonBan>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("person_ban_pkey");

            entity.ToTable("person_ban");

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnName("person_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnName("published");

            entity.HasOne(d => d.Person).WithOne(p => p.PersonBan)
                .HasForeignKey<PersonBan>(d => d.PersonId)
                .HasConstraintName("person_ban_person_id_fkey");
        });

        modelBuilder.Entity<PersonBlock>(entity =>
        {
            entity.HasKey(e => new { e.PersonId, e.TargetId }).HasName("person_block_pkey");

            entity.ToTable("person_block");

            entity.HasIndex(e => e.PersonId, "idx_person_block_person");

            entity.HasIndex(e => e.TargetId, "idx_person_block_target");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.TargetId).HasColumnName("target_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnName("published");

            entity.HasOne(d => d.Person).WithMany(p => p.PersonBlockPeople)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("person_block_person_id_fkey");

            entity.HasOne(d => d.Target).WithMany(p => p.PersonBlockTargets)
                .HasForeignKey(d => d.TargetId)
                .HasConstraintName("person_block_target_id_fkey");
        });

        modelBuilder.Entity<PersonFollower>(entity =>
        {
            entity.HasKey(e => new { e.FollowerId, e.PersonId }).HasName("person_follower_pkey");

            entity.ToTable("person_follower");

            entity.Property(e => e.FollowerId).HasColumnName("follower_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.Pending).HasColumnName("pending");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
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
                .HasColumnName("published");
            entity.Property(e => e.Read)
                .HasDefaultValue(false)
                .HasColumnName("read");
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
            entity.HasKey(e => new { e.PersonId, e.PostId }).HasName("person_post_aggregates_pkey");

            entity.ToTable("person_post_aggregates");

            entity.HasIndex(e => e.PersonId, "idx_person_post_aggregates_person");

            entity.HasIndex(e => e.PostId, "idx_person_post_aggregates_post");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnName("published");
            entity.Property(e => e.ReadComments)
                .HasDefaultValue(0L)
                .HasColumnName("read_comments");

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

            entity
                .ToTable("post")
                .HasAnnotation("Npgsql:StorageParameter:autovacuum_analyze_scale_factor", "0")
                .HasAnnotation("Npgsql:StorageParameter:autovacuum_analyze_threshold", "30")
                .HasAnnotation("Npgsql:StorageParameter:autovacuum_vacuum_scale_factor", "0.05")
                .HasAnnotation("Npgsql:StorageParameter:autovacuum_vacuum_threshold", "100");

            entity.HasIndex(e => e.ApId, "idx_post_ap_id").IsUnique();

            entity.HasIndex(e => e.CommunityId, "idx_post_community");

            entity.HasIndex(e => e.CreatorId, "idx_post_creator");

            entity.HasIndex(e => e.LanguageId, "idx_post_language");

            entity.HasIndex(e => new { e.Name, e.Body }, "idx_post_trigram")
                .HasMethod("gin")
                .HasOperators(new[] { "gin_trgm_ops", "gin_trgm_ops" });

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
            entity.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .HasColumnName("deleted");
            entity.Property(e => e.EmbedDescription).HasColumnName("embed_description");
            entity.Property(e => e.EmbedTitle).HasColumnName("embed_title");
            entity.Property(e => e.EmbedVideoUrl).HasColumnName("embed_video_url");
            entity.Property(e => e.FeaturedCommunity)
                .HasDefaultValue(false)
                .HasColumnName("featured_community");
            entity.Property(e => e.FeaturedLocal)
                .HasDefaultValue(false)
                .HasColumnName("featured_local");
            entity.Property(e => e.LanguageId)
                .HasDefaultValue(0)
                .HasColumnName("language_id");
            entity.Property(e => e.Local)
                .HasDefaultValue(true)
                .HasColumnName("local");
            entity.Property(e => e.Locked)
                .HasDefaultValue(false)
                .HasColumnName("locked");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Nsfw)
                .HasDefaultValue(false)
                .HasColumnName("nsfw");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnName("published");
            entity.Property(e => e.Removed)
                .HasDefaultValue(false)
                .HasColumnName("removed");
            entity.Property(e => e.ThumbnailUrl).HasColumnName("thumbnail_url");
            entity.Property(e => e.Updated).HasColumnName("updated");
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
            entity.HasKey(e => e.PostId).HasName("post_aggregates_pkey");

            entity.ToTable("post_aggregates");

            entity.HasIndex(e => new { e.CommunityId, e.FeaturedLocal, e.HotRankActive, e.Published }, "idx_post_aggregates_community_active").IsDescending(false, true, true, true);

            entity.HasIndex(e => new { e.CommunityId, e.FeaturedLocal, e.ControversyRank }, "idx_post_aggregates_community_controversy").IsDescending(false, true, true);

            entity.HasIndex(e => new { e.CommunityId, e.FeaturedLocal, e.HotRank, e.Published }, "idx_post_aggregates_community_hot").IsDescending(false, true, true, true);

            entity.HasIndex(e => new { e.CommunityId, e.FeaturedLocal, e.Comments, e.Published }, "idx_post_aggregates_community_most_comments").IsDescending(false, true, true, true);

            entity.HasIndex(e => new { e.CommunityId, e.FeaturedLocal, e.NewestCommentTime }, "idx_post_aggregates_community_newest_comment_time").IsDescending(false, true, true);

            entity.HasIndex(e => new { e.CommunityId, e.FeaturedLocal, e.NewestCommentTimeNecro }, "idx_post_aggregates_community_newest_comment_time_necro").IsDescending(false, true, true);

            entity.HasIndex(e => new { e.CommunityId, e.FeaturedLocal, e.Published }, "idx_post_aggregates_community_published").IsDescending(false, true, true);

            entity.HasIndex(e => new { e.CommunityId, e.FeaturedLocal, e.ScaledRank, e.Published }, "idx_post_aggregates_community_scaled").IsDescending(false, true, true, true);

            entity.HasIndex(e => new { e.CommunityId, e.FeaturedLocal, e.Score, e.Published }, "idx_post_aggregates_community_score").IsDescending(false, true, true, true);

            entity.HasIndex(e => new { e.CommunityId, e.FeaturedCommunity, e.HotRankActive, e.Published }, "idx_post_aggregates_featured_community_active").IsDescending(false, true, true, true);

            entity.HasIndex(e => new { e.FeaturedCommunity, e.Comments }, "idx_post_aggregates_featured_community_comments_ccnew").IsDescending();

            entity.HasIndex(e => new { e.CommunityId, e.FeaturedCommunity, e.ControversyRank }, "idx_post_aggregates_featured_community_controversy").IsDescending(false, true, true);

            entity.HasIndex(e => new { e.CommunityId, e.FeaturedCommunity, e.HotRank, e.Published }, "idx_post_aggregates_featured_community_hot").IsDescending(false, true, true, true);

            entity.HasIndex(e => new { e.CommunityId, e.FeaturedCommunity, e.Comments, e.Published }, "idx_post_aggregates_featured_community_most_comments").IsDescending(false, true, true, true);

            entity.HasIndex(e => new { e.FeaturedCommunity, e.NewestCommentTime }, "idx_post_aggregates_featured_community_newest_comment_tim_ccnew").IsDescending();

            entity.HasIndex(e => new { e.CommunityId, e.FeaturedCommunity, e.NewestCommentTime }, "idx_post_aggregates_featured_community_newest_comment_time").IsDescending(false, true, true);

            entity.HasIndex(e => new { e.CommunityId, e.FeaturedCommunity, e.NewestCommentTimeNecro }, "idx_post_aggregates_featured_community_newest_comment_time_necr").IsDescending(false, true, true);

            entity.HasIndex(e => new { e.CommunityId, e.FeaturedCommunity, e.Published }, "idx_post_aggregates_featured_community_published").IsDescending(false, true, true);

            entity.HasIndex(e => new { e.FeaturedCommunity, e.Published }, "idx_post_aggregates_featured_community_published_ccnew").IsDescending();

            entity.HasIndex(e => new { e.CommunityId, e.FeaturedCommunity, e.ScaledRank, e.Published }, "idx_post_aggregates_featured_community_scaled").IsDescending(false, true, true, true);

            entity.HasIndex(e => new { e.CommunityId, e.FeaturedCommunity, e.Score, e.Published }, "idx_post_aggregates_featured_community_score").IsDescending(false, true, true, true);

            entity.HasIndex(e => new { e.FeaturedCommunity, e.Score }, "idx_post_aggregates_featured_community_score_ccnew").IsDescending();

            entity.HasIndex(e => new { e.FeaturedLocal, e.HotRankActive, e.Published }, "idx_post_aggregates_featured_local_active").IsDescending();

            entity.HasIndex(e => new { e.FeaturedLocal, e.Comments }, "idx_post_aggregates_featured_local_comments_ccnew").IsDescending();

            entity.HasIndex(e => new { e.FeaturedLocal, e.ControversyRank }, "idx_post_aggregates_featured_local_controversy").IsDescending();

            entity.HasIndex(e => new { e.FeaturedLocal, e.HotRank, e.Published }, "idx_post_aggregates_featured_local_hot").IsDescending();

            entity.HasIndex(e => new { e.FeaturedLocal, e.Comments, e.Published }, "idx_post_aggregates_featured_local_most_comments").IsDescending();

            entity.HasIndex(e => new { e.FeaturedLocal, e.NewestCommentTime }, "idx_post_aggregates_featured_local_newest_comment_time").IsDescending();

            entity.HasIndex(e => new { e.FeaturedLocal, e.NewestCommentTime }, "idx_post_aggregates_featured_local_newest_comment_time_ccnew").IsDescending();

            entity.HasIndex(e => new { e.FeaturedLocal, e.NewestCommentTimeNecro }, "idx_post_aggregates_featured_local_newest_comment_time_necro").IsDescending();

            entity.HasIndex(e => new { e.FeaturedLocal, e.Published }, "idx_post_aggregates_featured_local_published").IsDescending();

            entity.HasIndex(e => new { e.FeaturedLocal, e.Published }, "idx_post_aggregates_featured_local_published_ccnew").IsDescending();

            entity.HasIndex(e => new { e.FeaturedLocal, e.ScaledRank, e.Published }, "idx_post_aggregates_featured_local_scaled").IsDescending();

            entity.HasIndex(e => new { e.FeaturedLocal, e.Score, e.Published }, "idx_post_aggregates_featured_local_score").IsDescending();

            entity.HasIndex(e => new { e.FeaturedLocal, e.Score }, "idx_post_aggregates_featured_local_score_ccnew").IsDescending();

            entity.HasIndex(e => e.Published, "idx_post_aggregates_nonzero_hotrank")
                .IsDescending()
                .HasFilter("((hot_rank <> (0)::double precision) OR (hot_rank_active <> (0)::double precision))");

            entity.HasIndex(e => e.Published, "idx_post_aggregates_published").IsDescending();

            entity.HasIndex(e => e.PostId, "post_aggregates_post_id_key_ccnew").IsUnique();

            entity.Property(e => e.PostId)
                .ValueGeneratedNever()
                .HasColumnName("post_id");
            entity.Property(e => e.Comments)
                .HasDefaultValue(0L)
                .HasColumnName("comments");
            entity.Property(e => e.CommunityId).HasColumnName("community_id");
            entity.Property(e => e.ControversyRank).HasColumnName("controversy_rank");
            entity.Property(e => e.CreatorId).HasColumnName("creator_id");
            entity.Property(e => e.Downvotes)
                .HasDefaultValue(0L)
                .HasColumnName("downvotes");
            entity.Property(e => e.FeaturedCommunity)
                .HasDefaultValue(false)
                .HasColumnName("featured_community");
            entity.Property(e => e.FeaturedLocal)
                .HasDefaultValue(false)
                .HasColumnName("featured_local");
            entity.Property(e => e.HotRank)
                .HasDefaultValueSql("0.0001")
                .HasColumnName("hot_rank");
            entity.Property(e => e.HotRankActive)
                .HasDefaultValueSql("0.0001")
                .HasColumnName("hot_rank_active");
            entity.Property(e => e.InstanceId).HasColumnName("instance_id");
            entity.Property(e => e.NewestCommentTime)
                .HasDefaultValueSql("now()")
                .HasColumnName("newest_comment_time");
            entity.Property(e => e.NewestCommentTimeNecro)
                .HasDefaultValueSql("now()")
                .HasColumnName("newest_comment_time_necro");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnName("published");
            entity.Property(e => e.ScaledRank)
                .HasDefaultValueSql("0.0001")
                .HasColumnName("scaled_rank");
            entity.Property(e => e.Score)
                .HasDefaultValue(0L)
                .HasColumnName("score");
            entity.Property(e => e.Upvotes)
                .HasDefaultValue(0L)
                .HasColumnName("upvotes");

            entity.HasOne(d => d.Community).WithMany(p => p.PostAggregates)
                .HasForeignKey(d => d.CommunityId)
                .HasConstraintName("post_aggregates_community_id_fkey");

            entity.HasOne(d => d.Creator).WithMany(p => p.PostAggregates)
                .HasForeignKey(d => d.CreatorId)
                .HasConstraintName("post_aggregates_creator_id_fkey");

            entity.HasOne(d => d.Instance).WithMany(p => p.PostAggregates)
                .HasForeignKey(d => d.InstanceId)
                .HasConstraintName("post_aggregates_instance_id_fkey");

            entity.HasOne(d => d.Post).WithOne(p => p.PostAggregate)
                .HasForeignKey<PostAggregate>(d => d.PostId)
                .HasConstraintName("post_aggregates_post_id_fkey");
        });

        modelBuilder.Entity<PostLike>(entity =>
        {
            entity.HasKey(e => new { e.PersonId, e.PostId }).HasName("post_like_pkey");

            entity
                .ToTable("post_like")
                .HasAnnotation("Npgsql:StorageParameter:autovacuum_analyze_scale_factor", "0.05")
                .HasAnnotation("Npgsql:StorageParameter:autovacuum_analyze_threshold", "100")
                .HasAnnotation("Npgsql:StorageParameter:autovacuum_vacuum_scale_factor", "0.05")
                .HasAnnotation("Npgsql:StorageParameter:autovacuum_vacuum_threshold", "100");

            entity.HasIndex(e => e.PostId, "idx_post_like_post");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
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
            entity.HasKey(e => new { e.PersonId, e.PostId }).HasName("post_read_pkey");

            entity.ToTable("post_read");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
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
                .HasColumnName("published");
            entity.Property(e => e.Reason)
                .IsRequired()
                .HasColumnName("reason");
            entity.Property(e => e.Resolved)
                .HasDefaultValue(false)
                .HasColumnName("resolved");
            entity.Property(e => e.ResolverId).HasColumnName("resolver_id");
            entity.Property(e => e.Updated).HasColumnName("updated");

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
            entity.HasKey(e => new { e.PersonId, e.PostId }).HasName("post_saved_pkey");

            entity.ToTable("post_saved");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
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
            entity.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .HasColumnName("deleted");
            entity.Property(e => e.Local)
                .HasDefaultValue(true)
                .HasColumnName("local");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnName("published");
            entity.Property(e => e.Read)
                .HasDefaultValue(false)
                .HasColumnName("read");
            entity.Property(e => e.RecipientId).HasColumnName("recipient_id");
            entity.Property(e => e.Updated).HasColumnName("updated");

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
                .HasColumnName("published");
            entity.Property(e => e.Reason)
                .IsRequired()
                .HasColumnName("reason");
            entity.Property(e => e.Resolved)
                .HasDefaultValue(false)
                .HasColumnName("resolved");
            entity.Property(e => e.ResolverId).HasColumnName("resolver_id");
            entity.Property(e => e.Updated).HasColumnName("updated");

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

        modelBuilder.Entity<ReceivedActivity>(entity =>
        {
            entity.HasKey(e => e.ApId).HasName("received_activity_pkey");

            entity.ToTable("received_activity");

            entity.Property(e => e.ApId).HasColumnName("ap_id");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnName("published");
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

        modelBuilder.Entity<SentActivity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sent_activity_pkey");

            entity.ToTable("sent_activity");

            entity.HasIndex(e => e.ApId, "sent_activity_ap_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActorApubId).HasColumnName("actor_apub_id");
            entity.Property(e => e.ApId)
                .IsRequired()
                .HasColumnName("ap_id");
            entity.Property(e => e.Data)
                .IsRequired()
                .HasColumnType("json")
                .HasColumnName("data");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("now()")
                .HasColumnName("published");
            entity.Property(e => e.SendAllInstances).HasColumnName("send_all_instances");
            entity.Property(e => e.SendCommunityFollowersOf).HasColumnName("send_community_followers_of");
            entity.Property(e => e.SendInboxes)
                .IsRequired()
                .HasColumnName("send_inboxes");
            entity.Property(e => e.Sensitive).HasColumnName("sensitive");
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
                .HasColumnName("published");
            entity.Property(e => e.Sidebar).HasColumnName("sidebar");
            entity.Property(e => e.Updated).HasColumnName("updated");

            entity.HasOne(d => d.Instance).WithOne(p => p.Site)
                .HasForeignKey<Site>(d => d.InstanceId)
                .HasConstraintName("site_instance_id_fkey");

            entity.HasMany(d => d.Languages).WithMany(p => p.Sites)
                .UsingEntity<Dictionary<string, object>>(
                    "SiteLanguage",
                    r => r.HasOne<Language>().WithMany()
                        .HasForeignKey("LanguageId")
                        .HasConstraintName("site_language_language_id_fkey"),
                    l => l.HasOne<Site>().WithMany()
                        .HasForeignKey("SiteId")
                        .HasConstraintName("site_language_site_id_fkey"),
                    j =>
                    {
                        j.HasKey("SiteId", "LanguageId").HasName("site_language_pkey");
                        j.ToTable("site_language");
                        j.IndexerProperty<int>("SiteId").HasColumnName("site_id");
                        j.IndexerProperty<int>("LanguageId").HasColumnName("language_id");
                    });
        });

        modelBuilder.Entity<SiteAggregate>(entity =>
        {
            entity.HasKey(e => e.SiteId).HasName("site_aggregates_pkey");

            entity.ToTable("site_aggregates");

            entity.Property(e => e.SiteId)
                .ValueGeneratedNever()
                .HasColumnName("site_id");
            entity.Property(e => e.Comments)
                .HasDefaultValue(0L)
                .HasColumnName("comments");
            entity.Property(e => e.Communities)
                .HasDefaultValue(0L)
                .HasColumnName("communities");
            entity.Property(e => e.Posts)
                .HasDefaultValue(0L)
                .HasColumnName("posts");
            entity.Property(e => e.Users)
                .HasDefaultValue(1L)
                .HasColumnName("users");
            entity.Property(e => e.UsersActiveDay)
                .HasDefaultValue(0L)
                .HasColumnName("users_active_day");
            entity.Property(e => e.UsersActiveHalfYear)
                .HasDefaultValue(0L)
                .HasColumnName("users_active_half_year");
            entity.Property(e => e.UsersActiveMonth)
                .HasDefaultValue(0L)
                .HasColumnName("users_active_month");
            entity.Property(e => e.UsersActiveWeek)
                .HasDefaultValue(0L)
                .HasColumnName("users_active_week");

            entity.HasOne(d => d.Site).WithOne(p => p.SiteAggregate)
                .HasForeignKey<SiteAggregate>(d => d.SiteId)
                .HasConstraintName("site_aggregates_site_id_fkey");
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
                .HasColumnName("published");
            entity.Property(e => e.Updated).HasColumnName("updated");

            entity.HasOne(d => d.LocalSite).WithMany(p => p.Taglines)
                .HasForeignKey(d => d.LocalSiteId)
                .HasConstraintName("tagline_local_site_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
