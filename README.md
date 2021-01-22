# Home Broker Process

Esse é um projeto de criação de um homebroker, cuja suas principais funcionalidade são:
- Permitir que o usuário faça aportes e retiradas na sua conta;
- Permitir a compra e venda de ações, de acordo com a cotação atual, subtraindo e somando do saldo da conta, respectivamente;
 
As tecnologias utilizadas neste repositórios e suas dependências estão abaixos;
#### Frontend
O projeto frontend foi utilizado um template e construído a aplicação sobre ele, a pasta do projeto encontra-se dentro deste repositório cuja o nome é frontend.
- Angular
- Template [Creative Tim](https://www.creative-tim.com/)

#### Backend
- CQRS (Mediatr) - Para contexto de negócios onde temos regras complexas o CQRS se aplica muito bem e deixa os comandos mais didáticos para a área de negócio
- DDD Domain driven Design - Para aproximar o código ao negócio
- PostgreSQL como banco de dados
- Elasticsearch/Kibana - Para armazenagem de logs de aplicação/erros
- Serilog - Para utilização dos logs
- Dapper como ORM principal, motivo - como o contexto de negócio possui muitas requisições foi escolhido para otimização das querys
- Fluent Migrator - Para controle da base de dados com as criações de campos etc...
- OfxSharp - Para leitura dos arquivos Ofx
- NSwag - Para documentação das APIs
- NSubstitute - Para fazer os mocks no contexto do teste, para não fazer vínculo com a base de dados
- Autenticação JWT - Para realizar a autenticação basta preencher o usuário/instituição que ele irá gerar um token para ser utilizados nos demais endpoints