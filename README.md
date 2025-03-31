# ListaTarefa - Aplicação Web

## Descrição
Este projeto é uma aplicação web construída com ASP.NET MVC para gerenciamento de tarefas simples e eficiente. Com este sistema, os usuários podem facilmente adicionar, visualizar, editar e remover suas tarefas diárias.

## Funcionalidades Principais
- **Adicionar Tarefas**: Insira novas tarefas de maneira simples.
- **Listar Tarefas**: Visualize todas as tarefas cadastradas.
- **Editar Tarefas**: Atualize o conteúdo das tarefas existentes.
- **Excluir Tarefas**: Remova tarefas que não são mais necessárias.

## Tecnologias Utilizadas
- **ASP.NET MVC**
- **jQuery** e **jQuery Validation** para validação de formulários
- **UIKit** para componentes adicionais de UI

## Instalação e Execução

1. **Clone o repositório:**
```bash
git clone https://github.com/joaoemanoelaho/ListaTarefa/
```

2. **Configurar a string de conexão:**
- No arquivo appsettings.json, defina a string de conexão na seção ConnectionStrings:
```
{
  "ConnectionStrings": {
    "DefaultConnection": "server=SEU_SERVIDOR\\SQLEXPRESS; database=ListaDeTarefa; trusted_connection=true; trustservercertificate=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```
  
3. **Acesse o diretório do projeto:**
```bash
cd ListaTarefa
```

4. **Execute o projeto:**
```bash
dotnet run
```


## Contribuição
Sinta-se à vontade para contribuir com melhorias ou correções enviando pull requests.

## Autor
João Emanoel de Araújo Henriques Oliveira

