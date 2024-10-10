CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Categorias` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nome` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `Ativo` tinyint(1) NOT NULL,
    `DataCadastro` DATETIME NOT NULL,
    `DataInativacao` DATETIME NULL,
    CONSTRAINT `PK_Categorias` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Produtos` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nome` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `Descricao` TEXT CHARACTER SET utf8mb4 NULL,
    `Preco` DECIMAL(10,2) NOT NULL,
    `Ativo` tinyint(1) NOT NULL,
    `DataCadastro` DATETIME NOT NULL,
    `DataInativacao` DATETIME NULL,
    `CategoriaId` int NOT NULL,
    CONSTRAINT `PK_Produtos` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Produtos_Categorias_CategoriaId` FOREIGN KEY (`CategoriaId`) REFERENCES `Categorias` (`Id`) ON DELETE RESTRICT
) CHARACTER SET=utf8mb4;

CREATE INDEX `IX_Produtos_CategoriaId` ON `Produtos` (`CategoriaId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20241009175935_InitialCreate', '8.0.8');

COMMIT;

