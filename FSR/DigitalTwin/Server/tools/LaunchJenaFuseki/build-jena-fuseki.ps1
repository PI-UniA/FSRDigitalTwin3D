# Build the Jena Fuseki Database using Maven
Set-Location -Path $PSScriptRoot/../../modules/Jena/
mvn -pl :apache-jena-fuseki -am package