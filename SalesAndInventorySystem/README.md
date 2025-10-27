# Projeto

---

## Sobre as decis�es tomadas
De acordo com os requerimentos do projeto, foram solicitados:
1. Microservi�o 1 (Gest�o de Estoque): 
   Respons�vel por cadastrar produtos, controlar o estoque e fornecer informa��es sobre a quantidade dispon�vel. 
- Onde:
	- Cadastro de Produtos: Adicionar novos produtos com nome, descri��o, pre�o e quantidade em estoque. 
	- Consulta de Produtos: Permitir que o usu�rio consulte o cat�logo de produtos e a quantidade dispon�vel em estoque. 
	- Atualiza��o de Estoque: O estoque deve ser atualizado quando ocorrer uma venda (integra��o com o Microservi�o de Vendas).

Portanto, ficou subentendido que n�o se faz necess�rio a cria��o de um m�todo que deleta dados do banco.
Sendo assim, optei por adicionar um m�todo chamado `Delete`, por�m o mesmo fica respons�vel apenas por alterar um status do
estoque para `Available` ou `Unavailable`.
Fazendo com que apenas itens dispon�veis sejam listados aos usu�rios. Garantindo uma maior rastreabilidade dos dados. 
Como por exemplo, saber o que foi registrado. Evitando que ocorra a polui��o ao retornar esses dados ao usu�rio,
no caso de um mesmo item ser registrado diversas vezes por um erro de digita��o.

---

### Value Objects
A fim de garantir a possibilidade de escalabilidade do projeto,
foram criados VOs para al�m de n�o quebrar a aplica��o. 
Garantindo tamb�m, que n�o ocorra a exposi��o direta de nossa entidade ao consumidor final (client).]

