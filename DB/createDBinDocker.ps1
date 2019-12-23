docker run --rm -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=St@rt123" -p 1433:1433 --name abdserver -d mcr.microsoft.com/mssql/server:2019-GA-ubuntu-16.04
# docker build -t "abdserver:Dockerfile" .
docker cp .\createDb.sql abdserver:.
docker exec abdserver /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "St@rt123" -I -i createDb.sql