-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Servidor: localhost:3310
-- Tiempo de generación: 19-04-2021 a las 22:25:14
-- Versión del servidor: 10.4.14-MariaDB
-- Versión de PHP: 7.4.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `consultingproject`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `actividades`
--

CREATE TABLE `actividades` (
  `Id_actividad` varchar(6) NOT NULL,
  `nombre_actividad` text DEFAULT NULL,
  `Descripcion_actividad` text DEFAULT NULL,
  `Id_etapa` varchar(4) NOT NULL,
  `Id_proyecto` varchar(6) NOT NULL,
  `Id_profesional` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `actividades`
--

INSERT INTO `actividades` (`Id_actividad`, `nombre_actividad`, `Descripcion_actividad`, `Id_etapa`, `Id_proyecto`, `Id_profesional`) VALUES
('A001', 'Formulario de inscripción', 'Generar formulario de inscripción para inscripcion de empresas', 'E001', 'IMP', 'P003'),
('A002', 'Aprobación empresas', 'Revisar que las empresas cumplan con los requisitos de participacion', 'E001', 'IMP', 'P003'),
('A003', 'Notificar empresas aprobadas', 'Enviar correos notificando empresas aprobadas', 'E001', 'IMP', 'P003'),
('A004', 'Notificar empresas no aprobadas', 'Enviar correos notificando empresas aprobadas', 'E001', 'IMP', 'P003'),
('A005', 'Postulación CV', 'Se realiza convocatoria de consultores ', 'E002', 'IMP', 'P003'),
('A006', 'Aprobar consultores', 'Se verifican requisitos y se aprueban consultores ', 'E002', 'IMP', 'P001'),
('A007', 'Contratación', 'Se realiza proceso para contratación de consultores', 'E002', 'IMP', 'P002'),
('A008', 'Asignación Usuario', 'Se crea usuario y contraseña', 'E002', 'IMP', 'P003'),
('A009', 'Asignacion empresas', 'Se asigna empresas a consultores', 'E002', 'IMP', 'P001'),
('A010', 'Notificar consultores', 'Enviar notificacion a consultores de las empresas asignadas', 'E002', 'IMP', 'P003'),
('A012', 'Capacitación', 'Capacitacion SI', 'E002', 'IMP', 'P003'),
('A013', 'Programación seminarios', '', 'E003', 'IMP', 'P003'),
('A014', 'Convocatoria para empresas', 'Enviar invitacion a las empresas', 'E003', 'IMP', 'P003'),
('A015', 'Listado Asistencia', 'Consolidar listado de asistencia', 'E003', 'IMP', 'P003'),
('A016', 'Certificados', 'Generar Certificados de formaciones', 'E003', 'IMP', 'P003'),
('A017', 'Reporte Avance', 'Generar reporte de avance de actividades', 'E004', 'IMP', 'P001'),
('A018', 'Informe Final', 'Generar reporte final de proyecto', 'E005', 'IMP', 'P001');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetroleclaims`
--

CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL,
  `RoleId` varchar(127) NOT NULL,
  `ClaimType` text DEFAULT NULL,
  `ClaimValue` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetroles`
--

CREATE TABLE `aspnetroles` (
  `Id` varchar(127) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` varchar(256) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `aspnetroles`
--

INSERT INTO `aspnetroles` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`) VALUES
('admin01', 'Administrador', 'Administrador', NULL),
('consultor01', 'Consultor', 'Consultor', NULL),
('profesional01', 'Profesional', 'Profesional', NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetuserclaims`
--

CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(767) NOT NULL,
  `ClaimType` text DEFAULT NULL,
  `ClaimValue` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetuserlogins`
--

CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(127) NOT NULL,
  `ProviderKey` varchar(127) NOT NULL,
  `ProviderDisplayName` text DEFAULT NULL,
  `UserId` varchar(767) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetuserroles`
--

CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(127) NOT NULL,
  `RoleId` varchar(127) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `aspnetuserroles`
--

INSERT INTO `aspnetuserroles` (`UserId`, `RoleId`) VALUES
('0a95cedc-ae66-4e6b-a290-e2a86b09bd77', 'consultor01'),
('1c4af4e6-6dfc-4dd6-a812-93b5391fff8e', 'admin01'),
('1eaeb03c-ebdc-4118-88c0-74dd162328bc', 'profesional01');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetusers`
--

CREATE TABLE `aspnetusers` (
  `Id` varchar(767) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` text DEFAULT NULL,
  `SecurityStamp` text DEFAULT NULL,
  `ConcurrencyStamp` text DEFAULT NULL,
  `PhoneNumber` text DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` timestamp NULL DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES
('0a95cedc-ae66-4e6b-a290-e2a86b09bd77', 'consultortest@gmail.com', 'CONSULTORTEST@GMAIL.COM', 'consultortest@gmail.com', 'CONSULTORTEST@GMAIL.COM', 0, 'AQAAAAEAACcQAAAAEEz05KI5U5L7EXjY7uWwvK+jasEbF/QL1wQ1/VDPGWU1xBXRMx5rPlKGVS8F66zVWw==', 'VAA4M3XRWEL7MHM67XR6FX76H5MNGCV6', 'af89932a-7f9c-4344-817c-b4e464898c3e', NULL, 0, 0, NULL, 1, 0),
('1c4af4e6-6dfc-4dd6-a812-93b5391fff8e', 'myarag17@gmail.com', 'MYARAG17@GMAIL.COM', 'myarag17@gmail.com', 'MYARAG17@GMAIL.COM', 0, 'AQAAAAEAACcQAAAAEHxniZAHK+/7G/BaKQRcvXSgQJX97cCUC9lnTiMS1cWUuJ1KA2JFoESxaYaqU3myWA==', 'PPG5CCVCRH6J4BVC3B4SI5W6RN2JKNI6', 'c7c61937-07cd-4501-9dcf-8bfec760f394', NULL, 0, 0, NULL, 1, 0),
('1eaeb03c-ebdc-4118-88c0-74dd162328bc', 'usuariotest@gmail.com', 'USUARIOTEST@GMAIL.COM', 'usuariotest@gmail.com', 'USUARIOTEST@GMAIL.COM', 0, 'AQAAAAEAACcQAAAAEA3xkZQLcWN4AvBKqdXIzLPsJOn+tULG43+Ag9CnBy5DpZtNpbzgxkhEtvvUzPhqSw==', 'O46YOXLUJDCFFKNRE727TK6ILDBZJZD6', '24aaf054-8bc1-4d21-ace3-49831fd05123', NULL, 0, 0, NULL, 1, 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetusertokens`
--

CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(127) NOT NULL,
  `LoginProvider` varchar(127) NOT NULL,
  `Name` varchar(127) NOT NULL,
  `Value` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cargos`
--

CREATE TABLE `cargos` (
  `Id_cargo` varchar(3) NOT NULL,
  `Cargo` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `cargos`
--

INSERT INTO `cargos` (`Id_cargo`, `Cargo`) VALUES
('A', 'Asistente de proyecto'),
('C', 'Consultor'),
('CA', 'Coordinador administrativo'),
('CP', 'Coordinador de proyecto'),
('CT', 'Coordinador técnico'),
('DP', 'Director de proyecto');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `citaconsultoria`
--

CREATE TABLE `citaconsultoria` (
  `id_citaconsultoria` varchar(5) NOT NULL,
  `Empresa` varchar(50) NOT NULL,
  `Asunto` varchar(200) NOT NULL,
  `Fechayhora` date NOT NULL DEFAULT current_timestamp(),
  `Lugar` varchar(50) NOT NULL,
  `Invitar_Correo` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `contacto_empresa`
--

CREATE TABLE `contacto_empresa` (
  `Id_Contacto_empresa` varchar(6) NOT NULL,
  `Nombres_Contacto_empresa` varchar(40) DEFAULT NULL,
  `Apellidos_Contacto_empresa` varchar(40) DEFAULT NULL,
  `Correo` varchar(40) DEFAULT NULL,
  `Telefono` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `departamento`
--

CREATE TABLE `departamento` (
  `Código_Departamento` int(11) NOT NULL,
  `Nombre_Departamento` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `departamento`
--

INSERT INTO `departamento` (`Código_Departamento`, `Nombre_Departamento`) VALUES
(5, 'ANTIOQUIA'),
(8, 'ATLANTICO'),
(11, 'BOGOTA'),
(13, 'BOLIVAR'),
(15, 'BOYACA'),
(17, 'CALDAS'),
(18, 'CAQUETA'),
(19, 'CAUCA'),
(20, 'CESAR'),
(23, 'CORDOBA'),
(25, 'CUNDINAMARCA'),
(27, 'CHOCO'),
(41, 'HUILA'),
(44, 'LA GUAJIRA'),
(47, 'MAGDALENA'),
(50, 'META'),
(52, 'NARIÑO'),
(54, 'N. DE SANTANDER'),
(63, 'QUINDIO'),
(66, 'RISARALDA'),
(68, 'SANTANDER'),
(70, 'SUCRE'),
(73, 'TOLIMA'),
(76, 'VALLE DEL CAUCA'),
(81, 'ARAUCA'),
(85, 'CASANARE'),
(86, 'PUTUMAYO'),
(88, 'SAN ANDRES'),
(91, 'AMAZONAS'),
(94, 'GUAINIA'),
(95, 'GUAVIARE'),
(97, 'VAUPES'),
(99, 'VICHADA');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `eje_seleccionado`
--

CREATE TABLE `eje_seleccionado` (
  `Id_eje` varchar(4) NOT NULL,
  `Eje` varchar(25) DEFAULT NULL,
  `Id_proyecto` varchar(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `eje_seleccionado`
--

INSERT INTO `eje_seleccionado` (`Id_eje`, `Eje`, `Id_proyecto`) VALUES
('0000', 'N/A', 'IMP'),
('B001', 'Bioseguridad', 'IMP'),
('C002', 'Continuidad de negocio', 'IMP'),
('F003', 'Financiero', 'IMP'),
('J004', 'Jurídico', 'IMP');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empresa`
--

CREATE TABLE `empresa` (
  `Id_empresa` int(11) NOT NULL,
  `Nombre_empresa` varchar(15) DEFAULT NULL,
  `NIT` int(11) DEFAULT NULL,
  `Digito_verificacion` int(11) DEFAULT NULL,
  `Fechaconstlegal` date DEFAULT NULL,
  `Código_Departamento` int(11) NOT NULL,
  `Código_Municipio` int(11) NOT NULL,
  `Id_sector` varchar(3) NOT NULL,
  `Id_Tamaño_empresa` varchar(6) NOT NULL,
  `Id_eje` varchar(4) NOT NULL,
  `Id_proyecto` varchar(6) NOT NULL,
  `Id_profesional` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `empresa`
--

INSERT INTO `empresa` (`Id_empresa`, `Nombre_empresa`, `NIT`, `Digito_verificacion`, `Fechaconstlegal`, `Código_Departamento`, `Código_Municipio`, `Id_sector`, `Id_Tamaño_empresa`, `Id_eje`, `Id_proyecto`, `Id_profesional`) VALUES
(1, 'Technomart SAS', 900829885, 5, '2015-03-13', 91, 515, 'S28', 'I', 'B001', 'IMP', 'P028'),
(2, 'GRUPO EMPRESARI', 900271394, 3, '2009-03-09', 11, 110, 'S09', 'I', 'B001', 'IMP', 'P028'),
(3, 'Alimentos Colom', 830067294, 8, '2000-01-22', 11, 110, 'S02', 'III', 'B001', 'IMP', 'P028'),
(4, 'BIOLOGÍA MOLECU', 900006315, 7, '2005-08-05', 73, 434, 'S27', 'I', 'B001', 'IMP', 'P028'),
(5, 'SELETTI SAS', 800238299, 1, '1994-08-09', 54, 266, 'S29', 'III', 'B001', 'IMP', 'P028'),
(6, 'PLASTICOS GHCA ', 901160932, 3, '2018-02-06', 52, 670, 'S26', 'I', 'C002', 'IMP', 'P006'),
(7, 'COOTRANSESPECIA', 900450176, 2, '2011-07-12', 11, 110, 'S30', 'I', 'C002', 'IMP', 'P025'),
(8, 'Fábrica Colombi', 901252731, 5, '2019-02-07', 5, 1, 'S22', 'I', 'F003', 'IMP', 'P004'),
(9, 'TBE MARKETING C', 900792512, 1, '2014-11-20', 11, 110, 'S28', 'II', 'F003', 'IMP', 'P004'),
(10, 'Ecoglobal Exped', 900423429, 6, '2011-03-23', 41, 612, 'S31', 'I', 'F003', 'IMP', 'P019'),
(11, 'Pacóa', 901149975, 5, '2016-02-01', 11, 110, 'S31', 'I', 'B001', 'IMP', 'P024'),
(12, 'Excursiones y T', 2147483647, 1, '2011-02-15', 20, 1063, 'S31', 'I', 'F003', 'IMP', 'P019'),
(13, 'Paramo Trek SAS', 901093369, 9, '2017-06-29', 11, 110, 'S31', 'I', 'F003', 'IMP', 'P011'),
(14, 'Cartagena For T', 901230150, 1, '2018-07-31', 25, 956, 'S30', 'I', 'F003', 'IMP', 'P011'),
(15, 'TRUCHERA EL OAS', 900285446, 9, '2009-05-11', 11, 110, 'S25', 'I', 'F003', 'IMP', 'P004'),
(16, 'Intelectum SAS', 901221605, 2, '2018-09-26', 11, 110, 'S28', 'I', 'F003', 'IMP', 'P019'),
(17, 'RETORNO S.A.S', 900438316, 8, '2011-12-13', 11, 110, 'S31', 'I', 'F003', 'IMP', 'P011'),
(18, 'DE UNA Colombia', 830146707, 7, '2004-08-23', 11, 110, 'S30', 'III', 'F003', 'IMP', 'P011'),
(19, 'TERRITORIO COLO', 900348176, 7, '2010-03-17', 11, 110, 'S31', 'II', 'F003', 'IMP', 'P004'),
(20, 'XPERIENCE TURIS', 900239131, 9, '2008-09-01', 54, 266, 'S31', 'I', 'F003', 'IMP', 'P019'),
(21, 'DISTRIAGROSEEDS', 900387378, 4, '2010-10-10', 5, 561, 'S02', 'I', 'C002', 'IMP', 'P032'),
(22, 'PACIFIC TRAVEL ', 901147480, 2, '2018-01-18', 25, 956, 'S31', 'I', 'C002', 'IMP', 'P032'),
(23, 'Descarga Colomb', 900389221, 7, '2010-10-15', 5, 561, 'S30', 'II', 'C002', 'IMP', 'P006'),
(24, 'MPM Consulting ', 900976685, 8, '2016-06-02', 68, 840, 'S05', 'I', 'C002', 'IMP', 'P032'),
(25, 'Casa Chente SAS', 901103849, 7, '2017-08-04', 11, 110, 'S31', 'I', 'B001', 'IMP', 'P028'),
(26, 'ALACOR SAS', 901198755, 1, '2020-08-01', 66, 681, 'S23', 'I', 'F003', 'IMP', 'P019'),
(27, 'EXYPNOS INGENIE', 901185054, 1, '2020-07-18', 11, 110, 'S18', 'II', 'F003', 'IMP', 'P019'),
(28, 'corporación de ', 800234799, 2, '1997-02-20', 68, 86, 'S31', 'I', 'F003', 'IMP', 'P019'),
(29, 'ANDESCOL S.A.S', 900199473, 1, '2008-02-11', 63, 804, 'S18', 'III', 'F003', 'IMP', 'P010'),
(30, 'DISEÑOS SHARO S', 900448180, 6, '2011-07-02', 13, 176, 'S29', 'II', 'F003', 'IMP', 'P010'),
(31, 'GESTION Y CONTR', 900306635, 6, '2009-08-09', 11, 110, 'S26', 'II', 'F003', 'IMP', 'P010'),
(32, 'Fundación Ramón', 900955446, 4, '2016-02-01', 25, 367, 'S30', 'I', 'F003', 'IMP', 'P004'),
(33, 'AGROPECUARIA CA', 900667801, 0, '2013-10-24', 11, 110, 'S02', 'I', 'F003', 'IMP', 'P019'),
(34, 'CRAVO SUR S.A.S', 2147483647, 0, '2016-11-23', 11, 110, 'S29', 'I', 'J004', 'IMP', 'P015'),
(35, 'Santa Publicida', 900339729, 1, '2010-02-12', 86, 576, 'S10', 'I', 'J004', 'IMP', 'P015'),
(36, 'IDEAS BIOMEDICA', 2147483647, 7, '2008-04-22', 25, 596, 'S27', 'I', 'B001', 'IMP', 'P026'),
(37, 'Ejefincas Colom', 901197344, 2, '2018-07-11', 11, 110, 'S31', 'I', 'B001', 'IMP', 'P024'),
(38, 'SUPER INFLABLES', 900471605, 0, '2011-10-12', 11, 110, 'S09', 'II', 'B001', 'IMP', 'P028'),
(39, 'Hotel Boutique ', 900430732, 2, '2011-04-26', 11, 110, 'S31', 'I', 'C002', 'IMP', 'P021'),
(40, 'DIMOREH S.A.S', 901308365, 5, '2019-07-30', 11, 110, 'S29', 'III', 'C002', 'IMP', 'P006'),
(41, 'C&C Instruments', 900618001, 6, '2013-05-17', 25, 979, 'S19', 'I', 'C002', 'IMP', 'P006'),
(42, 'SHIVA INGENIERI', 900540848, 8, '2020-02-01', 76, 152, 'S18', 'I', 'C002', 'IMP', 'P025'),
(43, 'Reserva Natural', 900582756, 0, '2020-03-25', 11, 110, 'S31', 'I', 'J004', 'IMP', 'P012'),
(44, 'FORTIS DOORS SA', 900696985, 0, '2020-04-30', 25, 255, 'S30', 'III', 'J004', 'IMP', 'P015'),
(45, 'Multiservicios ', 901048372, 0, '2017-01-26', 76, 299, 'S30', 'II', 'J004', 'IMP', 'P005'),
(46, 'Cruz Roja Colom', 800100542, 1, '1997-03-06', 25, 854, 'S32', 'III', 'J004', 'IMP', 'P012'),
(47, 'Industrial Caca', 891100158, 7, '1962-07-17', 25, 596, 'S06', 'III', 'C002', 'IMP', 'P021'),
(48, 'SG INGENIERIA S', 800061779, 1, '1989-03-27', 11, 110, 'S28', 'II', 'C002', 'IMP', 'P021'),
(49, 'Rio Elemento S.', 901131654, 7, '2017-11-10', 8, 723, 'S30', 'I', 'F003', 'IMP', 'P004'),
(50, 'LABORATORIOS RI', 860000757, 7, '1957-03-12', 76, 152, 'S15', 'I', 'F003', 'IMP', 'P019'),
(51, 'Mejia Consultor', 901281150, 1, '2019-05-08', 63, 587, 'S18', 'I', 'F003', 'IMP', 'P004'),
(52, 'Comunicación Ac', 811005344, 3, '1996-04-02', 5, 471, 'S10', 'II', 'F003', 'IMP', 'P019'),
(53, 'Wild About Colo', 901132193, 8, '2017-11-09', 63, 69, 'S31', 'I', 'F003', 'IMP', 'P010'),
(54, 'Solutions in Co', 900936031, 0, '2016-02-09', 11, 110, 'S30', 'I', 'F003', 'IMP', 'P020'),
(55, 'NATURE COLOMBIA', 900906993, 2, '2015-10-15', 25, 533, 'S02', 'II', 'F003', 'IMP', 'P020'),
(56, 'BC COFFEE COMPA', 901203777, 4, '2018-08-08', 13, 176, 'S14', 'I', 'F003', 'IMP', 'P020'),
(57, 'Laboratorio El ', 830062465, 8, '1999-09-23', 76, 152, 'S27', 'III', 'F003', 'IMP', 'P004'),
(58, 'Kaishi Travel o', 825003171, 8, '2003-06-10', 85, 1109, 'S31', 'I', 'F003', 'IMP', 'P019'),
(59, 'Monster Transpo', 900428134, 1, '0000-00-00', 85, 1109, 'S30', 'I', 'F003', 'IMP', 'P019'),
(60, 'Ecodestinos', 838000215, 7, '2001-01-06', 20, 475, 'S31', 'I', 'F003', 'IMP', 'P004'),
(61, 'Classic Jeans S', 900675626, 1, '0000-00-00', 85, 1109, 'S30', 'III', 'F003', 'IMP', 'P020'),
(62, 'Alimentos Tosta', 900914403, 2, '0000-00-00', 85, 1109, 'S02', 'II', 'F003', 'IMP', 'P020'),
(63, 'COSMETICOS BELI', 900848725, 6, '0000-00-00', 11, 110, 'S30', 'II', 'F003', 'IMP', 'P011'),
(64, 'MANUFACTURAS FE', 900317478, 3, '0000-00-00', 5, 561, 'S30', 'II', 'F003', 'IMP', 'P010'),
(65, 'Nirvana Medelli', 900222323, 1, '2008-04-06', 8, 92, 'S32', 'II', 'F003', 'IMP', 'P010'),
(66, 'Monte Gracia We', 2147483647, 5, '2017-06-29', 17, 780, 'S32', 'I', 'F003', 'IMP', 'P020'),
(67, 'Serviprocesos d', 901034315, 1, '0000-00-00', 25, 480, 'S30', 'I', 'F003', 'IMP', 'P020'),
(68, 'BELTRAN PUCHE S', 901113816, 7, '2017-09-12', 11, 110, 'S30', 'I', 'B001', 'IMP', 'P026'),
(69, 'INNOVACIONES OR', 901194257, 6, '2018-06-05', 73, 434, 'S09', 'I', 'F003', 'IMP', 'P019'),
(70, 'Gise Consultore', 901304690, 6, '2019-07-19', 15, 1006, 'S30', 'I', 'C002', 'IMP', 'P025'),
(71, 'GEFETIC S.A.S', 901044967, 4, '2017-01-20', 20, 1063, 'S30', 'I', 'F003', 'IMP', 'P004'),
(72, 'Interpreting Co', 900562114, 7, '2012-10-08', 8, 92, 'S30', 'II', 'F003', 'IMP', 'P019'),
(73, 'CARE Y ASOCIADO', 826001081, 8, '1998-01-05', 5, 336, 'S09', 'II', 'J004', 'IMP', 'P005'),
(74, 'Alternative Tra', 901007253, 7, '2016-09-08', 11, 110, 'S31', 'II', 'J004', 'IMP', 'P012'),
(75, 'LAMARGROUP SAS', 900617341, 0, '2013-05-15', 68, 120, 'S14', 'I', 'J004', 'IMP', 'P015'),
(76, 'Transmor sas', 844000218, 0, '1996-07-24', 44, 775, 'S30', 'II', 'J004', 'IMP', 'P012'),
(77, 'LLANO TOURS ZOM', 901241688, 9, '2018-12-12', 76, 152, 'S31', 'I', 'C002', 'IMP', 'P021'),
(78, 'FINCA VILLA GAB', 901204228, 7, '2018-08-07', 13, 176, 'S31', 'I', 'F003', 'IMP', 'P004'),
(79, 'MELANGE GOURMET', 830093564, 1, '2001-10-01', 18, 344, 'S02', 'I', 'F003', 'IMP', 'P019'),
(80, 'Industrias Mogo', 900615235, 9, '2013-05-07', 25, 970, 'S29', 'I', 'F003', 'IMP', 'P011'),
(81, 'TecniGasex SAS', 830103442, 6, '1995-08-28', 5, 464, 'S20', 'II', 'F003', 'IMP', 'P011'),
(82, 'SPIFFY SAS', 900517710, 6, '2012-03-29', 5, 444, 'S10', 'II', 'F003', 'IMP', 'P011'),
(83, 'OPERADOR INTEGR', 900769530, 8, '2014-09-11', 50, 4, 'S31', 'I', 'F003', 'IMP', 'P011'),
(84, 'D\'LAPEL S.A.', 800242987, 4, '1994-08-30', 85, 1109, 'S26', 'I', 'F003', 'IMP', 'P011'),
(85, 'INCOLPAN S.A.S', 90035082, 5, '2010-12-04', 41, 612, 'S02', 'II', 'F003', 'IMP', 'P019'),
(86, 'MAYORISTA TEAM ', 900968146, 6, '2016-05-04', 13, 176, 'S31', 'II', 'F003', 'IMP', 'P019'),
(87, 'Incentivamos Co', 900536030, 7, '2012-06-29', 76, 152, 'S10', 'I', 'C002', 'IMP', 'P025'),
(88, 'Todescol SAS', 900482216, 6, '2011-11-11', 47, 903, 'S02', 'II', 'F003', 'IMP', 'P019'),
(89, 'DECIMO DOTACION', 900350138, 3, '2010-03-28', 13, 176, 'S29', 'II', 'C002', 'IMP', 'P025'),
(90, 'Diseñar Mobilia', 900705937, 7, '2014-02-25', 11, 110, 'S18', 'II', 'B001', 'IMP', 'P024'),
(91, 'Fuvyam', 900763688, 5, '2020-06-20', 76, 152, 'S05', 'I', 'B001', 'IMP', 'P026'),
(92, 'Sonesta Hotel V', 900277215, 0, '2009-04-08', 76, 765, 'S31', 'I', 'B001', 'IMP', 'P026'),
(93, 'Technomart SAS', 900829885, 5, '2015-03-13', 91, 515, 'S28', 'I', 'B001', 'IMP', 'P028'),
(94, 'GRUPO EMPRESARI', 900271394, 3, '2009-03-09', 11, 110, 'S09', 'I', 'B001', 'IMP', 'P028'),
(95, 'Alimentos Colom', 830067294, 8, '2000-01-22', 11, 110, 'S02', 'III', 'B001', 'IMP', 'P028'),
(96, 'BIOLOGÍA MOLECU', 900006315, 7, '2005-08-05', 73, 434, 'S27', 'I', 'B001', 'IMP', 'P028'),
(97, 'SELETTI SAS', 800238299, 1, '1994-08-09', 54, 266, 'S29', 'III', 'B001', 'IMP', 'P028'),
(98, 'PLASTICOS GHCA ', 901160932, 3, '2018-02-06', 52, 670, 'S26', 'I', 'C002', 'IMP', 'P006'),
(99, 'COOTRANSESPECIA', 900450176, 2, '2011-07-12', 11, 110, 'S30', 'I', 'C002', 'IMP', 'P025'),
(100, 'Fábrica Colombi', 901252731, 5, '2019-02-07', 5, 1, 'S22', 'I', 'F003', 'IMP', 'P004'),
(101, 'TBE MARKETING C', 900792512, 1, '2014-11-20', 11, 110, 'S28', 'II', 'F003', 'IMP', 'P004'),
(102, 'Ecoglobal Exped', 900423429, 6, '2011-03-23', 41, 612, 'S31', 'I', 'F003', 'IMP', 'P019'),
(103, 'Pacóa', 901149975, 5, '2016-02-01', 11, 110, 'S31', 'I', 'B001', 'IMP', 'P024'),
(104, 'Excursiones y T', 2147483647, 1, '2011-02-15', 20, 1063, 'S31', 'I', 'F003', 'IMP', 'P019'),
(105, 'Paramo Trek SAS', 901093369, 9, '2017-06-29', 11, 110, 'S31', 'I', 'F003', 'IMP', 'P011'),
(106, 'Cartagena For T', 901230150, 1, '2018-07-31', 25, 956, 'S30', 'I', 'F003', 'IMP', 'P011'),
(107, 'TRUCHERA EL OAS', 900285446, 9, '2009-05-11', 11, 110, 'S25', 'I', 'F003', 'IMP', 'P004'),
(108, 'Intelectum SAS', 901221605, 2, '2018-09-26', 11, 110, 'S28', 'I', 'F003', 'IMP', 'P019'),
(109, 'RETORNO S.A.S', 900438316, 8, '2011-12-13', 11, 110, 'S31', 'I', 'F003', 'IMP', 'P011'),
(110, 'DE UNA Colombia', 830146707, 7, '2004-08-23', 11, 110, 'S30', 'III', 'F003', 'IMP', 'P011'),
(111, 'TERRITORIO COLO', 900348176, 7, '2010-03-17', 11, 110, 'S31', 'II', 'F003', 'IMP', 'P004'),
(112, 'XPERIENCE TURIS', 900239131, 9, '2008-09-01', 54, 266, 'S31', 'I', 'F003', 'IMP', 'P019'),
(113, 'DISTRIAGROSEEDS', 900387378, 4, '2010-10-10', 5, 561, 'S02', 'I', 'C002', 'IMP', 'P032'),
(114, 'PACIFIC TRAVEL ', 901147480, 2, '2018-01-18', 25, 956, 'S31', 'I', 'C002', 'IMP', 'P032'),
(115, 'Descarga Colomb', 900389221, 7, '2010-10-15', 5, 561, 'S30', 'II', 'C002', 'IMP', 'P006'),
(116, 'MPM Consulting ', 900976685, 8, '2016-06-02', 68, 840, 'S05', 'I', 'C002', 'IMP', 'P032'),
(117, 'Casa Chente SAS', 901103849, 7, '2017-08-04', 11, 110, 'S31', 'I', 'B001', 'IMP', 'P028'),
(118, 'ALACOR SAS', 901198755, 1, '2020-08-01', 66, 681, 'S23', 'I', 'F003', 'IMP', 'P019'),
(119, 'EXYPNOS INGENIE', 901185054, 1, '2020-07-18', 11, 110, 'S18', 'II', 'F003', 'IMP', 'P019'),
(120, 'corporación de ', 800234799, 2, '1997-02-20', 68, 86, 'S31', 'I', 'F003', 'IMP', 'P019'),
(121, 'ANDESCOL S.A.S', 900199473, 1, '2008-02-11', 63, 804, 'S18', 'III', 'F003', 'IMP', 'P010'),
(122, 'DISEÑOS SHARO S', 900448180, 6, '2011-07-02', 13, 176, 'S29', 'II', 'F003', 'IMP', 'P010'),
(123, 'GESTION Y CONTR', 900306635, 6, '2009-08-09', 11, 110, 'S26', 'II', 'F003', 'IMP', 'P010'),
(124, 'Fundación Ramón', 900955446, 4, '2016-02-01', 25, 367, 'S30', 'I', 'F003', 'IMP', 'P004'),
(125, 'AGROPECUARIA CA', 900667801, 0, '2013-10-24', 11, 110, 'S02', 'I', 'F003', 'IMP', 'P019'),
(126, 'CRAVO SUR S.A.S', 2147483647, 0, '2016-11-23', 11, 110, 'S29', 'I', 'J004', 'IMP', 'P015'),
(127, 'Santa Publicida', 900339729, 1, '2010-02-12', 86, 576, 'S10', 'I', 'J004', 'IMP', 'P015'),
(128, 'IDEAS BIOMEDICA', 2147483647, 7, '2008-04-22', 25, 596, 'S27', 'I', 'B001', 'IMP', 'P026'),
(129, 'Ejefincas Colom', 901197344, 2, '2018-07-11', 11, 110, 'S31', 'I', 'B001', 'IMP', 'P024'),
(130, 'SUPER INFLABLES', 900471605, 0, '2011-10-12', 11, 110, 'S09', 'II', 'B001', 'IMP', 'P028'),
(131, 'Hotel Boutique ', 900430732, 2, '2011-04-26', 11, 110, 'S31', 'I', 'C002', 'IMP', 'P021'),
(132, 'DIMOREH S.A.S', 901308365, 5, '2019-07-30', 11, 110, 'S29', 'III', 'C002', 'IMP', 'P006'),
(133, 'C&C Instruments', 900618001, 6, '2013-05-17', 25, 979, 'S19', 'I', 'C002', 'IMP', 'P006'),
(134, 'SHIVA INGENIERI', 900540848, 8, '2020-02-01', 76, 152, 'S18', 'I', 'C002', 'IMP', 'P025'),
(135, 'Reserva Natural', 900582756, 0, '2020-03-25', 11, 110, 'S31', 'I', 'J004', 'IMP', 'P012'),
(136, 'FORTIS DOORS SA', 900696985, 0, '2020-04-30', 25, 255, 'S30', 'III', 'J004', 'IMP', 'P015'),
(137, 'Multiservicios ', 901048372, 0, '2017-01-26', 76, 299, 'S30', 'II', 'J004', 'IMP', 'P005'),
(138, 'Cruz Roja Colom', 800100542, 1, '1997-03-06', 25, 854, 'S32', 'III', 'J004', 'IMP', 'P012'),
(139, 'Industrial Caca', 891100158, 7, '1962-07-17', 25, 596, 'S06', 'III', 'C002', 'IMP', 'P021'),
(140, 'SG INGENIERIA S', 800061779, 1, '1989-03-27', 11, 110, 'S28', 'II', 'C002', 'IMP', 'P021'),
(141, 'Rio Elemento S.', 901131654, 7, '2017-11-10', 8, 723, 'S30', 'I', 'F003', 'IMP', 'P004'),
(142, 'LABORATORIOS RI', 860000757, 7, '1957-03-12', 76, 152, 'S15', 'I', 'F003', 'IMP', 'P019'),
(143, 'Mejia Consultor', 901281150, 1, '2019-05-08', 63, 587, 'S18', 'I', 'F003', 'IMP', 'P004'),
(144, 'Comunicación Ac', 811005344, 3, '1996-04-02', 5, 471, 'S10', 'II', 'F003', 'IMP', 'P019'),
(145, 'Wild About Colo', 901132193, 8, '2017-11-09', 63, 69, 'S31', 'I', 'F003', 'IMP', 'P010'),
(146, 'Solutions in Co', 900936031, 0, '2016-02-09', 11, 110, 'S30', 'I', 'F003', 'IMP', 'P020'),
(147, 'NATURE COLOMBIA', 900906993, 2, '2015-10-15', 25, 533, 'S02', 'II', 'F003', 'IMP', 'P020'),
(148, 'BC COFFEE COMPA', 901203777, 4, '2018-08-08', 13, 176, 'S14', 'I', 'F003', 'IMP', 'P020'),
(149, 'Laboratorio El ', 830062465, 8, '1999-09-23', 76, 152, 'S27', 'III', 'F003', 'IMP', 'P004'),
(150, 'Kaishi Travel o', 825003171, 8, '2003-06-10', 85, 1109, 'S31', 'I', 'F003', 'IMP', 'P019'),
(151, 'Monster Transpo', 900428134, 1, '0000-00-00', 85, 1109, 'S30', 'I', 'F003', 'IMP', 'P019'),
(152, 'Ecodestinos', 838000215, 7, '2001-01-06', 20, 475, 'S31', 'I', 'F003', 'IMP', 'P004'),
(153, 'Classic Jeans S', 900675626, 1, '0000-00-00', 85, 1109, 'S30', 'III', 'F003', 'IMP', 'P020'),
(154, 'Alimentos Tosta', 900914403, 2, '0000-00-00', 85, 1109, 'S02', 'II', 'F003', 'IMP', 'P020'),
(155, 'COSMETICOS BELI', 900848725, 6, '0000-00-00', 11, 110, 'S30', 'II', 'F003', 'IMP', 'P011'),
(156, 'MANUFACTURAS FE', 900317478, 3, '0000-00-00', 5, 561, 'S30', 'II', 'F003', 'IMP', 'P010'),
(157, 'Nirvana Medelli', 900222323, 1, '2008-04-06', 8, 92, 'S32', 'II', 'F003', 'IMP', 'P010'),
(158, 'Monte Gracia We', 2147483647, 5, '2017-06-29', 17, 780, 'S32', 'I', 'F003', 'IMP', 'P020'),
(159, 'Serviprocesos d', 901034315, 1, '0000-00-00', 25, 480, 'S30', 'I', 'F003', 'IMP', 'P020'),
(160, 'BELTRAN PUCHE S', 901113816, 7, '2017-09-12', 11, 110, 'S30', 'I', 'B001', 'IMP', 'P026'),
(161, 'INNOVACIONES OR', 901194257, 6, '2018-06-05', 73, 434, 'S09', 'I', 'F003', 'IMP', 'P019'),
(162, 'Gise Consultore', 901304690, 6, '2019-07-19', 15, 1006, 'S30', 'I', 'C002', 'IMP', 'P025'),
(163, 'GEFETIC S.A.S', 901044967, 4, '2017-01-20', 20, 1063, 'S30', 'I', 'F003', 'IMP', 'P004'),
(164, 'Interpreting Co', 900562114, 7, '2012-10-08', 8, 92, 'S30', 'II', 'F003', 'IMP', 'P019'),
(165, 'CARE Y ASOCIADO', 826001081, 8, '1998-01-05', 5, 336, 'S09', 'II', 'J004', 'IMP', 'P005'),
(166, 'Alternative Tra', 901007253, 7, '2016-09-08', 11, 110, 'S31', 'II', 'J004', 'IMP', 'P012'),
(167, 'LAMARGROUP SAS', 900617341, 0, '2013-05-15', 68, 120, 'S14', 'I', 'J004', 'IMP', 'P015'),
(168, 'Transmor sas', 844000218, 0, '1996-07-24', 44, 775, 'S30', 'II', 'J004', 'IMP', 'P012'),
(169, 'LLANO TOURS ZOM', 901241688, 9, '2018-12-12', 76, 152, 'S31', 'I', 'C002', 'IMP', 'P021'),
(170, 'FINCA VILLA GAB', 901204228, 7, '2018-08-07', 13, 176, 'S31', 'I', 'F003', 'IMP', 'P004'),
(171, 'MELANGE GOURMET', 830093564, 1, '2001-10-01', 18, 344, 'S02', 'I', 'F003', 'IMP', 'P019'),
(172, 'Industrias Mogo', 900615235, 9, '2013-05-07', 25, 970, 'S29', 'I', 'F003', 'IMP', 'P011'),
(173, 'TecniGasex SAS', 830103442, 6, '1995-08-28', 5, 464, 'S20', 'II', 'F003', 'IMP', 'P011'),
(174, 'SPIFFY SAS', 900517710, 6, '2012-03-29', 5, 444, 'S10', 'II', 'F003', 'IMP', 'P011'),
(175, 'OPERADOR INTEGR', 900769530, 8, '2014-09-11', 50, 4, 'S31', 'I', 'F003', 'IMP', 'P011'),
(176, 'D\'LAPEL S.A.', 800242987, 4, '1994-08-30', 85, 1109, 'S26', 'I', 'F003', 'IMP', 'P011'),
(177, 'INCOLPAN S.A.S', 90035082, 5, '2010-12-04', 41, 612, 'S02', 'II', 'F003', 'IMP', 'P019'),
(178, 'MAYORISTA TEAM ', 900968146, 6, '2016-05-04', 13, 176, 'S31', 'II', 'F003', 'IMP', 'P019'),
(179, 'Incentivamos Co', 900536030, 7, '2012-06-29', 76, 152, 'S10', 'I', 'C002', 'IMP', 'P025'),
(180, 'Todescol SAS', 900482216, 6, '2011-11-11', 47, 903, 'S02', 'II', 'F003', 'IMP', 'P019'),
(181, 'DECIMO DOTACION', 900350138, 3, '2010-03-28', 13, 176, 'S29', 'II', 'C002', 'IMP', 'P025'),
(182, 'Diseñar Mobilia', 900705937, 7, '2014-02-25', 11, 110, 'S18', 'II', 'B001', 'IMP', 'P024'),
(183, 'Fuvyam', 900763688, 5, '2020-06-20', 76, 152, 'S05', 'I', 'B001', 'IMP', 'P026'),
(184, 'Sonesta Hotel V', 900277215, 0, '2009-04-08', 76, 765, 'S31', 'I', 'B001', 'IMP', 'P026');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estudios`
--

CREATE TABLE `estudios` (
  `Id_estudio` varchar(4) NOT NULL,
  `Estudio` varchar(40) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `estudios`
--

INSERT INTO `estudios` (`Id_estudio`, `Estudio`) VALUES
('D', 'Doctorado'),
('E', 'Especialización'),
('M', 'Maestria'),
('TB', 'Título Bachiller'),
('TFT', 'Título de Formación Tecnologica'),
('TP', 'Título Profesional');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `etapas`
--

CREATE TABLE `etapas` (
  `Id_etapa` varchar(4) NOT NULL,
  `Nombre_etapa` varchar(15) DEFAULT NULL,
  `Descripcion_etapa` text DEFAULT NULL,
  `Id_proyecto` varchar(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `etapas`
--

INSERT INTO `etapas` (`Id_etapa`, `Nombre_etapa`, `Descripcion_etapa`, `Id_proyecto`) VALUES
('E001', 'Inscripción', 'En esta etapa las empresas se inscriben', 'IMP'),
('E002', 'Consultoria', 'En esta etapa se prepara la logistica para que las empresas reciban consultoria', 'IMP'),
('E003', 'Formación', 'En esta etapa las empresas se capacitan', 'IMP'),
('E004', 'Seguimiento', 'En esta etapa se hace seguimiento permanente', 'IMP'),
('E005', 'Cierre', 'En esta etapa se realiza cierre e informes del proyecto', 'IMP');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `herramientas`
--

CREATE TABLE `herramientas` (
  `Id_herramienta` varchar(4) NOT NULL,
  `Herramienta` text DEFAULT NULL,
  `Id_eje` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `herramientas`
--

INSERT INTO `herramientas` (`Id_herramienta`, `Herramienta`, `Id_eje`) VALUES
('HB01', 'Control para el adecuado manejo de la pandemia. (Resolución 0666 del 24 de abril de 2020).', 'B001'),
('HB02', 'Protocolos  de bioseguridad COVID 19.', 'B001'),
('HB03', 'Vigilancia, seguimiento y control a trabajadores en aislamiento ó detectados COVID 19', 'B001'),
('HB04', 'Asistencia técnica para la prevención, acción y seguimiento COVID 19', 'B001'),
('HB05', 'Elementos de protección personal COVID 19', 'B001'),
('HC01', 'Transformación Digital', 'C002'),
('HC02', 'Comercio electrónico (E- Commerce)', 'C002'),
('HC03', 'Mejorar Calidad de Producto', 'C002'),
('HC04', 'Distribución y Logística', 'C002'),
('HC05', 'Mejorar Líneas de Producción', 'C002'),
('HC06', 'Trabajo en Casa (Home office)', 'C002'),
('HF01', 'Punto de Equilibrio', 'F003'),
('HF02', 'Gestor de Costos y Gastos', 'F003'),
('HF03', 'Flujo de Caja', 'F003'),
('HF04', 'Scoring Crediticio', 'F003'),
('HF05', 'Rentabilidad Exponencial', 'F003'),
('HJ01', 'Asesoría laboral', 'J004'),
('HJ02', 'Asesoría contractual', 'J004'),
('HJ03', 'Propiedad intelectual', 'J004'),
('HJ04', 'Alianzas y sinergias seguras', 'J004'),
('HJ05', 'Restructuración empresarial ​', 'J004');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `identityuser<string>`
--

CREATE TABLE `identityuser<string>` (
  `Id` varchar(127) NOT NULL,
  `UserName` text DEFAULT NULL,
  `NormalizedUserName` text DEFAULT NULL,
  `Email` text DEFAULT NULL,
  `NormalizedEmail` text DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` text DEFAULT NULL,
  `SecurityStamp` text DEFAULT NULL,
  `ConcurrencyStamp` text DEFAULT NULL,
  `PhoneNumber` text DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` timestamp NULL DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `municipio`
--

CREATE TABLE `municipio` (
  `Código_Municipio` int(11) NOT NULL,
  `Nombre_Municipio` varchar(40) DEFAULT NULL,
  `Código_Departamento` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `municipio`
--

INSERT INTO `municipio` (`Código_Municipio`, `Nombre_Municipio`, `Código_Departamento`) VALUES
(1, 'ABEJORRAL', 5),
(2, 'ABREGO', 54),
(3, 'ABRIAQUI', 5),
(4, 'ACACIAS', 50),
(5, 'ACANDI', 27),
(6, 'ACEVEDO', 41),
(7, 'ACHI', 13),
(8, 'AGRADO', 41),
(9, 'AGUA DE DIOS', 25),
(10, 'AGUACHICA', 20),
(11, 'AGUADA', 68),
(12, 'AGUADAS', 17),
(13, 'AGUAZUL', 85),
(14, 'AGUSTIN CODAZZI', 20),
(15, 'AIPE', 41),
(16, 'ALBAN', 25),
(17, 'ALBAN', 52),
(18, 'ALBANIA', 18),
(19, 'ALBANIA', 44),
(20, 'ALBANIA', 68),
(21, 'ALCALA', 76),
(22, 'ALDANA', 52),
(23, 'ALEJANDRIA', 5),
(24, 'ALGARROBO', 47),
(25, 'ALGECIRAS', 41),
(26, 'ALMAGUER', 19),
(27, 'ALMEIDA', 15),
(28, 'ALPUJARRA', 73),
(29, 'ALTAMIRA', 41),
(30, 'ALTO BAUDO', 27),
(31, 'ALTOS DEL ROSARIO', 13),
(32, 'ALVARADO', 73),
(33, 'AMAGA', 5),
(34, 'AMALFI', 5),
(35, 'AMBALEMA', 73),
(36, 'ANAPOIMA', 25),
(37, 'ANCUYA', 52),
(38, 'ANDALUCIA', 76),
(39, 'ANDES', 5),
(40, 'ANGELOPOLIS', 5),
(41, 'ANGOSTURA', 5),
(42, 'ANOLAIMA', 25),
(43, 'ANORI', 5),
(44, 'ANSERMA', 17),
(45, 'ANSERMANUEVO', 76),
(46, 'ANZA', 5),
(47, 'ANZOATEGUI', 73),
(48, 'APARTADO', 5),
(49, 'APIA', 66),
(50, 'APULO', 25),
(51, 'AQUITANIA', 15),
(52, 'ARACATACA', 47),
(53, 'ARANZAZU', 17),
(54, 'ARATOCA', 68),
(55, 'ARAUCA', 81),
(56, 'ARAUQUITA', 81),
(57, 'ARBELAEZ', 25),
(58, 'ARBOLEDA', 52),
(59, 'ARBOLEDAS', 54),
(60, 'ARBOLETES', 5),
(61, 'ARCABUCO', 15),
(62, 'ARENAL', 13),
(63, 'ARGELIA', 5),
(64, 'ARGELIA', 19),
(65, 'ARGELIA', 76),
(66, 'ARIGUANI', 47),
(67, 'ARJONA', 13),
(68, 'ARMENIA', 5),
(69, 'ARMENIA', 63),
(70, 'ARMERO', 73),
(71, 'ARROYOHONDO', 13),
(72, 'ASTREA', 20),
(73, 'ATACO', 73),
(74, 'ATRATO', 27),
(75, 'AYAPEL', 23),
(76, 'BAGADO', 27),
(77, 'BAHIA SOLANO', 27),
(78, 'BAJO BAUDO', 27),
(79, 'BALBOA', 19),
(80, 'BALBOA', 66),
(81, 'BARANOA', 8),
(82, 'BARAYA', 41),
(83, 'BARBACOAS', 52),
(84, 'BARBOSA', 5),
(85, 'BARBOSA', 68),
(86, 'BARICHARA', 68),
(87, 'BARRANCA DE UPIA', 50),
(88, 'BARRANCABERMEJA', 68),
(89, 'BARRANCAS', 44),
(90, 'BARRANCO DE LOBA', 13),
(91, 'BARRANCO MINAS', 94),
(92, 'BARRANQUILLA', 8),
(93, 'BECERRIL', 20),
(94, 'BELALCAZAR', 17),
(95, 'BELEN', 15),
(96, 'BELEN', 52),
(97, 'BELEN DE LOS ANDAQUIES', 18),
(98, 'BELEN DE UMBRIA', 66),
(99, 'BELLO', 5),
(100, 'BELMIRA', 5),
(101, 'BELTRAN', 25),
(102, 'BERBEO', 15),
(103, 'BETANIA', 5),
(104, 'BETEITIVA', 15),
(105, 'BETULIA', 5),
(106, 'BETULIA', 68),
(107, 'BITUIMA', 25),
(108, 'BOAVITA', 15),
(109, 'BOCHALEMA', 54),
(110, 'BOGOTA, D.C.', 11),
(111, 'BOJACA', 25),
(112, 'BOJAYA', 27),
(113, 'BOLIVAR', 19),
(114, 'BOLIVAR', 68),
(115, 'BOLIVAR', 76),
(116, 'BOSCONIA', 20),
(117, 'BOYACA', 15),
(118, 'BRICEÑO', 5),
(119, 'BRICEÑO', 15),
(120, 'BUCARAMANGA', 68),
(121, 'BUCARASICA', 54),
(122, 'BUENAVENTURA', 76),
(123, 'BUENAVISTA', 15),
(124, 'BUENAVISTA', 23),
(125, 'BUENAVISTA', 63),
(126, 'BUENAVISTA', 70),
(127, 'BUENOS AIRES', 19),
(128, 'BUESACO', 52),
(129, 'BUGALAGRANDE', 76),
(130, 'BURITICA', 5),
(131, 'BUSBANZA', 15),
(132, 'CABRERA', 25),
(133, 'CABRERA', 68),
(134, 'CABUYARO', 50),
(135, 'CACAHUAL', 94),
(136, 'CACERES', 5),
(137, 'CACHIPAY', 25),
(138, 'CACHIRA', 54),
(139, 'CACOTA', 54),
(140, 'CAICEDO', 5),
(141, 'CAICEDONIA', 76),
(142, 'CAIMITO', 70),
(143, 'CAJAMARCA', 73),
(144, 'CAJIBIO', 19),
(145, 'CAJICA', 25),
(146, 'CALAMAR', 13),
(147, 'CALAMAR', 95),
(148, 'CALARCA', 63),
(149, 'CALDAS', 5),
(150, 'CALDAS', 15),
(151, 'CALDONO', 19),
(152, 'CALI', 76),
(153, 'CALIFORNIA', 68),
(154, 'CALIMA', 76),
(155, 'CALOTO', 19),
(156, 'CAMPAMENTO', 5),
(157, 'CAMPO DE LA CRUZ', 8),
(158, 'CAMPOALEGRE', 41),
(159, 'CAMPOHERMOSO', 15),
(160, 'CANALETE', 23),
(161, 'CANDELARIA', 8),
(162, 'CANDELARIA', 76),
(163, 'CANTAGALLO', 13),
(164, 'CAÑASGORDAS', 5),
(165, 'CAPARRAPI', 25),
(166, 'CAPITANEJO', 68),
(167, 'CAQUEZA', 25),
(168, 'CARACOLI', 5),
(169, 'CARAMANTA', 5),
(170, 'CARCASI', 68),
(171, 'CAREPA', 5),
(172, 'CARMEN DE APICALA', 73),
(173, 'CARMEN DE CARUPA', 25),
(174, 'CARMEN DEL DARIEN', 27),
(175, 'CAROLINA', 5),
(176, 'CARTAGENA', 13),
(177, 'CARTAGENA DEL CHAIRA', 18),
(178, 'CARTAGO', 76),
(179, 'CARURU', 97),
(180, 'CASABIANCA', 73),
(181, 'CASTILLA LA NUEVA', 50),
(182, 'CAUCASIA', 5),
(183, 'CEPITA', 68),
(184, 'CERETE', 23),
(185, 'CERINZA', 15),
(186, 'CERRITO', 68),
(187, 'CERRO SAN ANTONIO', 47),
(188, 'CERTEGUI', 27),
(189, 'CHACHAGsI', 52),
(190, 'CHAGUANI', 25),
(191, 'CHALAN', 70),
(192, 'CHAMEZA', 85),
(193, 'CHAPARRAL', 73),
(194, 'CHARALA', 68),
(195, 'CHARTA', 68),
(196, 'CHIA', 25),
(197, 'CHIBOLO', 47),
(198, 'CHIGORODO', 5),
(199, 'CHIMA', 23),
(200, 'CHIMA', 68),
(201, 'CHIMICHAGUA', 20),
(202, 'CHINACOTA', 54),
(203, 'CHINAVITA', 15),
(204, 'CHINCHINA', 17),
(205, 'CHINU', 23),
(206, 'CHIPAQUE', 25),
(207, 'CHIPATA', 68),
(208, 'CHIQUINQUIRA', 15),
(209, 'CHIQUIZA', 15),
(210, 'CHIRIGUANA', 20),
(211, 'CHISCAS', 15),
(212, 'CHITA', 15),
(213, 'CHITAGA', 54),
(214, 'CHITARAQUE', 15),
(215, 'CHIVATA', 15),
(216, 'CHIVOR', 15),
(217, 'CHOACHI', 25),
(218, 'CHOCONTA', 25),
(219, 'CICUCO', 13),
(220, 'CIENAGA', 47),
(221, 'CIENAGA DE ORO', 23),
(222, 'CIENEGA', 15),
(223, 'CIMITARRA', 68),
(224, 'CIRCASIA', 63),
(225, 'CISNEROS', 5),
(226, 'CIUDAD BOLIVAR', 5),
(227, 'CLEMENCIA', 13),
(228, 'COCORNA', 5),
(229, 'COELLO', 73),
(230, 'COGUA', 25),
(231, 'COLOMBIA', 41),
(232, 'COLON', 52),
(233, 'COLON', 86),
(234, 'COLOSO', 70),
(235, 'COMBITA', 15),
(236, 'CONCEPCION', 5),
(237, 'CONCEPCION', 68),
(238, 'CONCORDIA', 5),
(239, 'CONCORDIA', 47),
(240, 'CONDOTO', 27),
(241, 'CONFINES', 68),
(242, 'CONSACA', 52),
(243, 'CONTADERO', 52),
(244, 'CONTRATACION', 68),
(245, 'CONVENCION', 54),
(246, 'COPACABANA', 5),
(247, 'COPER', 15),
(248, 'CORDOBA', 13),
(249, 'CORDOBA', 52),
(250, 'CORDOBA', 63),
(251, 'CORINTO', 19),
(252, 'COROMORO', 68),
(253, 'COROZAL', 70),
(254, 'CORRALES', 15),
(255, 'COTA', 25),
(256, 'COTORRA', 23),
(257, 'COVARACHIA', 15),
(258, 'COVEÑAS', 70),
(259, 'COYAIMA', 73),
(260, 'CRAVO NORTE', 81),
(261, 'CUASPUD', 52),
(262, 'CUBARA', 15),
(263, 'CUBARRAL', 50),
(264, 'CUCAITA', 15),
(265, 'CUCUNUBA', 25),
(266, 'CUCUTA', 54),
(267, 'CUCUTILLA', 54),
(268, 'CUITIVA', 15),
(269, 'CUMARAL', 50),
(270, 'CUMARIBO', 99),
(271, 'CUMBAL', 52),
(272, 'CUMBITARA', 52),
(273, 'CUNDAY', 73),
(274, 'CURILLO', 18),
(275, 'CURITI', 68),
(276, 'CURUMANI', 20),
(277, 'DABEIBA', 5),
(278, 'DAGUA', 76),
(279, 'DIBULLA', 44),
(280, 'DISTRACCION', 44),
(281, 'DOLORES', 73),
(282, 'DON MATIAS', 5),
(283, 'DOSQUEBRADAS', 66),
(284, 'DUITAMA', 15),
(285, 'DURANIA', 54),
(286, 'EBEJICO', 5),
(287, 'EL AGUILA', 76),
(288, 'EL BAGRE', 5),
(289, 'EL BANCO', 47),
(290, 'EL CAIRO', 76),
(291, 'EL CALVARIO', 50),
(292, 'EL CANTON DEL SAN PABLO', 27),
(293, 'EL CARMEN', 54),
(294, 'EL CARMEN DE ATRATO', 27),
(295, 'EL CARMEN DE BOLIVAR', 13),
(296, 'EL CARMEN DE CHUCURI', 68),
(297, 'EL CARMEN DE VIBORAL', 5),
(298, 'EL CASTILLO', 50),
(299, 'EL CERRITO', 76),
(300, 'EL CHARCO', 52),
(301, 'EL COCUY', 15),
(302, 'EL COLEGIO', 25),
(303, 'EL COPEY', 20),
(304, 'EL DONCELLO', 18),
(305, 'EL DORADO', 50),
(306, 'EL DOVIO', 76),
(307, 'EL ENCANTO', 91),
(308, 'EL ESPINO', 15),
(309, 'EL GUACAMAYO', 68),
(310, 'EL GUAMO', 13),
(311, 'EL LITORAL DEL SAN JUAN', 27),
(312, 'EL MOLINO', 44),
(313, 'EL PASO', 20),
(314, 'EL PAUJIL', 18),
(315, 'EL PEÑOL', 52),
(316, 'EL PEÑON', 13),
(317, 'EL PEÑON', 25),
(318, 'EL PEÑON', 68),
(319, 'EL PIÑON', 47),
(320, 'EL PLAYON', 68),
(321, 'EL RETEN', 47),
(322, 'EL RETORNO', 95),
(323, 'EL ROBLE', 70),
(324, 'EL ROSAL', 25),
(325, 'EL ROSARIO', 52),
(326, 'EL SANTUARIO', 5),
(327, 'EL TABLON DE GOMEZ', 52),
(328, 'EL TAMBO', 19),
(329, 'EL TAMBO', 52),
(330, 'EL TARRA', 54),
(331, 'EL ZULIA', 54),
(332, 'ELIAS', 41),
(333, 'ENCINO', 68),
(334, 'ENCISO', 68),
(335, 'ENTRERRIOS', 5),
(336, 'ENVIGADO', 5),
(337, 'ESPINAL', 73),
(338, 'FACATATIVA', 25),
(339, 'FALAN', 73),
(340, 'FILADELFIA', 17),
(341, 'FILANDIA', 63),
(342, 'FIRAVITOBA', 15),
(343, 'FLANDES', 73),
(344, 'FLORENCIA', 18),
(345, 'FLORENCIA', 19),
(346, 'FLORESTA', 15),
(347, 'FLORIAN', 68),
(348, 'FLORIDA', 76),
(349, 'FLORIDABLANCA', 68),
(350, 'FOMEQUE', 25),
(351, 'FONSECA', 44),
(352, 'FORTUL', 81),
(353, 'FOSCA', 25),
(354, 'FRANCISCO PIZARRO', 52),
(355, 'FREDONIA', 5),
(356, 'FRESNO', 73),
(357, 'FRONTINO', 5),
(358, 'FUENTE DE ORO', 50),
(359, 'FUNDACION', 47),
(360, 'FUNES', 52),
(361, 'FUNZA', 25),
(362, 'FUQUENE', 25),
(363, 'FUSAGASUGA', 25),
(364, 'GACHALA', 25),
(365, 'GACHANCIPA', 25),
(366, 'GACHANTIVA', 15),
(367, 'GACHETA', 25),
(368, 'GALAN', 68),
(369, 'GALAPA', 8),
(370, 'GALERAS', 70),
(371, 'GAMA', 25),
(372, 'GAMARRA', 20),
(373, 'GAMBITA', 68),
(374, 'GAMEZA', 15),
(375, 'GARAGOA', 15),
(376, 'GARZON', 41),
(377, 'GENOVA', 63),
(378, 'GIGANTE', 41),
(379, 'GINEBRA', 76),
(380, 'GIRALDO', 5),
(381, 'GIRARDOT', 25),
(382, 'GIRARDOTA', 5),
(383, 'GIRON', 68),
(384, 'GOMEZ PLATA', 5),
(385, 'GONZALEZ', 20),
(386, 'GRAMALOTE', 54),
(387, 'GRANADA', 5),
(388, 'GRANADA', 25),
(389, 'GRANADA', 50),
(390, 'GsEPSA', 68),
(391, 'GsICAN', 15),
(392, 'GUACA', 68),
(393, 'GUACAMAYAS', 15),
(394, 'GUACARI', 76),
(395, 'GUACHENE', 19),
(396, 'GUACHETA', 25),
(397, 'GUACHUCAL', 52),
(398, 'GUADALAJARA DE BUGA', 76),
(399, 'GUADALUPE', 5),
(400, 'GUADALUPE', 41),
(401, 'GUADALUPE', 68),
(402, 'GUADUAS', 25),
(403, 'GUAITARILLA', 52),
(404, 'GUALMATAN', 52),
(405, 'GUAMAL', 47),
(406, 'GUAMAL', 50),
(407, 'GUAMO', 73),
(408, 'GUAPI', 19),
(409, 'GUAPOTA', 68),
(410, 'GUARANDA', 70),
(411, 'GUARNE', 5),
(412, 'GUASCA', 25),
(413, 'GUATAPE', 5),
(414, 'GUATAQUI', 25),
(415, 'GUATAVITA', 25),
(416, 'GUATEQUE', 15),
(417, 'GUATICA', 66),
(418, 'GUAVATA', 68),
(419, 'GUAYABAL DE SIQUIMA', 25),
(420, 'GUAYABETAL', 25),
(421, 'GUAYATA', 15),
(422, 'GUTIERREZ', 25),
(423, 'HACARI', 54),
(424, 'HATILLO DE LOBA', 13),
(425, 'HATO', 68),
(426, 'HATO COROZAL', 85),
(427, 'HATONUEVO', 44),
(428, 'HELICONIA', 5),
(429, 'HERRAN', 54),
(430, 'HERVEO', 73),
(431, 'HISPANIA', 5),
(432, 'HOBO', 41),
(433, 'HONDA', 73),
(434, 'IBAGUE', 73),
(435, 'ICONONZO', 73),
(436, 'ILES', 52),
(437, 'IMUES', 52),
(438, 'INIRIDA', 94),
(439, 'INZA', 19),
(440, 'IPIALES', 52),
(441, 'IQUIRA', 41),
(442, 'ISNOS', 41),
(443, 'ISTMINA', 27),
(444, 'ITAGUI', 5),
(445, 'ITUANGO', 5),
(446, 'IZA', 15),
(447, 'JAMBALO', 19),
(448, 'JAMUNDI', 76),
(449, 'JARDIN', 5),
(450, 'JENESANO', 15),
(451, 'JERICO', 5),
(452, 'JERICO', 15),
(453, 'JERUSALEN', 25),
(454, 'JESUS MARIA', 68),
(455, 'JORDAN', 68),
(456, 'JUAN DE ACOSTA', 8),
(457, 'JUNIN', 25),
(458, 'JURADO', 27),
(459, 'LA APARTADA', 23),
(460, 'LA ARGENTINA', 41),
(461, 'LA BELLEZA', 68),
(462, 'LA CALERA', 25),
(463, 'LA CAPILLA', 15),
(464, 'LA CEJA', 5),
(465, 'LA CELIA', 66),
(466, 'LA CHORRERA', 91),
(467, 'LA CRUZ', 52),
(468, 'LA CUMBRE', 76),
(469, 'LA DORADA', 17),
(470, 'LA ESPERANZA', 54),
(471, 'LA ESTRELLA', 5),
(472, 'LA FLORIDA', 52),
(473, 'LA GLORIA', 20),
(474, 'LA GUADALUPE', 94),
(475, 'LA JAGUA DE IBIRICO', 20),
(476, 'LA JAGUA DEL PILAR', 44),
(477, 'LA LLANADA', 52),
(478, 'LA MACARENA', 50),
(479, 'LA MERCED', 17),
(480, 'LA MESA', 25),
(481, 'LA MONTAÑITA', 18),
(482, 'LA PALMA', 25),
(483, 'LA PAZ', 20),
(484, 'LA PAZ', 68),
(485, 'LA PEDRERA', 91),
(486, 'LA PEÑA', 25),
(487, 'LA PINTADA', 5),
(488, 'LA PLATA', 41),
(489, 'LA PLAYA', 54),
(490, 'LA PRIMAVERA', 99),
(491, 'LA SALINA', 85),
(492, 'LA SIERRA', 19),
(493, 'LA TEBAIDA', 63),
(494, 'LA TOLA', 52),
(495, 'LA UNION', 5),
(496, 'LA UNION', 52),
(497, 'LA UNION', 70),
(498, 'LA UNION', 76),
(499, 'LA UVITA', 15),
(500, 'LA VEGA', 19),
(501, 'LA VEGA', 25),
(502, 'LA VICTORIA', 15),
(503, 'LA VICTORIA', 76),
(504, 'LA VICTORIA', 91),
(505, 'LA VIRGINIA', 66),
(506, 'LABATECA', 54),
(507, 'LABRANZAGRANDE', 15),
(508, 'LANDAZURI', 68),
(509, 'LEBRIJA', 68),
(510, 'LEGUIZAMO', 86),
(511, 'LEIVA', 52),
(512, 'LEJANIAS', 50),
(513, 'LENGUAZAQUE', 25),
(514, 'LERIDA', 73),
(515, 'LETICIA', 91),
(516, 'LIBANO', 73),
(517, 'LIBORINA', 5),
(518, 'LINARES', 52),
(519, 'LLORO', 27),
(520, 'LOPEZ', 19),
(521, 'LORICA', 23),
(522, 'LOS ANDES', 52),
(523, 'LOS CORDOBAS', 23),
(524, 'LOS PALMITOS', 70),
(525, 'LOS PATIOS', 54),
(526, 'LOS SANTOS', 68),
(527, 'LOURDES', 54),
(528, 'LURUACO', 8),
(529, 'MACANAL', 15),
(530, 'MACARAVITA', 68),
(531, 'MACEO', 5),
(532, 'MACHETA', 25),
(533, 'MADRID', 25),
(534, 'MAGANGUE', 13),
(535, 'MAGsI', 52),
(536, 'MAHATES', 13),
(537, 'MAICAO', 44),
(538, 'MAJAGUAL', 70),
(539, 'MALAGA', 68),
(540, 'MALAMBO', 8),
(541, 'MALLAMA', 52),
(542, 'MANATI', 8),
(543, 'MANAURE', 20),
(544, 'MANAURE', 44),
(545, 'MANI', 85),
(546, 'MANIZALES', 17),
(547, 'MANTA', 25),
(548, 'MANZANARES', 17),
(549, 'MAPIRIPAN', 50),
(550, 'MAPIRIPANA', 94),
(551, 'MARGARITA', 13),
(552, 'MARIA LA BAJA', 13),
(553, 'MARINILLA', 5),
(554, 'MARIPI', 15),
(555, 'MARIQUITA', 73),
(556, 'MARMATO', 17),
(557, 'MARQUETALIA', 17),
(558, 'MARSELLA', 66),
(559, 'MARULANDA', 17),
(560, 'MATANZA', 68),
(561, 'MEDELLIN', 5),
(562, 'MEDINA', 25),
(563, 'MEDIO ATRATO', 27),
(564, 'MEDIO BAUDO', 27),
(565, 'MEDIO SAN JUAN', 27),
(566, 'MELGAR', 73),
(567, 'MERCADERES', 19),
(568, 'MESETAS', 50),
(569, 'MILAN', 18),
(570, 'MIRAFLORES', 15),
(571, 'MIRAFLORES', 95),
(572, 'MIRANDA', 19),
(573, 'MIRITI - PARANA', 91),
(574, 'MISTRATO', 66),
(575, 'MITU', 97),
(576, 'MOCOA', 86),
(577, 'MOGOTES', 68),
(578, 'MOLAGAVITA', 68),
(579, 'MOMIL', 23),
(580, 'MOMPOS', 13),
(581, 'MONGUA', 15),
(582, 'MONGUI', 15),
(583, 'MONIQUIRA', 15),
(584, 'MONTEBELLO', 5),
(585, 'MONTECRISTO', 13),
(586, 'MONTELIBANO', 23),
(587, 'MONTENEGRO', 63),
(588, 'MONTERIA', 23),
(589, 'MONTERREY', 85),
(590, 'MOÑITOS', 23),
(591, 'MORALES', 13),
(592, 'MORALES', 19),
(593, 'MORELIA', 18),
(594, 'MORICHAL', 94),
(595, 'MORROA', 70),
(596, 'MOSQUERA', 25),
(597, 'MOSQUERA', 52),
(598, 'MOTAVITA', 15),
(599, 'MURILLO', 73),
(600, 'MURINDO', 5),
(601, 'MUTATA', 5),
(602, 'MUTISCUA', 54),
(603, 'MUZO', 15),
(604, 'NARIÑO', 5),
(605, 'NARIÑO', 25),
(606, 'NARIÑO', 52),
(607, 'NATAGA', 41),
(608, 'NATAGAIMA', 73),
(609, 'NECHI', 5),
(610, 'NECOCLI', 5),
(611, 'NEIRA', 17),
(612, 'NEIVA', 41),
(613, 'NEMOCON', 25),
(614, 'NILO', 25),
(615, 'NIMAIMA', 25),
(616, 'NOBSA', 15),
(617, 'NOCAIMA', 25),
(618, 'NORCASIA', 17),
(619, 'NOROSI', 13),
(620, 'NOVITA', 27),
(621, 'NUEVA GRANADA', 47),
(622, 'NUEVO COLON', 15),
(623, 'NUNCHIA', 85),
(624, 'NUQUI', 27),
(625, 'OBANDO', 76),
(626, 'OCAMONTE', 68),
(627, 'OCAÑA', 54),
(628, 'OIBA', 68),
(629, 'OICATA', 15),
(630, 'OLAYA', 5),
(631, 'OLAYA HERRERA', 52),
(632, 'ONZAGA', 68),
(633, 'OPORAPA', 41),
(634, 'ORITO', 86),
(635, 'OROCUE', 85),
(636, 'ORTEGA', 73),
(637, 'OSPINA', 52),
(638, 'OTANCHE', 15),
(639, 'OVEJAS', 70),
(640, 'PACHAVITA', 15),
(641, 'PACHO', 25),
(642, 'PACOA', 97),
(643, 'PACORA', 17),
(644, 'PADILLA', 19),
(645, 'PAEZ', 15),
(646, 'PAEZ', 19),
(647, 'PAICOL', 41),
(648, 'PAILITAS', 20),
(649, 'PAIME', 25),
(650, 'PAIPA', 15),
(651, 'PAJARITO', 15),
(652, 'PALERMO', 41),
(653, 'PALESTINA', 17),
(654, 'PALESTINA', 41),
(655, 'PALMAR', 68),
(656, 'PALMAR DE VARELA', 8),
(657, 'PALMAS DEL SOCORRO', 68),
(658, 'PALMIRA', 76),
(659, 'PALMITO', 70),
(660, 'PALOCABILDO', 73),
(661, 'PAMPLONA', 54),
(662, 'PAMPLONITA', 54),
(663, 'PANA PANA', 94),
(664, 'PANDI', 25),
(665, 'PANQUEBA', 15),
(666, 'PAPUNAUA', 97),
(667, 'PARAMO', 68),
(668, 'PARATEBUENO', 25),
(669, 'PASCA', 25),
(670, 'PASTO', 52),
(671, 'PATIA', 19),
(672, 'PAUNA', 15),
(673, 'PAYA', 15),
(674, 'PAZ DE ARIPORO', 85),
(675, 'PAZ DE RIO', 15),
(676, 'PEÐOL', 5),
(677, 'PEDRAZA', 47),
(678, 'PELAYA', 20),
(679, 'PENSILVANIA', 17),
(680, 'PEQUE', 5),
(681, 'PEREIRA', 66),
(682, 'PESCA', 15),
(683, 'PIAMONTE', 19),
(684, 'PIEDECUESTA', 68),
(685, 'PIEDRAS', 73),
(686, 'PIENDAMO', 19),
(687, 'PIJAO', 63),
(688, 'PIJIÑO DEL CARMEN', 47),
(689, 'PINCHOTE', 68),
(690, 'PINILLOS', 13),
(691, 'PIOJO', 8),
(692, 'PISBA', 15),
(693, 'PITAL', 41),
(694, 'PITALITO', 41),
(695, 'PIVIJAY', 47),
(696, 'PLANADAS', 73),
(697, 'PLANETA RICA', 23),
(698, 'PLATO', 47),
(699, 'POLICARPA', 52),
(700, 'POLONUEVO', 8),
(701, 'PONEDERA', 8),
(702, 'POPAYAN', 19),
(703, 'PORE', 85),
(704, 'POTOSI', 52),
(705, 'PRADERA', 76),
(706, 'PRADO', 73),
(707, 'PROVIDENCIA', 52),
(708, 'PROVIDENCIA', 88),
(709, 'PUEBLO BELLO', 20),
(710, 'PUEBLO NUEVO', 23),
(711, 'PUEBLO RICO', 66),
(712, 'PUEBLORRICO', 5),
(713, 'PUEBLOVIEJO', 47),
(714, 'PUENTE NACIONAL', 68),
(715, 'PUERRES', 52),
(716, 'PUERTO ALEGRIA', 91),
(717, 'PUERTO ARICA', 91),
(718, 'PUERTO ASIS', 86),
(719, 'PUERTO BERRIO', 5),
(720, 'PUERTO BOYACA', 15),
(721, 'PUERTO CAICEDO', 86),
(722, 'PUERTO CARREÑO', 99),
(723, 'PUERTO COLOMBIA', 8),
(724, 'PUERTO COLOMBIA', 94),
(725, 'PUERTO CONCORDIA', 50),
(726, 'PUERTO ESCONDIDO', 23),
(727, 'PUERTO GAITAN', 50),
(728, 'PUERTO GUZMAN', 86),
(729, 'PUERTO LIBERTADOR', 23),
(730, 'PUERTO LLERAS', 50),
(731, 'PUERTO LOPEZ', 50),
(732, 'PUERTO NARE', 5),
(733, 'PUERTO NARIÑO', 91),
(734, 'PUERTO PARRA', 68),
(735, 'PUERTO RICO', 18),
(736, 'PUERTO RICO', 50),
(737, 'PUERTO RONDON', 81),
(738, 'PUERTO SALGAR', 25),
(739, 'PUERTO SANTANDER', 54),
(740, 'PUERTO SANTANDER', 91),
(741, 'PUERTO TEJADA', 19),
(742, 'PUERTO TRIUNFO', 5),
(743, 'PUERTO WILCHES', 68),
(744, 'PULI', 25),
(745, 'PUPIALES', 52),
(746, 'PURACE', 19),
(747, 'PURIFICACION', 73),
(748, 'PURISIMA', 23),
(749, 'QUEBRADANEGRA', 25),
(750, 'QUETAME', 25),
(751, 'QUIBDO', 27),
(752, 'QUIMBAYA', 63),
(753, 'QUINCHIA', 66),
(754, 'QUIPAMA', 15),
(755, 'QUIPILE', 25),
(756, 'RAGONVALIA', 54),
(757, 'RAMIRIQUI', 15),
(758, 'RAQUIRA', 15),
(759, 'RECETOR', 85),
(760, 'REGIDOR', 13),
(761, 'REMEDIOS', 5),
(762, 'REMOLINO', 47),
(763, 'REPELON', 8),
(764, 'RESTREPO', 50),
(765, 'RESTREPO', 76),
(766, 'RETIRO', 5),
(767, 'RICAURTE', 25),
(768, 'RICAURTE', 52),
(769, 'RIO DE ORO', 20),
(770, 'RIO IRO', 27),
(771, 'RIO QUITO', 27),
(772, 'RIO VIEJO', 13),
(773, 'RIOBLANCO', 73),
(774, 'RIOFRIO', 76),
(775, 'RIOHACHA', 44),
(776, 'RIONEGRO', 5),
(777, 'RIONEGRO', 68),
(778, 'RIOSUCIO', 17),
(779, 'RIOSUCIO', 27),
(780, 'RISARALDA', 17),
(781, 'RIVERA', 41),
(782, 'ROBERTO PAYAN', 52),
(783, 'ROLDANILLO', 76),
(784, 'RONCESVALLES', 73),
(785, 'RONDON', 15),
(786, 'ROSAS', 19),
(787, 'ROVIRA', 73),
(788, 'SABANA DE TORRES', 68),
(789, 'SABANAGRANDE', 8),
(790, 'SABANALARGA', 5),
(791, 'SABANALARGA', 8),
(792, 'SABANALARGA', 85),
(793, 'SABANAS DE SAN ANGEL', 47),
(794, 'SABANETA', 5),
(795, 'SABOYA', 15),
(796, 'SACAMA', 85),
(797, 'SACHICA', 15),
(798, 'SAHAGUN', 23),
(799, 'SALADOBLANCO', 41),
(800, 'SALAMINA', 17),
(801, 'SALAMINA', 47),
(802, 'SALAZAR', 54),
(803, 'SALDAÑA', 73),
(804, 'SALENTO', 63),
(805, 'SALGAR', 5),
(806, 'SAMACA', 15),
(807, 'SAMANA', 17),
(808, 'SAMANIEGO', 52),
(809, 'SAMPUES', 70),
(810, 'SAN AGUSTIN', 41),
(811, 'SAN ALBERTO', 20),
(812, 'SAN ANDRES', 68),
(813, 'SAN ANDRES', 88),
(814, 'SAN ANDRES DE CUERQUIA', 5),
(815, 'SAN ANDRES DE TUMACO', 52),
(816, 'SAN ANDRES SOTAVENTO', 23),
(817, 'SAN ANTERO', 23),
(818, 'SAN ANTONIO', 73),
(819, 'SAN ANTONIO DEL TEQUENDAMA', 25),
(820, 'SAN BENITO', 68),
(821, 'SAN BENITO ABAD', 70),
(822, 'SAN BERNARDO', 25),
(823, 'SAN BERNARDO', 52),
(824, 'SAN BERNARDO DEL VIENTO', 23),
(825, 'SAN CALIXTO', 54),
(826, 'SAN CARLOS', 5),
(827, 'SAN CARLOS', 23),
(828, 'SAN CARLOS DE GUAROA', 50),
(829, 'SAN CAYETANO', 25),
(830, 'SAN CAYETANO', 54),
(831, 'SAN CRISTOBAL', 13),
(832, 'SAN DIEGO', 20),
(833, 'SAN EDUARDO', 15),
(834, 'SAN ESTANISLAO', 13),
(835, 'SAN FELIPE', 94),
(836, 'SAN FERNANDO', 13),
(837, 'SAN FRANCISCO', 5),
(838, 'SAN FRANCISCO', 25),
(839, 'SAN FRANCISCO', 86),
(840, 'SAN GIL', 68),
(841, 'SAN JACINTO', 13),
(842, 'SAN JACINTO DEL CAUCA', 13),
(843, 'SAN JERONIMO', 5),
(844, 'SAN JOAQUIN', 68),
(845, 'SAN JOSE', 17),
(846, 'SAN JOSE DE LA MONTAÑA', 5),
(847, 'SAN JOSE DE MIRANDA', 68),
(848, 'SAN JOSE DE PARE', 15),
(849, 'SAN JOSE DEL FRAGUA', 18),
(850, 'SAN JOSE DEL GUAVIARE', 95),
(851, 'SAN JOSE DEL PALMAR', 27),
(852, 'SAN JUAN DE ARAMA', 50),
(853, 'SAN JUAN DE BETULIA', 70),
(854, 'SAN JUAN DE RIO SECO', 25),
(855, 'SAN JUAN DE URABA', 5),
(856, 'SAN JUAN DEL CESAR', 44),
(857, 'SAN JUAN NEPOMUCENO', 13),
(858, 'SAN JUANITO', 50),
(859, 'SAN LORENZO', 52),
(860, 'SAN LUIS', 5),
(861, 'SAN LUIS', 73),
(862, 'SAN LUIS DE GACENO', 15),
(863, 'SAN LUIS DE PALENQUE', 85),
(864, 'SAN LUIS DE SINCE', 70),
(865, 'SAN MARCOS', 70),
(866, 'SAN MARTIN', 20),
(867, 'SAN MARTIN', 50),
(868, 'SAN MARTIN DE LOBA', 13),
(869, 'SAN MATEO', 15),
(870, 'SAN MIGUEL', 68),
(871, 'SAN MIGUEL', 86),
(872, 'SAN MIGUEL DE SEMA', 15),
(873, 'SAN ONOFRE', 70),
(874, 'SAN PABLO', 13),
(875, 'SAN PABLO', 52),
(876, 'SAN PABLO DE BORBUR', 15),
(877, 'SAN PEDRO', 5),
(878, 'SAN PEDRO', 70),
(879, 'SAN PEDRO', 76),
(880, 'SAN PEDRO DE CARTAGO', 52),
(881, 'SAN PEDRO DE URABA', 5),
(882, 'SAN PELAYO', 23),
(883, 'SAN RAFAEL', 5),
(884, 'SAN ROQUE', 5),
(885, 'SAN SEBASTIAN', 19),
(886, 'SAN SEBASTIAN DE BUENAVISTA', 47),
(887, 'SAN VICENTE', 5),
(888, 'SAN VICENTE DE CHUCURI', 68),
(889, 'SAN VICENTE DEL CAGUAN', 18),
(890, 'SAN ZENON', 47),
(891, 'SANDONA', 52),
(892, 'SANTA ANA', 47),
(893, 'SANTA BARBARA', 5),
(894, 'SANTA BARBARA', 52),
(895, 'SANTA BARBARA', 68),
(896, 'SANTA BARBARA DE PINTO', 47),
(897, 'SANTA CATALINA', 13),
(898, 'SANTA HELENA DEL OPON', 68),
(899, 'SANTA ISABEL', 73),
(900, 'SANTA LUCIA', 8),
(901, 'SANTA MARIA', 15),
(902, 'SANTA MARIA', 41),
(903, 'SANTA MARTA', 47),
(904, 'SANTA ROSA', 13),
(905, 'SANTA ROSA', 19),
(906, 'SANTA ROSA DE CABAL', 66),
(907, 'SANTA ROSA DE OSOS', 5),
(908, 'SANTA ROSA DE VITERBO', 15),
(909, 'SANTA ROSA DEL SUR', 13),
(910, 'SANTA ROSALIA', 99),
(911, 'SANTA SOFIA', 15),
(912, 'SANTACRUZ', 52),
(913, 'SANTAFE DE ANTIOQUIA', 5),
(914, 'SANTANA', 15),
(915, 'SANTANDER DE QUILICHAO', 19),
(916, 'SANTIAGO', 54),
(917, 'SANTIAGO', 86),
(918, 'SANTIAGO DE TOLU', 70),
(919, 'SANTO DOMINGO', 5),
(920, 'SANTO TOMAS', 8),
(921, 'SANTUARIO', 66),
(922, 'SAPUYES', 52),
(923, 'SARAVENA', 81),
(924, 'SARDINATA', 54),
(925, 'SASAIMA', 25),
(926, 'SATIVANORTE', 15),
(927, 'SATIVASUR', 15),
(928, 'SEGOVIA', 5),
(929, 'SESQUILE', 25),
(930, 'SEVILLA', 76),
(931, 'SIACHOQUE', 15),
(932, 'SIBATE', 25),
(933, 'SIBUNDOY', 86),
(934, 'SILOS', 54),
(935, 'SILVANIA', 25),
(936, 'SILVIA', 19),
(937, 'SIMACOTA', 68),
(938, 'SIMIJACA', 25),
(939, 'SIMITI', 13),
(940, 'SINCELEJO', 70),
(941, 'SIPI', 27),
(942, 'SITIONUEVO', 47),
(943, 'SOACHA', 25),
(944, 'SOATA', 15),
(945, 'SOCHA', 15),
(946, 'SOCORRO', 68),
(947, 'SOCOTA', 15),
(948, 'SOGAMOSO', 15),
(949, 'SOLANO', 18),
(950, 'SOLEDAD', 8),
(951, 'SOLITA', 18),
(952, 'SOMONDOCO', 15),
(953, 'SONSON', 5),
(954, 'SOPETRAN', 5),
(955, 'SOPLAVIENTO', 13),
(956, 'SOPO', 25),
(957, 'SORA', 15),
(958, 'SORACA', 15),
(959, 'SOTAQUIRA', 15),
(960, 'SOTARA', 19),
(961, 'SUAITA', 68),
(962, 'SUAN', 8),
(963, 'SUAREZ', 19),
(964, 'SUAREZ', 73),
(965, 'SUAZA', 41),
(966, 'SUBACHOQUE', 25),
(967, 'SUCRE', 19),
(968, 'SUCRE', 68),
(969, 'SUCRE', 70),
(970, 'SUESCA', 25),
(971, 'SUPATA', 25),
(972, 'SUPIA', 17),
(973, 'SURATA', 68),
(974, 'SUSA', 25),
(975, 'SUSACON', 15),
(976, 'SUTAMARCHAN', 15),
(977, 'SUTATAUSA', 25),
(978, 'SUTATENZA', 15),
(979, 'TABIO', 25),
(980, 'TADO', 27),
(981, 'TALAIGUA NUEVO', 13),
(982, 'TAMALAMEQUE', 20),
(983, 'TAMARA', 85),
(984, 'TAME', 81),
(985, 'TAMESIS', 5),
(986, 'TAMINANGO', 52),
(987, 'TANGUA', 52),
(988, 'TARAIRA', 97),
(989, 'TARAPACA', 91),
(990, 'TARAZA', 5),
(991, 'TARQUI', 41),
(992, 'TARSO', 5),
(993, 'TASCO', 15),
(994, 'TAURAMENA', 85),
(995, 'TAUSA', 25),
(996, 'TELLO', 41),
(997, 'TENA', 25),
(998, 'TENERIFE', 47),
(999, 'TENJO', 25),
(1000, 'TENZA', 15),
(1001, 'TEORAMA', 54),
(1002, 'TERUEL', 41),
(1003, 'TESALIA', 41),
(1004, 'TIBACUY', 25),
(1005, 'TIBANA', 15),
(1006, 'TIBASOSA', 15),
(1007, 'TIBIRITA', 25),
(1008, 'TIBU', 54),
(1009, 'TIERRALTA', 23),
(1010, 'TIMANA', 41),
(1011, 'TIMBIO', 19),
(1012, 'TIMBIQUI', 19),
(1013, 'TINJACA', 15),
(1014, 'TIPACOQUE', 15),
(1015, 'TIQUISIO', 13),
(1016, 'TITIRIBI', 5),
(1017, 'TOCA', 15),
(1018, 'TOCAIMA', 25),
(1019, 'TOCANCIPA', 25),
(1020, 'TOGsI', 15),
(1021, 'TOLEDO', 5),
(1022, 'TOLEDO', 54),
(1023, 'TOLU VIEJO', 70),
(1024, 'TONA', 68),
(1025, 'TOPAGA', 15),
(1026, 'TOPAIPI', 25),
(1027, 'TORIBIO', 19),
(1028, 'TORO', 76),
(1029, 'TOTA', 15),
(1030, 'TOTORO', 19),
(1031, 'TRINIDAD', 85),
(1032, 'TRUJILLO', 76),
(1033, 'TUBARA', 8),
(1034, 'TULUA', 76),
(1035, 'TUNJA', 15),
(1036, 'TUNUNGUA', 15),
(1037, 'TUQUERRES', 52),
(1038, 'TURBACO', 13),
(1039, 'TURBANA', 13),
(1040, 'TURBO', 5),
(1041, 'TURMEQUE', 15),
(1042, 'TUTA', 15),
(1043, 'TUTAZA', 15),
(1044, 'UBALA', 25),
(1045, 'UBAQUE', 25),
(1046, 'ULLOA', 76),
(1047, 'UMBITA', 15),
(1048, 'UNE', 25),
(1049, 'UNGUIA', 27),
(1050, 'UNION PANAMERICANA', 27),
(1051, 'URAMITA', 5),
(1052, 'URIBE', 50),
(1053, 'URIBIA', 44),
(1054, 'URRAO', 5),
(1055, 'URUMITA', 44),
(1056, 'USIACURI', 8),
(1057, 'UTICA', 25),
(1058, 'VALDIVIA', 5),
(1059, 'VALENCIA', 23),
(1060, 'VALLE DE SAN JOSE', 68),
(1061, 'VALLE DE SAN JUAN', 73),
(1062, 'VALLE DEL GUAMUEZ', 86),
(1063, 'VALLEDUPAR', 20),
(1064, 'VALPARAISO', 5),
(1065, 'VALPARAISO', 18),
(1066, 'VEGACHI', 5),
(1067, 'VELEZ', 68),
(1068, 'VENADILLO', 73),
(1069, 'VENECIA', 5),
(1070, 'VENECIA', 25),
(1071, 'VENTAQUEMADA', 15),
(1072, 'VERGARA', 25),
(1073, 'VERSALLES', 76),
(1074, 'VETAS', 68),
(1075, 'VIANI', 25),
(1076, 'VICTORIA', 17),
(1077, 'VIGIA DEL FUERTE', 5),
(1078, 'VIJES', 76),
(1079, 'VILLA CARO', 54),
(1080, 'VILLA DE LEYVA', 15),
(1081, 'VILLA DE SAN DIEGO DE UBATE', 25),
(1082, 'VILLA DEL ROSARIO', 54),
(1083, 'VILLA RICA', 19),
(1084, 'VILLAGARZON', 86),
(1085, 'VILLAGOMEZ', 25),
(1086, 'VILLAHERMOSA', 73),
(1087, 'VILLAMARIA', 17),
(1088, 'VILLANUEVA', 13),
(1089, 'VILLANUEVA', 44),
(1090, 'VILLANUEVA', 68),
(1091, 'VILLANUEVA', 85),
(1092, 'VILLAPINZON', 25),
(1093, 'VILLARRICA', 73),
(1094, 'VILLAVICENCIO', 50),
(1095, 'VILLAVIEJA', 41),
(1096, 'VILLETA', 25),
(1097, 'VIOTA', 25),
(1098, 'VIRACACHA', 15),
(1099, 'VISTAHERMOSA', 50),
(1100, 'VITERBO', 17),
(1101, 'YACOPI', 25),
(1102, 'YACUANQUER', 52),
(1103, 'YAGUARA', 41),
(1104, 'YALI', 5),
(1105, 'YARUMAL', 5),
(1106, 'YAVARATE', 97),
(1107, 'YOLOMBO', 5),
(1108, 'YONDO', 5),
(1109, 'YOPAL', 85),
(1110, 'YOTOCO', 76),
(1111, 'YUMBO', 76),
(1112, 'ZAMBRANO', 13),
(1113, 'ZAPATOCA', 68),
(1114, 'ZAPAYAN', 47),
(1115, 'ZARAGOZA', 5),
(1116, 'ZARZAL', 76),
(1117, 'ZETAQUIRA', 15),
(1118, 'ZIPACON', 25),
(1119, 'ZIPAQUIRA', 25),
(1120, 'ZONA BANANERA', 47);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `profesional`
--

CREATE TABLE `profesional` (
  `Id_profesional` varchar(4) NOT NULL,
  `Nombres` varchar(40) DEFAULT NULL,
  `Apellidos` varchar(40) DEFAULT NULL,
  `Id_Tipo_Documento` int(11) NOT NULL,
  `No_documento` int(11) NOT NULL,
  `Correo` varchar(40) DEFAULT NULL,
  `Telefono` varchar(10) DEFAULT NULL,
  `Id_Profesion` varchar(4) NOT NULL,
  `Id_estudio` varchar(4) NOT NULL,
  `Id_cargo` varchar(2) NOT NULL,
  `Id_proyecto` varchar(6) NOT NULL,
  `Id_eje` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `profesional`
--

INSERT INTO `profesional` (`Id_profesional`, `Nombres`, `Apellidos`, `Id_Tipo_Documento`, `No_documento`, `Correo`, `Telefono`, `Id_Profesion`, `Id_estudio`, `Id_cargo`, `Id_proyecto`, `Id_eje`) VALUES
('P001', 'Holguer', 'Rangel Gonzales', 1, 1234567, 'hragelg@hotmail.com', '3213456789', 'I4', 'E', 'DP', 'IMP', '0000'),
('P002', 'Angela', 'Robledo Sanchez', 1, 9876541, 'angela_robledo@gmail.com', '3102581478', 'E1', 'E', 'CA', 'IMP', '0000'),
('P003', 'Lisset', 'Gomez Castaño', 1, 1022345612, 'proyctosinnova1@outlook.com', '3209875421', 'M2', 'TP', 'CP', 'IMP', '0000'),
('P004', 'Hector Ramon', 'Borrego Garcia', 1, 19395521, 'catalinares@gmail.com', '3042123001', 'A1', 'M', 'C', 'IMP', 'F003'),
('P005', 'Felix', 'Lievano Ortiz', 1, 29876866, 'cristina.cgil10@gmail.com', '3103188550', 'A1', 'M', 'C', 'IMP', 'J004'),
('P006', 'Angela María', 'Mendoza Ledezma', 1, 88159931, 'lamartinr@hotmail.com', '3173823401', 'A1', 'M', 'C', 'IMP', 'C002'),
('P007', 'Johanna', 'Alvarez Beltran', 1, 98399223, 'luzyarimamelendez@gmail.com', '3192997054', 'A1', 'E', 'C', 'IMP', 'B001'),
('P008', 'Veronica', 'Ordoñez Velasco', 1, 1013588408, 'mailfabianosorio@gmail.com', '3203027398', 'A1', 'E', 'C', 'IMP', 'B001'),
('P009', 'Natalia Andrea', 'Cardona Mazo', 1, 42897545, 'gcascar@gmail.com', '3134653037', 'B1', 'M', 'C', 'IMP', 'B001'),
('P010', 'Jhon Jairo', 'Peña Olarte', 1, 19151981, 'borregoasociados@gmail.com', '3013445137', 'C1', 'M', 'C', 'IMP', 'F003'),
('P011', 'Mónica', 'Hernández Piedrahita', 1, 43725134, 'gerente@bside.com.co', '3138929562', 'C1', 'E', 'C', 'IMP', 'F003'),
('P012', 'Jorge David', 'Bedoya Goyes', 1, 14883735, 'auraruiz34@gmail.com', '3008430015', 'D1', 'M', 'C', 'IMP', 'J004'),
('P013', 'Gerson Ariel', 'Castañeda Barrera', 1, 24334445, 'claudinasalazar@yahoo.com', '3057121007', 'D1', 'E', 'C', 'IMP', 'J004'),
('P014', 'Carlos Javier', 'Alzate Trujillo', 1, 31579172, 'dbedoya@bedoyagoyes.com', '3103300905', 'D1', 'M', 'C', 'IMP', 'J004'),
('P015', 'CAMILA ALEJANDRA', 'RAMIREZ ESPINEL', 1, 32888240, 'deyssy_90@hotmail.com', '3103302360', 'D1', 'E', 'C', 'IMP', 'J004'),
('P016', 'Argemiro', 'Carrillo Blanco', 1, 80196336, 'juanitamahecha@gmail.com', '3168687179', 'D1', 'E', 'C', 'IMP', 'J004'),
('P017', 'ALISSON MARIA CARLA', 'AGUIAR LEMOS', 1, 88251040, 'lievanofelix@gmail.com', '3174035398', 'D1', 'E', 'C', 'IMP', 'J004'),
('P018', 'Libia Alexandra', 'López Cepeda', 1, 63467337, 'javierayalatec@gmail.com', '3155843734', 'D2', 'E', 'C', 'IMP', 'B001'),
('P019', 'Juanita', 'Mahecha Pardo', 1, 14136199, 'amendozaledezma@gmail.com', '3007924700', 'E1', 'M', 'C', 'IMP', 'F003'),
('P020', 'OSCAR', 'GUERRERO FRANCO', 1, 42793482, 'fdelgado954@gmail.com', '3117334620', 'E1', 'M', 'C', 'IMP', 'F003'),
('P021', 'Luz Yarima', 'Meléndez Martínez', 1, 52221023, 'jaimedeleon1103@gmail.com', '3153201192', 'E1', 'M', 'C', 'IMP', 'C002'),
('P022', 'Germán', 'Castaño Cárdenas', 1, 79672087, 'jhonjpena@hotmail.com', '3163267871', 'E1', 'M', 'C', 'IMP', 'C002'),
('P023', 'Fabian', 'Osorio Mosquera', 1, 80087778, 'jorise10@hotmail.com', '3165424146', 'E1', 'M', 'C', 'IMP', 'C002'),
('P024', 'MANUEL GERARDO', 'ORJUELA GUAUQE', 1, 46385391, 'ignacio_herrera@yahoo.com', '3147377777', 'I1', 'E', 'C', 'IMP', 'B001'),
('P025', 'Jorge Enrique', 'Hernandez', 1, 79521725, 'jesusbalaguera@gmail.com', '3158491785', 'I2', 'M', 'C', 'IMP', 'C002'),
('P026', 'Adriana Patricia', 'Rodriguez Moreno', 1, 36276021, 'directorjuridico@carrilloalegal.com', '3107822872', 'I3', 'E', 'C', 'IMP', 'B001'),
('P027', 'MÓNICA MARÍA', 'RESTREPO QUICENO', 1, 43629944, 'gcastaneda@bedoyagoyes.com', '3137910328', 'I3', 'E', 'C', 'IMP', 'C002'),
('P028', 'LuzAngela', 'Mejia Sacipa', 1, 46674027, 'ing.luisgenes@gmail.com', '3153002902', 'I3', 'E', 'C', 'IMP', 'B001'),
('P029', 'Deicy', 'Sequea Herazo', 1, 94403956, 'luzangelamejiasacipa@gmail.com', '3192271594', 'I3', 'TP', 'C', 'IMP', 'B001'),
('P030', 'Luis Alberto', 'Martin', 1, 1015399482, 'manuelorjuela@hotmail.com', '3203531659', 'I3', 'TP', 'C', 'IMP', 'B001'),
('P031', 'NATALIA DEL PILAR', 'RIVERA CARDOZO', 1, 4585468, 'aaguiar@bedoyagoyes.com', '3002625389', 'I4', 'E', 'C', 'IMP', 'B001'),
('P032', 'Marco Tulio', 'Castaño Mejia', 1, 8028747, 'abogado406@gmail.com', '3004932183', 'I4', 'E', 'C', 'IMP', 'C002'),
('P033', 'Luis Alberto', 'Pérez Bonfante', 1, 8710036, 'adrianitarodri@gmail.com', '3007837626', 'I4', 'D', 'C', 'IMP', 'C002'),
('P034', 'YAMILET', 'PENA', 1, 40440706, 'disealexa@gmail.com', '3115612232', 'I4', 'M', 'C', 'IMP', 'C002'),
('P035', 'Fernando', 'Delgado Arias', 1, 79758085, 'jorgepintoco@hotmail.com', '3165295278', 'I4', 'E', 'C', 'IMP', 'B001'),
('P036', 'Claudia', 'Salazar Hernandez', 1, 91256204, 'luisbonfante.74@gmail.com', '3184879660', 'I4', 'TP', 'C', 'IMP', 'B001'),
('P037', 'Javier', 'Ayala', 1, 19166505, 'camila@cabreraeslegal.com', '3014900854', 'I5', 'M', 'C', 'IMP', 'C002'),
('P038', 'Jorge Enrique', 'Rojas Tarazona', 1, 79340356, 'jenriquerojas@hotmail.com', '3156952121', 'I5', 'E', 'C', 'IMP', 'C002'),
('P039', 'Cristina', 'Gil Rodríguez', 1, 29877655, 'das8028@gmail.com', '3103242484', 'M1', 'E', 'C', 'IMP', 'B001'),
('P040', 'Aura Luz', 'Ruiz Marin', 1, 34319078, 'diegoomarpaz@gmail.com', '3104490334', 'Q1', 'M', 'C', 'IMP', 'B001');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `profesiones`
--

CREATE TABLE `profesiones` (
  `Id_Profesion` varchar(4) NOT NULL,
  `Profesion` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `profesiones`
--

INSERT INTO `profesiones` (`Id_Profesion`, `Profesion`) VALUES
('A1', 'Administración de empresas'),
('B1', 'Bacteriología'),
('C1', 'Contaduría Pública'),
('D1', 'Derecho'),
('D2', 'Diseño Industrial'),
('E1', 'Economía'),
('I1', 'Ingeniería Agroindustrial'),
('I2', 'Ingeniería Ambiental'),
('I3', 'Ingeniería de Alimentos'),
('I4', 'Ingeniería Industrial'),
('I5', 'Ingeniería Mecánica'),
('M1', 'Microbiología'),
('M2', 'Mercadeo'),
('Q1', 'Química Farmacéutica');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proyecto`
--

CREATE TABLE `proyecto` (
  `Id_proyecto` varchar(6) NOT NULL,
  `Nombre_proyecto` varchar(15) DEFAULT NULL,
  `No_Convenio` varchar(10) DEFAULT NULL,
  `Objeto` text DEFAULT NULL,
  `Fecha_inicio` date DEFAULT NULL,
  `Plazo_Ejecucion` int(11) DEFAULT NULL,
  `Presupuesto` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `proyecto`
--

INSERT INTO `proyecto` (`Id_proyecto`, `Nombre_proyecto`, `No_Convenio`, `Objeto`, `Fecha_inicio`, `Plazo_Ejecucion`, `Presupuesto`) VALUES
('IMP', 'Imparables', '019-2020', 'Prestar asesoria a 480 empresas del pais en 4 ejes: Bioseguridad, Financiero, Continuidad de negocio y Juridico que ayude a la reactivacion empresarial en medio de la pandemia generada por el covid-19', '2020-06-09', 10, 1380000000);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `representante_legal`
--

CREATE TABLE `representante_legal` (
  `Id_repr_legal` varchar(6) NOT NULL,
  `Nombres_Representante_Legal` varchar(40) DEFAULT NULL,
  `Apellidos_Representante_Legal` varchar(40) DEFAULT NULL,
  `Id_Tipo_Documento` int(11) NOT NULL,
  `No_documento` int(11) NOT NULL,
  `Correo` varchar(40) DEFAULT NULL,
  `Telefono` varchar(10) DEFAULT NULL,
  `Id_empresa` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `representante_legal`
--

INSERT INTO `representante_legal` (`Id_repr_legal`, `Nombres_Representante_Legal`, `Apellidos_Representante_Legal`, `Id_Tipo_Documento`, `No_documento`, `Correo`, `Telefono`, `Id_empresa`) VALUES
('RP001', 'Gerardo', 'Aguilar Saavedra', 1, 79393373, 'gerardo.aguilar@technomart.com.co', '3162322612', 1),
('RP002', 'YERLY ANDREA', 'SALAZAR VEGA', 1, 1082215054, 'gerencia@liangroup.com.co', '3123376532', 2),
('RP003', 'Lucas', 'Rozo', 1, 79781257, 'juanmanuel@alimentoscolomer.com', '3105722246', 3),
('RP004', 'EMERSON', 'LOZANO GARCIA', 1, 80242480, 'gerencia@bioquigen.com', '3188268301', 4),
('RP005', 'CARLOS ALBERTO', 'SIABATTO AVILA', 1, 79486913, 'siabatto@seletti.net', '3002144030', 5),
('RP006', 'JHOAN SEBASTIAN', 'SIERRA BUITRAGO', 1, 1016079237, 'PLASTICOSGHCA@GMAIL.COM', '3022348666', 6),
('RP007', 'CARMEN PATRICIA', 'REYES LIZARAZO', 1, 37505118, 'cootransespeciales@hotmail.com', '3143033430', 7),
('RP008', 'Óscar Alberto', 'Urribarri Urdaneta', 1, 1017265530, 'gerencia@facolac.com', '3217130234', 8),
('RP009', 'ESTEBAN', 'VALLEJO BOCANUMEN', 1, 71781338, 'evb@tbemarketingcolombia.com', '3003798741', 9),
('RP010', 'Juan Fernando', 'Calle Pelaez', 1, 70568048, 'callepj@yahoo.com', '3108233974', 10),
('RP011', 'Natalia', 'Montoya Aguirre', 1, 42162402, 'Info@pacoatravel.co', '3153861768', 11),
('RP012', 'Carlos Alfonso', 'Hernández Aldana', 1, 79266053, 'exytures@hotmail.com', '3102048968', 12),
('RP013', 'Isabel Cristina', 'Giraldo Valencia', 1, 32144372, 'paramotrek@gmail.com', '3117453761', 13),
('RP014', 'Gilberto', 'Leon Perez', 1, 73207162, 'cartagenafortravelers@gmail.com', '3006777636', 14),
('RP015', 'MARCELA', 'BAHAMON DE TORRES', 1, 51587306, 'TRUCHERAELOASIS@HOTMAIL.COM', '3204184861', 15),
('RP016', 'Gabriel Eduardo', 'Lamus Suarez', 1, 79297562, 'administracion@viaggio.com.co', '3118768325', 16),
('RP017', 'Carlos Alfonso', 'Avellaneda Varlcarcel', 1, 79483109, 'retorno@caminantesdelretorno.com', '3102466716', 17),
('RP018', 'Erik', 'Rupert', 1, 325274, 'erik@deunacolombia.com', '3123510753', 18),
('RP019', 'KAREM HELENA', 'RUIZ REYES', 1, 52209633, 'gerencia@territoriocolombia.com', '3103235897', 19),
('RP020', 'SARA CONSUELO', 'MENDOZA GAONA', 1, 51693894, 'gerencia@xperience.com.co', '3138836745', 20),
('RP021', 'CARLOS AUGUSTO', 'BOHÓRQUEZ BUITRAGO', 1, 79382215, 'DISTRIAGROSEEDS@GMAIL.COM', '3132835213', 21),
('RP022', 'MAURICIO MIGUEL', 'NOVOA GARCIA', 1, 79285848, 'gerencia@pacifictravel.co', '3117649690', 22),
('RP023', 'Andrea Margarita', 'Ariza Jauregui', 1, 52692646, 'andrea.martinez@descargazf.com', '3173793256', 23),
('RP024', 'William', 'Conde Betancourth', 1, 1667716, 'gerencia@mpmconsulting.com.co', '3174274082', 24),
('RP025', 'Nubia Elsy', 'Martinez Castañeda', 1, 20902986, 'casachente@hotmail.com', '3016449795', 25),
('RP026', 'YULI CAROLINA', 'CORREDOR FORERO', 1, 52919128, 'carolina.corredor@alacor.com.co', '3502608925', 26),
('RP027', 'ANA MILENA', 'GARCIA ZAMBRANO', 1, 28272702, 'exypnos.ingenieria@gmail.com', '321.323.44', 27),
('RP028', 'Gustavo Adolfo', 'Vivas Forero', 1, 16639331, 'tesoreria@cdpcali.com', '3197543760', 28),
('RP029', 'Daniel', 'Giraldo Maya', 1, 71386888, 'info@andescol.com', '3183678409', 29),
('RP030', 'LUIS FERNANDO', 'PATIÑO MAYA', 1, 16768934, 'gerencia@sharo.com.co', '3164049147', 30),
('RP031', 'LUIS ARMANDO', 'LOZANO BLANCO', 1, 4099147, 'gerencia@geincor.com.co', '3203036411', 31),
('RP032', 'Fredy', 'Farfán Gordillo', 1, 74770309, 'ffarfang@ftrnp.edu.co', '3102576488', 32),
('RP033', 'JORGE ENRIQUE', 'RESTREPO DIAZ', 1, 1082913516, 'agropecuariacarssas2016@gmail.com', '3116523469', 33),
('RP034', 'JOSE MARCELINO', 'BERNAL DIAZ', 1, 9656832, 'cravosur.sas@gmail.com', '3124827193', 34),
('RP035', 'Andrés Gregorio', 'Ruiz Reyes', 1, 1020713550, 'gruiz@santapublicidad.com', '3114776199', 35),
('RP036', 'CAROLINA', 'JARAMILLO TOBÓN', 1, 32242065, 'cjaramillo@ideasbiomedicas.com', '3148616641', 36),
('RP037', 'Johana', 'Jaramillo orrego', 1, 24347391, 'Ejefincas.colombia@gmail.com', '3226325979', 37),
('RP038', 'JUAN DAVID', 'RINCON GONZALEZ', 1, 1018425549, 'gerencia@superinflable.com', '3187021060', 38),
('RP039', 'Josefina', 'Castro Daza', 1, 42490812, 'servicioalclientecasarosalia@hotmail.com', '3205662556', 39),
('RP040', 'SARA', 'GUERRA FLOREZ', 1, 1037611965, 'SARA@DIMOREH.COM', '3122722505', 40),
('RP041', 'Ronald', 'Calderón Trujillo', 1, 7708405, 'ceo@cycinstruments.com', '3004197760', 41),
('RP042', 'ALEXANDER', 'CALIXTO TORRES', 1, 13715392, 'gerencia@energreensas.com', '3022431956', 42),
('RP043', 'Iván', 'Salazar Penna', 1, 16186444, 'reservaeldanubio@gmail.com', '3202367654', 43),
('RP044', 'JAVIER ANDRES', 'SANCHEZ PINZÓN', 1, 17390998, 'MTORRES@FORTIS.COM.CO', '3187125919', 44),
('RP045', 'Elizabeth', 'Nuñez Arias', 1, 1094920544, 'Comercial@multisol.co', '3206068312', 45),
('RP046', 'Blanca Hilda', 'Hernandez Linares', 1, 40370375, 'casanare.hseq@cruzrojacolombiana.org', '3103417686', 46),
('RP047', 'Ricardo', 'Vera Torres', 1, 79791723, 'gerencia.general@tolimax.com.co', '3158372288', 47),
('RP048', 'Luis Alberto', 'Gonzalez Paredes', 1, 19400679, 'gerencia@sgingenieria.com', '3104220816', 48),
('RP049', 'Edward hamish', 'Meikle', 1, 417952, 'info@rioelemento.co', '3213397399', 49),
('RP050', 'LORENZO', 'VIDAL ROIG', 1, 162116, 'lriosol@gmail.com', '3103377879', 50),
('RP051', 'Diana Marcela', 'Lozano Mejía', 1, 1032357928, 'mejiaconsultoresjuridicos@gmail.com', '3017828722', 51),
('RP052', 'Vicente Antonio', 'Guerra Peña', 1, 71697863, 'vguerra@comunicacionactiva.com.co', '3152850945', 52),
('RP053', 'Claudia', 'Diaz Guzman', 1, 52390379, 'claudia@wildaboutcolombia.com', '3134571744', 53),
('RP054', 'Jorge Jovani', 'Flórez Rodríguez', 1, 80092350, 'solutionsincolombia@gmail.com', '3112271259', 54),
('RP055', 'ANGELA', 'GOMEZ GARCIA', 1, 24712563, 'agomez@naturecolombia.com', '3138529158', 55),
('RP056', 'ARGEMIRO', 'PEREA BETANCOURT', 1, 94526435, 'somosbccoffee@gmail.com', '3148883860', 56),
('RP057', 'Pablo David', 'Guevara Aguirre', 1, 80881243, 'Gerencia@elmana.com.co', '3208314502', 57),
('RP058', 'Andres Francisco de Paula Lazaro', 'Delgado Orozco', 1, 79153116, 'info@kaishitravel.com', '3203488399', 58),
('RP059', 'Felipe', 'Saravia Villalobos', 1, 80401469, 'Monstertransportcol@gmail.com', '3156074044', 59),
('RP060', 'HELIDA', 'LEON', 1, 39539530, 'eco_destinos@yahoo.com', '3167420286', 60),
('RP061', 'Alonso Jose', 'Borrero Donado', 1, 8733923, 'gborrero@classicjeans.com.co', '3014710886', 61),
('RP062', 'Jaime', 'Ramirez Ospina', 1, 70042266, 'edpradoq@gmail.com', '3182543184', 62),
('RP063', 'BETTY', 'GUERRERO MANOSALVA', 1, 49652702, 'DIEGO.DUARTE.G@COSMETICOSBELIER.COM', '3156124302', 63),
('RP064', 'CARLOS ANDRES', 'FORERO FRASSER', 1, 1022367904, 'jcf@mficolombia.com', '3137168523', 64),
('RP065', 'Angie Yulie', 'Velásquez Cuellar', 1, 43870645, 'avelasquez@nirvanaspacolombia.com', '3102042618', 65),
('RP066', 'Edgar Mauricio', 'Salgar Gallego', 1, 13484095, 'montegraciawellness@gmail.com', '3143866600', 66),
('RP067', 'Olga', 'Lopez Rincon', 1, 1015410564, 'serviprocesosdeingenieriaeosas@gmail.com', '3115679871', 67),
('RP068', 'MARIAJOSE', 'BELTRAN PUCHE', 1, 1125681299, 'mjbp1611@gmail.com', '3187168965', 68),
('RP069', 'YULY CATERINE', 'DÍAZ SÁNCHEZ', 1, 1088241513, 'yuly@innovacionesorion.com', '3017369305', 69),
('RP070', 'Amparo', 'Beltrán Puche', 1, 52413954, 'amparo.beltran@giseconsultores.com', '3182821476', 70),
('RP071', 'Paula Andrea', 'Villa Sánchez', 1, 42138645, 'Paula2713@gmail.com', '3162777103', 71),
('RP072', 'Teresa', 'Solá Molina', 1, 345260, 'info@interpretingcolombia.com', '3116860695', 72),
('RP073', 'Eleonora', 'Castro Rebolledo', 1, 51855955, 'eleonoracastrorebolledo@gmail.com', '3212430112', 73),
('RP074', 'Nina', 'Schlieper', 1, 398973, 'info@alternativetravelcartagena.com', '3203757261', 74),
('RP075', 'Oscar Mauricio', 'Marquez Ochoa', 1, 91282312, 'gerencia@lamartours.com', '3167522338', 75),
('RP076', 'Magdalena constanza', 'Niño tapias', 1, 46358150, 'Gerencia@transmor.com.co', '3118207673', 76),
('RP077', 'NATALIA', 'SANCHEZ NIÑO', 1, 1020833032, 'nataliasanchez05@hotmail.com', '3176816992', 77),
('RP078', 'ELIZABETH', 'AGUDELO VILLAMIZAR', 1, 51658567, 'fincavillagaby@gmail.com', '3133307045', 78),
('RP079', 'JORGE ANDRES', 'BUENDIA MOSQUERA', 1, 80419045, 'JORGE.BUENDIA@MELANGEGOURMET.COM', '3183305753', 79),
('RP080', 'Sergio Mario', 'Riberos Montero', 1, 1098630837, 'industriasmogotes@gmail.com', '3142505767', 80),
('RP081', 'Rossy Esmeralda', 'Arboleda de Rojas', 1, 51686066, 'rojasivan@tecnigasex.com', '3105545353', 81),
('RP082', 'JUAN CARLOS', 'RUEDA CARTAGENA', 1, 91281687, 'gerencia@spiffy.com.co', '3216427957', 82),
('RP083', 'Deiby', 'GUTIÉRREZ', 1, 7728742, 'gerencia@opitours.com', '3013129041', 83),
('RP084', 'JAIME HERNAN', 'MARTINEZ SERRANO', 1, 17095127, 'dlapel@outlook.com', '3112546427', 84),
('RP085', 'ADOLFO', 'CARLIER ARDILA', 1, 91102968, 'gerencia@incolpan.com.co', '3187173577', 85),
('RP086', 'ELIZABETH', 'SARMIENTO CUELLAR', 1, 31713036, 'directorcomercial@teamtravel.co', '3218556840', 86),
('RP087', 'Orlando', 'Martinez Nagle', 1, 1047392523, 'o.martinez@incentivamoscolombia.com', '3014684910', 87),
('RP088', 'Silvia Juliana', 'Navas Gutierrez', 1, 37514001, 'silvia.navas@todescol.co', '3102789897', 88),
('RP089', 'DEICY', 'MORENO MARTINEZ', 1, 41638412, 'gerencia@decimodotaciones.com', '3184320681', 89),
('RP090', 'Juan Carlos', 'Velasco Fajardo', 1, 76305551, 'acomercial@disenarmobiliario.com', '3168616993', 90),
('RP091', 'Rubi Baron', 'Baron De La Cruz', 1, 57302543, 'contactos@fuvyam.org', '3218502977', 91),
('RP092', 'María Fernanda', 'Villabona Hernandez', 1, 63319410, 'mariaf.villabona@ghlhoteles.com', '3157511945', 92);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `rol`
--

CREATE TABLE `rol` (
  `Id_rol` varchar(6) NOT NULL,
  `Nombre_Rol` varchar(15) DEFAULT NULL,
  `Descripción_Rol` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `rol`
--

INSERT INTO `rol` (`Id_rol`, `Nombre_Rol`, `Descripción_Rol`) VALUES
('Admin1', 'Administrador 1', 'Administrador principal del sistema'),
('Prom1', 'Programador', 'Este usuario corresponde al programador'),
('Usr1', 'Consultor', 'Este usuario corresponde a los consultores');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sector`
--

CREATE TABLE `sector` (
  `Id_sector` varchar(3) NOT NULL,
  `Sector` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `sector`
--

INSERT INTO `sector` (`Id_sector`, `Sector`) VALUES
('S01', 'Aeronáutico'),
('S02', 'Alimentos procesados'),
('S03', 'Astilleros'),
('S04', 'Audiovisuales y comunicaciones'),
('S05', 'BPO, KPO & ITO'),
('S06', 'Cacao y sus derivados'),
('S07', 'Café y sus derivados'),
('S08', 'Cárnicos'),
('S09', 'Comercio'),
('S10', 'Comunicación gráfica y editorial'),
('S11', 'Cosméticos y Aseo'),
('S12', 'Cuero, Calzado y Marroquinería'),
('S13', 'Educación'),
('S14', 'Energía eléctrica y bienes conexos'),
('S15', 'Farmacéuticos'),
('S16', 'Financiero'),
('S17', 'Frutas y derivados'),
('S18', 'Industrias de la construcción'),
('S19', 'Industrias del movimiento'),
('S20', 'Industrias extractivas'),
('S21', 'Instrumentos, equipos y aparatos eléctricos'),
('S22', 'Lácteos'),
('S23', 'Maquinaria'),
('S24', 'Palma y aceite de palma'),
('S25', 'Piscícola'),
('S26', 'Plásticos'),
('S27', 'Química básica'),
('S28', 'Software y TI'),
('S29', 'Textil y confección'),
('S30', 'Transporte'),
('S31', 'Turismo'),
('S32', 'Salud');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tamaño_empresa`
--

CREATE TABLE `tamaño_empresa` (
  `Id_Tamaño_empresa` varchar(6) NOT NULL,
  `Tamaño_empresa` varchar(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `tamaño_empresa`
--

INSERT INTO `tamaño_empresa` (`Id_Tamaño_empresa`, `Tamaño_empresa`) VALUES
('I', 'Microempresa'),
('II', 'Pequeña empresa'),
('III', 'Mediana empresa'),
('IIII', 'Grande empresa');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipo_documento`
--

CREATE TABLE `tipo_documento` (
  `Id_Tipo_Documento` int(11) NOT NULL,
  `Tipo_de_documento` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `tipo_documento`
--

INSERT INTO `tipo_documento` (`Id_Tipo_Documento`, `Tipo_de_documento`) VALUES
(1, 'Cédula de Ciudadanía'),
(2, 'Cédula de Extranjería'),
(3, 'Pasaporte');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE `usuario` (
  `Id_Usuario` varchar(4) NOT NULL,
  `No_documento` varchar(11) NOT NULL,
  `Contraseña` varchar(8) DEFAULT NULL,
  `Id_profesional` varchar(4) NOT NULL,
  `Id_rol` varchar(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`Id_Usuario`, `No_documento`, `Contraseña`, `Id_profesional`, `Id_rol`) VALUES
('U001', '1234567', 'C1234567', 'P001', 'Admin1'),
('U002', '9876541', 'C1234568', 'P002', 'Admin1'),
('U003', '1022345612', 'C1234569', 'P003', 'Prom1'),
('U004', '19395521', 'C1234570', 'P004', 'Usr1'),
('U005', '29876866', 'C1234571', 'P005', 'Usr1'),
('U006', '88159931', 'C1234572', 'P006', 'Usr1'),
('U007', '98399223', 'C1234573', 'P007', 'Usr1'),
('U008', '1013588408', 'C1234574', 'P008', 'Usr1'),
('U009', '42897545', 'C1234575', 'P009', 'Usr1'),
('U010', '19151981', 'C1234576', 'P010', 'Usr1'),
('U011', '43725134', 'C1234577', 'P011', 'Usr1'),
('U012', '14883735', 'C1234578', 'P012', 'Usr1'),
('U013', '24334445', 'C1234579', 'P013', 'Usr1'),
('U014', '31579172', 'C1234580', 'P014', 'Usr1'),
('U015', '32888240', 'C1234581', 'P015', 'Usr1'),
('U016', '80196336', 'C1234582', 'P016', 'Usr1'),
('U017', '88251040', 'C1234583', 'P017', 'Usr1'),
('U018', '63467337', 'C1234584', 'P018', 'Usr1'),
('U019', '14136199', 'C1234585', 'P019', 'Usr1'),
('U020', '42793482', 'C1234586', 'P020', 'Usr1'),
('U021', '52221023', 'C1234587', 'P021', 'Usr1'),
('U022', '79672087', 'C1234588', 'P022', 'Usr1'),
('U023', '80087778', 'C1234589', 'P023', 'Usr1'),
('U024', '46385391', 'C1234590', 'P024', 'Usr1'),
('U025', '79521725', 'C1234591', 'P025', 'Usr1'),
('U026', '36276021', 'C1234592', 'P026', 'Usr1'),
('U027', '43629944', 'C1234593', 'P027', 'Usr1'),
('U028', '46674027', 'C1234594', 'P028', 'Usr1'),
('U029', '94403956', 'C1234595', 'P029', 'Usr1'),
('U030', '1015399482', 'C1234596', 'P030', 'Usr1'),
('U031', '4585468', 'C1234597', 'P031', 'Usr1'),
('U032', '8028747', 'C1234598', 'P032', 'Usr1'),
('U033', '8710036', 'C1234599', 'P033', 'Usr1'),
('U034', '40440706', 'C1234600', 'P034', 'Usr1'),
('U035', '79758085', 'C1234601', 'P035', 'Usr1'),
('U036', '91256204', 'C1234602', 'P036', 'Usr1'),
('U037', '19166505', 'C1234603', 'P037', 'Usr1'),
('U038', '79340356', 'C1234604', 'P038', 'Usr1'),
('U039', '29877655', 'C1234605', 'P039', 'Usr1'),
('U040', '34319078', 'C1234606', 'P040', 'Usr1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20201130171605_CreateIdentitySchema', '3.1.10');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `actividades`
--
ALTER TABLE `actividades`
  ADD PRIMARY KEY (`Id_actividad`),
  ADD KEY `Id_etapa` (`Id_etapa`),
  ADD KEY `Id_proyecto` (`Id_proyecto`),
  ADD KEY `Id_profesional` (`Id_profesional`);

--
-- Indices de la tabla `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`);

--
-- Indices de la tabla `aspnetroles`
--
ALTER TABLE `aspnetroles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Indices de la tabla `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- Indices de la tabla `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- Indices de la tabla `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- Indices de la tabla `aspnetusers`
--
ALTER TABLE `aspnetusers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);

--
-- Indices de la tabla `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Indices de la tabla `cargos`
--
ALTER TABLE `cargos`
  ADD PRIMARY KEY (`Id_cargo`);

--
-- Indices de la tabla `citaconsultoria`
--
ALTER TABLE `citaconsultoria`
  ADD PRIMARY KEY (`id_citaconsultoria`);

--
-- Indices de la tabla `contacto_empresa`
--
ALTER TABLE `contacto_empresa`
  ADD PRIMARY KEY (`Id_Contacto_empresa`);

--
-- Indices de la tabla `departamento`
--
ALTER TABLE `departamento`
  ADD PRIMARY KEY (`Código_Departamento`);

--
-- Indices de la tabla `eje_seleccionado`
--
ALTER TABLE `eje_seleccionado`
  ADD PRIMARY KEY (`Id_eje`),
  ADD KEY `Id_proyecto` (`Id_proyecto`);

--
-- Indices de la tabla `empresa`
--
ALTER TABLE `empresa`
  ADD PRIMARY KEY (`Id_empresa`),
  ADD KEY `Código_Departamento` (`Código_Departamento`),
  ADD KEY `Código_Municipio` (`Código_Municipio`),
  ADD KEY `Id_sector` (`Id_sector`),
  ADD KEY `Id_Tamaño_empresa` (`Id_Tamaño_empresa`),
  ADD KEY `Id_eje` (`Id_eje`),
  ADD KEY `Id_proyecto` (`Id_proyecto`),
  ADD KEY `Id_profesional` (`Id_profesional`);

--
-- Indices de la tabla `estudios`
--
ALTER TABLE `estudios`
  ADD PRIMARY KEY (`Id_estudio`);

--
-- Indices de la tabla `etapas`
--
ALTER TABLE `etapas`
  ADD PRIMARY KEY (`Id_etapa`),
  ADD KEY `Id_proyecto` (`Id_proyecto`);

--
-- Indices de la tabla `herramientas`
--
ALTER TABLE `herramientas`
  ADD PRIMARY KEY (`Id_herramienta`),
  ADD KEY `Id_eje` (`Id_eje`);

--
-- Indices de la tabla `identityuser<string>`
--
ALTER TABLE `identityuser<string>`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `municipio`
--
ALTER TABLE `municipio`
  ADD PRIMARY KEY (`Código_Municipio`),
  ADD KEY `Código_Departamento` (`Código_Departamento`);

--
-- Indices de la tabla `profesional`
--
ALTER TABLE `profesional`
  ADD PRIMARY KEY (`Id_profesional`),
  ADD UNIQUE KEY `No_documento` (`No_documento`),
  ADD KEY `Id_Tipo_Documento` (`Id_Tipo_Documento`),
  ADD KEY `Id_Profesion` (`Id_Profesion`),
  ADD KEY `Id_estudio` (`Id_estudio`),
  ADD KEY `Id_cargo` (`Id_cargo`),
  ADD KEY `Id_proyecto` (`Id_proyecto`),
  ADD KEY `Id_eje` (`Id_eje`);

--
-- Indices de la tabla `profesiones`
--
ALTER TABLE `profesiones`
  ADD PRIMARY KEY (`Id_Profesion`);

--
-- Indices de la tabla `proyecto`
--
ALTER TABLE `proyecto`
  ADD PRIMARY KEY (`Id_proyecto`);

--
-- Indices de la tabla `representante_legal`
--
ALTER TABLE `representante_legal`
  ADD PRIMARY KEY (`Id_repr_legal`),
  ADD UNIQUE KEY `No_documento` (`No_documento`),
  ADD KEY `Id_Tipo_Documento` (`Id_Tipo_Documento`),
  ADD KEY `Id_empresa` (`Id_empresa`);

--
-- Indices de la tabla `rol`
--
ALTER TABLE `rol`
  ADD PRIMARY KEY (`Id_rol`);

--
-- Indices de la tabla `sector`
--
ALTER TABLE `sector`
  ADD PRIMARY KEY (`Id_sector`);

--
-- Indices de la tabla `tamaño_empresa`
--
ALTER TABLE `tamaño_empresa`
  ADD PRIMARY KEY (`Id_Tamaño_empresa`);

--
-- Indices de la tabla `tipo_documento`
--
ALTER TABLE `tipo_documento`
  ADD PRIMARY KEY (`Id_Tipo_Documento`);

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`Id_Usuario`),
  ADD UNIQUE KEY `No_documento` (`No_documento`),
  ADD KEY `Id_profesional` (`Id_profesional`),
  ADD KEY `Id_rol` (`Id_rol`);

--
-- Indices de la tabla `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `empresa`
--
ALTER TABLE `empresa`
  MODIFY `Id_empresa` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=258;

--
-- AUTO_INCREMENT de la tabla `representante_legal`
--
ALTER TABLE `representante_legal`
  MODIFY `Id_empresa` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=93;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `actividades`
--
ALTER TABLE `actividades`
  ADD CONSTRAINT `actividades_ibfk_1` FOREIGN KEY (`Id_etapa`) REFERENCES `etapas` (`Id_etapa`),
  ADD CONSTRAINT `actividades_ibfk_2` FOREIGN KEY (`Id_proyecto`) REFERENCES `proyecto` (`Id_proyecto`),
  ADD CONSTRAINT `actividades_ibfk_3` FOREIGN KEY (`Id_profesional`) REFERENCES `profesional` (`Id_profesional`);

--
-- Filtros para la tabla `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `eje_seleccionado`
--
ALTER TABLE `eje_seleccionado`
  ADD CONSTRAINT `eje_seleccionado_ibfk_1` FOREIGN KEY (`Id_proyecto`) REFERENCES `proyecto` (`Id_proyecto`);

--
-- Filtros para la tabla `empresa`
--
ALTER TABLE `empresa`
  ADD CONSTRAINT `empresa_ibfk_1` FOREIGN KEY (`Código_Departamento`) REFERENCES `departamento` (`Código_Departamento`),
  ADD CONSTRAINT `empresa_ibfk_2` FOREIGN KEY (`Código_Municipio`) REFERENCES `municipio` (`Código_Municipio`),
  ADD CONSTRAINT `empresa_ibfk_3` FOREIGN KEY (`Id_sector`) REFERENCES `sector` (`Id_sector`),
  ADD CONSTRAINT `empresa_ibfk_4` FOREIGN KEY (`Id_Tamaño_empresa`) REFERENCES `tamaño_empresa` (`Id_Tamaño_empresa`),
  ADD CONSTRAINT `empresa_ibfk_5` FOREIGN KEY (`Id_eje`) REFERENCES `eje_seleccionado` (`Id_eje`),
  ADD CONSTRAINT `empresa_ibfk_6` FOREIGN KEY (`Id_proyecto`) REFERENCES `proyecto` (`Id_proyecto`),
  ADD CONSTRAINT `empresa_ibfk_7` FOREIGN KEY (`Id_profesional`) REFERENCES `profesional` (`Id_profesional`);

--
-- Filtros para la tabla `etapas`
--
ALTER TABLE `etapas`
  ADD CONSTRAINT `etapas_ibfk_1` FOREIGN KEY (`Id_proyecto`) REFERENCES `proyecto` (`Id_proyecto`);

--
-- Filtros para la tabla `herramientas`
--
ALTER TABLE `herramientas`
  ADD CONSTRAINT `herramientas_ibfk_1` FOREIGN KEY (`Id_eje`) REFERENCES `eje_seleccionado` (`Id_eje`);

--
-- Filtros para la tabla `municipio`
--
ALTER TABLE `municipio`
  ADD CONSTRAINT `municipio_ibfk_1` FOREIGN KEY (`Código_Departamento`) REFERENCES `departamento` (`Código_Departamento`);

--
-- Filtros para la tabla `profesional`
--
ALTER TABLE `profesional`
  ADD CONSTRAINT `profesional_ibfk_1` FOREIGN KEY (`Id_Tipo_Documento`) REFERENCES `tipo_documento` (`Id_Tipo_Documento`),
  ADD CONSTRAINT `profesional_ibfk_2` FOREIGN KEY (`Id_Profesion`) REFERENCES `profesiones` (`Id_Profesion`),
  ADD CONSTRAINT `profesional_ibfk_3` FOREIGN KEY (`Id_estudio`) REFERENCES `estudios` (`Id_estudio`),
  ADD CONSTRAINT `profesional_ibfk_4` FOREIGN KEY (`Id_cargo`) REFERENCES `cargos` (`Id_cargo`),
  ADD CONSTRAINT `profesional_ibfk_5` FOREIGN KEY (`Id_proyecto`) REFERENCES `proyecto` (`Id_proyecto`),
  ADD CONSTRAINT `profesional_ibfk_6` FOREIGN KEY (`Id_eje`) REFERENCES `eje_seleccionado` (`Id_eje`);

--
-- Filtros para la tabla `representante_legal`
--
ALTER TABLE `representante_legal`
  ADD CONSTRAINT `representante_legal_ibfk_1` FOREIGN KEY (`Id_Tipo_Documento`) REFERENCES `tipo_documento` (`Id_Tipo_Documento`),
  ADD CONSTRAINT `representante_legal_ibfk_2` FOREIGN KEY (`Id_empresa`) REFERENCES `empresa` (`Id_empresa`);

--
-- Filtros para la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD CONSTRAINT `usuario_ibfk_1` FOREIGN KEY (`Id_profesional`) REFERENCES `profesional` (`Id_profesional`),
  ADD CONSTRAINT `usuario_ibfk_2` FOREIGN KEY (`Id_rol`) REFERENCES `rol` (`Id_rol`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
