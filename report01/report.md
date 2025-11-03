# Report 01 - Queda de performance
## Descrição
Performance do jogo cai após alguns segundos

## Reprodução
Iniciar o jogo

## Resultado Encrontrado
Baixa taxa de quadros

## Resultado Esperado
Taxa de quadros estável

## Root cause
Verificando o _profiling_, temos um pico na categoria `Others` seguido de uma grande carga em `Physics`
![Gráficos do profiling](https://github.com/hfsaito/BJL01_EngSoft_QA/blob/main/report01/profiling-graphs.png?raw=true)

Verificando a parte _Hierarchy_ do _profiling_, é possível ver que a função `Instantiate` foi chamada 1500 vezes
![Hierarchy do profiling](https://github.com/hfsaito/BJL01_EngSoft_QA/blob/main/report01/profiling-hierarchy.png?raw=true)

Procurando por `Instantiate` no código, cheguei no arquivo `Assets/EnemySpawner.cs` que instancia 1500 `GameObject`s a cada 10s

No editor da Unity, clicando com botão direito no script `EnemySpawner` e depois em "Find references in scene", podemos ver que há um objeto chamado "Decor" usando este script.
![Hierarchy do profiling](https://github.com/hfsaito/BJL01_EngSoft_QA/blob/main/report01/Decor.png?raw=true)

Investigando aonde este objeto é usado. Preque que é um elemento usado para agrupar outros game objects que são items, inimigos e decorações no cenário.
![Hierarchy do profiling](https://github.com/hfsaito/BJL01_EngSoft_QA/blob/main/report01/Decor-tree.png?raw=true)

Como o `Instantiate` usa a posição do game object que possui o script, verifiquei a posição de `Decor` na cena apertando a tecla `F`
![Hierarchy do profiling](https://github.com/hfsaito/BJL01_EngSoft_QA/blob/main/report01/Decor-position.png?raw=true)

## Correção
O script `EnemySpawner` deve ter sido feito para rodar um stress test de quantos inimigos conseguimos carregar porem foi esquecido. Os objetos agrupados pelo game object `Decor` não possuem relação com o script.

Como o script `EnemySpawner` usa o posicionamento de `Decor` e seus objetos filhos não tem relação a correção é remover ou desabilitar o script `EnemySpawner`. Renomear `Decor` para identificarmos no editor de que se trata de um objeto de  teste, e mover seus game objects filhos para `Grid` assim evitando de se mover no objeto de teste afetar os objetos do level