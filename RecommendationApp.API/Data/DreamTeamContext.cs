using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RecommendationApp.API.Models;

namespace RecommendationApp.API.Data
{
    public partial class DreamTeamContext : DbContext
    {
        public DreamTeamContext()
        {
        }

        public DreamTeamContext(DbContextOptions<DreamTeamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MapsStats> MapsStats { get; set; }
        public virtual DbSet<PlayersStatsLog> PlayersStatsLog { get; set; }
        public virtual DbSet<Profiles> Profiles { get; set; }
        public virtual DbSet<Profiles1> Profiles1 { get; set; }
        public virtual DbSet<ProfilesRatings> ProfilesRatings { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<TeamBestMaps> TeamBestMaps { get; set; }
        public virtual DbSet<TeamsData> TeamsData { get; set; }
        public virtual DbSet<TeamsUsers> TeamsUsers { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WeaponsStats> WeaponsStats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<MapsStats>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.MapName })
                    .HasName("maps_stats_pkey");

                entity.ToTable("maps_stats", "csgo");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.MapName).HasColumnName("map_name");

                entity.Property(e => e.TotalRounds).HasColumnName("total_rounds");

                entity.Property(e => e.TotalWins).HasColumnName("total_wins");
            });

            modelBuilder.Entity<PlayersStatsLog>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.AtDay })
                    .HasName("players_stats_log_pkey");

                entity.ToTable("players_stats_log", "csgo");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.AtDay)
                    .HasColumnName("at_day")
                    .HasColumnType("date")
                    .HasDefaultValueSql("('now'::text)::date");

                entity.Property(e => e.TotalDeaths).HasColumnName("total_deaths");

                entity.Property(e => e.TotalKills).HasColumnName("total_kills");

                entity.Property(e => e.TotalKillsHeadshot).HasColumnName("total_kills_headshot");
            });

            modelBuilder.Entity<Profiles>(entity =>
            {
                entity.ToTable("profiles", "core");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('core.profiles_id_seq'::regclass)");

                entity.Property(e => e.AtTime)
                    .HasColumnName("at_time_")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Profiles1>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("profiles_pkey");

                entity.ToTable("profiles", "csgo");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.About).HasColumnName("about");

                entity.Property(e => e.GoalId).HasColumnName("goal_id");

                entity.Property(e => e.RankId).HasColumnName("rank_id");

                entity.Property(e => e.TotalDeaths).HasColumnName("total_deaths");

                entity.Property(e => e.TotalKills).HasColumnName("total_kills");

                entity.Property(e => e.TotalKillsHeadshot).HasColumnName("total_kills_headshot");

                entity.Property(e => e.TotalMvps).HasColumnName("total_mvps");

                entity.Property(e => e.TotalRoundsPlayed).HasColumnName("total_rounds_played");

                entity.Property(e => e.TotalShotsFired).HasColumnName("total_shots_fired");

                entity.Property(e => e.TotalShotsHit).HasColumnName("total_shots_hit");

                entity.Property(e => e.TotalTimePlayed).HasColumnName("total_time_played");

                entity.Property(e => e.TotalWins).HasColumnName("total_wins");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<ProfilesRatings>(entity =>
            {
                entity.HasKey(e => e.ProfileId)
                    .HasName("profiles_ratings_pkey");

                entity.ToTable("profiles_ratings", "games");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.NumRates).HasColumnName("num_rates");

                entity.Property(e => e.Rating).HasColumnName("rating");
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.ToTable("reviews", "core");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('core.reviews_id_seq'::regclass)");

                entity.Property(e => e.AtTime)
                    .HasColumnName("at_time")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Likes)
                    .HasColumnName("likes")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.Property(e => e.RateWeight)
                    .HasColumnName("rate_weight")
                    .HasDefaultValueSql("1.0");

                entity.Property(e => e.ReviewerProfileId).HasColumnName("reviewer_profile_id");
            });

            modelBuilder.Entity<TeamBestMaps>(entity =>
            {
                entity.HasKey(e => new { e.ProfileId, e.MapName })
                    .HasName("team_best_maps_pkey");

                entity.ToTable("team_best_maps", "csgo");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.MapName).HasColumnName("map_name");

                entity.Property(e => e.Place).HasColumnName("place");
            });

            modelBuilder.Entity<TeamsData>(entity =>
            {
                entity.HasKey(e => e.ProfileId)
                    .HasName("teams_data_pkey");

                entity.ToTable("teams_data", "core");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profile_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.About).HasColumnName("about");

                entity.Property(e => e.Country).HasColumnName("country");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.FacebookLink).HasColumnName("facebook_link");

                entity.Property(e => e.GoalId).HasColumnName("goal_id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.Property(e => e.SteamLink).HasColumnName("steam_link");

                entity.Property(e => e.TwitchLink).HasColumnName("twitch_link");

                entity.Property(e => e.TwitterLink).HasColumnName("twitter_link");

                entity.Property(e => e.VkLink).HasColumnName("vk_link");

                entity.Property(e => e.WebsiteLink).HasColumnName("website_link");

                entity.Property(e => e.YoutubeLink).HasColumnName("youtube_link");
            });

            modelBuilder.Entity<TeamsUsers>(entity =>
            {
                entity.HasKey(e => new { e.TeamProfileId, e.UserProfileId })
                    .HasName("teams_users_pkey");

                entity.ToTable("teams_users", "core");

                entity.Property(e => e.TeamProfileId).HasColumnName("team_profile_id");

                entity.Property(e => e.UserProfileId).HasColumnName("user_profile_id");

                entity.Property(e => e.AtTime)
                    .HasColumnName("at_time__")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users", "core");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('core.users_id_seq'::regclass)");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("date");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.Country).HasColumnName("country");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.ReceiveEmails)
                    .HasColumnName("receive_emails")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("'new'::text");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Verified).HasColumnName("verified");
            });

            modelBuilder.Entity<WeaponsStats>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.WeaponName })
                    .HasName("weapons_stats_pkey");

                entity.ToTable("weapons_stats", "csgo");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.WeaponName).HasColumnName("weapon_name");

                entity.Property(e => e.TotalHits).HasColumnName("total_hits");

                entity.Property(e => e.TotalKills).HasColumnName("total_kills");

                entity.Property(e => e.TotalShots).HasColumnName("total_shots");
            });

            modelBuilder.HasSequence("profiles_id_seq");

            modelBuilder.HasSequence("reviews_characteristics_id_seq");

            modelBuilder.HasSequence("reviews_id_seq");

            modelBuilder.HasSequence("teams_players_activity_id_seq");

            modelBuilder.HasSequence("users_id_seq");

            modelBuilder.HasSequence("vacancies_id_seq");
        }
    }
}
