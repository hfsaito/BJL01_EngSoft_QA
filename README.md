# Quality Assurance Report

Engenharia de software - Atividade 03

Autor: Hiroshi Farias Saito

## Reports

### Queda de performance
#### Descrição
Performance do jogo cai após alguns segundos

#### Reprodução
Iniciar o jogo

#### Resultado Encrontrado
Baixa taxa de quadros

#### Resultado Esperado
Taxa de quadros estável

#### Root cause
Verificando o _profiling_, temos um pico na categoria `Others` seguido de uma grande carga em `Physics`
![Gráficos do profiling](https://github.com/hfsaito/BJL01_EngSoft_QA/blob/main/report1/profiling-graphs.jpg?raw=true)

Verificando a parte _Hierarchy_ do _profiling_, é possível ver que a função `Instantiate` foi chamada 1500 vezes
![Hierarchy do profiling](https://github.com/hfsaito/BJL01_EngSoft_QA/blob/main/report1/profiling-hierarchy.jpg?raw=true)

Procurando por `Instantiate` no código, cheguei no arquivo `Assets/EnemySpawner.cs` que instancia 1500 `GameObject`s a cada 10s
