# Proj_ProspEco

**Proj_ProspEco** é uma API desenvolvida para promover o gerenciamento eficiente de recursos energéticos, incluindo aparelhos, bandeiras tarifárias, metas e consumo energético. O projeto utiliza boas práticas de desenvolvimento de software, como injeção de dependência, design patterns e arquitetura em camadas.

---

## 📋 **Funcionalidades**

- Gerenciamento de **Aparelhos** com suporte a operações CRUD (Create, Read, Update, Delete).
- Registro e consulta de **bandeiras tarifárias**.
- Controle de **metas de consumo energético**.
- Notificação de **conquistas** com base em metas atingidas.
- Registro de consumo energético por usuários.
- Documentação da API usando **Swagger**.

---

## 🚀 **Tecnologias Utilizadas**

- **.NET Core 6.0**: Para desenvolvimento da API.
- **Entity Framework Core**: Para mapeamento objeto-relacional (ORM).
- **Oracle Database**: Banco de dados relacional utilizado no projeto.
- **Swagger**: Para documentação da API.
- **Dependency Injection**: Para a implementação de serviços e repositórios.
- **SOLID**: Princípios aplicados para um código mais escalável e fácil de manter.

---

## 🛠️ **Setup do Projeto**

### **Pré-requisitos**

- **.NET SDK** 6.0 ou superior
- **Oracle Database** configurado e rodando
- Editor de código, como **Visual Studio Code** ou **Visual Studio**
- Configuração da connection string no arquivo `appsettings.json`

### **Instalação**

1. Clone o repositório:
   ```bash
   git clone <url-do-repositorio>
Navegue para o diretório do projeto:

bash
Copiar código
cd Proj_ProspEco
Configure a string de conexão no arquivo appsettings.json:

json
Copiar código
"ConnectionStrings": {
  "OracleFIAP": "Data Source=<endereco_do_banco>;User Id=<usuario>;Password=<senha>;"
}
Restaure as dependências:

```bash
Copiar código
dotnet restore
Execute o projeto:

```bash
Copiar código
dotnet run
🧪 Endpoints da API
Aparelhos
GET /api/aparelho: Lista todos os aparelhos.
GET /api/aparelho/{id}: Retorna um aparelho específico pelo ID.
POST /api/aparelho: Cria um novo aparelho.
PUT /api/aparelho/{id}: Atualiza um aparelho existente.
DELETE /api/aparelho/{id}: Remove um aparelho pelo ID.
📝 Estrutura do Projeto
A estrutura do projeto segue a arquitetura em camadas, promovendo separação de responsabilidades:


Proj_ProspEco
├── Controllers        # Controladores da API
├── Data               # Configuração do DbContext
├── Models             # Modelos de dados
├── Persistencia
│   ├── Repositories   # Repositórios para acesso ao banco de dados
│   ├── Services       # Lógica de negócios e serviços
├── Properties         # Arquivos de configuração
├── appsettings.json   # Configuração do ambiente

✅ Boas Práticas Aplicadas
SOLID: Implementado em repositórios e serviços.
Injeção de Dependência: Para gerenciamento de dependências no projeto.
Swagger: Para documentação de API clara e acessível.
Clean Code: Código legível e bem estruturado.
📚 Documentação
A documentação da API está disponível através do Swagger. Após iniciar a aplicação, acesse o link:

```bash
Copiar código
http://localhost:<porta>/swagger
📌 Contribuindo
Contribuições são bem-vindas! Siga os passos abaixo para contribuir:

Fork este repositório.
Crie uma nova branch: git checkout -b minha-feature.
Faça suas alterações e commite: git commit -m 'Minha nova feature'.
Faça o push da branch: git push origin minha-feature.
Abra um Pull Request.
👨‍💻 Autor
David Bryan Viana De Sales - RM - 551236
Desenvolvedor responsável por soluções práticas e eficientes em projetos de software.

