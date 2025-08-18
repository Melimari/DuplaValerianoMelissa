# Solução para os Problemas de Conexão com o Banco de Dados

## Problemas Identificados

1. **Sistema não consegue conectar ao banco de dados**
2. **Erro de conexão ao iniciar o aplicativo**

## Causa Raiz

O problema principal é que o **banco de dados não está configurado corretamente**. O sistema tenta conectar ao MySQL, mas falha silenciosamente.

## Solução Passo a Passo

### 1. Verificar se o MySQL está rodando

1. Abra o **Serviços do Windows** (Win+R → services.msc)
2. Procure por **MySQL** ou **MySQL80**
3. Verifique se está **Em execução**
4. Se não estiver, clique com botão direito → **Iniciar**

### 2. Configurar o Banco de Dados

#### Opção A: Usando MySQL Workbench
1. Abra o **MySQL Workbench**
2. Conecte ao seu servidor MySQL
3. Abra o arquivo `database_setup.sql`
4. Execute o script completo

#### Opção B: Usando linha de comando
1. Abra o **Prompt de Comando** como administrador
2. Navegue até a pasta do projeto
3. Execute:
   ```cmd
   mysql -u root -p < database_setup.sql
   ```

#### Opção C: Copiar e colar no MySQL
1. Abra o MySQL Workbench ou linha de comando
2. Copie todo o conteúdo do arquivo `database_setup.sql`
3. Cole e execute no MySQL

### 3. Verificar se funcionou

Execute o script `test_database.sql` para verificar se tudo foi criado corretamente.

### 4. Testar o Sistema

1. Execute o aplicativo
2. O sistema deve abrir diretamente na tela principal
3. Não há mais sistema de login - acesso direto às funcionalidades

## Se ainda não funcionar

### Verificar configuração de conexão

Abra o arquivo `Data/Db.cs` e verifique se a string de conexão está correta:

```csharp
return "server=localhost;port=3306;database=bottle_store;uid=root;pwd=;SslMode=none;";
```

Se suas configurações forem diferentes, altere:
- `uid=root` → seu usuário MySQL
- `pwd=` → sua senha MySQL
- `port=3306` → sua porta MySQL

### Testar conexão manualmente

1. Abra o MySQL Workbench
2. Tente conectar com as mesmas credenciais do arquivo `Db.cs`
3. Se não conseguir, o problema é na configuração do MySQL

## Mensagens de Erro Comuns

### "Access denied for user 'root'@'localhost'"
- A senha do MySQL está incorreta
- Altere a string de conexão no arquivo `Db.cs`

### "Unknown database 'bottle_store'"
- O banco não foi criado
- Execute o script `database_setup.sql`

### "Can't connect to MySQL server"
- O MySQL não está rodando
- Inicie o serviço MySQL

## Após resolver

1. O sistema abrirá diretamente na tela principal
2. Você poderá acessar todas as funcionalidades sem autenticação
3. Gerenciar produtos, vendas e relatórios diretamente

## Próximos Passos

Após a conexão com o banco:
1. Vá em **Gerenciar Produtos** para adicionar produtos
2. Use **Vendas** para registrar vendas
3. Acesse **Relatórios** para visualizar dados

