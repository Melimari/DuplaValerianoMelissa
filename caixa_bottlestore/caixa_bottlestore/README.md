# Sistema de Caixa - Bottle Store

## Configuração Inicial

### 1. Configurar o Banco de Dados MySQL

1. **Instalar MySQL Server** (se ainda não tiver)
2. **Executar o script de configuração**:
   - Abra o MySQL Workbench ou linha de comando
   - Execute o arquivo `database_setup.sql`
   - Este script criará o banco `bottle_store` e todas as tabelas necessárias

### 2. Configurar a Conexão

O sistema usa as seguintes configurações padrão:
- **Servidor**: localhost
- **Porta**: 3306
- **Banco**: bottle_store
- **Usuário**: root
- **Senha**: (vazia)

Se suas configurações forem diferentes, você pode alterar no arquivo `Data/Db.cs`.

### 3. Primeira Execução

Na primeira execução do sistema:
1. O sistema verificará a conexão com o banco de dados
2. Se a conexão for bem-sucedida, abrirá diretamente na tela principal
3. Não há mais sistema de autenticação - acesso direto às funcionalidades

## Solução de Problemas

### Problema: "Não foi possível conectar ao banco de dados"

**Possíveis causas:**
1. MySQL não está rodando
2. Banco de dados `bottle_store` não existe
3. Credenciais incorretas

**Soluções:**
1. Verifique se o MySQL está rodando
2. Execute o script `database_setup.sql`
3. Verifique as credenciais no arquivo `Data/Db.cs`

### Problema: Sistema não abre

**Possíveis causas:**
1. Banco de dados não foi configurado
2. Erro na conexão com o MySQL

**Soluções:**
1. Execute o script `database_setup.sql`
2. Verifique se o MySQL está rodando
3. Configure as credenciais corretas no arquivo `Data/Db.cs`

## Estrutura do Projeto

- **Forms/**: Formulários da interface
- **Models/**: Modelos de dados (produtos, vendas)
- **Services/**: Serviços de negócio
- **Data/**: Configuração do banco de dados

## Funcionalidades

- **Gerenciar Produtos**: Adicionar, editar e remover produtos
- **Vendas**: Registrar vendas e itens de venda
- **Relatórios**: Visualizar dados de vendas e produtos

