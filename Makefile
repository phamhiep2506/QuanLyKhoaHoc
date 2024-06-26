default: clean run

dev: clean watch

build:
	dotnet build

clean:
	dotnet clean

watch:
	dotnet watch --project src/KhoaHoc/KhoaHoc.Api

run:
	dotnet run --project src/KhoaHoc/KhoaHoc.Api

db.add:
	dotnet ef migrations add $(name) --project src/KhoaHoc/KhoaHoc.Infrastructure --startup-project src/KhoaHoc/KhoaHoc.Api -o Data/Migrations

db.remove:
	dotnet ef migrations remove --project src/KhoaHoc/KhoaHoc.Infrastructure --startup-project src/KhoaHoc/KhoaHoc.Api

db.list:
	dotnet ef migrations list --project src/KhoaHoc/KhoaHoc.Infrastructure --startup-project src/KhoaHoc/KhoaHoc.Api

db.update:
	dotnet ef database update --project src/KhoaHoc/KhoaHoc.Infrastructure --startup-project src/KhoaHoc/KhoaHoc.Api

db.drop:
	dotnet ef database drop --project src/KhoaHoc/KhoaHoc.Infrastructure --startup-project src/KhoaHoc/KhoaHoc.Api

mssql.create:
	sudo docker volume create mssql-volume-manual
	sudo docker run -e "ACCEPT_EULA=Y" \
		-e "SA_PASSWORD=Password123" \
		--name mssql-server-manual \
		--user root \
		-p 1433:1433 \
		-v mssql-volume-manual:/var/opt/mssql/data \
		-d mcr.microsoft.com/mssql/server:2022-latest

mssql.delete: mssql.stop
	sudo docker container rm -f mssql-server-manual
	sudo docker volume rm -f mssql-volume-manual

mssql.start:
	sudo docker container start mssql-server-manual

mssql.stop:
	sudo docker container stop mssql-server-manual

docker.up:
	sudo docker-compose up -d

docker.down:
	sudo docker-compose down --remove-orphans

docker.build:
	sudo docker-compose up --build -d && sudo docker image prune

mailhog.run:
	sudo docker run \
		-d \
		-p 1025:1025 \
		-p 8025:8025 \
		--name mailhog-server-manual \
		mailhog/mailhog

mailhog.start:
	sudo docker container start mailhog-server-manual

mailhog.stop:
	sudo docker container stop mailhog-server-manual

mailhog.delete: mailhog.stop
	sudo docker container rm -f mailhog-server-manual