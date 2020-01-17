
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/27/2019 11:43:29
-- Generated from EDMX file: C:\Users\brayan obando\Source\Repos\NiscoutFBL\NiscoutFBL2019\Models\ModeloNiscoutFBL.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BDNiscout];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PeriodoResponsable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personas_Responsable] DROP CONSTRAINT [FK_PeriodoResponsable];
GO
IF OBJECT_ID(N'[dbo].[FK_ResponsableGrupo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Grupos] DROP CONSTRAINT [FK_ResponsableGrupo];
GO
IF OBJECT_ID(N'[dbo].[FK_DepartamentoPersona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personas] DROP CONSTRAINT [FK_DepartamentoPersona];
GO
IF OBJECT_ID(N'[dbo].[FK_DepartamentoMunicipio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Municipios] DROP CONSTRAINT [FK_DepartamentoMunicipio];
GO
IF OBJECT_ID(N'[dbo].[FK_MunicipioSector]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sectores] DROP CONSTRAINT [FK_MunicipioSector];
GO
IF OBJECT_ID(N'[dbo].[FK_DistritoSector]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sectores] DROP CONSTRAINT [FK_DistritoSector];
GO
IF OBJECT_ID(N'[dbo].[FK_CargoPersonal_Admon]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personas_Personal_Admon] DROP CONSTRAINT [FK_CargoPersonal_Admon];
GO
IF OBJECT_ID(N'[dbo].[FK_AsistenteSubGrupo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubGrupos] DROP CONSTRAINT [FK_AsistenteSubGrupo];
GO
IF OBJECT_ID(N'[dbo].[FK_SubGrupoMembresia_Juvenil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Membresia_JuvenilSet] DROP CONSTRAINT [FK_SubGrupoMembresia_Juvenil];
GO
IF OBJECT_ID(N'[dbo].[FK_Tipo_GrupoSubGrupo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubGrupos] DROP CONSTRAINT [FK_Tipo_GrupoSubGrupo];
GO
IF OBJECT_ID(N'[dbo].[FK_GrupoSubGrupo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubGrupos] DROP CONSTRAINT [FK_GrupoSubGrupo];
GO
IF OBJECT_ID(N'[dbo].[FK_SubGrupoEvento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Eventos] DROP CONSTRAINT [FK_SubGrupoEvento];
GO
IF OBJECT_ID(N'[dbo].[FK_Centro_EstudioJuvenil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personas_Juvenil] DROP CONSTRAINT [FK_Centro_EstudioJuvenil];
GO
IF OBJECT_ID(N'[dbo].[FK_DistritoGrupo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Grupos] DROP CONSTRAINT [FK_DistritoGrupo];
GO
IF OBJECT_ID(N'[dbo].[FK_PatrocinadorDetalle_Evento_Patro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Detalle_Evento_Patros] DROP CONSTRAINT [FK_PatrocinadorDetalle_Evento_Patro];
GO
IF OBJECT_ID(N'[dbo].[FK_EventoDetalle_Evento_Patro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Detalle_Evento_Patros] DROP CONSTRAINT [FK_EventoDetalle_Evento_Patro];
GO
IF OBJECT_ID(N'[dbo].[FK_PatrocinadorDetalle_Grupo_Patro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Detalle_Grupo_Patros] DROP CONSTRAINT [FK_PatrocinadorDetalle_Grupo_Patro];
GO
IF OBJECT_ID(N'[dbo].[FK_GrupoDetalle_Grupo_Patro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Detalle_Grupo_Patros] DROP CONSTRAINT [FK_GrupoDetalle_Grupo_Patro];
GO
IF OBJECT_ID(N'[dbo].[FK_Local_EventoDetalle_Evento_Patro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Detalle_Evento_Patros] DROP CONSTRAINT [FK_Local_EventoDetalle_Evento_Patro];
GO
IF OBJECT_ID(N'[dbo].[FK_Asistente_EventoDetalle_Evento_Patro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Detalle_Evento_Patros] DROP CONSTRAINT [FK_Asistente_EventoDetalle_Evento_Patro];
GO
IF OBJECT_ID(N'[dbo].[FK_Etapa_AprobacionMembresia_Juvenil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Membresia_JuvenilSet] DROP CONSTRAINT [FK_Etapa_AprobacionMembresia_Juvenil];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonaTutoria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tutorias] DROP CONSTRAINT [FK_PersonaTutoria];
GO
IF OBJECT_ID(N'[dbo].[FK_TutoriaJuvenil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personas_Juvenil] DROP CONSTRAINT [FK_TutoriaJuvenil];
GO
IF OBJECT_ID(N'[dbo].[FK_JuvenilMembresia_Juvenil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Membresia_JuvenilSet] DROP CONSTRAINT [FK_JuvenilMembresia_Juvenil];
GO
IF OBJECT_ID(N'[dbo].[FK_Etapa_AprobacionMembresia_Adulto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Membresia_Adultos] DROP CONSTRAINT [FK_Etapa_AprobacionMembresia_Adulto];
GO
IF OBJECT_ID(N'[dbo].[FK_AdultoMembresia_Adulto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Membresia_Adultos] DROP CONSTRAINT [FK_AdultoMembresia_Adulto];
GO
IF OBJECT_ID(N'[dbo].[FK_Membresia_JuvenilProgresion_Juvenil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Progresion_Juveniles] DROP CONSTRAINT [FK_Membresia_JuvenilProgresion_Juvenil];
GO
IF OBJECT_ID(N'[dbo].[FK_Responsable_inherits_Persona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personas_Responsable] DROP CONSTRAINT [FK_Responsable_inherits_Persona];
GO
IF OBJECT_ID(N'[dbo].[FK_Personal_Admon_inherits_Persona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personas_Personal_Admon] DROP CONSTRAINT [FK_Personal_Admon_inherits_Persona];
GO
IF OBJECT_ID(N'[dbo].[FK_Asistente_inherits_Persona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personas_Asistente] DROP CONSTRAINT [FK_Asistente_inherits_Persona];
GO
IF OBJECT_ID(N'[dbo].[FK_Juvenil_inherits_Persona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personas_Juvenil] DROP CONSTRAINT [FK_Juvenil_inherits_Persona];
GO
IF OBJECT_ID(N'[dbo].[FK_Patrocinador_inherits_Persona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personas_Patrocinador] DROP CONSTRAINT [FK_Patrocinador_inherits_Persona];
GO
IF OBJECT_ID(N'[dbo].[FK_Adulto_inherits_Persona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personas_Adulto] DROP CONSTRAINT [FK_Adulto_inherits_Persona];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Periodos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Periodos];
GO
IF OBJECT_ID(N'[dbo].[Departamentos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departamentos];
GO
IF OBJECT_ID(N'[dbo].[Municipios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Municipios];
GO
IF OBJECT_ID(N'[dbo].[Sectores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sectores];
GO
IF OBJECT_ID(N'[dbo].[Distritos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Distritos];
GO
IF OBJECT_ID(N'[dbo].[Eventos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Eventos];
GO
IF OBJECT_ID(N'[dbo].[Membresia_Adultos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Membresia_Adultos];
GO
IF OBJECT_ID(N'[dbo].[Personas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personas];
GO
IF OBJECT_ID(N'[dbo].[SubGrupos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubGrupos];
GO
IF OBJECT_ID(N'[dbo].[Grupos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Grupos];
GO
IF OBJECT_ID(N'[dbo].[Etapa_Aprobaciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Etapa_Aprobaciones];
GO
IF OBJECT_ID(N'[dbo].[Cargos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cargos];
GO
IF OBJECT_ID(N'[dbo].[Centro_Estudios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Centro_Estudios];
GO
IF OBJECT_ID(N'[dbo].[Tipo_Grupos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tipo_Grupos];
GO
IF OBJECT_ID(N'[dbo].[Progresion_Juveniles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Progresion_Juveniles];
GO
IF OBJECT_ID(N'[dbo].[Detalle_Evento_Patros]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Detalle_Evento_Patros];
GO
IF OBJECT_ID(N'[dbo].[Detalle_Grupo_Patros]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Detalle_Grupo_Patros];
GO
IF OBJECT_ID(N'[dbo].[Local_Eventos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Local_Eventos];
GO
IF OBJECT_ID(N'[dbo].[Asistente_Eventos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Asistente_Eventos];
GO
IF OBJECT_ID(N'[dbo].[Tutorias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tutorias];
GO
IF OBJECT_ID(N'[dbo].[Membresia_JuvenilSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Membresia_JuvenilSet];
GO
IF OBJECT_ID(N'[dbo].[Personas_Responsable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personas_Responsable];
GO
IF OBJECT_ID(N'[dbo].[Personas_Personal_Admon]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personas_Personal_Admon];
GO
IF OBJECT_ID(N'[dbo].[Personas_Asistente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personas_Asistente];
GO
IF OBJECT_ID(N'[dbo].[Personas_Juvenil]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personas_Juvenil];
GO
IF OBJECT_ID(N'[dbo].[Personas_Patrocinador]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personas_Patrocinador];
GO
IF OBJECT_ID(N'[dbo].[Personas_Adulto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personas_Adulto];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Periodos'
CREATE TABLE [dbo].[Periodos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Desde] datetime  NOT NULL,
    [Hasta] datetime  NOT NULL
);
GO

-- Creating table 'Departamentos'
CREATE TABLE [dbo].[Departamentos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Departamento] nvarchar(max)  NOT NULL,
    [Nombre_Departamento] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Municipios'
CREATE TABLE [dbo].[Municipios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Municipio] nvarchar(max)  NOT NULL,
    [Nombre_Municipio] nvarchar(max)  NOT NULL,
    [DepartamentoId] int  NOT NULL
);
GO

-- Creating table 'Sectores'
CREATE TABLE [dbo].[Sectores] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Sector] nvarchar(max)  NOT NULL,
    [Nombre_Sector] nvarchar(max)  NOT NULL,
    [MunicipioId] int  NOT NULL,
    [DistritoId] int  NOT NULL
);
GO

-- Creating table 'Distritos'
CREATE TABLE [dbo].[Distritos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Distrito] nvarchar(max)  NOT NULL,
    [Nombre_Distrito] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Eventos'
CREATE TABLE [dbo].[Eventos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Evento] nvarchar(max)  NOT NULL,
    [Nombre_Evento] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Hora] time  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [SubGrupoId] int  NOT NULL
);
GO

-- Creating table 'Membresia_Adultos'
CREATE TABLE [dbo].[Membresia_Adultos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Carta_Compromiso] varbinary(max)  NOT NULL,
    [Carta_Intencion] varbinary(max)  NOT NULL,
    [Record_Policia] varbinary(max)  NOT NULL,
    [Carta_Ref_Personal] varbinary(max)  NOT NULL,
    [Certifi_Salvo_Peligro] varbinary(max)  NOT NULL,
    [Annio] nvarchar(max)  NOT NULL,
    [Etapa_AprobacionId] int  NOT NULL,
    [AdultoId] int  NOT NULL
);
GO

-- Creating table 'Personas'
CREATE TABLE [dbo].[Personas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Persona] nvarchar(max)  NOT NULL,
    [Nombres] nvarchar(max)  NOT NULL,
    [Apellidos] nvarchar(max)  NOT NULL,
    [Fecha_Nac] datetime  NOT NULL,
    [E_Mail] nvarchar(max)  NULL,
    [Cedula] nvarchar(max)  NULL,
    [Sexo] nvarchar(max)  NOT NULL,
    [Estado_Civil] nvarchar(max)  NULL,
    [Num_Pasaporte] nvarchar(max)  NULL,
    [Telefono] int  NOT NULL,
    [Direccion] nvarchar(max)  NOT NULL,
    [DepartamentoId] int  NOT NULL
);
GO

-- Creating table 'SubGrupos'
CREATE TABLE [dbo].[SubGrupos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Subgrupo] nvarchar(max)  NOT NULL,
    [Nombre_Subgrupo] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [AsistenteId] int  NOT NULL,
    [Tipo_GrupoId] int  NOT NULL,
    [GrupoId] int  NOT NULL
);
GO

-- Creating table 'Grupos'
CREATE TABLE [dbo].[Grupos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Grupo] nvarchar(max)  NOT NULL,
    [Nombre_Grupo] nvarchar(max)  NOT NULL,
    [Num_Solicitud] int  NOT NULL,
    [Pañoleta] varbinary(max)  NOT NULL,
    [Insignia] varbinary(max)  NOT NULL,
    [Sello_Grupo] varbinary(max)  NOT NULL,
    [ResponsableId] int  NOT NULL,
    [DistritoId] int  NOT NULL,
    [Carta_Solicitud] varbinary(max)  NOT NULL
);
GO

-- Creating table 'Etapa_Aprobaciones'
CREATE TABLE [dbo].[Etapa_Aprobaciones] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Etapa] nvarchar(max)  NOT NULL,
    [Estado] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Cargos'
CREATE TABLE [dbo].[Cargos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Cargo] nvarchar(max)  NOT NULL,
    [Nombre_Cargo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Centro_Estudios'
CREATE TABLE [dbo].[Centro_Estudios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Centro] nvarchar(max)  NOT NULL,
    [Nombre_Centro] nvarchar(max)  NOT NULL,
    [Turno] nvarchar(max)  NOT NULL,
    [Telefono] int  NOT NULL,
    [E_Mail] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tipo_Grupos'
CREATE TABLE [dbo].[Tipo_Grupos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Tipo_Grupo] nvarchar(max)  NOT NULL,
    [Nombre_Tipo_Grupo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Progresion_Juveniles'
CREATE TABLE [dbo].[Progresion_Juveniles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Etapa_Prog] nvarchar(max)  NOT NULL,
    [Descripcion_Etapa] nvarchar(max)  NOT NULL,
    [Membresia_JuvenilId] int  NOT NULL
);
GO

-- Creating table 'Detalle_Evento_Patros'
CREATE TABLE [dbo].[Detalle_Evento_Patros] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Desde] datetime  NOT NULL,
    [PatrocinadorId] int  NOT NULL,
    [EventoId] int  NOT NULL,
    [Hasta] datetime  NOT NULL,
    [Local_EventoId] int  NOT NULL,
    [Asistente_EventoId] int  NOT NULL
);
GO

-- Creating table 'Detalle_Grupo_Patros'
CREATE TABLE [dbo].[Detalle_Grupo_Patros] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Desde] datetime  NOT NULL,
    [PatrocinadorId] int  NOT NULL,
    [GrupoId] int  NOT NULL,
    [Hasta] datetime  NOT NULL
);
GO

-- Creating table 'Local_Eventos'
CREATE TABLE [dbo].[Local_Eventos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Direccion] nvarchar(max)  NOT NULL,
    [Telefono] int  NOT NULL,
    [E_Mail] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Asistente_Eventos'
CREATE TABLE [dbo].[Asistente_Eventos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Hora_Llegada] time  NOT NULL
);
GO

-- Creating table 'Tutorias'
CREATE TABLE [dbo].[Tutorias] (
    [Id] int  NOT NULL,
    [Parentezco] nvarchar(max)  NOT NULL,
    [PersonaId] int  NOT NULL
);
GO

-- Creating table 'Membresia_JuvenilSet'
CREATE TABLE [dbo].[Membresia_JuvenilSet] (
    [SubGrupoId] int  NOT NULL,
    [Etapa_AprobacionId] int  NOT NULL,
    [JuvenilId] int  NOT NULL,
    [Annio] nvarchar(max)  NOT NULL,
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Personas_Responsable'
CREATE TABLE [dbo].[Personas_Responsable] (
    [PeriodoId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Personas_Personal_Admon'
CREATE TABLE [dbo].[Personas_Personal_Admon] (
    [CargoId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Personas_Asistente'
CREATE TABLE [dbo].[Personas_Asistente] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'Personas_Juvenil'
CREATE TABLE [dbo].[Personas_Juvenil] (
    [Centro_EstudioId] int  NOT NULL,
    [TutoriaId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Personas_Patrocinador'
CREATE TABLE [dbo].[Personas_Patrocinador] (
    [Nombre_Insti] nvarchar(max)  NOT NULL,
    [Nombre_Representante] nvarchar(max)  NOT NULL,
    [Trabajo] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Personas_Adulto'
CREATE TABLE [dbo].[Personas_Adulto] (
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Periodos'
ALTER TABLE [dbo].[Periodos]
ADD CONSTRAINT [PK_Periodos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Departamentos'
ALTER TABLE [dbo].[Departamentos]
ADD CONSTRAINT [PK_Departamentos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Municipios'
ALTER TABLE [dbo].[Municipios]
ADD CONSTRAINT [PK_Municipios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Sectores'
ALTER TABLE [dbo].[Sectores]
ADD CONSTRAINT [PK_Sectores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Distritos'
ALTER TABLE [dbo].[Distritos]
ADD CONSTRAINT [PK_Distritos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Eventos'
ALTER TABLE [dbo].[Eventos]
ADD CONSTRAINT [PK_Eventos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Membresia_Adultos'
ALTER TABLE [dbo].[Membresia_Adultos]
ADD CONSTRAINT [PK_Membresia_Adultos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Personas'
ALTER TABLE [dbo].[Personas]
ADD CONSTRAINT [PK_Personas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SubGrupos'
ALTER TABLE [dbo].[SubGrupos]
ADD CONSTRAINT [PK_SubGrupos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Grupos'
ALTER TABLE [dbo].[Grupos]
ADD CONSTRAINT [PK_Grupos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Etapa_Aprobaciones'
ALTER TABLE [dbo].[Etapa_Aprobaciones]
ADD CONSTRAINT [PK_Etapa_Aprobaciones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cargos'
ALTER TABLE [dbo].[Cargos]
ADD CONSTRAINT [PK_Cargos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Centro_Estudios'
ALTER TABLE [dbo].[Centro_Estudios]
ADD CONSTRAINT [PK_Centro_Estudios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tipo_Grupos'
ALTER TABLE [dbo].[Tipo_Grupos]
ADD CONSTRAINT [PK_Tipo_Grupos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Progresion_Juveniles'
ALTER TABLE [dbo].[Progresion_Juveniles]
ADD CONSTRAINT [PK_Progresion_Juveniles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Detalle_Evento_Patros'
ALTER TABLE [dbo].[Detalle_Evento_Patros]
ADD CONSTRAINT [PK_Detalle_Evento_Patros]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Detalle_Grupo_Patros'
ALTER TABLE [dbo].[Detalle_Grupo_Patros]
ADD CONSTRAINT [PK_Detalle_Grupo_Patros]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Local_Eventos'
ALTER TABLE [dbo].[Local_Eventos]
ADD CONSTRAINT [PK_Local_Eventos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Asistente_Eventos'
ALTER TABLE [dbo].[Asistente_Eventos]
ADD CONSTRAINT [PK_Asistente_Eventos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tutorias'
ALTER TABLE [dbo].[Tutorias]
ADD CONSTRAINT [PK_Tutorias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Membresia_JuvenilSet'
ALTER TABLE [dbo].[Membresia_JuvenilSet]
ADD CONSTRAINT [PK_Membresia_JuvenilSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Personas_Responsable'
ALTER TABLE [dbo].[Personas_Responsable]
ADD CONSTRAINT [PK_Personas_Responsable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Personas_Personal_Admon'
ALTER TABLE [dbo].[Personas_Personal_Admon]
ADD CONSTRAINT [PK_Personas_Personal_Admon]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Personas_Asistente'
ALTER TABLE [dbo].[Personas_Asistente]
ADD CONSTRAINT [PK_Personas_Asistente]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Personas_Juvenil'
ALTER TABLE [dbo].[Personas_Juvenil]
ADD CONSTRAINT [PK_Personas_Juvenil]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Personas_Patrocinador'
ALTER TABLE [dbo].[Personas_Patrocinador]
ADD CONSTRAINT [PK_Personas_Patrocinador]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Personas_Adulto'
ALTER TABLE [dbo].[Personas_Adulto]
ADD CONSTRAINT [PK_Personas_Adulto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PeriodoId] in table 'Personas_Responsable'
ALTER TABLE [dbo].[Personas_Responsable]
ADD CONSTRAINT [FK_PeriodoResponsable]
    FOREIGN KEY ([PeriodoId])
    REFERENCES [dbo].[Periodos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PeriodoResponsable'
CREATE INDEX [IX_FK_PeriodoResponsable]
ON [dbo].[Personas_Responsable]
    ([PeriodoId]);
GO

-- Creating foreign key on [ResponsableId] in table 'Grupos'
ALTER TABLE [dbo].[Grupos]
ADD CONSTRAINT [FK_ResponsableGrupo]
    FOREIGN KEY ([ResponsableId])
    REFERENCES [dbo].[Personas_Responsable]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ResponsableGrupo'
CREATE INDEX [IX_FK_ResponsableGrupo]
ON [dbo].[Grupos]
    ([ResponsableId]);
GO

-- Creating foreign key on [DepartamentoId] in table 'Personas'
ALTER TABLE [dbo].[Personas]
ADD CONSTRAINT [FK_DepartamentoPersona]
    FOREIGN KEY ([DepartamentoId])
    REFERENCES [dbo].[Departamentos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartamentoPersona'
CREATE INDEX [IX_FK_DepartamentoPersona]
ON [dbo].[Personas]
    ([DepartamentoId]);
GO

-- Creating foreign key on [DepartamentoId] in table 'Municipios'
ALTER TABLE [dbo].[Municipios]
ADD CONSTRAINT [FK_DepartamentoMunicipio]
    FOREIGN KEY ([DepartamentoId])
    REFERENCES [dbo].[Departamentos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartamentoMunicipio'
CREATE INDEX [IX_FK_DepartamentoMunicipio]
ON [dbo].[Municipios]
    ([DepartamentoId]);
GO

-- Creating foreign key on [MunicipioId] in table 'Sectores'
ALTER TABLE [dbo].[Sectores]
ADD CONSTRAINT [FK_MunicipioSector]
    FOREIGN KEY ([MunicipioId])
    REFERENCES [dbo].[Municipios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MunicipioSector'
CREATE INDEX [IX_FK_MunicipioSector]
ON [dbo].[Sectores]
    ([MunicipioId]);
GO

-- Creating foreign key on [DistritoId] in table 'Sectores'
ALTER TABLE [dbo].[Sectores]
ADD CONSTRAINT [FK_DistritoSector]
    FOREIGN KEY ([DistritoId])
    REFERENCES [dbo].[Distritos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DistritoSector'
CREATE INDEX [IX_FK_DistritoSector]
ON [dbo].[Sectores]
    ([DistritoId]);
GO

-- Creating foreign key on [CargoId] in table 'Personas_Personal_Admon'
ALTER TABLE [dbo].[Personas_Personal_Admon]
ADD CONSTRAINT [FK_CargoPersonal_Admon]
    FOREIGN KEY ([CargoId])
    REFERENCES [dbo].[Cargos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CargoPersonal_Admon'
CREATE INDEX [IX_FK_CargoPersonal_Admon]
ON [dbo].[Personas_Personal_Admon]
    ([CargoId]);
GO

-- Creating foreign key on [AsistenteId] in table 'SubGrupos'
ALTER TABLE [dbo].[SubGrupos]
ADD CONSTRAINT [FK_AsistenteSubGrupo]
    FOREIGN KEY ([AsistenteId])
    REFERENCES [dbo].[Personas_Asistente]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AsistenteSubGrupo'
CREATE INDEX [IX_FK_AsistenteSubGrupo]
ON [dbo].[SubGrupos]
    ([AsistenteId]);
GO

-- Creating foreign key on [SubGrupoId] in table 'Membresia_JuvenilSet'
ALTER TABLE [dbo].[Membresia_JuvenilSet]
ADD CONSTRAINT [FK_SubGrupoMembresia_Juvenil]
    FOREIGN KEY ([SubGrupoId])
    REFERENCES [dbo].[SubGrupos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubGrupoMembresia_Juvenil'
CREATE INDEX [IX_FK_SubGrupoMembresia_Juvenil]
ON [dbo].[Membresia_JuvenilSet]
    ([SubGrupoId]);
GO

-- Creating foreign key on [Tipo_GrupoId] in table 'SubGrupos'
ALTER TABLE [dbo].[SubGrupos]
ADD CONSTRAINT [FK_Tipo_GrupoSubGrupo]
    FOREIGN KEY ([Tipo_GrupoId])
    REFERENCES [dbo].[Tipo_Grupos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tipo_GrupoSubGrupo'
CREATE INDEX [IX_FK_Tipo_GrupoSubGrupo]
ON [dbo].[SubGrupos]
    ([Tipo_GrupoId]);
GO

-- Creating foreign key on [GrupoId] in table 'SubGrupos'
ALTER TABLE [dbo].[SubGrupos]
ADD CONSTRAINT [FK_GrupoSubGrupo]
    FOREIGN KEY ([GrupoId])
    REFERENCES [dbo].[Grupos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GrupoSubGrupo'
CREATE INDEX [IX_FK_GrupoSubGrupo]
ON [dbo].[SubGrupos]
    ([GrupoId]);
GO

-- Creating foreign key on [SubGrupoId] in table 'Eventos'
ALTER TABLE [dbo].[Eventos]
ADD CONSTRAINT [FK_SubGrupoEvento]
    FOREIGN KEY ([SubGrupoId])
    REFERENCES [dbo].[SubGrupos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubGrupoEvento'
CREATE INDEX [IX_FK_SubGrupoEvento]
ON [dbo].[Eventos]
    ([SubGrupoId]);
GO

-- Creating foreign key on [Centro_EstudioId] in table 'Personas_Juvenil'
ALTER TABLE [dbo].[Personas_Juvenil]
ADD CONSTRAINT [FK_Centro_EstudioJuvenil]
    FOREIGN KEY ([Centro_EstudioId])
    REFERENCES [dbo].[Centro_Estudios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Centro_EstudioJuvenil'
CREATE INDEX [IX_FK_Centro_EstudioJuvenil]
ON [dbo].[Personas_Juvenil]
    ([Centro_EstudioId]);
GO

-- Creating foreign key on [DistritoId] in table 'Grupos'
ALTER TABLE [dbo].[Grupos]
ADD CONSTRAINT [FK_DistritoGrupo]
    FOREIGN KEY ([DistritoId])
    REFERENCES [dbo].[Distritos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DistritoGrupo'
CREATE INDEX [IX_FK_DistritoGrupo]
ON [dbo].[Grupos]
    ([DistritoId]);
GO

-- Creating foreign key on [PatrocinadorId] in table 'Detalle_Evento_Patros'
ALTER TABLE [dbo].[Detalle_Evento_Patros]
ADD CONSTRAINT [FK_PatrocinadorDetalle_Evento_Patro]
    FOREIGN KEY ([PatrocinadorId])
    REFERENCES [dbo].[Personas_Patrocinador]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PatrocinadorDetalle_Evento_Patro'
CREATE INDEX [IX_FK_PatrocinadorDetalle_Evento_Patro]
ON [dbo].[Detalle_Evento_Patros]
    ([PatrocinadorId]);
GO

-- Creating foreign key on [EventoId] in table 'Detalle_Evento_Patros'
ALTER TABLE [dbo].[Detalle_Evento_Patros]
ADD CONSTRAINT [FK_EventoDetalle_Evento_Patro]
    FOREIGN KEY ([EventoId])
    REFERENCES [dbo].[Eventos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventoDetalle_Evento_Patro'
CREATE INDEX [IX_FK_EventoDetalle_Evento_Patro]
ON [dbo].[Detalle_Evento_Patros]
    ([EventoId]);
GO

-- Creating foreign key on [PatrocinadorId] in table 'Detalle_Grupo_Patros'
ALTER TABLE [dbo].[Detalle_Grupo_Patros]
ADD CONSTRAINT [FK_PatrocinadorDetalle_Grupo_Patro]
    FOREIGN KEY ([PatrocinadorId])
    REFERENCES [dbo].[Personas_Patrocinador]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PatrocinadorDetalle_Grupo_Patro'
CREATE INDEX [IX_FK_PatrocinadorDetalle_Grupo_Patro]
ON [dbo].[Detalle_Grupo_Patros]
    ([PatrocinadorId]);
GO

-- Creating foreign key on [GrupoId] in table 'Detalle_Grupo_Patros'
ALTER TABLE [dbo].[Detalle_Grupo_Patros]
ADD CONSTRAINT [FK_GrupoDetalle_Grupo_Patro]
    FOREIGN KEY ([GrupoId])
    REFERENCES [dbo].[Grupos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GrupoDetalle_Grupo_Patro'
CREATE INDEX [IX_FK_GrupoDetalle_Grupo_Patro]
ON [dbo].[Detalle_Grupo_Patros]
    ([GrupoId]);
GO

-- Creating foreign key on [Local_EventoId] in table 'Detalle_Evento_Patros'
ALTER TABLE [dbo].[Detalle_Evento_Patros]
ADD CONSTRAINT [FK_Local_EventoDetalle_Evento_Patro]
    FOREIGN KEY ([Local_EventoId])
    REFERENCES [dbo].[Local_Eventos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Local_EventoDetalle_Evento_Patro'
CREATE INDEX [IX_FK_Local_EventoDetalle_Evento_Patro]
ON [dbo].[Detalle_Evento_Patros]
    ([Local_EventoId]);
GO

-- Creating foreign key on [Asistente_EventoId] in table 'Detalle_Evento_Patros'
ALTER TABLE [dbo].[Detalle_Evento_Patros]
ADD CONSTRAINT [FK_Asistente_EventoDetalle_Evento_Patro]
    FOREIGN KEY ([Asistente_EventoId])
    REFERENCES [dbo].[Asistente_Eventos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Asistente_EventoDetalle_Evento_Patro'
CREATE INDEX [IX_FK_Asistente_EventoDetalle_Evento_Patro]
ON [dbo].[Detalle_Evento_Patros]
    ([Asistente_EventoId]);
GO

-- Creating foreign key on [Etapa_AprobacionId] in table 'Membresia_JuvenilSet'
ALTER TABLE [dbo].[Membresia_JuvenilSet]
ADD CONSTRAINT [FK_Etapa_AprobacionMembresia_Juvenil]
    FOREIGN KEY ([Etapa_AprobacionId])
    REFERENCES [dbo].[Etapa_Aprobaciones]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Etapa_AprobacionMembresia_Juvenil'
CREATE INDEX [IX_FK_Etapa_AprobacionMembresia_Juvenil]
ON [dbo].[Membresia_JuvenilSet]
    ([Etapa_AprobacionId]);
GO

-- Creating foreign key on [PersonaId] in table 'Tutorias'
ALTER TABLE [dbo].[Tutorias]
ADD CONSTRAINT [FK_PersonaTutoria]
    FOREIGN KEY ([PersonaId])
    REFERENCES [dbo].[Personas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonaTutoria'
CREATE INDEX [IX_FK_PersonaTutoria]
ON [dbo].[Tutorias]
    ([PersonaId]);
GO

-- Creating foreign key on [TutoriaId] in table 'Personas_Juvenil'
ALTER TABLE [dbo].[Personas_Juvenil]
ADD CONSTRAINT [FK_TutoriaJuvenil]
    FOREIGN KEY ([TutoriaId])
    REFERENCES [dbo].[Tutorias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TutoriaJuvenil'
CREATE INDEX [IX_FK_TutoriaJuvenil]
ON [dbo].[Personas_Juvenil]
    ([TutoriaId]);
GO

-- Creating foreign key on [JuvenilId] in table 'Membresia_JuvenilSet'
ALTER TABLE [dbo].[Membresia_JuvenilSet]
ADD CONSTRAINT [FK_JuvenilMembresia_Juvenil]
    FOREIGN KEY ([JuvenilId])
    REFERENCES [dbo].[Personas_Juvenil]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JuvenilMembresia_Juvenil'
CREATE INDEX [IX_FK_JuvenilMembresia_Juvenil]
ON [dbo].[Membresia_JuvenilSet]
    ([JuvenilId]);
GO

-- Creating foreign key on [Etapa_AprobacionId] in table 'Membresia_Adultos'
ALTER TABLE [dbo].[Membresia_Adultos]
ADD CONSTRAINT [FK_Etapa_AprobacionMembresia_Adulto]
    FOREIGN KEY ([Etapa_AprobacionId])
    REFERENCES [dbo].[Etapa_Aprobaciones]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Etapa_AprobacionMembresia_Adulto'
CREATE INDEX [IX_FK_Etapa_AprobacionMembresia_Adulto]
ON [dbo].[Membresia_Adultos]
    ([Etapa_AprobacionId]);
GO

-- Creating foreign key on [AdultoId] in table 'Membresia_Adultos'
ALTER TABLE [dbo].[Membresia_Adultos]
ADD CONSTRAINT [FK_AdultoMembresia_Adulto]
    FOREIGN KEY ([AdultoId])
    REFERENCES [dbo].[Personas_Adulto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdultoMembresia_Adulto'
CREATE INDEX [IX_FK_AdultoMembresia_Adulto]
ON [dbo].[Membresia_Adultos]
    ([AdultoId]);
GO

-- Creating foreign key on [Membresia_JuvenilId] in table 'Progresion_Juveniles'
ALTER TABLE [dbo].[Progresion_Juveniles]
ADD CONSTRAINT [FK_Membresia_JuvenilProgresion_Juvenil]
    FOREIGN KEY ([Membresia_JuvenilId])
    REFERENCES [dbo].[Membresia_JuvenilSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Membresia_JuvenilProgresion_Juvenil'
CREATE INDEX [IX_FK_Membresia_JuvenilProgresion_Juvenil]
ON [dbo].[Progresion_Juveniles]
    ([Membresia_JuvenilId]);
GO

-- Creating foreign key on [Id] in table 'Personas_Responsable'
ALTER TABLE [dbo].[Personas_Responsable]
ADD CONSTRAINT [FK_Responsable_inherits_Persona]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Personas]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Personas_Personal_Admon'
ALTER TABLE [dbo].[Personas_Personal_Admon]
ADD CONSTRAINT [FK_Personal_Admon_inherits_Persona]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Personas]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Personas_Asistente'
ALTER TABLE [dbo].[Personas_Asistente]
ADD CONSTRAINT [FK_Asistente_inherits_Persona]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Personas]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Personas_Juvenil'
ALTER TABLE [dbo].[Personas_Juvenil]
ADD CONSTRAINT [FK_Juvenil_inherits_Persona]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Personas]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Personas_Patrocinador'
ALTER TABLE [dbo].[Personas_Patrocinador]
ADD CONSTRAINT [FK_Patrocinador_inherits_Persona]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Personas]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Personas_Adulto'
ALTER TABLE [dbo].[Personas_Adulto]
ADD CONSTRAINT [FK_Adulto_inherits_Persona]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Personas]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------