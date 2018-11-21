using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CHIS.Core.Domain
{
    public partial class hotel_dbContext : DbContext
    {
        public hotel_dbContext()
        {
        }

        public hotel_dbContext(DbContextOptions<hotel_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<account_types> account_types { get; set; }
        public virtual DbSet<accounts> accounts { get; set; }
        public virtual DbSet<advancesetting> advancesetting { get; set; }
        public virtual DbSet<amenities> amenities { get; set; }
        public virtual DbSet<amenity_types> amenity_types { get; set; }
        public virtual DbSet<application_configurations> application_configurations { get; set; }
        public virtual DbSet<arrival_departure_infos> arrival_departure_infos { get; set; }
        public virtual DbSet<business_source_types> business_source_types { get; set; }
        public virtual DbSet<business_sources> business_sources { get; set; }
        public virtual DbSet<card_type_prefixes> card_type_prefixes { get; set; }
        public virtual DbSet<configurations> configurations { get; set; }
        public virtual DbSet<dashboard> dashboard { get; set; }
        public virtual DbSet<discount_plans> discount_plans { get; set; }
        public virtual DbSet<dnr_lists> dnr_lists { get; set; }
        public virtual DbSet<email_accounts> email_accounts { get; set; }
        public virtual DbSet<exchange_rates> exchange_rates { get; set; }
        public virtual DbSet<extra_charge_categories> extra_charge_categories { get; set; }
        public virtual DbSet<extra_charges> extra_charges { get; set; }
        public virtual DbSet<floors> floors { get; set; }
        public virtual DbSet<follow_up_types> follow_up_types { get; set; }
        public virtual DbSet<hotel_representatives> hotel_representatives { get; set; }
        public virtual DbSet<identities> identities { get; set; }
        public virtual DbSet<invoice_settings> invoice_settings { get; set; }
        public virtual DbSet<mainconfig> mainconfig { get; set; }
        public virtual DbSet<mastersetup> mastersetup { get; set; }
        public virtual DbSet<meal_plans> meal_plans { get; set; }
        public virtual DbSet<miscellaneous> miscellaneous { get; set; }
        public virtual DbSet<non_rental_units> non_rental_units { get; set; }
        public virtual DbSet<notices> notices { get; set; }
        public virtual DbSet<payment_methods> payment_methods { get; set; }
        public virtual DbSet<property_details> property_details { get; set; }
        public virtual DbSet<propertysetup> propertysetup { get; set; }
        public virtual DbSet<rate_types> rate_types { get; set; }
        public virtual DbSet<rates> rates { get; set; }
        public virtual DbSet<remark_categories> remark_categories { get; set; }
        public virtual DbSet<remarks> remarks { get; set; }
        public virtual DbSet<reservation_log_entries> reservation_log_entries { get; set; }
        public virtual DbSet<reservation_transaction> reservation_transaction { get; set; }
        public virtual DbSet<reservations> reservations { get; set; }
        public virtual DbSet<reserved_rooms> reserved_rooms { get; set; }
        public virtual DbSet<revenue_breakdowns> revenue_breakdowns { get; set; }
        public virtual DbSet<roles> roles { get; set; }
        public virtual DbSet<room_images> room_images { get; set; }
        public virtual DbSet<room_owners> room_owners { get; set; }
        public virtual DbSet<room_status_colors> room_status_colors { get; set; }
        public virtual DbSet<room_types> room_types { get; set; }
        public virtual DbSet<room_types_rates> room_types_rates { get; set; }
        public virtual DbSet<rooms> rooms { get; set; }
        public virtual DbSet<rooms_amenities> rooms_amenities { get; set; }
        public virtual DbSet<rooms_week_days> rooms_week_days { get; set; }
        public virtual DbSet<season_types> season_types { get; set; }
        public virtual DbSet<seasons> seasons { get; set; }
        public virtual DbSet<settlement_types> settlement_types { get; set; }
        public virtual DbSet<settlements> settlements { get; set; }
        public virtual DbSet<tax_setting_types> tax_setting_types { get; set; }
        public virtual DbSet<tax_settings> tax_settings { get; set; }
        public virtual DbSet<taxes> taxes { get; set; }
        public virtual DbSet<templates> templates { get; set; }
        public virtual DbSet<transportaion_statitions> transportaion_statitions { get; set; }
        public virtual DbSet<transportation_types> transportation_types { get; set; }
        public virtual DbSet<transportations> transportations { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<users_roles> users_roles { get; set; }
        public virtual DbSet<week_days> week_days { get; set; }
        public virtual DbSet<wings> wings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=hotel_db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<account_types>(entity =>
            {
                entity.ToTable("account_types", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.account_type_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<accounts>(entity =>
            {
                entity.ToTable("accounts", "hotel_db");

                entity.HasIndex(e => e.account_type_id)
                    .HasName("account_type_key_2000");

                entity.HasIndex(e => e.hotel_representative_id)
                    .HasName("hotel_representative_key_200");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.account_number)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.account_type_id).HasColumnType("int(11)");

                entity.Property(e => e.address1)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.address2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.card_holder)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.card_number)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.city)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.country)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.created_by)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.credit_card_type)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.credit_limit).HasColumnType("decimal(20,2)");

                entity.Property(e => e.email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.fax)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.first_name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.group_name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.hotel_representative_id).HasColumnType("int(11)");

                entity.Property(e => e.last_name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.opening_balance).HasColumnType("decimal(20,2)");

                entity.Property(e => e.payment_term).HasColumnType("decimal(20,2)");

                entity.Property(e => e.phone)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.postal_code)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.reg_number)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.reg_number1)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.reg_number2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.remark).IsUnicode(false);

                entity.Property(e => e.state)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.account_type_)
                    .WithMany(p => p.accounts)
                    .HasForeignKey(d => d.account_type_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("account_type_key_2000");

                entity.HasOne(d => d.hotel_representative_)
                    .WithMany(p => p.accounts)
                    .HasForeignKey(d => d.hotel_representative_id)
                    .HasConstraintName("hotel_representative_key_200");
            });

            modelBuilder.Entity<advancesetting>(entity =>
            {
                entity.ToTable("advancesetting", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");
            });

            modelBuilder.Entity<amenities>(entity =>
            {
                entity.ToTable("amenities", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.amenity_logo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.amenity_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.amenity_type_id).HasColumnType("int(11)");
            });

            modelBuilder.Entity<amenity_types>(entity =>
            {
                entity.ToTable("amenity_types", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.amenity_type_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<application_configurations>(entity =>
            {
                entity.ToTable("application_configurations", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.application_logo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.application_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.application_theme)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.login_banner)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<arrival_departure_infos>(entity =>
            {
                entity.ToTable("arrival_departure_infos", "hotel_db");

                entity.HasIndex(e => e.reservation_id)
                    .HasName("reservations__key_2354320");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.pickup_time)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.reservation_id).HasColumnType("int(11)");

                entity.Property(e => e.transaction_type)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.reservation_)
                    .WithMany(p => p.arrival_departure_infos)
                    .HasForeignKey(d => d.reservation_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reservations__key_2354320");
            });

            modelBuilder.Entity<business_source_types>(entity =>
            {
                entity.ToTable("business_source_types", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.business_source_type_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<business_sources>(entity =>
            {
                entity.ToTable("business_sources", "hotel_db");

                entity.HasIndex(e => e.business_source_types_id)
                    .HasName("business_source_types_key_200");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.business_source_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.business_source_types_id).HasColumnType("int(11)");

                entity.HasOne(d => d.business_source_types_)
                    .WithMany(p => p.business_sources)
                    .HasForeignKey(d => d.business_source_types_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("business_source_types_key_200");
            });

            modelBuilder.Entity<card_type_prefixes>(entity =>
            {
                entity.ToTable("card_type_prefixes", "hotel_db");

                entity.HasIndex(e => e.settlement_type_id)
                    .HasName("settlement_types_key_200");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.credit_card_type)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.prefix)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.settlement_type_id).HasColumnType("int(11)");

                entity.HasOne(d => d.settlement_type_)
                    .WithMany(p => p.card_type_prefixes)
                    .HasForeignKey(d => d.settlement_type_id)
                    .HasConstraintName("settlement_types_key_200");
            });

            modelBuilder.Entity<configurations>(entity =>
            {
                entity.ToTable("configurations", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.country_alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.country_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.curr_sign)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.financial_period_from_day).HasColumnType("int(11)");

                entity.Property(e => e.financial_period_from_month)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.financial_period_to_day).HasColumnType("int(11)");

                entity.Property(e => e.financial_period_to_month)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.state_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.zip)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<dashboard>(entity =>
            {
                entity.ToTable("dashboard", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");
            });

            modelBuilder.Entity<discount_plans>(entity =>
            {
                entity.ToTable("discount_plans", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.note).IsUnicode(false);

                entity.Property(e => e.plan_category)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.plan_name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<dnr_lists>(entity =>
            {
                entity.ToTable("dnr_lists", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.description).IsUnicode(false);

                entity.Property(e => e.dnr_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<email_accounts>(entity =>
            {
                entity.ToTable("email_accounts", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.email_address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.login_using_ssl).HasColumnType("tinyint(4)");

                entity.Property(e => e.mail_server)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.mail_server_port)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.sender_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.use_proxysettings).HasColumnType("tinyint(4)");

                entity.Property(e => e.user_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<exchange_rates>(entity =>
            {
                entity.ToTable("exchange_rates", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.active).HasColumnType("tinyint(4)");

                entity.Property(e => e.country_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.currency_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.currency_symbol)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.decimal_place).HasColumnType("int(11)");

                entity.Property(e => e.exchange_rate).HasColumnType("decimal(20,2)");

                entity.Property(e => e.symbol_placement)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<extra_charge_categories>(entity =>
            {
                entity.ToTable("extra_charge_categories", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.category_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.description).IsUnicode(false);
            });

            modelBuilder.Entity<extra_charges>(entity =>
            {
                entity.ToTable("extra_charges", "hotel_db");

                entity.HasIndex(e => e.extra_charge_category_id)
                    .HasName("extra_charge_categories_key_200");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.description).IsUnicode(false);

                entity.Property(e => e.extra_charge_category_id).HasColumnType("int(11)");

                entity.Property(e => e.extra_charge_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.rate).HasColumnType("decimal(20,2)");

                entity.HasOne(d => d.extra_charge_category_)
                    .WithMany(p => p.extra_charges)
                    .HasForeignKey(d => d.extra_charge_category_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("extra_charge_categories_key_200");
            });

            modelBuilder.Entity<floors>(entity =>
            {
                entity.ToTable("floors", "hotel_db");

                entity.HasIndex(e => e.wing_id)
                    .HasName("wings_key2000");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.description).IsUnicode(false);

                entity.Property(e => e.floor_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.sort_key).HasColumnType("int(11)");

                entity.Property(e => e.wing_id).HasColumnType("int(11)");

                entity.HasOne(d => d.wing_)
                    .WithMany(p => p.floors)
                    .HasForeignKey(d => d.wing_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("wings_key2000");
            });

            modelBuilder.Entity<follow_up_types>(entity =>
            {
                entity.ToTable("follow_up_types", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.color)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.type_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<hotel_representatives>(entity =>
            {
                entity.ToTable("hotel_representatives", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.hotel_representative_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<identities>(entity =>
            {
                entity.ToTable("identities", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.description).IsUnicode(false);

                entity.Property(e => e.identity_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.sort_key).HasColumnType("int(11)");
            });

            modelBuilder.Entity<invoice_settings>(entity =>
            {
                entity.ToTable("invoice_settings", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.invoice_variable_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.number_type)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.prefix)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.start_from).HasColumnType("int(11)");
            });

            modelBuilder.Entity<mainconfig>(entity =>
            {
                entity.ToTable("mainconfig", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");
            });

            modelBuilder.Entity<mastersetup>(entity =>
            {
                entity.ToTable("mastersetup", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");
            });

            modelBuilder.Entity<meal_plans>(entity =>
            {
                entity.ToTable("meal_plans", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.description).IsUnicode(false);

                entity.Property(e => e.meal_plan_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<miscellaneous>(entity =>
            {
                entity.ToTable("miscellaneous", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");
            });

            modelBuilder.Entity<non_rental_units>(entity =>
            {
                entity.ToTable("non_rental_units", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.amount).HasColumnType("decimal(20,2)");

                entity.Property(e => e.description).IsUnicode(false);

                entity.Property(e => e.min_deposit).HasColumnType("decimal(20,2)");

                entity.Property(e => e.name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<notices>(entity =>
            {
                entity.ToTable("notices", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.notice_body).IsUnicode(false);

                entity.Property(e => e.notice_title)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<payment_methods>(entity =>
            {
                entity.ToTable("payment_methods", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<property_details>(entity =>
            {
                entity.ToTable("property_details", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.address1)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.address2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.beneficiary_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.city)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.country)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.fax)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.logo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.phone)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.property_grade)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.property_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.property_type)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.registration_number)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.res_phone)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.state)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.website)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<propertysetup>(entity =>
            {
                entity.ToTable("propertysetup", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");
            });

            modelBuilder.Entity<rate_types>(entity =>
            {
                entity.ToTable("rate_types", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.rate_type_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<rates>(entity =>
            {
                entity.ToTable("rates", "hotel_db");

                entity.HasIndex(e => e.rate_type_id)
                    .HasName("rate_key100");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.amount).HasColumnType("decimal(20,2)");

                entity.Property(e => e.extra_adult).HasColumnType("decimal(20,2)");

                entity.Property(e => e.extra_child).HasColumnType("decimal(20,2)");

                entity.Property(e => e.isactive).HasColumnType("tinyint(4)");

                entity.Property(e => e.isspecial).HasColumnType("tinyint(4)");

                entity.Property(e => e.isweekday).HasColumnType("tinyint(4)");

                entity.Property(e => e.rate_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.rate_type_id).HasColumnType("int(11)");

                entity.HasOne(d => d.rate_type_)
                    .WithMany(p => p.rates)
                    .HasForeignKey(d => d.rate_type_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rate_key100");
            });

            modelBuilder.Entity<remark_categories>(entity =>
            {
                entity.ToTable("remark_categories", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.category_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.sort_key).HasColumnType("int(11)");
            });

            modelBuilder.Entity<remarks>(entity =>
            {
                entity.ToTable("remarks", "hotel_db");

                entity.HasIndex(e => e.remark_category_id)
                    .HasName("remark_categories_key_200");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.active).HasColumnType("tinyint(4)");

                entity.Property(e => e.alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.reason).IsUnicode(false);

                entity.Property(e => e.remark_category_id).HasColumnType("int(11)");

                entity.Property(e => e.sort_key).HasColumnType("int(11)");

                entity.HasOne(d => d.remark_category_)
                    .WithMany(p => p.remarks)
                    .HasForeignKey(d => d.remark_category_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("remark_categories_key_200");
            });

            modelBuilder.Entity<reservation_log_entries>(entity =>
            {
                entity.ToTable("reservation_log_entries", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.action)
                    .HasMaxLength(750)
                    .IsUnicode(false);

                entity.Property(e => e.reservation_id).HasColumnType("int(11)");

                entity.Property(e => e.reserved_room_id).HasColumnType("int(11)");
            });

            modelBuilder.Entity<reservation_transaction>(entity =>
            {
                entity.ToTable("reservation_transaction", "hotel_db");

                entity.HasIndex(e => e.reservation_id)
                    .HasName("reservations__key_2333909");

                entity.HasIndex(e => e.reserved_room_id)
                    .HasName("reserved_rooms__key_2333909");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.balance).HasColumnType("decimal(20,2)");

                entity.Property(e => e.paid).HasColumnType("decimal(20,2)");

                entity.Property(e => e.payment_method)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.rate).HasColumnType("decimal(20,2)");

                entity.Property(e => e.rate_name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.rate_type)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.reservation_id).HasColumnType("int(11)");

                entity.Property(e => e.reserved_room_id).HasColumnType("int(11)");

                entity.Property(e => e.room_Type)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.room_name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.status)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.total).HasColumnType("decimal(20,2)");

                entity.Property(e => e.total_adult).HasColumnType("decimal(20,2)");

                entity.Property(e => e.total_children).HasColumnType("decimal(20,2)");

                entity.Property(e => e.total_reservation).HasColumnType("decimal(20,2)");

                entity.HasOne(d => d.reservation_)
                    .WithMany(p => p.reservation_transaction)
                    .HasForeignKey(d => d.reservation_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reservations__key_2333909");

                entity.HasOne(d => d.reserved_room_)
                    .WithMany(p => p.reservation_transaction)
                    .HasForeignKey(d => d.reserved_room_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reserved_rooms__key_2333909");
            });

            modelBuilder.Entity<reservations>(entity =>
            {
                entity.ToTable("reservations", "hotel_db");

                entity.HasIndex(e => e.account_id)
                    .HasName("accounts__key_233320");

                entity.HasIndex(e => e.business_source_id)
                    .HasName("business_source_id_key_50909");

                entity.HasIndex(e => e.discount_plan)
                    .HasName("discount_plan__key_2333909008");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.account_id).HasColumnType("int(11)");

                entity.Property(e => e.account_number)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.amount_paid).HasColumnType("decimal(18,2)");

                entity.Property(e => e.apply_discount)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.arrival_time)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.balance).HasColumnType("decimal(18,2)");

                entity.Property(e => e.bank_name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.book_by)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.branch_name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.business_source_id).HasColumnType("int(11)");

                entity.Property(e => e.cheque)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.code)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.departure_time)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.discount_code)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.discount_plan).HasColumnType("int(11)");

                entity.Property(e => e.discount_value).HasColumnType("decimal(20,2)");

                entity.Property(e => e.num_of_adult).HasColumnType("int(11)");

                entity.Property(e => e.num_of_children).HasColumnType("int(11)");

                entity.Property(e => e.num_of_night).HasColumnType("int(11)");

                entity.Property(e => e.reservation_number)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.reservation_status)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.total_booking).HasColumnType("decimal(18,2)");

                entity.HasOne(d => d.account_)
                    .WithMany(p => p.reservations)
                    .HasForeignKey(d => d.account_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("accounts__key_233320");

                entity.HasOne(d => d.business_source_)
                    .WithMany(p => p.reservations)
                    .HasForeignKey(d => d.business_source_id)
                    .HasConstraintName("business_source_id_key_50909");

                entity.HasOne(d => d.discount_planNavigation)
                    .WithMany(p => p.reservations)
                    .HasForeignKey(d => d.discount_plan)
                    .HasConstraintName("discount_plan__key_2333909008");
            });

            modelBuilder.Entity<reserved_rooms>(entity =>
            {
                entity.ToTable("reserved_rooms", "hotel_db");

                entity.HasIndex(e => e.reservation_id)
                    .HasName("reservations__key_233320");

                entity.HasIndex(e => e.room_id)
                    .HasName("roomss__key_233320");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.arrival_time)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.balance).HasColumnType("decimal(20,2)");

                entity.Property(e => e.departure_time)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.discount_plan_id).HasColumnType("int(11)");

                entity.Property(e => e.discount_value).HasColumnType("decimal(20,2)");

                entity.Property(e => e.new_account_id).HasColumnType("int(11)");

                entity.Property(e => e.num_of_adult).HasColumnType("int(11)");

                entity.Property(e => e.num_of_children).HasColumnType("int(11)");

                entity.Property(e => e.num_of_night).HasColumnType("int(11)");

                entity.Property(e => e.original_owner)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.paid).HasColumnType("decimal(20,2)");

                entity.Property(e => e.reservation_id).HasColumnType("int(11)");

                entity.Property(e => e.reserved_status)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.room_id).HasColumnType("int(11)");

                entity.Property(e => e.room_name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.room_type_id).HasColumnType("int(11)");

                entity.Property(e => e.room_type_name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.serial_number)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.status)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.total).HasColumnType("decimal(20,2)");

                entity.Property(e => e.transfer_owner)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.reservation_)
                    .WithMany(p => p.reserved_rooms)
                    .HasForeignKey(d => d.reservation_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reservations__key_233320");

                entity.HasOne(d => d.room_)
                    .WithMany(p => p.reserved_rooms)
                    .HasForeignKey(d => d.room_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("roomss__key_233320");
            });

            modelBuilder.Entity<revenue_breakdowns>(entity =>
            {
                entity.ToTable("revenue_breakdowns", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.breakdown_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.description).IsUnicode(false);

                entity.Property(e => e.sort_key).HasColumnType("int(11)");
            });

            modelBuilder.Entity<roles>(entity =>
            {
                entity.ToTable("roles", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.role_name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<room_images>(entity =>
            {
                entity.ToTable("room_images", "hotel_db");

                entity.HasIndex(e => e.room_id)
                    .HasName("room_key500");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.image_url)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.room_id).HasColumnType("int(11)");

                entity.HasOne(d => d.room_)
                    .WithMany(p => p.room_images)
                    .HasForeignKey(d => d.room_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("room_key500");
            });

            modelBuilder.Entity<room_owners>(entity =>
            {
                entity.ToTable("room_owners", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.address)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.amount).HasColumnType("decimal(20,2)");

                entity.Property(e => e.city)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.country)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.description).IsUnicode(false);

                entity.Property(e => e.email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.fax)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.first_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.last_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.phone)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.room_plan)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.state)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<room_status_colors>(entity =>
            {
                entity.ToTable("room_status_colors", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.color_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.status_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.status_type)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<room_types>(entity =>
            {
                entity.ToTable("room_types", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.back_color)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.description).IsUnicode(false);

                entity.Property(e => e.inactive).HasColumnType("tinyint(4)");

                entity.Property(e => e.max_adult).HasColumnType("int(11)");

                entity.Property(e => e.max_child).HasColumnType("int(11)");

                entity.Property(e => e.room_type_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.sort_key).HasColumnType("int(11)");
            });

            modelBuilder.Entity<room_types_rates>(entity =>
            {
                entity.HasKey(e => new { e.room_type_id, e.rate_id });

                entity.ToTable("room_types_rates", "hotel_db");

                entity.HasIndex(e => e.rate_id)
                    .HasName("rate_key5600");

                entity.Property(e => e.room_type_id).HasColumnType("int(11)");

                entity.Property(e => e.rate_id).HasColumnType("int(11)");

                entity.HasOne(d => d.rate_)
                    .WithMany(p => p.room_types_rates)
                    .HasForeignKey(d => d.rate_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rate_key5600");

                entity.HasOne(d => d.room_type_)
                    .WithMany(p => p.room_types_rates)
                    .HasForeignKey(d => d.room_type_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("room_types_key5600");
            });

            modelBuilder.Entity<rooms>(entity =>
            {
                entity.ToTable("rooms", "hotel_db");

                entity.HasIndex(e => e.floor_id)
                    .HasName("floor_key59000");

                entity.HasIndex(e => e.room_owner_id)
                    .HasName("room_owners_key500");

                entity.HasIndex(e => e.room_type_id)
                    .HasName("room_type_key400");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.data_extension)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.floor_id).HasColumnType("int(11)");

                entity.Property(e => e.inactive).HasColumnType("tinyint(4)");

                entity.Property(e => e.keycard_alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.phone_extension)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.power_code)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.remark).IsUnicode(false);

                entity.Property(e => e.room_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.room_owner_id).HasColumnType("int(11)");

                entity.Property(e => e.room_type_id).HasColumnType("int(11)");

                entity.Property(e => e.sort_key).HasColumnType("int(11)");

                entity.HasOne(d => d.floor_)
                    .WithMany(p => p.rooms)
                    .HasForeignKey(d => d.floor_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("floor_key59000");

                entity.HasOne(d => d.room_owner_)
                    .WithMany(p => p.rooms)
                    .HasForeignKey(d => d.room_owner_id)
                    .HasConstraintName("room_owners_key500");

                entity.HasOne(d => d.room_type_)
                    .WithMany(p => p.rooms)
                    .HasForeignKey(d => d.room_type_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("room_type_key400");
            });

            modelBuilder.Entity<rooms_amenities>(entity =>
            {
                entity.HasKey(e => new { e.room_id, e.amenity_id });

                entity.ToTable("rooms_amenities", "hotel_db");

                entity.HasIndex(e => e.amenity_id)
                    .HasName("amenities_key600");

                entity.Property(e => e.room_id).HasColumnType("int(11)");

                entity.Property(e => e.amenity_id).HasColumnType("int(11)");

                entity.HasOne(d => d.amenity_)
                    .WithMany(p => p.rooms_amenities)
                    .HasForeignKey(d => d.amenity_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("amenities_key600");

                entity.HasOne(d => d.room_)
                    .WithMany(p => p.rooms_amenities)
                    .HasForeignKey(d => d.room_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("room_key600");
            });

            modelBuilder.Entity<rooms_week_days>(entity =>
            {
                entity.HasKey(e => new { e.room_id, e.week_day_id });

                entity.ToTable("rooms_week_days", "hotel_db");

                entity.HasIndex(e => e.week_day_id)
                    .HasName("week_days_key6400");

                entity.Property(e => e.room_id).HasColumnType("int(11)");

                entity.Property(e => e.week_day_id).HasColumnType("int(11)");

                entity.HasOne(d => d.room_)
                    .WithMany(p => p.rooms_week_days)
                    .HasForeignKey(d => d.room_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("room2_key600");

                entity.HasOne(d => d.week_day_)
                    .WithMany(p => p.rooms_week_days)
                    .HasForeignKey(d => d.week_day_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("week_days_key6400");
            });

            modelBuilder.Entity<season_types>(entity =>
            {
                entity.ToTable("season_types", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.deacription).IsUnicode(false);

                entity.Property(e => e.season_type_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<seasons>(entity =>
            {
                entity.ToTable("seasons", "hotel_db");

                entity.HasIndex(e => e.season_type_id)
                    .HasName("season_types_key450");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.deacription).IsUnicode(false);

                entity.Property(e => e.from_day).HasColumnType("int(11)");

                entity.Property(e => e.from_month)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.season_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.season_type_id).HasColumnType("int(11)");

                entity.Property(e => e.to_day).HasColumnType("int(11)");

                entity.Property(e => e.to_month)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.season_type_)
                    .WithMany(p => p.seasons)
                    .HasForeignKey(d => d.season_type_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("season_types_key450");
            });

            modelBuilder.Entity<settlement_types>(entity =>
            {
                entity.ToTable("settlement_types", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.active).HasColumnType("tinyint(4)");

                entity.Property(e => e.alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.can_generate_receipt).HasColumnType("tinyint(4)");

                entity.Property(e => e.current_index).HasColumnType("bigint(20)");

                entity.Property(e => e.payment_option)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.prefix)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.settlement_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.start_index).HasColumnType("bigint(20)");

                entity.Property(e => e.suffix)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<settlements>(entity =>
            {
                entity.ToTable("settlements", "hotel_db");

                entity.HasIndex(e => e.settlement_type_id)
                    .HasName("settlement_type_id_object_3400");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.card_holder_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.card_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.prefix)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.settlement_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.settlement_type_id).HasColumnType("int(11)");

                entity.Property(e => e.suffix)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.settlement_type_)
                    .WithMany(p => p.settlements)
                    .HasForeignKey(d => d.settlement_type_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("settlement_type_id_object_3400");
            });

            modelBuilder.Entity<tax_setting_types>(entity =>
            {
                entity.ToTable("tax_setting_types", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.tax_setting_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<tax_settings>(entity =>
            {
                entity.ToTable("tax_settings", "hotel_db");

                entity.HasIndex(e => e.tax_setting_type_id)
                    .HasName("tax_settings_key100");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.amount).HasColumnType("decimal(20,2)");

                entity.Property(e => e.tax_setting_type_id).HasColumnType("int(11)");

                entity.HasOne(d => d.tax_setting_type_)
                    .WithMany(p => p.tax_settings)
                    .HasForeignKey(d => d.tax_setting_type_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tax_settings_key100");
            });

            modelBuilder.Entity<taxes>(entity =>
            {
                entity.ToTable("taxes", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.charge_on_extra_adult).HasColumnType("tinyint(4)");

                entity.Property(e => e.charge_on_extra_child).HasColumnType("tinyint(4)");

                entity.Property(e => e.duration).HasColumnType("int(11)");

                entity.Property(e => e.format)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.tax_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<templates>(entity =>
            {
                entity.ToTable("templates", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.default_template_body).IsUnicode(false);

                entity.Property(e => e.template_body).IsUnicode(false);

                entity.Property(e => e.template_code)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.template_title)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<transportaion_statitions>(entity =>
            {
                entity.ToTable("transportaion_statitions", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.name)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<transportation_types>(entity =>
            {
                entity.ToTable("transportation_types", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.name)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<transportations>(entity =>
            {
                entity.ToTable("transportations", "hotel_db");

                entity.HasIndex(e => e.transportation_type_id)
                    .HasName("transportation_type_id_key_50909");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.name)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.transportation_type_id).HasColumnType("int(11)");

                entity.HasOne(d => d.transportation_type_)
                    .WithMany(p => p.transportations)
                    .HasForeignKey(d => d.transportation_type_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("transportation_type_id_key_50909");
            });

            modelBuilder.Entity<users>(entity =>
            {
                entity.ToTable("users", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.active).HasColumnType("tinyint(4)");

                entity.Property(e => e.email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<users_roles>(entity =>
            {
                entity.HasKey(e => new { e.user_id, e.role_id });

                entity.ToTable("users_roles", "hotel_db");

                entity.HasIndex(e => e.role_id)
                    .HasName("role_key200");

                entity.Property(e => e.user_id).HasColumnType("int(11)");

                entity.Property(e => e.role_id).HasColumnType("int(11)");

                entity.HasOne(d => d.role_)
                    .WithMany(p => p.users_roles)
                    .HasForeignKey(d => d.role_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("role_key200");

                entity.HasOne(d => d.user_)
                    .WithMany(p => p.users_roles)
                    .HasForeignKey(d => d.user_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_key200");
            });

            modelBuilder.Entity<week_days>(entity =>
            {
                entity.ToTable("week_days", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.day_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.isweekday).HasColumnType("tinyint(4)");
            });

            modelBuilder.Entity<wings>(entity =>
            {
                entity.ToTable("wings", "hotel_db");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.wing_name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
