# ReceitaFederal

Essa aplicação é uma simples API para consulta dos dados abertos da receita federal. Foi desenvolvida utilizando o Framework ASP.NET para C#.

### Rotas
A API possui uma única rota do tipo HTTP GET e aceita um único parâmetro, o CNPJ da empresa para a consulta no banco de dados:
http://localhost:5000/cnpj/{cnpj} -> http://localhost:5000/cnpj/00000000000191

### Migration
Ao executar a aplicação utilizando o parâmetro "--migration" os dados abertos da receita federal serão descarregados, extraídos para arquivos CSV através do utilitário [CNPJ-Full](https://github.com/fabioserpa/CNPJ-full). 
Com a conclusão do processo de extração para CSV, os dados presentes nos arquivos CSV serão enviados para um banco de dados MongoDB.

### Configuração

As configurações para a conexão do banco de dados estão localizadas no arquivo [MongoConfig.cs](https://github.com/GDnsk/ReceitaFederal/blob/master/Config/MongoConfig.cs)

### CNPJ-Full
O [utilitário](https://github.com/fabioserpa/CNPJ-full) para a extração dos dados da receita federal para arquivos CSV desenvolvido por Fabio Serpa, se encontra na pasta [CNPJ_Base_Parser](https://github.com/GDnsk/ReceitaFederal/tree/master/CNPJ_Base_Parser)
