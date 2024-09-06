## Como iniciar esse projeto localmente.

Para iniciar o projeto em mode de desenvolvimento, primeiramente é necessario ter o Docker instalado em seu computador. 
Segue o link da documentação para instalação em sua máquina https://www.docker.com/ 

Após ter instalado o Docker, é necessário realizar o clone deste projeto.
Realizado o clone do projeto basta entrar na pasta e digitar o comando abaixo:

```bash
docker compose up --build -d
```

## Para executar o balanceamento de carga com NGINX, digite os comandos
```bash
docker run -d -p 5001:80 fluxocaixasaldoconsolidado
docker run -d -p 5002:80 fluxocaixasaldoconsolidado
docker run -d -p 5003:80 fluxocaixasaldoconsolidado

docker network create saldo-diario-net

docker run -d --network saldo-diario-net --name saldo1 -p 5001:80 fluxocaixasaldoconsolidado
docker run -d --network saldo-diario-net --name saldo2 -p 5002:80 fluxocaixasaldoconsolidado
docker run -d --network saldo-diario-net --name saldo3 -p 5003:80 fluxocaixasaldoconsolidado

docker run -d -p 80:80 --network saldo-diario-net -v $(pwd)/nginx.conf:/etc/nginx/nginx.conf:ro nginx
## Substitua $(pwd) pelo caminho absoluto do diretorio onde o arquivo nginx.conf esta localizado.
## no meu caso: docker run -d -p 80:80 --network saldo-diario-net -v C:/Users/Administrador/Documents/nginx.conf:/etc/nginx/nginx.conf:ro nginx
```

## para visualizar o banco de dados
Para ter acesso ao banco de dados sql, caso queira manipular ou visualizar todas as transacoes:
* http://localhost:8080/index.php



## Com o container iniciado as seguintes url's serão disponibilizadas para testar os endPoins:
* http://localhost:49160/swagger/index.html - Lancamentos
* http://localhost:5298/swagger/index.html - Saldo Consolidado

## Com o container iniciado a seguintes url será disponibilizadas para acessar a interface grafica:

* http://localhost:49168/home - Front"# fluxoDeCaixaDotNet" 
