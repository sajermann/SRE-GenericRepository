@echo off 
echo Sistema de Migracoes, selecione a opcao desejada: 
@echo 1 - Criar Migration
@echo 2 - Atualizar Database
set /P optionUser=Opcao:
if %optionUser%==1 set /P migrationName=Nome da Migration:
if %optionUser%==1 GOTO AddMigration
if %optionUser%==2 GOTO UpdateDatabase
else exit




:AddMigration
echo Opcao escolhida: %optionUser%
echo NomeMigration: %migrationName%
call dotnet ef migrations add %migrationName% -p GenericRepository.Data -s GenericRepository.Api
GOTO UpdateDatabase

:UpdateDatabase
call dotnet ef database update -s GenericRepository.Api
GOTO End


:End
set /P bye=Pressione qualquer tecla para sair: