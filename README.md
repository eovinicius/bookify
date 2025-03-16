# Bookify

## 🏗️ Estrutura do projeto

- **Domain Layer (Camada de Core):** Define as entidades de domínio e as regras de negócio, além disso temos interfaces de repositórios da camada infraestrutura, etc.

- **Application Layer (Camada de Aplicação):** Contém a lógica de negócios da aplicação e os casos de uso da aplicação, além disso serve para possibilitar a comunicação da camada de Presentation com a camada Core, mesmo sem ter conhecimento da camada de apresentação (Presentation Layer).

- **Infrastructure Layer (Camada de Infraestrutura):** Camada mais externa da Clean Architecture, pois lida com os serviços externos como Frameworks e Drivers.

- **Presentation Layer (Camada de Apresentação):** Camada que que lida com a entrada e saída de dados e se comunica com as camadas mais internas para lidarem com o processamento das informações.

## 🛠️ Tecnologias Utilizadas

- **ASP.NET Core Web Api:** Framework para o desenvolvimento APIs.

- **Entity Framework Core:** ORM para mapeamento objeto-relacional, simplificando o acesso a dados.

- **Postgres SQL:** Banco de dados utilizado para armazenamento de dados.

- **Swagger:** Ferramenta que auxilia na documentação da API, seguindo as sugestões da OpenAPI.

- **MediatR:** Biblioteca utilizada reduzir o acoplamento entre objetos e faz a abstração da comunicação entre componentes.

- **Fluent Validations:** Biblioteca utilizada para fazer validações de entrada de uma forma mais simplificada e legível.

## ✨ Padrões de Projetos Utilizados

- **Domain Driven Design:** Utilizados alguns conceitos desta abordagem, visando desenvolver a aplicação dirigida ao domínio.

- **CQRS:** Padrão utilizado junto com o MediatR, visando a segregação de comandos de escrita dos comandos de leituras do banco de dados.

- **Unit Of Work:** Padrão utilizado para criar uma unidade única de trabalho, o que reduz a concorrência no banco de dados e permite lidar com múltiplas transações.

- **Code First:** Abordagem que visa gerar as entidades do banco de dados através das entidades presente no código.
