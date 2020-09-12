CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `Contas` (
    `id` int NOT NULL AUTO_INCREMENT,
    `idUsuario` int NOT NULL,
    `tipo` int NOT NULL,
    `codigoAgencia` int NOT NULL,
    `numero` int NOT NULL,
    `digito` int NOT NULL,
    `saldo` decimal(65,30) NOT NULL,
    CONSTRAINT `PK_Contas` PRIMARY KEY (`id`, `idUsuario`, `tipo`)
);

CREATE TABLE `Transacao` (
    `id` int NOT NULL AUTO_INCREMENT,
    `idConta` int NOT NULL,
    `idUsuario` int NOT NULL,
    `dataTransacao` datetime(6) NOT NULL,
    `saldoEmConta` decimal(65,30) NOT NULL,
    `valor` decimal(65,30) NOT NULL,
    `tipoTransacao` int NOT NULL,
    CONSTRAINT `PK_Transacao` PRIMARY KEY (`id`, `idConta`, `idUsuario`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200911155217_Mi', '3.1.8');

INSERT INTO Contas VALUES (1, 1, 1, 4763, 11458621, 1, 12500);