# Report 04 - Contador de vida sem limites
- ID: \[Prog\] E004
- Prioridade: Média
  - Comportamento inesperado na jogabilidade

## Descrição
Ao receber muito dano ou recuperar a vira multiplas vezes, é possível ver o mostrador de vida passando dos limites do mostrador

## Reprodução
2 modos de produzir
- Encostar no inimigo multiplas vezes
- Passar pelo item coração multiplas vezes

## Resultado Encrontrado
A barra que indica os pontos de vida passa dos limites determinados pelo game object `Border`

![Indicador de vida menor que o limite](https://github.com/hfsaito/BJL01_EngSoft_QA/blob/main/reports/04/life-below-zero.png?raw=true)

![Indicador de vida maior que o limite](https://github.com/hfsaito/BJL01_EngSoft_QA/blob/main/reports/04/life-over-maximum.png?raw=true)

## Resultado Esperado
A barra que indica os pontos de vida fica nos limites determinados pelo game object `Border`

## Root cause
Verificando o método `MudarVida` no script `Assets/MyAssets/Scripts/Player.cs` é possível ver que a alteração dos pontos de vida é feito direto no atributo `vida` sem usar o outro atributo `vidaMaxima` ou checar se o valor chega a ser negativo.

## Correção
Utilizar a função `Math.Clamp` ou estatégia similar para evitar que os pontos de vida ultrapassem os limites

https://github.com/hfsaito/BJL01_EngSoft_QA/commit/5e4bea882a1e93b51c1ca26d002eef03ef5fbd5d
