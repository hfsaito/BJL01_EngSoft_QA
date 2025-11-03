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
Verificando o profiling
Temos um pico na categoria Others seguido de uma grande carga em Physics
