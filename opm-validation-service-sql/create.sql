-- Table: tbl_duplicate_opms
-- DROP TABLE tbl_duplicate_opms;
CREATE TABLE tbl_duplicate_opms
(
	id integer NOT NULL IDENTITY(1,1), -- DEFAULT nextval('tbl_duplicate_opms_new_data_id_seq'::regclass),
	tdo_cp_id numeric(18,0) NOT NULL,
	tdo_ean character varying(50),
	tdo_is_opm_duplicate bit NOT NULL,
	CONSTRAINT pk_tbl_duplicate_opms PRIMARY KEY (id)
)

--WITH (
--OIDS=FALSE
--);
--ALTER TABLE tbl_duplicate_opms
--OWNER TO admin;
--GRANT ALL ON TABLE tbl_duplicate_opms TO admin;


