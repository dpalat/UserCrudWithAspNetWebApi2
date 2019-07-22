@echo off
REM tool made with OpenCover + ReportGenerator
cls
REM Create a 'GeneratedReports' folder if it does not exist
if not exist "%tmp%\OpenCover_GeneratedReports" mkdir "%tmp%\OpenCover_GeneratedReports"

REM Remove any previous test execution files to prevent issues overwriting
IF EXIST "%tmp%\TestCoverage.trx" del "%tmp%\TestCoverage.trx%"
IF EXIST "%tmp%\OpenCover_GeneratedReports\TestCoverage.trx" del "%tmp%\OpenCover_GeneratedReports\TestCoverage.trx%"

REM Remove any previously created test output directories
CD %tmp%\OpenCover_GeneratedReports\
FOR /D /R %%X IN (%USERNAME%*) DO RD /S /Q "%%X"

CD %~dp0
FOR /D /R %%X IN (%USERNAME%*) DO RD /S /Q "%%X"

REM Run the tests against the targeted output
call :RunOpenCoverUnitTestMetrics

REM Generate the report output based on the test results
if %errorlevel% equ 0 (
call :RunReportGeneratorOutput
)

REM Launch the report
if %errorlevel% equ 0 (
call :RunLaunchReport
)
exit /b %errorlevel%

REM -target:"%VS140COMNTOOLS%..\IDE\mstest.exe" ^
REM -targetargs:"/testcontainer:\"%~dp0Tests\Framework.Tests\bin\Debug\Framework.Tests.dll\" /testcontainer:\"%~dp0Tests\Domain.Tests\bin\Debug\Domain.Tests.dll\" /resultsfile:\"%tmp%\OpenCover_GeneratedReports\TestCoverage.trx\" " ^
//
rem "%USERPROFILE%\.nuget\packages\opencover\4.7.922\tools\OpenCover.Console.exe"

:RunOpenCoverUnitTestMetrics
cls
"%~dp0..\packages\OpenCover.4.7.922\tools\OpenCover.Console.exe" ^
-register:user ^
-target:"%VS140COMNTOOLS%..\IDE\mstest.exe" ^
-targetargs:"/testcontainer:\"%~dp0\UserCrud.Domain.UnitTest\bin\Debug\UserCrud.Domain.UnitTest.dll\" /testcontainer:\"%~dp0\UsersCrud.Repository.UnitTest\bin\Debug\UsersCrud.Repository.UnitTest.dll\" " ^
-filter:" +[*]* -[*.Tests*]* -[*.UnitTest*]* -[Flurl*]* -[MvvmCross.*]* -[Xamarin.*]* -[*]*.XForms.Templates.* -[*]*.XForms.Views.* -[Plugin.*]* -[*]*.Resources* " ^
-mergebyhash ^
-oldStyle ^
-output:"%tmp%\OpenCover_GeneratedReports\TestCoverage.xml"

exit /b %errorlevel%
rem "%USERPROFILE%\.nuget\packages\reportgenerator\4.2.10\tools\ReportGenerator.exe" ^

:RunReportGeneratorOutput
"%~dp0..\packages\ReportGenerator.4.2.10\tools\NET47\ReportGenerator.exe" ^
-reports:"%tmp%\OpenCover_GeneratedReports\TestCoverage.xml" ^
-targetdir:"%tmp%\OpenCover_GeneratedReports\ReportGenerator Output"
exit /b %errorlevel%

:RunLaunchReport
pause

start "report" "%tmp%\OpenCover_GeneratedReports\ReportGenerator Output\index.htm"

IF EXIST "TestResult.xml" del "TestResult.xml"

exit /b %errorlevel%

:END