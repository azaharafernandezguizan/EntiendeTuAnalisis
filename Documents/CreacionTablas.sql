CREATE TABLE Valores_Analisis (     
ID int,     
Parametro varchar(255),     
Max_Mujer double,     
Min_Mujer double,  
Max_Varon double,     
Min_Varon double,
    PRIMARY KEY (ID) );

CREATE TABLE Patologia (     
	PatologiaID int,     
	Nombre varchar(255),     
    Descripcion varchar(2048),     
    Tratamiento varchar(2048),  
    Riesgos varchar(2048),    
    Recomendaciones varchar(2048) ,
    PRIMARY KEY (PatologiaID)     
    );


CREATE TABLE Relacion_Patologia_Analisis (
    RelacionID int NOT NULL,
    PatologiaID int NOT NULL,
    ParametroID int NOT NULL,
    IsMin bit,
    PRIMARY KEY (RelacionID),
    FOREIGN KEY (PatologiaID) REFERENCES Patologia(PatologiaID),
    FOREIGN KEY (ParametroID) REFERENCES Valores_Analisis(ID)
);