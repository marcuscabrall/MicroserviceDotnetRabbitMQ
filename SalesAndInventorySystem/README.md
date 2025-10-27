# Projeto

---

## Sobre as decisões tomadas
De acordo com os requerimentos do projeto, foram solicitados:
1. Microserviço 1 (Gestão de Estoque): 
   Responsável por cadastrar produtos, controlar o estoque e fornecer informações sobre a quantidade disponível. 
- Onde:
	- Cadastro de Produtos: Adicionar novos produtos com nome, descrição, preço e quantidade em estoque. 
	- Consulta de Produtos: Permitir que o usuário consulte o catálogo de produtos e a quantidade disponível em estoque. 
	- Atualização de Estoque: O estoque deve ser atualizado quando ocorrer uma venda (integração com o Microserviço de Vendas).

Portanto, ficou subentendido que não se faz necessário a criação de um método que deleta dados do banco.
Sendo assim, optei por adicionar um método chamado `Delete`, porém o mesmo fica responsável apenas por alterar um status do
estoque para `Available` ou `Unavailable`.
Fazendo com que apenas itens disponíveis sejam listados aos usuários. Garantindo uma maior rastreabilidade dos dados. 
Como por exemplo, saber o que foi registrado. Evitando que ocorra a poluição ao retornar esses dados ao usuário,
no caso de um mesmo item ser registrado diversas vezes por um erro de digitação.

---

### Value Objects
A fim de garantir a possibilidade de escalabilidade do projeto,
foram criados VOs para além de não quebrar a aplicação. 
Garantindo também, que não ocorra a exposição direta de nossa entidade ao consumidor final (client).]

