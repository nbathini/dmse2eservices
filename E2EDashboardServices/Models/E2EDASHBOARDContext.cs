using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace E2EDashboardServices.Models
{
    public partial class E2EDASHBOARDContext : DbContext
    {
        public E2EDASHBOARDContext()
        {
        }

        public E2EDASHBOARDContext(DbContextOptions<E2EDASHBOARDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asset> Assets { get; set; }
        public virtual DbSet<BatchClass> BatchClasses { get; set; }
        public virtual DbSet<Boxbatch> Boxbatches { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=uskanme2ed01.na.imtn.com; Initial Catalog=E2EDASHBOARD; user id=e2edashboard; password=e2edashboard");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Asset>(entity =>
            {
                entity.ToTable("ASSET");

                entity.HasIndex(e => e.AdtCrtDt, "ASSET_ADT_CRT_DT_IDX");

                entity.HasIndex(e => e.BoxNbr, "ASSET_IDX1");

                entity.HasIndex(e => e.DstrctId, "ASSET_IDX_DSTRCT_ID");

                entity.HasIndex(e => e.ParentBoxNbr, "ASSET_IDX_PARENTBOXNBR");

                entity.HasIndex(e => e.ProjectId, "ASSET_IDX_PROJECT");

                entity.HasIndex(e => e.Status, "ASSET_IDX_STATUS");

                entity.HasIndex(e => new { e.Status, e.CmpltdDt, e.BoxNbr }, "ASSET_INDX44");

                entity.HasIndex(e => e.CmpltdDt, "ASSET_INDX_CMPLTD_DT");

                entity.HasIndex(e => new { e.DstrctId, e.CustAcntNbr, e.BoxNbr, e.SkpOrdrNbr, e.Isdeleted }, "ASSET_UN")
                    .IsUnique();

                entity.Property(e => e.AssetId)
                    .HasColumnType("numeric(38, 0)")
                    .HasColumnName("ASSET_ID");

                entity.Property(e => e.AdtCrtDt)
                    .HasPrecision(3)
                    .HasColumnName("ADT_CRT_DT");

                entity.Property(e => e.AdtUpdtDt)
                    .HasPrecision(3)
                    .HasColumnName("ADT_UPDT_DT")
                    .HasDefaultValueSql("(switchoffset(sysdatetimeoffset(),(0)))");

                entity.Property(e => e.AsgnmntTs)
                    .HasPrecision(3)
                    .HasColumnName("ASGNMNT_TS");

                entity.Property(e => e.BoxNbr)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("BOX_NBR");

                entity.Property(e => e.CmpltdDt)
                    .HasPrecision(3)
                    .HasColumnName("CMPLTD_DT");

                entity.Property(e => e.CmpltdFlg)
                    .HasColumnType("numeric(38, 0)")
                    .HasColumnName("CMPLTD_FLG")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CustAcntNbr)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CUST_ACNT_NBR");

                entity.Property(e => e.DstrctId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DSTRCT_ID");

                entity.Property(e => e.ExpctdCmpltdDt)
                    .HasPrecision(3)
                    .HasColumnName("EXPCTD_CMPLTD_DT");

                entity.Property(e => e.Isdeleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETED")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("MODIFIED_BY");

                entity.Property(e => e.ParentBoxNbr)
                    .HasMaxLength(150)
                    .HasColumnName("PARENT_BOX_NBR");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("numeric(38, 0)")
                    .HasColumnName("PROJECT_ID");

                entity.Property(e => e.ReportId)
                    .HasMaxLength(150)
                    .HasColumnName("REPORT_ID");

                entity.Property(e => e.SkpOrdrNbr)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("SKP_ORDR_NBR");

                entity.Property(e => e.Status)
                    .HasColumnType("numeric(38, 0)")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Subbtchhdr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SUBBTCHHDR")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<BatchClass>(entity =>
            {
                entity.ToTable("BATCH_CLASS");

                entity.Property(e => e.BatchClassId)
                    .HasColumnType("numeric(38, 0)")
                    .HasColumnName("BATCH_CLASS_ID")
                    .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[BATCH_CLASS_BATCH_CLASS_ID_SEQ])");

                entity.Property(e => e.ActiveFlg)
                    .HasColumnType("numeric(38, 0)")
                    .HasColumnName("ACTIVE_FLG");

                entity.Property(e => e.BatchClassNm)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("BATCH_CLASS_NM");

                entity.Property(e => e.DatePublished)
                    .HasPrecision(3)
                    .HasColumnName("DATE_PUBLISHED");

                entity.Property(e => e.ExpirationDate)
                    .HasPrecision(3)
                    .HasColumnName("EXPIRATION_DATE");

                entity.Property(e => e.GsJobId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GS_JOB_ID");

                entity.Property(e => e.GsRunDate)
                    .HasPrecision(3)
                    .HasColumnName("GS_RUN_DATE");

                entity.Property(e => e.JobSpecificationLink)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("JOB_SPECIFICATION_LINK");

                entity.Property(e => e.LastRunDate)
                    .HasPrecision(3)
                    .HasColumnName("LAST_RUN_DATE");

                entity.Property(e => e.MultilineFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MULTILINE_FLAG");

                entity.Property(e => e.PrintsowFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PRINTSOW_FLAG");

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");

                entity.Property(e => e.Version)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VERSION");

                entity.Property(e => e.WorkflowLink)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("WORKFLOW_LINK");
            });

            modelBuilder.Entity<Boxbatch>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BOXBATCHES");

                entity.HasIndex(e => e.Batchname, "IDX_BOXBATCHES_BATCHNAME");

                entity.HasIndex(e => e.Batchreferenceid, "IDX_BOXBATCHES_BATCHREFID");

                entity.HasIndex(e => e.Boxno, "IDX_BOXBATCHES_BOXNO");

                entity.HasIndex(e => e.ParentBoxNbr, "IDX_BOXBATCHES_PARENTBOXNO");

                entity.HasIndex(e => e.Releasetime, "IDX_BOXBATCHES_RELTIME");

                entity.Property(e => e.Batchclass)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BATCHCLASS");

                entity.Property(e => e.Batchname)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("BATCHNAME");

                entity.Property(e => e.Batchreferenceid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BATCHREFERENCEID");

                entity.Property(e => e.Boxno)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BOXNO");

                entity.Property(e => e.Createddate)
                    .HasPrecision(3)
                    .HasColumnName("CREATEDDATE");

                entity.Property(e => e.Doccount).HasColumnName("DOCCOUNT");

                entity.Property(e => e.Imagecount).HasColumnName("IMAGECOUNT");

                entity.Property(e => e.Iskofax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISKOFAX")
                    .HasDefaultValueSql("('Y')")
                    .IsFixedLength(true);

                entity.Property(e => e.ParentBoxNbr)
                    .HasMaxLength(150)
                    .HasColumnName("PARENT_BOX_NBR");

                entity.Property(e => e.Releasestatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RELEASESTATUS")
                    .IsFixedLength(true);

                entity.Property(e => e.Releasetime)
                    .HasPrecision(3)
                    .HasColumnName("RELEASETIME");

                entity.Property(e => e.Scandate)
                    .HasPrecision(3)
                    .HasColumnName("SCANDATE");

                entity.Property(e => e.Sitename)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SITENAME");

                entity.Property(e => e.Updateddate)
                    .HasPrecision(3)
                    .HasColumnName("UPDATEDDATE");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CUSTOMER");

                entity.HasIndex(e => e.Custid, "CUSTOMER_PK")
                    .IsUnique();

                entity.Property(e => e.BuildingId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BUILDING_ID");

                entity.Property(e => e.Ctype)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CTYPE");

                entity.Property(e => e.Custid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CUSTID");

                entity.Property(e => e.Customername)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMERNAME");

                entity.Property(e => e.Districid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICID");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("LOCATION");

                entity.Property(e => e.LocationId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION_ID");

                entity.Property(e => e.BaseLaborRate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BASE_LABOR_RATE");

                entity.Property(e => e.BaseLaborRateFortemp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BASE_LABOR_RATE_FORTEMP");

                entity.Property(e => e.BaseRate)
                    .HasColumnType("numeric(8, 4)")
                    .HasColumnName("BASE_RATE");

                entity.Property(e => e.Clustr)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("clustr");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.KronosOrgId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("KRONOS_ORG_ID");

                entity.Property(e => e.LocationName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION_NAME");

                entity.Property(e => e.LocationType)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION_TYPE");

                entity.Property(e => e.P4pMaxrate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("P4P_MAXRATE");

                entity.Property(e => e.Region)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("region");

                entity.Property(e => e.SeqNo).HasColumnName("SEQ_NO");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("PROJECT");

                entity.HasIndex(e => e.OpprtntyId, "INDEX1");

                entity.HasIndex(e => e.BatchClassId, "PROJECT_BATCHCLASS");

                entity.HasIndex(e => new { e.OpprtntyId, e.ProjectNm }, "PROJECT_UK")
                    .IsUnique();

                entity.Property(e => e.ProjectId)
                    .HasColumnType("numeric(38, 0)")
                    .HasColumnName("PROJECT_ID");

                entity.Property(e => e.AdtCrtDt)
                    .HasPrecision(3)
                    .HasColumnName("ADT_CRT_DT")
                    .HasDefaultValueSql("(switchoffset(sysdatetimeoffset(),(0)))");

                entity.Property(e => e.AdtUpdtDt)
                    .HasPrecision(3)
                    .HasColumnName("ADT_UPDT_DT")
                    .HasDefaultValueSql("(switchoffset(sysdatetimeoffset(),(0)))");

                entity.Property(e => e.BatchClassId)
                    .HasColumnType("numeric(38, 0)")
                    .HasColumnName("BATCH_CLASS_ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.IsSca)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IS_SCA")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("MODIFIED_BY");

                entity.Property(e => e.OpprtntyId)
                    .HasColumnType("numeric(38, 0)")
                    .HasColumnName("OPPRTNTY_ID");

                entity.Property(e => e.ProjectNm)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PROJECT_NM");

                entity.Property(e => e.ProjectVisibilityFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PROJECT_VISIBILITY_FLAG");

                entity.HasOne(d => d.BatchClass)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.BatchClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PROJECT_BATCH_CLASS_FK");
            });

            modelBuilder.HasSequence("ACTIVITYIDSEQ").StartsAt(2210);

            modelBuilder.HasSequence("ASSET_ASSET_ID_SEQ")
                .StartsAt(18164258)
                .HasMin(1);

            modelBuilder.HasSequence("AUDITAPPERRLOGSEQ")
                .StartsAt(41)
                .HasMin(1);

            modelBuilder.HasSequence("AUTOMATEDFILESEQ").HasMin(1);

            modelBuilder.HasSequence("BATCH_CLASS_BATCH_CLASS_ID_SEQ").StartsAt(3748);

            modelBuilder.HasSequence("BATCH_CLASSV1_BATCH_CLASS_ID").HasMin(1);

            modelBuilder.HasSequence("BATCH_NUMBER")
                .StartsAt(196291)
                .HasMin(1);

            modelBuilder.HasSequence("BEELINEFILESEQ")
                .StartsAt(2201)
                .HasMin(1);

            modelBuilder.HasSequence("BEELINELOCATIONSEQ")
                .StartsAt(451)
                .HasMin(1);

            modelBuilder.HasSequence("BEELINESUPPLIERFILESEQ")
                .StartsAt(2531)
                .HasMin(1);

            modelBuilder.HasSequence("BLUEWATERFILESEQ")
                .StartsAt(2621)
                .HasMin(1);

            modelBuilder.HasSequence("COMPUTER_ASSET_ID_SEQ").HasMin(1);

            modelBuilder.HasSequence("DELIVERYIDSEQ")
                .StartsAt(2040223)
                .HasMin(1);

            modelBuilder.HasSequence("DEPT_SEQ").StartsAt(221);

            modelBuilder.HasSequence("District_UserSEQ")
                .StartsAt(79289)
                .HasMin(1);

            modelBuilder.HasSequence("DISTUSERSTATUSSEQ")
                .StartsAt(241)
                .HasMin(1);

            modelBuilder.HasSequence("DOCIDSEQ")
                .StartsAt(40893623)
                .HasMin(1);

            modelBuilder.HasSequence("E2EXLCONFIGSEQ").HasMin(1);

            modelBuilder.HasSequence<int>("EMPLOYER_SEQ").StartsAt(36605);

            modelBuilder.HasSequence("ERRORCODES_SEQUENCE")
                .StartsAt(41)
                .HasMin(1);

            modelBuilder.HasSequence("EVENT_EVENT_ID_SEQ")
                .StartsAt(939410)
                .HasMin(1);

            modelBuilder.HasSequence("HIBERNATE_SEQUENCE");

            modelBuilder.HasSequence("INBOUNDIDSEQ")
                .StartsAt(4242009)
                .HasMin(1);

            modelBuilder.HasSequence("JOB_INFO_ID_SEQ")
                .StartsAt(2536)
                .HasMin(1);

            modelBuilder.HasSequence("KD_DUPES_SEQ")
                .StartsAt(2735047)
                .HasMin(1);

            modelBuilder.HasSequence("KRONOS_THREASHOLD_USER_SEQ")
                .StartsAt(19784)
                .HasMin(1);

            modelBuilder.HasSequence("KRONOSFILESEQ")
                .StartsAt(31523)
                .HasMin(1);

            modelBuilder.HasSequence("MANUAL_DIMENTION_SEQ")
                .StartsAt(4967647)
                .HasMin(1);

            modelBuilder.HasSequence("operational_forecast_seq").HasMin(1);

            modelBuilder.HasSequence("OPERATORLOGFILESEQ")
                .StartsAt(882)
                .HasMin(1);

            modelBuilder.HasSequence("OPPRTNTY_ID_SEQ").StartsAt(4843);

            modelBuilder.HasSequence("OPPRTNTY_OPPRTNTY_ID_SEQ")
                .StartsAt(4843)
                .HasMin(1);

            modelBuilder.HasSequence("P4P_ADMINPERCENTAGE_SEQ")
                .StartsAt(41)
                .HasMin(1);

            modelBuilder.HasSequence("P4P_PAYOUT_RUN_ID")
                .StartsAt(1381)
                .HasMin(1);

            modelBuilder.HasSequence("P4P_PAYPERIOD_PERIODID")
                .StartsAt(41)
                .HasMin(1);

            modelBuilder.HasSequence("P4P_TRENDS_JOBID_SEQ")
                .StartsAt(3221)
                .HasMin(1);

            modelBuilder.HasSequence("P4PJOBRUNLOG_JOBID")
                .StartsAt(14813)
                .HasMin(1);

            modelBuilder.HasSequence("P4PPAYPERIODAUDITLOGSEQ")
                .StartsAt(141)
                .HasMin(1);

            modelBuilder.HasSequence("PAMODEL_SEQ")
                .StartsAt(27421)
                .HasMin(1);

            modelBuilder.HasSequence("PROCESS_PROCESS_ID_SEQ").HasMin(1);

            modelBuilder.HasSequence("PROJECT_PROJECT_ID_SEQ")
                .StartsAt(5743)
                .HasMin(1);

            modelBuilder.HasSequence("QA_BATCH_DETAILS_SEQ")
                .StartsAt(99861)
                .HasMin(1);

            modelBuilder.HasSequence("QA_BATCH_SEQ")
                .StartsAt(11101)
                .HasMin(1);

            modelBuilder.HasSequence("QC_BATCHDETAILID_SEQ").HasMin(1);

            modelBuilder.HasSequence("QC_BATCHID_SEQ")
                .StartsAt(41)
                .HasMin(1);

            modelBuilder.HasSequence("QC_ERRORID_SEQ")
                .StartsAt(20921)
                .HasMin(1);

            modelBuilder.HasSequence("QC_OPERATORID_SEQ").HasMin(1);

            modelBuilder.HasSequence("QC_STAGEID_SEQ").HasMin(1);

            modelBuilder.HasSequence("QUALITYERRORDESCRIPTION_SEQ")
                .StartsAt(36880)
                .HasMin(1);

            modelBuilder.HasSequence("REGIONAL_ID_MASTER_SEQ")
                .StartsAt(41)
                .HasMin(1);

            modelBuilder.HasSequence("REGIONAL_STG_LANG_SEQ")
                .StartsAt(81)
                .HasMin(1);

            modelBuilder.HasSequence("RELEASEIDSEQ")
                .StartsAt(3320942)
                .HasMin(1);

            modelBuilder.HasSequence("Sequence-20200729-114740").StartsAt(4949);

            modelBuilder.HasSequence("SITE_SEQ").StartsAt(2020);

            modelBuilder.HasSequence("SOW_SEQ")
                .StartsAt(381)
                .HasMin(1);

            modelBuilder.HasSequence("STATUS_JOBID")
                .StartsAt(263510)
                .HasMin(1);

            modelBuilder.HasSequence("STEP_STEP_ID_SEQ").HasMin(1);

            modelBuilder.HasSequence("SWIDISHCLOCKFILESEQ")
                .StartsAt(241)
                .HasMin(1);

            modelBuilder.HasSequence("TASK_INFO_SEQ")
                .StartsAt(6440)
                .HasMin(1);

            modelBuilder.HasSequence("TRANSFERIDSEQ")
                .StartsAt(2952542)
                .HasMin(1);

            modelBuilder.HasSequence("UATTENDFILESEQ")
                .StartsAt(5466)
                .HasMin(1);

            modelBuilder.HasSequence("UDFCONFIGSEQ").HasMin(1);

            modelBuilder.HasSequence("UDFDETAILSSEQ")
                .StartsAt(56041)
                .HasMin(1);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
