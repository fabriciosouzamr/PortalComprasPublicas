CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Clientes` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Nome` varchar(250) CHARACTER SET utf8mb4 NOT NULL,
    `Endereco` varchar(500) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Clientes` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Produtos` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Nome` varchar(250) CHARACTER SET utf8mb4 NOT NULL,
    `Preco` numeric(65,30) NOT NULL,
    CONSTRAINT `PK_Produtos` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20240524011525_InitialCreate', '7.0.10');

COMMIT;

