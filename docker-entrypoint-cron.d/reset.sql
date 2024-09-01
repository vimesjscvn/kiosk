INSERT INTO "IHM".queue_number_backup SELECT * FROM "IHM".queue_number;

TRUNCATE TABLE "IHM".queue_number;
TRUNCATE TABLE "IHM".queue_number_temp;
TRUNCATE TABLE "IHM".patient_temp;
TRUNCATE TABLE "IHM".transaction_draft;
TRUNCATE TABLE "IHM".transaction_draft_clinic;
TRUNCATE TABLE "IHM".transaction_draft_prescription;

TRUNCATE TABLE PUBLIC.table_name;
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
	"table" CHARACTER VARYING ( 50 ) COLLATE pg_catalog."default",
	created_date TIMESTAMP WITHOUT TIME ZONE DEFAULT now( ),
	"created_by" uuid,
	ip CHARACTER VARYING COLLATE pg_catalog."default",
	user_id uuid,
	area_code CHARACTER VARYING COLLATE pg_catalog."default",
	department_code CHARACTER VARYING COLLATE pg_catalog."default",
	CONSTRAINT table_d_call_number_priority_pk PRIMARY KEY ( seq ) 
) WITH ( OIDS = FALSE ) TABLESPACE pg_default;
-- Table: public.table_d_call_number_normal
-- DROP TABLE public.table_d_call_number_normal;
CREATE TABLE PUBLIC.table_d_call_number_normal (
	seq bigserial NOT NULL,
	is_selected bool NOT NULL DEFAULT TRUE,
	"table" CHARACTER VARYING ( 50 ) COLLATE pg_catalog."default",
	created_date TIMESTAMP WITHOUT TIME ZONE DEFAULT now( ),
	"created_by" uuid,
	ip CHARACTER VARYING COLLATE pg_catalog."default",
	area_code CHARACTER VARYING ( 36 ) COLLATE pg_catalog."default",
	department_code CHARACTER VARYING COLLATE pg_catalog."default",
	CONSTRAINT table_d_call_number_normal_pk PRIMARY KEY ( seq ) 
) WITH ( OIDS = FALSE ) TABLESPACE pg_default;
-- Table: public.table_call_paid_number_priority
-- DROP TABLE public.table_call_paid_number_priority;
CREATE TABLE PUBLIC.table_call_paid_number_priority (
	seq bigserial NOT NULL,
	is_selected bool NOT NULL DEFAULT TRUE,
	created_date TIMESTAMP WITHOUT TIME ZONE DEFAULT now( ),
	"table" CHARACTER VARYING ( 5 ) COLLATE pg_catalog."default",
	"created_by" uuid,
	ip CHARACTER VARYING COLLATE pg_catalog."default",
	area_code CHARACTER VARYING COLLATE pg_catalog."default",
	department_code CHARACTER VARYING COLLATE pg_catalog."default",
	CONSTRAINT table_call_paid_number_priority_pk PRIMARY KEY ( seq ) 
) WITH ( OIDS = FALSE ) TABLESPACE pg_default;
-- Table: public.table_call_paid_number_normal
-- DROP TABLE public.table_call_paid_number_normal;
CREATE TABLE PUBLIC.table_call_paid_number_normal (
	seq bigserial NOT NULL,
	is_selected bool NOT NULL DEFAULT TRUE,
	created_date TIMESTAMP WITHOUT TIME ZONE DEFAULT now( ),
	"table" CHARACTER VARYING ( 5 ) COLLATE pg_catalog."default",
	"created_by" uuid,
	ip CHARACTER VARYING COLLATE pg_catalog."default",
	area_code CHARACTER VARYING COLLATE pg_catalog."default",
	department_code CHARACTER VARYING COLLATE pg_catalog."default",
	CONSTRAINT table_call_paid_number_normal_pk PRIMARY KEY ( seq ) 
) WITH ( OIDS = FALSE ) TABLESPACE pg_default;
-- Table: public.table_call_number_priority
-- DROP TABLE public.table_call_number_priority;
CREATE TABLE PUBLIC.table_call_number_priority (
	seq bigserial NOT NULL,
	is_selected bool NOT NULL DEFAULT TRUE,
	"table" CHARACTER VARYING ( 50 ) COLLATE pg_catalog."default",
	created_date TIMESTAMP WITHOUT TIME ZONE DEFAULT now( ),
	"created_by" uuid,
	ip CHARACTER VARYING COLLATE pg_catalog."default",
	area_code CHARACTER VARYING COLLATE pg_catalog."default",
	department_code CHARACTER VARYING COLLATE pg_catalog."default",
	CONSTRAINT table_call_number_priority_pk PRIMARY KEY ( seq ) 
) WITH ( OIDS = FALSE ) TABLESPACE pg_default;
-- Table: public.table_call_number_normal
-- DROP TABLE public.table_call_number_normal;
CREATE TABLE PUBLIC.table_call_number_normal (
	seq bigserial NOT NULL,
	is_selected bool NOT NULL DEFAULT TRUE,
	"table" CHARACTER VARYING ( 50 ) COLLATE pg_catalog."default",
	created_date TIMESTAMP WITHOUT TIME ZONE DEFAULT now( ),
	"created_by" uuid,
	ip CHARACTER VARYING COLLATE pg_catalog."default",
	area_code CHARACTER VARYING ( 36 ) COLLATE pg_catalog."default",
	department_code CHARACTER VARYING COLLATE pg_catalog."default",
	CONSTRAINT table_call_number_normal_pk PRIMARY KEY ( seq ) 
) WITH ( OIDS = FALSE ) TABLESPACE pg_default;
-- Table: public.table_d_call_paid_number_priority
-- DROP TABLE public.table_d_call_paid_number_priority;
CREATE TABLE PUBLIC.table_d_call_paid_number_priority (
	seq bigserial NOT NULL,
	is_selected bool NOT NULL DEFAULT TRUE,
	created_date TIMESTAMP WITHOUT TIME ZONE DEFAULT now( ),
	"table" CHARACTER VARYING ( 5 ) COLLATE pg_catalog."default",
	"created_by" uuid,
	ip CHARACTER VARYING COLLATE pg_catalog."default",
	area_code CHARACTER VARYING COLLATE pg_catalog."default",
	department_code CHARACTER VARYING COLLATE pg_catalog."default",
	CONSTRAINT table_d_call_paid_number_priority_pk PRIMARY KEY ( seq ) 
) WITH ( OIDS = FALSE ) TABLESPACE pg_default;
-- Table: public.table_d_call_paid_number_normal
-- DROP TABLE public.table_d_call_paid_number_normal;
CREATE TABLE PUBLIC.table_d_call_paid_number_normal (
	seq bigserial NOT NULL,
	is_selected bool NOT NULL DEFAULT TRUE,
	created_date TIMESTAMP WITHOUT TIME ZONE DEFAULT now( ),
	"table" CHARACTER VARYING ( 5 ) COLLATE pg_catalog."default",
	"created_by" uuid,
	ip CHARACTER VARYING COLLATE pg_catalog."default",
	area_code CHARACTER VARYING COLLATE pg_catalog."default",
	department_code CHARACTER VARYING COLLATE pg_catalog."default",
CONSTRAINT table_d_call_paid_number_normal_pk PRIMARY KEY ( seq ) 
) WITH ( OIDS = FALSE ) TABLESPACE pg_default;