echo "Start SonarQube scanner c#";
dotnet sonarscanner begin /key:"brka-bank" /d:sonar.cs.opencover.reportsPaths="test\*.Test\lcov.opencover.xml" /d:sonar.coverage.exclusions="*Test*.cs";
dotnet build;
dotnet test /p:CollectCoverage=true /p:Include="[Brka.*]*" /p:CoverletOutputFormat=opencover /p:CoverletOutput=./lcov /p:CopyLocalLockFileAssemblies=true;
dotnet sonarscanner end;