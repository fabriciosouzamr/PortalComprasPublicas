# Projeto WebAPI em DDD

Este é um projeto WebAPI utilizando o padrão de arquitetura DDD (Domain-Driven Design). O projeto inclui uma API para gerenciar entidades como Cliente e Produto, armazenando-as em um banco de dados MySQL, e logs de segurança (`LogSec`) armazenados em um banco de dados SQLite.

## Estrutura do Projeto

- **Domain**: Contém as entidades e interfaces.
- **Application**: Contém os serviços de aplicação que implementam a lógica de negócio.
- **Infrastructure**: Contém a implementação de persistência (repositórios) e configuração dos bancos de dados.
- **API**: Contém os controladores que expõem as APIs.