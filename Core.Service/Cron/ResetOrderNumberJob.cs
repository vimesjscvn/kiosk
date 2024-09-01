using System.Data;
using System.Threading.Tasks;
using Core.Config.Helpers;
using Core.Config.Settings;
using Core.Service.Interfaces;
using Core.UoW;
using CS.EF.Models;
using Dapper;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Core.Service.Cron
{
    public class ResetOrderNumberJob
    {
        private readonly BackgroundJobSettings _backgroundJobSettings;
        private readonly IConfiguration _configuration;
        private readonly IHospitalSystemService _hospitalSystemService;
        private readonly ILogger<ResetOrderNumberJob> _logger;

        /// <summary>
        ///     The hospital settings
        /// </summary>
        private readonly IPatientService _patientService;

        /// <summary>
        ///     The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        public ResetOrderNumberJob(IUnitOfWork unitOfWork,
            IPatientService patientService,
            IHospitalSystemService hospitalSystemService,
            BackgroundJobSettings backgroundJobSettings,
            ILogger<ResetOrderNumberJob> logger,
            IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _patientService = patientService;
            _hospitalSystemService = hospitalSystemService;
            _backgroundJobSettings = AppConfig.LoadBackgroundJob(backgroundJobSettings);
            _logger = logger;
            _configuration = configuration;
        }

        [AutomaticRetry(Attempts = 0)]
        public async Task Sync()
        {
            var sql = @"
            INSERT INTO ""IHM"".queue_number_backup SELECT * FROM ""IHM"".queue_number;

            TRUNCATE TABLE ""IHM"".queue_number;
            TRUNCATE TABLE ""IHM"".queue_number_temp;
            TRUNCATE TABLE ""IHM"".patient_temp;
            TRUNCATE TABLE ""IHM"".transaction_draft;
            TRUNCATE TABLE ""IHM"".transaction_draft_clinic;
            TRUNCATE TABLE ""IHM"".transaction_draft_prescription;
            TRUNCATE TABLE PUBLIC.audit_log;
            TRUNCATE TABLE PUBLIC.table_call_number_normal;
            TRUNCATE TABLE PUBLIC.table_call_number_priority;
            TRUNCATE TABLE PUBLIC.table_d_call_number_normal;
            TRUNCATE TABLE PUBLIC.table_d_call_number_priority;
            TRUNCATE TABLE PUBLIC.table_call_paid_number_normal;
            TRUNCATE TABLE PUBLIC.table_call_paid_number_priority;
            DROP TABLE PUBLIC.table_call_number_normal;
            DROP TABLE PUBLIC.table_call_number_priority;
            DROP TABLE PUBLIC.table_call_paid_number_normal;
            DROP TABLE PUBLIC.table_call_paid_number_priority;
            DROP TABLE PUBLIC.table_d_call_number_normal;
            DROP TABLE PUBLIC.table_d_call_number_priority;
            DROP TABLE PUBLIC.table_d_call_paid_number_normal;
            DROP TABLE PUBLIC.table_d_call_paid_number_priority;
            -- Table: public.table_d_call_number_priority
            -- DROP TABLE public.table_d_call_number_priority;
            CREATE TABLE PUBLIC.table_d_call_number_priority (
             seq bigserial NOT NULL,
             is_selected bool NOT NULL DEFAULT TRUE,
             ""table"" CHARACTER VARYING ( 50 ) COLLATE pg_catalog.""default"",
             created_date TIMESTAMP WITHOUT TIME ZONE DEFAULT now( ),
             ""created_by"" uuid,
             ip CHARACTER VARYING COLLATE pg_catalog.""default"",
             user_id uuid,
             area_code CHARACTER VARYING COLLATE pg_catalog.""default"",
             department_code CHARACTER VARYING COLLATE pg_catalog.""default"",
             CONSTRAINT table_d_call_number_priority_pk PRIMARY KEY ( seq ) 
            ) WITH ( OIDS = FALSE ) TABLESPACE pg_default;
            -- Table: public.table_d_call_number_normal
            -- DROP TABLE public.table_d_call_number_normal;
            CREATE TABLE PUBLIC.table_d_call_number_normal (
             seq bigserial NOT NULL,
             is_selected bool NOT NULL DEFAULT TRUE,
             ""table"" CHARACTER VARYING ( 50 ) COLLATE pg_catalog.""default"",
             created_date TIMESTAMP WITHOUT TIME ZONE DEFAULT now( ),
             ""created_by"" uuid,
             ip CHARACTER VARYING COLLATE pg_catalog.""default"",
             area_code CHARACTER VARYING ( 36 ) COLLATE pg_catalog.""default"",
             department_code CHARACTER VARYING COLLATE pg_catalog.""default"",
             CONSTRAINT table_d_call_number_normal_pk PRIMARY KEY ( seq ) 
            ) WITH ( OIDS = FALSE ) TABLESPACE pg_default;
            -- Table: public.table_call_paid_number_priority
            -- DROP TABLE public.table_call_paid_number_priority;
            CREATE TABLE PUBLIC.table_call_paid_number_priority (
             seq bigserial NOT NULL,
             is_selected bool NOT NULL DEFAULT TRUE,
             created_date TIMESTAMP WITHOUT TIME ZONE DEFAULT now( ),
             ""table"" CHARACTER VARYING ( 5 ) COLLATE pg_catalog.""default"",
             ""created_by"" uuid,
             ip CHARACTER VARYING COLLATE pg_catalog.""default"",
             area_code CHARACTER VARYING COLLATE pg_catalog.""default"",
             department_code CHARACTER VARYING COLLATE pg_catalog.""default"",
             CONSTRAINT table_call_paid_number_priority_pk PRIMARY KEY ( seq ) 
            ) WITH ( OIDS = FALSE ) TABLESPACE pg_default;
            -- Table: public.table_call_paid_number_normal
            -- DROP TABLE public.table_call_paid_number_normal;
            CREATE TABLE PUBLIC.table_call_paid_number_normal (
             seq bigserial NOT NULL,
             is_selected bool NOT NULL DEFAULT TRUE,
             created_date TIMESTAMP WITHOUT TIME ZONE DEFAULT now( ),
             ""table"" CHARACTER VARYING ( 5 ) COLLATE pg_catalog.""default"",
             ""created_by"" uuid,
             ip CHARACTER VARYING COLLATE pg_catalog.""default"",
             area_code CHARACTER VARYING COLLATE pg_catalog.""default"",
             department_code CHARACTER VARYING COLLATE pg_catalog.""default"",
             CONSTRAINT table_call_paid_number_normal_pk PRIMARY KEY ( seq ) 
            ) WITH ( OIDS = FALSE ) TABLESPACE pg_default;
            -- Table: public.table_call_number_priority
            -- DROP TABLE public.table_call_number_priority;
            CREATE TABLE PUBLIC.table_call_number_priority (
             seq bigserial NOT NULL,
             is_selected bool NOT NULL DEFAULT TRUE,
             ""table"" CHARACTER VARYING ( 50 ) COLLATE pg_catalog.""default"",
             created_date TIMESTAMP WITHOUT TIME ZONE DEFAULT now( ),
             ""created_by"" uuid,
             ip CHARACTER VARYING COLLATE pg_catalog.""default"",
             area_code CHARACTER VARYING COLLATE pg_catalog.""default"",
             department_code CHARACTER VARYING COLLATE pg_catalog.""default"",
             CONSTRAINT table_call_number_priority_pk PRIMARY KEY ( seq ) 
            ) WITH ( OIDS = FALSE ) TABLESPACE pg_default;
            -- Table: public.table_call_number_normal
            -- DROP TABLE public.table_call_number_normal;
            CREATE TABLE PUBLIC.table_call_number_normal (
             seq bigserial NOT NULL,
             is_selected bool NOT NULL DEFAULT TRUE,
             ""table"" CHARACTER VARYING ( 50 ) COLLATE pg_catalog.""default"",
             created_date TIMESTAMP WITHOUT TIME ZONE DEFAULT now( ),
             ""created_by"" uuid,
             ip CHARACTER VARYING COLLATE pg_catalog.""default"",
             area_code CHARACTER VARYING ( 36 ) COLLATE pg_catalog.""default"",
             department_code CHARACTER VARYING COLLATE pg_catalog.""default"",
             CONSTRAINT table_call_number_normal_pk PRIMARY KEY ( seq ) 
            ) WITH ( OIDS = FALSE ) TABLESPACE pg_default;
            -- Table: public.table_d_call_paid_number_priority
            -- DROP TABLE public.table_d_call_paid_number_priority;
            CREATE TABLE PUBLIC.table_d_call_paid_number_priority (
             seq bigserial NOT NULL,
             is_selected bool NOT NULL DEFAULT TRUE,
             created_date TIMESTAMP WITHOUT TIME ZONE DEFAULT now( ),
             ""table"" CHARACTER VARYING ( 5 ) COLLATE pg_catalog.""default"",
             ""created_by"" uuid,
             ip CHARACTER VARYING COLLATE pg_catalog.""default"",
             area_code CHARACTER VARYING COLLATE pg_catalog.""default"",
             department_code CHARACTER VARYING COLLATE pg_catalog.""default"",
             CONSTRAINT table_d_call_paid_number_priority_pk PRIMARY KEY ( seq ) 
            ) WITH ( OIDS = FALSE ) TABLESPACE pg_default;
            -- Table: public.table_d_call_paid_number_normal
            -- DROP TABLE public.table_d_call_paid_number_normal;
            CREATE TABLE PUBLIC.table_d_call_paid_number_normal (
             seq bigserial NOT NULL,
             is_selected bool NOT NULL DEFAULT TRUE,
             created_date TIMESTAMP WITHOUT TIME ZONE DEFAULT now( ),
             ""table"" CHARACTER VARYING ( 5 ) COLLATE pg_catalog.""default"",
             ""created_by"" uuid,
             ip CHARACTER VARYING COLLATE pg_catalog.""default"",
             area_code CHARACTER VARYING COLLATE pg_catalog.""default"",
             department_code CHARACTER VARYING COLLATE pg_catalog.""default"",
            CONSTRAINT table_d_call_paid_number_normal_pk PRIMARY KEY ( seq ) 
            ) WITH ( OIDS = FALSE ) TABLESPACE pg_default;
            ";

            var connectionString = _configuration.GetConnectionString(nameof(ApplicationDbContext));
            using (var conn = new NpgsqlConnection(connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    await conn.OpenAsync();

                var paramaters = new DynamicParameters();
                var result = await conn.ExecuteAsync(sql, paramaters, null, null, CommandType.Text);
            }
        }
    }
}