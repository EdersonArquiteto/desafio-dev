<h1 align="center">
    <img src="logo.jpg"/>
    <p>desenvolvedor Full Stack - Ler um arquivo de Movimentações Bancárias</p>
</h1>

##📙 About

O objetivo do projeto é fazer com que o usuário seja capaz de carregar um arquivo de movimentações bancárias de algumas lojas e consiga visualizar o saldo da conta bancária de cada loja após a realização dessas movimentações. 

## 🧪 Conceituação
O projeto foi desenvolvido utilizando o conceito de serviços. Sendo assim o usuário irá conseguir ler o arquivo de movimentações bancárias através de uma WEB API que será disponibilizada como serviço. 
## Arquitetura 
A arquitetura/modelagem de software do Projeto é baseada em DDD - Domain Driven Design conseguindo assim: 
- Reutilização do código;
- Mínimo de acoplamento e alta coesão;
- Independência de Tecnologia;
- Código/Projeto alinhado com o negócio.

## 🔨 Ferramentas utilizadas

### BackEnd

- [Liguagem C#](https://learn.microsoft.com/pt-br/dotnet/csharp/tour-of-csharp/); 
- Metodologia: Orientação a objetos<br> com SOLID;
- Framework .NET Core 6.0;
- [Fluent Validation](https://docs.fluentvalidation.net/en/latest/) - Para validação<br> das regras de domínio
- Bando de dados SQL Server;
- Padrão Repository com [Entity Framework 6](https://learn.microsoft.com/en-us/ef/core/);
- [AutoMapper](https://automapper.org/) para mapeamento de Objetos; 
- [XUNIT](https://xunit.net/) para criação de Testes Unitários;
- [JWT](https://jwt.io/) para Autenticação de usuários.

### FrontEnd

- [Angular 16](https://angular.io/guide/update-to-version-16);
- Bootstrap;

##👨‍💻 Como utilizar 

```bash
$ git clone https://github.com/EdersonArquiteto/desafio-dev.git
````
<p>Para o BackEnd</p>

- Abra o diretório API e em seguida Abra o arquivo EOS.CNAB.sln com o Visual Studio;
- Altere a Connection String do arquivo appSettings.json localizado nos projetos EOS.CNAB.API, EOS.CNAB.InfraStructure, EOS.CNAB.UnitTest fazendo com que aponte para o banco de dados que você criar para a utilização do projeto. 
- Defina o projeto EOS.CNAB.InfraStructure como projeto de Inicialização e execute os comandos abaixo para criação das tabelas no banco;

```bash
Add-Migration Initial
``````
```bash
Update-Database
````

<p> Para o FrontEnd</p>

```bash
#Entre no diretório
$ cd UI
```
```bash
#Execute o comando
$ npm install
```

