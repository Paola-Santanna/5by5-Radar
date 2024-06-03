CREATE TABLE RADARES
(
	id_radar INT IDENTITY(1,1) NOT NULL,
	concessionaria VARCHAR(200) NOT NULL,
	ano_do_pnv_snv INT NOT NULL,
	tipo_de_radar VARCHAR(50) NOT NULL,
	rodovia VARCHAR(10) NOT NULL,
	uf CHAR(2) NOT NULL,
	km_m VARCHAR(15) NOT NULL,
	municipio VARCHAR(50) NOT NULL,
	tipo_pista VARCHAR(20) NOT NULL,
	sentido VARCHAR(20) NOT NULL,
	situacao VARCHAR(15) NOT NULL,
	data_da_inativacao DATE,
	latitude VARCHAR(15) NOT NULL,
	longitude VARCHAR(15) NOT NULL,
	velocidade_leve INT NOT NULL
);