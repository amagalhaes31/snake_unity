# :snake: Snake

Este projeto tem como objetivo consolidar os conhecimentos adquiridos sobre desenvolvimento de jogos utilizando a plataforma Unity 3D da disciplina DM117 do curso de Pós Graduação de Desenvolvimento de Aplicações para Dispositivos Móveis e Cloud Computing do [Inatel](https://www.inatel.br/pos/).

## :video_game: O Jogo
O jogo possui uma tela inicial conforme apresentado na imagem a seguir:

<img src="https://github.com/amagalhaes31/snake_unity/blob/master/.github/tela_inicial.png">

Como pode ser observado, possui um botão chamado **"JOGAR"** para iniciar a partida. Após iniciada aparecerá a imagem abaixo com um som de suspense.

<p align="center">
<img src="https://github.com/amagalhaes31/snake_unity/blob/master/.github/tela_jogo.PNG">
</p>

Nesta imagem podemos observar os seguintes itens:

| Função | Descrição |
| --- | --- | 
| Score | Indica a pontuação na rodada |
| High Score | Indica a pontuação máxima do jogador durante a partida |
| Life | Indica a quantidade de vidas disponíveis pelo jogador |
| Maçã | Objeto em vermelho que representa a comida da snake |
| Snake | Objeto de cor verde, onde a cabeça possui cor verde escura e o seu corpo em verde claro |
| Botão Pause | Pausa o jogo |

O jogo é controlado pelas teclas do teclado do PC ou laptop:

| Teclas | Descrição |
| --- | --- | 
| W ou Seta para Cima | Direciona a snake para cima |
| S ou Seta para Baixo | Direciona a snake para baixo |
| A ou Seta para Esquerda | Direciona a snake para esquerda |
| D ou Seta para Direita | Direciona a snake para direita|


O jogador possui no máximo três vidas, a cada vida que ele perde o pontuação **Score** é zerada automaticamente. A pontuação **Score** é incrementada quando a **snake** come a **maçã** que vale 100 pontos gerando um efeito de *Particle System*. O valor do **High Score** é atualizado quando o valor do **Score** for maior que ele. 
Durante a partida o jogador poderá pausar o jogo a qualquer momento. Quando pressionado o botão **Pause**, aparecerá a seguinte tela:

<p align="center">
<img src="https://github.com/amagalhaes31/snake_unity/blob/master/.github/tela_pausado.PNG">
</p>

Como podemos observar é apresentado ao jogador três opções:

| Botões | Descrição |
| --- | --- | 
| Continuar  | Retorna do ponto que o jogador pausou a partida |
| Reiniciar | Reinicializa a partida |
| Menu Principal | Retorna a tela inicial do jogo |


O joagdor perde sua vida em dois momentos: (I) quando bate em uma das quatros paredes e (II) quando bate em seu próprio corpo, então o jogo apresenta a mensagem **You Lose!** conforme exibido na figura abaixo:

<p align="center">
<img src="https://github.com/amagalhaes31/snake_unity/blob/master/.github/tela_lose.png">
</p>

Após perder as três vidas, Game Over, o jogador perde o jogo. A partir disso são apresentadas as seguintes opções:

<p align="center">
<img src="https://github.com/amagalhaes31/snake_unity/blob/master/.github/tela_game_over.PNG">
</p>

| Botões | Descrição |
| --- | --- | 
| Continuar (Ad)  | Apresenta a tela de anúncios (advertisements) |
| Reiniciar | Reinicializa a partida |
| Menu Principal | Retorna a tela inicial do jogo |


A tela de anuncios pode ser observada pela imagem a seguir:

<p align="center">
<img src="https://github.com/amagalhaes31/snake_unity/blob/master/.github/tela_ad.PNG">
</p>


Se o jogador assistir o anúncio ele ganha uma vida na partida podendo jogar novamente, se ele pressionar o botão de **Skip** reinicia a partida zerando a pontuação.


## :wrench: Ferramentas
 - Unity 3D versão 2020.1.0f1 Personal
 - Linguagem C# utilizando Visual Studio
 
 
## :star: Agradecimentos
Agradeço ao professor [Christopher Lima](https://www.linkedin.com/in/christopher-lima-13050597/) pelas aulas ministradas.


## :boy: Desenvolvedores
 - [Alexandre Magalhães](https://www.linkedin.com/in/alexandre-magalh%C3%A3es-1919a68b/)
 - [Breno Ribeiro do Val](https://www.linkedin.com/in/breno-do-val-8a9149195/)
 
 
