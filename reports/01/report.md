# Report 01 - Queda de performance
- ID: \[Prog\] E001
- Prioridade: Alta
  - Impede jogabilidade

## Descrição
Performance do jogo cai após alguns segundos.

## Reprodução
Iniciar o jogo.

## Resultado Encrontrado
Baixa taxa de quadros.

## Resultado Esperado
Taxa de quadros estável.

## Root cause
Verificando o _profiling_, temos um pico na categoria `Others` seguido de uma grande carga em `Physics`.

![Gráficos do profiling](https://github.com/hfsaito/BJL01_EngSoft_QA/blob/main/reports/01/profiling-graphs.png?raw=true)

Verificando a parte _Hierarchy_ do _profiling_, é possível ver que a função `Instantiate` foi chamada 1500 vezes.

![Hierarchy do profiling](https://github.com/hfsaito/BJL01_EngSoft_QA/blob/main/reports/01/profiling-hierarchy.png?raw=true)

Procurando por `Instantiate` no código, cheguei no arquivo `Assets/EnemySpawner.cs` que instancia 1500 `GameObject`s a cada 10s.

No editor da Unity, clicando com botão direito no script `EnemySpawner` e depois em "Find references in scene", podemos ver que há um objeto chamado "Decor" usando este script.

![Hierarchy do profiling](https://github.com/hfsaito/BJL01_EngSoft_QA/blob/main/reports/01/Decor.png?raw=true)

Investigando aonde este objeto é usado. É um elemento usado para agrupar outros game objects que são items, inimigos e decorações no cenário jogável.

![Hierarchy do profiling](https://github.com/hfsaito/BJL01_EngSoft_QA/blob/main/reports/01/Decor-tree.png?raw=true)

Como o `Instantiate` usa a posição do game object que possui o script, verifiquei a posição de `Decor` na cena apertando a tecla `F`.

![Hierarchy do profiling](https://github.com/hfsaito/BJL01_EngSoft_QA/blob/main/reports/01/Decor-position.png?raw=true)

Logo se conclui que o script `EnemySpawner` deve ter sido feito para rodar um stress test de quantos inimigos conseguimos carregar porem foi esquecido. Os objetos agrupados pelo game object `Decor` não possuem relação com o script.

## Correção
Como o script `EnemySpawner` usa o posicionamento de `Decor` e seus objetos filhos não tem relação, a correção involde dois pontos:
- Renomear o objeto `Decor` para identificarmos no editor de que se trata de um objeto de  teste. Remover ou desabilitar o script `EnemySpawner` do objeto `Decor`;
- Mover seus game objects filhos para `Grid` assim evitando que ao mover o objeto de teste, não impacte nos objetos do level.

https://github.com/hfsaito/BJL01_EngSoft_QA/commit/7eaac0ed92216b71d66d63a1b7623dde3ca91f25
