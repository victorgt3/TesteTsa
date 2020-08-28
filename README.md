# TesteTsa



Este projeto foi implemento com padrão CQRS usando os conceitos do DDD.
No domínio de dados “Demo.Dal” usei o SqlServer como base de dados. Onde está as migrations, 
para executar altere a ConnectionString que está dentro Demo.Dal no appsettings.json 
DefaultConnection ponte para seu banco e rode o segue comando 
update-migration -Context BrtContext.

Como esse comando será criado as tabelas e o banco de dados.  
Abra o projeto no visual studio execute e abrira na uma aba no seu navegador com Swagger e a documentação dos end-points 
