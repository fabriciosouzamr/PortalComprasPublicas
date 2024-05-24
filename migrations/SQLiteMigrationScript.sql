CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "LogSecs" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_LogSecs" PRIMARY KEY,
    "DataHora" TEXT NOT NULL,
    "Rotina" TEXT NOT NULL,
    "Descricao" TEXT NOT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240524003914_InitialCreate', '7.0.10');

COMMIT;

