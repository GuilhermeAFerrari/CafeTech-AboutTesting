@echo off

:: Instala o dotnet-reportgenerator-globaltool com a versão 5.1.26
dotnet tool install dotnet-reportgenerator-globaltool --version 5.1.26 --tool-path .tools

:: Verifica se o diretório .testResult existe e o remove, se existir
if exist .\.testResult\ (
	echo.
	echo removendo diretorio existente .\testResult
	echo.
    rmdir /s /q .\.testResult\
)

:: Executa os testes do projeto
dotnet test .\tests\CafeTechCalculator.UnitTests\ --results-directory:".testResult\temp" --collect:"XPlat Code Coverage"
dotnet test .\tests\CafeTechCalculator.IntegrationTests\ --results-directory:".testResult\temp" --collect:"XPlat Code Coverage"

:: Move o arquivo de cobertura gerado
REM move .\.testResult\temp\*.coverage.cobertura.xml .\.testResult\unit.coverage.cobertura.xml

:: Remove o diretório .coverageReport, se existir
if exist .\.coverageReport\ (
	echo.
	echo apagando diretorio .\coverageReport
	echo.
    rmdir /s /q .\.coverageReport\
)

:: Usa a ferramenta ReportGenerator para gerar um relatório de cobertura HTML
.\.tools\reportgenerator "-reports:.\.testResult\temp\**\*coverage.cobertura.xml" "-targetdir:.coverageReport" "-reporttypes:HtmlInline"

if exist .\.testResult\ (
	echo.
	echo removendo diretorio existente .\testResult
	echo.
    rmdir /s /q .\.testResult\
)

:: Pausa para que você possa ver os resultados
pause